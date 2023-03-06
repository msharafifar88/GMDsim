using System.Runtime.Serialization;

namespace persistent.network.generator_entity
{
    [DataContract]
    public class CapabilityCurve : bases.BaseEntity
    {
        [DataMember]
        public string PC1_name { get; set; }
        [DataMember]
        public double PC1VM { get; set; }
        [DataMember]
        public double PC1Mvar { get; set; }
        [DataMember]
        public double PC2 { get; set; }
        [DataMember]
        public double QC1min { get; set; }
        [DataMember]
        public double QC2min { get; set; }
        [DataMember]
        public double QC1max { get; set; }
        [DataMember]
        public double QC2max { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public double MW { get; set; }
        [DataMember]
        public double MVAR { get; set; }
        [DataMember]
        public double MVARmin { get; set; }
        [DataMember]
        public double MVARmax { get; set; }
        [DataMember]

        public bool CCurve { get; set; } = false;


    }
}
