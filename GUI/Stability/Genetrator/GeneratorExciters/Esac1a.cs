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

namespace GUI.Stability.GeneratorExciters
{
    public partial class Esac1a : StabilityForm
    {
        private ESAC1A eSAC1A;
        public Esac1a()
        {
            InitializeComponent();
            eSAC1A = new ESAC1A();
            base.stability = eSAC1A;
        }

       
    }
}
