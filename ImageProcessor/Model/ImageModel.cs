using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageProcessor.Model
{
    public class ImageModel : IModel
    {
        private Bitmap image;
        private string imageInfo;

        public ImageModel() { }
        public ImageModel(Bitmap img)
        {
            this.image = img;
        }


        public Bitmap Image
        {
            get
            {
                return image;
            }

            set
            {
                this.image = value;
            }
        }

        public string ImageInfo
        {
            get
            {
                return this.imageInfo;
            }

            set
            {
                this.imageInfo = value;
            }
        }
   
        public void Load()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            openFileDialog.InitialDirectory = path; /*"c:\\";*/
            openFileDialog.Filter = "Bitmap files (*.bmp)|*.bmp|Jpeg files (*.jpg)|*.jpg|GIF files(*.gif)|*.gif|PNG files(*.png)|*.png|All valid files|*.bmp/*.jpg/*.gif/*.png";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;

            if (DialogResult.OK == openFileDialog.ShowDialog())
            {
                this.image = (Bitmap)Bitmap.FromFile(openFileDialog.FileName, false);
                this.imageInfo = "File name: " + openFileDialog.FileName + " | Resolution: " + this.image.Width + " x " + this.image.Height;
            }
            else
                this.image = null;
        }

        public void Save()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            saveFileDialog.InitialDirectory = path;
            saveFileDialog.Filter = "Bitmap files (*.bmp)|*.bmp";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;

            if (DialogResult.OK == saveFileDialog.ShowDialog())
               image.Save(saveFileDialog.FileName, ImageFormat.Bmp);

        }
    }
}
