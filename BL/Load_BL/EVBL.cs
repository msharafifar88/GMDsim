using DAO.Load_DAO;
using persistent;
using persistent.network.load_entitiy;
using System.Collections.Generic;
using System.Linq;

namespace BL.Load_BL
{
    public class EVBL : AbstractBL<EV>
    {
        EVDAO evDAO = new EVDAO();

        public void createEV(Case cases, EV ev)
        {
            evDAO.create(cases, ev);
        }
        public List<EV> loadAll(Case cases)
        {
            return evDAO.loadAll(cases).ToList();
        }
        public void editEV(EV ev, Case cases)
        {
            evDAO.update(cases, ev);
        }
        public void removeEV(EV ev, Case cases)
        {
            evDAO.delete(cases, ev);
        }

        public EV addEV(Case cases)
        {
            EV ev = new EV();
            string name = ev.Name;
            long code = ev.Code;
            List<EV> loadList = loadAll(cases);
            if (loadList.Count() == 0)
            {
                name = name + " " + code;

            }
            else
            {
                foreach (EV l in loadList)
                {
                    if (l.Code >= code)
                    {
                        code = l.Code + 1;
                    }
                }
                name = name + " " + code;
            }

            ev.Name = name;
            ev.Code = code;


            createEV(cases, ev);

            return ev;
        }

        public override EV findByID(Case cases, long ID)
        {
            return evDAO.findByID(cases, ID);
        }
    }
}
