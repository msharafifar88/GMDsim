using DAO;
using persistent.network;
using System.Collections.Generic;

namespace BL
{
    public class SubstationBL
    {
        SubstationDAO substationDAO = new SubstationDAO();
        public List<Substations> loadAll()
        {
            return substationDAO.loadAll();
        }
        public void createSubstation(Substations substation)
        {
            substationDAO.Create(substation);
        }

        public void editSubstation(Substations substation)
        {
            substationDAO.Update(substation);
        }
        public void removeSubstation(Substations substation)
        {
            substationDAO.Delete(substation);
        }

        public Substations findLastSubstation()
        {
            return substationDAO.findLastSubstation();
        }
    }
}
