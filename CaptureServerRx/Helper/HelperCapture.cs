using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaptureServerRx
{
    public class HelperCapture
    {
        /// <summary>
        /// Capture Screen
        /// </summary>
        /// <param name="topleftx">the top left point x</param>
        /// <param name="toplefty">thie top left point y</param>
        /// <param name="width">capture width</param>
        /// <param name="height">capture height</param>
        /// <returns></returns>
        public static Bitmap Capture(int topleftx, int toplefty, int width, int height)
        {
            var bmp = new Bitmap(width, height);
            using (var g = Graphics.FromImage(bmp))
            {
                g.CopyFromScreen(topleftx, toplefty, 0, 0, new Size(width, height));
                return bmp;
            }
        }

        /// <summary>
        /// Capture the whole primary screen
        /// Eaquals to press the "Print screen" key
        /// </summary>
        /// <returns></returns>
        public static Bitmap Capture()
        {
            Size screenSize = Screen.PrimaryScreen.Bounds.Size;
            return Capture(0, 0, screenSize.Width, screenSize.Height);
        }
    }
}
