using network.generator.Gentype;
using persistent;
using System.Collections.Generic;
using System.Linq;

namespace DAO.Generator_DAO
{
    public class PVGenDA : AbstractDA<PVGen>
    {
        public void create(PVGen pvGen, Case cases)
        {
            if (false)
            {
                GmdsimModel gmdsimModel = new GmdsimModel();
                gmdsimModel.PVGens.Add(pvGen);
                gmdsimModel.SaveChanges();
            }
            else
            {
                pvGen.ID = findLastId(loadAll(cases));
                DataStored.addPVGen(pvGen, cases);
            }
        }

        public void update(PVGen pvGen, Case cases)
        {
            if (false)
            {
                GmdsimModel gmdsimModel = new GmdsimModel();
                gmdsimModel.PVGens.Add(pvGen);
                gmdsimModel.SaveChanges();
            }
            else
            {
                DataStored.editPVGen(pvGen, cases);
            }
        }

        public void delete(PVGen pvGen, Case cases)
        {
            if (false)
            {
                GmdsimModel gmdsimModel = new GmdsimModel();
                gmdsimModel.PVGens.Remove(pvGen);
                gmdsimModel.SaveChanges();
            }
            else
            {
                DataStored.removePVGen(pvGen, cases);
            }
        }

        public List<PVGen> loadAll(Case cases)
        {
            return DataStored.findAllPVGen(cases).ToList();
        }

        public PVGen findByID(Case cases, long ID)
        {
            List<PVGen> pvGens = loadAll(cases);
            foreach (PVGen pgen in pvGens)
            {
                if (pgen.ID == ID)
                {
                    return pgen;
                }
            }
            return null;
        }
    }
}
