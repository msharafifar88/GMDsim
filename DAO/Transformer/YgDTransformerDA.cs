using network;
using persistent;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace DAO
{
    public class YgDTransformerDA : AbstractDA<YgDTransformer>
    {
        public void Create(YgDTransformer ygDTransformer, Case cases)
        {
            if (false)
            {
                GmdsimModel gmdsimModel = new GmdsimModel();
                gmdsimModel.YgDTransformers.Add(ygDTransformer);
                gmdsimModel.SaveChanges();
            }
            else
            {
                ygDTransformer.ID = findLastId(loadAll(cases));
                DataStored.addYgDTransformer(ygDTransformer, cases);
            }
        }

        public void Update(YgDTransformer ygDTransformer, Case cases)
        {
            if (false)
            {
                GmdsimModel gmdsimModel = new GmdsimModel();
                gmdsimModel.YgDTransformers.AddOrUpdate(ygDTransformer);
                gmdsimModel.SaveChanges();
            }
            else
            {
                DataStored.editYgDTransformer(ygDTransformer, cases);
            }
        }

        public void Delete(YgDTransformer ygDTransformer, Case cases)
        {
            if (false)
            {
                GmdsimModel gmdsimModel = new GmdsimModel();
                gmdsimModel.YgDTransformers.Remove(ygDTransformer);
                gmdsimModel.SaveChanges();
            }
            else
            {
                DataStored.removeYgDTransformer(ygDTransformer, cases);
            }

        }
        public List<YgDTransformer> loadAll(Case cases)
        {
            return DataStored.findAllYgDTransformer(cases).ToList();
        }

        public YgDTransformer findByID(Case cases, long ID)
        {
            List<YgDTransformer> ygDs = loadAll(cases);
            foreach (YgDTransformer ygD in ygDs)
            {
                if (ygD.ID == ID)
                {
                    return ygD;
                }
            }
            return null;
        }
    }
}
