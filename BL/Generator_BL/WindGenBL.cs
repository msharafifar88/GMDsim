using DAO;
using network.generator.Gentype;
using persistent;
using persistent.power;
using System.Collections.Generic;
using System.Linq;


namespace BL
{
    public class WindGenBL : AbstractBL<WindGen>
    {
        WindGenDA windGenDA = new WindGenDA();

        public void create(WindGen windGen, Case cases)
        {
            windGenDA.create(windGen, cases);

        }
        public List<WindGen> LoadAll(Case cases)
        {
            return DataStored.findAllWindGen(cases).ToList<WindGen>();
        }
        public void edit(WindGen windGen, Case cases)
        {
            windGenDA.update(windGen, cases);
        }
        public void remove(WindGen windGen, Case cases)
        {
            windGenDA.delete(windGen, cases);
        }
        public WindGen addWindGen(Case cases)
        {
            WindGen windGen = new WindGen();


            string name = "WindGen";
            long code = 1;
            List<WindGen> windGens = LoadAll(cases);
            if (windGens.Count() == 0)
            {
                name = name + " " + code;

            }
            else
            {
                foreach (WindGen WindGen in windGens)
                {
                    if (WindGen.Code >= code)
                    {
                        code = WindGen.Code + 1;
                    }
                }
                name = name + " " + code;
            }
            //BusBL bus = new BusBL();
            windGen.Name = name;
            windGen.Code = code;
            VoltageControl voltageControl = new VoltageControl();
            PowerControl powerControl = new PowerControl();
            windGen.voltageControl = voltageControl;
            windGen.powerControl = powerControl;
            // This line must Comment
            // BusBL busBL = new BusBL();
            // generator.Bus = busBL.addBus(cases);
            create(windGen, cases);

            return windGen;
        }

        public override WindGen findByID(Case cases, long ID)
        {
            return windGenDA.findByID(cases, ID);
        }
    }
}
