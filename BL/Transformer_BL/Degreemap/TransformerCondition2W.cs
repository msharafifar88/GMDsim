using persistent.enumeration.Transformer;
using System.Collections.Generic;

namespace BL
{
    public class TransformerCondition2W
    {
        Dictionary<ConditionWrapper, List<string>> WindingMap = new Dictionary<ConditionWrapper, List<string>>();
        Dictionary<string, int> DegreeMap = new Dictionary<string, int>();
        public TransformerCondition2W()
        {
            InsetDegreeCalculator();
        }
        public void InsetDegreeCalculator()
        {
            DegreeMap.Add("1", -30);
            DegreeMap.Add("2", -60);
            DegreeMap.Add("3", -90);
            DegreeMap.Add("4", -120);
            DegreeMap.Add("5", -150);
            DegreeMap.Add("6", 180);
            DegreeMap.Add("7", 150);
            DegreeMap.Add("8", 120);
            DegreeMap.Add("9", 90);
            DegreeMap.Add("10", 60);
            DegreeMap.Add("11", 30);
            DegreeMap.Add("0", 0);

            /// for HV : YN 
            /// 
            WindingMap.Add(new ConditionWrapper(HVtypeeWindingConfiguration.YN, LVtypeWindingConfiguration.yn), new List<string>() { "0", "6" });
            WindingMap.Add(new ConditionWrapper(HVtypeeWindingConfiguration.YN, LVtypeWindingConfiguration.y), new List<string>() { "0", "6" });
            WindingMap.Add(new ConditionWrapper(HVtypeeWindingConfiguration.YN, LVtypeWindingConfiguration.zn), new List<string>() { "1", "3", "5", "7", "9", "11" });
            WindingMap.Add(new ConditionWrapper(HVtypeeWindingConfiguration.YN, LVtypeWindingConfiguration.z), new List<string>() { "1", "3", "5", "7", "9", "11" });
            WindingMap.Add(new ConditionWrapper(HVtypeeWindingConfiguration.YN, LVtypeWindingConfiguration.d), new List<string>() { "1", "3", "5", "7", "9", "11" });
            WindingMap.Add(new ConditionWrapper(HVtypeeWindingConfiguration.YN, LVtypeWindingConfiguration.od), new List<string>() { "1", "3", "5", "7", "9", "11" });

            /// for HV : Y 
            /// 
            WindingMap.Add(new ConditionWrapper(HVtypeeWindingConfiguration.Y, LVtypeWindingConfiguration.yn), new List<string>() { "0", "6" });
            WindingMap.Add(new ConditionWrapper(HVtypeeWindingConfiguration.Y, LVtypeWindingConfiguration.y), new List<string>() { "0", "6" });
            WindingMap.Add(new ConditionWrapper(HVtypeeWindingConfiguration.Y, LVtypeWindingConfiguration.zn), new List<string>() { "1", "3", "5", "7", "9", "11" });
            WindingMap.Add(new ConditionWrapper(HVtypeeWindingConfiguration.Y, LVtypeWindingConfiguration.z), new List<string>() { "1", "3", "5", "7", "9", "11" });
            WindingMap.Add(new ConditionWrapper(HVtypeeWindingConfiguration.Y, LVtypeWindingConfiguration.d), new List<string>() { "1", "3", "5", "7", "9", "11" });
            WindingMap.Add(new ConditionWrapper(HVtypeeWindingConfiguration.Y, LVtypeWindingConfiguration.od), new List<string>() { "1", "3", "5", "7", "9", "11" });

            /// for HV : ZN
            /// 
            WindingMap.Add(new ConditionWrapper(HVtypeeWindingConfiguration.ZN, LVtypeWindingConfiguration.yn), new List<string>() { "1", "3", "5", "7", "9", "11" });
            WindingMap.Add(new ConditionWrapper(HVtypeeWindingConfiguration.ZN, LVtypeWindingConfiguration.y), new List<string>() { "1", "3", "5", "7", "9", "11" });
            WindingMap.Add(new ConditionWrapper(HVtypeeWindingConfiguration.ZN, LVtypeWindingConfiguration.zn), new List<string>() { "0", "2", "4", "6", "8", "10" });
            WindingMap.Add(new ConditionWrapper(HVtypeeWindingConfiguration.ZN, LVtypeWindingConfiguration.z), new List<string>() { "0", "2", "4", "6", "8", "10" });
            WindingMap.Add(new ConditionWrapper(HVtypeeWindingConfiguration.ZN, LVtypeWindingConfiguration.d), new List<string>() { "0", "2", "4", "6", "8", "10" });
            WindingMap.Add(new ConditionWrapper(HVtypeeWindingConfiguration.ZN, LVtypeWindingConfiguration.od), new List<string>() { "0", "2", "4", "6", "8", "10" });

            /// for HV : Z
            /// 
            WindingMap.Add(new ConditionWrapper(HVtypeeWindingConfiguration.Z, LVtypeWindingConfiguration.yn), new List<string>() { "1", "3", "5", "7", "9", "11" });
            WindingMap.Add(new ConditionWrapper(HVtypeeWindingConfiguration.Z, LVtypeWindingConfiguration.y), new List<string>() { "1", "3", "5", "7", "9", "11" });
            WindingMap.Add(new ConditionWrapper(HVtypeeWindingConfiguration.Z, LVtypeWindingConfiguration.zn), new List<string>() { "0", "2", "4", "6", "8", "10" });
            WindingMap.Add(new ConditionWrapper(HVtypeeWindingConfiguration.Z, LVtypeWindingConfiguration.z), new List<string>() { "0", "2", "4", "6", "8", "10" });
            WindingMap.Add(new ConditionWrapper(HVtypeeWindingConfiguration.Z, LVtypeWindingConfiguration.d), new List<string>() { "0", "2", "4", "6", "8", "10" });
            WindingMap.Add(new ConditionWrapper(HVtypeeWindingConfiguration.Z, LVtypeWindingConfiguration.od), new List<string>() { "0", "2", "4", "6", "8", "10" });

            /// for HV : D
            /// 
            WindingMap.Add(new ConditionWrapper(HVtypeeWindingConfiguration.D, LVtypeWindingConfiguration.yn), new List<string>() { "1", "3", "5", "7", "9", "11" });
            WindingMap.Add(new ConditionWrapper(HVtypeeWindingConfiguration.D, LVtypeWindingConfiguration.y), new List<string>() { "1", "3", "5", "7", "9", "11" });
            WindingMap.Add(new ConditionWrapper(HVtypeeWindingConfiguration.D, LVtypeWindingConfiguration.zn), new List<string>() { "0", "2", "4", "6", "8", "10" });
            WindingMap.Add(new ConditionWrapper(HVtypeeWindingConfiguration.D, LVtypeWindingConfiguration.z), new List<string>() { "0", "2", "4", "6", "8", "10" });
            WindingMap.Add(new ConditionWrapper(HVtypeeWindingConfiguration.D, LVtypeWindingConfiguration.d), new List<string>() { "0", "2", "4", "6", "8", "10" });
            WindingMap.Add(new ConditionWrapper(HVtypeeWindingConfiguration.D, LVtypeWindingConfiguration.od), new List<string>() { "0", "2", "4", "6", "8", "10" });
        }

        public List<string> FetchDegree(ConditionWrapper e)
        {
            return new List<string>(WindingMap[e]);
        }

        public int FetchDegreeValue(string val)
        {
            return DegreeMap[val];
        }
    }
}
