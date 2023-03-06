using bases;

namespace persistent.network.Load
{
    public class LoadInformation : BaseEntity
    {
        public double P_Power { get; set; }
        public double P_Current { get; set; }
        public double P_Impedance { get; set; }
        public double Q_Power { get; set; }
        public double Q_Current { get; set; }
        public double Q_Impedance { get; set; }

    }
}
