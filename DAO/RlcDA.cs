using network;
using persistent;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;


namespace DAO.da
{
    public class RlcDA : AbstractDA<RLC>
    {

        public void Create(RLC rLC, Case cases)
        {
            if (false)
            {
                GmdsimModel gmdsimModel = new GmdsimModel();
                gmdsimModel.RLCs.Add(rLC);
                gmdsimModel.SaveChanges();
            }
            else
            {
                rLC.ID = findLastId(loadAll(cases));
                DataStored.addRlc(rLC, cases);
            }
        }

        public void Update(RLC RLC, Case cases)
        {
            if (false)
            {
                GmdsimModel gmdsimModel = new GmdsimModel();
                gmdsimModel.RLCs.AddOrUpdate(RLC);
                gmdsimModel.SaveChanges();
            }
            else
            {
                DataStored.editRLC(RLC, cases);

            }

        }

        public void Delete(RLC RLC, Case cases)
        {
            if (false)
            {
                GmdsimModel gmdsimModel = new GmdsimModel();
                gmdsimModel.RLCs.Remove(RLC);
                gmdsimModel.SaveChanges();
            }
            else
            {
                DataStored.removeRLC(RLC, cases);
            }

        }
        public List<RLC> loadAll(Case cases)
        {
            return DataStored.findAllRLC(cases).ToList();
        }

        public RLC findByID(Case cases, long ID)
        {
            List<RLC> rlsList = loadAll(cases);
            foreach (RLC rlc in rlsList)
            {
                if (rlc.ID == ID)
                {
                    return rlc;
                }
            }
            return null;
        }
    }
}
