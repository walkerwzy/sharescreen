using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Tracing;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaptureTest
{
    public partial class CaptureRectangle : Form
    {
        public CaptureRectangle()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.Manual;
            Location = new Point(200, 100);
            Width = 1014;
            Height = 768;
            BackColor = Color.White;
            TransparencyKey = Color.White;
            Opacity = 1;
            TopMost = true;
            ControlBox = false;
            Text = "Drag and resize the rectangle to the area you want to capture";
            ShowInTaskbar = false;
            MaximizeBox = false;
        }

        public override sealed Color BackColor
        {
            get { return base.BackColor; }
            set { base.BackColor = value; }
        }

        public override sealed string Text
        {
            get { return base.Text; }
            set { base.Text = value; }
        }
    }
}
