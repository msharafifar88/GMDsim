namespace network
{
    public class L : RLCbranches
    {
        public float inductance { get; set; } = 1;
        public int inductanceUnit { get; set; } = 2;
        public float initialCurrent { get; set; } = 0;
        public int currentUnit { get; set; } = 1;
    }
}
