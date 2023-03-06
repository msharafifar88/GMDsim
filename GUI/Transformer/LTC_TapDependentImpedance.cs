using network;
using persistent.enumeration.Transformer;
using persistent.network.Transformers;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace GUI.Transformer
{
    public partial class LTC_TapDependentImpedance : Form
    {
        MainTransformers transformers;


        public LTC_TapDependentImpedance(MainTransformers transformer)
        {
            InitializeComponent();

            this.transformers = transformer;
            this.TapSideCombo.DataSource = Enum.GetValues(typeof(TransformerTapSide)).Cast<TransformerTapSide>().ToList();
            LoadData();
        }
        public void LoadData()
        {
            TapDependentImpedance dependentImpedance = transformers.ltccontrol.dependentImpedance;

            label_Z1_HVLV.Text = MAX_Z1_HV_LV.Text = MIN_Z1_HV_LV.Text = transformers.impedances.Z1_HVLV.ToString();
            label_Z1_HVTV.Text = MAX_Z1_HV_TV.Text = MIN_Z1_HV_TV.Text = transformers.impedances.Z1_HVTV.ToString();
            label_Z1_LVTV.Text = MAX_Z1_LV_TV.Text = MIN_Z1_LV_TV.Text = transformers.impedances.Z1_LVTV.ToString();

            label_PSC_HVLV.Text = MAX_PSC_HV_LV.Text = MIN_PSC_HV_LV.Text = transformers.impedances.Psc_HVLV.ToString();
            label_PSC_HVTV.Text = MAX_PSC_HV_TV.Text = MIN_PSC_HV_TV.Text = transformers.impedances.Psc_HVTV.ToString();
            label_PSC_LVTV.Text = MAX_PSC_LV_TV.Text = MIN_PSC_LV_TV.Text = transformers.impedances.Psc_LVTV.ToString();

            label_Z0_HVLV.Text = MAX_Z0_HV_LV.Text = MIN_Z0_HV_LV.Text = transformers.impedances.Z0_HVLV.ToString();
            label_Z0_HVTV.Text = MAX_Z0_HV_TV.Text = MIN_Z0_HV_TV.Text = transformers.impedances.Z0_HVTV.ToString();
            label_Z0_LVTV.Text = MAX_Z0_LV_TV.Text = MIN_Z0_LV_TV.Text = transformers.impedances.Z0_LVTV.ToString();

            label_X0_HVLV.Text = MAX_X0R0_HV_LV.Text = MIN_X0R0_HV_LV.Text = transformers.impedances.X0_HVLV.ToString();
            label_X0_HVTV.Text = MAX_X0R0_HV_TV.Text = MIN_X0R0_HV_TV.Text = transformers.impedances.X0_HVTV.ToString();
            label_X0_LVTV.Text = MAX_X0R0_LV_TV.Text = MIN_X0R0_LV_TV.Text = transformers.impedances.X0_LVTV.ToString();

            /*   label_R0_HVLV.Text = MAX_X0R0_HV_LV.Text = MIN_X0R0_HV_LV.Text = transformers.impedances.R0_HVLV.ToString();
               label_R0_HVTV.Text = MAX_X0R0_HV_TV.Text = MIN_X0R0_HV_TV.Text = transformers.impedances.R0_HVTV.ToString();
               label_R0_LVTV.Text = MAX_X0R0_LV_TV.Text = MIN_X0R0_LV_TV.Text = transformers.impedances.R0_LVTV.ToString();*/
        }

    }
}
