using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ChatWeaverApp.Uti
{
    public static class ColorTheme
    {
        #region General Colors

        /// <summary> BG : 230 </summary>
        public static Color light = Color.FromArgb(230, 230, 230);

        /// <summary> For Textboxes: 210 </summary>
        public static Color lightDimTextBox = Color.FromArgb(210, 210, 210);

        /// <summary> For Buttons : 220 </summary>
        public static Color lightDimButton = Color.FromArgb(220, 220, 220);
        public static Color lightDimAccent220 = Color.FromArgb(220, 220, 220);

        /// <summary> Selected textboxes : 245 </summary>
        public static Color lightFocus = Color.FromArgb(245, 245, 245);

        /// <summary> Selected but dimmed : 242 </summary>
        public static Color lightFocusBrighter = Color.FromArgb(250, 250, 250);

        /// <summary> Regular fonts, titles : 10 </summary>
        public static Color fontDark = Color.FromArgb(10, 10, 10);

        /// <summary> Subtitles, control bar menus : 100 </summary>
        public static Color fontDarkDim = Color.FromArgb(100, 100, 100);

        /// <summary> Subtitles, control bar menus : 100 </summary>
        public static Color fontDarkAsh = Color.FromArgb(150, 150, 150);

        /// <summary> Subtle icons : 200 </summary>
        public static Color fontAsh = Color.FromArgb(200, 200, 200);

        /// <summary> When mouse over : 205 </summary>
        public static Color lightButtonHover = Color.FromArgb(205, 205, 205);

        /// <summary> When mouse down : 185 </summary>
        public static Color lightButtonDown = Color.FromArgb(185, 185, 185);

        #endregion

        #region Interactive Colors

        public static Color green = Color.LightGreen;
        public static Color greenDark = Color.LightSeaGreen;

        public static Color blue = Color.DeepSkyBlue;
        public static Color blueDark = Color.SkyBlue;

        public static Color red = Color.LightCoral;
        public static Color redDark = Color.Tomato;

        public static Color pub = Color.Gold;
        public static Color pubDark = Color.Goldenrod;

        public static Color more = Color.Moccasin;
        public static Color moreDark = Color.Orange;

        #endregion
    }
}
