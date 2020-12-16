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
    public partial class FormMainControl : Form
    {
        public FormMainControl()
        {
            InitializeComponent();
        }

        private void butOpenFormManageSayUnit_Click(object sender, EventArgs e)
        {
            TabHome.FormManageSayUnit form = new TabHome.FormManageSayUnit();
            form.MdiParent = this.MdiParent;
            form.Show();
        }
    }
}
