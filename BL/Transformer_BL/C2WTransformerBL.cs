using DAO;
using display;
using persistent;
using persistent.network;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BL
{
    public class C2WTransformerBL : AbstractBL<C2WTransformer>
    {
        C2WTransformerDA c2WTransformerDA = new C2WTransformerDA();
        public void create(C2WTransformer c2WTransformer, Case cases)
        {
            if (c2WTransformer.GetType().Name.Equals("C2WTransformer"))
            {
                c2WTransformerDA.Create((C2WTransformer)c2WTransformer, cases);
            }
        }
        public List<C2WTransformer> loadAll(Case cases)
        {
            List<C2WTransformer> temp = new List<C2WTransformer>();
            foreach (C2WTransformer c2WTransformer in c2WTransformerDA.loadAll(cases))
            {
                temp.Add((C2WTransformer)c2WTransformer);
            }
            return temp;
        }
        public void edit(C2WTransformer c2WTransformer, Case cases)
        {
            if ((c2WTransformer.GetType().Name.Equals("C2WTransformer")))
            {
                c2WTransformerDA.Update((C2WTransformer)c2WTransformer, cases);
            }
        }
        public void remove(C2WTransformer c2WTransformer, Case Cases)
        {
            if (c2WTransformer.GetType().Name.Equals("C2WTransformer"))
            {
                c2WTransformerDA.Delete((C2WTransformer)c2WTransformer, Cases);
            }
        }

        public C2WTransformer add(Case cases)
        {
            C2WTransformer c2WTransformer = new C2WTransformer();


            string name = c2WTransformer.name;
            long code = c2WTransformer.number;
            List<C2WTransformer> c2WTransformers = loadAll(cases);
            if (c2WTransformers.Count() == 0)
            {
                name = name + " " + code;

            }
            else
            {
                foreach (C2WTransformer b in c2WTransformers)
                {
                    if (b.number >= code)
                    {
                        code = b.number + 1;
                    }
                }
                name = name + " " + code;
            }

            c2WTransformer.name = name;
            c2WTransformer.number = code;
            ZoneBL zoneBL = new ZoneBL();
            Display display = new Display();
            //resistance.display = display;

            /*if (zoneBL.loadAll().Count == 0)
            {
                c2WTransformer.PrimaryBUS.zone = zoneBL.addZone();
            }
            else
            {
                c2WTransformer.PrimaryBUS.zone = zoneBL.loadAll()[0];
            }
            AreaBL areaBL = new AreaBL();

            if (areaBL.loadAll().Count == 0)
            {
                c2WTransformer.PrimaryBUS.area = areaBL.addArea();
            }
            else
            {
                c2WTransformer.PrimaryBUS.area = areaBL.loadAll()[0];
            }
*/
            create(c2WTransformer, cases);

            return c2WTransformer;
        }

        public override C2WTransformer findByID(Case cases, long ID)
        {
            throw new NotImplementedException();
        }
    }
}

