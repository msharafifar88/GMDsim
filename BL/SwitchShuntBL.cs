using DAO;
using network;
using persistent;
using System.Collections.Generic;
using display;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class SwitchShuntBL : AbstractBL<SwitchBranches>, IShunt
    {
        SwitchedShuntDA switchedShuntDA = new SwitchedShuntDA();
        public void create(SwitchBranches switchedShunt, Case cases)
        {
            if (switchedShunt.GetType().Name.Equals("SwitchedShunt"))
            {
                switchedShuntDA.Create((SwitchBranches)switchedShunt, cases);
            }
        }
        public List<SwitchBranches> loadAll(Case cases)
        {
            List<SwitchBranches> temp = new List<SwitchBranches>();
            foreach (SwitchBranches switchedShunt in switchedShuntDA.loadAll(cases))
            {
                temp.Add((SwitchBranches)switchedShunt);
            }
            return temp;
        }
        public void edit(SwitchBranches switchedShunt, Case cases)
        {
            if ((switchedShunt.GetType().Name.Equals("SwitchedShunt")))
            {
                switchedShuntDA.Update((SwitchBranches)switchedShunt, cases);
            }
        }
        public void remove(SwitchBranches switchedShunt, Case Cases)
        {
            if (switchedShunt.GetType().Name.Equals("SwitchedShunt"))
            {
                switchedShuntDA.Delete((SwitchBranches)switchedShunt, Cases);
            }
        }

        public SwitchBranches add(Case cases)
        {
            SwitchBranches switchedShunt = new SwitchBranches();

            /*
                        string name = switchedShunt.name;
                        long code = switchedShunt.number;
                        List<ShuntBranches> switchedShunts = loadAll(cases);
                        if (switchedShunts.Count() == 0)
                        {
                            name = name + " " + code;

                        }
                        else
                        {
                            foreach (SwitchBranches b in switchedShunts)
                            {
                                if (b.number >= code)
                                {
                                    code = b.number + 1;
                                }
                            }
                            name = name + " " + code;
                        }

                        switchedShunt.name = name;
                        switchedShunt.number = code;
                        ZoneBL zoneBL = new ZoneBL();
                        Display display = new Display();
                        //resistance.display = display;

                        if (zoneBL.loadAll().Count == 0)
                        {
                            switchedShunt.zone = zoneBL.addZone();
                        }
                        else
                        {
                            switchedShunt.zone = zoneBL.loadAll()[0];
                        }
                        AreaBL areaBL = new AreaBL();

                        if (areaBL.loadAll().Count == 0)
                        {
                            switchedShunt.area = areaBL.addArea();
                        }
                        else
                        {
                            switchedShunt.area = areaBL.loadAll()[0];
                        }

                        create(switchedShunt, cases);*/

            return switchedShunt;
        }

        public override SwitchBranches findByID(Case cases, long ID)
        {
            throw new System.NotImplementedException();
        }
    }
}
