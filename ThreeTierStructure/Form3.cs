using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BEL;
using BAL;
using System.Net;
using System.Net.Mail;

namespace ThreeTierStructure
{
    public partial class Form3 : Form
    {
        public Operations opr = new Operations();
        public Informations info = new Informations();
    

        public Form3()
        {
            InitializeComponent();
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            comboBox1.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "USER NAME")
            {
                info.username = textBox1.Text;
                DataTable dt = new DataTable();
                dt = opr.viewemployee(info);
                //dataGrid1.DataSource = dt;
                textBox2.Text = dt.Rows[0].ItemArray[1].ToString();
            }
            else
            {
                MessageBox.Show("haha");
            }
            
            
            
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void dataGrid1_Navigate(object sender, NavigateEventArgs ne)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = opr.viewemployee(info);

            SmtpClient smtp_server = new SmtpClient();
            MailMessage e_mail = new MailMessage();
            smtp_server.Credentials = new NetworkCredential("y.j00123456@gmail.com", "0750874556");
            smtp_server.Port = 587;
            smtp_server.EnableSsl = true;
            smtp_server.Host = "smtp.gmail.com";


            e_mail = new MailMessage();
            e_mail.From = new MailAddress("y.j00123456@gmail.com");
            //e_mail.To.Add(dt.Rows[0].ItemArray[1].ToString());
            e_mail.To.Add(textBox2.Text);
            e_mail.Subject = " UR PASsword Password";
            e_mail.Body = dt.Rows[0].ItemArray[1].ToString();
            smtp_server.Send(e_mail);
            MessageBox.Show("success");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }
    }
}
