namespace persistent.network.Transformers
{
    public class Reliability
    {

        public double lambdaA { get; set; } = 0.015d;
        public double lambdaP { get; set; } = 0.0d;
        public double Mu { get; set; } = 43.8d;
        public double FOR { get; set; } = 3.42354d;
        public double MR { get; set; } = 80.0d;
        public double MTTF { get; set; } = 66.7d;
        public double MTTR { get; set; } = 200.0d;
        public double SWtime { get; set; } = 10.0d;
        public double rP { get; set; } = 200.0d;
    }
}
