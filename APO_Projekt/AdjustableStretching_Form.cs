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
    public partial class AdjustableStretching_Form : Form
    {
        private PictureWindow pw;

        private byte p1 = 0;
        private byte p2 = 255;
        private byte q3 = 0;
        private byte q4 = 255;

        public AdjustableStretching_Form(PictureWindow pw)
        {
            InitializeComponent();
            this.pw = pw;
        }

        private void tbP1_Scroll(object sender, EventArgs e)
        {
            p1 = (byte)tbP1.Value;
            lblSrcFrom.Text = "Value: " + p1.ToString();
        }

        private void tbP2_Scroll(object sender, EventArgs e)
        {
            p2 = (byte)tbP2.Value;
            lblSrcTo.Text = "Value: " + p2.ToString();
        }

        private void tbQ3_Scroll(object sender, EventArgs e)
        {
            q3 = (byte)tbQ3.Value;
            lblTrgFrom.Text = "Value: " + q3.ToString();
        }

        private void tbQ4_Scroll(object sender, EventArgs e)
        {
            q4 = (byte)tbQ4.Value;
            lblTrgTo.Text = "Value: " + q4.ToString();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            if(p1 <= p2 && q3 <= q4)
            {
                Operations.adjustableStretching(pw.Bitmap, p1, p2, q3, q4);
                pw.resetLutTables();
                pw.resetBitmap();
                Close();
            }
            else
            {
                // invalid params
            }
        }
    }
}
