using System.Collections.Generic;

namespace persistent.enumeration
{
    public static class InsulationList
    {
        static List<string> Insulations = new List<string> {
            "Cast Coil",
            "Gas Fill Dry",
            "Liquid-Fill",
            "Nonvent-Dry",
            "Sealed-Dry",
            "Vent-Dry"
        };

        public static List<string> getInsulations()
        {
            return Insulations;
        }
    }
}
