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
    public partial class PosterizeForm : Form
    {
        private byte value = 8;
        private PictureWindow pw;
        public PosterizeForm(PictureWindow pw)
        {
            InitializeComponent();
            this.pw = pw;
        }

        private void txtBins_TextChanged(object sender, EventArgs e)
        {
            btnDo.Enabled = Byte.TryParse(txtBins.Text, out value);
        }

        private void btnDo_Click(object sender, EventArgs e)
        {
            Operations.posterize(pw.Bitmap, value);
            pw.resetLutTables();
            pw.resetBitmap();
            Close();
        }
    }
}
