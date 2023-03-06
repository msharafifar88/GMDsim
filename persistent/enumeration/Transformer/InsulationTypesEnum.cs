using System.ComponentModel.DataAnnotations;

namespace persistent.enumeration
{
    public enum InsulationTypesEnum
    {
        [Display(Name = "Cast Coil")]
        CastCoil,
        [Display(Name = "Gas Fill Dry")]
        GasFillDry,
        [Display(Name = "Liquid-Fill")]
        LiquidFill,
        [Display(Name = "Nonvent-Dry")]
        NonVentDry,
        [Display(Name = "Sealed-Dry")]
        SealedDry,
        [Display(Name = "Vent-Dry")]
        VentDry
    }
}
