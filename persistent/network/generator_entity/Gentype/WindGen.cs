using bases;
using persistent.display;
using persistent.network.Generator;
using persistent.network.generator_entity;
using persistent.power;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace network.generator.Gentype
{
    [DataContract]
    public class WindGen : BaseEntity
    {
        [DataMember]

        public long Code { get; set; }
        [DataMember]
        public long Identity { get; set; }
        [DataMember]
        public bool Inservice { get; set; } = true;
        [DataMember]
        public double Generator_MVA_BASE { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public Bus Bus { get; set; }
        /*    public List<Owner> owners { get; set; }
            public Zone zone { get; set; }
            public Area area { get; set; }*/
        [DataMember]
        public DisplayGenerator displayGenerator { get; set; }
        [DataMember]
        public PowerControl powerControl { get; set; }
        [DataMember]
        public VoltageControl voltageControl { get; set; }
        [DataMember]
        public LineDropCompensation lineDropCompensation { get; set; }
        [DataMember]
        public FaultParameters faultParameters { get; set; } = new FaultParameters();
        [DataMember]
        public WindControlMode windControlMode { get; set; } = new WindControlMode();
        [DataMember]
        public List<CapabilityCurve> capabilityCurves { get; set; } = new List<CapabilityCurve>();

    }
}
