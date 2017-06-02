using ImageProcessor.Filters;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessor
{
    public class Pixel : IEquatable<Pixel>
    {
        public int x;
        public int y;

        public Pixel(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public Pixel() { }

        public bool Equals(Pixel other)
        {
            return (this.x == other.x && this.y == other.y);
            
        }
    }

    public struct Pixel24b
    {
        public byte r;
        public byte g;
        public byte b;
    }

    public class SeamCarving
    {
        private Bitmap edge;
        private Bitmap m_bitmap;
        private int[,] energyMap;
        //private Pixel[] path;
        private List<Pixel> path;

        private Pixel24b[ , ] bitmapMatrix;

        #region Helper Functions  
        public int GetElementX(int[,] mat, int x, int y, bool infinite_limit)
        {
            if (infinite_limit == true)
            {
                if ((x < 0) || (x >= mat.GetLength(1)))
                {
                    return Int32.MaxValue;
                }
            }
            else
            {
                if ((x < 0) || (x >= mat.GetLength(1)))
                {
                    return 0;
                }
            }

            return mat[y, x];
        }
        public int GetElementY(int[,] mat, int x, int y, bool infinite_limit)
        {
            if (infinite_limit == true)
            {
                if ((y < 0) || (y >= mat.GetLength(0)))
                {
                    return Int32.MaxValue;
                }
            }
            else
            {
                if ((y < 0) || (y >= mat.GetLength(0)))
                {
                    return 0;
                }
            }

            return mat[y, x];
        }
        #endregion

        public SeamCarving(Bitmap b)
        {
            this.edge = (Bitmap)b.Clone();
            this.m_bitmap = (Bitmap)b.Clone();
            //SimpleFilters.GrayscaleMarshaling(this.edge);
            //SimpleFilters.EdgeDetectHorizontalUnsafe(this.edge);

            this.energyMap = new int[this.m_bitmap.Height, this.m_bitmap.Width];
            this.bitmapMatrix = new Pixel24b[this.m_bitmap.Height, this.m_bitmap.Width];
            BasicFilters.GrayscaleMarshal(this.edge);
            ConvFilters.EdgeDetectConvolution(this.edge, 1, 0);
        }

        #region NEW
        private void PopulateBitmapMatrix()
        {
            BitmapData bmData = this.edge.LockBits(new Rectangle(0, 0, this.edge.Width, this.edge.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);


            int size = bmData.Stride * bmData.Height;
            int width = this.edge.Width;
            int height = this.edge.Height;

            byte[] p = new byte[size];

            System.Runtime.InteropServices.Marshal.Copy(bmData.Scan0, p, 0, size);
            int x = 0;
            int y = 0;

            for(int i = 0; i < size; i += 3)
            {
                if (x == width)
                {
                    x = 0;
                    y++;
                    if (y == height) break;
                }

                Pixel24b px = new Pixel24b();
                px.r = p[i + 2];
                px.g = p[i + 1];
                px.b = p[i];

                this.bitmapMatrix[y, x] = px;

                x++;
            
            }
            this.edge.UnlockBits(bmData);
        }
        private void PopulateEnergyMap()
        {
           
            for(int y = 0; y < this.bitmapMatrix.GetLength(0); y++)  
                for(int x = 0; x < this.bitmapMatrix.GetLength(1); x++)    
                    this.energyMap[y, x] = DualGradient(x, y);
                
            
        }

        private int DualGradient(int x, int y)
        {
            Pixel24b yUp = GetPixelY(x, y + 1);
            Pixel24b yDown = GetPixelY(x, y - 1);
            int yGradient = (yUp.r - yDown.r) * (yUp.r - yDown.r) + (yUp.g - yDown.g) * (yUp.g - yDown.g) + (yUp.b - yDown.b) * (yUp.b - yDown.b);

            Pixel24b xLeft = GetPixelX(x - 1, y);
            Pixel24b xRight = GetPixelX(x + 1, y);
            int xGradient = (xRight.r - xLeft.r) * (xRight.r - xLeft.r) + (xRight.g - xLeft.g) * (xRight.g - xLeft.g) + (xRight.b - xLeft.b) * (xRight.b - xLeft.b);

            return xGradient + yGradient;
        }
        private Pixel24b GetPixelX(int x, int y)
        {
            if (x < 0)
                return this.bitmapMatrix[y, x + 3];

            else if (x >= this.bitmapMatrix.GetLength(1))
                return this.bitmapMatrix[y, x - 3];

                return this.bitmapMatrix[y, x];
        }
        private Pixel24b GetPixelY(int x, int y)
        {

            if (y < 0)
                return this.bitmapMatrix[y + 3, x];

            else if (y >= this.bitmapMatrix.GetLength(0))
                return this.bitmapMatrix[y - 3, x];

            return this.bitmapMatrix[y, x];
        }
        #endregion



        public Bitmap GetPathBitmap()
        {
            for (int y = 0; y < this.path.Count; ++y)
            {
                this.m_bitmap.SetPixel(path[y].x, path[y].y, Color.FromArgb(255, 0, 0));
                
            }
            return this.m_bitmap;
        }
        public Bitmap GetCarvedBitmap()
        {
            Bitmap result = new Bitmap(this.m_bitmap.Width - 1, this.m_bitmap.Height); // - 1 = broj vertikalnih puteva koji se uklanjaju
            this.path.Reverse();
    
            BitmapData bmData = this.m_bitmap.LockBits(new Rectangle(0, 0, this.m_bitmap.Width, this.m_bitmap.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            BitmapData bmData2 = result.LockBits(new Rectangle(0, 0, result.Width, result.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            IntPtr p = bmData.Scan0;
            IntPtr r = bmData2.Scan0;
            int strideP = bmData.Stride;
            int strideR = bmData2.Stride;

            byte[] data = new byte[bmData.Stride];
            for (int y = 0; y < bmData.Height; y++)
            {
                System.Runtime.InteropServices.Marshal.Copy(p, data, 0, data.Length);
                byte[] temp = new byte[strideR];
                int removeIndex = this.path[y].x * 3;
                Buffer.BlockCopy(data, 0, temp, 0, removeIndex);
                Buffer.BlockCopy(data, removeIndex + 3, temp, removeIndex, this.m_bitmap.Width * 3 - removeIndex - 3);
             

                System.Runtime.InteropServices.Marshal.Copy(temp, 0, r, temp.Length);


                p += strideP;
                r += strideR;

            }

            result.UnlockBits(bmData2);
            this.m_bitmap.UnlockBits(bmData);
            return result;

        }
   

        private void GeneratePath(int min_x)
        {
            this.path = new List<Pixel>();
          
            //this.path = new Pixel[this.energy.GetLength(0)];
            int x = min_x;
            for (int y = this.energyMap.GetLength(0) - 1; y >= 0; y--)
            {
                Pixel min = new Pixel();
                min.x = x;
                min.y = y;

                if (GetElementX(this.energyMap, x - 1, y, true) < GetElementX(this.energyMap, min.x, min.y, true))
                {
                    min.x = x - 1;
                }
                if (GetElementX(this.energyMap, x + 1, y, true) < GetElementX(this.energyMap, min.x, min.y, true))
                {
                    min.x = x + 1;
                }

                //this.path[y] = min;
                this.path.Add(min);
                x = min.x;
            }
        }
        private void EnergyPath()
        {
            int min_x = 0;
            for (int x = 1; x < this.energyMap.GetLength(1); x++)
            {
                if (this.energyMap[1, x] < this.energyMap[1, min_x])
                {
                    min_x = x;
                }
            }
            this.GeneratePath(min_x);
        }
  

        public void Prepare()
        {
            this.PopulateBitmapMatrix();
            this.PopulateEnergyMap();
            this.EnergyPath();
        }
        
    }
}


  

