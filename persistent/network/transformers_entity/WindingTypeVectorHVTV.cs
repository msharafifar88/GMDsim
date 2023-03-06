using System;

namespace persistent.network.Transformers
{
    public class WindingTypeVectorHVTV
    {
        public Enum HVtypeeWinding { get; set; }
        public Enum TVtypeWinding { get; set; }
        public string degre { get; set; }


        public override string ToString()
        {
            return this.HVtypeeWinding + "" + TVtypeWinding + "" + degre;
        }
    }
}
