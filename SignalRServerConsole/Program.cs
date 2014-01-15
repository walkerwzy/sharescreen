using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Hosting;
using Owin;

namespace SignalRServerConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Set fresh frequency:\n[0]: fast(default), [1]: medium, [2]: slow, [3]: extremely fast(be careful)\n");
            var k = Console.ReadKey();
            int speed = 5;
            switch (k.Key.ToString())
            {
                case "1":
                    speed = 10;
                    break;
                case "2":
                    speed = 50;
                    break;
                case "3":
                    speed = 1;
                    break;
                default:
                    speed = 5;
                    break;
            }
            // This will *ONLY* bind to localhost, if you want to bind to all addresses
            // use http://*:8080 to bind to all addresses. 
            // See http://msdn.microsoft.com/en-us/library/system.net.httplistener.aspx 
            // for more information.
            const string url = "http://*:8080";
            using (WebApp.Start(url))
            {
                Console.WriteLine("\nServer running on {0}", url);
                var bgw = new BackgroundWorker();
                bgw.DoWork += bgw_DoWork;
                bgw.RunWorkerAsync(speed);
                Console.ReadLine();
            }
        }

        static void bgw_DoWork(object sender, DoWorkEventArgs e)
        {
            int speed = int.Parse(e.Argument.ToString());
            while (true)
            {
                Notify();
                Thread.Sleep(speed);
            }
        }
        public static void Notify()
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<MyHub>();
            //context.Clients.All.addMessage("aa", GetPic());
            context.Clients.All.stream(GetPic());
        }
        public static string GetPic()
        {
            using (var ms = new MemoryStream())
            {
                var scr = Screen.PrimaryScreen.Bounds;
                //var path = AppDomain.CurrentDomain.BaseDirectory;
                //var time = DateTime.Now.ToFileTime();
                int startx = 0,
                    starty = 0,
                    width = scr.Width - 500,
                    height = scr.Height - 200;

                var img = new Bitmap(width, height);
                var g = Graphics.FromImage(img);
                g.CopyFromScreen(startx, starty, 0, 0, new Size(width, height));
                //var fname = time + ".png";
                //var fullname = Path.Combine(path, fname);
                //img.Save(fullname, ImageFormat.Png);
                img.Save(ms, ImageFormat.Png);

                byte[] imageBytes = ms.ToArray();

                // Convert byte[] to Base64 String
                return Convert.ToBase64String(imageBytes);
            }
        }
    }
    class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(CorsOptions.AllowAll);
            app.MapSignalR();
        }
    }
    public class MyHub : Hub
    {
        public void Send(string name, string message)
        {
            Clients.All.addMessage(name, message);
        }
    }
}
