using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APO_Projekt
{
    public partial class WzorHistogramuTEMP : Form
    {
        private int[] red = null;
        private int[] green = null;
        private int[] blue = null;

        public WzorHistogramuTEMP()
        {
            InitializeComponent();
        }

        private void wczytaj_Click(object sender, EventArgs e)
        {
            
        }

        private int[] calculateLUT(int[] values)
        {
            //poszukaj wartości minimalnej
            int minValue = 0;
            for (int i = 0; i < 256; i++)
            {
                if (values[i] != 0)
                {
                    minValue = i;
                    break;
                }
            }

            //poszukaj wartości maksymalnej
            int maxValue = 255;
            for (int i = 255; i >= 0; i--)
            {
                if (values[i] != 0)
                {
                    maxValue = i;
                    break;
                }
            }

            //przygotuj tablice zgodnie ze wzorem
            int[] result = new int[256];
            double a = 255.0 / (maxValue - minValue);
            for (int i = 0; i < 256; i++)
            {
                result[i] = (int)(a * (i - minValue));
            }

            return result;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Otwórz obraz";
            dlg.Filter = "Obrazy (*.jpg;*.gif;*.png;*.bmp)|*.jpg;*.gif;*.png;*.bmp";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                //Wczytaj plik

                picture.Image = new Bitmap(dlg.OpenFile());
                picture.Height = picture.Image.Height;
                picture.Width = picture.Image.Width;
                this.ClientSize = new System.Drawing.Size(Math.Max(picture.Width + 30, 345), picture.Height + 155);

                //Oblicz histogram
                red = new int[256];
                green = new int[256];
                blue = new int[256];
                for (int x = 0; x < picture.Width; x++)
                {
                    for (int y = 0; y < picture.Height; y++)
                    {
                        Color pixel = ((Bitmap)picture.Image).GetPixel(x, y);
                        red[pixel.R]++;
                        green[pixel.G]++;
                        blue[pixel.B]++;
                    }
                }

                //Wyswietl histogram na wykresie
                chart.Series["red"].Points.Clear();
                chart.Series["green"].Points.Clear();
                chart.Series["blue"].Points.Clear();
                for (int i = 0; i < 256; i++)
                {
                    chart.Series["red"].Points.AddXY(i, red[i]);
                    chart.Series["green"].Points.AddXY(i, green[i]);
                    chart.Series["blue"].Points.AddXY(i, blue[i]);
                }
                chart.Invalidate();
            }
            dlg.Dispose();
        }
    }
}
