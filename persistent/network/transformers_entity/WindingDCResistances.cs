using bases;

namespace persistent.network.Transformers
{
    public class WindingDCResistances : BaseEntity
    {
        public double HV { get; set; }
        public double LV { get; set; }
        public double TV { get; set; }
    }
}
