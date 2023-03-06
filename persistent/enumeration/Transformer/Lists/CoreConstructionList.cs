using System.Collections.Generic;

namespace persistent.enumeration
{
    public static class CoreConstructionList
    {
        static List<string> Cores = new List<string> {
            "3 Legged Core-Type",
            "3 Single Phase",
            "5 Legged Core-Type",
            "Shell Type",
            "7 Legged Shell Type",
            "5 Legged Wound-Core",
            "4 Legged Core-Type"

        };

        public static List<string> getCores()
        {
            return Cores;
        }
    }
}
