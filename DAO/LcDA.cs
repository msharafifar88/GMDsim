using network;
using persistent;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace DAO
{
    public class LcDA : AbstractDA<LC>
    {
        public void Create(LC lc, Case cases)
        {
            if (false)
            {
                GmdsimModel gmdsimModel = new GmdsimModel();
                gmdsimModel.LCs.Add(lc);
                gmdsimModel.SaveChanges();
            }
            else
            {
                lc.ID = findLastId(loadAll(cases));
                DataStored.addLC(lc, cases);
            }
        }

        public void Update(LC lc, Case cases)
        {
            if (false)
            {
                GmdsimModel gmdsimModel = new GmdsimModel();
                gmdsimModel.LCs.AddOrUpdate(lc);
                gmdsimModel.SaveChanges();
            }
            else
            {
                DataStored.editLC(lc, cases);
            }
        }

        public void Delete(LC lc, Case cases)
        {
            if (false)
            {
                GmdsimModel gmdsimModel = new GmdsimModel();
                gmdsimModel.LCs.Remove(lc);
                gmdsimModel.SaveChanges();
            }
            else
            {
                DataStored.removeLC(lc, cases);
            }

        }
        public List<LC> loadAll(Case cases)
        {
            return DataStored.findAllLC(cases).ToList();
        }

        public LC findByID(Case cases, long ID)
        {
            List<LC> lcList = loadAll(cases);
            foreach (LC lc in lcList)
            {
                if (lc.ID == ID)
                {
                    return lc;
                }
            }
            return null;
        }
    }
}
