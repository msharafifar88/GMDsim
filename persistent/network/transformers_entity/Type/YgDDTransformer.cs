namespace network
{
    public class YgDDTransformer : MainTransformers
    {
        public int windingA { get; set; } = 2;
        public int windingB { get; set; } = 5;
        public int windingC { get; set; } = 5;
        public int phaseBDelay { get; set; } = 0;
        public int phaseCDelay { get; set; } = 0;
        public double voltageA { get; set; } = 735;
        public double voltageB { get; set; } = 13.8;
        public double voltageC { get; set; } = 13.8;
        public double powerA { get; set; } = 350;
        public double powerB { get; set; } = 350;
        public double powerC { get; set; } = 350;
        public double windingRAB { get; set; } = 0.0021;
        public double windingRAC { get; set; } = 0.0020;
        public double windingRBC { get; set; } = 0.0040;
        public double windingXAB { get; set; } = 0.1510;
        public double windingXAC { get; set; } = 0.1509;
        public double windingXBC { get; set; } = 0.2770;
        public double windingAZ { get; set; } = 0;
        public double windingBZ { get; set; } = 0;
        public double windingCZ { get; set; } = 0;
        public bool windingAcurrent { get; set; } = false;
        public bool windingBcurrent { get; set; } = false;
        public bool windingCcurrent { get; set; } = false;
    }
}
