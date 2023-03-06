using System;



namespace propagationModel
{
    public class PropagationData
    {
        public double ResistancePrime { get; set; }
        public double ImpedancePrime { get; set; }
        public double CapacitancePrime { get; set; }

        public PropagationData(double rPrime, double lPrime, double cPrime)
        {

            this.ResistancePrime = rPrime;
            this.ImpedancePrime = lPrime;
            this.CapacitancePrime = cPrime;
        }
        public double this[int i]
        {
            get
            {
                switch (i)
                {
                    case 0: return ResistancePrime;
                    case 1: return ImpedancePrime;
                    case 2: return CapacitancePrime;
                    default: return Double.NaN;
                }
            }
        }
    }
}

