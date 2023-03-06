using DAO;
using display;
using network;
using persistent;
using System.Collections.Generic;
using System.Linq;

namespace BL
{
    public class RBL : AbstractBL<R>, IRlcBL
    {
        RDA rDA = new RDA();
        public void create(RLCbranches resistance, Case cases)
        {
            if (resistance.GetType().Name.Equals("R"))
            {
                rDA.Create((R)resistance, cases);
            }
        }
        public List<RLCbranches> loadAll(Case cases)
        {
            List<RLCbranches> temp = new List<RLCbranches>();
            foreach (R resistance in rDA.loadAll(cases))
            {
                temp.Add(((RLCbranches)resistance));
            }
            return temp;
        }
        public void edit(RLCbranches resistance, Case cases)
        {
            if ((resistance.GetType().Name.Equals("R")))
            {
                rDA.Update((R)resistance, cases);
            }
        }
        public void remove(RLCbranches resistance, Case Cases)
        {
            if ((resistance.GetType().Name.Equals("R")))
            {
                rDA.Delete((R)resistance, Cases);
            }
        }

        public RLCbranches add(Case cases)
        {
            R resistance = new R();


            string name = resistance.name;
            long code = resistance.number;
            List<RLCbranches> resistances = loadAll(cases);
            if (resistances.Count() == 0)
            {
                name = name + " " + code;

            }
            else
            {
                foreach (R b in resistances)
                {
                    if (b.number >= code)
                    {
                        code = b.number + 1;
                    }
                }
                name = name + " " + code;
            }

            resistance.name = name;
            resistance.number = code;
            ZoneBL zoneBL = new ZoneBL();
            Display display = new Display();
            //resistance.display = display;

            if (zoneBL.loadAll().Count == 0)
            {
                resistance.zone = zoneBL.addZone();
            }
            else
            {
                resistance.zone = zoneBL.loadAll()[0];
            }
            AreaBL areaBL = new AreaBL();

            if (areaBL.loadAll().Count == 0)
            {
                resistance.area = areaBL.addArea();
            }
            else
            {
                resistance.area = areaBL.loadAll()[0];
            }

            create(resistance, cases);

            return resistance;
        }

        public override R findByID(Case cases, long ID)
        {
            return rDA.findByID(cases, ID);
        }
    }
}

