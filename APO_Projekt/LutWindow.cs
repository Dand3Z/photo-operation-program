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
    public partial class LutWindow : Form
    {
        private readonly int[] red = null, green = null, blue = null;
        private bool isGrey, isClosed = false;

        public LutWindow(PictureWindow pw)
        {
            InitializeComponent();
            red = pw.Red;
            green = pw.Green;
            blue = pw.Blue;
            isGrey = pw.IsGrey;
        }

        public void resetLutTable()
            {
            LutList.Items.Clear();

            for (int i = 0; i < red.Length; ++i)
            {
                ListViewItem item = new ListViewItem(i.ToString());
                item.SubItems.Add(red[i].ToString());
                if (!isGrey)
                {
                    item.SubItems.Add(green[i].ToString());
                    item.SubItems.Add(blue[i].ToString());
                }
                LutList.Items.Add(item);
            }
        }

        public bool IsClosed { get { return this.isClosed; } }

        private void LutWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            isClosed = true;
        }

        private void LutWindow_Load(object sender, EventArgs e)
        {
            if (isGrey)
            {
                LutList.Columns.RemoveAt(2);
                LutList.Columns.RemoveAt(2);
                LutList.Columns[1].Text = "Grey";
            }

            resetLutTable();
        }
        
        public void toGrayscale()
        {
            isGrey = true;
            resetLutTable();
        }
    }      
}
