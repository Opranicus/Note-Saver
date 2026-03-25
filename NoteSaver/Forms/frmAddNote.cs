using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace NoteSaver.Forms
{
    public partial class frmAddNote : Form
    {
        public frmAddNote()
        {
            InitializeComponent();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            frmMain form = new frmMain();
            form.Show();
            this.Hide();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string sub = @"C:\Users\User\source\repos\NoteSaver\TextFiles\Sub.txt";
            string des = @"C:\Users\User\source\repos\NoteSaver\TextFiles\Des.txt";

            string subs = txtSub.Text;
            string dess = txtDes.Text;


            try
            {

                if (string.IsNullOrEmpty(subs) || string.IsNullOrEmpty(dess))
                {
                    MessageBox.Show("All feilds are required!");
                }

                else
                {
                    bool add = false;
                    File.AppendAllText(sub, subs + Environment.NewLine);
                    File.AppendAllText(des, dess + Environment.NewLine);
                    add = true;

                    if (add)
                    {
                        MessageBox.Show("Succes adding note", "Adding", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtSub.Clear();
                        txtDes.Clear();
                    }
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show("Error adding note!" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
