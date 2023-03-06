namespace network
{
    public class TTransformer : MainTransformers
    {
        public int windingA { get; set; } = 0;
        public int windingB { get; set; } = 0;
        public int windingC { get; set; } = 0;
        public int phaseBDelay { get; set; } = 0;
        public int phaseCDelay { get; set; } = 0;
        public double voltageA { get; set; } = 230;
        public double voltageB { get; set; } = 27.6;
        public double voltageC { get; set; } = 120;
        public double powerA { get; set; } = 125;
        public double powerB { get; set; } = 125;
        public double powerC { get; set; } = 125;
        public double windingRAB { get; set; } = 0.4;
        public double windingRAC { get; set; } = 0.006;
        public double windingRBC { get; set; } = 0.1;
        public double windingXAB { get; set; } = 0;
        public double windingXAC { get; set; } = 0;
        public double windingXBC { get; set; } = 0;
        public double windingAZ { get; set; } = 0;
        public double windingBZ { get; set; } = 0;
        public double windingCZ { get; set; } = 0;
        public bool windingAcurrent { get; set; } = false;
        public bool windingBcurrent { get; set; } = false;
        public bool windingCcurrent { get; set; } = false;


    }
}
