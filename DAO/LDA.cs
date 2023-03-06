using network;
using persistent;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace DAO
{
    public class LDA : AbstractDA<L>
    {
        public void Create(L inductance, Case cases)
        {
            if (false)
            {
                GmdsimModel gmdsimModel = new GmdsimModel();
                gmdsimModel.Inductances.Add(inductance);
                gmdsimModel.SaveChanges();
            }
            else
            {
                inductance.ID = findLastId(loadAll(cases));
                DataStored.addL(inductance, cases);
            }
        }

        public void Update(L inductance, Case cases)
        {
            if (false)
            {
                GmdsimModel gmdsimModel = new GmdsimModel();
                gmdsimModel.Inductances.AddOrUpdate(inductance);
                gmdsimModel.SaveChanges();
            }
            else
            {
                DataStored.editL(inductance, cases);
            }
        }

        public void Delete(L inductance, Case cases)
        {
            if (false)
            {
                GmdsimModel gmdsimModel = new GmdsimModel();
                gmdsimModel.Inductances.Remove(inductance);
                gmdsimModel.SaveChanges();
            }
            else
            {
                DataStored.removeL(inductance, cases);
            }

        }
        public List<L> loadAll(Case cases)
        {
            return DataStored.findAllL(cases).ToList();
        }

        public L findByID(Case cases, long ID)
        {
            List<L> lList = loadAll(cases);
            foreach (L l in lList)
            {
                if (l.ID == ID)
                {
                    return l;
                }
            }
            return null;
        }
    }
}
