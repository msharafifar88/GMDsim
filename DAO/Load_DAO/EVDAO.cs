using persistent;
using persistent.network.load_entitiy;
using System.Collections.Generic;
using System.Linq;

namespace DAO.Load_DAO
{
    public class EVDAO : AbstractDA<EV>
    {
        public void create(Case cases, EV ev)
        {
            if (false)
            {
                GmdsimModel gmdsimModel = new GmdsimModel();
                gmdsimModel.EVlist.Add(ev);
                gmdsimModel.SaveChanges();
            }
            else
            {
                DataStored.addEV(cases, ev);
            }
        }

        public void update(Case cases, EV ev)
        {
            if (false)
            {
                GmdsimModel gmdsimModel = new GmdsimModel();
                gmdsimModel.EVlist.Add(ev);
                gmdsimModel.SaveChanges();
            }
            else
            {
                DataStored.editEV(cases, ev);
            }
        }

        public void delete(Case cases, EV ev)
        {
            if (false)
            {
                GmdsimModel gmdsimModel = new GmdsimModel();
                gmdsimModel.EVlist.Remove(ev);
                gmdsimModel.SaveChanges();
            }
            else
            {
                DataStored.removeEV(cases, ev);
            }
        }
        public List<EV> loadAll(Case cases)
        {
            return DataStored.findAllEVs(cases).ToList();
        }
        public EV findByID(Case cases, long ID)
        {
            List<EV> loadList = loadAll(cases);
            foreach (EV load in loadList)
            {
                if (load.ID == ID)
                {
                    return load;
                }
            }
            return null;
        }
    }
}
