using System.Collections.Generic;

namespace persistent.enumeration
{
    public static class BILValuesList
    {
        static List<string> BILValues = new List<string>
        {
            "10",
            "20",
            "30",
            "45",
            "60",
            "95",
            "110",
            "125",
            "150",
            "200",
            "250",
            "350",
            "550",
            "650",
            "750",
            "900",
            "1050",
            "1300",
            "1550",
            "1800",
            "2050",
            "0"
        };

        public static List<string> getBILValues()
        {

            return BILValues;
        }
    }
}
