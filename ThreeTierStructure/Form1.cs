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
    public partial class Form1 : Form
    {
        public Informations info = new Informations();
        public Operations opr = new Operations();

        string gender;

        public Form1()
        {
            InitializeComponent();
        }

        private void tbReg_Click(object sender, EventArgs e)
        {
            info.name = tbName.Text;

            if (rbMale.Checked == true)
            {
                gender = "Male";
            }
            if (rbFemale.Checked == true)
            {
                gender = "Female";
            }
            info.gender = gender;

            info.dob =dtpDOB.Value.ToShortDateString();
            info.address = tbAdrs.Text;
            info.education = cbEdu.Text;
            info.username = tbUname.Text;
            info.password = tbPass.Text;
           // info.repass = recpass.Text;
            

            int rows=opr.insertEmp(info);
            if (rows > 0)
            {
                MessageBox.Show("Data Saved Successfully");
            }
            
        }
    }
}
