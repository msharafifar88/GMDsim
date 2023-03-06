using DAO;
using DAO.Generator_DAO;
using network.generator.Gentype;
using persistent;
using persistent.power;
using System.Collections.Generic;
using System.Linq;

namespace BL
{
    public class PVGenBL : AbstractBL<PVGen>
    {
        PVGenDA pvGenDA = new PVGenDA();


        public void create(PVGen pvGEN, Case cases)
        {
            pvGenDA.create(pvGEN, cases);

        }
        public List<PVGen> LoadAll(Case cases)
        {
            return DataStored.findAllPVGen(cases).ToList<PVGen>();
        }
        public void edit(PVGen pvGEN, Case cases)
        {
            pvGenDA.update(pvGEN, cases);
        }
        public void remove(PVGen pvGEN, Case cases)
        {
            pvGenDA.delete(pvGEN, cases);
        }
        public PVGen addPVGen(Case cases)
        {
            PVGen pvGEN = new PVGen();


            string name = "PVGen";
            long code = 1;
            List<PVGen> pVGens = LoadAll(cases);
            if (pVGens.Count() == 0)
            {
                name = name + " " + code;

            }
            else
            {
                foreach (PVGen gen in pVGens)
                {
                    if (gen.Code >= code)
                    {
                        code = gen.Code + 1;
                    }
                }
                name = name + " " + code;
            }
            //BusBL bus = new BusBL();
            pvGEN.Code = code;
            pvGEN.Name = name;
            VoltageControl voltageControl = new VoltageControl();
            PowerControl powerControl = new PowerControl();
            pvGEN.voltageControl = voltageControl;
            pvGEN.powerControl = powerControl;
            // This line must Comment
            // BusBL busBL = new BusBL();
            // generator.Bus = busBL.addBus(cases);
            create(pvGEN, cases);

            return pvGEN;
        }

        public override PVGen findByID(Case cases, long ID)
        {
            return pvGenDA.findByID(cases, ID);
        }
    }
}
