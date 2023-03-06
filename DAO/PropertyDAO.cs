using bases;
using System.Collections.Generic;

namespace DAO
{
    public class PropertyDAO
    {


        public List<Property> findGeneratorPropery()
        {
            List<string> names = new List<string> { "Number of bus", "Name of bus", "ID", "Status", " Gen MW", "Gen Mvar", "Min MW", "Max MW", "AGC", "AVR", "RegBus Num", "Set Volt", "Min Mvar", "Max Mvar", "Enforce MW Limits", "Part. Factor", "Cost Model" };
            List<PropertyType> types = new List<PropertyType>
            {
                PropertyType.Long, PropertyType.String, PropertyType.Long,PropertyType.String ,PropertyType.Long,
                PropertyType.Long, PropertyType.Long, PropertyType.Long, PropertyType.Long, PropertyType.Long,
                PropertyType.Long, PropertyType.Long, PropertyType.Long, PropertyType.Long, PropertyType.Long,
                PropertyType.Long, PropertyType.Long };
            List<Property> properties = new List<Property>();
            for (int i = 0; i < names.Count; i++)
            {
                Property p = new Property();
                p.id = i;
                p.name = names[i];
                p.type = types[i];
                properties.Add(p);
            }
            return properties;
        }

        public List<Property> findBusPropery()
        {
            List<string> names = new List<string> { "Number", "Name", "Area Name", " Nom Kv", " Pu Volt", "Volt(kV)", "Angle(Deg)", "Load MW", "Load Mvar", "Gen MW", " Gen Mvar", "Switched Shunts Mvar", "Act G Shunt MW ", "Act B Shunt Mvar", "Area Num", "Zone Num" };
            List<PropertyType> types = new List<PropertyType>
            {
                PropertyType.Long, PropertyType.String, PropertyType.Long, PropertyType.Long, PropertyType.Long,
                PropertyType.Long, PropertyType.Long, PropertyType.Long , PropertyType.Long , PropertyType.Long,
                PropertyType.Long, PropertyType.Long, PropertyType.Long , PropertyType.Long , PropertyType.Long,
                PropertyType.Long };
            List<Property> properties = new List<Property>();
            for (int i = 0; i < names.Count; i++)
            {
                Property p = new Property();
                p.id = i;
                p.name = names[i];
                p.type = types[i];
                properties.Add(p);
            }
            return properties;
        }

        public List<Property> findLoadPropery()
        {
            List<string> names = new List<string> { "Number of bus", "Name of bus", "Area Name of Load", "Zone Name of Load", "ID", "Status", "MW", "Mvar", "MVA", "S MW", "S Mvar", "Dist Status", "Dist MW Input", "Dist Mvar Input" };
            List<PropertyType> types = new List<PropertyType>
            {
                PropertyType.Long, PropertyType.String, PropertyType.String, PropertyType.String, PropertyType.Long,
                PropertyType.String, PropertyType.Long, PropertyType.Long, PropertyType.Long, PropertyType.Long,
                PropertyType.Long, PropertyType.String, PropertyType.Long, PropertyType.Long
            };
            List<Property> properties = new List<Property>();
            for (int i = 0; i < names.Count; i++)
            {
                Property p = new Property();
                p.id = i;
                p.name = names[i];
                p.type = types[i];
                properties.Add(p);
            }
            return properties;
        }
        public List<Property> findTransFormer_ControlPropery()
        {
            List<string> names = new List<string> { "From Number", "From Name", "To Number", "To Name", " Circuit", "Type", "Status", "Tap Ratio", "Phase(Deg)", "XF Auto", "Reg Bus Num", "Reg value", "Reg Error", "Reg Min", "Reg Max", "Tap Min", "Tap Max", "Step Size", "Reg Bus Name" };
            List<PropertyType> types = new List<PropertyType>
            {
                PropertyType.Long, PropertyType.String, PropertyType.Long, PropertyType.String, PropertyType.Long,
                PropertyType.Long, PropertyType.String, PropertyType.Long, PropertyType.Long, PropertyType.Long,
                PropertyType.Long,PropertyType.Long, PropertyType.Long, PropertyType.Long, PropertyType.Long,
                PropertyType.Long,  PropertyType.Long,  PropertyType.Long,  PropertyType.Long};
            List<Property> properties = new List<Property>();
            for (int i = 0; i < names.Count; i++)
            {
                Property p = new Property();
                p.id = i;
                p.name = names[i];
                p.type = types[i];
                properties.Add(p);
            }
            return properties;
        }

    }
}
