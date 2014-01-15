using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Hosting;
using Noesis.Drawing.Imaging.WebP;

namespace CaptureTest
{
    public partial class Main : Form
    {
        private bool _listening = false;
        private readonly BackgroundWorker _bgw = null;
        private readonly HelperFirewall _fw = new HelperFirewall();
        private readonly CaptureRectangle _frmRec = new CaptureRectangle();

        public int Speed { get; set; }
        public int Port { get; set; }

        public Main()
        {
            InitializeComponent();
            SetSpeed(trackBarSpeed.Value);
            SetPort();

            _bgw = new BackgroundWorker();
            _bgw.DoWork += bgw_DoWork;
            _bgw.ProgressChanged += bgw_ProgressChanged;
            _bgw.WorkerReportsProgress = true;
            _bgw.WorkerSupportsCancellation = true;

            this.FormClosed += Main_FormClosed;
        }

        private void bgw_DoWork(object sender, DoWorkEventArgs e)
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
                MessageBox.Show("Please open the port " + Port + " manually!\nor check the \"Auto configure firewall\"");
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
                        _bgw.ReportProgress(1, size);
                    }
                    Thread.Sleep(Speed);
                }
            }
        }

        private int Notify()
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<MyHub>();
            var size = 0;
            context.Clients.All.stream(_Capture(out size));
            return size;
        }

        #region Events

        //start
        private void button1_Click(object sender, EventArgs e)
        {
            _listening = true;
            button1.Enabled = !_listening;
            button2.Enabled = _listening;
            txtport.ReadOnly = _listening;
            checkBox1.Enabled = !_listening;

            if (!_bgw.IsBusy) _bgw.RunWorkerAsync();

        }

        //stop
        private void button2_Click(object sender, EventArgs e)
        {
            _listening = false;
            button1.Enabled = !_listening;
            button2.Enabled = _listening;
            txtport.ReadOnly = _listening;
            checkBox1.Enabled = !_listening;

            if (_bgw.IsBusy) _bgw.CancelAsync();
            _fw.CloseFirewall(Port);
        }
        void bgw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage == 2)
            {
                button2_Click(null, null);
            }
            else if (cbxConsole.Checked)
            {
                txtconsole.AppendText(string.Format("{0} frame captured, buffer size: {1}\n", DateTime.Now.ToString("s"), e.UserState));
            }
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

        void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
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
            try
            {
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
                    // Convert byte[] to Base64 String
                    return Convert.ToBase64String(imageBytes);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                _bgw.ReportProgress(2);
                return "";
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

    }
}
