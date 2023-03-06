using System.ComponentModel;

namespace persistent.enumeration.T_Lines
{
    public enum LineModelType
    {
        [Description("Bergeron (Physical Data Entry)")]
        BergeronPhysycal,
        [Description("Bergeron (RLC Data Entry)")]
        BergeronRLC,
        [Description("Frequency Dependent (phase)")]
        Frequency,

    }
}
