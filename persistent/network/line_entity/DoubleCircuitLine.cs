using propagationModel;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace network
{
    [DataContract]
    public class DoubleCircuitLine : LineBranches
    {
        [DataMember]
        private static List<double> length = new List<double>() { 218, 218, 218 };
        [DataMember]
        private static List<double> rPrimeList = new List<double>() { 0.5306, 0.0117, 0.0304 };
        [DataMember]
        private static List<double> lPrimeList = new List<double>() { 1.521, 0.3270, 0.6560 };
        [DataMember]
        private static List<double> cPrimeList = new List<double>() { 3.239, 4.920, 3.239 };
        [DataMember]
        private static List<PropagationDataDoubleLine> temp = new List<PropagationDataDoubleLine>()
        {
               new PropagationDataDoubleLine(length[0],rPrimeList[0], lPrimeList[0], cPrimeList[0]),
               new PropagationDataDoubleLine(length[1],rPrimeList[1], lPrimeList[1], cPrimeList[1]),
               new PropagationDataDoubleLine(length[2],rPrimeList[2], lPrimeList[2], cPrimeList[2])
        };
        [DataMember]
        public List<PropagationDataDoubleLine> propagationSet { get; set; } = temp;
        [DataMember]
        public double VoltageA { get; set; } = 0;
        [DataMember]
        public double VoltageB { get; set; } = 0;
        [DataMember]
        public double VoltageC { get; set; } = 0;
        [DataMember]
        public double Angmin { get; set; } = -360;
        [DataMember]
        public double Angmax { get; set; } = 360;
    }
}
