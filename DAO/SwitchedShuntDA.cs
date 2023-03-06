using network;
using persistent;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace DAO
{
    public class SwitchedShuntDA : AbstractDA<SwitchBranches>
    {
        public void Create(SwitchBranches switchedShunt, Case cases)
        {
            if (false)
            {
                GmdsimModel gmdsimModel = new GmdsimModel();
                gmdsimModel.SwitchedShunts.Add(switchedShunt);
                gmdsimModel.SaveChanges();
            }
            else
            {
                switchedShunt.ID = findLastId(loadAll(cases));
                DataStored.addSwitchedShunt(switchedShunt, cases);
            }
        }

        public void Update(SwitchBranches switchedShunt, Case cases)
        {
            if (false)
            {
                GmdsimModel gmdsimModel = new GmdsimModel();
                gmdsimModel.SwitchedShunts.AddOrUpdate(switchedShunt);
                gmdsimModel.SaveChanges();
            }
            else
            {
                DataStored.editSwitchedShunt(switchedShunt, cases);
            }
        }

        public void Delete(SwitchBranches switchedShunt, Case cases)
        {
            if (false)
            {
                GmdsimModel gmdsimModel = new GmdsimModel();
                gmdsimModel.SwitchedShunts.Remove(switchedShunt);
                gmdsimModel.SaveChanges();
            }
            else
            {
                DataStored.removeSwitchedShunt(switchedShunt, cases);
            }

        }
        public List<SwitchBranches> loadAll(Case cases)
        {
            return DataStored.findAllSwitchedShunt(cases).ToList();
        }
    }
}
