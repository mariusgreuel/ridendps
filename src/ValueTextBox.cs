using System;
using System.Drawing;
using System.Windows.Forms;

namespace Riden
{
    class ValueTextBox : TextBox
    {
        public event EventHandler ValueChanged;
        public event EventHandler ValueRestored;

        public override string Text
        {
            set
            {
                base.Text = value;
                textBackup = value;
            }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (e.KeyCode == Keys.Enter)
            {
                ApplyValue();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                RestoreValue();
            }
        }

        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
            ApplyValue();
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);

            bool valid = Tools.TryParseValue(Text, out double _);
            BackColor = valid ? SystemColors.Window : Color.Red;
        }

        protected virtual void OnValueChanged(EventArgs e)
        {
            ValueChanged?.Invoke(this, e);
        }

        protected virtual void OnValueRestored(EventArgs e)
        {
            ValueRestored?.Invoke(this, e);
        }

        void ApplyValue()
        {
            if (Text != textBackup)
            {
                if (Tools.TryParseValue(Text, out double _))
                {
                    textBackup = Text;
                    OnValueChanged(EventArgs.Empty);
                }
            }
        }

        void RestoreValue()
        {
            if (Text != textBackup)
            {
                Text = textBackup;
                OnValueRestored(EventArgs.Empty);
            }
        }

        string textBackup;
    }
}
