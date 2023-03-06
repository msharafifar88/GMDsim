using network;
using persistent;
using System.Collections.Generic;
using System.Linq;

namespace DAO
{
    public class LoadDA : AbstractDA<Loads>
    {

        public void create(Case cases, Loads load)
        {
            if (false)
            {
                GmdsimModel gmdsimModel = new GmdsimModel();
                gmdsimModel.Loads.Add(load);
                gmdsimModel.SaveChanges();
            }
            else
            {
                DataStored.addLoad(cases, load);
            }
        }

        public void update(Case cases, Loads load)
        {
            if (false)
            {
                GmdsimModel gmdsimModel = new GmdsimModel();
                gmdsimModel.Loads.Add(load);
                gmdsimModel.SaveChanges();
            }
            else
            {
                DataStored.editLoad(cases, load);
            }
        }

        public void delete(Case cases, Loads load)
        {
            if (false)
            {
                GmdsimModel gmdsimModel = new GmdsimModel();
                gmdsimModel.Loads.Remove(load);
                gmdsimModel.SaveChanges();
            }
            else
            {
                DataStored.removeLoad(cases, load);
            }
        }
        public List<Loads> loadAll(Case cases)
        {
            return DataStored.findAllLoads(cases).ToList();
        }
        public Loads findByID(Case cases, long ID)
        {
            List<Loads> loadList = loadAll(cases);
            foreach (Loads load in loadList)
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
