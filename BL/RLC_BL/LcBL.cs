using DAO;
using display;
using network;
using persistent;
using System.Collections.Generic;
using System.Linq;

namespace BL
{
    public class LcBL : AbstractBL<LC>, IRlcBL
    {
        LcDA lcDA = new LcDA();
        public void create(RLCbranches lc, Case cases)
        {
            if (lc.GetType().Name.Equals("LC"))
            {
                lcDA.Create((LC)lc, cases);
            }
        }
        public List<RLCbranches> loadAll(Case cases)
        {
            List<RLCbranches> temp = new List<RLCbranches>();
            foreach (LC lc in lcDA.loadAll(cases))
            {
                temp.Add((RLCbranches)lc);
            }
            return temp;
        }
        public void edit(RLCbranches lc, Case cases)
        {
            if ((lc.GetType().Name.Equals("LC")))
            {
                lcDA.Update((LC)lc, cases);
            }
        }
        public void remove(RLCbranches lc, Case Cases)
        {
            if ((lc.GetType().Name.Equals("LC")))
            {
                lcDA.Delete((LC)lc, Cases);
            }
        }

        public RLCbranches add(Case cases)
        {
            LC lc = new LC();


            string name = lc.name;
            long code = lc.number;
            List<RLCbranches> lces = loadAll(cases);
            if (lces.Count() == 0)
            {
                name = name + " " + code;

            }
            else
            {
                foreach (LC b in lces)
                {
                    if (b.number >= code)
                    {
                        code = b.number + 1;
                    }
                }
                name = name + " " + code;
            }

            lc.name = name;
            lc.number = code;
            ZoneBL zoneBL = new ZoneBL();
            Display display = new Display();
            //resistance.display = display;

            if (zoneBL.loadAll().Count == 0)
            {
                lc.zone = zoneBL.addZone();
            }
            else
            {
                lc.zone = zoneBL.loadAll()[0];
            }
            AreaBL areaBL = new AreaBL();

            if (areaBL.loadAll().Count == 0)
            {
                lc.area = areaBL.addArea();
            }
            else
            {
                lc.area = areaBL.loadAll()[0];
            }

            create(lc, cases);

            return lc;
        }

        public override LC findByID(Case cases, long ID)
        {
            return lcDA.findByID(cases, ID);
        }
    }
}
