using bases;

namespace persistent.network.Transformers
{
    public class Topology : BaseEntity
    {
        public double YMArea { get; set; } = 1.0d;
        public double YMAlength { get; set; } = 1.1;
        public double RMArea { get; set; } = 1.5d;
        public double RMAlength { get; set; } = 0.5;
        public double CtoTAirgap { get; set; } = 3.5d;
        public double TSL { get; set; } = 0.4d;
        public double AirHV { get; set; } = 0.22;
        public double AirLV { get; set; } = 0.11d;
        public double AirTV { get; set; } = 0.39d;
    }
}
