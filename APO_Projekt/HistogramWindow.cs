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
    public partial class HistogramWindow : Form
    {
        private int[] red = null, green = null, blue = null;
        private int[] yellow = null, pink = null, turquoise = null;
        private int[] allColors = null;
        
        private PictureWindow pictureWindow;
        public HistogramWindow(PictureWindow pictureWindow)
        {
            InitializeComponent();
            this.pictureWindow = pictureWindow;

            if (pictureWindow.getIsGrey()) showGreyHistogram();
            else showColorHistogram();



        }

        private void fillColorTables()
        {
            red = new int[256];
            green = new int[256];
            blue = new int[256];
            yellow = new int[256];
            pink = new int[256];
            turquoise = new int[256];
            allColors = new int[256];

            Bitmap img = pictureWindow.GetBitmap();
            for (Int32 h = 0; h < img.Height; h++)
                for (Int32 w = 0; w < img.Width; w++)
                {
                    Color color = img.GetPixel(w, h);
                    red[color.R]++;
                    green[color.G]++;
                    blue[color.B]++;

                    if (color.R == color.G) yellow[color.R]++;
                    if (color.R == color.B) pink[color.R]++;
                    if (color.G == color.B) turquoise[color.G]++;
                    
                    if ((color.R == color.G) && (color.G == color.B)) allColors[color.G]++;
                }
        } // make new tables and fill it

        private void showColorHistogram()
        {
            fillColorTables();

            // clear charm
            chart.Series["red"].Points.Clear();
            chart.Series["green"].Points.Clear();
            chart.Series["blue"].Points.Clear();
            chart.Series["yellow"].Points.Clear();
            chart.Series["turquoise"].Points.Clear();
            chart.Series["pink"].Points.Clear();
            chart.Series["black"].Points.Clear();
            // print new values
            for(int i = 0; i < 256; ++i)
            {
                chart.Series["red"].Points.AddXY(i, red[i]);
                chart.Series["green"].Points.AddXY(i, green[i]);
                chart.Series["blue"].Points.AddXY(i, blue[i]);
                chart.Series["yellow"].Points.AddXY(i, yellow[i]);
                chart.Series["turquoise"].Points.AddXY(i, turquoise[i]);
                chart.Series["pink"].Points.AddXY(i, pink[i]);
                chart.Series["black"].Points.AddXY(i, allColors[i]);

            }
            chart.Invalidate();
        }

        private void fillGreyTables()
        {
            red = new int[256];
            Bitmap img = pictureWindow.GetBitmap();
            for (Int32 h = 0; h < img.Height; h++)
                for (Int32 w = 0; w < img.Width; w++)
                {
                    Color color = img.GetPixel(w, h);
                    red[color.R]++;
                }
        } // make new tables and fill it
    

        private void showGreyHistogram()
        {
            fillGreyTables();
            //chart.Series["red"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            chart.Series["green"].Enabled = false;
            chart.Series["blue"].Enabled = false;
            chart.Series["yellow"].Enabled = false;
            chart.Series["turquoise"].Enabled = false;
            chart.Series["pink"].Enabled = false;
            chart.Series["black"].Enabled = false;
            chart.Series["red"].Points.Clear();
            for (int i = 0; i < 256; ++i)
            {
                chart.Series["red"].Points.AddXY(i, red[i]);
            }
            chart.Invalidate();
        }


    }
}
