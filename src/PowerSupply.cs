using System;
using System.IO.Ports;
using System.Threading.Tasks;

namespace Riden
{
    public class PowerSupply : IDisposable
    {
        public enum Status
        {
            Off,
            CV,
            CC,
            OVP,
            OCP,
            OPP,
        }

        public enum Regulation
        {
            CV,
            CC,
        }

        public enum Protection
        {
            None,
            OVP,
            OCP,
            OPP,
        }

        public class Dataset
        {
            public double Voltage { get; set; }
            public double Current { get; set; }
            public double VoltageLimit { get; set; }
            public double CurrentLimit { get; set; }
            public double PowerLimit { get; set; }
            public int Brightness { get; set; }
            public int MemoryPreset { get; set; }
            public bool KeepOutputEnabled { get; set; }
            public bool EnableOutputAtPowerOn { get; set; }
        }

        public class TaskQueue
        {
            public void QueueCommand(Action asyncAction)
            {
                QueueCommand(asyncAction, null);
            }

            public void QueueCommand(Action asyncAction, Action uiAction)
            {
                lock (this)
                {
                    var oldTask = currentTask;

                    var task = Task.Run(delegate
                    {
                        try
                        {
                            if (oldTask != null)
                            {
                                oldTask.Wait();
                            }

                            asyncAction();
                        }
                        catch (ModbusException e)
                        {
                            Console.Error.WriteLine($"Modbus exception: {e.Message}");
                        }
                    });

                    currentTask = task.ContinueWith(delegate
                    {
                        uiAction?.Invoke();
                    }, TaskScheduler.FromCurrentSynchronizationContext());
                }
            }

            public void Clear()
            {
                lock (this)
                {
                    currentTask = null;
                }
            }

            Task currentTask;
        }

        public ModbusClient ModbusClient => modbusClient;
        public TaskQueue CommandQueue => commandQueue;
        public bool IsConnected => modbusClient.IsOpen;

        
        public int Address
        {
            get { return modbusClient.SlaveAddress; }
            set { modbusClient.SlaveAddress = value; }
        }

        public double SetVoltage
        {
            get { return setVoltage; }
            set
            {
                var registerValue = ToShort(Limit(value, MaxVoltage) / VoltageResolution);
                if (registerValue != ToShort(setVoltage / VoltageResolution))
                {
                    WriteRegister(0x00, registerValue);
                    setVoltage = registerValue * VoltageResolution;
                }
            }
        }

        public double SetCurrent
        {
            get { return setCurrent; }
            set
            {
                var registerValue = ToShort(Limit(value, MaxCurrent) / CurrentResolution);
                if (registerValue != ToShort(setCurrent / CurrentResolution))
                {
                    WriteRegister(0x01, registerValue);
                    setCurrent = registerValue * CurrentResolution;
                }
            }
        }

        public bool OutputEnabled
        {
            get { return outputEnabled; }
            set
            {
                WriteRegister(0x09, (ushort)(value ? 1 : 0));
                outputEnabled = value;
            }
        }

        public bool ControlsLocked
        {
            get { return controlsLocked; }
            set
            {
                WriteRegister(0x06, (ushort)(value ? 1 : 0));
                controlsLocked = value;
            }
        }

        public int Brightness
        {
            get { return brightness; }
            set
            {
                WriteRegister(0x0A, (ushort)value);
                brightness = value;
            }
        }

        public int MemoryPreset
        {
            get { return ReadRegister(0x23); }
            set
            {
                WriteRegister(0x23, (ushort)value);
            }
        }

        public Regulation RegulationStatus => regulation;
        public Protection ProtectionStatus => protection;
        public double OutputVoltage => outputVoltage;
        public double OutputCurrent => outputCurrent;
        public double OutputPower => outputPower;
        public double InputVoltage => inputVoltage;
        public int ProductModel => productModel;
        public int FirmwareVersion => firmwareVersion;

        public double VoltageResolution => 0.01;
        public double CurrentResolution => 0.001;
        public double PowerResolution => 0.01;

        public double DatasetVoltageResolution => 0.01;
        public double DatasetCurrentResolution => 0.001;
        public double DatasetPowerResolution => 0.1;

        public double MaxVoltage
        {
            get
            {
                switch (productModel)
                {
                    case 3003:
                    case 3005:
                        return 32.0;
                    case 5005:
                    case 5015:
                    case 5020:
                        return 50.0;
                    case 8005:
                        return 80.0;
                    default:
                        return 32.0;
                }
            }
        }

        public double MaxCurrent
        {
            get
            {
                switch (productModel)
                {
                    case 3003:
                        return 3.0;
                    case 3005:
                    case 5005:
                    case 8005:
                        return 5.0;
                    case 5015:
                        return 15.0;
                    case 5020:
                        return 20.0;
                    default:
                        return 5.0;
                }
            }
        }

        public Status OutoutStatus
        {
            get
            {
                switch (protection)
                {
                    case Protection.OVP:
                        return Status.OVP;
                    case Protection.OCP:
                        return Status.OCP;
                    case Protection.OPP:
                        return Status.OPP;
                    default:
                        if (outputEnabled)
                        {
                            return regulation == Regulation.CV ? Status.CV : Status.CC;
                        }
                        else
                        {
                            return Status.Off;
                        }
                }
            }
        }

        public static string[] EnumeratePorts()
        {
            return SerialPort.GetPortNames();
        }

