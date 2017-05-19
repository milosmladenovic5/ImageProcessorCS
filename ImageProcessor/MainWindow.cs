using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ImageProcessor.View;
using ImageProcessor.Controller;
using ImageProcessor.Model;
using ImageProcessor.Utilities;
using System.Drawing.Drawing2D;
using ImageProcessor;

namespace ImageProcessor
{
    public partial class MainWindow : Form, IView
    {
        private IController controller;
    

        public Image Image
        {
            get
            {
                return this.pictureBox.Image;
            }

            set
            {
                this.pictureBox.Image = value;
            }
        }

        public string ImageInfo
        {
            set
            {
                statusBar.Text = value;
            }
        }

        public MainWindow()
        {
            InitializeComponent();

        
            //this.pictureBox.Location = new Point(0, this.mainMenu.Height);

            this.pictureBox.Height = this.Height - statusBar.Height - this.mainMenu.Height;
            this.pictureBox.Width = this.Width;
            this.pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            this.statusBar.BringToFront();

        }

      

        public void AddListener(IController controller)
        {
            this.controller = controller;
        }

        public void RedrawInvoker()
        {
            this.BeginInvoke(new MethodInvoker(delegate
            {
                this.MainMenuStrip.Enabled = true;
                this.Refresh();
            }));
        }

        public void Redraw()
        {
            this.statusBar.Text = Image.Width + " x " + Image.Height;
            this.Refresh();
        }

        public void EnableControls()
        {
            this.save.Enabled = true;
            this.editToolStripMenuItem.Enabled = true;
            this.optionsToolStripMenuItem.Enabled = true;
            this.filtersToolStripMenuItem.Enabled = true;
        }

        public void RedrawImageOnlyInvoker()
        {
            this.BeginInvoke(new MethodInvoker(delegate
            {
                this.Redraw();
            }));
        }



        // ------------------------------ EVENT HANDLERS -------------------------------------------------------------------

        protected override void OnResize(EventArgs e)
        {
            this.pictureBox.Height = this.Height - statusBar.Height-this.mainMenu.Height;
            this.pictureBox.Width = this.Width;

        }

        private void LoadImage(object sender, EventArgs e)
        {
            this.controller.LoadImage();
        }

