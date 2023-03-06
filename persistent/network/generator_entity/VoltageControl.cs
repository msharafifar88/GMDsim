using bases;
using System;
using System.Runtime.Serialization;

namespace persistent.power
{
    [DataContract]
    public class VoltageControl : BaseEntity
    {
        [DataMember]
        public float MvarOutput { get; set; } = 0.0000f;
        [DataMember]
        public float MinMvars { get; set; } = -9900.0000f;
        [DataMember]
        public float MaxMvars { get; set; } = 9900.0000f;
        [DataMember]
        public Boolean Available { get; set; } = false;
        [DataMember]
        public long Regulated { get; set; } = 0l;
        [DataMember]
        public float SetPointVoltage { get; set; } = 0.0000f;
        [DataMember]
        public float SetPointVoltageTOL { get; set; } = 0.0000f;
        [DataMember]
        public float RegFactor { get; set; } = 0.0000f;
    }
}
