using network;
using persistent;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace DAO
{
    public class CDA : AbstractDA<C>
    {
        public void Create(C capacitance, Case cases)
        {
            if (false)
            {
                GmdsimModel gmdsimModel = new GmdsimModel();
                gmdsimModel.Capacitances.Add(capacitance);
                gmdsimModel.SaveChanges();
            }
            else
            {
                capacitance.ID = findLastId(loadAll(cases));
                DataStored.addC(capacitance, cases);
            }
        }

        public void Update(C capacitance, Case cases)
        {
            if (false)
            {
                GmdsimModel gmdsimModel = new GmdsimModel();
                gmdsimModel.Capacitances.AddOrUpdate(capacitance);
                gmdsimModel.SaveChanges();
            }
            else
            {
                DataStored.editC(capacitance, cases);
            }
        }

        public void Delete(C capacitance, Case cases)
        {
            if (false)
            {
                GmdsimModel gmdsimModel = new GmdsimModel();
                gmdsimModel.Capacitances.Remove(capacitance);
                gmdsimModel.SaveChanges();
            }
            else
            {
                DataStored.removeC(capacitance, cases);
            }

        }
        public List<C> loadAll(Case cases)
        {
            return DataStored.findAllC(cases).ToList();
        }
        public C findByID(Case cases, long ID)
        {
            List<C> cList = loadAll(cases);
            foreach (C c in cList)
            {
                if (c.ID == ID)
                {
                    return c;
                }
            }
            return null;
        }
    }
}
