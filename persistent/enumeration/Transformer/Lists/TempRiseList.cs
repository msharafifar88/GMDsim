using System.Collections.Generic;

namespace persistent.enumeration
{
    public static class TempRiseList
    {
        static List<string> TempRise = new List<string>
        {
            "55",
            "60",
            "65",
            "80",
            "115",
            "130",
            "150"
        };


        public static List<string> getTempRise()
        {
            return TempRise;
        }
    }
}
