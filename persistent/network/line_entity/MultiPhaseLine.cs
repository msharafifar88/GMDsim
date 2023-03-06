using propagationModel;
using System.Collections.Generic;

namespace network
{
    public class MultiPhaseLine : LineBranches
    {

        private static List<double> rPrimeList = new List<double>() { 0.3, 0.02 };
        private static List<double> lPrimeList = new List<double>() { 3, 0.9 };
        private static List<double> cPrimeList = new List<double>() { 0.008, 0.0126 };
        private static List<PropagationData> temp = new List<PropagationData>()
            {
               new PropagationData(rPrimeList[0], lPrimeList[0], cPrimeList[0]),
               new PropagationData(rPrimeList[1], lPrimeList[1], cPrimeList[1])
            };

        public int NumOfPhase { get; set; } = 3;
        public double Length { get; set; } = 400;
        public bool ContinuouslyTransposed { get; set; } = true;
        public List<PropagationData> propagationSet { get; set; } = temp;
        public List<MatrixCoeficients> Coeficients { get; set; }

        public double VoltageA { get; set; } = 0;
        public double VoltageB { get; set; } = 0;
        public double VoltageC { get; set; } = 0;
        public double Angmin { get; set; } = -360;
        public double Angmax { get; set; } = 360;
    }
}
