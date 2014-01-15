using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Hosting;
using Noesis.Drawing.Imaging.WebP;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Reactive.Linq;
using System.Threading;
using System.Windows.Forms;

namespace CaptureServerRx
{
    public partial class Main : Form
    {
        private bool _listening;
        private readonly HelperFirewall _fw = new HelperFirewall();
        private readonly CaptureRectangle _frmRec = new CaptureRectangle();
        private readonly IDisposable _task;

        public int Speed { get; set; }
        public int Port { get; set; }

        public Main()
        {
            InitializeComponent();
            FormClosing += Main_FormClosing;

            SetSpeed(trackBarSpeed.Value);
            SetPort();

            _task = Observable.ToAsync(DoWork)().Subscribe(
                _ => { },
                ex =>
                {
                    txtconsole.AppendText(ex.InnerException != null ? ex.InnerException.Message : ex.Message);
                    button2_Click(null, null);
                });
        }


        #region Events

        //start
        private void button1_Click(object sender, EventArgs e)
        {
            //incase when user modified the port
            SetPort();

            _listening = true;
            button1.Enabled = !_listening;
            button2.Enabled = _listening;
            txtport.ReadOnly = _listening;
            checkBox1.Enabled = !_listening;
        }

        //stop
        private void button2_Click(object sender, EventArgs e)
        {
            _listening = false;
            button1.Enabled = !_listening;
            button2.Enabled = _listening;
            txtport.ReadOnly = _listening;
            checkBox1.Enabled = !_listening;

            //incase when user modified the port
            _fw.CloseFirewall(Port);
        }

        private void trackBarSpeed_ValueChanged(object sender, EventArgs e)
        {
            SetSpeed(trackBarSpeed.Value);
        }

        // capture full screen
        private void rbtnfull_CheckedChanged(object sender, EventArgs e)
        {
            _frmRec.Hide();
        }

        // capture specific area
        private void rbtnrec_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnrec.Checked) _frmRec.Show();
        }

        // capture windows form control
        private void rbtnControl_CheckedChanged(object sender, EventArgs e)
        {
            _frmRec.Hide();
        }

        void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_task != null) _task.Dispose();
            _fw.CloseFirewall(Port);
        }

        private void cbxConsole_CheckedChanged(object sender, EventArgs e)
        {
            if (!cbxConsole.Checked) txtconsole.Text = "";
        }
        #endregion

        private string _Capture(out int size)
        {
            size = 0;
            using (var ms = new MemoryStream())
            {
                Bitmap bmp;
                if (rbtnfull.Checked)
                    bmp = HelperCapture.Capture();
                else if (rbtnrec.Checked)
                {
                    int borderwidth = SystemInformation.SizingBorderWidth + SystemInformation.FrameBorderSize.Width +
                        //SystemInformation.BorderSize.Width +
                                      SystemInformation.HorizontalFocusThickness +
                                      SystemInformation.HorizontalResizeBorderThickness,
                        borderheight = SystemInformation.FrameBorderSize.Height +
                        //SystemInformation.BorderSize.Height +
                                       SystemInformation.VerticalFocusThickness +
                                       SystemInformation.VerticalResizeBorderThickness;
                    bmp = HelperCapture.Capture(
                        _frmRec.Location.X + borderwidth,
                        _frmRec.Location.Y + borderheight + SystemInformation.CaptionHeight,
                        _frmRec.Width - borderwidth * 2,
                        _frmRec.Height - borderheight * 2 - SystemInformation.CaptionHeight);
                }
                else
                {
                    bmp = HelperCapture.Capture();
                }
                if (rbtnvp.Checked)
                {
                    WebPFormat.SaveToStream(ms, bmp);
                }
                else if (rbtnjpg.Checked)
                {
                    bmp.Save(ms, ImageFormat.Jpeg);
                }
                else
                {
                    bmp.Save(ms, ImageFormat.Png);
                }
                byte[] imageBytes = ms.ToArray();
                size = imageBytes.Length;
                return Convert.ToBase64String(imageBytes);
            }
        }

        private void SetSpeed(int value)
        {
            var i = 11 - value;
            if (i < 5) Speed = 5 * i;
            else Speed = 10 * i;

            var fps = 1000 / Speed;
            lblfps.Text = fps + " fps";
        }

        private void SetPort()
        {
            var p = 8080;
            int.TryParse(txtport.Text.Trim(), out p);
            Port = p;
        }

        private int Notify()
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<MyHub>();
            int size;
            context.Clients.All.stream(_Capture(out size));
            return size;
        }
        
        private void DoWork()
        {
            SetPort();
            string url = "http://*:" + Port + "/";

            //check if need to set up firewall (open port) manually
            if (checkBox1.Checked)
            {
                _fw.OpenFirewall(Port, "Screen Share Service");
            }
            else if (!_fw.isPortFound(Port))
            {
                MessageBox.Show("Please open the port " + Port +
                                " manually!\r\nor check the \"Auto configure firewall\"");
                button2_Click(null, null);
                return;
            }

            using (WebApp.Start<Startup>(url))
            {
                while (true)
                {
                    if (_listening)
                    {
                        var size = Notify();
                        if (cbxConsole.Checked)
                            txtconsole.AppendText(string.Format("{0} frame captured, buffer size: {1}\r\n",
                                DateTime.Now.ToString("s"), size));
                    }
                    Thread.Sleep(Speed);
                }
            }
        }


    }
}
