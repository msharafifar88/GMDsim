using areaandzone;
using System.Collections.Generic;
using System.Linq;

namespace DAO
{
    public class AreaDA
    {
        public void Create(Area area)
        {
            if (false)
            {
                GmdsimModel gmdsimModel = new GmdsimModel();
                gmdsimModel.Areas.Add(area);
                gmdsimModel.SaveChanges();
            }
            else

            {
                DataStored.addArea(area);
            }
        }

        public void Update(Area area)
        {
            if (false)
            {
                GmdsimModel gmdsimModel = new GmdsimModel();
                gmdsimModel.Areas.Add(area);
                gmdsimModel.SaveChanges();
            }
            else
            {
                DataStored.addArea(area);

            }

        }

        public void Delete(Area area)
        {
            if (false)
            {
                GmdsimModel gmdsimModel = new GmdsimModel();
                gmdsimModel.Areas.Remove(area);
                gmdsimModel.SaveChanges();
            }
            else
            {
                DataStored.removeArea(area);
            }

        }
        public List<Area> loadAll()
        {
            return DataStored.findAllArea().ToList();
        }
    }
}
