namespace network
{
    public class YgYgDTransformer : MainTransformers
    {
        public int windingA { get; set; } = 2;
        public int windingB { get; set; } = 2;
        public int windingC { get; set; } = 5;
        public int phaseBDelay { get; set; } = 0;
        public int phaseCDelay { get; set; } = 0;
        public double voltageA { get; set; } = 735;
        public double voltageB { get; set; } = 315;
        public double voltageC { get; set; } = 15;
        public double powerA { get; set; } = 1110;
        public double powerB { get; set; } = 71;
        public double powerC { get; set; } = 71;
        public double windingRAB { get; set; } = 0.0024;
        public double windingRAC { get; set; } = 0.0010;
        public double windingRBC { get; set; } = 0.00048;
        public double windingXAB { get; set; } = 0.20;
        public double windingXAC { get; set; } = 0.026;
        public double windingXBC { get; set; } = 0.012;
        public double windingAZ { get; set; } = 0;
        public double windingBZ { get; set; } = 0;
        public double windingCZ { get; set; } = 0;
        public bool windingAcurrent { get; set; } = false;
        public bool windingBcurrent { get; set; } = false;
        public bool windingCcurrent { get; set; } = false;
    }
}
