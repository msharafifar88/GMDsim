namespace persistent.stability
{
    public class GENSAL : BaseStability, IStability
    {
        public GENSAL()
        {
            base.modelType = GeneratorModelType.GenSAL;
            base.stabilityType = enumeration.StabilityType.Generator;
            base.active = true;
        }

        public double H { set; get; }
        public double D { set; get; }
        public double RA { set; get; }
        public double XD { set; get; }
        public double XQ { set; get; }
        public double XDP { set; get; }
        public double XQP { set; get; }
        public double XDPP { set; get; }
        public double XI { set; get; }
        public double TDOP { set; get; }
        public double TQOP { set; get; }
        public double TDQPP { set; get; }
        public double TQOPP { set; get; }
        public double S1 { set; get; }
        public double S12 { set; get; }
        public double RCOMP { set; get; }
        public double XCOMP { set; get; }

        public bool getActive()
        {
            return base.active;
        }

        public string getName()
        {
            return base.modelType.ToString();
        }

        public override string ToString()
        {
            return base.modelType + "-" + base.active;
        }
    }
}
