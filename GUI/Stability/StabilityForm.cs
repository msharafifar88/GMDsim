using persistent.stability;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.Stability
{
    public class StabilityForm : Form
    {
        public IStability stability;
        public StabilityForm()
        {
            base.TopLevel = false;
            base.Dock = DockStyle.Fill;
            base.FormBorderStyle = FormBorderStyle.None;
        }
        public IStability GetStability() {
            return stability;
        }
    }
}
