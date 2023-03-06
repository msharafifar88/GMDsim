namespace persistent.network.Transformers
{
    public class TemperaturesLimits
    {
        public double LongTermWinding { get; set; } = 140d;
        public double ShortTermWinding { get; set; } = 180d;
        public double LongTermParts { get; set; } = 160d;
        public double ShortTermParts { get; set; } = 200d;
    }
}
