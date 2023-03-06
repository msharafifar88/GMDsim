using areaandzone;
using DAO.da;
using display;
using network;
using persistent;
using System.Collections.Generic;
using System.Linq;



namespace BL
{
    public class BusBL : AbstractBL<Bus>
    {
        BusDA busDA = new BusDA();


        public void createBus(Bus bus, Case cases)
        {

            busDA.Create(bus, cases);
        }
        public List<Bus> loadAll(Case cases)
        {
            return busDA.loadAll(cases);
        }
        public void editBus(Bus bus, Case cases)
        {

            int a = (int)bus.voltage;
            int b = (int)bus.nominalVoltage;
            //bus.angle = Call_Calculator.SumInteger(ref a ,ref b);

            busDA.Update(bus, cases);
        }
        public void removeBus(Bus bus, Case Cases)
        {
            busDA.Delete(bus, Cases);
        }

        public override Bus findByID(Case cases, long ID)
        {
            return busDA.findByID(cases, ID);
        }

        public Bus findByCode(Case cases, long ID)
        {
            return busDA.findByCode(cases, ID);
        }
        public Bus addBus(Case cases)
        {
            Bus bus = new Bus();


            string name = bus.BusName;
            long code = bus.BusNumber;
            List<Bus> buses = loadAll(cases);
            if (buses.Count() == 0)
            {
                name = name + " " + code;

            }
            else
            {
                foreach (Bus b in buses)
                {
                    if (b.BusNumber >= code)
                    {
                        code = b.BusNumber + 1;
                    }
                }
                name = name + " " + code;
            }

            bus.BusName = name;
            bus.BusNumber = code;
            ZoneBL zoneBL = new ZoneBL();
            Display display = new Display();
            bus.display = display;

            if (zoneBL.loadAll().Count == 0)
            {
                bus.zone = zoneBL.addZone();
            }
            else
            {
                bus.zone = zoneBL.loadAll()[0];
            }
            AreaBL areaBL = new AreaBL();

            if (areaBL.loadAll().Count == 0)
            {
                bus.area = areaBL.addArea();
            }
            else
            {
                bus.area = areaBL.loadAll()[0];
            }

            OwnerBL ownerBL = new OwnerBL();

            if (ownerBL.loadAll().Count == 0)
            {

                bus.owners.Add(ownerBL.addOwner());
            }
            else
            {

                Owner o = ownerBL.loadAll()[0];
                bus.owners.Add(o);
            }
            createBus(bus, cases);

            return bus;
        }


    }
}
