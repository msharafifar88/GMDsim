using persistent.stability.Generator.Stabilizers;

namespace persistent.stability
{
    public class IEE2ST : BaseStability, IStability
    {
        public IEE2ST()
        {
            base.GenStabilizersModelType = GeneratorStabilizersModelType.IEE2ST;
            base.stabilityType = enumeration.StabilityType.Generator;
            base.active = true;
        }

        public double Ics1 { set; get; }
        public double Ics2 { set; get; }
        public double K1 { set; get; }
        public double K2 { set; get; }
        public double T1 { set; get; }
        public double T2 { set; get; }
        public double T3 { set; get; }
        public double T4 { set; get; }
        public double T5 { set; get; }
        public double T6 { set; get; }
        public double T7 { set; get; }
        public double T8 { set; get; }
        public double T9 { set; get; }
        public double T10 { set; get; }
        public double Lsmax { set; get; }
        public double Lsmin { set; get; }
        public double Vcu { set; get; }
        public double Vcl { set; get; }

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
