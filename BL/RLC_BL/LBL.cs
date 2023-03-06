using DAO;
using display;
using network;
using persistent;
using System.Collections.Generic;
using System.Linq;

namespace BL
{
    public class LBL : AbstractBL<L>, IRlcBL
    {
        LDA lDA = new LDA();
        public void create(RLCbranches inductance, Case cases)
        {
            if (inductance.GetType().Name.Equals("L"))
            {
                lDA.Create((L)inductance, cases);
            }
        }
        public List<RLCbranches> loadAll(Case cases)
        {
            List<RLCbranches> temp = new List<RLCbranches>();
            foreach (L inductance in lDA.loadAll(cases))
            {
                temp.Add(((RLCbranches)inductance));
            }
            return temp;
        }
        public void edit(RLCbranches inductance, Case cases)
        {
            if (inductance.GetType().Name.Equals("L"))
            {
                lDA.Update((L)inductance, cases);
            }
        }
        public void remove(RLCbranches inductance, Case Cases)
        {
            if ((inductance.GetType().Name.Equals("L")))
            {
                lDA.Delete((L)inductance, Cases);
            }
        }

        public RLCbranches add(Case cases)
        {
            L inductance = new L();


            string name = inductance.name;
            long code = inductance.number;
            List<RLCbranches> inductances = loadAll(cases);
            if (inductances.Count() == 0)
            {
                name = name + " " + code;

            }
            else
            {
                foreach (L b in inductances)
                {
                    if (b.number >= code)
                    {
                        code = b.number + 1;
                    }
                }
                name = name + " " + code;
            }

            inductance.name = name;
            inductance.number = code;
            ZoneBL zoneBL = new ZoneBL();
            Display display = new Display();
            //resistance.display = display;

            if (zoneBL.loadAll().Count == 0)
            {
                inductance.zone = zoneBL.addZone();
            }
            else
            {
                inductance.zone = zoneBL.loadAll()[0];
            }
            AreaBL areaBL = new AreaBL();

            if (areaBL.loadAll().Count == 0)
            {
                inductance.area = areaBL.addArea();
            }
            else
            {
                inductance.area = areaBL.loadAll()[0];
            }

            create(inductance, cases);

            return inductance;
        }

        public override L findByID(Case cases, long ID)
        {
            return lDA.findByID(cases, ID);
        }
    }
}
