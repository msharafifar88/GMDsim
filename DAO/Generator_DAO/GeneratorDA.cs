using network;
using persistent;
using System.Collections.Generic;
using System.Linq;

namespace DAO
{
    public class GeneratorDA : AbstractDA<Generator>
    {

        public void create(Generator generator, Case cases)
        {
            if (false)
            {
                GmdsimModel gmdsimModel = new GmdsimModel();
                gmdsimModel.Generators.Add(generator);
                gmdsimModel.SaveChanges();
            }
            else
            {
                generator.ID = findLastId(loadAll(cases));
                DataStored.addGenerator(generator, cases);
            }
        }

        public void update(Generator generator, Case cases)
        {
            if (false)
            {
                GmdsimModel gmdsimModel = new GmdsimModel();
                gmdsimModel.Generators.Add(generator);
                gmdsimModel.SaveChanges();
            }
            else
            {
                DataStored.editGenerator(generator, cases);
            }
        }

        public void delete(Generator generator, Case cases)
        {
            if (false)
            {
                GmdsimModel gmdsimModel = new GmdsimModel();
                gmdsimModel.Generators.Remove(generator);
                gmdsimModel.SaveChanges();
            }
            else
            {
                DataStored.removeGenerator(generator, cases);
            }
        }

        public List<Generator> loadAll(Case cases)
        {
            return DataStored.findAllGenerator(cases).ToList();
        }

        public Generator findByID(Case cases, long ID)
        {
            List<Generator> generators = loadAll(cases);
            foreach (Generator gen in generators)
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
