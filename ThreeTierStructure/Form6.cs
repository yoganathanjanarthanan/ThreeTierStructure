using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.IO;
using System.Data.SqlClient;

namespace ThreeTierStructure
{
    public partial class Form6 : Form
    {
       Image image;
       static string fname1, fname2;
       Bitmap img1, img2;
       int count1 = 0, count2 = 0;
       bool flag = true;


       SqlConnection con;
       SqlCommand commend, cmd;
       SqlDataReader dr;
       SqlDataAdapter da;
      string x,imgloc="";
      int a, z;

      string y;

        public Form6(Image codeimage)
        {
            InitializeComponent();
            image = codeimage;
        }

        

        private void Form6_Load(object sender, EventArgs e)
        {
            pictureBox2.Image = image;
            con = new SqlConnection(@"Data Source=assaain\SQLEXPRESS;Initial Catalog=testintest;Integrated Security=True");

            button1.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (; ; )
            {

                try
                {
                    
                    a = 1;
                    z = a + 1;
                    y = Convert.ToString(z);
                    string sql = "select image from image_code where id ='"+ y +"'";
                    if (con.State != ConnectionState.Open)
                        con.Open();
                    commend = new SqlCommand(sql, con);
                    SqlDataReader reader = commend.ExecuteReader();
                    reader.Read();
                    if (reader.HasRows)
                    {
                        byte[] imgloc = (byte[])(reader[0]);
                        if (imgloc == null)
                            pictureBox1.Image = null;
                        else
                        {
                            MemoryStream ms = new MemoryStream(imgloc);
                            pictureBox1.Image = Image.FromStream(ms);

                            con.Close();

                        }
                    }

                }
                catch (Exception ee)
                {
                    MessageBox.Show("" + ee);
                }

                MemoryStream ms1 = new MemoryStream();
                pictureBox1.Image.Save(ms1, ImageFormat.Png);
                byte[] pic_arr = new byte[ms1.Length];
                ms1.Position = 100;
                ms1.Read(pic_arr, 0, pic_arr.Length);

                MemoryStream ms2 = new MemoryStream();
                pictureBox2.Image.Save(ms2, ImageFormat.Png);
                byte[] pic_arr1 = new byte[ms2.Length];
                ms2.Position = 100;
                ms2.Read(pic_arr, 0, pic_arr.Length);

                progressBar1.Visible = true;

                string img1_ref, img2_ref;
                img1 = new Bitmap(pictureBox1.Image);
                img2 = new Bitmap(pictureBox2.Image);

                progressBar1.Maximum = img1.Width;
                if (img1.Width == img2.Width && img1.Height == img2.Height)
                {
                    for (int i = 0; i < img1.Width; i++)
                    {
                        for (int j = 0; j < img1.Height; j++)
                        {
                            img1_ref = img1.GetPixel(i, j).ToString();
                            img2_ref = img2.GetPixel(i, j).ToString();

                            if (img1_ref != img2_ref)
                            {
                                count2++;
                                flag = false;
                                break;
                            }
                            count1++;
                        }
                        progressBar1.Value++;
                    }

                    if (flag == false)
                    {
                        MessageBox.Show("Sorry, Images are not same , " + count2 + " wrong pixels found");
                        
                        a++;
                    }

                    else
                        MessageBox.Show(" Images are same , " + count1 + " same pixels found  and " + count2 + " wrong pixels found");
                    
                    break;
                }
                else
                    MessageBox.Show("can not compare this images");
                a++;
                //break;
            }
         
        }

        private void button2_Click(object sender, EventArgs e)
        {
           try
           {
               string sql = "select image from image_code where id ='"+textBox1.Text+"'";
               if (con.State != ConnectionState.Open)
                   con.Open();
               commend = new SqlCommand(sql, con);
               SqlDataReader reader = commend.ExecuteReader();
               reader.Read();
               if (reader.HasRows)
               {
                   byte[] imgloc = (byte[])(reader[0]);
                   if (imgloc == null)
                       pictureBox1.Image = null;
                   else
                   {
                       MemoryStream ms = new MemoryStream(imgloc);
                       pictureBox1.Image = Image.FromStream(ms);

                       con.Close();

                   }
               }

           }

           
            catch (SqlException ee)
            {
                MessageBox.Show(ee.Message);
                con.Close();
            }
            catch (InvalidOperationException ee)
            {
                con.Close();
            }
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
             MemoryStream ms1 = new MemoryStream();
                pictureBox1.Image.Save(ms1, ImageFormat.Png);
                byte[] pic_arr = new byte[ms1.Length];
                ms1.Position = 100;
                ms1.Read(pic_arr, 0, pic_arr.Length);

                MemoryStream ms2 = new MemoryStream();
                pictureBox3.Image.Save(ms2, ImageFormat.Png);
                byte[] pic_arr1 = new byte[ms2.Length];
                ms2.Position = 100;
                ms2.Read(pic_arr, 0, pic_arr.Length);

                progressBar1.Visible = true;

                string img1_ref, img2_ref;
                img1 = new Bitmap(pictureBox1.Image);
                img2 = new Bitmap(pictureBox3.Image);

                progressBar1.Maximum = img1.Width;
                if (img1.Width == img2.Width && img1.Height == img2.Height)
                {
                    for (int i = 0; i < img1.Width; i++)
                    {
                        for (int j = 0; j < img1.Height; j++)
                        {
                            img1_ref = img1.GetPixel(i, j).ToString();
                            img2_ref = img2.GetPixel(i, j).ToString();

                            if (img1_ref != img2_ref)
                            {
                                count2++;
                                flag = false;
                                break;
                            }
                            count1++;
                        }
                        progressBar1.Value++;
                    }

                    if (flag == false)
                        MessageBox.Show("Sorry, Images are not same , " + count2 + " wrong pixels found");
                    else
                        MessageBox.Show(" Images are same , " + count1 + " same pixels found  and " + count2 + " wrong pixels found");
                    //break;
                }
                else
                    MessageBox.Show("can not compare this images");

               // break;

            con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "select * from m_instument where track13 ='" + textBox1.Text + "'";
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    label3.Text = dr.GetValue(1).ToString();
                    label4.Text = dr.GetValue(2).ToString();
                    label5.Text = dr.GetValue(3).ToString();
                    label6.Text = dr.GetValue(4).ToString();
                    label7.Text = dr.GetValue(5).ToString();
                    label8.Text = dr.GetValue(6).ToString();
                    label9.Text = dr.GetValue(7).ToString();
                    label10.Text = dr.GetValue(8).ToString();
                    label11.Text = dr.GetValue(9).ToString();
                    label12.Text = dr.GetValue(10).ToString();
                    label13.Text = dr.GetValue(11).ToString();
                    label14.Text = dr.GetValue(12).ToString();
                }
                    
            }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "JPG files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif|All Files (*.*)|*.*";
            dlg.Title = "Select Music Image";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                imgloc = dlg.FileName.ToString();
                pictureBox3.ImageLocation = imgloc;
            }
        }
         
        }

        




    }

