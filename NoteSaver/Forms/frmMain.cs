using NoteSaver.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NoteSaver
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddNote note = new frmAddNote();
            note.Show();
            this.Hide();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            frmView view = new frmView();
            view.Show();
            this.Hide();
        }
    }
}
