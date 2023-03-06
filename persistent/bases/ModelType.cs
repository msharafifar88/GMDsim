using System;

namespace bases
{
    public class ModelType
    {
        public long id { get; set; }
        public String name { get; set; }
        public long code { get; set; }
        /*  public String key { get; set; }*/
        public ModelType parent { get; set; }
        public Boolean leaf { get; set; }


    }
}
