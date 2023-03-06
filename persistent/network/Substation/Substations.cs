using bases;

namespace persistent.network
{
    public class Substations : BaseEntity
    {

        public long Substation_Number { get; set; } = 0l;
        public string Substation_Name { get; set; } = " Bus_Substation";
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double GroundGridResistance { get; set; }
    }
}
