using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageProcessor.Model;
using ImageProcessor.View;
using ImageProcessor.Utilities;
using ImageProcessor.Filters;
using System.Threading;
using System.Drawing;

namespace ImageProcessor.Controller
{



    public class Controller : IController
    {
        private IView view;
        private IModel model;
        private UndoRedo undoRedo;
        private double filterParam;
        private bool displacementSmooth = false;


        public double FilterParam
        {
            get
            {
                return this.filterParam;
            }

            set
            {
                this.filterParam = value;
            }
        }

        public bool DisplacementSmooth
        {
            get
            {
                return this.displacementSmooth;
            }

            set
            {
                this.displacementSmooth = value;
            }
        }

        public Controller(IView view, IModel model)
        {
            this.view = view;
            this.model = model;
            this.view.AddListener(this);
            this.undoRedo = new UndoRedo(4);
        }


        public void LoadImage()
        {
            this.model.Load();
            if (this.model.Image != null)
            {
                this.view.Image = this.model.Image;
                this.view.ImageInfo = this.model.ImageInfo;
                this.view.EnableControls();
            }
        }

        public void SaveImage()
        {
            this.model.Save();
        }

        public void Brightness()
        {
            new Thread(() =>
            {
                this.undoRedo.PushToUndoStack((Bitmap)this.model.Image.Clone());
                this.undoRedo.ClearRedoStack();

                BasicFilters.Brightness(this.model.Image, (int)this.filterParam);
                this.view.RedrawInvoker();

            }).Start();

        }

        public void Contrast()
        {
            new Thread(() =>
            {
                this.undoRedo.PushToUndoStack((Bitmap)this.model.Image.Clone());
                this.undoRedo.ClearRedoStack();

                BasicFilters.Contrast(this.model.Image, (sbyte)this.filterParam);
                this.view.RedrawInvoker();

            }).Start();
        }

        public void Water()
        {
            new Thread(() =>
            {
                this.undoRedo.PushToUndoStack((Bitmap)this.model.Image.Clone());
                this.undoRedo.ClearRedoStack();

                DispFilters.Water(this.model.Image, (short)this.filterParam, this.displacementSmooth);
                this.view.RedrawInvoker();

            }).Start();

        }

        public void EdgeDetect()
        {
            new Thread(() =>
            {
                this.undoRedo.PushToUndoStack((Bitmap)this.model.Image.Clone());
                this.undoRedo.ClearRedoStack();

                ConvFilters.EdgeDetectConvolution(this.model.Image, 2, 0);
                this.view.RedrawInvoker();

            }).Start();
        }

        public void GaussianBlur()
        {
            new Thread(() =>
            {
                this.undoRedo.PushToUndoStack((Bitmap)this.model.Image.Clone());
                this.undoRedo.ClearRedoStack();

                ConvFilters.GaussianBlur(this.model.Image, (int)this.filterParam);
                this.view.RedrawInvoker();

            }).Start();
        }

        public void Sharpen()
        {
            new Thread(() =>
            {
                this.undoRedo.PushToUndoStack((Bitmap)this.model.Image.Clone());
                this.undoRedo.ClearRedoStack();

                ConvFilters.Sharpen(this.model.Image, (int)this.filterParam);
                this.view.RedrawInvoker();

            }).Start();
        }

        public void Undo()
        {
            Bitmap temp = this.undoRedo.Undo(this.model.Image);

            if (temp != null)
            {
                this.model.Image = temp;
                this.view.Image = this.model.Image;
                this.view.Redraw();
            }
        }

        public void Redo()
        {
            Bitmap temp = this.undoRedo.Redo(this.model.Image);

            if (temp != null)
            {
                this.model.Image = temp;
                this.view.Image = this.model.Image;
                this.view.Redraw();
            }
        }

        public void Grayscale()
        {
            this.undoRedo.PushToUndoStack((Bitmap)this.model.Image.Clone());
            this.undoRedo.ClearRedoStack();

            new Thread(() =>
            {
                this.undoRedo.PushToUndoStack((Bitmap)this.model.Image.Clone());
                this.undoRedo.ClearRedoStack();

                BasicFilters.GrayscaleMarshal(this.model.Image);
                this.view.RedrawInvoker();

            }).Start();        
        }

