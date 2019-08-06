using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pexels
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //pexels x = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.ShowDialog();
                pictureBox1.ImageLocation = openFileDialog1.FileName;
                this.Text = openFileDialog1.FileName;
                
               
                
            }
            catch
            { 
            
            }
        }
        int ort;
        int genelOrt;
        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            Bitmap bix = new Bitmap(pictureBox1.Image);
            Color cobi;

            int a = 0,r = 0, g = 0, b = 0;
            int n = bix.Width * bix.Height;
            


                for (int i = 0; i <bix.Width ; i++)
                {
                    for (int j = 0; j <bix.Height ; j++)
                    {
                        cobi = bix.GetPixel(i, j);
                        a = a + cobi.A;
                        r = r + cobi.R;
                        g = r + cobi.G;
                        b = b + cobi.B;
                    }
                }

            listBox1.Items.Add("pixel sayısı: " + bix.Width + "x" + bix.Height);

            ort = a / n;
            genelOrt=genelOrt+ort;

            listBox1.Items.Add("A rengi ort: " + ort);

            ort = r / n;
            genelOrt=genelOrt+ort;

            listBox1.Items.Add("Kırmızı rengi ort: " + ort);

            ort = g / n;
            genelOrt=genelOrt+ort;

            listBox1.Items.Add("Yaşil rengi ort: " + ort);

            ort = b / n;
            genelOrt=genelOrt+ort;

            listBox1.Items.Add("Mavi rengi ort: " + ort);
            
            genelOrt=(genelOrt+ort)/3;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Bitmap bix = new Bitmap(pictureBox1.Image);
            Color cobi;
            for (int i = 0; i < bix.Width; i++)
            {
                for (int j = 0; j < bix.Height; j++)
                {
                    cobi = bix.GetPixel(i, j);
                    int ort = (cobi.R + cobi.G + cobi.B) / 3;
                    bix.SetPixel(i, j, Color.FromArgb(cobi.A, ort, ort, ort));
                }
            }
            pictureBox2.Image = bix;

           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Bitmap bix = new Bitmap(pictureBox1.Image);
            Color cobi;
            for (int i = 0; i < bix.Width/4; i++)
            {
                for (int j = 0; j < bix.Height/4; j++)
                {
                    cobi = bix.GetPixel(i, j);
                    int ort = (cobi.R + cobi.G + cobi.B) / 3;
                    listBox1.Items.Add(i+","+j+": "+ort);
                    
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Bitmap bix = new Bitmap(pictureBox1.Image);
            Color cobi;
            for (int i = 0; i < bix.Width; i++)
            {
                for (int j = 0; j < bix.Height; j++)
                {
                    cobi = bix.GetPixel(i, j);
                    int ort = (cobi.R + cobi.G + cobi.B) / 3;
                    
                    if(ort<genelOrt)
                    {
                        ort=ort/2;
                        bix.SetPixel(i, j, Color.FromArgb(cobi.A, cobi.R+ort, cobi.G+ort, cobi.B+ort));
                    }
                    else if(ort>genelOrt)
                    {
                        ort=ort/2;
                        bix.SetPixel(i, j, Color.FromArgb(cobi.A, cobi.R-ort, cobi.G-ort, cobi.B-ort));
                    }
                }
            }//deneme
            pictureBox2.Image = bix;
        }
    }
}
