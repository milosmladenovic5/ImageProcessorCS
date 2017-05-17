using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageProcessor
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            MainWindow view = new MainWindow();
            Model.IModel model = new Model.ImageModel();
            Controller.IController controller = new Controller.Controller(view, model);

            Application.Run(view);
        }
    }
}
