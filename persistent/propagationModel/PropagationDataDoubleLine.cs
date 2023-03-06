using System;
using System.Runtime.Serialization;

namespace propagationModel
{
    [DataContract]
    public class PropagationDataDoubleLine
    {
        [DataMember]
        public double Length { get; set; }
        [DataMember]
        public double ResistancePrime { get; set; }
        [DataMember]
        public double ImpedancePrime { get; set; }
        [DataMember]
        public double CapacitancePrime { get; set; }

        public PropagationDataDoubleLine(double length, double rPrime, double lPrime, double cPrime)
        {

            this.Length = length;
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
                    case 0: return Length;
                    case 1: return ResistancePrime;
                    case 2: return ImpedancePrime;
                    case 3: return CapacitancePrime;
                    default: return Double.NaN;
                }
            }
        }
    }


}
