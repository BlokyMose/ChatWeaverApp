using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatWeaverApp.TabHome
{
    public partial class FormHomeMain : Form
    {
        Form currentChild;
        public FormHomeMain()
        {
            InitializeComponent();
        }

        private void FormHomeMain_SizeChanged(object sender, EventArgs e)
        {
            panRight.Size = new Size(Width - flowLeft.Width, Height);
        }

        #region REG: Button Clicks
        
        private void butData_Click(object sender, EventArgs e)
        {
            if(currentChild!=null) 
                if (currentChild is FormManageSayUnit)
                {
                    return;
                }
                else
                {
                    currentChild.Close();
                }

            FormManageSayUnit form = new FormManageSayUnit();
            currentChild = form;
            Size = new Size(flowLeft.Width, Height);
            panRight.Hide();

            form.StartPosition = FormStartPosition.Manual;
            form.MdiParent = this.MdiParent;
            form.Size = new Size(MdiParent.Size.Width - Size.Width - 10, Size.Height - 10);
            form.Show();
            form.Location = new Point(Size.Width, Location.Y);

        }

        #endregion

    }
}
