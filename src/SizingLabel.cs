using System;
using System.Drawing;
using System.Windows.Forms;

namespace Riden
{
    class SizingLabel : Label
    {
        public override string Text
        { 
            set
            {
                base.Text = value;

                if (measureText == null)
                {
                    measureText = value;
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            OnPaintBackground(e);
            var size = TextRenderer.MeasureText(e.Graphics, measureText, Font);
            var scale = Math.Min((float)Width / size.Width, (float)Height / size.Height);
            var font = new Font(Font.FontFamily, Font.Size * scale, Font.Style);
            TextRenderer.DrawText(e.Graphics, Text, font, ClientRectangle, ForeColor, MapAlignment(TextAlign));
        }

        static TextFormatFlags MapAlignment(ContentAlignment alignment)
        {
            switch (alignment)
            {
                case ContentAlignment.TopLeft:
                    return TextFormatFlags.Left | TextFormatFlags.Top;
                case ContentAlignment.TopCenter:
                    return TextFormatFlags.HorizontalCenter | TextFormatFlags.Top;
                case ContentAlignment.TopRight:
                    return TextFormatFlags.Right | TextFormatFlags.Top;
                case ContentAlignment.MiddleLeft:
                    return TextFormatFlags.Left | TextFormatFlags.VerticalCenter;
                case ContentAlignment.MiddleCenter:
                    return TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter;
                case ContentAlignment.MiddleRight:
                    return TextFormatFlags.Right | TextFormatFlags.VerticalCenter;
                case ContentAlignment.BottomLeft:
                    return TextFormatFlags.Left | TextFormatFlags.Bottom;
                case ContentAlignment.BottomCenter:
                    return TextFormatFlags.HorizontalCenter | TextFormatFlags.Bottom;
                case ContentAlignment.BottomRight:
                    return TextFormatFlags.Right | TextFormatFlags.Bottom;
                default:
                    return TextFormatFlags.Default;
            }
        }

        string measureText = null;
    }
}
