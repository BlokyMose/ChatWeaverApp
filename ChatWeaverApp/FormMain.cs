using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace ChatWeaverApp
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            ShowFormHome();

            // Change BG color
            foreach (Control control in this.Controls)
            {
                MdiClient client = control as MdiClient;
                if (!(client == null))
                {
                    client.BackColor = Color.FromArgb(255,230,230,230);
                    break;
                }
                //https://stackoverflow.com/questions/1087133/change-background-of-an-mdi-form
            }
        }


        private void flowControlBar_Paint(object sender, PaintEventArgs e)
        {
            flowControlBar.Location = new Point(Width - flowControlBar.Width, 0);
        }

        #region REG: Buttons Callbacks

        private void butExit_Click(object sender, EventArgs e)
        {
            DialogForms.DialogSimple dialog = new DialogForms.DialogSimple(DialogForms.DialogType.Exit, this);
            dialog.Show();
        }

        private void butMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        #endregion

        #region REG: Paints

        private void butMinimize_Paint(object sender, PaintEventArgs e)
        {
            ToolTip toolTip = new ToolTip();
            toolTip.BackColor = Color.Transparent;
            toolTip.SetToolTip((Control)sender, "Minimize");
        }




        #endregion


        private void butHome_Click(object sender, EventArgs e)
        {
            ShowFormHome();
        }

        #region REG: Show Forms

        private void ShowFormHome()
        {
            foreach (Form f in Application.OpenForms)
            {
                if (f is TabHome.FormHomeMain) return;
            }

            TabHome.FormHomeMain form = new TabHome.FormHomeMain();
            form.MdiParent = this;
            form.StartPosition = FormStartPosition.Manual;
            form.Size = new Size(Screen.PrimaryScreen.WorkingArea.Size.Width-10, Screen.PrimaryScreen.WorkingArea.Size.Height - flowTabBar.Height-10);
            form.Show();
            form.Location = new Point(0, flowTabBar.Height);
        }

        #endregion
    }
}
