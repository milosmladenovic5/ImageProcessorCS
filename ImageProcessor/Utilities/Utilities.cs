using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageProcessor.Utilities
{
    public static class Utilities
    {
        public static double GetParameters(string formText, string labelText)
        {
            double val = 0;

            Parameters.label = labelText;

            using (var form = new Parameters())
            {
                form.Name = formText;
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    val = form.val;
                }
            }

            return val;
        }

        public static int Clamp(int value, int min, int max)
        {
            return (value < min) ? min : (value > max) ? max : value;
        }

    }
}
