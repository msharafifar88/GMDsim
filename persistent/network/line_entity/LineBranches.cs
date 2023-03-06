using areaandzone;
using bases;
using persistent.enumeration;
using persistent.line;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace network
{
    [DataContract]
    public class LineBranches : BaseEntity
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public long Number { get; set; } = 1L;
        [DataMember]
        public string Branch { get; set; }
        [DataMember]
        public long Type { get; set; }
        [DataMember]
        public int ResistancePrimeUnit { get; set; } = 0;
        [DataMember]
        public int ImpedancePrimeUnit { get; set; } = 1;
        [DataMember]
        public int CapacitancePrimeUnit { get; set; } = 1;
        [DataMember]
        public int TimeUnit { get; set; } = 2;
        [DataMember]
        public int DataType { get; set; } = 0;
        [DataMember]
        public bool DistortionlessModel { get; set; } = false;
        [DataMember]
        public int lineInitialVoltageUnit { get; set; } = 0;
        [DataMember]
        public int TypeofLoadLimit { get; set; } = 0;
        [DataMember]
        public string Identity { get; set; }
        [DataMember]

        public Bus FromBus { get; set; }
        [DataMember]
        public Bus ToBus { get; set; }
        [DataMember]
        public Boolean Status { get; set; }
        [DataMember]
        public float Resistance { get; set; }
        [DataMember]
        public float Reactance { get; set; }
        [DataMember]
        public float Charging { get; set; }
        [DataMember]
        public float Conductance { get; set; }
        [DataMember]

        public float RzeroSequence { get; set; }
        [DataMember]
        public float XzeroSequence { get; set; }
        [DataMember]
        public float BzeroSequence { get; set; }
        [DataMember]
        public float GzeroSequence { get; set; }
        [DataMember]
        public bool Inservice { get; set; } = true;
        [DataMember]

        public LengthType lengthType { get; set; } = LengthType.km;
        [DataMember]
        public float LineLengthvalue { get; set; } = 0.00f;
        [DataMember]
        public TypeLimit typeLimit { get; set; } = TypeLimit.Fixed;
        [DataMember]

        public EMTModelTypeEnum eMTModelTypeEnum { get; set; } = EMTModelTypeEnum.FD;
        [DataMember]
        // line conducor transmissionline default 

        public LineConductor LineConductor { get; set; } = new LineConductor(LineConductorTypeEnum.TransmissionLine);
        [DataMember]
        /*Stability Tab*/
        public List<StabilityLine> StabilityLines { get; set; } = new List<StabilityLine>();

        /// < summary Line limt Tab>
        [DataMember]
        public double[] LimitList { get; set; } = new double[16];

        public void SetLimitList(int i, double d)
        {
            LimitList[i] = d;
        }

        public double GetLimitList(int i)
        {
            return LimitList[i];
        }

        [DataMember]
        /// </summary>
        public Owner[] Owners { get; set; } = new Owner[10];

        public Owner GetOwner(int i)
        {
            return Owners[i];
        }



    }
}
