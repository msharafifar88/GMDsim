using areaandzone;
using bases;
using display;
using persistent.common;
using persistent.network;
using persistent.network.bus_entity;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace network
{
    [DataContract]
    public class Bus : BaseEntity, DeviceInterface
    {


        [DataMember]
        public long BusNumber
        {
            get;
            set;
        } = 1l;
        [DataMember]
        public string BusName
        {
            get;
            set;
        } = " Bus";
        [DataMember]
        public float nominalVoltage { get; set; } = 138.00f;
        [DataMember]
        public int Identity { get; set; } = 1;
        [DataMember]
        public Area area { get; set; }
        [DataMember]
        public byte[] lable { get; set; }
        [DataMember]
        public Zone zone { get; set; }
        [DataMember]
        public Bus_type Bus_Type { get; set; }
        [DataMember]
        public List<Owner> owners { get; set; } = new List<Owner>();
        [DataMember]
        public Display display { get; set; }
        [DataMember]
        public float voltage { get; set; } = 1.0000f;
        [DataMember]
        public float angle { get; set; } = 0.0000f;
        [DataMember]
        public bool enable3phase { get; set; } = false;
        [DataMember]
        public float Va_mag { get; set; } = 1.0000f;
        [DataMember]
        public float Va_angle { get; set; } = 0.0000f;
        [DataMember]
        public float Vb_mag { get; set; } = 1.0000f;
        [DataMember]
        public float Vb_angle { get; set; } = -120.0000f;
        [DataMember]
        public float Vc_mag { get; set; } = 1.0000f;
        [DataMember]
        public float Vc_angle { get; set; } = 120.0000f;
        [DataMember]
        public Boolean slack { get; set; } = false;
        [DataMember]
        public Boolean Status { get; set; } = true;
        [DataMember]
        public float EmerVmin { get; set; } = 0.9f;
        [DataMember]
        public float EmerVmax { get; set; } = 1.1f;
        [DataMember]
        public float NominalVmin { get; set; } = 0.9f;
        [DataMember]
        public float NominalVmax { get; set; } = 1.1f;
        [DataMember]
        public float Voltagemagnitude { get; set; } = 1.1f;
        [DataMember]
        public float ShuntB { get; set; } = 0.0000f;
        [DataMember]
        public float ShuntG { get; set; } = 0.0000f;
        [DataMember]
        public float ShuntB_pu { get; set; } = 0.0000f;
        [DataMember]
        public float ShuntG_pu { get; set; } = 0.0000f;
        [DataMember]
        public float QD_pu { get; set; } = 0.0000f;
        [DataMember]
        public float PD_pu { get; set; } = 0.0000f;
        [DataMember]
        public float QD { get; set; } = 0.0000f;
        [DataMember]
        public float PD { get; set; } = 0.0000f;
        [DataMember]
        public long areaLong { get; set; }
        [DataMember]
        public long ZoneLong { get; set; }
        [DataMember]
        public Substations substation { get; set; } = new Substations();
        [DataMember]
        public List<long> ownersLong { get; set; }




        public string getName()
        {
            return this.BusName;
        }
        public long getCode()
        {
            return this.BusNumber;
        }
    }
}

