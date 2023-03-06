using persistent.enumeration;

namespace persistent.line
{
    public class StabilityLine
    {
        public long ID { get; set; }
        public LineModelType LineModel { get; set; }
        public bool status { get; set; }

        public override string ToString()
        {
            return LineModel + "-" + status;
        }
    }
}
