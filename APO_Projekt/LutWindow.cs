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
        // trzyma 3 referencje do tablic podstawowych kolorów
        private readonly int[] red = null, green = null, blue = null;
        private bool isGrey;
        public LutWindow(PictureWindow pw)
        {
            InitializeComponent();
            red = pw.getRed();
            green = pw.getGreen();
            blue = pw.getBlue();
            isGrey = pw.getIsGrey();
        }

        private void LutWindow_Load(object sender, EventArgs e)
        {
            // wyczyść aktualną zawartość
            LutList.Items.Clear();

            if (isGrey)
            {
                LutList.Columns.RemoveAt(2); // usuń green
                LutList.Columns.RemoveAt(2); // usuń blue
                LutList.Columns[1].Text = "Grey"; // przemianuj Red na Grey
            }

            for (int i = 0; i < red.Length; ++i)
            {
                ListViewItem item = new ListViewItem(i.ToString());
                item.SubItems.Add(red[i].ToString());
                // jeżeli nie jest szaroodcieniowy to licz dla trzech kanałów
                if (!isGrey)
                {
                    item.SubItems.Add(green[i].ToString());
                    item.SubItems.Add(blue[i].ToString());
                }
                // dodaj nowy wiersz wynikowy
                LutList.Items.Add(item);
                
            }
        }

        
    }
}
