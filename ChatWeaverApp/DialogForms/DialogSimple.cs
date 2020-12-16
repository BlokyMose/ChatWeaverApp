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
    public enum DialogIcon { Warning, Question, Quit}
    public enum DialogType { Exit }

    public partial class DialogSimple : Form
    {
        public DialogSimple(string title, string desc, DialogIcon icon, List<Action> buttonCallbacks, List<string> buttonTexts, Form parent, List<Color> butColors = null, List<Color> butColorHovers = null, List<Color> butColorDowns = null)
        {
            InitializeComponent();
            SetComponents(title, desc, icon, buttonCallbacks, buttonTexts, parent, butColors, butColorHovers, butColorDowns);
        }

        public DialogSimple(DialogType type, Form parent)
        {
            InitializeComponent();
            switch (type)
            {
                case DialogType.Exit:
                    SetComponents(
                        "Exit ChatWeaver",
                        "You are about to exit this program. Are you sure you want to quit?",
                        DialogIcon.Quit,
                        new List<Action>() { () => { Application.Exit(); }, () => { this.Close(); } },
                        new List<string>() { "Quit", "Cancel" },
                        parent,
                        new List<Color>() { Color.White, Color.White },
                        new List<Color>() { Uti.ColorTheme.red, Uti.ColorTheme.green },
                        new List<Color>() { Uti.ColorTheme.redDark, Uti.ColorTheme.greenDark }
                        ); ; ;
                    break;
                default:
                    break;
            }

        }

        private void SetComponents(string title, string desc, DialogIcon icon, List<Action> buttonCallbacks, List<string> buttonTexts, Form parent, List<Color> butColors = null, List<Color> butColorHovers = null, List<Color> butColorDowns = null)
        {
            labDialogTitle.Text = title;
            labDesc.Text = desc;
            switch (icon)
            {
                case DialogIcon.Warning: labIcon.Text = "~ ✋ ~";
                    break;
                case DialogIcon.Question:labIcon.Text = "~ 🤔 ~";
                    break;
                case DialogIcon.Quit:labIcon.Text = "~ 🚪🚶 ~";
                    break;
                default:
                    break;
            }
            for (int i = 0; i < buttonCallbacks.Count; i++)
            {
                Button but = Uti.MakeComponents.MakeButtonDialog(
                    buttonTexts[i], 
                    butColors!=null ? butColors[i] : Color.White, 
                    butColorHovers != null ? butColorHovers[i] : Color.Orange, 
                    butColorDowns != null ? butColorDowns[i] : Color.DarkOrange, 
                    buttonCallbacks[i], 
                    flowButtons.Width / buttonCallbacks.Count, 
                    flowButtons.Height);
                but.Parent = flowButtons;
            }
        }
    }
}


