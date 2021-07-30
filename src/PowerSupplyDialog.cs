using Riden.Properties;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Riden
{
    public partial class PowerSupplyDialog : Form
    {
        public PowerSupplyDialog(PowerSupply powerSupply)
        {
            this.powerSupply = powerSupply;
            InitializeComponent();
        }

        private void PowerSupplyDialog_Load(object sender, EventArgs e)
        {
            MinimumSize = Size;

            disableChangeEvents = true;
            PopulateControls();
            LoadSettings();
            disableChangeEvents = false;

            Connect();

            timer.Interval = 2000;
            timer.Tick += new EventHandler(OnTimer);
            timer.Start();
        }

        private void PowerSupplyDialog_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (powerSupply.IsConnected)
            {
                powerSupply.CommandQueue.QueueCommand(delegate { powerSupply.ControlsLocked = false; });
            }

            SaveSettings();
        }

        private void comboBoxPort_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!disableChangeEvents)
            {
                Connect();
            }
        }

        private void comboBoxBaudrate_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!disableChangeEvents)
            {
                Connect();
            }
        }

        private void buttonPower_Click(object sender, EventArgs e)
        {
            powerSupply.CommandQueue.QueueCommand(delegate { powerSupply.OutputEnabled = !powerSupply.OutputEnabled; });
        }

        private void checkBoxLockControls_CheckedChanged(object sender, EventArgs e)
        {
            powerSupply.CommandQueue.QueueCommand(delegate { powerSupply.ControlsLocked = !powerSupply.ControlsLocked; });
        }

        private void textBoxVoltage_ValueChanged(object sender, EventArgs e)
        {
            if (Tools.TryParseValue(textBoxVoltage.Text, out double value))
            {
                powerSupply.CommandQueue.QueueCommand(delegate
                {
                    powerSupply.SetVoltage = value;
                }, delegate
                {
                    textBoxVoltage.Text = Tools.FormatValue(powerSupply.SetVoltage, "F2");
                });
            }
        }

        private void textBoxCurrent_ValueChanged(object sender, EventArgs e)
        {
            if (Tools.TryParseValue(textBoxCurrent.Text, out double value))
            {
                powerSupply.CommandQueue.QueueCommand(delegate
                {
                    powerSupply.SetCurrent = value;
                }, delegate
                {
                    textBoxCurrent.Text = Tools.FormatValue(powerSupply.SetCurrent, "F3");
                });
            }
        }

        private void buttonPreset0_Click(object sender, EventArgs e)
        {
            EditDataset(0);
        }

        private void buttonPreset1_Click(object sender, EventArgs e)
        {
            EditDataset(1);
        }

        private void buttonPreset2_Click(object sender, EventArgs e)
        {
            EditDataset(2);
        }

        private void buttonPreset3_Click(object sender, EventArgs e)
        {
            EditDataset(3);
        }

        private void buttonPreset4_Click(object sender, EventArgs e)
        {
            EditDataset(4);
        }

        private void buttonPreset5_Click(object sender, EventArgs e)
        {
            EditDataset(5);
        }

        private void buttonPreset6_Click(object sender, EventArgs e)
        {
            EditDataset(6);
        }

        private void buttonPreset7_Click(object sender, EventArgs e)
        {
            EditDataset(7);
        }

        private void buttonPreset8_Click(object sender, EventArgs e)
        {
            EditDataset(8);
        }

        private void buttonPreset9_Click(object sender, EventArgs e)
        {
            EditDataset(9);
        }

        void EditDataset(int index)
        {
            new DatasetDialog(powerSupply, index).Show(this);
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            const int WM_DEVICECHANGE = 0x0219;
            if (m.Msg == WM_DEVICECHANGE)
            {
                PopulateControls();
                if (!powerSupply.IsConnected)
                {
                    LoadSettings();
                    Connect();
                }
            }
        }

        void OnTimer(object source, EventArgs e)
        {
            powerSupply.CommandQueue.QueueCommand(delegate
            {
                powerSupply.ReadOutputData();
            }, delegate
            {
                UpdateOutputData();
            });
        }

        void PopulateControls()
        {
            comboBoxPort.Items.Clear();
            comboBoxPort.Items.AddRange(PowerSupply.EnumeratePorts());
        }

        void LoadSettings()
        {
            var position = Settings.Default.DialogPosition;
            var size = Settings.Default.DialogSize;
            if (!size.IsEmpty)
            {
                DesktopBounds = new Rectangle(position, size);
            }

            var port = Settings.Default.Port;
            var baudrate = Settings.Default.Baudrate;

            if (comboBoxPort.Items.Count > 0)
            {
                if (port != null && comboBoxPort.Items.Contains(port))
                {
                    comboBoxPort.Text = port;
                }
                else
                {
                    comboBoxPort.SelectedIndex = 0;
                }
            }

            if (baudrate != null && comboBoxBaudrate.Items.Contains(baudrate))
            {
                comboBoxBaudrate.Text = baudrate;
            }
            else
            {
                comboBoxBaudrate.Text = "9600";
            }

            checkBoxLockControls.Checked = Settings.Default.ControlsLocked;
        }

        void SaveSettings()
        {
            Settings.Default.DialogPosition = DesktopBounds.Location;
            Settings.Default.DialogSize = DesktopBounds.Size;

            if (comboBoxPort.Text != null)
            {
                Settings.Default.Port = comboBoxPort.Text;
            }

            if (comboBoxBaudrate.Text != null)
            {
                Settings.Default.Baudrate = comboBoxBaudrate.Text;
            }

            Settings.Default.ControlsLocked = checkBoxLockControls.Checked;

            Settings.Default.Save();
        }

        void Connect()
        {
            powerSupply.Close();
            powerSupply.Clear();
            UpdateOutputData(true);

            var port = comboBoxPort.Text;
            var baudrate = int.TryParse(comboBoxBaudrate.Text, out int value) ? value : 9600;

            powerSupply.CommandQueue.QueueCommand(delegate
            {
                powerSupply.Open(port, baudrate);
                powerSupply.ReadAll();
                powerSupply.ControlsLocked = checkBoxLockControls.Checked;
            }, delegate
            {
                UpdateModel();
                UpdateOutputData(true);
            });
        }

        void UpdateModel()
        {
            if (powerSupply.ProductModel != 0)
            {
                Text = $"Riden DPS{powerSupply.ProductModel}";
            }
            else
            {
                Text = "Riden DPS";
            }
        }

        void UpdateOutputData(bool forceUpdate = false)
        {
            if (forceUpdate || updateSetData || !textBoxVoltage.Focused)
            {
                textBoxVoltage.Text = powerSupply.SetVoltage.ToString("F2");
            }

            if (forceUpdate || updateSetData || !textBoxCurrent.Focused)
            {
                textBoxCurrent.Text = powerSupply.SetCurrent.ToString("F3");
            }

            updateSetData = false;

            labelOutputVoltage.Text = Tools.FormatValue(powerSupply.OutputVoltage, "F3") + "V";
            labelOutputCurrent.Text = Tools.FormatValue(powerSupply.OutputCurrent, "F3") + "A";
            labelOutputPower.Text = Tools.FormatValue(powerSupply.OutputPower, "F2") + "W";
            buttonPower.Checked = powerSupply.OutputEnabled;

            switch (powerSupply.OutoutStatus)
            {
                case PowerSupply.Status.Off:
                    labelCV.Text = "";
                    labelCC.Text = "";
                    labelOP.Text = "";
                    break;
                case PowerSupply.Status.CV:
                    labelCV.Text = "CV";
                    labelCC.Text = "";
                    labelOP.Text = "";
                    break;
                case PowerSupply.Status.CC:
                    labelCV.Text = "";
                    labelCC.Text = "CC";
                    labelOP.Text = "";
                    break;
                case PowerSupply.Status.OVP:
                    labelCV.Text = "";
                    labelCC.Text = "";
                    labelOP.Text = "OVP";
                    break;
                case PowerSupply.Status.OCP:
                    labelCV.Text = "";
                    labelCC.Text = "";
                    labelOP.Text = "OCP";
                    break;
                case PowerSupply.Status.OPP:
                    labelCV.Text = "";
                    labelCC.Text = "";
                    labelOP.Text = "OPP";
                    break;
                default:
                    throw new ApplicationException();
            }

            UpdateStatus();
        }

        void UpdateStatus()
        {
            if (powerSupply.ProductModel != 0)
            {
                string device = $"DPS{powerSupply.ProductModel}";
                string firmware = $"V{powerSupply.FirmwareVersion / 10}.{powerSupply.FirmwareVersion % 10}";
                string inputVoltage = $"Input: {Tools.FormatValue(powerSupply.InputVoltage, "F2")}V";
                toolStripStatusLabel.Text = $"{device} {firmware}, {inputVoltage}";
            }
            else
            {
                toolStripStatusLabel.Text = "Not connected";
            }
        }

        readonly PowerSupply powerSupply;
        readonly Timer timer = new Timer();
        bool disableChangeEvents = false;
        bool updateSetData = false;
    }
}
