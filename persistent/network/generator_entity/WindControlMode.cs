using bases;
using System.Runtime.Serialization;

namespace persistent.network.Generator
{
    [DataContract]
    public class WindControlMode : BaseEntity
    {
        [DataMember]
        public double PowerFactor { get; set; } = 1.00d;
    }
}
