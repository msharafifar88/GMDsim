using DAO;
using network;
using persistent;
using System.Collections.Generic;
using System.Linq;

namespace BL
{
    public class LoadBL : AbstractBL<Loads>
    {
        LoadDA loadDA = new LoadDA();

        public void createLoad(Case cases, Loads load)
        {
            loadDA.create(cases, load);
        }
        public List<Loads> loadAll(Case cases)
        {
            return loadDA.loadAll(cases).ToList();
        }
        public void editLoad(Loads load, Case cases)
        {
            loadDA.update(cases, load);
        }
        public void removeLoad(Loads load, Case cases)
        {
            loadDA.delete(cases, load);
        }

        public Loads addLoad(Case cases)
        {
            Loads load = new Loads();


            string name = load.Name;
            long code = load.Code;
            List<Loads> loadList = loadAll(cases);
            if (loadList.Count() == 0)
            {
                name = name + " " + code;

            }
            else
            {
                foreach (Loads l in loadList)
                {
                    if (l.Code >= code)
                    {
                        code = l.Code + 1;
                    }
                }
                name = name + " " + code;
            }

            load.Name = name;
            load.Code = code;


            createLoad(cases, load);

            return load;
        }

        public override Loads findByID(Case cases, long ID)
        {
            return loadDA.findByID(cases, ID);
        }

        public List<Loads> findLoadByBus(Case cases, Bus bus)
        {
            List<Loads> loadList = new List<Loads>();
            foreach (Loads l in loadAll(cases))
            {
                if (l.Bus.Equals(bus))
                {
                    loadList.Add(l);
                }
            }
            return loadList;
        }


    }
}
