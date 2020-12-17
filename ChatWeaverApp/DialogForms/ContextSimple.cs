using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatWeaverApp.DialogForms
{
    public partial class ContextSimple : Form
    {
        public ContextSimple(bool hasInsight, Action CallbackShowInsight)
        {
            InitializeComponent();
            if (!hasInsight)
            {
                labInsight.Visible = false;
                flowMainContainer.Height = flowMain.Height;
            }
            else
            {
                labInsight.Click += (sender, e) => { CallbackShowInsight(); };
                labInsight.ForeColor = Uti.ColorTheme.fontDarkAsh;
                labInsight.MouseEnter += (sender, e) => { labInsight.BackColor = BackColor; labInsight.ForeColor = Uti.ColorTheme.fontDark; };
                labInsight.MouseLeave += (sender, e) => { labInsight.BackColor = Color.Transparent; labInsight.ForeColor = Uti.ColorTheme.fontDarkAsh; };
            }
        }

        public void MakeMenuClick(string name, Action CallbackClick, bool hasLock = false , string icon = "", Color? colorIcon = null, Color? colorName = null)
        {
            colorIcon = colorIcon != null ? (Color)colorIcon : Uti.ColorTheme.fontDark;
            colorName = colorName != null ? (Color)colorName : Uti.ColorTheme.fontDark;

            int panelHeight = 17;
            int panelWidth = 150;
            int iconWidth = 17;
            int lockWidth = 34;
            int nameWidth = !hasLock ? panelWidth - iconWidth : panelWidth - iconWidth - lockWidth;

            bool isLocked = hasLock;

            FlowLayoutPanel flow = new FlowLayoutPanel();
            flow.Margin = new Padding(0);
            flow.Size = new Size(panelWidth, panelHeight);
            flow.BackColor = flowMain.BackColor;
            flowMain.Controls.Add(flow);

            Label labIcon = new Label();
            labIcon.Text = icon;
            labIcon.Font = Uti.FontTheme.mini;
            labIcon.ForeColor = isLocked ? Uti.ColorTheme.fontAsh : (Color)colorIcon;
            labIcon.Size = new Size(iconWidth, panelHeight);
            labIcon.Margin = new Padding(0);
            labIcon.AutoSize = false;
            labIcon.TextAlign = ContentAlignment.MiddleCenter;
            labIcon.BackColor = Color.Transparent;
            labIcon.MouseEnter += (sender, e) => { if(!isLocked)flow.BackColor = Uti.ColorTheme.lightButtonHover; };
            labIcon.MouseLeave += (sender, e) => { if(!isLocked)flow.BackColor = flowMain.BackColor; };

            labIcon.MouseClick += (sender, e) => { Callback(); };
            flow.Controls.Add(labIcon);

            Label labName = new Label();
            labName.Text = name;
            labName.Font = Uti.FontTheme.mini;
            labName.ForeColor =  isLocked ? Uti.ColorTheme.fontAsh : (Color)colorName;
            labName.Size = new Size(nameWidth, panelHeight);
            labName.Margin = new Padding(0);
            labName.AutoSize = false;
            labName.TextAlign = ContentAlignment.MiddleLeft;
            labName.BackColor = Color.Transparent;
            labName.MouseClick += (sender, e) => { Callback(); };
            labName.MouseEnter += (sender, e) => { if(!isLocked)flow.BackColor = Uti.ColorTheme.lightButtonHover; };
            labName.MouseLeave += (sender, e) => { if(!isLocked)flow.BackColor = flowMain.BackColor; };
            flow.Controls.Add(labName);

            void Callback()
            {
                if (!isLocked)
                {
                    CallbackClick();
                    Close();
                }
            }
            if (!hasLock) return;

            Label labLock = new Label();
            labLock.Text = "🔒";
            labLock.Font = Uti.FontTheme.mini;
            labLock.ForeColor = Uti.ColorTheme.fontDarkDim;
            labLock.Size = new Size(lockWidth, panelHeight);
            labLock.Margin = new Padding(0);
            labLock.AutoSize = false;
            labLock.TextAlign = ContentAlignment.MiddleCenter;
            labLock.BackColor = Color.Transparent;
            labLock.MouseEnter += (sender, e) => { if(isLocked)labLock.ForeColor = Uti.ColorTheme.greenDark; };
            labLock.MouseLeave += (sender, e) => { if(isLocked)labLock.ForeColor = Uti.ColorTheme.fontDark; };
            labLock.MouseClick += (sender, e) => 
            { 
                isLocked = false; 
                labLock.Text = "✔";
                labLock.ForeColor = Uti.ColorTheme.fontAsh;
                labIcon.ForeColor = (Color)colorIcon;
                labName.ForeColor = (Color)colorName;
            }; 
            flow.Controls.Add(labLock);

            flowMain.Controls.Add(flow);
            UpdateHeight(panelHeight);
        }
       
        public void MakeMenuTextBox(string name, Action<string> CallbackClick, string icon = "", string defaultValue = "", Color? colorIcon = null, Color? colorName = null)
        {
            colorIcon = colorIcon != null ? (Color)colorIcon : Uti.ColorTheme.fontDark;
            colorName = colorName != null ? (Color)colorName : Uti.ColorTheme.fontDark;

            int panelHeight = 34;
            int panelWidth = 150;
            int iconWidth = 17;
            int nameWidth = 56;

            FlowLayoutPanel flow = new FlowLayoutPanel();
            flow.Margin = new Padding(0);
            flow.Size = new Size(panelWidth, panelHeight);
            flow.BackColor = flowMain.BackColor;
            flowMain.Controls.Add(flow);

            Label labIcon = new Label();
            labIcon.Text = icon;
            labIcon.Font = Uti.FontTheme.mini;
            labIcon.ForeColor = (Color)colorIcon ;
            labIcon.Size = new Size(iconWidth, panelHeight);
            labIcon.Margin = new Padding(0);
            labIcon.AutoSize = false;
            labIcon.TextAlign = ContentAlignment.MiddleCenter;
            labIcon.BackColor = Color.Transparent;
            flow.Controls.Add(labIcon);

            Label labName = new Label();
            labName.Text = name;
            labName.Font = Uti.FontTheme.mini;
            labName.ForeColor =(Color)colorName;
            labName.Size = new Size(nameWidth, panelHeight);
            labName.Margin = new Padding(0);
            labName.AutoSize = false;
            labName.TextAlign = ContentAlignment.MiddleLeft;
            labName.BackColor = Color.Transparent;
            flow.Controls.Add(labName);

            TextBox tb = new TextBox();
            tb.Text = defaultValue;
            tb.Font = Uti.FontTheme.mini;
            tb.ForeColor = Uti.ColorTheme.fontDark;
            tb.Size = new Size(70, 15);
            tb.Margin = new Padding(0);
            tb.BorderStyle = BorderStyle.None;
            flow.Controls.Add(tb);

            flowMain.Controls.Add(flow);
            UpdateHeight(panelHeight);
        }

        private void UpdateHeight(int addheight)
        {
            flowMain.Height += addheight;
            flowMainContainer.Height += addheight;
            Height += addheight;
        }
    }
}
