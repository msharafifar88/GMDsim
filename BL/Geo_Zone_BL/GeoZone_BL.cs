using areaandzone;
using DAO.GeoZone_DAO;
using persistent;
using persistent.network.Geo_Zone;
using System.Collections.Generic;
using System.Linq;

namespace BL.Geo_Zone_BL
{
    public class GeoZone_BL : AbstractBL<GeoZone>
    {
        GeoZone_DA geozoneDA = new GeoZone_DA();


        public void createGeozone(GeoZone geozone, Case cases)
        {

            geozoneDA.Create(geozone, cases);
        }
        public List<GeoZone> loadAll(Case cases)
        {
            return geozoneDA.loadAll(cases);
        }
        public void editGeozone(GeoZone geozone, Case cases)
        {


            // List<long> a = geozone.thickness;
            // List<long> b = geozone.Ro;

            geozoneDA.Update(geozone, cases);
        }
        public void removeGeozone(GeoZone geozone, Case Cases)
        {
            geozoneDA.Delete(geozone, Cases);
        }

        public override GeoZone findByID(Case cases, long ID)
        {
            return geozoneDA.findByID(cases, ID);
        }
        public GeoZone addGeoZone(Case cases)
        {
            GeoZone geozone = new GeoZone();

            string name = geozone.Name;
            long code = geozone.Number;
            List<GeoZone> geozones = loadAll(cases);
            if (geozones.Count() == 0)
            {
                name = name + " " + code;

            }
            else
            {
                foreach (GeoZone b in geozones)
                {
                    if (b.Number >= code)
                    {
                        code = b.Number + 1;
                    }
                }
                name = name + " " + code;
            }

            geozone.Name = name;
            geozone.Number = code;
            ZoneBL zoneBL = new ZoneBL();


            if (zoneBL.loadAll().Count == 0)
            {
                geozone.zone = zoneBL.addZone();
            }
            else
            {
                geozone.zone = zoneBL.loadAll()[0];
            }
            AreaBL areaBL = new AreaBL();

            if (areaBL.loadAll().Count == 0)
            {
                geozone.area = areaBL.addArea();
            }
            else
            {
                geozone.area = areaBL.loadAll()[0];
            }

            OwnerBL ownerBL = new OwnerBL();

            if (ownerBL.loadAll().Count == 0)
            {

                geozone.owners.Add(ownerBL.addOwner());
            }
            else
            {

                Owner o = ownerBL.loadAll()[0];
                geozone.owners.Add(o);
            }
            createGeozone(geozone, cases);

            return geozone;
        }

    }
}
