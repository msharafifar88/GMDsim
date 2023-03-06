using persistent.stability.Generator.Stabilizers;

namespace persistent.stability
{
    public class PSSSH : BaseStability, IStability
    {
        public PSSSH()
        {
            base.GenStabilizersModelType = GeneratorStabilizersModelType.PSSSH;
            base.stabilityType = enumeration.StabilityType.Generator;
            base.active = true;
        }

        public double K { set; get; }
        public double K0 { set; get; }
        public double K1 { set; get; }
        public double K2 { set; get; }
        public double K3 { set; get; }
        public double K4 { set; get; }
        public double Td { set; get; }
        public double T1 { set; get; }
        public double T2 { set; get; }
        public double T3 { set; get; }
        public double T4 { set; get; }
        public double Vsmax { set; get; }
        public double Vsmin { set; get; }


        public bool getActive()
        {
            return base.active;
        }

        public string getName()
        {
            return base.GenStabilizersModelType.ToString();
        }

        public override string ToString()
        {
            return base.GenStabilizersModelType + "-" + base.active;
        }
    }
}
