using bases;
using System.Collections.Generic;

namespace persistent.line
{
    public class CableData : BaseEntity
    {


        public long CableNumber { get; set; }

        public long NumberofConductor { get; set; } = 2l;
        public long VerticalDistance { get; set; } = 0l;
        public long HorizontalDistance { get; set; } = 0l;
        public long OuterInsulationRadius { get; set; } = 0l;
        public ICollection<ConductorData> conductorDatas { get; set; } = new List<ConductorData>();

    }
}
