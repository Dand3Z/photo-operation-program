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
        /**************************************************************
         * Pola
         ************************************************************/

        // trzyma 3 referencje do tablic podstawowych kolorów
        private readonly int[] red = null, green = null, blue = null;
        private bool isGrey, isClosed = false;

        /**************************************************************
         * Konstruktory
         ************************************************************/

        public LutWindow(PictureWindow pw)
        {
            InitializeComponent();
            red = pw.Red;
            green = pw.Green;
            blue = pw.Blue;
            isGrey = pw.IsGrey;
        }

        /**************************************************************
         * Metody
         ************************************************************/

        // zresetuj wyświetalne wartości po zmianie na obrazie
        public void resetLutTable()
            {
            // wyczyść aktualną zawartość
            LutList.Items.Clear();

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

        /**************************************************************
         * Właściwości
         ************************************************************/

        public bool IsClosed { get { return this.isClosed; } }


        /**************************************************************
         * Zdarzenia
         ************************************************************/

        private void LutWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            // okno zostało zamknięte
            isClosed = true;
        }

        private void LutWindow_Load(object sender, EventArgs e)
        {
            if (isGrey)
            {
                LutList.Columns.RemoveAt(2); // usuń green
                LutList.Columns.RemoveAt(2); // usuń blue
                LutList.Columns[1].Text = "Grey"; // przemianuj Red na Grey
            }

            resetLutTable();
        }

        
    }      
}
