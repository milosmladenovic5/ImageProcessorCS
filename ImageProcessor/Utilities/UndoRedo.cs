using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ImageProcessor.Utilities
{
    public class UndoRedo
    {
        private List<Bitmap> undoStack;
        public List<Bitmap> redoStack;
        private int maxSize;

        public UndoRedo(int size)
        {
            this.undoStack = new List<Bitmap>(size);
            this.redoStack = new List<Bitmap>(size);
            this.maxSize = size;

        }
    
        public Bitmap Undo(Bitmap b)
        {
            Bitmap temp = null;
            if(this.undoStack.Count > 0)
            {
                PushToRedoStack((Bitmap)b.Clone());
                b.Dispose();
                temp = (Bitmap)this.undoStack[this.undoStack.Count - 1].Clone();
                this.undoStack.RemoveAt(this.undoStack.Count - 1);
                
            }

            return temp;
        }
        public Bitmap Redo(Bitmap b)
        {
            Bitmap temp = null;
            if (this.redoStack.Count > 0)
            {
                PushToUndoStack((Bitmap)b.Clone());
                b.Dispose();
                temp = (Bitmap)this.redoStack[this.redoStack.Count - 1].Clone();
                this.redoStack.RemoveAt(this.redoStack.Count - 1);
                       
            }
            return temp;
        }
        public void PushToUndoStack(Bitmap b)
        {
            if (this.undoStack.Count == this.maxSize)
            {
                this.undoStack.First().Dispose();
                this.undoStack.RemoveAt(0);
            }
            this.undoStack.Add(b);
        }
        public void PushToRedoStack(Bitmap b)
        {
            if (this.redoStack.Count == this.maxSize)
            {
                this.redoStack.First().Dispose();
                this.redoStack.RemoveAt(0);
            }
            this.redoStack.Add(b);
        }
        public void ClearStacks()
        {
            foreach (Bitmap b in this.undoStack)
                b.Dispose();
            foreach (Bitmap b in this.redoStack)
                b.Dispose();
        }

        public void ClearRedoStack()
        {
            foreach (Bitmap b in this.redoStack)
                b.Dispose();
            this.redoStack = new List<Bitmap>(this.maxSize);
        }
        public void ClearUndoStack()
        {
            foreach (Bitmap b in this.undoStack)
                b.Dispose();
            this.undoStack = new List<Bitmap>(this.maxSize);
        }

    }
}
