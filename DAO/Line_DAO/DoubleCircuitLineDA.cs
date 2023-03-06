using network;
using persistent;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace DAO
{
    public class DoubleCircuitLineDA : AbstractDA<DoubleCircuitLine>
    {
        public void Create(DoubleCircuitLine doubleCircuit, Case cases)
        {
            if (false)
            {
                GmdsimModel gmdsimModel = new GmdsimModel();
                gmdsimModel.BiLines.Add(doubleCircuit);
                gmdsimModel.SaveChanges();
            }
            else
            {
                doubleCircuit.ID = findLastId(loadAll(cases));
                DataStored.addDoubleCircuitLine(doubleCircuit, cases);
            }
        }

        public void Update(DoubleCircuitLine doubleCircuit, Case cases)
        {
            if (false)
            {
                GmdsimModel gmdsimModel = new GmdsimModel();
                gmdsimModel.BiLines.AddOrUpdate(doubleCircuit);
                gmdsimModel.SaveChanges();
            }
            else
            {
                DataStored.editDoubleCircuitLine(doubleCircuit, cases);
            }
        }

        public void Delete(DoubleCircuitLine doubleCircuit, Case cases)
        {
            if (false)
            {
                GmdsimModel gmdsimModel = new GmdsimModel();
                gmdsimModel.BiLines.Remove(doubleCircuit);
                gmdsimModel.SaveChanges();
            }
            else
            {
                DataStored.removeDoubleCircuitLine(doubleCircuit, cases);
            }

        }
        public List<DoubleCircuitLine> loadAll(Case cases)
        {
            return DataStored.findAllDoubleCircuitLine(cases).ToList();
        }


        public DoubleCircuitLine findByID(Case cases, long ID)
        {
            List<DoubleCircuitLine> doubleCircuits = loadAll(cases);
            foreach (DoubleCircuitLine doubline in doubleCircuits)
            {
                if (doubline.ID == ID)
                {
                    return doubline;
                }
            }
            return null;
        }
    }
}
