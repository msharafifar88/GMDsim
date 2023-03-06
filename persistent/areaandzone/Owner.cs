using bases;

namespace areaandzone
{
    public class Owner : BaseEntity
    {
        public float Percentage { get; set; } = 100.00f;
        public long Number { get; set; } = 1l;
        public string Name { get; set; } = "owner";
    }
}
