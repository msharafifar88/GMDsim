using bases;

namespace persistent.network.Transformers
{
    public class LTCControl : BaseEntity
    {  /// <summary>
       /// FIX NOMINAL 
       /// </summary>
        public float FIXPrimNominalTurnRateHV { get; set; } = 1;
        public float FIXSecNominalTurnRateLV { get; set; } = 1;
        public float FIXTerNominalTurnRateTV { get; set; } = 1;

        public float FIXPrimPhaseHV { get; set; } = 0;
        public float FIXSecPhaseLV { get; set; } = 0;
        public float FIXTerPhaseTV { get; set; } = 0;

        /// <summary>
        /// AVR
        /// </summary>
        public float AVRPrimNominalTurnRateHV { get; set; } = 0;
        public float AVRSecNominalTurnRateLV { get; set; } = 0;
        public float AVRerNominalTurnRateTV { get; set; } = 0;

        public double AVRHV { get; set; } = 0;
        public double AVIRLV { get; set; } = 0;
        public double AVRTV { get; set; } = 0;
        /// <summary>
        /// RPC
        /// </summary>
        public double RPCHV { get; set; } = 0;
        public double RPCLV { get; set; } = 0;
        public double RPCTV { get; set; } = 0;


        /// <summary>
        /// PSC
        /// </summary>
        public double PSCHV { get; set; } = 0;
        public double PSCLV { get; set; } = 0;
        public double PSCTV { get; set; } = 0;
        /// <summary>
        /// CW, CZ .CM
        public float CW { get; set; } = 1;
        public float CZ { get; set; } = 1;
        public float CM { get; set; } = 1;
        /// </summary>
        public LoadTapChanger tapChanger { get; set; } = new LoadTapChanger();
        public TapDependentImpedance dependentImpedance { get; set; } = new TapDependentImpedance();
    }
}

