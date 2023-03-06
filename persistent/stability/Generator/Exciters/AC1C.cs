namespace persistent.stability
{
    public class AC1C : BaseStability, IStability
    {
        public AC1C()
        {
            base.GenExcitersModelType = GeneratorExcitersModelType.AC1C;
            base.stabilityType = enumeration.StabilityType.Generator;
            base.active = true;
        }

        public double OEL { set; get; }
        public double UEL { set; get; }
        public double SCL { set; get; }
        public double Tr { set; get; }
        public double Tb { set; get; }
        public double Tc { set; get; }
        public double Ka { set; get; }
        public double Ta { set; get; }
        public double VaMax { set; get; }
        public double Vamin { set; get; }
        public double Te { set; get; }
        public double Kf { set; get; }
        public double Tf { set; get; }
        public double Kc { set; get; }
        public double Kd { set; get; }
        public double Ke { set; get; }
        public double E1 { set; get; }
        public double SE1 { set; get; }
        public double E2 { set; get; }
        public double SE2 { set; get; }
        public double EefMax { set; get; }
        public double EefMin { set; get; }


        public bool getActive()
        {
            return base.active;
        }

        public string getName()
        {
            return base.GenExcitersModelType.ToString();
        }

        public override string ToString()
        {
            return base.GenExcitersModelType + "-" + base.active;
        }
    }
}
