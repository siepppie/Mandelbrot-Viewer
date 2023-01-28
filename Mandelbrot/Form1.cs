using System;
using System.Drawing;
using System.Windows.Forms;

namespace Mandelbrot
{
    public partial class Form1 : Form
    {
        //Aanmaken public variabelen
        public double midden_x = 0;
        public double midden_y = 0;
        public double schaal = 1;
        public double max_iteraties = 100;

        //Initatie form
        public Form1()
        {
            InitializeComponent();

            //Textboxes op default waarden zetten
            textBox1.Text = "0";
            textBox2.Text = "0";
            textBox3.Text = "1";
            textBox4.Text = "100";

            //Mandelbrot genereren
            Generate();
        }

        public void button1_Click(object sender, EventArgs e)
        {
            //Controle of er iets is ingevuld, zo ja: ken het getal toe aan de juiste variabele
            if (textBox1.Text != "")
            {
                midden_x = Convert.ToDouble(textBox1.Text);
            }

            if (textBox2.Text != "")
            {
                midden_y = Convert.ToDouble(textBox2.Text);
            }

            if (textBox3.Text != "")
            {
                schaal = Convert.ToDouble(textBox3.Text);
            }

            if (textBox4.Text != "")
            {
                max_iteraties = Convert.ToDouble(textBox4.Text);
            }

            //Mandelbrot genereren
            Generate();
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            //Waarden terugbrengen naar default
            midden_x = 0;
            midden_y = 0;
            schaal = 1;
            max_iteraties = 100;

            //Juiste waarden updaten in textboxes
            textBox1.Text = "0";
            textBox2.Text = "0";
            textBox3.Text = "1";
            textBox4.Text = "100";

            //Mandelbrot genereren
            Generate();
        }

        public void Generate()
        {
            //Bitmap aanmaken en voor elke pixel een kleur invullen
            Bitmap map = new Bitmap(pictureBox1.Width, pictureBox1.Width);
            for (int x = 0; x < pictureBox1.Width; x++)
            {
                for (int y = 0; y < pictureBox1.Height; y++)
                {
                    map.SetPixel(x, y, Math(x, y));
                }
            }
            pictureBox1.Image = map;
        }

