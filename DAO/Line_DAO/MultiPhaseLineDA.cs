using network;
using persistent;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace DAO
{
    public class MultiPhaseLineDA : AbstractDA<MultiPhaseLine>
    {
        public void Create(MultiPhaseLine multiPhase, Case cases)
        {
            if (false)
            {
                GmdsimModel gmdsimModel = new GmdsimModel();
                gmdsimModel.TriLines.Add(multiPhase);
                gmdsimModel.SaveChanges();
            }
            else
            {
                multiPhase.ID = findLastId(loadAll(cases));
                DataStored.addMultiPhaseLine(multiPhase, cases);
            }
        }

        public void Update(MultiPhaseLine multiPhase, Case cases)
        {
            if (false)
            {
                GmdsimModel gmdsimModel = new GmdsimModel();
                gmdsimModel.TriLines.AddOrUpdate(multiPhase);
                gmdsimModel.SaveChanges();
            }
            else
            {
                DataStored.editMultiPhaseLine(multiPhase, cases);
            }
        }

        public void Delete(MultiPhaseLine multiPhase, Case cases)
        {
            if (false)
            {
                GmdsimModel gmdsimModel = new GmdsimModel();
                gmdsimModel.TriLines.Remove(multiPhase);
                gmdsimModel.SaveChanges();
            }
            else
            {
                DataStored.removeMultiPhaseLine(multiPhase, cases);
            }

        }
        public List<MultiPhaseLine> loadAll(Case cases)
        {
            return DataStored.findAllMultiPhaseLine(cases).ToList();
        }

        public MultiPhaseLine findByID(Case cases, long ID)
        {
            List<MultiPhaseLine> multiPhaseLines = loadAll(cases);
            foreach (MultiPhaseLine mline in multiPhaseLines)
            {
                if (mline.ID == ID)
                {
                    return mline;
                }
            }
            return null;
        }
    }
}
