using network;
using persistent;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace DAO
{
    public class YgDDTransformerDA : AbstractDA<YgDDTransformer>
    {
        public void Create(YgDDTransformer ygDDTransformer, Case cases)
        {
            if (false)
            {
                GmdsimModel gmdsimModel = new GmdsimModel();
                gmdsimModel.YgDDTransformers.Add(ygDDTransformer);
                gmdsimModel.SaveChanges();
            }
            else
            {
                ygDDTransformer.ID = findLastId(loadAll(cases));
                DataStored.addYgDDTransformer(ygDDTransformer, cases);
            }
        }

        public void Update(YgDDTransformer ygDDTransformer, Case cases)
        {
            if (false)
            {
                GmdsimModel gmdsimModel = new GmdsimModel();
                gmdsimModel.YgDDTransformers.AddOrUpdate(ygDDTransformer);
                gmdsimModel.SaveChanges();
            }
            else
            {
                DataStored.editYgDDTransformer(ygDDTransformer, cases);
            }
        }

        public void Delete(YgDDTransformer ygDDTransformer, Case cases)
        {
            if (false)
            {
                GmdsimModel gmdsimModel = new GmdsimModel();
                gmdsimModel.YgDDTransformers.Remove(ygDDTransformer);
                gmdsimModel.SaveChanges();
            }
            else
            {
                DataStored.removeYgDDTransformer(ygDDTransformer, cases);
            }

        }
        public List<YgDDTransformer> loadAll(Case cases)
        {
            return DataStored.findAllYgDDTransformer(cases).ToList();
        }

        public YgDDTransformer findByID(Case cases, long ID)
        {
            List<YgDDTransformer> ygDDs = loadAll(cases);
            foreach (YgDDTransformer ygDD in ygDDs)
            {
                if (ygDD.ID == ID)
                {
                    return ygDD;
                }
            }
            return null;
        }
    }
}
