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
    public abstract partial class HistogramWindow : Form
    {
        private readonly PictureWindow pictureWindow;
        // private int[] lutTable;
        public HistogramWindow(PictureWindow pictureWindow)
        {
            InitializeComponent();
            this.pictureWindow = pictureWindow;
        }

        public abstract void SetHistogram();
       
    }

    public partial class GreyHistogramWindow : HistogramWindow
    {
        public GreyHistogramWindow(PictureWindow pictureWindow) : base(pictureWindow)
        {

        }

        public override void SetHistogram()
        {

        }
    }

    public partial class ColorHistogramWindow : HistogramWindow
    {
        public ColorHistogramWindow(PictureWindow pictureWindow) : base(pictureWindow)
        {

        }

        public override void SetHistogram()
        {

        }
    }

}
