using System.ComponentModel;

namespace persistent.enumeration.T_Lines
{
    public enum DefaultOhmMValuesMetric
    {
        [Description("Swamp (30.0)")]
        Swamp,
        [Description("Loam or Clay (100.0) ")]
        LoamOrClay,
        [Description("Sandy Clay (150.0)")]
        SandyClay,
        [Description("Moist Sandy (300.0)")]
        MoistSandy,
        [Description("Concrete (400.0)")]
        Concrete,
        [Description("Moist Gravel (500.0)")]
        MoistGravel,
        [Description("Dry Sandy (1000.0)")]
        DrySandy,
        [Description("Dry Gravel (1000.0)")]
        DryGravel,
        [Description("Stoney (30000.0)")]
        Stoney,
        [Description("Rock (1.0E7)")]
        Rock,
        [Description("Sea Water (0.2)")]
        SeaWater
    }

    public enum DefaultOhmMValuesImperial
    {
        [Description("Swamp (98.4251968504)")]
        Swamp,
        [Description("Loam or Clay (328.0839895013) ")]
        LoamOrClay,
        [Description("Sandy Clay (492.125984252)")]
        SandyClay,
        [Description("Moist Sandy (984.2519685039)")]
        MoistSandy,
        [Description("Concrete (1312.3359580052)")]
        Concrete,
        [Description("Moist Gravel (1640.4199475066)")]
        MoistGravel,
        [Description("Dry Sandy (3280.8398950131)")]
        DrySandy,
        [Description("Dry Gravel (3280.8398950131)")]
        DryGravel,
        [Description("Stoney (98425.1968503937)")]
        Stoney,
        [Description("Rock (3.280839895013123E8)")]
        Rock,
        [Description("Sea Water (0.656167979)")]
        SeaWater
    }
}

