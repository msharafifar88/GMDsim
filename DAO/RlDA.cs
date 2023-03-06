using network;
using persistent;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace DAO
{
    public class RlDA : AbstractDA<RL>
    {
        public void Create(RL rl, Case cases)
        {
            if (false)
            {
                GmdsimModel gmdsimModel = new GmdsimModel();
                gmdsimModel.RLs.Add(rl);
                gmdsimModel.SaveChanges();
            }
            else
            {
                rl.ID = findLastId(loadAll(cases));
                DataStored.addRL(rl, cases);
            }
        }

        public void Update(RL rl, Case cases)
        {
            if (false)
            {
                GmdsimModel gmdsimModel = new GmdsimModel();
                gmdsimModel.RLs.AddOrUpdate(rl);
                gmdsimModel.SaveChanges();
            }
            else
            {
                DataStored.editRL(rl, cases);
            }
        }

        public void Delete(RL rl, Case cases)
        {
            if (false)
            {
                GmdsimModel gmdsimModel = new GmdsimModel();
                gmdsimModel.RLs.Remove(rl);
                gmdsimModel.SaveChanges();
            }
            else
            {
                DataStored.removeRL(rl, cases);
            }

        }
        public List<RL> loadAll(Case cases)
        {
            return DataStored.findAllRL(cases).ToList();
        }

        public RL findByID(Case cases, long ID)
        {
            List<RL> rlList = loadAll(cases);
            foreach (RL rl in rlList)
            {
                if (rl.ID == ID)
                {
                    return rl;
                }
            }
            return null;
        }
    }
}
