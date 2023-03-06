using persistent;
using persistent.network.Geo_Zone;
using System.Collections.Generic;
using System.Linq;

namespace DAO.GeoZone_DAO
{
    public class GeoZone_DA : AbstractDA<GeoZone>
    {
        public void Create(GeoZone geozone, Case cases)
        {
            if (canEditGeoZone(geozone, cases))
            {
                if (false)
                {
                    GmdsimModel gmdsimModel = new GmdsimModel();
                    gmdsimModel.GeoZones.Add(geozone);
                    gmdsimModel.SaveChanges();
                }
                else
                {

                    DataStored.addGeoZone(geozone);
                }
            }
        }



        public void Update(GeoZone geozone, Case cases)
        {
            if (false)
            {
                GmdsimModel gmdsimModel = new GmdsimModel();
                gmdsimModel.GeoZones.Add(geozone);
                gmdsimModel.SaveChanges();
            }
            else
            {
                DataStored.addGeoZone(geozone);

            }
        }

        public void Delete(GeoZone geozone, Case cases)
        {
            if (false)
            {
                GmdsimModel gmdsimModel = new GmdsimModel();
                gmdsimModel.GeoZones.Remove(geozone);
                gmdsimModel.SaveChanges();
            }
            else
            {
                DataStored.removeGeoZone(geozone);
            }
        }
        public List<GeoZone> loadAll(Case cases)
        {
            return DataStored.findAllGeoZone().ToList();
        }

        public GeoZone findByID(Case cases, long iD)
        {
            if (loadAll(cases).Count == 0)
            {
                return new GeoZone();

            }
            return loadAll(cases).Last();
        }
        private bool canEditGeoZone(GeoZone geozone, Case cases)
        {
            List<GeoZone> geozoneList = loadAll(cases);
            foreach (GeoZone geo in geozoneList)
            {
                if (geo.Name.Equals(geozone.Name) || geo.Number.Equals(geozone.Number))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
