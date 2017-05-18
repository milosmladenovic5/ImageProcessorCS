namespace ImageProcessor
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.load = new System.Windows.Forms.ToolStripMenuItem();
            this.save = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undo = new System.Windows.Forms.ToolStripMenuItem();
            this.redo = new System.Windows.Forms.ToolStripMenuItem();
            this.seamCarving = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.displacementSmoothToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filtersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.brightness = new System.Windows.Forms.ToolStripMenuItem();
            this.contrast = new System.Windows.Forms.ToolStripMenuItem();
            this.grayscale = new System.Windows.Forms.ToolStripMenuItem();
            this.color = new System.Windows.Forms.ToolStripMenuItem();
            this.edgeEnhanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gamma = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.sharpen = new System.Windows.Forms.ToolStripMenuItem();
            this.gaussianBlur = new System.Windows.Forms.ToolStripMenuItem();
            this.edgeDetect = new System.Windows.Forms.ToolStripMenuItem();
            this.water = new System.Windows.Forms.ToolStripMenuItem();
            this.flipHorizontalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flipVerticalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.swirlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sphereToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timeWarpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.statusBar = new System.Windows.Forms.StatusBar();
            this.pixelateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.filtersToolStripMenuItem});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(848, 24);
            this.mainMenu.TabIndex = 0;
            this.mainMenu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.load,
            this.save,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // load
            // 
            this.load.Name = "load";
            this.load.Size = new System.Drawing.Size(100, 22);
            this.load.Text = "Load";
            this.load.Click += new System.EventHandler(this.LoadImage);
            // 
            // save
            // 
            this.save.Enabled = false;
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(100, 22);
            this.save.Text = "Save";
            this.save.Click += new System.EventHandler(this.SaveImage);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.Exit);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undo,
            this.redo,
            this.seamCarving});
            this.editToolStripMenuItem.Enabled = false;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // undo
            // 
            this.undo.Name = "undo";
            this.undo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.undo.Size = new System.Drawing.Size(145, 22);
            this.undo.Text = "Undo";
            this.undo.Click += new System.EventHandler(this.Undo);
            // 
            // redo
            // 
            this.redo.Name = "redo";
            this.redo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.redo.Size = new System.Drawing.Size(145, 22);
            this.redo.Text = "Redo";
            this.redo.Click += new System.EventHandler(this.Redo);
            // 
            // seamCarving
            // 
            this.seamCarving.Name = "seamCarving";
            this.seamCarving.Size = new System.Drawing.Size(145, 22);
            this.seamCarving.Text = "Seam carving";
            this.seamCarving.Click += new System.EventHandler(this.SeamCarving);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.colorizeToolStripMenuItem,
            this.displacementSmoothToolStripMenuItem});
            this.optionsToolStripMenuItem.Enabled = false;
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // colorizeToolStripMenuItem
            // 
            this.colorizeToolStripMenuItem.Name = "colorizeToolStripMenuItem";
            this.colorizeToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.colorizeToolStripMenuItem.Text = "Colorize";
            // 
            // displacementSmoothToolStripMenuItem
            // 
            this.displacementSmoothToolStripMenuItem.Name = "displacementSmoothToolStripMenuItem";
            this.displacementSmoothToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.displacementSmoothToolStripMenuItem.Text = "Displacement : Smooth";
            this.displacementSmoothToolStripMenuItem.Click += new System.EventHandler(this.DisplacementSmoothChange);
            // 
            // filtersToolStripMenuItem
            // 
            this.filtersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.brightness,
            this.contrast,
            this.grayscale,
            this.color,
            this.edgeEnhanceToolStripMenuItem,
            this.gamma,
            this.toolStripSeparator1,
            this.sharpen,
            this.gaussianBlur,
            this.edgeDetect,
            this.water,
            this.flipHorizontalToolStripMenuItem,
            this.flipVerticalToolStripMenuItem,
            this.swirlToolStripMenuItem,
            this.sphereToolStripMenuItem,
            this.timeWarpToolStripMenuItem,
            this.pixelateToolStripMenuItem});
            this.filtersToolStripMenuItem.Enabled = false;
            this.filtersToolStripMenuItem.Name = "filtersToolStripMenuItem";
            this.filtersToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.filtersToolStripMenuItem.Text = "Filters";
            // 
            // brightness
            // 
            this.brightness.Name = "brightness";
            this.brightness.Size = new System.Drawing.Size(157, 22);
            this.brightness.Text = "Brightness";
            this.brightness.Click += new System.EventHandler(this.Brightness);
            // 
            // contrast
            // 
            this.contrast.Name = "contrast";
            this.contrast.Size = new System.Drawing.Size(157, 22);
            this.contrast.Text = "Contrast";
            this.contrast.Click += new System.EventHandler(this.Contrast);
            // 
            // grayscale
            // 
            this.grayscale.Name = "grayscale";
            this.grayscale.Size = new System.Drawing.Size(157, 22);
            this.grayscale.Text = "Grayscale";
            this.grayscale.Click += new System.EventHandler(this.Grayscale);
            // 
            // color
            // 
            this.color.Name = "color";
            this.color.Size = new System.Drawing.Size(157, 22);
            this.color.Text = "Color";
            this.color.Click += new System.EventHandler(this.Color);
            // 
            // edgeEnhanceToolStripMenuItem
            // 
            this.edgeEnhanceToolStripMenuItem.Name = "edgeEnhanceToolStripMenuItem";
            this.edgeEnhanceToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.edgeEnhanceToolStripMenuItem.Text = "Edge enhance";
            this.edgeEnhanceToolStripMenuItem.Click += new System.EventHandler(this.EdgeEnhance);
            // 
            // gamma
            // 
            this.gamma.Name = "gamma";
            this.gamma.Size = new System.Drawing.Size(157, 22);
            this.gamma.Text = "Gamma";
            this.gamma.Click += new System.EventHandler(this.Gamma);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(154, 6);
            // 
            // sharpen
            // 
            this.sharpen.Name = "sharpen";
            this.sharpen.Size = new System.Drawing.Size(157, 22);
            this.sharpen.Text = "Sharpen";
            this.sharpen.Click += new System.EventHandler(this.Sharpen);
            // 
            // gaussianBlur
            // 
            this.gaussianBlur.Name = "gaussianBlur";
            this.gaussianBlur.Size = new System.Drawing.Size(157, 22);
            this.gaussianBlur.Text = "Gaussian blur";
            this.gaussianBlur.Click += new System.EventHandler(this.GaussianBlur);
            // 
            // edgeDetect
            // 
            this.edgeDetect.Name = "edgeDetect";
            this.edgeDetect.Size = new System.Drawing.Size(157, 22);
            this.edgeDetect.Text = "Edge detect";
            this.edgeDetect.Click += new System.EventHandler(this.EdgeDetectFilter);
            // 
            // water
            // 
            this.water.Name = "water";
            this.water.Size = new System.Drawing.Size(157, 22);
            this.water.Text = "Water";
            this.water.Click += new System.EventHandler(this.WaterFilter);
            // 
            // flipHorizontalToolStripMenuItem
            // 
            this.flipHorizontalToolStripMenuItem.Name = "flipHorizontalToolStripMenuItem";
            this.flipHorizontalToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.flipHorizontalToolStripMenuItem.Text = "Flip : Horizontal";
            this.flipHorizontalToolStripMenuItem.Click += new System.EventHandler(this.FlipHorizontal);
            // 
            // flipVerticalToolStripMenuItem
            // 
            this.flipVerticalToolStripMenuItem.Name = "flipVerticalToolStripMenuItem";
            this.flipVerticalToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.flipVerticalToolStripMenuItem.Text = "Flip : Vertical";
            this.flipVerticalToolStripMenuItem.Click += new System.EventHandler(this.FlipVertical);
            // 
            // swirlToolStripMenuItem
            // 
            this.swirlToolStripMenuItem.Name = "swirlToolStripMenuItem";
            this.swirlToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.swirlToolStripMenuItem.Text = "Swirl";
            this.swirlToolStripMenuItem.Click += new System.EventHandler(this.Swirl);
            // 
            // sphereToolStripMenuItem
            // 
            this.sphereToolStripMenuItem.Name = "sphereToolStripMenuItem";
            this.sphereToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.sphereToolStripMenuItem.Text = "Sphere";
            this.sphereToolStripMenuItem.Click += new System.EventHandler(this.Sphere);
            // 
            // timeWarpToolStripMenuItem
            // 
            this.timeWarpToolStripMenuItem.Name = "timeWarpToolStripMenuItem";
            this.timeWarpToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.timeWarpToolStripMenuItem.Text = "Time warp";
            this.timeWarpToolStripMenuItem.Click += new System.EventHandler(this.TimeWarp);
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(-10, 27);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(855, 390);
            this.pictureBox.TabIndex = 1;
            this.pictureBox.TabStop = false;
            // 
            // statusBar
            // 
            this.statusBar.Location = new System.Drawing.Point(0, 453);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(848, 22);
            this.statusBar.TabIndex = 2;
            // 
            // pixelateToolStripMenuItem
            // 
            this.pixelateToolStripMenuItem.Name = "pixelateToolStripMenuItem";
            this.pixelateToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.pixelateToolStripMenuItem.Text = "Pixelate";
            this.pixelateToolStripMenuItem.Click += new System.EventHandler(this.Pixelate);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(848, 475);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.mainMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mainMenu;
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ImageProcessor";
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem load;
        private System.Windows.Forms.ToolStripMenuItem save;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem filtersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undo;
        private System.Windows.Forms.ToolStripMenuItem redo;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.StatusBar statusBar;
        private System.Windows.Forms.ToolStripMenuItem brightness;
        private System.Windows.Forms.ToolStripMenuItem contrast;
        private System.Windows.Forms.ToolStripMenuItem gaussianBlur;
        private System.Windows.Forms.ToolStripMenuItem edgeDetect;
        private System.Windows.Forms.ToolStripMenuItem water;
        private System.Windows.Forms.ToolStripMenuItem seamCarving;
        private System.Windows.Forms.ToolStripMenuItem colorizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sharpen;
        private System.Windows.Forms.ToolStripMenuItem grayscale;
        private System.Windows.Forms.ToolStripMenuItem gamma;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem color;
        private System.Windows.Forms.ToolStripMenuItem edgeEnhanceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem flipHorizontalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem flipVerticalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem displacementSmoothToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem swirlToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sphereToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem timeWarpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pixelateToolStripMenuItem;
    }
}

