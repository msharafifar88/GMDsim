using DAO;
using display;
using network;
using persistent;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BL
{
    public class TTransformerBL : AbstractBL<TTransformer>, ITransformer
    {
        TTransformerDA tTransformerDA = new TTransformerDA();
        public void create(MainTransformers tTransformer, Case cases)
        {
            if (tTransformer.GetType().Name.Equals("TTransformer"))
            {
                tTransformerDA.Create((TTransformer)tTransformer, cases);
            }
        }
        public List<MainTransformers> loadAll(Case cases)
        {
            List<MainTransformers> temp = new List<MainTransformers>();
            foreach (TTransformer tTransformer in tTransformerDA.loadAll(cases))
            {
                temp.Add((MainTransformers)tTransformer);
            }
            return temp;
        }
        public void edit(MainTransformers tTransformer, Case cases)
        {
            if ((tTransformer.GetType().Name.Equals("TTransformer")))
            {
                tTransformerDA.Update((TTransformer)tTransformer, cases);
            }
        }
        public void remove(MainTransformers tTransformer, Case Cases)
        {
            if (tTransformer.GetType().Name.Equals("TTransformer"))
            {
                tTransformerDA.Delete((TTransformer)tTransformer, Cases);
            }
        }

        public MainTransformers add(Case cases)
        {
            TTransformer tTransformer = new TTransformer();


            string name = tTransformer.name;
            long code = tTransformer.number;
            List<MainTransformers> tTransformers = loadAll(cases);
            if (tTransformers.Count() == 0)
            {
                name = name + " " + code;

            }
            else
            {
                foreach (TTransformer b in tTransformers)
                {
                    if (b.number >= code)
                    {
                        code = b.number + 1;
                    }
                }
                name = name + " " + code;
            }

            tTransformer.name = name;
            tTransformer.number = code;
            ZoneBL zoneBL = new ZoneBL();
            Display display = new Display();
            //resistance.display = display;

            if (zoneBL.loadAll().Count == 0)
            {
                tTransformer.PrimaryBUS.zone = zoneBL.addZone();
            }
            else
            {
                tTransformer.PrimaryBUS.zone = zoneBL.loadAll()[0];
            }
            AreaBL areaBL = new AreaBL();

            if (areaBL.loadAll().Count == 0)
            {
                tTransformer.PrimaryBUS.area = areaBL.addArea();
            }
            else
            {
                tTransformer.PrimaryBUS.area = areaBL.loadAll()[0];
            }

            create(tTransformer, cases);

            return tTransformer;
        }

        public override TTransformer findByID(Case cases, long ID)
        {
            throw new NotImplementedException();
        }
    }
}
