using DAO;
using network;
using network.generator.Gentype;
using persistent;
using persistent.power;
using System.Collections.Generic;
using System.Linq;

namespace BL
{
    public class SyncGenBL : AbstractBL<SyncGen>
    {
        SyncGenDA syncGenDA = new SyncGenDA();


        public void create(SyncGen syncGen, Case cases)
        {
            syncGenDA.create(syncGen, cases);

        }
        public List<SyncGen> LoadAll(Case cases)
        {
            return DataStored.findAllSyncGen(cases).ToList<SyncGen>();
        }
        public void edit(SyncGen syncGen, Case cases)
        {
            syncGenDA.update(syncGen, cases);
        }
        public void remove(SyncGen syncGen, Case cases)
        {
            syncGenDA.delete(syncGen, cases);
        }
        public SyncGen addSyncGen(Case cases)
        {
            SyncGen syncGen = new SyncGen();


            string name = "SyncGen";
            long code = 1;
            List<SyncGen> syncGens = LoadAll(cases);
            if (syncGens.Count() == 0)
            {
                name = name + " " + code;

            }
            else
            {
                foreach (SyncGen SyncGen in syncGens)
                {
                    if (SyncGen.Code >= code)
                    {
                        code = SyncGen.Code + 1;
                    }
                }
                name = name + " " + code;
            }
            //BusBL bus = new BusBL();
            syncGen.Name = name;
            syncGen.Code = code;
            VoltageControl voltageControl = new VoltageControl();
            PowerControl powerControl = new PowerControl();
            syncGen.voltageControl = voltageControl;
            syncGen.powerControl = powerControl;
            // This line must Comment
            // BusBL busBL = new BusBL();
            // generator.Bus = busBL.addBus(cases);
            create(syncGen, cases);

            return syncGen;
        }

        public override SyncGen findByID(Case cases, long ID)
        {
            return syncGenDA.findByID(cases, ID);
        }
        public List<SyncGen> findGeneratorByBus(Case cases, Bus bus)
        {
            List<SyncGen> syncGens = new List<SyncGen>();
            foreach (SyncGen g in LoadAll(cases))
            {
                if (g.Bus.Equals(bus))
                {
                    syncGens.Add(g);
                }
            }
            return syncGens;
        }

        public List<SyncGen> findGeneratorHasAVRByBus(Case cases, Bus bus)
        {
            List<SyncGen> syncGens = new List<SyncGen>();
            foreach (SyncGen g in LoadAll(cases))
            {
                if (g.Bus.Equals(bus) && g.powerControl.availableAVR)
                {
                    syncGens.Add(g);
                }
            }
            return syncGens;
        }
    }
}
