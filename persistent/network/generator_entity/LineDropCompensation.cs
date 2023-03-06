using bases;
using persistent.Generator;
using System.Runtime.Serialization;

namespace persistent.network.Generator
{
    [DataContract]
    public class LineDropCompensation : BaseEntity
    {
        public LineDropCompensationEnum lineDropCompensationEnum { get; set; }
        public double Xcomp { get; set; }
        public double Rcomp { get; set; }
    }
}
