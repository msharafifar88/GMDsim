using System.ComponentModel.DataAnnotations;

namespace persistent.enumeration.Transformer
{
    public enum CoreConstruction2W
    {
        [Display(Name = "3 Legged Core-Type")]
        ThreeLeggedCoreType,
        [Display(Name = "3 Single Phase")]
        ThreeSinglePhase,
        [Display(Name = "5 Legged Core-Type")]
        FiveLeggedCoreType,
        [Display(Name = "Shell Type")]
        ShellType,
        [Display(Name = "7 Legged Shell Type")]
        SevenShellType,
        [Display(Name = "5 Legged Wound-Core")]
        FiveLeggedWoundCore,
        [Display(Name = "4 Legged Core-Type")]
        FourLeggedCoreType

    }
}
