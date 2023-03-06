using bases;
using persistent.enumeration;

namespace persistent.line
{
    public class TransmissionLineData : BaseEntity
    {
        public int Cirrcuit { get; set; }
        public TransmissionLineDataTypeEnum TypeEnum { get; set; }


        public int Wire { get; set; } = 0;
        public float DCresistance { get; set; } = 0f;
        public float Outside { get; set; } = 0f;
        public float Horizontaldistance { get; set; } = 0f;
        public float VerticalHeigthAtTower { get; set; } = 0f;
        public float VerticalHeigthAtMidspan { get; set; } = 0f;

        public TransmissionLineData(TransmissionLineDataTypeEnum typeEnum)
        {
            TypeEnum = typeEnum;
            if (typeEnum.Equals(TransmissionLineDataTypeEnum.PhaseA))
            {

            }

            else if (typeEnum.Equals(TransmissionLineDataTypeEnum.PhaseB))
            {

            }
            else if (typeEnum.Equals(TransmissionLineDataTypeEnum.PhaseC))
            {

            }
            else if (typeEnum.Equals(TransmissionLineDataTypeEnum.Sheild))
            {

            }
        }
    }
}
