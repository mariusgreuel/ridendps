using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace Riden
{
    class PowerButton : CheckBox
    {
        protected override void OnPaint(PaintEventArgs e)
        {
            OnPaintBackground(e);

            var graphics = e.Graphics;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;

            if (Focused)
            {
                ControlPaint.DrawFocusRectangle(graphics, ClientRectangle);
            }

            var rectangle = new Rectangle(2, 2, Height - 5, Height - 5);
            graphics.FillEllipse(Checked ? Brushes.Green : Brushes.Red, rectangle);

            var stringFormat = new StringFormat() { HotkeyPrefix = ShowKeyboardCues ? HotkeyPrefix.Show : HotkeyPrefix.Hide };
            graphics.DrawString(Text, Font, new SolidBrush(ForeColor), Height, (Height - Font.Height) / 2, stringFormat);
        }
    }
}
