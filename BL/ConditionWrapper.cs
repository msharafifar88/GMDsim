using System;

namespace BL
{
    public class ConditionWrapper
    {
        public ConditionWrapper(Enum p, Enum s)
        {
            this.Base = p;
            this.Secend = s;
        }
        public Enum Base { get; set; }
        public Enum Secend { get; set; }

        public override bool Equals(object obj)
        {
            var v = obj as ConditionWrapper;
            if (v == null)
            {
                return false;
            }

            return this.Base.Equals(v.Base) && this.Secend.Equals(v.Secend);
        }

        public override int GetHashCode()
        {
            return this.Base.GetHashCode() + this.Secend.GetHashCode();
        }
    }


}
