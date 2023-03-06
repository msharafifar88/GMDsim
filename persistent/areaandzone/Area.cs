using bases;
using persistent.common;

namespace areaandzone
{
    public class Area : BaseEntity, DeviceInterface
    {
        public string Name { get; set; } = "area";
        public long Number { get; set; } = 1l;

        public string getName()
        {
            return this.Name;
        }
        public long getCode()
        {
            return this.Number;
        }
    }
}
