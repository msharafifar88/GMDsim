using System.ComponentModel;

namespace persistent.enumeration.T_Lines
{
    public enum TowerType
    {
        [Description("1Ha: 3c/1g:138kV")]
        T1Ha,
        [Description("2Ha: 3c/1g:230kV")]
        T2Ha,
        [Description("3H1: 3c/2g:345kV")]
        T3H1,
        [Description("3H2: 3c/2g:345kV")]
        T3H2,
        [Description("3H4s: 3c/2g:345kV")]
        T3H4s,
        [Description("3H4t: 3c/2g:345kV")]
        T3H4t,
        [Description("3L1: 3c/2g:345kV")]
        T3L1,
        [Description("3L12: 6c/2g:345kV")]
        T3L12,
        [Description("3L13: 6c/2g:345kV")]
        T3L13,
        [Description("3L14n: 6c/2g:345kV")]
        T3L14n,
        [Description("3L14w: 6c/2g:345kV")]
        T3L14w,
        [Description("3P1s: 3c/1g:345kV")]
        T3P1s,
        [Description("3P1t: 3c/1g:345kV")]
        T3P1t,
        [Description("3P5: 6c/2g:345kV")]
        T3P5,
        [Description("5P1: 3c/1g:500kV")]
        T5P1,
        [Description("DC1: 2c/1g:735kV")]
        TDC1,
        [Description("DC2: 2c/1g:735kV")]
        TDC2,
        [Description("DistributionWoodPool: 3c/1g:138kV")]
        TDistributionWoodPool
    }



}
