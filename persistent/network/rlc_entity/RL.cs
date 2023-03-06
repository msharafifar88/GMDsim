namespace network
{
    public class RL : RLCbranches
    {
        public float resistance { get; set; } = 1;
        public int resistanceUnit { get; set; } = 1;
        public float inductance { get; set; } = 1;
        public int inductanceUnit { get; set; } = 2;
        public float initialCurrent { get; set; } = 0;
        public int currentUnit { get; set; } = 1;
        public float initialVoltage { get; set; } = 0;
        public int voltageUnit { get; set; } = 1;
    }
}
