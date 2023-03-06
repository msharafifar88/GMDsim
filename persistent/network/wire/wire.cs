using bases;
using persistent.enumeration;

namespace persistent.network.wire
{
    public class Wire : BaseEntity
    {
        public object from { get; set; }
        public object to { get; set; }
        public string Type { get; set; } = StabilityType.Bus.ToString();
        public float RwireIsolate { get; set; } = 100000000;
    }
}
