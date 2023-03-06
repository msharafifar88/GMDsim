using DAO;
using display;
using network;
using persistent;
using System.Collections.Generic;
using System.Linq;

namespace BL
{
    public class YgDTransformerBL : AbstractBL<YgDTransformer>, ITransformer
    {
        YgDTransformerDA ygDTransformerDA = new YgDTransformerDA();
        public void create(MainTransformers ygDTransformer, Case cases)
        {
            if (ygDTransformer.GetType().Name.Equals("YgDTransformer"))
            {
                ygDTransformerDA.Create((YgDTransformer)ygDTransformer, cases);
            }
        }
        public List<MainTransformers> loadAll(Case cases)
        {
            List<MainTransformers> temp = new List<MainTransformers>();
            foreach (YgDTransformer ygDTransformer in ygDTransformerDA.loadAll(cases))
            {
                temp.Add((MainTransformers)ygDTransformer);
            }
            return temp;
        }
        public void edit(MainTransformers ygDTransformer, Case cases)
        {
            if (ygDTransformer.GetType().Name.Equals("YgDTransformer"))
            {
                ygDTransformerDA.Update((YgDTransformer)ygDTransformer, cases);
            }
        }
        public void remove(MainTransformers ygDTransformer, Case Cases)
        {
            if (ygDTransformer.GetType().Name.Equals("YgDTransformer"))
            {
                ygDTransformerDA.Delete((YgDTransformer)ygDTransformer, Cases);
            }
        }

        public MainTransformers add(Case cases)
        {
            YgDTransformer ygDTransformer = new YgDTransformer();

            string name = ygDTransformer.name;
            long code = ygDTransformer.number;
            List<MainTransformers> ygDTransformers = loadAll(cases);
            if (ygDTransformers.Count() == 0)
            {
                name = name + " " + code;

            }
            else
            {
                foreach (YgDTransformer b in ygDTransformers)
                {
                    if (b.number >= code)
                    {
                        code = b.number + 1;
                    }
                }
                name = name + " " + code;
            }

            ygDTransformer.name = name;
            ygDTransformer.number = code;
            ZoneBL zoneBL = new ZoneBL();
            Display display = new Display();
            //resistance.display = display;

            if (zoneBL.loadAll().Count == 0)
            {
                ygDTransformer.PrimaryBUS.zone = zoneBL.addZone();
            }
            else
            {
                ygDTransformer.PrimaryBUS.zone = zoneBL.loadAll()[0];
            }
            AreaBL areaBL = new AreaBL();

            if (areaBL.loadAll().Count == 0)
            {
                ygDTransformer.PrimaryBUS.area = areaBL.addArea();
            }
            else
            {
                ygDTransformer.PrimaryBUS.area = areaBL.loadAll()[0];
            }

            create(ygDTransformer, cases);

            return ygDTransformer;
        }

        public override YgDTransformer findByID(Case cases, long ID)
        {
            return ygDTransformerDA.findByID(cases, ID);
        }
    }
}
