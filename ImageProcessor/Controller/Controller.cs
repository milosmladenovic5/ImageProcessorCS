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

                DispFilters.Water(this.model.Image, (short)this.filterParam, false);
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
            throw new NotImplementedException();
        }

        public void Sharpen()
        {
            throw new NotImplementedException();
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
    }
}
