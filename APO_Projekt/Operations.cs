using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APO_Projekt
{
    public class Operations
    {
        /**
         * Klasa zawierająca różnego rodzaju metody do wykonywania na obrazach
         */

        /**************************************************************
         * Metody
         ************************************************************/

        // zwraca informację o tym czy wskazany obraz jest czarno-biały
        public static Boolean isGrayScale(Bitmap img)
        {
            Boolean result = true;
            // iteracja po wszystkich pikselach
            for (Int32 h = 0; h < img.Height; h++)
                for (Int32 w = 0; w < img.Width; w++)
                {
                    Color color = img.GetPixel(w, h);
                    // nie mają tych samych wartości i aktualnie rozpatrywana wartość nie jest czernią
                    if ((color.R != color.G || color.G != color.B || color.R != color.B) && color.A != 0)
                    {
                        result = false;
                        return result;
                    }
                }

            return result;
        }

        // neguje wartości wszystkich pikseli wskazanego obrazu
        public static void negation(Bitmap bitmap, bool isGrey)
        {
            // szary obraz
            if (isGrey)
            {
                for (Int32 h = 0; h < bitmap.Height; h++)
                    for (Int32 w = 0; w < bitmap.Width; w++)
                    {
                        Color color = bitmap.GetPixel(w, h);
                        int negRed = 255 - color.R;
                        bitmap.SetPixel(w, h, Color.FromArgb(color.A, negRed, negRed, negRed));
                    }
            }
            // kolorowy obraz
            else
            {
                for (Int32 h = 0; h < bitmap.Height; h++)
                    for (Int32 w = 0; w < bitmap.Width; w++)
                    {
                        Color color = bitmap.GetPixel(w, h);
                        int negRed = 255 - color.R;
                        int negGreen = 255 - color.G;
                        int negBlue = 255 - color.B;
                        bitmap.SetPixel(w, h, Color.FromArgb(color.A, negRed, negGreen, negBlue));
                        
                    }
            }
        }

        // liniowe rozciąganie histogramu obrazy szaroodcieniowego
        public static void greyLinearStretching(Bitmap bitmap, int[] greyLut)
        {
            // definicja lokalnych min i max
            byte localMin = 0, localMax = 255;

            // znajdź pierwsze min i ostatnie max dla których wartości są niezerowe
            while (greyLut[localMin] == 0) ++localMin;
            while (greyLut[localMax] == 0) --localMax;

            // definicja nowego minimum i maksimum
            byte newMin = 0, newMax = 255;

            // zabezpieczenie
            if (localMax < localMin) return;

            //int[] newGreyLut = new int[256];

            for (Int32 h = 0; h < bitmap.Height; ++h)
                for (Int32 w = 0; w < bitmap.Width; ++w)
                {
                    Color color = bitmap.GetPixel(w, h);
                    byte newValue = calculateNewIntensity(color.R,localMin, localMax, newMax);
                    bitmap.SetPixel(w, h, Color.FromArgb(color.A, newValue, newValue, newValue));
                }
        }
        // operacja pomocnicza do wyliczania liniowego rozciągania histogramu
        private static byte calculateNewIntensity(byte current, byte localMin, byte localMax, byte newMax)
        {
            return (byte) ( ((current - localMin) * newMax) / (localMax - localMin) );
        }
        


    }
}
