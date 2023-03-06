using System;

namespace propagationModel
{
    public class MatrixCoeficients
    {
        public double One { get; set; }
        public double Two { get; set; }
        public double Three { get; set; }

        public MatrixCoeficients(double one, double two, double three)
        {

            this.One = one;
            this.Two = two;
            this.Three = three;
        }
        public double this[int i]
        {
            get
            {
                switch (i)
                {
                    case 0: return One;
                    case 1: return Two;
                    case 2: return Three;
                    default: return Double.NaN;
                }
            }
        }
    }
}
