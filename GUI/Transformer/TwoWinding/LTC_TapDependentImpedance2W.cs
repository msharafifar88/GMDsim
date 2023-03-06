using network;
using persistent.enumeration.Transformer;
using persistent.network.Transformers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.Transformer
{
    public partial class LTC_TapDependentImpedance2W : Form
    {
        MainTransformers transformers;
        
        public LTC_TapDependentImpedance2W(MainTransformers transformer, string mode = "X1/R1")
        {
            InitializeComponent();
          
            this.transformers = transformer;
            this.TapSideCombo.DataSource = Enum.GetValues(typeof(TransformerTapSide2W)).Cast<TransformerTapSide>().ToList();
            this.label33.Text = (mode.Contains("X1/R1") ? "X1/R1" : "PSC");
            LoadData();
        }
        public void LoadData()
        {
            TapDependentImpedance dependentImpedance = transformers.ltccontrol.dependentImpedance;

            label_Z1_HVLV.Text = MAX_Z1_HV_LV.Text =MIN_Z1_HV_LV.Text = transformers.impedances.Z1_HVLV.ToString();
           
            label_PSC_HVLV.Text = MAX_PSC_HV_LV.Text =MIN_PSC_HV_LV.Text = transformers.impedances.Psc_HVLV.ToString();
 
            label_Z0_HVLV.Text = MAX_Z0_HV_LV.Text = MIN_Z0_HV_LV.Text = transformers.impedances.Z0_HVLV.ToString();
 
            label_X0_HVLV.Text =  MAX_X0R0_HV_LV.Text = MIN_X0R0_HV_LV.Text = transformers.impedances.X0_HVLV.ToString();

        }
    }
}
