using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessor.View
{
    public interface IView
    {
        void AddListener(Controller.IController controller);
        System.Drawing.Image Image { get; set; }
        string ImageInfo { set;}

        void RedrawInvoker();
        void Redraw();

    }
}
