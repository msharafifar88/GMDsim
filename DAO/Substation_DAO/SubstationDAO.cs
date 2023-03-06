using persistent.network;
using System.Collections.Generic;
using System.Linq;

namespace DAO
{
    public class SubstationDAO
    {

        public void Create(Substations substation)
        {
            if (canEditSubstation(substation))
            {
                try
                {
                    GmdsimModel gmdsimModel = new GmdsimModel();
                    gmdsimModel.Substations.Add(substation);
                    gmdsimModel.SaveChanges();
                }
                catch
                {
                    DataStored.addSubstation(substation);
                }
            }
        }

        public void Update(Substations substation)
        {
            try
            {
                GmdsimModel gmdsimModel = new GmdsimModel();
                gmdsimModel.Substations.Add(substation);
                gmdsimModel.SaveChanges();
            }
            catch
            {
                DataStored.addSubstation(substation);

            }

        }

        public void Delete(Substations substation)
        {
            try
            {
                GmdsimModel gmdsimModel = new GmdsimModel();
                gmdsimModel.Substations.Remove(substation);
                gmdsimModel.SaveChanges();
            }
            catch
            {
                DataStored.removeSubstation(substation);
            }

        }
        public List<Substations> loadAll()
        {
            return DataStored.findAllSubstation().ToList();
        }

        public Substations findLastSubstation()
        {
            if (loadAll().Count == 0)
            {
                return new Substations();

            }
            return loadAll().Last();
        }

        /* Can Edit Substation*/
        private bool canEditSubstation(Substations substation)
        {
            List<Substations> substationsList = loadAll();
            foreach (Substations sub in substationsList)
            {
                if (sub.Substation_Name.Equals(substation.Substation_Name) || sub.Substation_Number.Equals(substation.Substation_Number))
                {
                    return false;
                }
            }
            return true;
        }

    }

}
