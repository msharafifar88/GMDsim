using DAO;
using display;
using network;
using persistent;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BL
{
    public class C3WTransformerBL : AbstractBL<C3WTransformer>
    {
        TriTransformerDA triTransformerDA = new TriTransformerDA();
        public void create(C3WTransformer triTransformer, Case cases)
        {
            if (triTransformer.GetType().Name.Equals("C3WTransformer"))
            {
                triTransformerDA.Create((C3WTransformer)triTransformer, cases);
            }
        }
        public List<C3WTransformer> loadAll(Case cases)
        {
            List<C3WTransformer> temp = new List<C3WTransformer>();
            foreach (C3WTransformer triTransformer in triTransformerDA.loadAll(cases))
            {
                temp.Add((C3WTransformer)triTransformer);
            }
            return temp;
        }
        public void edit(C3WTransformer triTransformer, Case cases)
        {
            if ((triTransformer.GetType().Name.Equals("C3WTransformer")))
            {
                triTransformerDA.Update((C3WTransformer)triTransformer, cases);
            }
        }
        public void remove(C3WTransformer triTransformer, Case Cases)
        {
            if (triTransformer.GetType().Name.Equals("C3WTransformer"))
            {
                triTransformerDA.Delete((C3WTransformer)triTransformer, Cases);
            }
        }

        public C3WTransformer add(Case cases)
        {
            C3WTransformer triTransformer = new C3WTransformer();

            string name = triTransformer.name;
            long code = triTransformer.number;
            List<C3WTransformer> triTransformers = loadAll(cases);
            if (triTransformers.Count() == 0)
            {
                name = name + " " + code;

            }
            else
            {
                foreach (C3WTransformer b in triTransformers)
                {
                    if (b.number >= code)
                    {
                        code = b.number + 1;
                    }
                }
                name = name + " " + code;
            }

            triTransformer.name = name;
            triTransformer.number = code;
            ZoneBL zoneBL = new ZoneBL();
            Display display = new Display();
            //resistance.display = display;

            /* if (zoneBL.loadAll().Count == 0)
             {
                 triTransformer.PrimaryBUS.zone = zoneBL.addZone();
             }
             else
             {
                 triTransformer.PrimaryBUS.zone = zoneBL.loadAll()[0];
             }
             AreaBL areaBL = new AreaBL();

             if (areaBL.loadAll().Count == 0)
             {
                 triTransformer.PrimaryBUS.area = areaBL.addArea();
             }
             else
             {
                 triTransformer.PrimaryBUS.area = areaBL.loadAll()[0];
             }
                 triTransformer.substation= new Substations();*/
            create(triTransformer, cases);

            return triTransformer;
        }

        public override C3WTransformer findByID(Case cases, long ID)
        {
            throw new NotImplementedException();
        }
    }
}
