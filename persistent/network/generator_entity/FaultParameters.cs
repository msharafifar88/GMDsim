using bases;
using System.Runtime.Serialization;

namespace persistent.network.Generator
{
    [DataContract]
    public class FaultParameters : BaseEntity
    {
        [DataMember]
        public double Generatoe_Step_Transformer_R { get; set; }
        [DataMember]
        public double Generatoe_Step_Transformer_X { get; set; }
        [DataMember]
        public double Generatoe_Step_Transformer_Tap { get; set; }
        [DataMember]
        public double Neutral_Ground_Impedance_R { get; set; }
        [DataMember]
        public double Neutral_Ground_Impedance_X { get; set; }
        [DataMember]
        public double ISI_Positive_R { get; set; }
        [DataMember]
        public double ISI_Positive_X { get; set; }
        [DataMember]
        public double ISI_Negative_R { get; set; }
        [DataMember]
        public double ISI_Negative_X { get; set; }
        [DataMember]
        public double ISI_Zero_R { get; set; }
        [DataMember]
        public double ISI_Zero_X { get; set; }
    }
}
