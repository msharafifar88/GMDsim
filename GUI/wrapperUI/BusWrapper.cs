using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.wrapperUI
{
    public class BusWrapper
    {
        public long busNumber { get; set; }
        public string busName { get; set; }
        public float numenicVoltage { get; set; }
        public string areaName { get; set; }
        public string zoneName { get; set; }


        public BusWrapper(long busNumber, string busName, float numenicVoltage, string areaName, string zoneName)
        {
            this.busNumber = busNumber;
            this.busName = busName;
            this.numenicVoltage = numenicVoltage;
            this.areaName = areaName;
            this.zoneName = zoneName;
        }
    }
}
