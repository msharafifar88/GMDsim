using network;
using persistent;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace DAO
{
    public class Single3phaseLineDA : AbstractDA<Single3phaseLine>
    {
        public void Create(Single3phaseLine single3phaseLine, Case cases)
        {
            if (false)
            {
                GmdsimModel gmdsimModel = new GmdsimModel();
                gmdsimModel.Single3phaseLines.Add(single3phaseLine);
                gmdsimModel.SaveChanges();
            }
            else
            {
                single3phaseLine.ID = findLastId(loadAll(cases));
                DataStored.addSingle3phaseLine(single3phaseLine, cases);
            }
        }

        public void Update(Single3phaseLine single3phaseLine, Case cases)
        {
            if (false)
            {
                GmdsimModel gmdsimModel = new GmdsimModel();
                gmdsimModel.Single3phaseLines.AddOrUpdate(single3phaseLine);
                gmdsimModel.SaveChanges();
            }
            else
            {
                DataStored.editSingle3phaseLine(single3phaseLine, cases);
            }
        }

        public void Delete(Single3phaseLine single3phaseLine, Case cases)
        {
            if (false)
            {
                GmdsimModel gmdsimModel = new GmdsimModel();
                gmdsimModel.Single3phaseLines.Remove(single3phaseLine);
                gmdsimModel.SaveChanges();
            }
            else
            {
                DataStored.removeSingle3phaseLine(single3phaseLine, cases);
            }

        }

        public List<Single3phaseLine> loadAll(Case cases)
        {
            return DataStored.findAllSingle3phaseLine(cases).ToList();
        }

        public Single3phaseLine findByID(Case cases, long ID)
        {
            List<Single3phaseLine> Single3phaseLines = loadAll(cases);
            foreach (Single3phaseLine sing3phase in Single3phaseLines)
            {
                if (sing3phase.ID == ID)
                {
                    return sing3phase;
                }
            }
            return null;
        }
    }
}
