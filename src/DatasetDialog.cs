using System;
using System.Windows.Forms;

namespace Riden
{
    public partial class DatasetDialog : Form
    {
        public DatasetDialog(PowerSupply powerSupply, int index)
        {
            this.powerSupply = powerSupply;
            this.index = index;
            InitializeComponent();
        }

        private void DatasetDialog_Load(object sender, EventArgs e)
        {
            Text = $"Dataset {index}";
            LoadDataset();
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            LoadDataset();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            SaveDataset();
        }

        private void buttonApply_Click(object sender, EventArgs e)
        {
            SaveDataset();
            SelectDataset();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        void SelectDataset()
        {
            powerSupply.CommandQueue.QueueCommand(delegate
            {
                powerSupply.MemoryPreset = index;
            });
        }

        void LoadDataset()
        {
            powerSupply.CommandQueue.QueueCommand(delegate
            {
                dataset = powerSupply.LoadDataset(index);
            }, delegate
            {
                UpdateControlsFromDataset();
            });
        }

        void SaveDataset()
        {
            UpdateDatasetFromControls();

            powerSupply.CommandQueue.QueueCommand(delegate
            {
                powerSupply.SaveDataset(index, dataset);
            });
        }

        void UpdateControlsFromDataset()
        {
            textBoxVoltage.Text = Tools.FormatValue(dataset.Voltage, "F2");
            textBoxCurrent.Text = Tools.FormatValue(dataset.Current, "F3");
            textBoxVoltageLimit.Text = Tools.FormatValue(dataset.VoltageLimit, "F2");
            textBoxCurrentLimit.Text = Tools.FormatValue(dataset.CurrentLimit, "F3");
            textBoxPowerLimit.Text = Tools.FormatValue(dataset.PowerLimit, "F1");
            textBoxBrightness.Text = dataset.Brightness.ToString();
            checkBoxKeepOutputEnabled.Checked = dataset.KeepOutputEnabled;
            checkBoxOutputEnabledAtPowerOn.Checked = dataset.EnableOutputAtPowerOn;
        }

        void UpdateDatasetFromControls()
        {
            if (Tools.TryParseValue(textBoxVoltage.Text, out double voltage))
            {
                dataset.Voltage = voltage;
            }

            if (Tools.TryParseValue(textBoxCurrent.Text, out double current))
            {
                dataset.Current = current;
            }

            if (Tools.TryParseValue(textBoxVoltageLimit.Text, out double voltageLimit))
            {
                dataset.VoltageLimit = voltageLimit;
            }

            if (Tools.TryParseValue(textBoxCurrentLimit.Text, out double currentLimit))
            {
                dataset.CurrentLimit = currentLimit;
            }

            if (Tools.TryParseValue(textBoxPowerLimit.Text, out double powerLimit))
            {
                dataset.PowerLimit = powerLimit;
            }

            if (int.TryParse(textBoxBrightness.Text, out int brightness))
            {
                dataset.Brightness = brightness;
            }

            dataset.KeepOutputEnabled = checkBoxKeepOutputEnabled.Checked;
            dataset.EnableOutputAtPowerOn = checkBoxOutputEnabledAtPowerOn.Checked;
        }

        readonly PowerSupply powerSupply;
        readonly int index;
        PowerSupply.Dataset dataset = new PowerSupply.Dataset();
    }
}
