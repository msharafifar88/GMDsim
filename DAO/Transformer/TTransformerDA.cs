using network;
using persistent;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace DAO
{
    public class TTransformerDA : AbstractDA<TTransformer>
    {
        public void Create(TTransformer customTransformer, Case cases)
        {
            if (false)
            {
                GmdsimModel gmdsimModel = new GmdsimModel();
                gmdsimModel.CustomTransformers.Add(customTransformer);
                gmdsimModel.SaveChanges();
            }
            else
            {
                customTransformer.ID = findLastId(loadAll(cases));
                DataStored.addTTransformer(customTransformer, cases);
            }
        }

        public void Update(TTransformer customTransformer, Case cases)
        {
            if (false)
            {
                GmdsimModel gmdsimModel = new GmdsimModel();
                gmdsimModel.CustomTransformers.AddOrUpdate(customTransformer);
                gmdsimModel.SaveChanges();
            }
            else
            {
                DataStored.editTTransformer(customTransformer, cases);
            }
        }

        public void Delete(TTransformer customTransformer, Case cases)
        {
            if (false)
            {
                GmdsimModel gmdsimModel = new GmdsimModel();
                gmdsimModel.CustomTransformers.Remove(customTransformer);
                gmdsimModel.SaveChanges();
            }
            else
            {
                DataStored.removeTTransformer(customTransformer, cases);
            }

        }
        public List<TTransformer> loadAll(Case cases)
        {
            return DataStored.findAllTTransformer(cases).ToList();
        }
    }
}
