
namespace Riden
{
    partial class PowerSupplyDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelInstrument = new System.Windows.Forms.Panel();
            this.tableLayoutPanelAll = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelLeft = new System.Windows.Forms.TableLayoutPanel();
            this.labelOutputVoltage = new Riden.SizingLabel();
            this.labelOutputCurrent = new Riden.SizingLabel();
            this.labelOutputPower = new Riden.SizingLabel();
            this.tableLayoutPanelRight = new System.Windows.Forms.TableLayoutPanel();
            this.labelOP = new Riden.SizingLabel();
            this.labelCC = new Riden.SizingLabel();
            this.labelCV = new Riden.SizingLabel();
            this.labelSetV = new System.Windows.Forms.Label();
            this.labelSetA = new System.Windows.Forms.Label();
            this.labelSet = new System.Windows.Forms.Label();
            this.textBoxVoltage = new Riden.ValueTextBox();
            this.textBoxCurrent = new Riden.ValueTextBox();
            this.buttonPreset0 = new System.Windows.Forms.Button();
            this.buttonPreset1 = new System.Windows.Forms.Button();
            this.buttonPreset2 = new System.Windows.Forms.Button();
            this.buttonPreset3 = new System.Windows.Forms.Button();
            this.buttonPreset4 = new System.Windows.Forms.Button();
            this.buttonPreset5 = new System.Windows.Forms.Button();
            this.buttonPreset6 = new System.Windows.Forms.Button();
            this.buttonPreset7 = new System.Windows.Forms.Button();
            this.buttonPreset8 = new System.Windows.Forms.Button();
            this.buttonPreset9 = new System.Windows.Forms.Button();
            this.comboBoxPort = new System.Windows.Forms.ComboBox();
            this.comboBoxBaudrate = new System.Windows.Forms.ComboBox();
            this.labelPort = new System.Windows.Forms.Label();
            this.labelBaudrate = new System.Windows.Forms.Label();
            this.checkBoxLockControls = new System.Windows.Forms.CheckBox();
            this.labelDivider = new System.Windows.Forms.Label();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.buttonPower = new Riden.PowerButton();
            this.panelInstrument.SuspendLayout();
            this.tableLayoutPanelAll.SuspendLayout();
            this.tableLayoutPanelLeft.SuspendLayout();
            this.tableLayoutPanelRight.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelInstrument
            // 
            this.panelInstrument.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelInstrument.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panelInstrument.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelInstrument.Controls.Add(this.tableLayoutPanelAll);
            this.panelInstrument.Controls.Add(this.labelSetV);
            this.panelInstrument.Controls.Add(this.labelSetA);
            this.panelInstrument.Controls.Add(this.labelSet);
            this.panelInstrument.Controls.Add(this.textBoxVoltage);
            this.panelInstrument.Controls.Add(this.textBoxCurrent);
            this.panelInstrument.Location = new System.Drawing.Point(10, 10);
            this.panelInstrument.Margin = new System.Windows.Forms.Padding(2);
            this.panelInstrument.Name = "panelInstrument";
            this.panelInstrument.Size = new System.Drawing.Size(225, 163);
            this.panelInstrument.TabIndex = 0;
            // 
            // tableLayoutPanelAll
            // 
            this.tableLayoutPanelAll.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanelAll.ColumnCount = 2;
            this.tableLayoutPanelAll.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanelAll.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanelAll.Controls.Add(this.tableLayoutPanelLeft, 0, 0);
            this.tableLayoutPanelAll.Controls.Add(this.tableLayoutPanelRight, 1, 0);
            this.tableLayoutPanelAll.Location = new System.Drawing.Point(5, 5);
            this.tableLayoutPanelAll.Name = "tableLayoutPanelAll";
            this.tableLayoutPanelAll.RowCount = 1;
            this.tableLayoutPanelAll.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelAll.Size = new System.Drawing.Size(210, 115);
            this.tableLayoutPanelAll.TabIndex = 20;
            // 
            // tableLayoutPanelLeft
            // 
            this.tableLayoutPanelLeft.ColumnCount = 1;
            this.tableLayoutPanelLeft.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelLeft.Controls.Add(this.labelOutputVoltage, 0, 0);
            this.tableLayoutPanelLeft.Controls.Add(this.labelOutputCurrent, 0, 1);
            this.tableLayoutPanelLeft.Controls.Add(this.labelOutputPower, 0, 2);
            this.tableLayoutPanelLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelLeft.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelLeft.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelLeft.Name = "tableLayoutPanelLeft";
            this.tableLayoutPanelLeft.RowCount = 3;
            this.tableLayoutPanelLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 38F));
            this.tableLayoutPanelLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 38F));
            this.tableLayoutPanelLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 24F));
            this.tableLayoutPanelLeft.Size = new System.Drawing.Size(168, 115);
            this.tableLayoutPanelLeft.TabIndex = 19;
            // 
            // labelOutputVoltage
            // 
            this.labelOutputVoltage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelOutputVoltage.Font = new System.Drawing.Font("Consolas", 25F);
            this.labelOutputVoltage.Location = new System.Drawing.Point(0, 0);
            this.labelOutputVoltage.Margin = new System.Windows.Forms.Padding(0);
            this.labelOutputVoltage.Name = "labelOutputVoltage";
            this.labelOutputVoltage.Size = new System.Drawing.Size(168, 43);
            this.labelOutputVoltage.TabIndex = 0;
            this.labelOutputVoltage.Text = "00.000X";
            this.labelOutputVoltage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelOutputCurrent
            // 
            this.labelOutputCurrent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelOutputCurrent.Font = new System.Drawing.Font("Consolas", 25F);
            this.labelOutputCurrent.Location = new System.Drawing.Point(0, 43);
            this.labelOutputCurrent.Margin = new System.Windows.Forms.Padding(0);
            this.labelOutputCurrent.Name = "labelOutputCurrent";
            this.labelOutputCurrent.Size = new System.Drawing.Size(168, 43);
            this.labelOutputCurrent.TabIndex = 1;
            this.labelOutputCurrent.Text = "00.000X";
            this.labelOutputCurrent.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelOutputPower
            // 
            this.labelOutputPower.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelOutputPower.Font = new System.Drawing.Font("Consolas", 18F);
            this.labelOutputPower.Location = new System.Drawing.Point(0, 86);
            this.labelOutputPower.Margin = new System.Windows.Forms.Padding(0);
            this.labelOutputPower.Name = "labelOutputPower";
            this.labelOutputPower.Size = new System.Drawing.Size(168, 29);
            this.labelOutputPower.TabIndex = 2;
            this.labelOutputPower.Text = "0000000.0X";
            this.labelOutputPower.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tableLayoutPanelRight
            // 
            this.tableLayoutPanelRight.ColumnCount = 1;
            this.tableLayoutPanelRight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelRight.Controls.Add(this.labelOP, 0, 2);
            this.tableLayoutPanelRight.Controls.Add(this.labelCC, 0, 1);
            this.tableLayoutPanelRight.Controls.Add(this.labelCV, 0, 0);
            this.tableLayoutPanelRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelRight.Location = new System.Drawing.Point(168, 0);
            this.tableLayoutPanelRight.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelRight.Name = "tableLayoutPanelRight";
            this.tableLayoutPanelRight.RowCount = 4;
            this.tableLayoutPanelRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelRight.Size = new System.Drawing.Size(42, 115);
            this.tableLayoutPanelRight.TabIndex = 21;
            // 
            // labelOP
            // 
            this.labelOP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelOP.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOP.Location = new System.Drawing.Point(0, 56);
            this.labelOP.Margin = new System.Windows.Forms.Padding(0);
            this.labelOP.Name = "labelOP";
            this.labelOP.Size = new System.Drawing.Size(49, 28);
            this.labelOP.TabIndex = 5;
            this.labelOP.Text = "XXX";
            this.labelOP.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelCC
            // 
            this.labelCC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelCC.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCC.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelCC.Location = new System.Drawing.Point(0, 28);
            this.labelCC.Margin = new System.Windows.Forms.Padding(0);
            this.labelCC.Name = "labelCC";
            this.labelCC.Size = new System.Drawing.Size(49, 28);
            this.labelCC.TabIndex = 4;
            this.labelCC.Text = "XXX";
            this.labelCC.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelCV
            // 
            this.labelCV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelCV.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCV.Location = new System.Drawing.Point(0, 0);
            this.labelCV.Margin = new System.Windows.Forms.Padding(0);
            this.labelCV.Name = "labelCV";
            this.labelCV.Size = new System.Drawing.Size(49, 28);
            this.labelCV.TabIndex = 3;
            this.labelCV.Text = "XXX";
            this.labelCV.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelSetV
            // 
            this.labelSetV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelSetV.AutoSize = true;
            this.labelSetV.Location = new System.Drawing.Point(92, 128);
            this.labelSetV.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelSetV.Name = "labelSetV";
            this.labelSetV.Size = new System.Drawing.Size(14, 13);
            this.labelSetV.TabIndex = 8;
            this.labelSetV.Text = "V";
            // 
            // labelSetA
            // 
            this.labelSetA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelSetA.AutoSize = true;
            this.labelSetA.Location = new System.Drawing.Point(158, 128);
            this.labelSetA.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelSetA.Name = "labelSetA";
            this.labelSetA.Size = new System.Drawing.Size(14, 13);
            this.labelSetA.TabIndex = 10;
            this.labelSetA.Text = "A";
            // 
            // labelSet
            // 
            this.labelSet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelSet.AutoSize = true;
            this.labelSet.Location = new System.Drawing.Point(16, 127);
            this.labelSet.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelSet.Name = "labelSet";
            this.labelSet.Size = new System.Drawing.Size(26, 13);
            this.labelSet.TabIndex = 6;
            this.labelSet.Text = "&Set:";
            // 
            // textBoxVoltage
            // 
            this.textBoxVoltage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxVoltage.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxVoltage.Location = new System.Drawing.Point(46, 125);
            this.textBoxVoltage.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxVoltage.Name = "textBoxVoltage";
            this.textBoxVoltage.Size = new System.Drawing.Size(46, 20);
            this.textBoxVoltage.TabIndex = 7;
            this.textBoxVoltage.Text = "0.000";
            this.textBoxVoltage.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBoxVoltage.ValueChanged += new System.EventHandler(this.textBoxVoltage_ValueChanged);
            // 
            // textBoxCurrent
            // 
            this.textBoxCurrent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxCurrent.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxCurrent.Location = new System.Drawing.Point(112, 125);
            this.textBoxCurrent.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxCurrent.Name = "textBoxCurrent";
            this.textBoxCurrent.Size = new System.Drawing.Size(46, 20);
            this.textBoxCurrent.TabIndex = 9;
            this.textBoxCurrent.Text = "0.000";
            this.textBoxCurrent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBoxCurrent.ValueChanged += new System.EventHandler(this.textBoxCurrent_ValueChanged);
            // 
            // buttonPreset0
            // 
            this.buttonPreset0.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPreset0.Location = new System.Drawing.Point(242, 10);
            this.buttonPreset0.Name = "buttonPreset0";
            this.buttonPreset0.Size = new System.Drawing.Size(28, 28);
            this.buttonPreset0.TabIndex = 3;
            this.buttonPreset0.Text = "&0";
            this.buttonPreset0.UseVisualStyleBackColor = true;
            this.buttonPreset0.Click += new System.EventHandler(this.buttonPreset0_Click);
            // 
            // buttonPreset1
            // 
            this.buttonPreset1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPreset1.Location = new System.Drawing.Point(276, 10);
            this.buttonPreset1.Name = "buttonPreset1";
            this.buttonPreset1.Size = new System.Drawing.Size(28, 28);
            this.buttonPreset1.TabIndex = 4;
            this.buttonPreset1.Text = "&1";
            this.buttonPreset1.UseVisualStyleBackColor = true;
            this.buttonPreset1.Click += new System.EventHandler(this.buttonPreset1_Click);
            // 
            // buttonPreset2
            // 
            this.buttonPreset2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPreset2.Location = new System.Drawing.Point(242, 44);
            this.buttonPreset2.Name = "buttonPreset2";
            this.buttonPreset2.Size = new System.Drawing.Size(28, 28);
            this.buttonPreset2.TabIndex = 5;
            this.buttonPreset2.Text = "&2";
            this.buttonPreset2.UseVisualStyleBackColor = true;
            this.buttonPreset2.Click += new System.EventHandler(this.buttonPreset2_Click);
            // 
            // buttonPreset3
            // 
            this.buttonPreset3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPreset3.Location = new System.Drawing.Point(276, 44);
            this.buttonPreset3.Name = "buttonPreset3";
            this.buttonPreset3.Size = new System.Drawing.Size(28, 28);
            this.buttonPreset3.TabIndex = 6;
            this.buttonPreset3.Text = "&3";
            this.buttonPreset3.UseVisualStyleBackColor = true;
            this.buttonPreset3.Click += new System.EventHandler(this.buttonPreset3_Click);
            // 
            // buttonPreset4
            // 
            this.buttonPreset4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPreset4.Location = new System.Drawing.Point(242, 78);
            this.buttonPreset4.Name = "buttonPreset4";
            this.buttonPreset4.Size = new System.Drawing.Size(28, 28);
            this.buttonPreset4.TabIndex = 7;
            this.buttonPreset4.Text = "&4";
            this.buttonPreset4.UseVisualStyleBackColor = true;
            this.buttonPreset4.Click += new System.EventHandler(this.buttonPreset4_Click);
            // 
            // buttonPreset5
            // 
            this.buttonPreset5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPreset5.Location = new System.Drawing.Point(276, 78);
            this.buttonPreset5.Name = "buttonPreset5";
            this.buttonPreset5.Size = new System.Drawing.Size(28, 28);
            this.buttonPreset5.TabIndex = 8;
            this.buttonPreset5.Text = "&5";
            this.buttonPreset5.UseVisualStyleBackColor = true;
            this.buttonPreset5.Click += new System.EventHandler(this.buttonPreset5_Click);
            // 
            // buttonPreset6
            // 
            this.buttonPreset6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPreset6.Location = new System.Drawing.Point(242, 112);
            this.buttonPreset6.Name = "buttonPreset6";
            this.buttonPreset6.Size = new System.Drawing.Size(28, 28);
            this.buttonPreset6.TabIndex = 9;
            this.buttonPreset6.Text = "&6";
            this.buttonPreset6.UseVisualStyleBackColor = true;
            this.buttonPreset6.Click += new System.EventHandler(this.buttonPreset6_Click);
            // 
            // buttonPreset7
            // 
            this.buttonPreset7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPreset7.Location = new System.Drawing.Point(276, 112);
            this.buttonPreset7.Name = "buttonPreset7";
            this.buttonPreset7.Size = new System.Drawing.Size(28, 28);
            this.buttonPreset7.TabIndex = 10;
            this.buttonPreset7.Text = "&7";
            this.buttonPreset7.UseVisualStyleBackColor = true;
            this.buttonPreset7.Click += new System.EventHandler(this.buttonPreset7_Click);
            // 
            // buttonPreset8
            // 
            this.buttonPreset8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPreset8.Location = new System.Drawing.Point(242, 146);
            this.buttonPreset8.Name = "buttonPreset8";
            this.buttonPreset8.Size = new System.Drawing.Size(28, 28);
            this.buttonPreset8.TabIndex = 11;
            this.buttonPreset8.Text = "&8";
            this.buttonPreset8.UseVisualStyleBackColor = true;
            this.buttonPreset8.Click += new System.EventHandler(this.buttonPreset8_Click);
            // 
            // buttonPreset9
            // 
            this.buttonPreset9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPreset9.Location = new System.Drawing.Point(276, 146);
            this.buttonPreset9.Name = "buttonPreset9";
            this.buttonPreset9.Size = new System.Drawing.Size(28, 28);
            this.buttonPreset9.TabIndex = 12;
            this.buttonPreset9.Text = "&9";
            this.buttonPreset9.UseVisualStyleBackColor = true;
            this.buttonPreset9.Click += new System.EventHandler(this.buttonPreset9_Click);
            // 
            // comboBoxPort
            // 
            this.comboBoxPort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.comboBoxPort.FormattingEnabled = true;
            this.comboBoxPort.Location = new System.Drawing.Point(40, 218);
            this.comboBoxPort.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxPort.Name = "comboBoxPort";
            this.comboBoxPort.Size = new System.Drawing.Size(61, 21);
            this.comboBoxPort.TabIndex = 15;
            this.comboBoxPort.SelectedIndexChanged += new System.EventHandler(this.comboBoxPort_SelectedIndexChanged);
            // 
            // comboBoxBaudrate
            // 
            this.comboBoxBaudrate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.comboBoxBaudrate.FormattingEnabled = true;
            this.comboBoxBaudrate.Items.AddRange(new object[] {
            "2400",
            "4800",
            "9600",
            "19200"});
            this.comboBoxBaudrate.Location = new System.Drawing.Point(174, 218);
            this.comboBoxBaudrate.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxBaudrate.Name = "comboBoxBaudrate";
            this.comboBoxBaudrate.Size = new System.Drawing.Size(61, 21);
            this.comboBoxBaudrate.TabIndex = 17;
            this.comboBoxBaudrate.SelectedIndexChanged += new System.EventHandler(this.comboBoxBaudrate_SelectedIndexChanged);
            // 
            // labelPort
            // 
            this.labelPort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelPort.AutoSize = true;
            this.labelPort.Location = new System.Drawing.Point(7, 221);
            this.labelPort.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelPort.Name = "labelPort";
            this.labelPort.Size = new System.Drawing.Size(29, 13);
            this.labelPort.TabIndex = 14;
            this.labelPort.Text = "&Port:";
            // 
            // labelBaudrate
            // 
            this.labelBaudrate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelBaudrate.AutoSize = true;
            this.labelBaudrate.Location = new System.Drawing.Point(117, 221);
            this.labelBaudrate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelBaudrate.Name = "labelBaudrate";
            this.labelBaudrate.Size = new System.Drawing.Size(53, 13);
            this.labelBaudrate.TabIndex = 16;
            this.labelBaudrate.Text = "&Baudrate:";
            // 
            // checkBoxLockControls
            // 
            this.checkBoxLockControls.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBoxLockControls.AutoSize = true;
            this.checkBoxLockControls.Location = new System.Drawing.Point(144, 182);
            this.checkBoxLockControls.Name = "checkBoxLockControls";
            this.checkBoxLockControls.Size = new System.Drawing.Size(91, 17);
            this.checkBoxLockControls.TabIndex = 2;
            this.checkBoxLockControls.Text = "&Lock Controls";
            this.checkBoxLockControls.UseVisualStyleBackColor = true;
            this.checkBoxLockControls.CheckedChanged += new System.EventHandler(this.checkBoxLockControls_CheckedChanged);
            // 
            // labelDivider
            // 
            this.labelDivider.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelDivider.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelDivider.Location = new System.Drawing.Point(0, 207);
            this.labelDivider.Name = "labelDivider";
            this.labelDivider.Size = new System.Drawing.Size(315, 2);
            this.labelDivider.TabIndex = 13;
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 247);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(314, 22);
            this.statusStrip.TabIndex = 18;
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // buttonPower
            // 
            this.buttonPower.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonPower.Location = new System.Drawing.Point(10, 182);
            this.buttonPower.Margin = new System.Windows.Forms.Padding(2);
            this.buttonPower.Name = "buttonPower";
            this.buttonPower.Size = new System.Drawing.Size(62, 19);
            this.buttonPower.TabIndex = 1;
            this.buttonPower.Text = "&On/Off";
            this.buttonPower.UseVisualStyleBackColor = true;
            this.buttonPower.Click += new System.EventHandler(this.buttonPower_Click);
            // 
            // PowerSupplyDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 269);
            this.Controls.Add(this.panelInstrument);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.buttonPower);
            this.Controls.Add(this.checkBoxLockControls);
            this.Controls.Add(this.labelDivider);
            this.Controls.Add(this.labelPort);
            this.Controls.Add(this.comboBoxPort);
            this.Controls.Add(this.labelBaudrate);
            this.Controls.Add(this.comboBoxBaudrate);
            this.Controls.Add(this.buttonPreset0);
            this.Controls.Add(this.buttonPreset1);
            this.Controls.Add(this.buttonPreset2);
            this.Controls.Add(this.buttonPreset3);
            this.Controls.Add(this.buttonPreset4);
            this.Controls.Add(this.buttonPreset5);
            this.Controls.Add(this.buttonPreset6);
            this.Controls.Add(this.buttonPreset7);
            this.Controls.Add(this.buttonPreset8);
            this.Controls.Add(this.buttonPreset9);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(330, 308);
            this.Name = "PowerSupplyDialog";
            this.Text = "Riden DPS";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PowerSupplyDialog_FormClosed);
            this.Load += new System.EventHandler(this.PowerSupplyDialog_Load);
            this.panelInstrument.ResumeLayout(false);
            this.panelInstrument.PerformLayout();
            this.tableLayoutPanelAll.ResumeLayout(false);
            this.tableLayoutPanelLeft.ResumeLayout(false);
            this.tableLayoutPanelRight.ResumeLayout(false);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelInstrument;
        private SizingLabel labelOutputVoltage;
        private SizingLabel labelOutputCurrent;
        private SizingLabel labelOutputPower;
        private SizingLabel labelCC;
        private SizingLabel labelCV;
        private SizingLabel labelOP;
        private System.Windows.Forms.Label labelSet;
        private System.Windows.Forms.Label labelSetV;
        private System.Windows.Forms.Label labelSetA;
        private ValueTextBox textBoxVoltage;
        private ValueTextBox textBoxCurrent;
        private PowerButton buttonPower;
        private System.Windows.Forms.Button buttonPreset0;
        private System.Windows.Forms.Button buttonPreset1;
        private System.Windows.Forms.Button buttonPreset2;
        private System.Windows.Forms.Button buttonPreset3;
        private System.Windows.Forms.Button buttonPreset4;
        private System.Windows.Forms.Button buttonPreset5;
        private System.Windows.Forms.Button buttonPreset6;
        private System.Windows.Forms.Button buttonPreset7;
        private System.Windows.Forms.Button buttonPreset8;
        private System.Windows.Forms.Button buttonPreset9;
        private System.Windows.Forms.ComboBox comboBoxPort;
        private System.Windows.Forms.ComboBox comboBoxBaudrate;
        private System.Windows.Forms.Label labelPort;
        private System.Windows.Forms.Label labelBaudrate;
        private System.Windows.Forms.CheckBox checkBoxLockControls;
        private System.Windows.Forms.Label labelDivider;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelAll;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelLeft;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelRight;
    }
}