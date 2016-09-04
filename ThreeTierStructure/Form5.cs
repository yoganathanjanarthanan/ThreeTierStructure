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
using System.IO;
using System.Reflection;
using System.Data.SqlClient;
using System.Drawing.Imaging;

namespace ThreeTierStructure
{
    public partial class Form5 : Form
    {
        public Informations trcinfo= new Informations();
        public Operations trcopr = new Operations();
        SqlDataReader dr;
        private string p;
        string uni0;
            int uni, uni1;
        string imgloc = "";
        bool flag = true;
        int count0 = 0, count = 1;
        SqlConnection con;
        SqlCommand cmd;
        Bitmap image_pix;

        PictureBox picture = new PictureBox
        {
            Name = "pictureBox",
            Size = new Size(100, 50),
            Location = new Point(14, 17),
            ImageLocation = @"c:\Images\test.jpg",
            SizeMode = PictureBoxSizeMode.CenterImage
        };
        
        public Form5()
        {
            InitializeComponent(); 
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            
            con = new SqlConnection(@"Data Source=assaain\SQLEXPRESS;Initial Catalog=testintest;Integrated Security=True");

            this.Opacity = 0;
            Rectangle bounds = Screen.GetBounds(Point.Empty);

            // create the bitmap to copy the screen shot to
            //Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height);
            Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height);

            // now copy the screen image to the graphics device from the bitmap
            using (Graphics gr = Graphics.FromImage(bitmap))
            {//(,,left,down)
                gr.CopyFromScreen(0, 80, 0, 300, bitmap.Size);
                // gr.CopyFromScreen(Point.Empty, Point.Empty, bounds.Size);

                Pen p = new Pen(Color.Red);
                p.Width = 4.0f;
                gr.DrawRectangle(p, 10, 300, 1310, 370);

            }
            this.Opacity = 100;
            pictureBox1.Image = bitmap;


            label1.Text = Form4.set1;
            label2.Text = Form4.set2;
            label3.Text = Form4.set3;
            label4.Text = Form4.set4;
            label5.Text = Form4.set5;
            label6.Text = Form4.set6;
            label7.Text = Form4.set7;
            label8.Text = Form4.set8;
            label9.Text = Form4.set9;
            label10.Text = Form4.set10;
            label11.Text = Form4.set11;
            label12.Text = Form4.set12;

            Rectangle crop = new Rectangle(10, 300, 1310, 370);
            Bitmap destBitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics g = Graphics.FromImage(destBitmap);
            g.DrawImage(pictureBox1.Image, new Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height), crop, GraphicsUnit.Pixel);
            g.Dispose();
            pictureBox1.Image = destBitmap;
            pictureBox1.Image.Save(@"C:\Users\JANA ASSASSIN\Desktop\New folder (5)\img.jpg", ImageFormat.Jpeg);
           
            pictureBox2.Image = Image.FromFile(@"C:\Users\JANA ASSASSIN\Desktop\New folder (5)\img.jpg");
            

            con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT TOP 1 id FROM image_code ORDER BY id DESC;";
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    uni0 = dr.GetValue(0).ToString();
                   
                }
            
                uni = Convert.ToInt32(uni0);
                uni1 = uni + 1;
                uni0 =Convert.ToString (uni1);
                textBox1.Text = uni0;

        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            byte[] img = null;
            FileStream fs = new FileStream(@"C:\Users\JANA ASSASSIN\Desktop\New folder (5)\img.jpg", FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            img = br.ReadBytes((int)fs.Length);
            string sql = "INSERT INTO image_code(id,image)VALUES('" + uni0 + "',@img)";
            con.Close();
            con.Open();
            if (con.State != ConnectionState.Open)
                con.Open();
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add(new SqlParameter("@img", img));
            int x = cmd.ExecuteNonQuery();
            con.Close();
            //MessageBox.Show("success");
                
                trcinfo.track1 = label1.Text;
                trcinfo.track2 = label2.Text;
                trcinfo.track3 = label3.Text;
                trcinfo.track4 = label4.Text;
                trcinfo.track5 = label5.Text;
                trcinfo.track6 = label6.Text;
                trcinfo.track7 = label7.Text;
                trcinfo.track8 = label8.Text;
                trcinfo.track9 = label9.Text;
                trcinfo.track10 = label10.Text;
                trcinfo.track11 = label11.Text;
                trcinfo.track12 = label12.Text;
                trcinfo.track13 = uni0;

                int rows = trcopr.insertwave(trcinfo);
                if (rows > 0)
                {
                    MessageBox.Show("Data Saved Successfully");
                }

           


        }

        private void button3_Click(object sender, EventArgs e)
        {

            byte[] img = null;
            FileStream fs = new FileStream(@"C:\Users\JANA ASSASSIN\Desktop\New folder (5)\img.jpg", FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            img = br.ReadBytes((int)fs.Length);
            string sql = "INSERT INTO image_code(id,image)VALUES('" + textBox1.Text + "',@img)";
            con.Open();
            if (con.State != ConnectionState.Open)
                con.Open();
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add(new SqlParameter("@img", img));
            int x = cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("success");
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Form6 fm = new Form6(this.pictureBox1.Image);
            fm.Show();
        }

       

        
       
        
    }
}
