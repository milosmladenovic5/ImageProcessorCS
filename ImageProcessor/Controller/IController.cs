using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessor.Controller
{
    public interface IController
    {
        double FilterParam { get; set; }
        void LoadImage();
        void SaveImage();

        void Brightness();
        void Contrast();
        void Water();
        void EdgeDetect();
        void GaussianBlur();
        void Sharpen();

        void Undo();
        void Redo();
    }
}
