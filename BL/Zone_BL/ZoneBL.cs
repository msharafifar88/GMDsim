using areaandzone;
using DAO;
using persistent;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BL
{
    public class ZoneBL : AbstractBL<Zone>
    {
        ZoneDA zoneDA = new ZoneDA();

        public void createZone(Zone zone)
        {
            zoneDA.Create(zone);
        }
        public List<Zone> loadAll()
        {
            return zoneDA.loadAll();
        }
        public void editZone(Zone zone)
        {
            zoneDA.Update(zone);
        }
        public void removeZone(Zone zone)
        {
            zoneDA.Delete(zone);
        }

        public Zone addZone()
        {
            Zone zone = new Zone();
            string name = zone.Name;
            long code = zone.Number;
            List<Zone> zones = loadAll();
            if (zones.Count() == 0)
            {
                name = name + " " + code;

            }
            else
            {
                foreach (Zone z in zones)
                {
                    if (z.Number >= code)
                    {
                        code = z.Number + 1;
                    }
                }
                name = name + " " + code;
            }

            zone.Name = name;
            zone.Number = code;

            createZone(zone);

            return zone;
        }

        public override Zone findByID(Case cases, long ID)
        {
            throw new NotImplementedException();
        }
    }
}
