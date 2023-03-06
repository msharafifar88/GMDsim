using DAO;
using display;
using network;
using persistent;
using System.Collections.Generic;
using System.Linq;

namespace BL
{
    public class RlBL : AbstractBL<RL>, IRlcBL
    {
        RlDA rlDA = new RlDA();
        public void create(RLCbranches rl, Case cases)
        {
            if (rl.GetType().Name.Equals("RL"))
            {
                rlDA.Create((RL)rl, cases);
            }
        }
        public List<RLCbranches> loadAll(Case cases)
        {
            List<RLCbranches> temp = new List<RLCbranches>();
            foreach (RL rl in rlDA.loadAll(cases))
            {
                temp.Add(((RLCbranches)rl));
            }
            return temp;
        }
        public void edit(RLCbranches rl, Case cases)
        {
            if (rl.GetType().Name.Equals("RL"))
            {
                rlDA.Update((RL)rl, cases);
            }
        }
        public void remove(RLCbranches rl, Case Cases)
        {
            if (rl.GetType().Name.Equals("RL"))
            {
                rlDA.Delete((RL)rl, Cases);
            }
        }

        public RLCbranches add(Case cases)
        {
            RL rl = new RL();


            string name = rl.name;
            long code = rl.number;
            List<RLCbranches> rles = loadAll(cases);
            if (rles.Count() == 0)
            {
                name = name + " " + code;

            }
            else
            {
                foreach (RL b in rles)
                {
                    if (b.number >= code)
                    {
                        code = b.number + 1;
                    }
                }
                name = name + " " + code;
            }

            rl.name = name;
            rl.number = code;
            ZoneBL zoneBL = new ZoneBL();
            Display display = new Display();
            //resistance.display = display;

            if (zoneBL.loadAll().Count == 0)
            {
                rl.zone = zoneBL.addZone();
            }
            else
            {
                rl.zone = zoneBL.loadAll()[0];
            }
            AreaBL areaBL = new AreaBL();

            if (areaBL.loadAll().Count == 0)
            {
                rl.area = areaBL.addArea();
            }
            else
            {
                rl.area = areaBL.loadAll()[0];
            }

            create(rl, cases);

            return rl;
        }

        public override RL findByID(Case cases, long ID)
        {
            return rlDA.findByID(cases, ID);
        }
    }
}
