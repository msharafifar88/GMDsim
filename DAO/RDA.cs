using network;
using persistent;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace DAO
{
    public class RDA : AbstractDA<R>
    {
        public void Create(R resistance, Case cases)
        {
            if (false)
            {
                GmdsimModel gmdsimModel = new GmdsimModel();
                gmdsimModel.Resistances.Add(resistance);
                gmdsimModel.SaveChanges();
            }
            else
            {
                resistance.ID = findLastId(loadAll(cases));
                DataStored.addR(resistance, cases);
            }
        }

        public void Update(R resistance, Case cases)
        {
            if (false)
            {
                GmdsimModel gmdsimModel = new GmdsimModel();
                gmdsimModel.Resistances.AddOrUpdate(resistance);
                gmdsimModel.SaveChanges();
            }
            else
            {
                DataStored.editR(resistance, cases);
            }
        }

        public void Delete(R resistance, Case cases)
        {
            if (false)
            {
                GmdsimModel gmdsimModel = new GmdsimModel();
                gmdsimModel.Resistances.Remove(resistance);
                gmdsimModel.SaveChanges();
            }
            else
            {
                DataStored.removeR(resistance, cases);
            }

        }
        public List<R> loadAll(Case cases)
        {
            return DataStored.findAllR(cases).ToList();
        }

        public R findByID(Case cases, long ID)
        {
            List<R> rList = loadAll(cases);
            foreach (R r in rList)
            {
                if (r.ID == ID)
                {
                    return r;
                }
            }
            return null;
        }
    }
}
