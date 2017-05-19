using ImageProcessor.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageProcessor
{
    public partial class CropView : Form
    {

        private bool _selecting;
        private Rectangle _selection;
       

        public Image Image
        {
            get
            {
                return this.pictureBox1.Image;
            }

            set
            {
                this.pictureBox1.Image = value;
            }
        }


        public void Crop()
        {

            Bitmap bmp = Image as Bitmap;
            // Check if it is a bitmap:
            if (bmp == null)
                throw new ArgumentException("No valid bitmap");

            // Crop the image:
            Bitmap cropBmp = bmp.Clone(this._selection, System.Drawing.Imaging.PixelFormat.Format24bppRgb);

            // Release the resources:
            //model.Image.Dispose();

            Image = cropBmp;
            this.Close();

        }

        public CropView()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            this.WindowState = FormWindowState.Maximized;

        }

        private void PictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (_selecting)
            {
                // Draw a rectangle displaying the current selection
                Pen pen = Pens.GreenYellow;
                e.Graphics.DrawRectangle(pen, _selection);
            }
        }

        private void PictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (_selecting)
            {
                _selection.Width = e.X - _selection.X;
                _selection.Height = e.Y - _selection.Y;

                // Redraw the picturebox:
                pictureBox1.Refresh();
            }
        }

        private void PictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && _selecting && _selection.Size != new Size())
            {
                // Create cropped image:
                //controller.Crop(_selection);
                this.Crop();
                // Fit image to the picturebox:


                _selecting = false;
            }
            else
                _selecting = false;

            this.DialogResult = DialogResult.OK;
        }

        private void PictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _selecting = true;
                _selection = new Rectangle(new Point(e.X, e.Y), new Size());
            }
        }

        public CropView(Bitmap img)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            this.WindowState = FormWindowState.Maximized;
           
            this.panel1.AutoScroll = true;
            this.pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;

            this.pictureBox1.Image = img;
            //this.panel1.AutoSize = true;


            this.pictureBox1.MouseDown += PictureBox1_MouseDown;
            this.pictureBox1.MouseUp += PictureBox1_MouseUp;
            this.pictureBox1.MouseMove += PictureBox1_MouseMove;
            this.pictureBox1.Paint += PictureBox1_Paint;
            

        }

        protected override void OnResize(EventArgs e)
        {
            this.pictureBox1.Width = this.Width - 50;
            this.pictureBox1.Height = this.Height - 50;

            this.panel1.Width = this.Width - 50;
            this.panel1.Height = this.Height - 50;
            ;
        }

        public Image Fit2PictureBox(Image image, PictureBox picBox)
        {
            Bitmap bmp = null;
            Graphics g;

            // Scale:
            double scaleY = (double)image.Width / picBox.Width;
            double scaleX = (double)image.Height / picBox.Height;
            double scale = scaleY < scaleX ? scaleX : scaleY;

            // Create new bitmap:
            bmp = new Bitmap(
                (int)((double)image.Width / scale),
                (int)((double)image.Height / scale));

            // Set resolution of the new image:
            bmp.SetResolution(
                image.HorizontalResolution,
                image.VerticalResolution);

            // Create graphics:
            g = Graphics.FromImage(bmp);

            // Set interpolation mode:
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;

            // Draw the new image:
            g.DrawImage(
                image,
                new Rectangle(            // Destination
                    0, 0,
                    bmp.Width, bmp.Height),
                new Rectangle(            // Source
                    0, 0,
                    image.Width, image.Height),
                GraphicsUnit.Pixel);

            // Release the resources of the graphics:
            g.Dispose();

            // Release the resources of the origin image:
            image.Dispose();

            return bmp;
        }

    }
}
