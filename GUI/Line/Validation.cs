using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.Line
{
    public class Validation : Form
    {

        public static void NumberValidation(object sender, KeyPressEventArgs e)
        {

            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8 && ch != 46 )
            {

                e.Handled = true;
            }
        }
    }
}