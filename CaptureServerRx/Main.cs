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
        private IDisposable _task;
        private bool _serverRunning = false;

        public int Speed { get; set; }
        public int Port { get; set; }

        public Main()
        {
            InitializeComponent();
            FormClosing += Main_FormClosing;

            SetSpeed(trackBarSpeed.Value);
            SetPortNumber();
        }

        private void StartTask()
        {
            _task = Observable.ToAsync(DoWork)().Subscribe(
                _ => { },
                ex =>
                {
                    txtconsole.AppendText(ex.InnerException != null ? ex.InnerException.Message : ex.Message);
                    button2_Click(null, null);
                });
        }
        private void DoWork()
        {
            SetPortNumber();
            string url = "http://*:" + Port + "/";

            using (WebApp.Start<Startup>(url))
            {
                _serverRunning = true;
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

        private void SetPortNumber()
        {
            var p = 8080;
            int.TryParse(txtport.Text.Trim(), out p);
            Port = p;
        }

        private bool CheckPortIsOpen()
        {
            if (!cbxAutoFirewall.Checked) return _fw.isPortFound(Port);
            _fw.OpenFirewall(Port, "Screen Share Service");
            return true;
        }

        private int Notify()
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<MyHub>();
            int size;
            context.Clients.All.stream(_Capture(out size));
            return size;
        }

        #region Events

        //start
        private void button1_Click(object sender, EventArgs e)
        {
            //in case  people modified the port
            SetPortNumber();
            if (!CheckPortIsOpen())
            {
                MessageBox.Show("Please open the port " + Port +
                                " manually!\r\nor check the \"Auto configure firewall\" control");
                return;
            }

            _listening = true;
            button1.Enabled = !_listening;
            button2.Enabled = _listening;
            txtport.ReadOnly = _listening;
            cbxAutoFirewall.Enabled = !_listening;

            if (!_serverRunning) StartTask();
        }

        //stop
        private void button2_Click(object sender, EventArgs e)
        {
            _listening = false;
            button1.Enabled = !_listening;
            button2.Enabled = _listening;
            //TODO: I can't stop the signalr server and restart it, so it's no way to reset the port after the server is start
            //txtport.ReadOnly = _listening;
            //cbxAutoFirewall.Enabled = !_listening;

            //in case people modified the port
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

    }
}
