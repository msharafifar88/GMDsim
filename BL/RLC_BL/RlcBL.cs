using DAO.da;
using display;
using network;
using persistent;
using System.Collections.Generic;
using System.Linq;



namespace BL
{
    public class RlcBL : AbstractBL<RLC>, IRlcBL
    {
        RlcDA rlcDA = new RlcDA();

        public void create(RLCbranches rlc, Case cases)
        {
            if (rlc.GetType().Name.Equals("RLC"))
            {
                rlcDA.Create((RLC)rlc, cases);
            }

        }
        public List<RLCbranches> loadAll(Case cases)
        {
            List<RLCbranches> temp = new List<RLCbranches>();
            foreach (RLC rlc in rlcDA.loadAll(cases))
            {
                temp.Add(((RLCbranches)rlc));
            }
            return temp;
        }
        public void edit(RLCbranches rlc, Case cases)
        {
            if ((rlc.GetType().Name.Equals("RLC")))
            {
                rlcDA.Update((RLC)rlc, cases);
            }
        }
        public void remove(RLCbranches rlc, Case Cases)
        {
            if ((rlc.GetType().Name.Equals("RLC")))
            {
                rlcDA.Delete((RLC)rlc, Cases);
            }
        }

        public RLCbranches add(Case cases)
        {
            RLC rlc = new RLC();


            string name = rlc.name;
            long code = rlc.number;
            List<RLCbranches> rlces = loadAll(cases);
            if (rlces.Count() == 0)
            {
                name = name + " " + code;

            }
            else
            {
                foreach (RLC b in rlces)
                {
                    if (b.number >= code)
                    {
                        code = b.number + 1;
                    }
                }
                name = name + " " + code;
            }

            rlc.name = name;
            rlc.number = code;
            ZoneBL zoneBL = new ZoneBL();
            Display display = new Display();
            // rlc.display = display;

            if (zoneBL.loadAll().Count == 0)
            {
                rlc.zone = zoneBL.addZone();
            }
            else
            {
                rlc.zone = zoneBL.loadAll()[0];
            }
            AreaBL areaBL = new AreaBL();

            if (areaBL.loadAll().Count == 0)
            {
                rlc.area = areaBL.addArea();
            }
            else
            {
                rlc.area = areaBL.loadAll()[0];
            }

            create(rlc, cases);

            return rlc;
        }

        public override RLC findByID(Case cases, long ID)
        {
            return rlcDA.findByID(cases, ID);
        }
    }
}
