using bases;

namespace persistent.network.Transformers
{
    public class CurrentVoltageLossUnit : BaseEntity
    {
        public double Current { get; set; }
        public double Voltage { get; set; }
        public double Loss { get; set; }

    }
}
