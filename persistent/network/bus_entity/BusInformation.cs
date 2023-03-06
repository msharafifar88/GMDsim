using bases;
using System.ComponentModel.DataAnnotations;

namespace network
{
    public class BusInformation : BaseEntity
    {
        [Key]
        private long ID { get; set; }

    }

}