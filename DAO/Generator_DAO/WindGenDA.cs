using network.generator.Gentype;
using persistent;
using System.Collections.Generic;
using System.Linq;

namespace DAO
{
    public class WindGenDA : AbstractDA<WindGen>
    {
        public void create(WindGen windGen, Case cases)
        {
            if (false)
            {
                GmdsimModel gmdsimModel = new GmdsimModel();
                gmdsimModel.WindGens.Add(windGen);
                gmdsimModel.SaveChanges();
            }
            else
            {
                windGen.ID = findLastId(loadAll(cases));
                DataStored.addwindGen(windGen, cases);
            }
        }

        public void update(WindGen windGen, Case cases)
        {
            if (false)
            {
                GmdsimModel gmdsimModel = new GmdsimModel();
                gmdsimModel.WindGens.Add(windGen);
                gmdsimModel.SaveChanges();
            }
            else
            {
                DataStored.editWindGen(windGen, cases);
            }
        }

        public void delete(WindGen windGen, Case cases)
        {
            if (false)
            {
                GmdsimModel gmdsimModel = new GmdsimModel();
                gmdsimModel.WindGens.Remove(windGen);
                gmdsimModel.SaveChanges();
            }
            else
            {
                DataStored.removeWindGen(windGen, cases);
            }
        }

        public List<WindGen> loadAll(Case cases)
        {
            return DataStored.findAllWindGen(cases).ToList();
        }

        public WindGen findByID(Case cases, long ID)
        {
            List<WindGen> windGen = loadAll(cases);
            foreach (WindGen gen in windGen)
            {
                if (gen.ID == ID)
                {
                    return gen;
                }
            }
            return null;
        }
    }
}
