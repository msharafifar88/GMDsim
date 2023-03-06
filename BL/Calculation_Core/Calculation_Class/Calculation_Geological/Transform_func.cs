using BL.Geo_Zone_BL;
using persistent.network.Geo_Zone;
using System.Collections.Generic;
using System.Linq;

namespace BL.Calculation_Core.Calculation_Class.Calculation_Geological
{



    public class Transform_func
    {
        GeoZone_BL geoZone_BL;
        List<GeoZone> geoZone = new List<GeoZone>();
        List<GeoZone_Property> geoZone_Properties = new List<GeoZone_Property>();
        int Num_geo = 0;

        public Transform_func(List<GeoZone> geoZones_, List<GeoZone_Property> geoProperties_)
        {
            geoZone_Properties = geoProperties_;
            geoZone = geoZones_;
            Num_geo = geoZones_.Count();

            List<GeoZone_Property> proprty = new List<GeoZone_Property>();
            List<double> tika = new List<double>();
            for (int i = 0; i < Num_geo; i++)
            {
                GeoZone_Property caltik = geoZone_Properties[i];
                var tik = geoZone_Properties[i].Thikness;
                var ro = geoZone_Properties[i].Ro;
                tika[i] = tik;
                proprty[i].Ro = ro;

            }
        }
    }

}
