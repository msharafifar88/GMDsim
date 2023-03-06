using bases;

namespace persistent.line
{
    public class ConductorData : BaseEntity
    {
        public CableData cable { get; set; }
        public long ConductorNumber { get; set; } = 0l;
        public long InsideRadiudRIn { get; set; } = 0l;
        public long OutsideRadiudRIn { get; set; } = 0l;
        public long ResistivityRho { get; set; } = 0l;
        public long RelativePremeability { get; set; } = 0l;
        public long InsulatorRelativePermeability { get; set; } = 0l;
        public long InsulatorRelativePermittivity { get; set; } = 0l;
        public long InsulatorLossFactor { get; set; } = 0l;
        public long PhaseNumber { get; set; } = 0l;

        public long CableNumber { get; set; }

    }
}
