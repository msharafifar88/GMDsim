namespace persistent.stability
{
    public class ESAC1A : BaseStability, IStability
    {
        public ESAC1A()
        {
            base.GenExcitersModelType = GeneratorExcitersModelType.ESAC1A;
            base.stabilityType = enumeration.StabilityType.Generator;
            base.active = true;
        }

        public double TR { set; get; }
        public double Tb { set; get; }
        public double Tc { set; get; }
        public double Ka { set; get; }
        public double Ta { set; get; }
        public double VaMax { set; get; }
        public double VaMin { set; get; }
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
        public double Vrmax { set; get; }
        public double Vrmin { set; get; }
        public double Spdmlt { set; get; }


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
