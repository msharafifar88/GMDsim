using bases;
using System;
using System.Runtime.Serialization;

namespace persistent.power
{
    [DataContract]
    public class PowerControl : BaseEntity
    {
        [DataMember]
        public float setpoint { get; set; } = 240.00f;
        [DataMember]

        public float setpoint_pu { get; set; } = 240.00f;
        [DataMember]
        public float minOut { get; set; } = 0.000f;
        [DataMember]
        public float maxOut { get; set; } = 1000.000f;
        [DataMember]
        public float outPut { get; set; } = 0.000f;
        [DataMember]
        public bool availableAVR { get; set; } = false;
        [DataMember]
        public Boolean enforce { get; set; } = true;
        [DataMember]
        public float factor { get; set; } = 10.00f;
    }
}
