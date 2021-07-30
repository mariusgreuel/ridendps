
namespace Riden
{
    partial class DatasetDialog
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
            this.labelVoltage = new System.Windows.Forms.Label();
            this.textBoxVoltage = new System.Windows.Forms.TextBox();
            this.labelCurrent = new System.Windows.Forms.Label();
            this.textBoxCurrent = new System.Windows.Forms.TextBox();
            this.labelVoltageLimit = new System.Windows.Forms.Label();
            this.textBoxVoltageLimit = new System.Windows.Forms.TextBox();
            this.labelCurrentLimit = new System.Windows.Forms.Label();
            this.textBoxCurrentLimit = new System.Windows.Forms.TextBox();
            this.labelPowerLimit = new System.Windows.Forms.Label();
            this.textBoxPowerLimit = new System.Windows.Forms.TextBox();
            this.labelBrightness = new System.Windows.Forms.Label();
            this.textBoxBrightness = new System.Windows.Forms.TextBox();
            this.checkBoxKeepOutputEnabled = new System.Windows.Forms.CheckBox();
            this.checkBoxOutputEnabledAtPowerOn = new System.Windows.Forms.CheckBox();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonApply = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelVoltage
            // 
            this.labelVoltage.AutoSize = true;
            this.labelVoltage.Location = new System.Drawing.Point(39, 14);
            this.labelVoltage.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelVoltage.Name = "labelVoltage";
            this.labelVoltage.Size = new System.Drawing.Size(62, 13);
            this.labelVoltage.TabIndex = 0;
            this.labelVoltage.Text = "&Voltage [V]:";
            // 
            // textBoxVoltage
            // 
            this.textBoxVoltage.Location = new System.Drawing.Point(105, 11);
            this.textBoxVoltage.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxVoltage.Name = "textBoxVoltage";
            this.textBoxVoltage.Size = new System.Drawing.Size(60, 20);
            this.textBoxVoltage.TabIndex = 1;
            // 
            // labelCurrent
            // 
            this.labelCurrent.AutoSize = true;
            this.labelCurrent.Location = new System.Drawing.Point(41, 38);
            this.labelCurrent.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelCurrent.Name = "labelCurrent";
            this.labelCurrent.Size = new System.Drawing.Size(60, 13);
            this.labelCurrent.TabIndex = 2;
            this.labelCurrent.Text = "&Current [A]:";
            // 
            // textBoxCurrent
            // 
            this.textBoxCurrent.Location = new System.Drawing.Point(105, 35);
            this.textBoxCurrent.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxCurrent.Name = "textBoxCurrent";
            this.textBoxCurrent.Size = new System.Drawing.Size(60, 20);
            this.textBoxCurrent.TabIndex = 3;
            // 
            // labelVoltageLimit
            // 
            this.labelVoltageLimit.AutoSize = true;
            this.labelVoltageLimit.Location = new System.Drawing.Point(15, 62);
            this.labelVoltageLimit.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelVoltageLimit.Name = "labelVoltageLimit";
            this.labelVoltageLimit.Size = new System.Drawing.Size(86, 13);
            this.labelVoltageLimit.TabIndex = 4;
            this.labelVoltageLimit.Text = "Voltage Limit [V]:";
            // 
            // textBoxVoltageLimit
            // 
            this.textBoxVoltageLimit.Location = new System.Drawing.Point(105, 59);
            this.textBoxVoltageLimit.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxVoltageLimit.Name = "textBoxVoltageLimit";
            this.textBoxVoltageLimit.Size = new System.Drawing.Size(60, 20);
            this.textBoxVoltageLimit.TabIndex = 5;
            // 
            // labelCurrentLimit
            // 
            this.labelCurrentLimit.AutoSize = true;
            this.labelCurrentLimit.Location = new System.Drawing.Point(17, 86);
            this.labelCurrentLimit.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelCurrentLimit.Name = "labelCurrentLimit";
            this.labelCurrentLimit.Size = new System.Drawing.Size(84, 13);
            this.labelCurrentLimit.TabIndex = 6;
            this.labelCurrentLimit.Text = "Current Limit [A]:";
            // 
            // textBoxCurrentLimit
            // 
            this.textBoxCurrentLimit.Location = new System.Drawing.Point(105, 83);
            this.textBoxCurrentLimit.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxCurrentLimit.Name = "textBoxCurrentLimit";
            this.textBoxCurrentLimit.Size = new System.Drawing.Size(60, 20);
            this.textBoxCurrentLimit.TabIndex = 7;
            // 
            // labelPowerLimit
            // 
            this.labelPowerLimit.AutoSize = true;
            this.labelPowerLimit.Location = new System.Drawing.Point(17, 110);
            this.labelPowerLimit.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelPowerLimit.Name = "labelPowerLimit";
            this.labelPowerLimit.Size = new System.Drawing.Size(84, 13);
            this.labelPowerLimit.TabIndex = 8;
            this.labelPowerLimit.Text = "Power Limit [W]:";
            // 
            // textBoxPowerLimit
            // 
            this.textBoxPowerLimit.Location = new System.Drawing.Point(105, 107);
            this.textBoxPowerLimit.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxPowerLimit.Name = "textBoxPowerLimit";
            this.textBoxPowerLimit.Size = new System.Drawing.Size(60, 20);
            this.textBoxPowerLimit.TabIndex = 9;
            // 
            // labelBrightness
            // 
            this.labelBrightness.AutoSize = true;
            this.labelBrightness.Location = new System.Drawing.Point(42, 134);
            this.labelBrightness.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelBrightness.Name = "labelBrightness";
            this.labelBrightness.Size = new System.Drawing.Size(59, 13);
            this.labelBrightness.TabIndex = 10;
            this.labelBrightness.Text = "&Brightness:";
            // 
            // textBoxBrightness
            // 
            this.textBoxBrightness.Location = new System.Drawing.Point(105, 131);
            this.textBoxBrightness.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxBrightness.Name = "textBoxBrightness";
            this.textBoxBrightness.Size = new System.Drawing.Size(60, 20);
            this.textBoxBrightness.TabIndex = 11;
            // 
            // checkBoxDisableOutput
            // 
            this.checkBoxKeepOutputEnabled.AutoSize = true;
            this.checkBoxKeepOutputEnabled.Location = new System.Drawing.Point(11, 155);
            this.checkBoxKeepOutputEnabled.Margin = new System.Windows.Forms.Padding(2);
            this.checkBoxKeepOutputEnabled.Name = "checkBoxKeepOutputEnabled";
            this.checkBoxKeepOutputEnabled.Size = new System.Drawing.Size(94, 17);
            this.checkBoxKeepOutputEnabled.TabIndex = 12;
            this.checkBoxKeepOutputEnabled.Text = "&Keep output enabled";
            this.checkBoxKeepOutputEnabled.UseVisualStyleBackColor = true;
            // 
            // checkBoxOutputEnabledAtPowerOn
            // 
            this.checkBoxOutputEnabledAtPowerOn.AutoSize = true;
            this.checkBoxOutputEnabledAtPowerOn.Location = new System.Drawing.Point(11, 176);
            this.checkBoxOutputEnabledAtPowerOn.Margin = new System.Windows.Forms.Padding(2);
            this.checkBoxOutputEnabledAtPowerOn.Name = "checkBoxOutputEnabledAtPowerOn";
            this.checkBoxOutputEnabledAtPowerOn.Size = new System.Drawing.Size(154, 17);
            this.checkBoxOutputEnabledAtPowerOn.TabIndex = 13;
            this.checkBoxOutputEnabledAtPowerOn.Text = "Enable output at &Power-On";
            this.checkBoxOutputEnabledAtPowerOn.UseVisualStyleBackColor = true;
            // 
            // buttonLoad
            // 
            this.buttonLoad.Location = new System.Drawing.Point(11, 197);
            this.buttonLoad.Margin = new System.Windows.Forms.Padding(2);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(75, 23);
            this.buttonLoad.TabIndex = 15;
            this.buttonLoad.Text = "&Load";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(90, 197);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 16;
            this.buttonSave.Text = "&Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonApply
            // 
            this.buttonApply.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonApply.Location = new System.Drawing.Point(11, 224);
            this.buttonApply.Margin = new System.Windows.Forms.Padding(2);
            this.buttonApply.Name = "buttonApply";
            this.buttonApply.Size = new System.Drawing.Size(75, 23);
            this.buttonApply.TabIndex = 17;
            this.buttonApply.Text = "&Apply";
            this.buttonApply.UseVisualStyleBackColor = true;
            this.buttonApply.Click += new System.EventHandler(this.buttonApply_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonClose.Location = new System.Drawing.Point(90, 224);
            this.buttonClose.Margin = new System.Windows.Forms.Padding(2);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 18;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // DatasetDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonClose;
            this.ClientSize = new System.Drawing.Size(176, 256);
            this.Controls.Add(this.buttonApply);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonLoad);
            this.Controls.Add(this.checkBoxOutputEnabledAtPowerOn);
            this.Controls.Add(this.checkBoxKeepOutputEnabled);
            this.Controls.Add(this.textBoxBrightness);
            this.Controls.Add(this.textBoxPowerLimit);
            this.Controls.Add(this.textBoxCurrentLimit);
            this.Controls.Add(this.textBoxVoltageLimit);
            this.Controls.Add(this.textBoxCurrent);
            this.Controls.Add(this.textBoxVoltage);
            this.Controls.Add(this.labelBrightness);
            this.Controls.Add(this.labelPowerLimit);
            this.Controls.Add(this.labelCurrentLimit);
            this.Controls.Add(this.labelVoltageLimit);
            this.Controls.Add(this.labelCurrent);
            this.Controls.Add(this.labelVoltage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DatasetDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Dataset";
            this.Load += new System.EventHandler(this.DatasetDialog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelVoltage;
        private System.Windows.Forms.TextBox textBoxVoltage;
        private System.Windows.Forms.Label labelCurrent;
        private System.Windows.Forms.TextBox textBoxCurrent;
        private System.Windows.Forms.Label labelVoltageLimit;
        private System.Windows.Forms.TextBox textBoxVoltageLimit;
        private System.Windows.Forms.Label labelCurrentLimit;
        private System.Windows.Forms.TextBox textBoxCurrentLimit;
        private System.Windows.Forms.Label labelPowerLimit;
        private System.Windows.Forms.TextBox textBoxPowerLimit;
        private System.Windows.Forms.Label labelBrightness;
        private System.Windows.Forms.TextBox textBoxBrightness;
        private System.Windows.Forms.CheckBox checkBoxKeepOutputEnabled;
        private System.Windows.Forms.CheckBox checkBoxOutputEnabledAtPowerOn;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonApply;
        private System.Windows.Forms.Button buttonClose;
    }
}