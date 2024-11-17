using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CarRacingGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=.;Initial Catalog=CarRacingGame;Integrated Security=True");
        void Ekle()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into Points(Point) values (@point)", baglanti);
            komut.Parameters.AddWithValue("@point", label3.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Visible= false;
            button1.Visible = false;
            MaxPuan();
        }

        void Altınlar(int Hız)
        {
            if (p1.Top > 500)
            {
                x = r.Next(0, 200);
                p1.Location = new Point(x, 0);
            }
            else
            {
                p1.Top += Hız;
            }

            if (p2.Top > 500)
            {
                x = r.Next(100, 300);
                p2.Location = new Point(x, 0);
            }
            else
            {
                p2.Top += Hız;
            }


            if (p3.Top > 500)
            {
                x = r.Next(0, 350);
                p3.Location = new Point(x, 0);
            }
            else
            {
                p3.Top += Hız;
            }

            if (p4.Top > 500)
            {
                x = r.Next(150, 350);
                p4.Location = new Point(x, 0);
            }
            else
            {
                p4.Top += Hız;
            }
        }

        int ToplamAltın = 0;
        void ToplamAltınlar()
        {
            if (pFerrari.Bounds.IntersectsWith(p1.Bounds))
            {
                ToplamAltın++;
                label3.Text = ToplamAltın.ToString();
                x = r.Next(0, 350);
                p1.Location=new Point(x, 0);
            }
            if (pFerrari.Bounds.IntersectsWith(p2.Bounds))
            {
                ToplamAltın++;
                label3.Text = ToplamAltın.ToString();
                x = r.Next(0, 350);
                p2.Location = new Point(x, 0);
            }
            if (pFerrari.Bounds.IntersectsWith(p3.Bounds))
            {
                ToplamAltın++;
                label3.Text = ToplamAltın.ToString();
                x = r.Next(0, 350);
                p3.Location = new Point(x, 0);
            }
            if (pFerrari.Bounds.IntersectsWith(p4.Bounds))
            {
                ToplamAltın++;
                label3.Text = ToplamAltın.ToString();
                x = r.Next(0, 350);
                p4.Location = new Point(x, 0);
            }
        }
        void OyunBitti()
        {
            if (pFerrari.Bounds.IntersectsWith(pKirmizi.Bounds))
            {
                label1.Visible = true;
                button1.Visible=true;
                timer1.Enabled = false;
                if (Convert.ToInt32(label3.Text) > Convert.ToInt32(label4.Text))
                {
                    Ekle();
                }
            }

            if (pFerrari.Bounds.IntersectsWith(pTuruncu.Bounds))
            {
                label1.Visible = true;
                button1.Visible = true;
                timer1.Enabled = false;
                if (Convert.ToInt32(label3.Text) > Convert.ToInt32(label4.Text))
                {
                    Ekle();
                }
            }

            if (pFerrari.Bounds.IntersectsWith(pYesil.Bounds))
            {
                label1.Visible = true;
                button1.Visible = true;
                timer1.Enabled = false;
                if (Convert.ToInt32(label3.Text) > Convert.ToInt32(label4.Text))
                {
                    Ekle();
                }
            }
        }

        void MaxPuan()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select max(Point) from Points", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                label4.Text = oku[0].ToString();
            }
            baglanti.Close();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            //pictureBox1.Top += 5;
            //pictureBox1.Top = pictureBox1.Top + 5;
            cizgiHareketi(OyunHizi);
            Araclar(OyunHizi);
            OyunBitti();
            Altınlar(OyunHizi);
            ToplamAltınlar();

        }
        Random r = new Random();
        int x;
        void Araclar(int Hız)
        {
            if (pKirmizi.Top>500)
            {
               x=r.Next(0,200);
               pKirmizi.Location= new Point(x,0);
            }
            else
            {
                pKirmizi.Top += Hız;
            }
            if (pTuruncu.Top > 500)
            {
                x = r.Next(0, 350);
                pTuruncu.Location = new Point(x, 0);
            }
            else
            {
                pTuruncu.Top += Hız;
            }

            if (pYesil.Top > 500)
            {
                x = r.Next(200, 300);
                pYesil.Location = new Point(x, 0);
            }
            else
            {
                pYesil.Top += Hız;
            }
        }
        void cizgiHareketi(int Hiz)
        {
            if (pictureBox1.Top>450)
            {
                pictureBox1.Top = 0;
            }
            else
            {
                pictureBox1.Top += Hiz;
            }

            if (pictureBox2.Top > 450)
            {
                pictureBox2.Top = 0;
            }
            else
            {
                pictureBox2.Top += Hiz;
            }

            if (pictureBox3.Top > 450)
            {
                pictureBox3.Top = 0;
            }
            else
            {
                pictureBox3.Top += Hiz;
            }

            if (pictureBox4.Top > 450)
            {
                pictureBox4.Top = 0;
            }
            else
            {
                pictureBox4.Top += Hiz;
            }
        }
        int OyunHizi = 0;
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Right)
            {
                if (pFerrari.Right<380)
                {
                    pFerrari.Left += 8;
                }
            }
            if (e.KeyCode==Keys.Left)
            {
                if (pFerrari.Left>0)
                {
                    pFerrari.Left += -8;
                }
            }

            if (e.KeyCode==Keys.Up)
            {
                if (OyunHizi<21)
                {
                    OyunHizi++;
                }
            }

            if (e.KeyCode==Keys.Down)
            {
                if (OyunHizi>0)
                {
                    OyunHizi--;
                }
            }
        }

        private void pKirmizi_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}
