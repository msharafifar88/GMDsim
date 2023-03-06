using bases;
using persistent.enumeration;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace persistent.line
{
    [DataContract]
    public class LineConductor : BaseEntity
    {
        [DataMember]
        public LineConductorTypeEnum LineConductorType { get; set; }
        [DataMember]
        public ConductorTypeEnum ConductorType { get; set; } = ConductorTypeEnum.NotAvaileble;
        [DataMember]
        public CableTypeEnum cableTypeEnum { get; set; } = CableTypeEnum.SingleCore;
        [DataMember]
        public ConductorDataOnce conductorDataOnce { get; set; } = new ConductorDataOnce();
        [DataMember]
        public ICollection<CableData> CableDatas { get; set; }
        public ICollection<TransmissionLineData> transmissionLines { get; set; }
        [DataMember]
        public float CableLength { get; set; } = 0f;
        [DataMember]
        public float EarthResistivity { get; set; } = 0f;
        [DataMember]
        public float EarthRelativePermeability { get; set; } = 0f;
        [DataMember]
        public float ConductorBreackpointFrequncy { get; set; } = 0f;
        [DataMember]
        public float LineLength { get; set; } = 0f;
        [DataMember]
        public float GroundReturnResistivity { get; set; } = 0f;

        [DataMember]
        public GeometricalPipData pipData { get; set; }
        [DataMember]
        public ElectricalData electricalData { get; set; }
        [DataMember]
        public SkinEffect skinEffect { get; set; }

        public LineConductor(LineConductorTypeEnum lineConductorType)
        {
            LineConductorType = lineConductorType;
            if (lineConductorType.Equals(LineConductorTypeEnum.Cable))
            {
                CableDatas = new List<CableData>();
                pipData = new GeometricalPipData();
                electricalData = new ElectricalData();
            }
            else
            {
                transmissionLines = CreateTransmissionLineData(2);
                skinEffect = new SkinEffect();
            }
        }

        public static List<TransmissionLineData> CreateTransmissionLineData(int Sheild)
        {
            List<TransmissionLineData> list = new List<TransmissionLineData>();

            TransmissionLineData transmissionLinePhaseA = new TransmissionLineData(TransmissionLineDataTypeEnum.PhaseA);
            transmissionLinePhaseA.Wire = 1;
            list.Add(transmissionLinePhaseA);
            TransmissionLineData transmissionLinePhaseB = new TransmissionLineData(TransmissionLineDataTypeEnum.PhaseB);
            transmissionLinePhaseB.Wire = 2;
            list.Add(transmissionLinePhaseB);
            TransmissionLineData transmissionLinePhaseC = new TransmissionLineData(TransmissionLineDataTypeEnum.PhaseC);
            transmissionLinePhaseC.Wire = 3;
            list.Add(transmissionLinePhaseC);
            for (int i = 0; i < Sheild; i++)
            {
                TransmissionLineData transmissionLinePhase = new TransmissionLineData(TransmissionLineDataTypeEnum.Sheild);
                transmissionLinePhase.Wire = i + 3;
                list.Add(transmissionLinePhase);
            }


            return list;
        }

    }
}
