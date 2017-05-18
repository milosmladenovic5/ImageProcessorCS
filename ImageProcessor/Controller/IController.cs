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
        bool DisplacementSmooth { get; set; }
        void LoadImage();
        void SaveImage();

        void Brightness();
        void Contrast();
        void Water();
        void EdgeDetect();
        void GaussianBlur();
        void Sharpen();
        void Grayscale();
        void Color(int r, int g, int b);
        void Gamma(double r, double g, double b);
        void EdgeEnhance();
        void Flip();
        void Swirl();
        void Sphere();
        void TimeWarp();
        void Pixelate();

        void Carve();

        void Undo();
        void Redo();
    }
}
