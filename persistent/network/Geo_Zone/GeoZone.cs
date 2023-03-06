using areaandzone;
using bases;
using System.Collections.Generic;

namespace persistent.network.Geo_Zone
{
    public class GeoZone : BaseEntity
    {
        public string Name { get; set; }
        public long Number { get; set; }
        // Geo Zone Calvulation

        public double Geozone_Start_Num { get; set; } = 0.1d;
        public double Geozone_End_Num { get; set; } = 1.0d;
        public long Geozone_point { get; set; } = 2000;
        public bool logarithmic_range { get; set; } = true;
        public bool Linear_range { get; set; } = false;
        public bool Function_Order { get; set; } = false;
        public int Function_Order_number { get; set; } = 10;

        public List<GeoZone_Property> geoZone_Properties { get; set; } = new List<GeoZone_Property>();
        public List<GeoZone_location> geoZone_Locations { get; set; } = new List<GeoZone_location>();

        public Zone zone { get; set; }
        public Area area { get; set; }
        public List<Owner> owners { get; set; } = new List<Owner>();

    }
}
