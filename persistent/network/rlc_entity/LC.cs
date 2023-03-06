namespace network
{
    public class LC : RLCbranches
    {
        public float capacitance { get; set; } = 1;
        public int capacitanceUnit { get; set; } = 3;
        public float inductance { get; set; } = 1;
        public int inductanceUnit { get; set; } = 2;
        public float initialCurrent { get; set; } = 0;
        public int currentUnit { get; set; } = 1;
        public float initialVoltage { get; set; } = 0;
        public int voltageUnit { get; set; } = 1;
    }
}
