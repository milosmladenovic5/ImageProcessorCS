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
            this.menuStrip1.Enabled = false;
            this.controller.Brightness();
        }

        private void Contrast(object sender, EventArgs e)
        {
            double param = Utilities.Utilities.Clamp((int)Utilities.Utilities.GetParameters("Contrast ", "Contrast value: "), -100, 100);
            this.controller.FilterParam = param;
            this.menuStrip1.Enabled = false;
            this.controller.Contrast();
        }

        private void WaterFilter(object sender, EventArgs e)
        {
            double param = Utilities.Utilities.Clamp((int)Utilities.Utilities.GetParameters("Water ", "Wave value: "), -100, 100);
            this.controller.FilterParam = param;
            this.menuStrip1.Enabled = false;
            this.controller.Water();
        }

        private void EdgeDetectFilter(object sender, EventArgs e)
        {
            
            this.menuStrip1.Enabled = false;
            this.controller.EdgeDetect();
        }

        private void Sharpen(object sender, EventArgs e)
        {
            this.controller.Sharpen();
        }

        private void Grayscale(object sender, EventArgs e)
        {

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

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        public void Redraw()
        {
            this.Refresh();
        }
    }
}
