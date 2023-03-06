using bases;
using persistent.enumeration;

namespace persistent.line
{
    public class LineEMTModel : BaseEntity
    {
        public EMTModelTypeEnum eMTPModelType { get; set; }
        public ScaleType eScaleType { get; set; }
        public int ModelFrequency { get; set; } = 60;

        // Logarithmic
        public int NumofDecades { get; set; } = 8;

        public float Points_decade { get; set; } = 10f;
        //


        // Linear
        public float Fmax { get; set; } = 5000.0f;
        public float DeltaF { get; set; } = 100.0f;
        public float Fmin { get; set; } = 0.1f;
        //
        // plot when FD active

        public bool EMTPlot { get; set; } = false;
        public bool QuikFit { get; set; } = false;

        public bool FindModelFrequencyAuto { get; set; } = true;
        public float MaxNumPoles { get; set; }

        public int MaxNumOfPolsevalue { get; set; } = 25;

    }
}
