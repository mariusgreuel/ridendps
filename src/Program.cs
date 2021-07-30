using Riden;
using System;
using System.Globalization;
using System.Windows.Forms;

namespace DPS
{
    class Program
    {
        static int Main(string[] arguments)
        {
            return new Program().Run(arguments);
        }

        int Run(string[] arguments)
        {
            try
            {
                PrintLogo();

                options.ParseArguments(arguments);
                if (!options.Validate())
                {
                    PrintUsage();
                    return 2;
                }

                using (var powerSupply = new PowerSupply())
                {
                    if (options.verbose)
                    {
                        powerSupply.ModbusClient.Logger = new Logger();
                    }

                    if (options.gui)
                    {
                        Application.EnableVisualStyles();
                        Application.SetCompatibleTextRenderingDefault(false);
                        Application.Run(new PowerSupplyDialog(powerSupply));
                    }
                    else
                    {
                        powerSupply.Open(options.port, options.baudrate);
                        powerSupply.Address = options.address;

                        if (options.id)
                        {
                            powerSupply.ReadProductData();
                            Console.WriteLine($"ProductModel: {powerSupply.ProductModel}");
                            Console.WriteLine($"FirmwareVersion: {powerSupply.FirmwareVersion}");
                        }
                        else if (options.dump != null)
                        {
                            var address = ushort.Parse(options.dump, NumberStyles.HexNumber);
                            var regs = powerSupply.ModbusClient.ReadHoldingRegisters(address, 16);
                            for (int i = 0; i < regs.Length; i++)
                            {
                                Console.WriteLine($"Reg[{address + i}]: {regs[i]:X04}");
                            }
                        }
                        else
                        {
                            if (options.voltage != null ||
                                options.current != null ||
                                options.vlimit != null ||
                                options.climit != null ||
                                options.plimit != null ||
                                options.brightness != null ||
                                options.print)
                            {
                                var dataset = powerSupply.LoadDataset(options.dataset);

                                if (Tools.TryParseValue(options.voltage, out double voltage))
                                {
                                    dataset.Voltage = voltage;
                                }

                                if (Tools.TryParseValue(options.current, out double current))
                                {
                                    dataset.Current = current;
                                }

                                if (Tools.TryParseValue(options.vlimit, out double voltageLimit))
                                {
                                    dataset.VoltageLimit = voltageLimit;
                                }

                                if (Tools.TryParseValue(options.climit, out double currentLimit))
                                {
                                    dataset.CurrentLimit = currentLimit;
                                }

                                if (Tools.TryParseValue(options.plimit, out double powerLimit))
                                {
                                    dataset.PowerLimit = powerLimit;
                                }

                                if (Tools.TryParseValue(options.brightness, out int brightness))
                                {
                                    dataset.Brightness = brightness;
                                }

                                if (options.print)
                                {
                                    Console.WriteLine($"Voltage: {dataset.Voltage:0.00}V");
                                    Console.WriteLine($"Current: {dataset.Current:0.00}A");
                                    Console.WriteLine($"OVP: {dataset.VoltageLimit:0.00}V");
                                    Console.WriteLine($"OCP: {dataset.CurrentLimit:0.000}A");
                                    Console.WriteLine($"OPP: {dataset.PowerLimit:0.0}W");
                                    Console.WriteLine($"Brightness: {dataset.Brightness}");
                                    Console.WriteLine($"Memory: {dataset.MemoryPreset}");
                                    Console.WriteLine($"Enabled: {dataset.KeepOutputEnabled}");
                                }

                                powerSupply.SaveDataset(options.dataset, dataset);
                            }

                            if (options.select)
                            {
                                powerSupply.MemoryPreset = options.dataset;
                            }

                            if (options.off)
                            {
                                powerSupply.OutputEnabled = false;
                            }
                            else if (options.on)
                            {
                                powerSupply.OutputEnabled = true;
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                using (new ColoredConsole(ConsoleColor.Red))
                {
                    Console.Error.WriteLine($"ERROR: {e.Message}");
                }

                return 1;
            }

            return 0;
        }

        void PrintLogo()
        {
            Console.WriteLine("Riden DPS Tool, V1.0");
            Console.WriteLine("Copyright (C) 2020 Marius Greuel.");
        }

        void PrintUsage()
        {
            Console.WriteLine("Usage: dps [options] <files>");
            options.WriteUsage();
            Console.WriteLine();
            Console.WriteLine("Examples:");
            Console.WriteLine("    Print device ID: dps -port COM3 -id");
            Console.WriteLine("    Set voltage and current: dps -port COM3 -voltage 5.0 -current 0.1");
        }

        readonly Options options = new Options();
    }
}
