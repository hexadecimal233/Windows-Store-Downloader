using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;


namespace WinUtils
{
    public class ToolStripNonClientRender : ToolStripProfessionalRenderer
    {
        public bool useMenuRender = true;
        private Color BackGroundColor;

        public ToolStripNonClientRender()
        {
            BackGroundColor = Win7Style.GetAeroBackgroundColor();
        }

        public ToolStripNonClientRender(Color backColor)
        {
            BackGroundColor = backColor;
        }

        protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
        {
            if (!useMenuRender)
            {
                base.OnRenderMenuItemBackground(e);
                return;
            }

            if (e.Item.Selected)
            {
                if (e.Item.Enabled)
                {
                    e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(221, 236, 255)), 3, 0, e.Item.Width - 6, e.Item.Height - 1);
                    e.Graphics.DrawRectangle(new Pen(Color.FromArgb(38, 160, 218)), 3, 0, e.Item.Width - 6, e.Item.Height - 1);
                }
                else
                {
                    e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(238, 238, 238)), 3, 0, e.Item.Width - 6, e.Item.Height - 1);
                    e.Graphics.DrawRectangle(new Pen(Color.FromArgb(128, 128, 128)), 3, 0, e.Item.Width - 6, e.Item.Height - 1);
                }
            }
            else
            {
                base.OnRenderMenuItemBackground(e);
            }
        }

        protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e)
        {
            if (e.ToolStrip.IsDropDown)
            {
                base.OnRenderToolStripBackground(e);
            }
            else
            {
                //Clear so Aero glass covers the area
                e.Graphics.Clear(BackGroundColor);
            }
        }

        protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
        {
            /// Don't render border if on glass area
            if (e.ToolStrip.IsDropDown)
            {
                base.OnRenderToolStripBorder(e);
            }
        }

        protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
        {
            if (e.ToolStrip.IsDropDown)
            {
                base.OnRenderItemText(e);
            }
            else
            {
                //Text must be rendered this way or text will be ugly-painted.
                GraphicsPath path = new GraphicsPath();
                path.AddString(e.Text, e.TextFont.FontFamily, (int)e.TextFont.Style, e.TextFont.Size + 2, e.TextRectangle.Location, new StringFormat());
                e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
                e.Graphics.FillPath(Brushes.Black, path);

                path.Dispose();
            }


        }

        protected override void OnRenderOverflowButtonBackground(ToolStripItemRenderEventArgs e)
        {
            ///Draw overflow button, specially for this renderer.

            if (e.Item.Selected)
            {
                e.Graphics.Clear(Color.FromArgb(20, Color.Navy));
            }

            Rectangle r = Rectangle.Empty;
            if (e.Item.RightToLeft == RightToLeft.Yes)
            {
                r = new Rectangle(0, e.Item.Height - 8, 9, 5);
            }
            else
            {
                r = new Rectangle(e.Item.Width - 12, e.Item.Height - 16, 9, 5);
            }

            base.DrawArrow(new ToolStripArrowRenderEventArgs(e.Graphics, e.Item, r, SystemColors.ControlText, ArrowDirection.Down));

            e.Graphics.DrawLine(SystemPens.ControlText, (int)(r.Right - 7), (int)(r.Y - 2), (int)(r.Right - 3), (int)(r.Y - 2));

        }

    }
}
