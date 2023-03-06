using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace bases
{
    [DataContract]
    public abstract class BaseEntity
    {
        [Key]
        [DataMember]
        public long ID { get; set; }
        private DateTime created { get; set; }
        private int createdBy { get; set; }
        private DateTime updated { get; set; }
        private int updatedBy { get; set; }
        //   private bool inservice { get; set; }
    }
}
