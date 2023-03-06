using areaandzone;
using DAO;
using persistent;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BL
{
    public class AreaBL : AbstractBL<Area>
    {
        AreaDA areaDA = new AreaDA();

        public void createArea(Area area)
        {
            areaDA.Create(area);
        }
        public List<Area> loadAll()
        {
            return areaDA.loadAll();
        }
        public void editarea(Area area)
        {
            areaDA.Update(area);
        }
        public void removeArea(Area area)
        {
            areaDA.Delete(area);
        }

        public Area addArea()
        {
            Area area = new Area();
            string name = area.Name;
            long code = area.Number;
            List<Area> areas = loadAll();
            if (areas.Count() == 0)
            {
                name = name + " " + code;

            }
            else
            {
                foreach (Area a in areas)
                {
                    if (a.Number >= code)
                    {
                        code = a.Number + 1;
                    }
                }
                name = name + " " + code;
            }

            area.Name = name;
            area.Number = code;

            createArea(area);

            return area;
        }

        public override Area findByID(Case cases, long ID)
        {
            throw new NotImplementedException();
        }
    }
}
