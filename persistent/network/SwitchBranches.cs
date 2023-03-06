using areaandzone;
using bases;

namespace network
{
    public class SwitchBranches : BaseEntity
    {
        public string name { get; set; }
        public long number { get; set; }
        public Area area { get; set; }
        public Zone zone { get; set; }
    }
}
