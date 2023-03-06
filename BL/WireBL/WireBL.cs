using DAO.Wire_DAO;
using persistent;
using persistent.network.wire;
using System.Collections.Generic;

namespace BL.WireBL
{
    public class WireBL : AbstractBL<Wire>
    {
        WireDA wireDA = new WireDA();
        public void createwire(Wire wire, Case cases)
        {

            wireDA.Create(wire, cases);
        }
        public List<Wire> loadAll(Case cases)
        {
            return wireDA.loadAll(cases);
        }
        public void editWire(Wire bus, Case cases)
        {


            //bus.angle = Call_Calculator.SumInteger(ref a ,ref b);

            wireDA.Update(bus, cases);
        }
        public void removeWire(Wire wire, Case Cases)
        {
            wireDA.Delete(wire, Cases);
        }

        public override Wire findByID(Case cases, long ID)
        {
            return wireDA.findByID(cases, ID);
        }
        public Wire addWire(Case cases)
        {
            Wire wire = new Wire();


            object from = wire.from;
            object to = wire.to;


            createwire(wire, cases);

            return wire;
        }

    }
}
