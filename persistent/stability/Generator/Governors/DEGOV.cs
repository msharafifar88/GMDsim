namespace persistent.stability
{
    public class DEGOV : BaseStability, IStability
    {
        public DEGOV()
        {
            base.GenGovernorsModelType = GeneratorGovernorsModelType.DEGOV;
            base.stabilityType = enumeration.StabilityType.Generator;
            base.active = true;
        }

        public double T1 { set; get; }
        public double T2 { set; get; }
        public double T3 { set; get; }
        public double K { set; get; }
        public double T4 { set; get; }
        public double T5 { set; get; }
        public double T6 { set; get; }
        public double Td { set; get; }
        public double Tmax { set; get; }
        public double Tmin { set; get; }



        public bool getActive()
        {
            return base.active;
        }

        public string getName()
        {
            return base.GenGovernorsModelType.ToString();
        }

        public override string ToString()
        {
            return base.GenGovernorsModelType + "-" + base.active;
        }
    }
}
