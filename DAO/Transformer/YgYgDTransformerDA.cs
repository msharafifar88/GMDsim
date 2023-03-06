using network;
using persistent;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace DAO
{
    public class YgYgDTransformerDA : AbstractDA<YgYgDTransformer>
    {
        public void Create(YgYgDTransformer ygYgDTransformer, Case cases)
        {
            if (false)
            {
                GmdsimModel gmdsimModel = new GmdsimModel();
                gmdsimModel.YgYgDTransformers.Add(ygYgDTransformer);
                gmdsimModel.SaveChanges();
            }
            else
            {
                ygYgDTransformer.ID = findLastId(loadAll(cases));
                DataStored.addYgYgDTransformer(ygYgDTransformer, cases);
            }
        }

        public void Update(YgYgDTransformer ygYgDTransformer, Case cases)
        {
            if (false)
            {
                GmdsimModel gmdsimModel = new GmdsimModel();
                gmdsimModel.YgYgDTransformers.AddOrUpdate(ygYgDTransformer);
                gmdsimModel.SaveChanges();
            }
            else
            {
                DataStored.editYgYgDTransformer(ygYgDTransformer, cases);
            }
        }

        public void Delete(YgYgDTransformer ygYgDTransformer, Case cases)
        {
            if (false)
            {
                GmdsimModel gmdsimModel = new GmdsimModel();
                gmdsimModel.YgYgDTransformers.Remove(ygYgDTransformer);
                gmdsimModel.SaveChanges();
            }
            else
            {
                DataStored.removeYgYgDTransformer(ygYgDTransformer, cases);
            }

        }
        public List<YgYgDTransformer> loadAll(Case cases)
        {
            return DataStored.findAllYgYgDTransformer(cases).ToList();
        }

        public YgYgDTransformer findByID(Case cases, long ID)
        {
            List<YgYgDTransformer> ygYgDTransformers = loadAll(cases);
            foreach (YgYgDTransformer ygYgD in ygYgDTransformers)
            {
                if (ygYgD.ID == ID)
                {
                    return ygYgD;
                }
            }
            return null;
        }
    }
}
