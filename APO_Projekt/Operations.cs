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
        public static void negation(Bitmap bitmap, bool isGrey)
        {
            if (isGrey)
            {
                //var rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
                //var newBitmap = bitmap.Clone(rect, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

                for (Int32 h = 0; h < bitmap.Height; h++)
                    for (Int32 w = 0; w < bitmap.Width; w++)
                    {
                        Color color = bitmap.GetPixel(w, h);
                        int negRed = 255 - color.R;
                        bitmap.SetPixel(w, h, Color.FromArgb(color.A, negRed, negRed, negRed));
                    }
                
            }
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
    }
    
}
