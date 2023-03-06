using System.ComponentModel.DataAnnotations;
namespace persistent.faultParameters
{
    public class Nerual_to_GroundImpedance
    {
        [Key]
        private long ID { get; set; }
        private float R { get; set; }
        private float X { get; set; }
    }
}