        private void Exit(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void SaveImage(object sender, EventArgs e)
        {
            this.controller.SaveImage();
        }

        private void Undo(object sender, EventArgs e)
        {
            this.controller.Undo();
        }

        private void Redo(object sender, EventArgs e)
        {
            this.controller.Redo();
        }

        private void Brightness(object sender, EventArgs e)
        {
            double param = Utilities.Utilities.Clamp((int)Utilities.Utilities.GetParameters("Brightness ", "Brightness value: "), -255, 255);
            this.controller.FilterParam = param;
            this.mainMenu.Enabled = false;
            this.controller.Brightness();
        }

        private void Contrast(object sender, EventArgs e)
        {
            double param = Utilities.Utilities.Clamp((int)Utilities.Utilities.GetParameters("Contrast ", "Contrast value: "), -100, 100);
            this.controller.FilterParam = param;
            this.mainMenu.Enabled = false;
            this.controller.Contrast();
        }

        private void WaterFilter(object sender, EventArgs e)
        {
            double param = Utilities.Utilities.Clamp((int)Utilities.Utilities.GetParameters("Water ", "Wave value: "), 15, 50);
            this.controller.FilterParam = param;
            this.mainMenu.Enabled = false;
            this.controller.Water();
        }

        private void EdgeDetectFilter(object sender, EventArgs e)
        {
            
            this.mainMenu.Enabled = false;
            this.controller.EdgeDetect();
        }

        private void Sharpen(object sender, EventArgs e)
        {
            double param = Utilities.Utilities.Clamp((int)Utilities.Utilities.GetParameters("Sharpen ", "Sharpness: "), 11, 50);
            this.controller.FilterParam = param;
            this.mainMenu.Enabled = false;
            this.controller.Sharpen();
        }

        private void Grayscale(object sender, EventArgs e)
        {
            this.mainMenu.Enabled = false;
            this.controller.Grayscale();
        }

        private void Gamma(object sender, EventArgs e)
        {
            double r = Utilities.Utilities.Clamp(Utilities.Utilities.GetParameters("Red ", "Value(0.2, 5): "), 0.2, 5);
            double g = Utilities.Utilities.Clamp(Utilities.Utilities.GetParameters("Green ", "Value(0.2, 5): "), 0.2, 5);
            double b = Utilities.Utilities.Clamp(Utilities.Utilities.GetParameters("Blue ", "Value(0.2, 5): "), 0.2, 5);

            this.mainMenu.Enabled = false;
            this.controller.Color((int)r, (int)g, (int)b);
        }

        private void Color(object sender, EventArgs e)
        {
            double r = Utilities.Utilities.Clamp((int)Utilities.Utilities.GetParameters("Red ", "Value(-255, 255): "), -255, 255);
            double g = Utilities.Utilities.Clamp((int)Utilities.Utilities.GetParameters("Green ", "Value(-255, 255): "), -255, 255);
            double b = Utilities.Utilities.Clamp((int)Utilities.Utilities.GetParameters("Blue ", "Value(-255, 255): "), -255, 255);

            this.mainMenu.Enabled = false;
            this.controller.Color((int)r, (int)g, (int)b);
        }

  

        private void GaussianBlur(object sender, EventArgs e)
        {
            double param = Utilities.Utilities.Clamp((int)Utilities.Utilities.GetParameters("Gaussian blur ", "Blur parameter: "), 1, 4);
            this.controller.FilterParam = param;
            this.mainMenu.Enabled = false;
            this.controller.GaussianBlur();
        }

        private void SeamCarving(object sender, EventArgs e)
        {
            double param = Utilities.Utilities.Clamp((int)Utilities.Utilities.GetParameters("Seam Carving ", "Width - : "), 1, 100);
            this.controller.FilterParam = param;
            this.mainMenu.Enabled = false;

            this.controller.Carve();    
        }    

        private void EdgeEnhance(object sender, EventArgs e)
        {
            double param = Utilities.Utilities.Clamp((int)Utilities.Utilities.GetParameters("Edge enhance ", "Weight: "), 1, 4);
            this.controller.FilterParam = param;
            this.mainMenu.Enabled = false;
            this.controller.EdgeEnhance();
        }

        private void FlipHorizontal(object sender, EventArgs e)
        {
            this.controller.FilterParam = 1.0;
            this.mainMenu.Enabled = false;
            this.controller.Flip();
        }

        private void FlipVertical(object sender, EventArgs e)
        {
            this.controller.FilterParam = 2.0;
            this.mainMenu.Enabled = false;
            this.controller.Flip();
        }

        private void DisplacementSmoothChange(object sender, EventArgs e)
        {
            this.displacementSmoothToolStripMenuItem.Checked = !this.displacementSmoothToolStripMenuItem.Checked;
            this.controller.DisplacementSmooth = this.displacementSmoothToolStripMenuItem.Checked;
        }

        private void Swirl(object sender, EventArgs e)
        {
            double param = Utilities.Utilities.Clamp((int)Utilities.Utilities.GetParameters("Swirl", "Degree: "), 0.5, 360);
            this.controller.FilterParam = param;
            this.mainMenu.Enabled = false;
            this.controller.Swirl();
        }

        private void Sphere(object sender, EventArgs e)
        {
            this.mainMenu.Enabled = false;
            this.controller.Sphere();
        }

        private void TimeWarp(object sender, EventArgs e)
        {
            double param = Utilities.Utilities.Clamp((int)Utilities.Utilities.GetParameters("TimeWarp", "Factor: "), 0, 255);
            this.controller.FilterParam = param;
            this.mainMenu.Enabled = false;
            this.controller.TimeWarp();
        }

        private void Pixelate(object sender, EventArgs e)
        {
            double param = Utilities.Utilities.Clamp((int)Utilities.Utilities.GetParameters("Pixelate", "Pixel: "), 0, 255);
            this.controller.FilterParam = param;
            this.mainMenu.Enabled = false;
            this.controller.Pixelate();
        }   

        private void cropToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.controller.Crop();
        }
    }
}
