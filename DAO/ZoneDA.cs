using areaandzone;
using System.Collections.Generic;
using System.Linq;

namespace DAO
{
    public class ZoneDA
    {
        public void Create(Zone zone)
        {
            if (false)
            {
                GmdsimModel gmdsimModel = new GmdsimModel();
                gmdsimModel.Zones.Add(zone);
                gmdsimModel.SaveChanges();
            }
            else
            {
                DataStored.addZone(zone);
            }
        }

        public void Update(Zone zone)
        {
            if (false)
            {
                GmdsimModel gmdsimModel = new GmdsimModel();
                gmdsimModel.Zones.Add(zone);
                gmdsimModel.SaveChanges();
            }
            else
            {
                DataStored.addZone(zone);

            }

        }

        public void Delete(Zone zone)
        {
            if (false)
            {
                GmdsimModel gmdsimModel = new GmdsimModel();
                gmdsimModel.Zones.Remove(zone);
                gmdsimModel.SaveChanges();
            }
            else
            {
                DataStored.removeZone(zone);
            }

        }
        public List<Zone> loadAll()
        {
            return DataStored.findAllZone().ToList();
        }
    }
}
