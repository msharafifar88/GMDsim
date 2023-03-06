using System.Collections.Generic;

namespace persistent.enumeration
{
    public static class CoolingClassList
    {
        static List<string> CoolingClass = new List<string> {
             "AA",
             "AA/FA",
             "AFA",
             "FOA",
             "FOW",
             "OA",
             "OA/FA",
             "OA/FA/FA",
             "OA/FA/FOA",
             "OA/FOA/FOA",
             "OW",
             "OW/A",
             "ANV",
             "GA",
             "Other",
             "ONAF",
             "ONAN",
             "ONWN",
             "ONWN/ONAN",
             "ONAN/ONAF",
             "ONAN/ONAF/ONAF",
             "ONAN/ONAF/OFAF",
             "ONAN/OFAF/ONAF",
             "OFAF",
             "OFWF",
             "ODWF",
             "ONAN/OFAN/OFAF",
             "OFAN",
             "OFAN/OFAF",
             "ONWF",
             "AN",
             "AF",
             "ANAN",
             "ANAF",
             "GN",
             "GF",
             "GNAF",
             "GNAN/GNAF",
             "GNAN",
        };

        public static string getCoolingClass(string cc)
        {
            return CoolingClass.Find(x => { return x.Equals(cc); });
        }

        public static List<string> getCoolingClass()
        {
            return CoolingClass;
        }
    }
}
