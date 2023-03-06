using bases;
namespace persistent.line
{
    public class ConductorDataOnce : BaseEntity
    {
        public int NumberOfPhase { get; set; }
        public double Rzerosequence { get; set; }
        public double Lzerosequence { get; set; }
        public double Gzerosequence { get; set; }
        public double Czerosequence { get; set; }
        public double Rpositionsequence { get; set; }
        public double Lpositionsequence { get; set; }
        public double Gpositionsequence { get; set; }
        public double Cpositionsequence { get; set; }
        public double Frequency { get; set; }
        public double DCresistance { get; set; }

    }
}
