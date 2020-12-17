using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatWeaverApp.Uti
{
    public static class MakeComponents
    {
        public static Button MakeButtonDialog(string text, Color color, Color colorHover, Color colorDown, Action callback, int width, int height)
        {
            Button but = new Button();
            but.Text = text;
            but.BackColor = color;
            but.FlatAppearance.MouseOverBackColor = colorHover;
            but.FlatAppearance.MouseDownBackColor = colorDown;
            but.Click += (sender, e) => { callback(); };
            but.Width = width;
            but.Height = height;

            but.FlatStyle = FlatStyle.Flat;
            but.FlatAppearance.BorderSize = 0;
            but.Font = FontTheme.regular;
            but.Margin = new Padding(0, 0, 0, 0);

            return but;
        }

        public static Label MakeLabelRegular(string text, Color backColor)
        {
            Label lab = new Label();
            lab.Text = text;
            lab.AutoSize = true;
            lab.Font = FontTheme.regular;
            lab.Margin = new Padding(0, 0, 0, 0);
            lab.TextAlign = ContentAlignment.MiddleLeft;
            lab.ForeColor = Uti.ColorTheme.fontDark;
            lab.BackColor = backColor;
            lab.FlatStyle = FlatStyle.Flat;

            return lab;
        }

        public static Button MakeButtonRegular(string text)
        {
            Button but = new Button();
            but.Text = text;
            but.FlatStyle = FlatStyle.Flat;
            but.FlatAppearance.BorderSize = 0;
            but.FlatAppearance.MouseOverBackColor = Uti.ColorTheme.lightButtonHover;
            but.FlatAppearance.MouseDownBackColor = Uti.ColorTheme.lightButtonDown;
            but.Font = Uti.FontTheme.mini;
            but.ForeColor = Uti.ColorTheme.fontDark;
            but.BackColor = Uti.ColorTheme.lightDimButton;
            but.Size = new Size(90, 30);
            but.Location = new Point(10, 5);
            but.Margin = new Padding(0, 0, 0, 0);

            return but;
        }

        public static Button MakeButtonIcon(string text, Color backColor, Color colorHover, Color colorDown, Size size = new Size(), bool isSmall = false)
        {
            Button but = new Button();
            but.Text = text;
            but.Font = isSmall? FontTheme.mini : FontTheme.regular;
            but.AutoSize = false;
            but.Size = !size.IsEmpty ? size : new Size(40, 40);
            but.Margin = new Padding(0, 0, 0, 0);
            but.TextAlign = ContentAlignment.MiddleCenter;
            but.ForeColor = Uti.ColorTheme.fontDarkDim;
            but.BackColor = backColor;
            but.FlatStyle = FlatStyle.Flat;
            but.FlatAppearance.BorderSize = 0;
            but.FlatAppearance.MouseOverBackColor = colorHover;
            but.FlatAppearance.MouseDownBackColor = colorDown;

            return but;
        }

        public static TextBox MakeTextBoxRegular(string text, Size size, Color? backColor=null, Color? fontColor = null, Color? backColorHighlight=null, Color? fontColorHighlight=null)
        {
            backColor = backColor == null ? ColorTheme.lightDimTextBox : backColor;
            fontColor = fontColor == null ? ColorTheme.fontDarkDim : fontColor;
            backColorHighlight = backColorHighlight == null ? ColorTheme.lightFocus : backColorHighlight;
            fontColorHighlight = fontColorHighlight == null ? ColorTheme.fontDark : fontColorHighlight;

            TextBox tb = new TextBox();
            tb.Size = size;
            tb.Text = text;
            tb.Font = FontTheme.regular;
            tb.BackColor = (Color)backColor;
            tb.ForeColor = (Color)fontColor;
            tb.Location = new Point(10, 10);
            tb.BorderStyle = BorderStyle.None;
            tb.Margin = new Padding(0, 0, 0, 0);

            tb.Enter += (sender, e) => { Uti.Methods.Highlight(tb, (Color)backColorHighlight, (Color)fontColorHighlight); };
            tb.Leave += (sender, e) => { Uti.Methods.Dehighlight(tb, (Color)backColor, (Color)fontColor); };

            return tb;
        }

        public static ComboBox MakeComboBoxRegular(List<string> items, Color backColor, string text = null)
        {
            ComboBox cb = new ComboBox();

            if (text != null) { cb.Text = text; } 
            else { cb.SelectedIndex = 0; }
            cb.Items.AddRange(items.Cast<object>().ToArray());
            cb.Font = Uti.FontTheme.regular;
            cb.FlatStyle = FlatStyle.Flat;
            cb.ForeColor = Uti.ColorTheme.fontDark;
            cb.BackColor = backColor;
            cb.Size = new Size(120, 30);
            cb.Location = new Point(10, 5);
            cb.Margin = new Padding(0, 0, 0, 0);

            cb.Enter += (sender, e) => { cb.BackColor = backColor; };
            cb.MouseClick += (sender, e) => { cb.BackColor = backColor; };

            return cb;
        }
    }
}
