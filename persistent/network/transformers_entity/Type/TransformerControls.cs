using bases;

namespace network
{
    public class TransformerControls : BaseEntity
    {
        public long ID { get; set; }
        public Bus fromBus { get; set; }
        public Bus toBus { get; set; }



    }
}
