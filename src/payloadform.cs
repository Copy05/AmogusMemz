/*
* (c) Copyright Copy 2021
*
* AmogusMemz.exe Source code
* Note: This Trojan is not destructive
*
*/

using System;
using System.IO;
using System.Net;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace AmogusMemz
{
    public partial class payloadform : Form
    {
        public payloadform()
        {
            InitializeComponent();
        }

        // Messagebox Triggers every 10 seconds
        public void AskMsg(object source, EventArgs e)
        {
            MessageBox.Show("Sussy Amogus", "LMAO XD BRUH", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        // Makes the screen glitching like memz
        public void ScreenGlitching(object source, EventArgs e)
        {
            Random ran = new Random();
            int num = ran.Next(0, 150);
            int num1 = ran.Next(0, 150);
            int num2 = ran.Next(0, 150);
            int num3 = ran.Next(0, 150);
            Bitmap bmp = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Width);
            Graphics gr = Graphics.FromImage(bmp);
            gr.CopyFromScreen(num, num3, num1, num2, bmp.Size);
            gr.CopyFromScreen(num3, num2, num, num1, bmp.Size);
            int width = ran.Next(500, 1500);
            int height = ran.Next(250, 800);

            for(int y = 0; y < height; y++)
            {
                for(int x = 0; x < width; x++)
                {
                    Color p = bmp.GetPixel(x, y);
                    int a = p.A;
                    int r = p.R;
                    int gre = p.G;
                    int b = p.B;

                    r = 255 - r;
                    gre = 255 - gre;
                    b = 255 - b;

                    bmp.SetPixel(x, y, Color.FromArgb(a, r, gre, b));
                }
                pictureBox1.Image = bmp;
            }
        }

        // Opens and triggers the amogus image and messaegebox
        public void AmogusImg(object source, EventArgs e)
        {
            Process.Start("mogus.png");
            MessageBox.Show("Still trying your toasted computer?", "Amogus Sus", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        // The whole payload system
        public void Amogus()
        {
            StreamWriter File = new StreamWriter("getsus.txt");
            File.Write("Your PC is now FUCKED with the AmogusMemz Trojan. still this is a safe version you may be careful of its payloads\n\nDont worry you can restore your pc by restarting your pc or taskkilling the trojan Goodluck suffering in the Sus hell.\n\nOr if you dont want to lose your work think of pressing the escape key.");
            File.Close();
            Process.Start("getsus.txt");
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.TransparencyKey = this.BackColor;
            this.TopMost = true;
            string mogusuri = "https://static.wikia.nocookie.net/the-streets-roblox/images/9/9e/Amogus.jpg/revision/latest/scale-to-width-down/344?cb=20210409100921";
            WebClient mogus = new WebClient();

            try
            {
                string filename = "mogus.png";
                mogus.DownloadFile(mogusuri, filename);
            } catch
            {
                MessageBox.Show("It seems i injected my beauty allready in your toaster.", "Amogus Sad", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            Process.Start("mogus.png");

            Timer t1 = new Timer
            {
                Interval = 20000
            };

            Timer t2 = new Timer
            {
                Interval = 300
            };

            Timer t3 = new Timer
            {
                Interval = 60000
            };

            t1.Enabled = true;
            t1.Tick += new System.EventHandler(AskMsg);
            t2.Enabled = true;
            t2.Tick += new System.EventHandler(ScreenGlitching);
            t3.Enabled = true;
            t3.Tick += new System.EventHandler(AmogusImg);
        }

        // To exit this joke trojan
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        // To warn the user
        private void Form1_Load(object sender, EventArgs e)
        {
            DialogResult r1;
            DialogResult r2;
            r1 = MessageBox.Show("This Is a clean and a not so destructive version of AmogusMemz the creator is not responsble for any harm made on your computer still wish to continue??", "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if(r1 == DialogResult.No)
            {
                this.Close();

            } else if(r1 == DialogResult.Yes)
                {
                r2 = MessageBox.Show("Last warning before getting your toaster sus....", "LAST WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (r1 == DialogResult.No)
                {
                    this.Close();

                }
                else if (r1 == DialogResult.Yes)
                {
                    Amogus();
                }
            }

        }

    }
}
