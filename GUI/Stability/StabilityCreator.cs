using GUI.Stability.Generator_Stability;
using GUI.Stability.GeneratorExciters;
using persistent.enumeration;
using persistent.stability;
using persistent.stability.Generator.Stabilizers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.Stability
{
    public class StabilityCreator
    {

        public static  StabilityForm  CreateForm(StabilityType stability)
        {
            if (stability.Equals(StabilityType.Line))
            {

            }else if (stability.Equals(StabilityType.Bus))
            {

            }

            return null;
        }
        public static StabilityForm CreateForm(GeneratorModelType generatorModel)
        {          
                if (generatorModel.Equals(GeneratorModelType.GENROU))
                {
                    return new GenROU();
                }
                if (generatorModel.Equals(GeneratorModelType.CSVBN1))
                {
                    return new GenROU();
                }
                if (generatorModel.Equals(GeneratorModelType.GenSAL))
                {
                    return new GenSAL();
                }
                if (generatorModel.Equals(GeneratorModelType.GenCLS))
                {
                    return new GenROU();
                }
                if (generatorModel.Equals(GeneratorModelType.CBEST))
                {
                    return new GenROU();
                }

            return null;
        }
        public static StabilityForm CreateForm(GeneratorExcitersModelType excitersModel)
        {
            if (excitersModel.Equals(GeneratorExcitersModelType.AC1C))
            {
                return new Ac1c();
            }
            if (excitersModel.Equals(GeneratorExcitersModelType.ESAC1A))
            {
                return new GenROU();
            }
            if (excitersModel.Equals(GeneratorExcitersModelType.AC3C))
            {
                return new GenSAL();
            }
            if (excitersModel.Equals(GeneratorExcitersModelType.AC4C))
            {
                return new GenROU();
            }
            if (excitersModel.Equals(GeneratorExcitersModelType.AC5C))
            {
                return new GenROU();
            }

            return null;
        }
        public static StabilityForm CreateForm(GeneratorGovernorsModelType generatorGovernorsModel)
        {
            if (generatorGovernorsModel.Equals(GeneratorGovernorsModelType.BBGOV1))
            {
                return new Ac1c();
            }
            if (generatorGovernorsModel.Equals(GeneratorGovernorsModelType.CCBT1))
            {
                return new GenROU();
            }
            if (generatorGovernorsModel.Equals(GeneratorGovernorsModelType.CRCMGV))
            {
                return new GenSAL();
            }
            if (generatorGovernorsModel.Equals(GeneratorGovernorsModelType.DEGOV))
            {
                return new GenROU();
            }
            if (generatorGovernorsModel.Equals(GeneratorGovernorsModelType.GAST2A))
            {
                return new GenROU();
            }
            if (generatorGovernorsModel.Equals(GeneratorGovernorsModelType.GASTD))
            {
                return new GenROU();
            }

            return null;
        }

             public static StabilityForm CreateForm(GeneratorStabilizersModelType stabilizersModelType)
            {
            if (stabilizersModelType.Equals(GeneratorStabilizersModelType.IEE2ST))
            {
                return new Ac1c();
            }
            if (stabilizersModelType.Equals(GeneratorStabilizersModelType.PSS1A))
            {
                return new GenROU();
            }
            if (stabilizersModelType.Equals(GeneratorStabilizersModelType.PSSSB))
            {
                return new GenSAL();
            }
            if (stabilizersModelType.Equals(GeneratorStabilizersModelType.PSSSH))
            {
                return new GenROU();
            }
            if (stabilizersModelType.Equals(GeneratorStabilizersModelType.STBSVC))
            {
                return new GenROU();
            }
            if (stabilizersModelType.Equals(GeneratorStabilizersModelType.WSCCST))
            {
                return new GenROU();
            }

            return null;
        }


    }
}
