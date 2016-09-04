using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;


namespace ThreeTierStructure
{

    public partial class Form4 : Form
    {
         System.Media.SoundPlayer player= new System.Media.SoundPlayer();

        public Form4()
        {
            InitializeComponent();
           
          
        }

        OpenFileDialog open = new OpenFileDialog();
        private void button1_Click(object sender, EventArgs e)
        {
            
            open.Filter = "Wave File (*.wav)|*.wav;";
            if (open.ShowDialog() != DialogResult.OK) return;
            this.label1.Text = open.FileName;
            chart1.Visible = true;
            chart1.Series.Clear();
            chart2.Series.Clear();


            //waveViewer1.Visible = true;     
            chart1.Series.Add("wave");
            chart2.Series.Add("wave");
            chart1.Series["wave"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            chart2.Series["wave"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            chart1.Series["wave"].ChartArea = "ChartArea1";
            chart2.Series["wave"].ChartArea = "ChartArea1";
            NAudio.Wave.WaveChannel32 wave = new NAudio.Wave.WaveChannel32(new NAudio.Wave.WaveFileReader(open.FileName));

            byte[] buffer = new byte[16384];
            int read = 0;

            while (wave.Position < wave.Length)
            {
                read = wave.Read(buffer, 0, 16384);

                for (int i = 0; i < read / 8; i++)
                {

                    chart1.Series["wave"].Points.Add(BitConverter.ToSingle(buffer, i * 8));
                    chart2.Series["wave"].Points.Add(BitConverter.ToSingle(buffer, i * 8));

                }
            }

            chart2.Visible = false;
           // button2.Enabled = true;
        }


        private void Form4_Load(object sender, EventArgs e)
        {
            chart2.Visible = false;
            lab_X.Visible = false;
            lab_Y.Visible = false;
            label_cur.Visible = false;
            chart1.Visible = true;
            button3.Visible = false;
            //button2.Enabled = false;

           
        }

        private void chart2_MouseMove(object sender, MouseEventArgs e)
        {
            lab_X.Location = new Point((e.X), 58);
            lab_Y.Location = new Point(95, e.Y);
            if (e.X <= 120 || e.Y >= 600 || e.Y <= 65|| e.X >= 1120)
            {
                lab_X.Visible = false;
                lab_Y.Visible = false;
                label_cur.Visible = false;
            }
            else
            {
                lab_X.Visible = true;
                lab_Y.Visible = true;
                label_cur.Visible = true;
            }
            try
            {
                double yvalue = chart1.ChartAreas[0].AxisY2.PixelPositionToValue(e.Y);
                double xvalue = chart1.ChartAreas[0].AxisX2.PixelPositionToValue(e.X);

                label_cur.Text = string.Concat(string.Concat(Math.Round(xvalue, 2).ToString(), ","), Math.Round(yvalue, 2).ToString());

                label_cur.Location = new Point(775, e.Y - 5);
            }
            catch
            {

            }
            finally
            {

            }

           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            chart1.Visible = false;
            chart2.Visible = true;
            lab_X.Visible = true;
            lab_Y.Visible = true;
            label_cur.Visible = true;
        }

        private void chart2_MouseClick(object sender, MouseEventArgs e)
        {
            //textBox1.Focus();
            try
            {
                double yvalue = chart1.ChartAreas[0].AxisY2.PixelPositionToValue(e.Y);
                double xvalue = chart1.ChartAreas[0].AxisX2.PixelPositionToValue(e.X);
               
                    
                    if (yvalue >= -0.74 && yvalue <= -0.4)
                    {
                        textBox1.Text = "drum";
                       // textBox1.Enabled = false;
                        textBox2.Focus();
                    }
                    else if (yvalue >= -0.39 && yvalue <=-0.29)
                    {
                        textBox2.Text = "sexaphone";
                        textBox3.Focus();
                    }
                    else if (yvalue >= -0.28 && yvalue <= -0.18)
                    {
                        textBox3.Text = "flute";
                        textBox4.Focus();
                    }

                    else if (yvalue >= -0.17 && yvalue <= -0.07)
                    {
                        textBox4.Text = "violin guitar";
                        textBox5.Focus();
                    }
                    else if (yvalue >= -0.6 && yvalue <= -0.01)
                    {
                        textBox5.Text = "guitar";
                        textBox6.Focus();
                    }
                    else if (yvalue >= 0.0 && yvalue <= 0.0)
                    {
                        MessageBox.Show("No Instument playing in this value Or area");
                        
                    }
                    else if (yvalue >= 0.1 && yvalue <= 0.25)
                    {
                        textBox6.Text = "daduk";
                        textBox7.Focus();
                    }
                    else if (yvalue >= 0.26 && yvalue <= 0.3)
                    {
                        textBox7.Text = "cetera";
                        textBox8.Focus();
                    }
                    else if (yvalue >= 0.31 && yvalue <= 0.39)
                    {
                        textBox8.Text = "Oboe";
                        textBox9.Focus();
                    }
                    else if (yvalue >= 0.40 && yvalue <= 0.49)
                    {
                        textBox9.Text = "Struck";
                        textBox10.Focus();
                    }
                    else if (yvalue >= 0.50 && yvalue <= 0.59)
                    {
                        textBox10.Text = "Tromboned";
                        textBox11.Focus();
                    }
                    else if (yvalue >= 0.6 && yvalue <= 0.7)
                    {
                        textBox11.Text = "Trumpet";
                        textBox12.Focus();
                    }
                    else if (yvalue >= 0.71 && yvalue <= 1)
                    {
                        textBox12.Text = "Indefinite pitch";
                        //textBox10.Focus();
                    }
               
            }
            catch (ArgumentException ee)
            {
                MessageBox.Show("Can't find indtument in minus value -0.50 value ");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }
        public static string set1 = "", set2 = "", set3 = "", set4 = "", set5 = "", set6 = "", set7 = "", 
            set8 = "", set9 = "", set10 = "", set11 = "", set12 = "";
        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("You Sure Do You Done The Trainning?", "Some Title", MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                chart1.Visible = true;
                chart2.Visible = false;
                button4.Visible = false;
                button3.Visible = true;     
                
            }
            else if (dialogResult == DialogResult.No)
            {
               
            }
           
           
          
            
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            set1 = textBox1.Text;
            set2 = textBox2.Text;
            set3 = textBox3.Text;
            set4 = textBox4.Text;
            set5 = textBox5.Text;
            set6 = textBox6.Text;
            set7 = textBox7.Text;
            set8 = textBox8.Text;
            set9 = textBox9.Text;
            set10 = textBox10.Text;
            set11 = textBox11.Text;
            set12 = textBox12.Text;
            
            Form5 form2 = new Form5();
            form2.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
             try
            {
                player.SoundLocation = label1.Text;

                player.Load();

                player.Play();
            }
            
            catch (InvalidOperationException ee)
            {
                MessageBox.Show(ee.Message);
            }
            catch (NullReferenceException ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            player.Stop();
        }

       

        

    }
}
