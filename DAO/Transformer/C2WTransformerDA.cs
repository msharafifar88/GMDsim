using persistent;
using persistent.network;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace DAO
{
    public class C2WTransformerDA : AbstractDA<C2WTransformer>
    {
        public void Create(C2WTransformer customTransformer, Case cases)
        {
            if (false)
            {
                GmdsimModel gmdsimModel = new GmdsimModel();
                gmdsimModel.Custom2WTransformers.Add(customTransformer);
                gmdsimModel.SaveChanges();
            }
            else
            {
                customTransformer.ID = findLastId(loadAll(cases));
                DataStored.addC2WTransformer(customTransformer, cases);
            }
        }

        public void Update(C2WTransformer customTransformer, Case cases)
        {
            if (false)
            {
                GmdsimModel gmdsimModel = new GmdsimModel();
                gmdsimModel.Custom2WTransformers.AddOrUpdate(customTransformer);
                gmdsimModel.SaveChanges();
            }
            else
            {
                DataStored.editC2WTransformer(customTransformer, cases);
            }
        }

        public void Delete(C2WTransformer customTransformer, Case cases)
        {
            if (false)
            {
                GmdsimModel gmdsimModel = new GmdsimModel();
                gmdsimModel.Custom2WTransformers.Remove(customTransformer);
                gmdsimModel.SaveChanges();
            }
            else
            {
                DataStored.removeC2WTransformer(customTransformer, cases);
            }

        }
        public List<C2WTransformer> loadAll(Case cases)
        {
            return DataStored.findAllC2WTransformer(cases).ToList();
        }
    }
}