        public Color Math(double x, double y)
        {
            //x en y coördinaat berekenen
            double coordinate_x = (x - (pictureBox1.Width / 2)) / (pictureBox1.Width / 4) * schaal + midden_x;
            double coordinate_y = (y - (pictureBox1.Height / 2)) / (pictureBox1.Height / 4) * schaal - midden_y;

            //Berekenen van Mandelbrot getal
            double a = coordinate_x;
            double b = coordinate_y;
            int iteraties = 0;

            //Controleren of de afstand tussen de twee punten groter is dan 2, zo niet: itereer opnieuw door de berekening heen.
            for (int n = 0; n < max_iteraties; n++)
            {
                if ((a * a + b * b) > 4)
                {
                    break;
                }

                double placeholder_a = (a * a) - (b * b) + coordinate_x;
                b = (2 * a * b + coordinate_y);
                a = placeholder_a;
                iteraties++;
            }

            //Geselecteerde kleur toewijzen aan de variabele selectedColor
            int selectedColor = listBox1.SelectedIndex;

            //Zwart-wit
            if (selectedColor == 0)
            {
                if (iteraties % 2 == 1)
                {
                    return Color.White;
                }
                else
                {
                    return Color.Black;
                }
            }

            //Rood
            if (selectedColor == 1)
            {
                if (iteraties % 5 == 0)
                {
                    return Color.FromArgb(240, 96, 96);
                }
                else if (iteraties % 5 == 1)
                {
                    return Color.FromArgb(241, 118, 97);
                }
                else if (iteraties % 5 == 2)
                {
                    return Color.FromArgb(242, 139, 97);
                }
                else if (iteraties % 5 == 3)
                {
                    return Color.FromArgb(243, 160, 98);
                }
                else if (iteraties % 5 == 4)
                {
                    return Color.FromArgb(243, 181, 98);
                }
            }

            //Blauw
            if (selectedColor == 2)
            {
                if (iteraties % 5 == 0)
                {
                    return Color.FromArgb(89, 79, 79);
                }
                else if (iteraties % 5 == 1)
                {
                    return Color.FromArgb(84, 121, 128);
                }
                else if (iteraties % 5 == 2)
                {
                    return Color.FromArgb(69, 173, 168);
                }
                else if (iteraties % 5 == 3)
                {
                    return Color.FromArgb(157, 224, 173);
                }
                else if (iteraties % 5 == 4)
                {
                    return Color.FromArgb(229, 252, 194);
                }
            }

            //Retro
            if (selectedColor == 3)
            {
                if (iteraties % 5 == 0)
                {
                    return Color.FromArgb(92, 75, 81);
                }
                else if (iteraties % 5 == 1)
                {
                    return Color.FromArgb(140, 190, 178);
                }
                else if (iteraties % 5 == 2)
                {
                    return Color.FromArgb(242, 235, 191);
                }
                else if (iteraties % 5 == 3)
                {
                    return Color.FromArgb(243, 181, 98);
                }
                else if (iteraties % 5 == 4)
                {
                    return Color.FromArgb(240, 96, 96);
                }
            }

            //Oranje/Blauw
            if (selectedColor == 4)
            {
                if (iteraties % 16 == 0)
                {
                    return Color.FromArgb(25, 8, 26);
                }

                if (iteraties % 16 == 1)
                {
                    return Color.FromArgb(9, 1, 48);
                }

                if (iteraties % 16 == 2)
                {
                    return Color.FromArgb(4, 5, 72);
                }

                if (iteraties % 16 == 3)
                {
                    return Color.FromArgb(1, 7, 101);
                }

                if (iteraties % 16 == 4)
                {
                    return Color.FromArgb(11, 44, 137);
                }

                if (iteraties % 16 == 5)
                {
                    return Color.FromArgb(23, 82, 176);
                }

                if (iteraties % 16 == 6)
                {
                    return Color.FromArgb(56, 125, 208);
                }

                if (iteraties % 16 == 7)
                {
                    return Color.FromArgb(134, 180, 229);
                }

                if (iteraties % 16 == 8)
                {
                    return Color.FromArgb(214, 235, 248);
                }

                if (iteraties % 16 == 9)
                {
                    return Color.FromArgb(241, 234, 192);
                }

                if (iteraties % 16 == 10)
                {
                    return Color.FromArgb(247, 201, 97);
                }

                if (iteraties % 16 == 11)
                {
                    return Color.FromArgb(255, 170, 1);
                }

                if (iteraties % 16 == 12)
                {
                    return Color.FromArgb(204, 128, 0);
                }

                if (iteraties % 16 == 13)
                {
                    return Color.FromArgb(153, 87, 0);
                }

                if (iteraties % 16 == 14)
                {
                    return Color.FromArgb(106, 52, 4);
                }

                if (iteraties % 16 == 15)
                {
                    return Color.FromArgb(66, 30, 14);
                }
            }

            //Grayscale
            if (selectedColor == 5)
            {
                int rgbValue = Convert.ToInt32(iteraties / max_iteraties * 255);
                return Color.FromArgb(rgbValue, rgbValue, rgbValue);
            }

            //Geen waarde selecteerd
            else
            {
                if (iteraties % 2 == 1)
                {
                    return Color.White;
                }
                else
                {
                    return Color.Black;
                }
            }
        }

        //Interactie klikken op het figuur
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //Controle of tekstvelden ingevuld zijn, zo ja: pas waarden schaal en iteraties aan
            if (textBox3.Text != "")
            {
                schaal = Convert.ToDouble(textBox3.Text);
            }

            if (textBox4.Text != "")
            {
                max_iteraties = Convert.ToDouble(textBox4.Text);
            }

            //Controleren locatie muis en juiste waarden voor midden_x en midden_y berekenen
            MouseEventArgs me = (MouseEventArgs)e;
            Point coordinates = me.Location;
            midden_x = Convert.ToDouble(textBox1.Text) + ((coordinates.X - 200) / (double)100) * schaal;
            midden_y = Convert.ToDouble(textBox2.Text) + (((coordinates.Y - 200) / (double)100) * -1) * schaal;

            //Schaal twee keer zo klein maken
            schaal = schaal * 0.5;

            //Texboxes bijwerken met nieuwe waarden
            textBox1.Text = midden_x.ToString();
            textBox2.Text = midden_y.ToString();
            textBox3.Text = schaal.ToString();

            //Figuur genereren
            Generate();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            midden_x = -0.7453;
            midden_y = 0.1127;
            schaal = 0.00065;

            textBox1.Text = midden_x.ToString();
            textBox2.Text = midden_y.ToString();
            textBox3.Text = schaal.ToString();
            Generate();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            midden_x = -0.74529;
            midden_y = 0.113075;
            schaal = 0.00015;

            textBox1.Text = midden_x.ToString();
            textBox2.Text = midden_y.ToString();
            textBox3.Text = schaal.ToString();
            Generate();

        }
    }
}
