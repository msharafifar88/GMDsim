namespace persistent.network.Transformers
{
    public class TransformerImpedance
    {
        /// <summary>
        /// Positive sequence Impedances
        /// </summary>
        public double z1HVLV { get; set; } = 0;
        public double z1HVTV { get; set; } = 0;
        public double z1LVTV { get; set; } = 0;

        public double pscHVLV { get; set; } = 0;
        public double pscHVTV { get; set; } = 0;
        public double pscLVTV { get; set; } = 0;
        public double x1r1HVLV { get; set; } = 0;
        public double x1r1HVTV { get; set; } = 0;
        public double x1r1LVTV { get; set; } = 0;
        /// <summary>
        /// Zero sequence Impedances
        /// </summary>
        public double z0HVLV { get; set; } = 0;
        public double z0HVTV { get; set; } = 0;
        public double z0LVTV { get; set; } = 0;
        public double x0r0HVLV { get; set; } = 0;
        public double x0r0HVTV { get; set; } = 0;
        public double x0r0LVTV { get; set; } = 0;
        /// <summary>
        /// Linnear Magnetization Branch
        /// </summary>
        public double magnetizationConductance { get; set; } = 0;
        public double magnetizationSusceptance { get; set; } = 0;
        public double noLoadLoss { get; set; } = 0;
        public double magnetizationcurrent { get; set; } = 0;
        // Grounding Impedances
        public double rgHV { get; set; } = 0;
        public double rgLV { get; set; } = 0;
        public double rgTV { get; set; } = 0;
        public double xgHV { get; set; } = 0;
        public double xgLV { get; set; } = 0;
        public double xgTV { get; set; } = 0;


    }
}