        public void Open(string port, int baudRate = 9600)
        {
            Close();
            Clear();
            modbusClient.Open(port, baudRate, StopBits.One, Parity.None);
        }

        public void Close()
        {
            modbusClient.Close();
        }

        public void Clear()
        {
            commandQueue.Clear();

            outputEnabled = false;
            regulation = Regulation.CV;
            protection = Protection.None;
            setVoltage = 0.0;
            setCurrent = 0.0;
            outputVoltage = 0.0;
            outputCurrent = 0.0;
            outputPower = 0.0;
            inputVoltage = 0.0;
            controlsLocked = false;
            brightness = 0;
            productModel = 0;
            firmwareVersion = 0;
        }

        public void Flush()
        {
            modbusClient.Flush();
        }

        public void ReadAll()
        {
            var registers = ReadRegisters(0x00, 13);
            UpdateSetData(registers, 0);
            UpdateOutputData(registers, 0);
            UpdateProductData(registers, 0);
        }

        public void ReadSetData()
        {
            var registers = ReadRegisters(0x00, 2);
            UpdateSetData(registers, 0x00);
        }

        public void ReadOutputData()
        {
            var registers = ReadRegisters(0x00, 11);
            UpdateSetData(registers, 0x00);
            UpdateOutputData(registers, 0x00);
        }

        public void ReadProductData()
        {
            var registers = ReadRegisters(0x0B, 2);
            UpdateProductData(registers, 0x0B);
        }

        public Dataset LoadDataset(int index)
        {
            var registers = ReadRegisters(0x50 + index * 0x10, 8);

            return new Dataset
            {
                Voltage = registers[0] * DatasetVoltageResolution,
                Current = registers[1] * DatasetCurrentResolution,
                VoltageLimit = registers[2] * DatasetVoltageResolution,
                CurrentLimit = registers[3] * DatasetCurrentResolution,
                PowerLimit = registers[4] * DatasetPowerResolution,
                Brightness = registers[5],
                KeepOutputEnabled = registers[6] != 0,
                EnableOutputAtPowerOn = registers[7] != 0
            };
        }

        public void SaveDataset(int index, Dataset dataset)
        {
            var registers = new ushort[8];
            registers[0] = ToShort(dataset.Voltage / DatasetVoltageResolution);
            registers[1] = ToShort(dataset.Current / DatasetCurrentResolution);
            registers[2] = ToShort(dataset.VoltageLimit / DatasetVoltageResolution);
            registers[3] = ToShort(dataset.CurrentLimit / DatasetCurrentResolution);
            registers[4] = ToShort(dataset.PowerLimit / DatasetPowerResolution);
            registers[5] = (ushort)dataset.Brightness;
            registers[6] = (ushort)(dataset.KeepOutputEnabled ? 1 : 0);
            registers[7] = (ushort)(dataset.EnableOutputAtPowerOn ? 1 : 0);
            WriteRegisters(0x50 + index * 0x10, registers);
        }

        public void Dispose()
        {
            ((IDisposable)modbusClient).Dispose();
        }

        void UpdateSetData(ushort[] registers, int offset)
        {
            setVoltage = registers[0x00 - offset] * VoltageResolution;
            setCurrent = registers[0x01 - offset] * CurrentResolution;
        }

        void UpdateOutputData(ushort[] registers, int offset)
        {
            outputVoltage = registers[0x02 - offset] * VoltageResolution;
            outputCurrent = registers[0x03 - offset] * CurrentResolution;
            outputPower = registers[0x04 - offset] * PowerResolution;
            inputVoltage = registers[0x05 - offset] * VoltageResolution;
            controlsLocked = registers[0x06 - offset] != 0;
            protection = (Protection)registers[0x07 - offset];
            regulation = (Regulation)registers[0x08 - offset];
            outputEnabled = registers[0x09 - offset] != 0;
            brightness = registers[0x0A - offset];
        }

        void UpdateProductData(ushort[] registers, int offset)
        {
            productModel = registers[0x0B - offset];
            firmwareVersion = registers[0x0C - offset];
        }

        ushort ReadRegister(int address)
        {
            return ReadRegisters(address, 1)[0];
        }

        ushort[] ReadRegisters(int address, int count)
        {
            return modbusClient.ReadHoldingRegisters((ushort)address, (ushort)count);
        }

        void WriteRegister(int address, ushort value)
        {
            modbusClient.WriteSingleRegister((ushort)address, (ushort)(value));
        }

        void WriteRegisters(int address, ushort[] values)
        {
            modbusClient.WriteMultipleRegisters((ushort)address, values);
        }

        static double Limit(double value, double maxValue)
        {
            return Math.Min(Math.Max(value, 0.0), maxValue);
        }

        static ushort ToShort(double value)
        {
            return (ushort)Math.Round(value);
        }

        readonly ModbusClient modbusClient = new ModbusClient();
        readonly TaskQueue commandQueue = new TaskQueue();
        bool outputEnabled = false;
        Regulation regulation = Regulation.CV;
        Protection protection = Protection.None;
        double setVoltage = 0.0;
        double setCurrent = 0.0;
        double outputVoltage = 0.0;
        double outputCurrent = 0.0;
        double outputPower = 0.0;
        double inputVoltage = 0.0;
        bool controlsLocked = false;
        int brightness = 0;
        int productModel = 0;
        int firmwareVersion = 0;
    }
}
