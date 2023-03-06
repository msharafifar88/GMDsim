namespace persistent.stability
{
    public class BBGOV1 : BaseStability, IStability
    {
        public BBGOV1()
        {
            base.GenGovernorsModelType = GeneratorGovernorsModelType.BBGOV1;
            base.stabilityType = enumeration.StabilityType.Generator;
            base.active = true;
        }

        public double Fcut { set; get; }
        public double Ks { set; get; }
        public double Kls { set; get; }
        public double Kg { set; get; }
        public double Kp { set; get; }
        public double Tn { set; get; }
        public double Kd { set; get; }
        public double Td { set; get; }
        public double T4 { set; get; }
        public double K2 { set; get; }
        public double T5 { set; get; }
        public double K3 { set; get; }
        public double T6 { set; get; }
        public double T1 { set; get; }
        public double Switch { set; get; }
        public double Pmax { set; get; }
        public double Pmin { set; get; }



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
