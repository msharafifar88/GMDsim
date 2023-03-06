namespace BL.Calculation_Core
{
    public class PointerInt
    {
        public int i { set; get; }
        public int j { set; get; }
        public string s { set; get; }

        public PointerInt(int i, int j)
        {
            this.i = i;
            this.j = j;
        }

        public PointerInt(int i, int j, string s)
        {
            this.i = i;
            this.j = j;
            this.s = s;
        }
    }
}