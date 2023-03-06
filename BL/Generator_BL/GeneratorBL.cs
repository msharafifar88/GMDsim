using DAO;
using network;
using persistent;
using persistent.power;
using System.Collections.Generic;
using System.Linq;

namespace BL
{
    public class GeneratorBL : AbstractBL<Generator>
    {
        GeneratorDA generatorDa = new GeneratorDA();


        public void create(Generator generator, Case cases)
        {
            generatorDa.create(generator, cases);

        }
        public List<Generator> LoadAll(Case cases)
        {
            return DataStored.findAllGenerator(cases).ToList<Generator>();
        }
        public void edit(Generator generator, Case cases)
        {
            generatorDa.update(generator, cases);
        }
        public void remove(Generator generator, Case cases)
        {
            generatorDa.delete(generator, cases);
        }
        public Generator addGenerator(Case cases)
        {
            Generator generator = new Generator();


            string name = "GEN";
            long code = 1;
            List<Generator> generators = LoadAll(cases);
            if (generators.Count() == 0)
            {
                name = name + " " + code;

            }
            else
            {
                foreach (Generator gen in generators)
                {
                    if (gen.Code >= code)
                    {
                        code = gen.Code + 1;
                    }
                }
                name = name + " " + code;
            }
            //BusBL bus = new BusBL();
            generator.Code = code;
            generator.Name = name;
            VoltageControl voltageControl = new VoltageControl();
            PowerControl powerControl = new PowerControl();
            generator.voltageControl = voltageControl;
            generator.powerControl = powerControl;
            // This line must Comment
            // BusBL busBL = new BusBL();
            // generator.Bus = busBL.addBus(cases);
            create(generator, cases);

            return generator;
        }

        public override Generator findByID(Case cases, long ID)
        {
            return generatorDa.findByID(cases, ID);
        }
        public List<Generator> findGeneratorByBus(Case cases, Bus bus)
        {
            List<Generator> generators = new List<Generator>();
            foreach (Generator g in LoadAll(cases))
            {
                if (g.Bus.Equals(bus))
                {
                    generators.Add(g);
                }
            }
            return generators;
        }

        public List<Generator> findGeneratorHasAVRByBus(Case cases, Bus bus)
        {
            List<Generator> generators = new List<Generator>();
            foreach (Generator g in LoadAll(cases))
            {
                if (g.Bus.Equals(bus) && g.powerControl.availableAVR)
                {
                    generators.Add(g);
                }
            }
            return generators;
        }
    }
}
