using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APO_Projekt
{
    /**
     * Klasa zawierająca różnego rodzaju metody do wykonywania na obrazach
     */
    public class Operations
    {

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
            // znajdź pierwsze min i ostatnie max dla których wartości są niezerowe
            byte localMin = findMin(greyLut);
            byte localMax = findMax(greyLut);

            // definicja nowego minimum i maksimum
            byte newMin = 0, newMax = 255;

            // zabezpieczenie
            if (localMax < localMin) return;

            for (Int32 h = 0; h < bitmap.Height; ++h)
                for (Int32 w = 0; w < bitmap.Width; ++w)
                {
                    Color color = bitmap.GetPixel(w, h);
                    byte newValue = calcNewLinearIntensity(color.R,localMin, localMax, newMax);
                    bitmap.SetPixel(w, h, Color.FromArgb(color.A, newValue, newValue, newValue));
                }
        }
        // operacja pomocnicza do wyliczania liniowego rozciągania histogramu
        private static byte calcNewLinearIntensity(byte current, byte localMin, byte localMax, byte newMax)
        {
            return (byte) ( ((current - localMin) * newMax) / (localMax - localMin) );
        }
        
        //*******************EQUALIZACJA******************************************
        // do poprawy!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

        // wyrównanie histogramu przez equalizację
        public static void greyEqualization(Bitmap bitmap, int[] greyLut)
        {
            // wylicz histogram skumulowany
            int[] cumLut = cumsum(greyLut);

            // indeksy
            byte localMin = findMin(cumLut);
            byte localMax = findMax(cumLut);

            // zabezpieczenie
            if (localMax < localMin) return;

            int[] newCumLut = new int[256 - localMin];
            Array.Copy(cumLut, localMin, newCumLut, 0, 256 - localMin);

            for (int i = 0; i < newCumLut.Length; ++i)
            {
                Console.WriteLine(i + " " + newCumLut[i]);
            }

            for (int i = 0; i < 256; ++i)
            {
                Console.WriteLine(i + " " + cumLut[i]);
            }

            // ponownie przelicz indeksy
            localMin = findMin(newCumLut);
            localMax = findMax(newCumLut);

            // normalizujemy wartości w histogramie
            // CHYBA DZIAŁA
            for (int i = 0; i < cumLut.Length; ++i)
            {
                int newValue = ((cumLut[i] - cumLut[localMin]) * 255) / (cumLut[localMax] - cumLut[localMin]);
                cumLut[i] = newValue >= 0 ? newValue : 0;
            }

         

            /*
            for (Int32 h = 0; h < bitmap.Height; ++h)
                for (Int32 w = 0; w < bitmap.Width; ++w)
                {
                    Color color = bitmap.GetPixel(w, h);
                    byte newValue = calcNewEqualizationIntensity(color.R, localMin, localMax);
                    bitmap.SetPixel(w, h, Color.FromArgb(color.A, newValue, newValue, newValue));
                }
            */

            for (Int32 h = 0; h < bitmap.Height; ++h)
                for (Int32 w = 0; w < bitmap.Width; ++w)
                {
                    Color color = bitmap.GetPixel(w, h);
                    byte intensity = color.R;
                    byte result = (byte) cumLut[intensity];
                    bitmap.SetPixel(w, h, Color.FromArgb(color.A, result, result, result));
                }
        }

        // operacja pomocnicza do wyliczania wyrównania histogramu przez equalizację
        private static byte calcNewEqualizationIntensity(byte current, byte localMin, byte localMax)
        {
            return (byte)(((current - localMin) * 255) / (localMax - localMin));
        }

        // formuła do wyliczenia skumulowanego histogramu
        // zwraca tablicę na podstawie, której taki histogram można stworzyć
        private static int[] cumsum(int[] greyLut)
        {
            int[] cumLut = new int[256];
            cumLut[0] = greyLut[0];
            for (int i = 1; i < 256; ++i)
            {
                cumLut[i] = cumLut[i - 1] + greyLut[i];
            }

            return cumLut;

        }

        // znajdź pierwszą niezerową wartość
        private static byte findMin(int[] lutTable)
        {
            byte localMin = 0;
            while (lutTable[localMin] == 0) ++localMin;
            return localMin;
        }

        // znajdź ostatnią niezerową wartość
        private static byte findMax(int[] lutTable)
        {
            byte localMax = 0;
            while (lutTable[localMax] == 0) --localMax;
            return localMax;
        }

        //*******************PROGOWANIE******************************************
        public static void thresholding(Bitmap bitmap, byte threshold)
        {
            // można by dodać suwak w przyszłości do wyboru wartości
            for (Int32 h = 0; h < bitmap.Height; ++h)
                for (Int32 w = 0; w < bitmap.Width; ++w)
                {
                    Color color = bitmap.GetPixel(w, h);
                    byte intensity = color.R;
                    byte newValue = (intensity > threshold) ? (byte) 255 : (byte) 0;
                    bitmap.SetPixel(w, h, Color.FromArgb(color.A, newValue, newValue, newValue));
                }
        }
    }
}
