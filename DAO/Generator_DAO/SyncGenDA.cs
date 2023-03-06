using network.generator.Gentype;
using persistent;
using System.Collections.Generic;
using System.Linq;

namespace DAO
{
    public class SyncGenDA : AbstractDA<SyncGen>
    {
        public void create(SyncGen syncGen, Case cases)
        {
            if (false)
            {
                GmdsimModel gmdsimModel = new GmdsimModel();
                gmdsimModel.SyncGens.Add(syncGen);
                gmdsimModel.SaveChanges();
            }
            else
            {
                syncGen.ID = findLastId(loadAll(cases));
                DataStored.addSyncGen(syncGen, cases);
            }
        }

        public void update(SyncGen syncGen, Case cases)
        {
            if (false)
            {
                GmdsimModel gmdsimModel = new GmdsimModel();
                gmdsimModel.SyncGens.Add(syncGen);
                gmdsimModel.SaveChanges();
            }
            else
            {
                DataStored.editSyncGen(syncGen, cases);
            }
        }

        public void delete(SyncGen syncGen, Case cases)
        {
            if (false)
            {
                GmdsimModel gmdsimModel = new GmdsimModel();
                gmdsimModel.Generators.Remove(syncGen);
                gmdsimModel.SaveChanges();
            }
            else
            {
                DataStored.removeSyncGen(syncGen, cases);
            }
        }

        public List<SyncGen> loadAll(Case cases)
        {
            return DataStored.findAllSyncGen(cases).ToList();
        }

        public SyncGen findByID(Case cases, long ID)
        {
            List<SyncGen> syncGens = loadAll(cases);
            foreach (SyncGen gen in syncGens)
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
