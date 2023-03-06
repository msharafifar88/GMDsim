using System.ComponentModel.DataAnnotations;

namespace persistent.faultParameters
{
    public class InternalSequence
    {

        [Key]
        private long ID { get; set; }
        private float PositiveX { get; set; }
        private float NegativeX { get; set; }
        private float ZeroX { get; set; }
        private float PositiveR { get; set; }
        private float NegativeR { get; set; }
        private float ZeroR { get; set; }
    }
}
