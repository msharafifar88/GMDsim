using persistent;
using persistent.network.wire;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace DAO.Wire_DAO
{
    public class WireDA : AbstractDA<Wire>
    {


        public void Create(Wire wire, Case cases)
        {
            try
            {
                GmdsimModel gmdsimModel = new GmdsimModel();
                gmdsimModel.wires.Add(wire);
                gmdsimModel.SaveChanges();
            }
            catch
            {
                wire.ID = findLastId(loadAll(cases));
                DataStored.addWire(cases, wire);
            }
        }

        public void Update(Wire wire, Case cases)
        {
            try
            {
                GmdsimModel gmdsimModel = new GmdsimModel();
                gmdsimModel.wires.AddOrUpdate(wire);
                gmdsimModel.SaveChanges();
            }
            catch
            {
                DataStored.editWire(wire, cases);

            }

        }

        public void Delete(Wire wire, Case cases)
        {
            try
            {
                GmdsimModel gmdsimModel = new GmdsimModel();
                gmdsimModel.wires.Remove(wire);
                gmdsimModel.SaveChanges();
            }
            catch
            {
                DataStored.removeWire(cases, wire);
            }

        }
        public List<Wire> loadAll(Case cases)
        {
            return DataStored.findAllwires(cases).ToList();
        }
        public Wire findByID(Case cases, long ID)
        {
            List<Wire> wires = loadAll(cases);
            foreach (Wire wire in wires)
            {
                if (wire.ID == ID)
                {
                    return wire;
                }
            }
            return null;
        }
    }
}
