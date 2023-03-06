namespace network
{
    public class C3WTransformer : MainTransformers
    {
        public int windingA { get; set; } = 1;
        public int windingB { get; set; } = 5;
        public int phaseBDelay { get; set; } = 1;
        public double nominalPower { get; set; } = 200;
        public double voltageA { get; set; } = 315;
        public double voltageB { get; set; } = 120;
        public double windingImpedanceOnA { get; set; } = 0.9;
        public bool checkedWindingImpedance { get; set; } = true;
        public double winding1R { get; set; } = 0.00375;
        public double winding1X { get; set; } = 0.15;
        public double winding2R { get; set; } = double.NaN;
        public double winding2X { get; set; } = double.NaN;
        public double windingAZ { get; set; } = 0;
        public double windingBZ { get; set; } = 0;
        public bool windingAcurrent { get; set; } = false;
        public bool windingBcurrent { get; set; } = false;
    }
}
