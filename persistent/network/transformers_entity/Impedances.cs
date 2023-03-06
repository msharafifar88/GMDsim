using bases;

namespace persistent.network.Transformers
{
    public class Impedances : BaseEntity
    {
        /// <summary>
        ///  Positive - Sequence Impedances
        /// </summary>
        /// 
        public bool checkPsc { get; set; }
        public bool checkR1X1 { get; set; }
        public bool checkNoLoad { get; set; }
        public bool checkMagnetization { get; set; }
        public double Z1_HVLV { get; set; } = 5.8d;
        public double Z1_HVTV { get; set; } = 10.1d;
        public double Z1_LVTV { get; set; } = 3.5d;
        /* */
        public bool PSC { get; set; } = true;
        public bool X1R1 { get; set; } = false;

        /**/

        public double Psc_HVLV { get; set; } = 35.0d;
        public double Psc_HVTV { get; set; } = 35.0d;
        public double Psc_LVTV { get; set; } = 35.0d;
        /// <summary>
        /// Zero - Sequence Impedances
        /// </summary>

        public double X1_HVLV { get; set; } = 35.0d;
        public double X1_HVTV { get; set; } = 35.0d;
        public double X1_LVTV { get; set; } = 35.0d;

        public double R1_HVLV { get; set; } = 35.0d;
        public double R1_HVTV { get; set; } = 35.0d;
        public double R1_LVTV { get; set; } = 35.0d;

        public double Z0_HVLV { get; set; } = 3.5d;
        public double Z0_HVTV { get; set; } = 10.1d;
        public double Z0_LVTV { get; set; } = 5.8d;

        public double X0_HVLV { get; set; } = 35.0d;
        public double X0_HVTV { get; set; } = 35.0d;
        public double X0_LVTV { get; set; } = 35.0d;
        public double R0_HVLV { get; set; } = 35.0d;
        public double R0_HVTV { get; set; } = 35.0d;
        public double R0_LVTV { get; set; } = 35.0d;
        /// <summary>
        /// Linear Magnetization Branch
        /// </summary>

        public double Magnetization_Conductance { get; set; } = 0d;
        public double Magnetization_Susceptance { get; set; } = 0d;

        public double NoLosses { get; set; } = 0d;
        public double MagnetizConductace_Current { get; set; } = 0d;

        /// <summary>
        ///  Geounding Impedances
        /// </summary>
        public double RG_HVLV { get; set; } = 0d;
        public double RG_HVTV { get; set; } = 0d;
        public double RG_LVTV { get; set; } = 0d;

        public double XG_HVLV { get; set; } = 0d;
        public double XG_HVTV { get; set; } = 0d;
        public double XG_LVTV { get; set; } = 0d;

    }
}
