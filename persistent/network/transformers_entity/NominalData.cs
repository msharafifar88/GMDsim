using bases;
using persistent.enumeration;

namespace persistent.network.Transformers
{
    public class NominalData : BaseEntity
    {
        public double PrimaryNominalRating { get; set; } = 750.0d;
        public double PrimaryRatedVoltage { get; set; } = 750.0d;
        public double SecondaryNominalRating { get; set; } = 250.0d;
        public double SecondaryRatedVoltage { get; set; } = 500.0d;
        public double TertiaryNominalRating { get; set; } = 230.0d;
        public double TertiaryRatedVoltage { get; set; } = 27.6d;
        public NominalRatingUnit NominalRatingUnit { get; set; } = NominalRatingUnit.MVA;
        public RatedVoltageUnit RatedVoltageUnit { get; set; } = RatedVoltageUnit.kVLL;
    }
}
