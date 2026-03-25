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
using System.Security;

namespace NoteSaver.Forms
{
    public partial class frmView : Form
    {
        string sub = @"C:\Users\User\source\repos\NoteSaver\TextFiles\Sub.txt";
        string des = @"C:\Users\User\source\repos\NoteSaver\TextFiles\Des.txt";
        public frmView()
        {
            InitializeComponent();
        }

        DataTable dt = new DataTable();
        
        private void btnHome_Click(object sender, EventArgs e)
        {
            frmMain form = new frmMain();
            form.Show();
            this.Hide();
           
        }

        private void frmView_Load(object sender, EventArgs e)
        {
            LoadNotes();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvNotes.SelectedRows.Count < 0)
            {
                MessageBox.Show("Select a note to update first!");
                
            }

            string subject = dgvNotes.SelectedRows[0].Cells[0].Value.ToString();
            string description = dgvNotes.SelectedRows[0].Cells[1].Value.ToString();
            int index = dgvNotes.SelectedRows[0].Index;


            frmEditNotes form = new frmEditNotes(this, subject, description, index);
            form.ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvNotes.SelectedRows.Count < 1)
            {
                MessageBox.Show("Select a note to remove!");
                return;
            }

            int index = dgvNotes.SelectedRows[0].Index;

            try
            {
               
                if (MessageBox.Show("Are you sure you want to remove this note?", "Remove",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    if (File.Exists(sub) && File.Exists(des))
                    {
                       var ubs = File.ReadAllLines(sub).ToList();
                       var bruh = File.ReadAllLines(des).ToList();

                        ubs.RemoveAt(index);
                        bruh.RemoveAt(index);

                        File.WriteAllLines(sub, ubs);
                        File.WriteAllLines(des, bruh);

                    }

                    MessageBox.Show("Success Removing note!");
                    LoadNotes();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error removing note" + ex.Message, "Error");
            }
        }

        public void LoadNotes()
        {
            dt.Columns.Clear();
            dt.Rows.Clear();
            dt.Columns.Add("Subject");
            dt.Columns.Add("Description");

            try
            {
                if (File.Exists(sub) && File.Exists(des))
                {
                    string[] lines = File.ReadAllLines(sub);
                    string[] desc = File.ReadAllLines(des);

                    for (int i = 0; i < lines.Length; i++)
                    {
                        DataRow row = dt.NewRow();
                        row[0] = lines[i];
                        row[1] = desc[i];
                        dt.Rows.Add(row);
                        dgvNotes.DataSource = dt;
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("File does not exist" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
