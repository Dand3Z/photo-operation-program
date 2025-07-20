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

        private readonly int[] red = null, green = null, blue = null;
        private readonly int[] yellow = null, pink = null, turquoise = null;
        private readonly int[] allColors = null;

        private bool isClosed = false;
        private bool isGrey;

        public HistogramWindow(PictureWindow pictureWindow)
        {
            InitializeComponent();

            red = pictureWindow.Red;
            green = pictureWindow.Green;
            blue = pictureWindow.Blue;
            yellow = pictureWindow.Yellow;
            pink = pictureWindow.Pink;
            turquoise = pictureWindow.Turquoise;
            allColors = pictureWindow.AllColors;
            isGrey = pictureWindow.IsGrey;

            printChart();
        }

        private void HistogramWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            isClosed = true;
        }
        
        public void printChart()
        {
            if (isGrey) showGreyHistogram(); 
            else showColorHistogram();
        }
        
        private void showColorHistogram()
        {
            chart.Series["red"].Points.Clear();
            chart.Series["green"].Points.Clear();
            chart.Series["blue"].Points.Clear();
            chart.Series["red+green"].Points.Clear();
            chart.Series["green+blue"].Points.Clear();
            chart.Series["red+blue"].Points.Clear();
            chart.Series["red+green+blue"].Points.Clear();
            
            for(int i = 0; i < 256; ++i)
            {
                chart.Series["red"].Points.AddXY(i, red[i]);
                chart.Series["green"].Points.AddXY(i, green[i]);
                chart.Series["blue"].Points.AddXY(i, blue[i]);
                chart.Series["red+green"].Points.AddXY(i, yellow[i]);
                chart.Series["green+blue"].Points.AddXY(i, turquoise[i]);
                chart.Series["red+blue"].Points.AddXY(i, pink[i]);
                chart.Series["red+green+blue"].Points.AddXY(i, allColors[i]);

            }
            chart.Invalidate();
        }

        private void showGreyHistogram()
        {
            chart.Series["green"].Enabled = false;
            chart.Series["blue"].Enabled = false;
            chart.Series["red+green"].Enabled = false;
            chart.Series["green+blue"].Enabled = false;
            chart.Series["red+blue"].Enabled = false;
            chart.Series["red+green+blue"].Enabled = false;

            chart.Series["red"].Points.Clear();
            for (int i = 0; i < 256; ++i)
            {
                chart.Series["red"].Points.AddXY(i, red[i]);
            }
            chart.Invalidate();
        }

        public void toGrayscale()
        {
            chart.Series["green"].Enabled = false;
            chart.Series["blue"].Enabled = false;
            chart.Series["red+green"].Enabled = false;
            chart.Series["green+blue"].Enabled = false;
            chart.Series["red+blue"].Enabled = false;
            chart.Series["red+green+blue"].Enabled = false;
            chart.Invalidate();
        }

        public bool IsClosed { get { return this.isClosed; } }
    }
}
