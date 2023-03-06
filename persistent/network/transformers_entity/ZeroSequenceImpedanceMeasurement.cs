using persistent.enumeration.Transformer;

namespace persistent.network.Transformers
{
    public class ZeroSequenceImpedanceMeasurement
    {
        public double Z0 { get; set; }
        public double X0_R0 { get; set; }
        public ExcitedWindingEnum excitedWindingEnum { get; set; }
    }
}
