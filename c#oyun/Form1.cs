using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace c_oyun
{
    public partial class Form1 : Form
    {

        Image[] resimler =
        {
           Properties.Resources.images,
           Properties.Resources._11,
           Properties.Resources.images__1_,
           Properties.Resources.images__2_,
           Properties.Resources._22,
           Properties.Resources.indir__1_,
           Properties.Resources.indir__2_,
           Properties.Resources.indir,
           Properties.Resources.indirr,
           Properties.Resources.indir_22,

        };

        PictureBox ilkkutu;
        int ilkIndex;


        int[] index =
        {
            0,0,1,1,2,2,3,3,4,4,5,5,6,6,7,7,8,8,9,9,
        };


        private void Form1_Load(object sender, EventArgs e)
        {
            resimleriKaristir();
        }

        private void resimleriKaristir()
        {
            Random rnd = new Random();
            for (int i = 0; i < 20; i++)
            {
                int sayi = rnd.Next(20);     //0 dan 20 ye kadar ratgele bir sayı seç.
                int gecici = index[i];
                index[i] = index[sayi];
                index[sayi] = gecici;

            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            PictureBox kutu = (PictureBox)sender;


            int kutuNo = int.Parse(kutu.Name.Substring(10));
            int indexNo = index[kutuNo - 1];  //index no o dan box 1 den başladığı için.
            kutu.Image = resimler[indexNo];
            kutu.Refresh();  //beklemeden siliyor.

            if (ilkkutu == null)
            {
                ilkkutu = kutu;
                ilkIndex = indexNo;
            }
            else
            {
                System.Threading.Thread.Sleep(1000);

                ilkkutu.Image = null;
                kutu.Image = null;


                if (ilkIndex == indexNo)     //ilk kutu diğer kutuyle
                {
                    ilkkutu.Visible = false;
                    kutu.Visible = false;

                }
                ilkkutu = null;
            }
            bitti();






        }





        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        private int remainingTime = 40;

        private void button2_Click(object sender, EventArgs e)
        {
            if (int.TryParse(label2.Text, out remainingTime) && remainingTime >= 0)
            {
                timer1.Start();
            }


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (remainingTime >= 0)
            {
                label2.Text = remainingTime.ToString();
                remainingTime--;
            }
            else
            {

                timer1.Stop();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Stop();

        }

        private void bitti()
        {
            if (remainingTime == 0)
            {

                label4.Text = "Oyun Bitti";
              
            }



        }
    }

}
