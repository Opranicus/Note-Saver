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
    public partial class frmEditNotes : Form
    {

        string _subject;
        string _description;
        int _index;
        private frmView _view;
        
        public frmEditNotes(frmView view, string subject, string description, int index)
        {
            InitializeComponent();
            _view = view;
            _subject = subject;
            _description = description;
            _index = index;
           
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            frmMain form = new frmMain();
            form.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void frmEditNotes_Load_1(object sender, EventArgs e)
        {
            txtSub.Text = _subject;
            txtDes.Text = _description;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string sub = @"C:\Users\User\source\repos\NoteSaver\TextFiles\Sub.txt";
            string des = @"C:\Users\User\source\repos\NoteSaver\TextFiles\Des.txt";

            string subs = txtSub.Text;
            string desc = txtDes.Text;

            bool bruh = false;
            if (File.Exists(sub) && File.Exists(des))
            {
                string[] su = File.ReadAllLines(sub);
                string[] de = File.ReadAllLines(des);

                if (_index < subs.Length && _index < desc.Length)
                {
                    su[_index] = subs;
                    de[_index] = desc;

                    File.WriteAllLines(sub, su);
                    File.WriteAllLines(des, de);
                    bruh = true;

                    if (bruh)
                    {
                        MessageBox.Show("Success editing Bruh");
                        this.Hide();
                        _view.LoadNotes();
                    }
                }
            }
        }
    }
}
