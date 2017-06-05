using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ImageProcessor.Utilities;
using System.Threading;

namespace ImageProcessor
{
  
    public partial class AnimationView : Form
    {
        private Thread worker;
        private Bitmap image;
        private Bitmap edgeImage;
        private int edgeThreshold = 700; // default
        private int edgesAtOnce = 50;

        public Bitmap Image
        {
            get
            {
                return this.image;
            }

            set
            {
                this.image = value;
            }
        }

 
        public AnimationView(Bitmap bmp)
        {
            InitializeComponent();
            this.image = bmp;
            this.edgeImage = (Bitmap)bmp.Clone();
            this.pictureBox1.Height = this.Height;
            this.pictureBox1.Width = this.Width;
            this.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            Filters.BasicFilters.GrayscaleMarshal(edgeImage);
            Filters.ConvFilters.EdgeDetectConvolution(edgeImage, 1, 0);
            
        }

        public AnimationView(Bitmap bmp, int edgeThreshold, int edgesAtOnce)
        {
            InitializeComponent();
            this.image = bmp;
            this.edgeThreshold = edgeThreshold;
            this.edgesAtOnce = edgesAtOnce;
            this.edgeImage = (Bitmap)bmp.Clone();
            this.pictureBox1.Height = this.Height;
            this.pictureBox1.Width = this.Width;
            this.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            Filters.BasicFilters.GrayscaleMarshal(edgeImage);
            Filters.ConvFilters.EdgeDetectConvolution(edgeImage, 1, 0);

        }

        public List<PixelRGB> ExtractPixels()
        {
            List<PixelRGB> pixels = new List<PixelRGB>();

   
            BitmapData bmData = this.edgeImage.LockBits(new Rectangle(0, 0, edgeImage.Width, edgeImage.Height), ImageLockMode.ReadWrite, edgeImage.PixelFormat);// PixelFormat.Format24bppRgb);

            int stride = bmData.Stride;
            System.IntPtr Scan0 = bmData.Scan0;

            unsafe
            {
                byte* p = (byte*)(void*)Scan0;

                int nOffset = stride - edgeImage.Width * 3;

                for (int y = 0; y < edgeImage.Height; ++y)
                {
                    for (int x = 0; x < edgeImage.Width; ++x)
                    {
                        if ((int)(p[2] + p[1] + p[0]) > this.edgeThreshold)
                        {
                            pixels.Add(new PixelRGB(x, y, p[2], p[1], p[0]));
                        }
                        p += 3;
                    }
                    p += nOffset;
                }
            }

            edgeImage.UnlockBits(bmData);

            pixels.Sort();

            return pixels;
        }


        protected override void OnResize(EventArgs e)
        {
            this.pictureBox1.Height = this.Height;
            this.pictureBox1.Width = this.Width;
        }

        public AnimationView()
        {
            InitializeComponent();
        }

        public void Animate()
        {
            try
            {
                this.worker = new Thread(() =>
                     {
                         List<PixelRGB> pixels = ExtractPixels();
                         Bitmap result = new Bitmap(Image.Width, this.Image.Height);

                         using (Graphics g = Graphics.FromImage(result))
                         {
                             g.FillRectangle(Brushes.Black, new Rectangle(0, 0, result.Width, result.Height));
                             this.pictureBox1.Image = result;

                             for (int i = 0; i < pixels.Count /*- this.edgesAtOnce*/; i += this.edgesAtOnce)
                             {

                                 for (int j = 0; j < this.edgesAtOnce; j++)
                                 {
                                     if (i + j >= pixels.Count) break; // mora ovako da ne bi preskakalo na kraju, ruzno je..
                                     var brush = new SolidBrush(Color.FromArgb(pixels[i + j].R, pixels[i + j].G, pixels[i + j].B));
                                     g.FillRectangle(brush, pixels[i + j].xPos, pixels[i + j].yPos, 1, 1);

                                 }

                                 Thread.Sleep(3);
                                 this.RedrawInvoker();
                             }
                             Thread.Sleep(300);
                             this.pictureBox1.Image = this.image;
                             this.RedrawInvoker();

                         }
                       //MessageBox.Show("Done.");

                   });
                this.worker.Start();
            }
            catch (Exception e)
            {
                Console.Write(e);
            }

  
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            //Environment.Exit(Environment.ExitCode);
            if(this.worker != null)
                this.worker.Abort();
        }

        public void RedrawInvoker()
        {
            this.BeginInvoke(new MethodInvoker(delegate
            {
                this.Refresh();
            }));
        }
    }
}
