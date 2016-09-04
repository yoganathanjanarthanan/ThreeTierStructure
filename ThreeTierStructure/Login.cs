using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BAL;
using BEL;

namespace ThreeTierStructure
{
    public partial class Login : Form
    {
        public Informations info = new Informations();
        public Operations opr = new Operations();
        DataTable dt = new DataTable();
        public Login()
        {
            InitializeComponent();
        }

        private void btLogin_Click(object sender, EventArgs e)
        {
            info.username = tbUname.Text;
            info.password = tbPass.Text;

            dt=opr.login(info);
            if (dt.Rows.Count > 0)
            {
                MDIParent1 m = new MDIParent1();
                m.Show();
                Login log = new Login();
                log.Close();
                this.Hide();
                
            }
            else
            {
                MessageBox.Show("invalid Username and Password", "invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                tbUname.Text = "";
                tbPass.Text = "";
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            Environment.Exit(0);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form3 re = new Form3();
            re.Show();
            this.Hide();

        }
    }
}
