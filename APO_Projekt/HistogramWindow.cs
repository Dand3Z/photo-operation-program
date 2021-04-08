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
        private PictureWindow pictureWindow;

        private int[] red = null, green = null, blue = null;
        private int[] yellow = null, pink = null, turquoise = null;
        private int[] allColors = null;
       
        
        public HistogramWindow(PictureWindow pictureWindow)
        {
            InitializeComponent();
            this.pictureWindow = pictureWindow;
            // get LutTable for each colors
            red = pictureWindow.getRed();
            green = pictureWindow.getGreen();
            blue = pictureWindow.getBlue();
            yellow = pictureWindow.getYellow();
            pink = pictureWindow.getPink();
            turquoise = pictureWindow.getTurquoise();
            allColors = pictureWindow.getAllColors();
            setChartValues();
        }

        public void setChartValues()
        {
            if (pictureWindow.getIsGrey()) showGreyHistogram();
            else showColorHistogram();
        }
        
        // set chart values
        private void showColorHistogram()
        {
            //fillColorTables();

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


        private void showGreyHistogram()
        {
            //fillGreyTables();
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
