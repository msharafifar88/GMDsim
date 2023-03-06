using bases;
using network;

namespace persistent.network.Transformers
{
    public class LoadTapChanger : BaseEntity
    {
        public Bus bus { get; set; }

        /// <summary>
        /// Reactive Power Control 
        /// </summary>
        public double Reactive_Power_Control_SetPoint { get; set; }
        public double Reactive_Power_Control_Max { get; set; }
        public double Reactive_Power_Control_Min { get; set; }

        /// <summary>
        /// Tap
        /// </summary>
        public double Tap_Min { get; set; }
        public double Tap_Max { get; set; }
        public double Tap_Step { get; set; }
        public int Of_Taps { get; set; }
        /// <summary>
        /// Time Delay
        /// </summary>
        public double Time_Delay_Initial { get; set; }
        public double Time_Delay_Operation { get; set; }
        /// <summary>
        /// Drop Compensation
        /// </summary>
        /// 
        public double Resistance { get; set; }
        public double Reactance { get; set; }
    }
}
