using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessor.Filters
{
    public class DispFilters
    {

        public static bool OffsetFilterAbs(Bitmap b, Point[,] offset)
        {
            Bitmap bSrc = (Bitmap)b.Clone();

        
            BitmapData bmData = b.LockBits(new Rectangle(0, 0, b.Width, b.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            BitmapData bmSrc = bSrc.LockBits(new Rectangle(0, 0, bSrc.Width, bSrc.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int scanline = bmData.Stride;

            System.IntPtr Scan0 = bmData.Scan0;
            System.IntPtr SrcScan0 = bmSrc.Scan0;

            unsafe
            {
                byte* p = (byte*)(void*)Scan0;
                byte* pSrc = (byte*)(void*)SrcScan0;

                int nOffset = bmData.Stride - b.Width * 3;
                int nWidth = b.Width;
                int nHeight = b.Height;

                int xOffset, yOffset;

                for (int y = 0; y < nHeight; ++y)
                {
                    for (int x = 0; x < nWidth; ++x)
                    {
                        xOffset = offset[x, y].X;
                        yOffset = offset[x, y].Y;

                        if (yOffset >= 0 && yOffset < nHeight && xOffset >= 0 && xOffset < nWidth)
                        {
                            p[0] = pSrc[(yOffset * scanline) + (xOffset * 3)];
                            p[1] = pSrc[(yOffset * scanline) + (xOffset * 3) + 1];
                            p[2] = pSrc[(yOffset * scanline) + (xOffset * 3) + 2];
                        }

                        p += 3;
                    }
                    p += nOffset;
                }
            }

            b.UnlockBits(bmData);
            bSrc.UnlockBits(bmSrc);

            return true;
        }
        public static bool OffsetFilter(Bitmap b, Point[,] offset)
        {
            Bitmap bSrc = (Bitmap)b.Clone();

            // GDI+ still lies to us - the return format is BGR, NOT RGB.
            BitmapData bmData = b.LockBits(new Rectangle(0, 0, b.Width, b.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            BitmapData bmSrc = bSrc.LockBits(new Rectangle(0, 0, bSrc.Width, bSrc.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int scanline = bmData.Stride;

            System.IntPtr Scan0 = bmData.Scan0;
            System.IntPtr SrcScan0 = bmSrc.Scan0;

            unsafe
            {
                byte* p = (byte*)(void*)Scan0;
                byte* pSrc = (byte*)(void*)SrcScan0;

                int nOffset = bmData.Stride - b.Width * 3;
                int nWidth = b.Width;
                int nHeight = b.Height;

                int xOffset, yOffset;

                for (int y = 0; y < nHeight; ++y)
                {
                    for (int x = 0; x < nWidth; ++x)
                    {
                        xOffset = offset[x, y].X;
                        yOffset = offset[x, y].Y;

                        if (y + yOffset >= 0 && y + yOffset < nHeight && x + xOffset >= 0 && x + xOffset < nWidth)
                        {
                            p[0] = pSrc[((y + yOffset) * scanline) + ((x + xOffset) * 3)];
                            p[1] = pSrc[((y + yOffset) * scanline) + ((x + xOffset) * 3) + 1];
                            p[2] = pSrc[((y + yOffset) * scanline) + ((x + xOffset) * 3) + 2];
                        }

                        p += 3;
                    }
                    p += nOffset;
                }
            }

            b.UnlockBits(bmData);
            bSrc.UnlockBits(bmSrc);

            return true;
        }
        public static bool OffsetFilterAntiAlias(Bitmap b, FloatPoint[,] fp)
        {
            Bitmap bSrc = (Bitmap)b.Clone();

            // GDI+ still lies to us - the return format is BGR, NOT RGB.
            BitmapData bmData = b.LockBits(new Rectangle(0, 0, b.Width, b.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            BitmapData bmSrc = bSrc.LockBits(new Rectangle(0, 0, bSrc.Width, bSrc.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int scanline = bmData.Stride;

            System.IntPtr Scan0 = bmData.Scan0;
            System.IntPtr SrcScan0 = bmSrc.Scan0;

            unsafe
            {
                byte* p = (byte*)(void*)Scan0;
                byte* pSrc = (byte*)(void*)SrcScan0;

                int nOffset = bmData.Stride - b.Width * 3;
                int nWidth = b.Width;
                int nHeight = b.Height;

                double xOffset, yOffset;

                double fraction_x, fraction_y, one_minus_x, one_minus_y;
                int ceil_x, ceil_y, floor_x, floor_y;
                Byte p1, p2;

                for (int y = 0; y < nHeight; ++y)
                {
                    for (int x = 0; x < nWidth; ++x)
                    {
                        xOffset = fp[x, y].X;
                        yOffset = fp[x, y].Y;

                        // Setup

                        floor_x = (int)Math.Floor(xOffset);
                        floor_y = (int)Math.Floor(yOffset);
                        ceil_x = floor_x + 1;
                        ceil_y = floor_y + 1;
                        fraction_x = xOffset - floor_x;
                        fraction_y = yOffset - floor_y;
                        one_minus_x = 1.0 - fraction_x;
                        one_minus_y = 1.0 - fraction_y;

                        if (floor_y >= 0 && ceil_y < nHeight && floor_x >= 0 && ceil_x < nWidth)
                        {
                            // Blue

                            p1 = (Byte)(one_minus_x * (double)(pSrc[floor_y * scanline + floor_x * 3]) +
                                fraction_x * (double)(pSrc[floor_y * scanline + ceil_x * 3]));

                            p2 = (Byte)(one_minus_x * (double)(pSrc[ceil_y * scanline + floor_x * 3]) +
                                fraction_x * (double)(pSrc[ceil_y * scanline + 3 * ceil_x]));

                            p[x * 3 + y * scanline] = (Byte)(one_minus_y * (double)(p1) + fraction_y * (double)(p2));

                            // Green

                            p1 = (Byte)(one_minus_x * (double)(pSrc[floor_y * scanline + floor_x * 3 + 1]) +
                                fraction_x * (double)(pSrc[floor_y * scanline + ceil_x * 3 + 1]));

                            p2 = (Byte)(one_minus_x * (double)(pSrc[ceil_y * scanline + floor_x * 3 + 1]) +
                                fraction_x * (double)(pSrc[ceil_y * scanline + 3 * ceil_x + 1]));

                            p[x * 3 + y * scanline + 1] = (Byte)(one_minus_y * (double)(p1) + fraction_y * (double)(p2));

                            // Red

                            p1 = (Byte)(one_minus_x * (double)(pSrc[floor_y * scanline + floor_x * 3 + 2]) +
                                fraction_x * (double)(pSrc[floor_y * scanline + ceil_x * 3 + 2]));

                            p2 = (Byte)(one_minus_x * (double)(pSrc[ceil_y * scanline + floor_x * 3 + 2]) +
                                fraction_x * (double)(pSrc[ceil_y * scanline + 3 * ceil_x + 2]));

                            p[x * 3 + y * scanline + 2] = (Byte)(one_minus_y * (double)(p1) + fraction_y * (double)(p2));
                        }
                    }
                }
            }

            b.UnlockBits(bmData);
            bSrc.UnlockBits(bmSrc);

            return true;
        }


        public static bool Flip(Bitmap b, bool bHorz, bool bVert)
        {
            Point[,] ptFlip = new Point[b.Width, b.Height];

            int nWidth = b.Width;
            int nHeight = b.Height;

            for (int x = 0; x < nWidth; ++x)
                for (int y = 0; y < nHeight; ++y)
                {
                    ptFlip[x, y].X = (bHorz) ? nWidth - (x + 1) : x;
                    ptFlip[x, y].Y = (bVert) ? nHeight - (y + 1) : y;
                }

            OffsetFilterAbs(b, ptFlip);

            return true;
        }
        public static bool Water(Bitmap b, short nWave, bool bSmoothing)
        {
            int nWidth = b.Width;
            int nHeight = b.Height;

            FloatPoint[,] fp = new FloatPoint[nWidth, nHeight];
            Point[,] pt = new Point[nWidth, nHeight];

            Point mid = new Point();
            mid.X = nWidth / 2;
            mid.Y = nHeight / 2;

            double newX, newY;
            double xo, yo;

            for (int x = 0; x < nWidth; ++x)
                for (int y = 0; y < nHeight; ++y)
                {
                    xo = ((double)nWave * Math.Sin(2.0 * Math.PI * (float)y / 128.0));
                    yo = ((double)nWave * Math.Cos(2.0 * Math.PI * (float)x / 128.0));

                    newX = (x + xo);
                    newY = (y + yo);

                    if (newX > 0 && newX < nWidth)
                    {
                        fp[x, y].X = newX;
                        pt[x, y].X = (int)newX;
                    }
                    else
                    {
                        fp[x, y].X = 0.0;
                        pt[x, y].X = 0;
                    }


                    if (newY > 0 && newY < nHeight)
                    {
                        fp[x, y].Y = newY;
                        pt[x, y].Y = (int)newY;
                    }
                    else
                    {
                        fp[x, y].Y = 0.0;
                        pt[x, y].Y = 0;
                    }
                }

            if (bSmoothing)
                OffsetFilterAbs(b, pt);
            else
                OffsetFilterAntiAlias(b, fp);

            return true;
        }
        public static bool Swirl(Bitmap b, double fDegree, bool bSmoothing )
        {
            int nWidth = b.Width;
            int nHeight = b.Height;

            FloatPoint[,] fp = new FloatPoint[nWidth, nHeight];
            Point[,] pt = new Point[nWidth, nHeight];

            Point mid = new Point();
            mid.X = nWidth / 2;
            mid.Y = nHeight / 2;

            double theta, radius;
            double newX, newY;

            for (int x = 0; x < nWidth; ++x)
                for (int y = 0; y < nHeight; ++y)
                {
                    int trueX = x - mid.X;
                    int trueY = y - mid.Y;
                    theta = Math.Atan2((trueY), (trueX));

                    radius = Math.Sqrt(trueX * trueX + trueY * trueY);

                    newX = mid.X + (radius * Math.Cos(theta + fDegree * radius));
                    if (newX > 0 && newX < nWidth)
                    {
                        fp[x, y].X = newX;
                        pt[x, y].X = (int)newX;
                    }
                    else
                        fp[x, y].X = pt[x, y].X = x;

                    newY = mid.Y + (radius * Math.Sin(theta + fDegree * radius));
                    if (newY > 0 && newY < nHeight)
                    {
                        fp[x, y].Y = newY;
                        pt[x, y].Y = (int)newY;
                    }
                    else
                        fp[x, y].Y = pt[x, y].Y = y;
                }

            if (bSmoothing)
                OffsetFilterAntiAlias(b, fp);
            else
                OffsetFilterAbs(b, pt);

            return true;
        }
        public static bool Sphere(Bitmap b, bool bSmoothing)
        {
            int nWidth = b.Width;
            int nHeight = b.Height;

            FloatPoint[,] fp = new FloatPoint[nWidth, nHeight];
            Point[,] pt = new Point[nWidth, nHeight];

            Point mid = new Point();
            mid.X = nWidth / 2;
            mid.Y = nHeight / 2;

            double theta, radius;
            double newX, newY;

            for (int x = 0; x < nWidth; ++x)
                for (int y = 0; y < nHeight; ++y)
                {
                    int trueX = x - mid.X;
                    int trueY = y - mid.Y;
                    theta = Math.Atan2((trueY), (trueX));

                    radius = Math.Sqrt(trueX * trueX + trueY * trueY);

                    double newRadius = radius * radius / (Math.Max(mid.X, mid.Y));

                    newX = mid.X + (newRadius * Math.Cos(theta));

                    if (newX > 0 && newX < nWidth)
                    {
                        fp[x, y].X = newX;
                        pt[x, y].X = (int)newX;
                    }
                    else
                    {
                        fp[x, y].X = fp[x, y].Y = 0.0;
                        pt[x, y].X = pt[x, y].Y = 0;
                    }

                    newY = mid.Y + (newRadius * Math.Sin(theta));

                    if (newY > 0 && newY < nHeight && newX > 0 && newX < nWidth)
                    {
                        fp[x, y].Y = newY;
                        pt[x, y].Y = (int)newY;
                    }
                    else
                    {
                        fp[x, y].X = fp[x, y].Y = 0.0;
                        pt[x, y].X = pt[x, y].Y = 0;
                    }
                }

            if (bSmoothing)
                OffsetFilterAbs(b, pt);
            else
                OffsetFilterAntiAlias(b, fp);

            return true;
        }
        public static bool TimeWarp(Bitmap b, Byte factor, bool bSmoothing)
        {
            int nWidth = b.Width;
            int nHeight = b.Height;

            FloatPoint[,] fp = new FloatPoint[nWidth, nHeight];
            Point[,] pt = new Point[nWidth, nHeight];

            Point mid = new Point();
            mid.X = nWidth / 2;
            mid.Y = nHeight / 2;

            double theta, radius;
            double newX, newY;

            for (int x = 0; x < nWidth; ++x)
                for (int y = 0; y < nHeight; ++y)
                {
                    int trueX = x - mid.X;
                    int trueY = y - mid.Y;
                    theta = Math.Atan2((trueY), (trueX));

                    radius = Math.Sqrt(trueX * trueX + trueY * trueY);

                    double newRadius = Math.Sqrt(radius) * factor;

                    newX = mid.X + (newRadius * Math.Cos(theta));
                    if (newX > 0 && newX < nWidth)
                    {
                        fp[x, y].X = newX;
                        pt[x, y].X = (int)newX;
                    }
                    else
                    {
                        fp[x, y].X = 0.0;
                        pt[x, y].X = 0;
                    }

                    newY = mid.Y + (newRadius * Math.Sin(theta));
                    if (newY > 0 && newY < nHeight)
                    {
                        fp[x, y].Y = newY;
                        pt[x, y].Y = (int)newY;
                    }
                    else
                    {
                        fp[x, y].Y = 0.0;
                        pt[x, y].Y = 0;
                    }
                }

            if (bSmoothing)
                OffsetFilterAbs(b, pt);
            else
                OffsetFilterAntiAlias(b, fp);

            return true;
        }
        public static bool Pixelate(Bitmap b, short pixel, bool bGrid)
        {
            int nWidth = b.Width;
            int nHeight = b.Height;

            Point[,] pt = new Point[nWidth, nHeight];

            int newX, newY;

            for (int x = 0; x < nWidth; ++x)
                for (int y = 0; y < nHeight; ++y)
                {
                    newX = pixel - x % pixel;

                    if (bGrid && newX == pixel)
                        pt[x, y].X = -x;
                    else if (x + newX > 0 && x + newX < nWidth)
                        pt[x, y].X = newX;
                    else
                        pt[x, y].X = 0;

                    newY = pixel - y % pixel;

                    if (bGrid && newY == pixel)
                        pt[x, y].Y = -y;
                    else if (y + newY > 0 && y + newY < nHeight)
                        pt[x, y].Y = newY;
                    else
                        pt[x, y].Y = 0;
                }

            OffsetFilter(b, pt);

            return true;
        }
    }
}
