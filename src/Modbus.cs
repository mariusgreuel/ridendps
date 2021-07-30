using System;
using System.Collections.Generic;
using System.IO.Ports;

namespace Riden
{
    public interface IModbusLogger
    {
        void WriteLine(string text);
    }

    public class ModbusException : ApplicationException
    {
        public ModbusException()
        {
        }

        public ModbusException(string message) : base(message)
        {
        }

        public ModbusException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

    public class ModbusClient : IDisposable
    {
        public static ModbusClient Open(string port)
        {
            var client = new ModbusClient();
            client.Open(port);
            return client;
        }

        public IModbusLogger Logger { get; set; }
        public bool IsOpen => serialPort.IsOpen;
        public int SlaveAddress { get; set; } = 1;
        public double ResponseTimeout { get; set; } = 1.0;

        public void Open(string port, int baudRate = 9600, StopBits stopBits = StopBits.One, Parity parity = Parity.None)
        {
            Close();

            WriteLogger($"Opening COM port {port} @ {baudRate}...");
            serialPort.PortName = port;
            serialPort.BaudRate = baudRate;
            serialPort.DataBits = 8;
            serialPort.StopBits = stopBits;
            serialPort.Parity = parity;
            serialPort.ReadTimeout = (int)(ResponseTimeout * 1000.0);
            serialPort.Open();
        }

        public void Close()
        {
            if (serialPort.IsOpen)
            {
                serialPort.Close();
            }
        }

        public void Flush()
        {
        }

        public ushort[] ReadHoldingRegisters(ushort address, ushort count)
        {
            var data = new byte[2 + 2];
            SetWord(data, 0, address);
            SetWord(data, 2, count);
            SendMessage(0x03, data);

            var response = ReadResponse(2 + 2 * count);
            if (response[0] != 0x03)
                throw new ModbusException($"Unexpected Modbus function code response '0x{response[0]:X02}'.");

            if (response[1] != 2 * count)
                throw new ModbusException($"Unexpected Modbus response byte count '0x{response[1]:X02}'.");

            var registers = new ushort[response[1] / 2];
            for (int i = 0; i < registers.Length; i++)
            {
                registers[i] = GetWord(response, 2 + i * 2);
            }

            return registers;
        }

        public void WriteSingleRegister(ushort address, ushort value)
        {
            var data = new byte[4];
            SetWord(data, 0, address);
            SetWord(data, 2, value);
            SendMessage(0x06, data);

            var response = ReadResponse(5);
            if (response[0] != 0x06)
                throw new ModbusException($"Unexpected Modbus function code response '0x{response[0]:X02}'.");

            if (GetWord(response, 1) != address)
                throw new ModbusException($"Unexpected Modbus response address '0x{GetWord(response, 1):X02}'.");

            if (GetWord(response, 3) != value)
                throw new ModbusException($"Unexpected Modbus response value '0x{GetWord(response, 3):X02}'.");
        }

        public void WriteMultipleRegisters(ushort address, ushort[] values)
        {
            var data = new byte[5 + 2 * values.Length];
            SetWord(data, 0, address);
            SetWord(data, 2, (ushort)values.Length);
            data[4] = (byte)(values.Length * 2);

            for (int i = 0; i < values.Length; i++)
            {
                data[5 + i * 2] = (byte)(values[i] >> 8);
                data[6 + i * 2] = (byte)(values[i] >> 0);
            }

            SendMessage(0x10, data);

            var response = ReadResponse(5);
            if (response[0] != 0x10)
                throw new ModbusException($"Unexpected Modbus function code response '0x{response[0]:X02}'.");

            if (GetWord(response, 1) != address)
                throw new ModbusException($"Unexpected Modbus response address '0x{GetWord(response, 1):X02}'.");

            if (GetWord(response, 3) != values.Length)
                throw new ModbusException($"Unexpected Modbus response length '0x{GetWord(response, 3):X02}'.");
        }

        public void SendMessage(byte functionCode, byte[] data)
        {
            if (data.Length > 252)
                throw new ModbusException($"Modbus frame data length must not exceed 252 bytes.");

            var buffer = new byte[2 + data.Length + 2];
            buffer[0] = (byte)SlaveAddress;
            buffer[1] = functionCode;
            data.CopyTo(buffer, 2);

            ushort crc = CalculateCrc(buffer, buffer.Length - 2);
            buffer[buffer.Length - 2] = (byte)(crc >> 0);
            buffer[buffer.Length - 1] = (byte)(crc >> 8);

            WriteLogger($">{Dump(buffer)}");
            WriteData(buffer);
        }

        byte[] ReadResponse(int bytes)
        {
            byte[] buffer = ReadData(bytes + 3);
            WriteLogger($"<{Dump(buffer)}");

            if (buffer.Length < 3)
                throw new ModbusException($"Invalid Modbus response.");

            if (buffer[0] != (byte)SlaveAddress)
                throw new ModbusException($"Invalid Modbus response.");

            ushort crc = CalculateCrc(buffer, buffer.Length - 2);
            if (buffer[buffer.Length - 2] != (byte)(crc >> 0) ||
                buffer[buffer.Length - 1] != (byte)(crc >> 8))
                throw new ModbusException($"Modbus CRC error detected.");

            var response = new byte[buffer.Length - 3];
            Array.Copy(buffer, 1, response, 0, buffer.Length - 3);
            return response;
        }

        byte[] ReadData(int bytes)
        {
            var buffer = new List<byte>(bytes);

            try
            {
                for (int i = 0; i < bytes; i++)
                {
                    var ch = serialPort.ReadByte();
                    if (ch < 0)
                        break;

                    buffer.Add((byte)ch);
                }
            }
            catch (TimeoutException)
            {
            }

            return buffer.ToArray();
        }

        void WriteData(byte[] buffer)
        {
            serialPort.Write(buffer, 0, buffer.Length);
        }

        void WriteLogger(string text)
        {
            Logger?.WriteLine(text);
        }

        string Dump(byte[] buffer)
        {
            string result = "";

            for (int i = 0; i< buffer.Length; i++)
            {
                result += $" {buffer[i]:X02}";
            }

            return result;
        }

        void IDisposable.Dispose()
        {
            Close();
        }

        static ushort GetWord(byte[] buffer, int offset)
        {
            return (ushort)((buffer[offset] << 8) | buffer[offset + 1]);
        }

        static void SetWord(byte[] buffer, int offset, ushort value)
        {
            buffer[offset + 0] = (byte)(value >> 8);
            buffer[offset + 1] = (byte)(value >> 0);
        }

        static ushort CalculateCrc(byte[] buffer, int length)
        {
            ushort crc = 0xFFFF;

            for (int i = 0; i < length; i++)
            {
                crc = CalculateCrc(crc, buffer[i]);
            }

            return crc;
        }

        static ushort CalculateCrc(ushort crc, byte value)
        {
            crc = (ushort)(crc ^ value);

            for (int i = 0; i < 8; i++)
            {
                if ((crc & 1) != 0)
                {
                    crc = (ushort)((crc >> 1) ^ 0xA001);
                }
                else
                {
                    crc = (ushort)(crc >> 1);
                }
            }

            return crc;
        }

        readonly SerialPort serialPort = new SerialPort();
    }
}
