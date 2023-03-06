using System;

namespace persistent.network
{
    public class RLCAttribute : Attribute
    {
        public RLCAttribute(string name, float value)
        {
            this.Name = name;
            this.Value = value;
        }
        public string Name { get; private set; }
        public float Value { get; private set; }
    }
}
