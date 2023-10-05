using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flappy_Bird
{
    public partial class Form1 : Form
    {
        public int brzina = 5;
        public int brzinaPipa = 5;
        public int brojac = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
                brzina = -5;
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
                brzina = 5;
            else if (e.KeyCode == Keys.Enter)
                timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pictureBox1.Top += brzina;
            if (pictureBox1.Bounds.IntersectsWith(pictureBox2.Bounds) ||
                pictureBox1.Bounds.IntersectsWith(pictureBox3.Bounds) ||
                pictureBox1.Bounds.IntersectsWith(pictureBox4.Bounds))
            {
                timer1.Stop();
                MessageBox.Show($"Game oveeeer!\nResult: {brojac}");
            }
            pictureBox3.Left -= brzinaPipa;
            pictureBox4.Left -= brzinaPipa;
            if(pictureBox3.Location.X < 50 && pictureBox4.Location.X < 50)
            {
                Random random = new Random();
                int zapamtiRandomBroj=random.Next(50,150);
                pictureBox3.Location = new Point(816, zapamtiRandomBroj + 72);
                pictureBox4.Height = zapamtiRandomBroj;
                pictureBox4.Location = new Point(816, -3);
                brojac++;
                label1.Text = brojac.ToString();
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.BackColor = Color.FromArgb(224, 217, 147);
        }
    }
}
