using bases;

namespace persistent.network.Transformers
{
    public class WindingCapacitances : BaseEntity
    {
        public double HV_Ground { get; set; }
        public double LV_Ground { get; set; }
        public double TV_Ground { get; set; }

        public double HV_LV { get; set; }
        public double HV_TV { get; set; }
        public double LV_TV { get; set; }
    }
}
