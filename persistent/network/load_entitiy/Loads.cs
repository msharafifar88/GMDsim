
using bases;
using display;
using persistent.network;
using persistent.network.Load;

namespace network
{
    public class Loads : BaseEntity
    {

        public string Name { get; set; } = "load";
        public long Code { get; set; } = 1l;
        public Bus Bus { get; set; }
        //  public Area area { get; set; }
        public Display display { get; set; }
        public Substations substation { get; set; } = new Substations();



        public bool Inservice { get; set; } = false;
        public bool Scalable { get; set; } = false;
        public bool Interruptible { get; set; } = false;
        public int Identity { get; set; }
        public LoadInformation loadinformation { get; set; } = new LoadInformation();
        public DistributedGeneration distributedGeneration { get; set; } = new DistributedGeneration();
        public string getName()

        {
            return this.Name;
        }
        public long getCode()
        {
            return this.Code;
        }
    }
}

