using persistent.display;
using persistent.power;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using network;
using areaandzone;

using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using bases;
using persistent.network.Generator;
using persistent.network.generator_entity;

namespace network
{
    [DataContract]
    public class Generator : BaseEntity
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
