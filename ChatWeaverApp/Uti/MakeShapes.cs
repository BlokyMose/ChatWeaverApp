using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace ChatWeaverApp.Uti
{
    public static class MakeShapes
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        public static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // height of ellipse
            int nHeightEllipse // width of ellipse

        //How to use:
        //butMinimize.Region = System.Drawing.Region.FromHrgn(Utility.MakeShapes.CreateRoundRectRgn(0, 0, butMinimize.Width, butMinimize.Height, 10, 10));
        );
    }
}
