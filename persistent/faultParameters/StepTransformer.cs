using System.ComponentModel.DataAnnotations;

namespace persistent.faultParameters
{
    public class StepTransformer
    {
        [Key]
        public long ID { get; set; }
        public float R { get; set; }
        public float X { get; set; }
        public float Tap { get; set; }
    }
}
