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
            this.pictureBox.Height = this.Height - statusBar.Height;
            this.pictureBox.Width = this.Width;
            this.pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        protected override void OnResize(EventArgs e)
        {
            this.pictureBox.Height = this.Height - statusBar.Height;
            this.pictureBox.Width = this.Width;
        }

        public void AddListener(IController controller)
        {
            this.controller = controller;
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

        }

        private void Color(object sender, EventArgs e)
        {

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
            this.Refresh();
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
    
            MessageBox.Show("Fucking done");
        }

        public void RedrawImageOnly()
        {
            this.BeginInvoke(new MethodInvoker(delegate
            {
                this.Refresh();
            }));
        }
    }
}