        public void Carve()
        {
            this.undoRedo.PushToUndoStack((Bitmap)this.model.Image.Clone());
            this.undoRedo.ClearRedoStack();

            
            new Thread(() =>
            {
                for (int i = 0; i < this.filterParam; i++)
                {
                    SeamCarving s = new SeamCarving(this.model.Image);
                    s.Prepare();

                    this.model.Image = s.GetCarvedBitmap();
                    this.view.Image = this.model.Image;
                    this.view.RedrawImageOnly();


                    this.view.ImageInfo = this.model.Image.Width + "x" + this.model.Image.Height;
                }
                this.view.RedrawInvoker();

            }).Start();
        }

        public void Color(int r, int g, int b)
        {
            this.undoRedo.PushToUndoStack((Bitmap)this.model.Image.Clone());
            this.undoRedo.ClearRedoStack();

            new Thread(() =>
            {
                this.undoRedo.PushToUndoStack((Bitmap)this.model.Image.Clone());
                this.undoRedo.ClearRedoStack();

                BasicFilters.Color(this.model.Image, r, g, b);
                this.view.RedrawInvoker();

            }).Start();
        }

        public void Gamma(double r, double g, double b)
        {
            this.undoRedo.PushToUndoStack((Bitmap)this.model.Image.Clone());
            this.undoRedo.ClearRedoStack();

            new Thread(() =>
            {
                this.undoRedo.PushToUndoStack((Bitmap)this.model.Image.Clone());
                this.undoRedo.ClearRedoStack();

                BasicFilters.Gamma(this.model.Image, r, g, b);
                this.view.RedrawInvoker();

            }).Start();
        }

        public void EdgeEnhance()
        {
            new Thread(() =>
            {
                this.undoRedo.PushToUndoStack((Bitmap)this.model.Image.Clone());
                this.undoRedo.ClearRedoStack();

                BasicFilters.EdgeEnhance(this.model.Image, (byte)this.filterParam);
                this.view.RedrawInvoker();

            }).Start();
        }

        public void Flip()
        {
            this.undoRedo.PushToUndoStack((Bitmap)this.model.Image.Clone());
            this.undoRedo.ClearRedoStack();

            new Thread(() =>
            {
                this.undoRedo.PushToUndoStack((Bitmap)this.model.Image.Clone());
                this.undoRedo.ClearRedoStack();

                if (this.filterParam == 1.0)
                    DispFilters.Flip(this.model.Image, true, false);
                else
                    DispFilters.Flip(this.model.Image, false, true);
                this.view.RedrawInvoker();

            }).Start();
        }

        public void Swirl()
        {
            this.undoRedo.PushToUndoStack((Bitmap)this.model.Image.Clone());
            this.undoRedo.ClearRedoStack();

            new Thread(() =>
            {
                this.undoRedo.PushToUndoStack((Bitmap)this.model.Image.Clone());
                this.undoRedo.ClearRedoStack();

                DispFilters.Swirl(this.model.Image, this.filterParam, this.displacementSmooth);
                this.view.RedrawInvoker();

            }).Start();
        }

        public void Sphere()
        {
            this.undoRedo.PushToUndoStack((Bitmap)this.model.Image.Clone());
            this.undoRedo.ClearRedoStack();

            new Thread(() =>
            {
                this.undoRedo.PushToUndoStack((Bitmap)this.model.Image.Clone());
                this.undoRedo.ClearRedoStack();

                DispFilters.Sphere(this.model.Image, this.displacementSmooth);
                this.view.RedrawInvoker();

            }).Start();
        }

        public void TimeWarp()
        {
            this.undoRedo.PushToUndoStack((Bitmap)this.model.Image.Clone());
            this.undoRedo.ClearRedoStack();

            new Thread(() =>
            {
                this.undoRedo.PushToUndoStack((Bitmap)this.model.Image.Clone());
                this.undoRedo.ClearRedoStack();

                DispFilters.TimeWarp(this.model.Image, (byte)this.filterParam, this.displacementSmooth);
                this.view.RedrawInvoker();

            }).Start();
        }

        public void Pixelate()
        {
            this.undoRedo.PushToUndoStack((Bitmap)this.model.Image.Clone());
            this.undoRedo.ClearRedoStack();

            new Thread(() =>
            {
                this.undoRedo.PushToUndoStack((Bitmap)this.model.Image.Clone());
                this.undoRedo.ClearRedoStack();

                DispFilters.Pixelate(this.model.Image, (short)this.filterParam, this.displacementSmooth);
                this.view.RedrawInvoker();

            }).Start();
        }
    }
}
