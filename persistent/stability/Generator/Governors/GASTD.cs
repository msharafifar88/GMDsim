namespace persistent.stability
{
    public class GASTD : BaseStability, IStability
    {
        public GASTD()
        {
            base.GenGovernorsModelType = GeneratorGovernorsModelType.GASTD;
            base.stabilityType = enumeration.StabilityType.Generator;
            base.active = true;
        }

        public double R { set; get; }
        public double T1 { set; get; }
        public double T2 { set; get; }
        public double T3 { set; get; }
        public double At { set; get; }
        public double Kt { set; get; }
        public double Vmax { set; get; }
        public double Vmin { set; get; }
        public double Dturb { set; get; }
        public double dbh { set; get; }
        public double dbL { set; get; }
        public double Trate { set; get; }


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
