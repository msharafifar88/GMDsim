using bases;
using persistent.enumeration.Transformer;

namespace persistent.network.Transformers
{
    public class TapDependentImpedance : BaseEntity
    {
        public TransformerTapSide transformerTapSide { get; set; }

        public double MAX_Z1_HV_LV { get; set; }
        public double MAX_Z1_HV_TV { get; set; }
        public double MAX_Z1_LV_TV { get; set; }

        public double MAX_PSC_HV_LV { get; set; }
        public double MAX_PSC_HV_TV { get; set; }
        public double MAX_PSC_LV_TV { get; set; }

        public double MAX_Z0_HV_LV { get; set; }
        public double MAX_Z0_HV_TV { get; set; }
        public double MAX_Z0_LV_TV { get; set; }

        public double MAX_X0R0_HV_LV { get; set; }
        public double MAX_X0R0_HV_TV { get; set; }
        public double MAX_X0R0_LV_TV { get; set; }

        public double MIN_Z1_HV_LV { get; set; }
        public double MIN_Z1_HV_TV { get; set; }
        public double MIN_Z1_LV_TV { get; set; }

        public double MIN_PSC_HV_LV { get; set; }
        public double MIN_PSC_HV_TV { get; set; }
        public double MIN_PSC_LV_TV { get; set; }

        public double MIN_Z0_HV_LV { get; set; }
        public double MIN_Z0_HV_TV { get; set; }
        public double MIN_Z0_LV_TV { get; set; }

        public double MIN_X0R0_HV_LV { get; set; }
        public double MIN_X0R0_HV_TV { get; set; }
        public double MIN_X0R0_LV_TV { get; set; }



    }
}
