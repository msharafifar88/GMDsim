using System.ComponentModel;

namespace persistent.enumeration.T_Lines
{
    public enum RatedVoltage
    {
        [Description("Any")]
        Any,
        [Description("138.0")]
        V138,
        [Description("230.0")]
        V230,
        [Description("345.0")]
        V345,
        [Description("500.0")]
        V500,
        [Description("735.0")]
        V735
    }
}
