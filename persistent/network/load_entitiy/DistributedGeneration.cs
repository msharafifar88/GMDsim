namespace persistent.network.Load
{
    public class DistributedGeneration
    {
        public double P_GEN { get; set; }
        public double Q_GEN { get; set; }
        public double P_GEN_MIN { get; set; }
        public double Q_GEN_MIN { get; set; }
        public bool DGinservice { get; set; } = false;
    }
}
