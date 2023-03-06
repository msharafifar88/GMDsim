using bases;

namespace persistent.network.Transformers
{
    public class MVALimits : BaseEntity
    {
        public double PrimaryNominal { set; get; } = 1000d;
        public double SecendrayNominal { set; get; } = 1000d;
        public double TertiaryNominal { set; get; } = 1000d;
        public double PrimarySummer { set; get; } = 1000d;
        public double SecendraySummer { set; get; } = 1000d;
        public double TertiarySummer { set; get; } = 1000d;
        public double PrimaryWinter { set; get; } = 1000d;
        public double SecendrayWinter { set; get; } = 1000d;
        public double TertiaryWinter { set; get; } = 1000d;
        public double PrimarySummerEmergancy { set; get; } = 1000d;
        public double SecendraySummerEmergancy { set; get; } = 1000d;
        public double TertiarySummerEmergancy { set; get; } = 1000d;
        public double PrimaryWinterEmergancy { set; get; } = 1000d;
        public double SecendrayWinterEmergancy { set; get; } = 1000d;
        public double TertiaryWinterEmergancy { set; get; } = 1000d;

        public InsulationType insulationType { get; set; }
        public CoolingClass coolingClass { get; set; }
        public BIL bil { get; set; }
        public TempRiseClass tempRise { get; set; }
    }
}
