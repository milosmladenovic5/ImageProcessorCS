using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessor.Model
{
    /// <summary>
    /// 
    /// </summary>
    public interface IModel
    {
        Bitmap Image { get; set; }
        string ImageInfo { get; set; }

        void Load();

        void Save();
    }
}
