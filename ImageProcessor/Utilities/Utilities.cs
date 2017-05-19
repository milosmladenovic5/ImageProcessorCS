using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageProcessor.Utilities
{
    public class PixelRGB : IComparable<PixelRGB>
    {
        public int xPos;
        public int yPos;

        public byte R;
        public byte G;
        public byte B;

        public int Val
        {
            get
            {
                return (int)(R + G + B);
            }
        }

        public PixelRGB(int x, int y, byte r, byte g, byte b)
        {
            this.xPos = x;
            this.yPos = y;
            this.R = r;
            this.G = g;
            this.B = b;
        }

        public int CompareTo(PixelRGB other)
        {
            if (this.Val > other.Val)
                return -1;
            if (this.Val == other.Val)
                return 0;
            return 1;
        }
    }


    public static class Utilities
    {
        public static double GetParameters(string formText, string labelText)
        {
            double val = 0;

            Parameters.label = labelText;

            using (var form = new Parameters())
            {
                form.Text = formText;
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    val = form.val;
                }
            }

            return val;
        }

        public static unsafe void SetPixel(Bitmap bmp, int x, int y, Color PixelColor)
        {
            BitmapData Data = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            try
            {
                byte* DataPointer = (byte*)Data.Scan0;

                DataPointer = DataPointer + (y * Data.Stride) + (x * 3);

                DataPointer[2] = PixelColor.R;
                DataPointer[1] = PixelColor.G;
                DataPointer[0] = PixelColor.B;
            }
            catch
            {
                throw;
            }
            finally
            {
                bmp.UnlockBits(Data);
            }
        }


        public static double Clamp(double value, double min, double max)
        {
            return (value < min) ? min : (value > max) ? max : value;
        }

    }
}
