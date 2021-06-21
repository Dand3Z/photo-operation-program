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
    public partial class AboutMe_Form : Form
    {
        public AboutMe_Form()
        {
            InitializeComponent();
            CenterToScreen();
            init();
            txtAbout.ReadOnly = true;
        }

        private void init()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Aplikacja zbiorcza z ćwiczeń laboratoryjnych i projektu." + Environment.NewLine);
            sb.Append("Program do konstrukcji obrazów monochromatycznych z obrazów kolorowych według wskazań użytkownika co do konwersji koloru." + Environment.NewLine);

            sb.Append(Environment.NewLine);
            sb.Append("Autor: Daniel Delegacz" + Environment.NewLine);
            sb.Append("Nr indeksu: 17995" + Environment.NewLine);
            sb.Append("WIT grupa: ID06IO1" + Environment.NewLine);
            sb.Append("Prowadzący: mgr inż. Łukasz Roszkowiak" + Environment.NewLine);
            sb.Append("Algorytmy Przetwarzania Obrazów 2021" + Environment.NewLine);
            
            txtAbout.Text = sb.ToString();
        }
    }
}
