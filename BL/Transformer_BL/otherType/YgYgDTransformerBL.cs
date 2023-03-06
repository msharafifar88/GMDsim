using DAO;
using display;
using network;
using persistent;
using System.Collections.Generic;
using System.Linq;

namespace BL
{
    public class YgYgDTransformerBL : AbstractBL<YgYgDTransformer>, ITransformer
    {
        YgYgDTransformerDA ygYgDTransformerDA = new YgYgDTransformerDA();
        public void create(MainTransformers ygYgDTransformer, Case cases)
        {
            if (ygYgDTransformer.GetType().Name.Equals("YgYgDTransformer"))
            {
                ygYgDTransformerDA.Create((YgYgDTransformer)ygYgDTransformer, cases);
            }
        }
        public List<MainTransformers> loadAll(Case cases)
        {
            List<MainTransformers> temp = new List<MainTransformers>();
            foreach (YgYgDTransformer ygYgDTransformer in ygYgDTransformerDA.loadAll(cases))
            {
                temp.Add((MainTransformers)ygYgDTransformer);
            }
            return temp;
        }
        public void edit(MainTransformers ygYgDTransformer, Case cases)
        {
            if (ygYgDTransformer.GetType().Name.Equals("YgYgDTransformer"))
            {
                ygYgDTransformerDA.Update((YgYgDTransformer)ygYgDTransformer, cases);
            }
        }
        public void remove(MainTransformers ygYgDTransformer, Case Cases)
        {
            if (ygYgDTransformer.GetType().Name.Equals("YgYgDTransformer"))
            {
                ygYgDTransformerDA.Delete((YgYgDTransformer)ygYgDTransformer, Cases);
            }
        }

        public MainTransformers add(Case cases)
        {
            YgYgDTransformer ygYgDTransformer = new YgYgDTransformer();


            string name = ygYgDTransformer.name;
            long code = ygYgDTransformer.number;
            List<MainTransformers> ygYgDTransformers = loadAll(cases);
            if (ygYgDTransformers.Count() == 0)
            {
                name = name + " " + code;

            }
            else
            {
                foreach (YgYgDTransformer b in ygYgDTransformers)
                {
                    if (b.number >= code)
                    {
                        code = b.number + 1;
                    }
                }
                name = name + " " + code;
            }

            ygYgDTransformer.name = name;
            ygYgDTransformer.number = code;
            ZoneBL zoneBL = new ZoneBL();
            Display display = new Display();
            //resistance.display = display;

            /*  if (zoneBL.loadAll().Count == 0)
              {
                  ygYgDTransformer.zone = zoneBL.addZone();
              }
              else
              {
                  ygYgDTransformer.zone = zoneBL.loadAll()[0];
              }
              AreaBL areaBL = new AreaBL();

              if (areaBL.loadAll().Count == 0)
              {
                  ygYgDTransformer.area = areaBL.addArea();
              }
              else
              {
                  ygYgDTransformer.area = areaBL.loadAll()[0];
              }
  */
            create(ygYgDTransformer, cases);

            return ygYgDTransformer;
        }

        public override YgYgDTransformer findByID(Case cases, long ID)
        {
            return ygYgDTransformerDA.findByID(cases, ID);
        }
    }
}
