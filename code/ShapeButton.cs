using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Windows_Store_Downloader.code
{
    public partial class ShapeButton : Button
    {
        private Color m_CustomClickColor;
        private Color m_CustomDisabledColor;
        private Color m_CustomDefaultColor;
        private Color m_CustomClickTextColor;
        private Color m_CustomDisabledTextColor;
        private Color m_CustomDefaultTextColor;
        private int m_Fillet;

        public ShapeButton()
        {
            this.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MouseEnter += new EventHandler(UserControlRoundButton_MouseEnter);
            this.MouseLeave += new EventHandler(UserControlRoundButton_MouseLeave);
            this.EnabledChanged += new EventHandler(UserControlCustomButton_EnabledChanged);

        }

        /// <summary>
        ///  不可用背景颜色
        /// </summary>
        public Color CustomDisabledColor
        {
            get
            {
                return m_CustomDisabledColor;
            }
            set
            {
                m_CustomDisabledColor = value;
            }
        }

        /// <summary>
        /// 默认背景颜色
        /// </summary>
        [Browsable(true)]
        public Color CustomDefaultColor
        {
            get
            {
                return m_CustomDefaultColor;
            }
            set
            {
                m_CustomDefaultColor = value;
            }
        }

        /// <summary>
        /// 光标放上去时颜色
        /// </summary>
        [Browsable(true)]
        public Color CustomClickColor
        {
            get
            {
                return m_CustomClickColor;
            }
            set
            {
                m_CustomClickColor = value;
            }
        }


        /// <summary>
        ///  不可用文字颜色
        /// </summary>
        [Browsable(true)]
        public Color CustomDisabledTextColor
        {
            get
            {
                return m_CustomDisabledTextColor;
            }
            set
            {
                m_CustomDisabledTextColor = value;
            }
        }

        /// <summary>
        /// 默认文字颜色
        /// </summary>
        [Browsable(true)]
        public Color CustomDefaultTextColor
        {
            get
            {
                return m_CustomDefaultTextColor;
            }
            set
            {
                m_CustomDefaultTextColor = value;
            }
        }

        /// <summary>
        /// 光标放上去时文字颜色
        /// </summary>
        [Browsable(true)]
        public Color CustomClickTextColor
        {
            get
            {
                return m_CustomClickTextColor;
            }
            set
            {
                m_CustomClickTextColor = value;
            }
        }


        /// <summary>
        /// 圆角度数、
        /// </summary>
        [Browsable(true)]
        public int Fillet
        {
            get
            {
                return m_Fillet;
            }
            set
            {
                m_Fillet = value;
            }
        }

        /// <summary>
        /// 按钮不可用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void UserControlCustomButton_EnabledChanged(object sender, EventArgs e)
        {
            if (!this.Enabled)
            {
                this.BackColor = m_CustomDisabledColor;
                this.ForeColor = m_CustomDisabledTextColor;
            }
            else
            {
                this.BackColor = m_CustomDefaultColor;
                this.ForeColor = m_CustomDefaultTextColor;
            }
        }

        /// <summary>
        /// 鼠标离开
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void UserControlRoundButton_MouseLeave(object sender, EventArgs e)
        {
            if (!this.Enabled)
                return;

            this.BackColor = m_CustomDefaultColor;
            this.ForeColor = m_CustomDefaultTextColor;
        }

        /// <summary>
        /// 鼠标进入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void UserControlRoundButton_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = m_CustomClickColor;
            this.ForeColor = m_CustomClickTextColor;
            this.ResetFlagsandPaint();
        }

        /// <summary>
        /// 绘制的路径
        /// </summary>
        /// <param name="rect"></param>
        /// <param name="radius"></param>
        /// <returns></returns>
        private GraphicsPath GetRoundedRectPath(Rectangle rect, int radius)
        {
            int diameter = radius;
            Rectangle arcRect = new Rectangle(rect.Location, new Size(diameter, diameter));
            GraphicsPath path = new GraphicsPath();
            path.AddArc(arcRect, 180, 90);
            arcRect.X = rect.Right - diameter;
            path.AddArc(arcRect, 270, 90);
            arcRect.Y = rect.Bottom - diameter;
            path.AddArc(arcRect, 0, 90);
            arcRect.X = rect.Left;
            path.AddArc(arcRect, 90, 90);
            path.CloseFigure();
            return path;
        }

        /// <summary>
        /// 绘制的代码，需要在设计页面声明事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShapeButton_Paint(object sender, PaintEventArgs e)
        {

            System.Drawing.Drawing2D.GraphicsPath FormPath;
            FormPath = new System.Drawing.Drawing2D.GraphicsPath();
            Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);//this.Left-10,this.Top-10,this.Width-10,this.Height-10);                 
            e.Graphics.Clear(Color.White);
            FormPath = GetRoundedRectPath(rect, m_Fillet);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.FillPath(new SolidBrush(this.BackColor), FormPath);

            StringFormat gs = new StringFormat();
            gs.Alignment = StringAlignment.Center; //居中
            gs.LineAlignment = StringAlignment.Center;//垂直居中
                                                      // gs.Alignment = StringAlignment.Far; //右对齐
            string str = "Hello World";
            Rectangle rc = new Rectangle(0, 0, this.Width, this.Height);
            Font fo = new Font("宋体", 10.5F);
            Brush brush = new SolidBrush(this.ForeColor);
            e.Graphics.DrawString(str, fo, brush, rc, gs);

        }
    }

}
