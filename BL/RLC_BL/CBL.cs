using DAO;
using display;
using network;
using persistent;
using System.Collections.Generic;
using System.Linq;

namespace BL
{
    public class CBL : AbstractBL<C>, IRlcBL
    {
        CDA cDA = new CDA();
        public void create(RLCbranches capacitance, Case cases)
        {
            if (capacitance.GetType().Name.Equals("C"))
            {
                cDA.Create((C)capacitance, cases);
            }
        }
        public List<RLCbranches> loadAll(Case cases)
        {
            List<RLCbranches> temp = new List<RLCbranches>();
            foreach (C capacitance in cDA.loadAll(cases))
            {
                temp.Add(((RLCbranches)capacitance));
            }
            return temp;
        }
        public void edit(RLCbranches capacitance, Case cases)
        {
            if ((capacitance.GetType().Name.Equals("C")))
            {
                cDA.Update((C)capacitance, cases);
            }
        }
        public void remove(RLCbranches capacitance, Case Cases)
        {
            if ((capacitance.GetType().Name.Equals("C")))
            {
                cDA.Delete((C)capacitance, Cases);
            }
        }

        public RLCbranches add(Case cases)
        {
            C capacitance = new C();


            string name = capacitance.name;
            long code = capacitance.number;
            List<RLCbranches> capacitances = loadAll(cases);
            if (capacitances.Count() == 0)
            {
                name = name + " " + code;

            }
            else
            {
                foreach (C b in capacitances)
                {
                    if (b.number >= code)
                    {
                        code = b.number + 1;
                    }
                }
                name = name + " " + code;
            }

            capacitance.name = name;
            capacitance.number = code;
            ZoneBL zoneBL = new ZoneBL();
            Display display = new Display();
            //resistance.display = display;

            if (zoneBL.loadAll().Count == 0)
            {
                capacitance.zone = zoneBL.addZone();
            }
            else
            {
                capacitance.zone = zoneBL.loadAll()[0];
            }
            AreaBL areaBL = new AreaBL();

            if (areaBL.loadAll().Count == 0)
            {
                capacitance.area = areaBL.addArea();
            }
            else
            {
                capacitance.area = areaBL.loadAll()[0];
            }

            create(capacitance, cases);

            return capacitance;
        }

        public override C findByID(Case cases, long ID)
        {
            return cDA.findByID(cases, ID);
        }
    }
}
