using areaandzone;
using bases;

namespace network
{
    public class RLCbranches : BaseEntity
    {
        public string name { get; set; }
        public long number { get; set; } = 1L;
        public float nominalFrequency { get; set; } = 60;
        public string branch { get; set; }
        public bool rOfFrequency { get; set; } = false;
        public bool voltage { get; set; } = false;
        public bool current { get; set; } = false;
        public bool power { get; set; } = false;
        public Area area { get; set; }
        public Zone zone { get; set; }
        public Bus Bus { get; set; }

    }
}
