using network;
using persistent;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace DAO
{
    public class TriTransformerDA : AbstractDA<C3WTransformer>
    {
        public void Create(C3WTransformer transformer, Case cases)
        {
            if (false)
            {
                GmdsimModel gmdsimModel = new GmdsimModel();
                gmdsimModel.TriTransformers.Add(transformer);
                gmdsimModel.SaveChanges();
            }
            else
            {
                transformer.ID = findLastId(loadAll(cases));
                DataStored.addTriTransformer(transformer, cases);
            }
        }

        public void Update(C3WTransformer transformer, Case cases)
        {
            if (false)
            {
                GmdsimModel gmdsimModel = new GmdsimModel();
                gmdsimModel.TriTransformers.AddOrUpdate(transformer);
                gmdsimModel.SaveChanges();
            }
            else
            {
                DataStored.editTriTransformer(transformer, cases);
            }
        }

        public void Delete(C3WTransformer transformer, Case cases)
        {
            if (false)
            {
                GmdsimModel gmdsimModel = new GmdsimModel();
                gmdsimModel.TriTransformers.Remove(transformer);
                gmdsimModel.SaveChanges();
            }
            else
            {
                DataStored.removeTriTransformer(transformer, cases);
            }

        }
        public List<C3WTransformer> loadAll(Case cases)
        {
            return DataStored.findAllTriTransformer(cases).ToList();
        }
    }
}
