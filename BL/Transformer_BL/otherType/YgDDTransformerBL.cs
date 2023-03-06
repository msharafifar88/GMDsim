using DAO;
using display;
using network;
using persistent;
using System.Collections.Generic;
using System.Linq;

namespace BL
{
    public class YgDDTransformerBL : AbstractBL<YgDDTransformer>, ITransformer
    {
        YgDDTransformerDA ygDDTransformerDA = new YgDDTransformerDA();
        public void create(MainTransformers ygDDTransformer, Case cases)
        {
            if (ygDDTransformer.GetType().Name.Equals("YgDDTransformer"))
            {
                ygDDTransformerDA.Create((YgDDTransformer)ygDDTransformer, cases);
            }
        }
        public List<MainTransformers> loadAll(Case cases)
        {
            List<MainTransformers> temp = new List<MainTransformers>();
            foreach (YgDDTransformer ygDDTransformer in ygDDTransformerDA.loadAll(cases))
            {
                temp.Add((MainTransformers)ygDDTransformer);
            }
            return temp;
        }
        public void edit(MainTransformers ygDDTransformer, Case cases)
        {
            if (ygDDTransformer.GetType().Name.Equals("YgDDTransformer"))
            {
                ygDDTransformerDA.Update((YgDDTransformer)ygDDTransformer, cases);
            }
        }
        public void remove(MainTransformers ygDDTransformer, Case Cases)
        {
            if (ygDDTransformer.GetType().Name.Equals("YgDDTransformer"))
            {
                ygDDTransformerDA.Delete((YgDDTransformer)ygDDTransformer, Cases);
            }
        }

        public MainTransformers add(Case cases)
        {
            YgDDTransformer ygDDTransformer = new YgDDTransformer();

            string name = ygDDTransformer.name;
            long code = ygDDTransformer.number;
            List<MainTransformers> ygDDTransformers = loadAll(cases);
            if (ygDDTransformers.Count() == 0)
            {
                name = name + " " + code;

            }
            else
            {
                foreach (YgDDTransformer b in ygDDTransformers)
                {
                    if (b.number >= code)
                    {
                        code = b.number + 1;
                    }
                }
                name = name + " " + code;
            }

            ygDDTransformer.name = name;
            ygDDTransformer.number = code;
            ZoneBL zoneBL = new ZoneBL();
            Display display = new Display();
            //resistance.display = display;

            if (zoneBL.loadAll().Count == 0)
            {
                ygDDTransformer.PrimaryBUS.zone = zoneBL.addZone();
            }
            else
            {
                ygDDTransformer.PrimaryBUS.zone = zoneBL.loadAll()[0];
            }
            AreaBL areaBL = new AreaBL();

            if (areaBL.loadAll().Count == 0)
            {
                ygDDTransformer.PrimaryBUS.area = areaBL.addArea();
            }
            else
            {
                ygDDTransformer.PrimaryBUS.area = areaBL.loadAll()[0];
            }

            create(ygDDTransformer, cases);

            return ygDDTransformer;
        }

        public override YgDDTransformer findByID(Case cases, long ID)
        {
            return ygDDTransformerDA.findByID(cases, ID);
        }
    }
}
