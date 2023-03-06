using System;

namespace persistent.network.Transformers
{
    public class WindingTypeVectorHVLV
    {
        public Enum HVtypeeWinding { get; set; }
        public Enum LVtypeWinding { get; set; }
        public string degre { get; set; }


        public override string ToString()
        {
            return this.HVtypeeWinding + "" + LVtypeWinding + "" + degre;
        }
    }
}
