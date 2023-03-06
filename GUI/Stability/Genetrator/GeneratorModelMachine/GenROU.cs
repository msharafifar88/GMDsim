using persistent.stability;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.Stability.Generator_Stability
{
    public partial class GenROU : StabilityForm
    {
        private GENROE genROU;
        public GenROU()
        {
            InitializeComponent();
            
            genROU = new GENROE();
            base.stability = genROU;
        }


    }
}
