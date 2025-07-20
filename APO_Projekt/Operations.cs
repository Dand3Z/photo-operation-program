using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Emgu;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using Emgu.CV.UI;
using Emgu.CV.CvEnum;

namespace APO_Projekt
{
    public class Operations
    {
        
        public static Boolean isGrayScale(Bitmap img)
        {
            Boolean result = true;
            for (Int32 h = 0; h < img.Height; h++)
                for (Int32 w = 0; w < img.Width; w++)
                {
                    Color color = img.GetPixel(w, h);
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

        public static void greyLinearStretching(Bitmap bitmap, int[] greyLut)
        {
            byte localMin = findMin(greyLut);
            byte localMax = findMax(greyLut);
            byte newMin = 0, newMax = 255;

            if (localMax < localMin || localMax - localMin == 0) return;

            for (Int32 h = 0; h < bitmap.Height; ++h)
                for (Int32 w = 0; w < bitmap.Width; ++w)
                {
                    Color color = bitmap.GetPixel(w, h);
                    byte newValue = calcNewLinearIntensity(color.R,localMin, localMax, newMax);
                    bitmap.SetPixel(w, h, Color.FromArgb(color.A, newValue, newValue, newValue));
                }
        }
        private static byte calcNewLinearIntensity(byte current, byte localMin, byte localMax, byte newMax)
        {
            return (byte) ( ((current - localMin) * newMax) / (localMax - localMin) );
        }
        
        public static void greyEqualization(Bitmap bitmap, int[] greyLut)
        {
            int[] cumLut = cumsum(greyLut);
            foreach (int i in cumLut) Console.WriteLine(i);

            byte localMin = findMin(cumLut);
            byte localMax = findMax(cumLut);

            if (localMax < localMin) return;

            localMin = findMin(cumLut);
            localMax = findMax(cumLut);

            var localMinValue = cumLut[localMin];
            var localMaxValue = cumLut[localMax];

            if (localMaxValue - localMinValue == 0) return;

            for (int i = 0; i < cumLut.Length; ++i)
            {
                int newValue = ((cumLut[i] - localMinValue) * 255) / (localMaxValue - localMinValue);
                cumLut[i] = newValue >= 0 ? newValue : 0;
            }

            for (Int32 h = 0; h < bitmap.Height; ++h)
                for (Int32 w = 0; w < bitmap.Width; ++w)
                {
                    Color color = bitmap.GetPixel(w, h);
                    byte intensity = color.R;
                    byte result = (byte) cumLut[intensity];
                    bitmap.SetPixel(w, h, Color.FromArgb(color.A, result, result, result));
                }
        }

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

        private static byte findMin(int[] lutTable)
        {
            byte localMin = 0;
            while (lutTable[localMin] == 0) ++localMin;
            return localMin;
        }

        private static byte findMax(int[] lutTable)
        {
            byte localMax = 0;
            while (lutTable[localMax] == 0) --localMax;
            return localMax;
        }

        public static void thresholding(Bitmap bitmap, byte threshold)
        {
            for (Int32 h = 0; h < bitmap.Height; ++h)
                for (Int32 w = 0; w < bitmap.Width; ++w)
                {
                    Color color = bitmap.GetPixel(w, h);
                    byte intensity = color.R;
                    byte newValue = (intensity > threshold) ? (byte) 255 : (byte) 0;
                    bitmap.SetPixel(w, h, Color.FromArgb(color.A, newValue, newValue, newValue));
                }
        }

        public static void grayLevelsThresholding(Bitmap bitmap, byte threshold)
        {
            for (Int32 h = 0; h < bitmap.Height; ++h)
                for (Int32 w = 0; w < bitmap.Width; ++w)
                {
                    Color color = bitmap.GetPixel(w, h);
                    byte intensity = color.R;
                    byte newValue = (intensity > threshold) ? (byte)intensity : (byte)0;
                    bitmap.SetPixel(w, h, Color.FromArgb(color.A, newValue, newValue, newValue));
                }
        }

        public static void posterize(Bitmap bitmap, byte binsAmount)
        {
            byte binSize = (byte) Math.Round(255.0 / binsAmount);
            byte[] myBins = new byte[binsAmount - 1];

            for(byte i = 0; i < binsAmount-1; ++i)
            {
                myBins[i] = (byte) (binSize *(i+1));
            }

            for (Int32 h = 0; h < bitmap.Height; ++h)
                for (Int32 w = 0; w < bitmap.Width; ++w)
                {
                    Color color = bitmap.GetPixel(w, h);
                    byte intensity = color.R;
                    byte newValue = getNewValueFromBins(myBins, binsAmount, intensity, binSize);
                    bitmap.SetPixel(w, h, Color.FromArgb(color.A, newValue, newValue, newValue));
                }
        }

        private static byte getNewValueFromBins(byte[] myBins, byte binAmount, byte colorValue, byte binSize) 
        {
            for (byte i = 0; i < binAmount-1; ++i)
            {
                if (colorValue <= myBins[i]) return (byte) ((i) * binSize); 
            }
            return 255;
        }

        public static void adjustableStretching(Bitmap bitmap, byte p1, byte p2, byte q3, byte q4)
        {
            if (p2 < p1 && q4 < q3) return;
            byte pSize = (byte) (p2 - p1);
            byte qSize = (byte) (q4 - q3);
            Console.WriteLine(pSize + " " + qSize);

            for(Int32 h = 0; h < bitmap.Height; ++h)
                for(Int32 w = 0; w < bitmap.Width; ++w)
                {
                    Color color = bitmap.GetPixel(w, h);
                    byte redValue = color.R;
                    byte newValue;
                    if (redValue < p1 || redValue > p2) newValue = 0;
                    else newValue = (byte)(q3 + (((redValue - p1) / (double)pSize) * qSize));

                    bitmap.SetPixel(w, h, Color.FromArgb(color.A, newValue, newValue, newValue));
                }
        }

        public static void blur(PictureWindow pw, Size kernel, BorderType borderType)
        {
            Size kernelSize = kernel;
            Bitmap source = pw.Bitmap;
            Image<Rgb, byte> emguImage = source.ToImage<Rgb, byte>();
            CvInvoke.Blur(emguImage, emguImage, kernelSize , new Point(-1, -1), borderType);
            Bitmap result = emguImage.ToBitmap();
            pw.Bitmap = result;
        }

        public static void gaussianBlur(PictureWindow pw, Size size, BorderType borderType, double sX, double sY)
        {
            Size kernelSize = new Size(5, 5);
            double sigmaX = 0;
            double sigmaY = sigmaX;

            Bitmap source = pw.Bitmap;
            Image<Rgb, byte> emguImage = source.ToImage<Rgb, byte>();
            CvInvoke.GaussianBlur(emguImage, emguImage, kernelSize, sigmaX, sigmaY, borderType);
            Bitmap result = emguImage.ToBitmap();
            pw.Bitmap = result;
        }

        public static void laplacian(PictureWindow pw, int kernel, BorderType border)
        {
            var ddepth = DepthType.Cv8U;
            Bitmap source = pw.Bitmap;
            Image<Gray, byte> emguImage = source.ToImage<Gray, byte>();
            CvInvoke.Laplacian(emguImage, emguImage, ddepth, kernel, 1, 0, border);
            Bitmap result = emguImage.Mat.ToImage<Rgb, byte>().ToBitmap();
            pw.Bitmap = result;
        }

        public static void sobel(PictureWindow pw, int kernel, int xorder, int yorder, BorderType border)
        {
            var ddepth = DepthType.Cv8U;
            Bitmap source = pw.Bitmap;
            Image<Gray, byte> emguImage = source.ToImage<Gray, byte>();
            CvInvoke.Sobel(emguImage, emguImage, ddepth, xorder, yorder, kernel, 1, 0, border);
            Bitmap result = emguImage.Mat.ToImage<Rgb, byte>().ToBitmap();
            pw.Bitmap = result;
        }

        public static void canny(PictureWindow pw, double th1, double th2)
        {
            Bitmap source = pw.Bitmap;
            Image<Gray, byte> emguImage = source.ToImage<Gray, byte>();
            CvInvoke.Canny(emguImage, emguImage, th1, th2);
            Bitmap result = emguImage.Mat.ToImage<Rgb, byte>().ToBitmap();
            pw.Bitmap = result;
        }

        public static void linearSharpening(PictureWindow pw, Matrix<double> matrix, BorderType border)
        {
            var maskSharp = matrix;
            var borderKind = border;

            Bitmap source = pw.Bitmap;
            Image<Rgb, byte> emguImage = source.ToImage<Rgb, byte>();
            CvInvoke.Filter2D(emguImage, emguImage, maskSharp, new Point(-1, -1), 0, borderKind);
            Bitmap result = emguImage.ToBitmap();
            pw.Bitmap = result;
        }

        public static void directionalEdgeDetection(PictureWindow pw, Matrix<double> matrix, BorderType border)
        {
            var maskSharp = matrix;
            var borderKind = border;

            Bitmap source = pw.Bitmap;
            Image<Rgb, byte> emguImage = source.ToImage<Rgb, byte>();
            CvInvoke.Filter2D(emguImage, emguImage, maskSharp, new Point(-1, -1), 0, borderKind);
            Bitmap result = emguImage.ToBitmap();
            pw.Bitmap = result;
            
        }

        public static void otsu(PictureWindow pw)
        {
            Image<Gray, byte> emguImage = pw.Bitmap.ToImage<Gray, byte>();
            CvInvoke.Threshold(emguImage, emguImage, 0, 255, ThresholdType.Binary | ThresholdType.Otsu);
            pw.Bitmap = emguImage.Mat.ToImage<Rgb, byte>().ToBitmap();
            pw.resetBitmap();
            pw.resetLutTables();
        }

        public static void watershed(PictureWindow pw)
        {
            Mat imageMat = pw.Bitmap.ToImage<Rgb, byte>().Mat;
            Mat resultMat = imageMat.Clone();
            Mat grayMat = new Mat();

            CvInvoke.CvtColor(imageMat, grayMat, ColorConversion.Rgb2Gray);
            
            Mat threshMat = new Mat();
            CvInvoke.Threshold(grayMat, threshMat, 0, 255, ThresholdType.BinaryInv | ThresholdType.Otsu);
            
            Mat openingMat = new Mat();
            Mat kernel = CvInvoke.GetStructuringElement(ElementShape.Rectangle, new Size(3, 3), new Point(-1, -1));
            CvInvoke.MorphologyEx(threshMat, openingMat, MorphOp.Open, kernel, new Point(-1, -1), 1, BorderType.Reflect, new MCvScalar());
            
            Mat sureBgMat = new Mat();
            CvInvoke.MorphologyEx(openingMat, sureBgMat, MorphOp.Dilate, kernel, new Point(-1, -1), 1, BorderType.Reflect, new MCvScalar());
            
            Mat distTransformMat = new Mat();
            CvInvoke.DistanceTransform(openingMat, distTransformMat, null, DistType.L2, 5);
            
            Mat sureFgMat = new Mat();
            CvInvoke.Threshold(distTransformMat, sureFgMat, 0.5, 255, ThresholdType.Binary); 
            CvInvoke.MorphologyEx(sureFgMat, sureFgMat, MorphOp.Erode, kernel, new Point(-1, -1), 9, BorderType.Default, new MCvScalar());
            
            Mat unknownMat = new Mat();
            sureFgMat.ConvertTo(sureFgMat, unknownMat.Depth);
            CvInvoke.Subtract(sureBgMat, sureFgMat, unknownMat);
            
            Mat markersMat = new Mat();
            CvInvoke.ConnectedComponents(sureFgMat, markersMat);
            
            markersMat += 1;
            Image<Gray, byte> markersImage = markersMat.ToImage<Gray, byte>();
            Image<Gray, byte> unknownImage = unknownMat.ToImage<Gray, byte>();
            for (int i = 0; i < markersImage.Rows; ++i)
            {
                for (int j = 0; j < markersImage.Cols; ++j)
                {
                    if (unknownImage.Data[i, j, 0] == 255) markersImage.Data[i, j, 0] = 0;
                }
            }
            markersMat = markersImage.Mat;

            
            resultMat.ConvertTo(resultMat, DepthType.Cv8U);
            markersMat.ConvertTo(markersMat, DepthType.Cv32S); 
            CvInvoke.Watershed(resultMat, markersMat);

            markersMat.ConvertTo(markersMat, DepthType.Cv8U);
            markersMat *= 10;
            CvInvoke.ApplyColorMap(markersMat, markersMat, Emgu.CV.CvEnum.ColorMapType.Jet);
            
            pw.Bitmap = markersMat.ToBitmap();
            pw.resetBitmap();
            pw.resetLutTables();
        }

        public static void toGrayscale(PictureWindow pw)
        {
            Mat imageMat = pw.Bitmap.ToImage<Gray, byte>().Mat;
            pw.Bitmap = imageMat.ToImage<Rgb, byte>().ToBitmap();
            pw.toGrayscale();
        }
    }
}
