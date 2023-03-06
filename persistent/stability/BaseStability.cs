using bases;
using persistent.enumeration;
using persistent.stability.Generator.Stabilizers;
using System;

namespace persistent.stability
{
    public class BaseStability : BaseEntity
    {
        public Boolean active;
        public GeneratorModelType modelType;
        public StabilityType stabilityType;
        public GeneratorExcitersModelType GenExcitersModelType;
        public GeneratorGovernorsModelType GenGovernorsModelType;
        public GeneratorStabilizersModelType GenStabilizersModelType;

    }
}
