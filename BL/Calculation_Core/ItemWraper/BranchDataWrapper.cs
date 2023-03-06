namespace BL.Calculation_Core.ItemWraper
{
    public class BranchDataWrapper
    {
        public long ID { get; set; }
        public long number { get; set; }
        public long F_Bus { get; set; }

        public long T_Bus { get; set; }
        public double BR_R { get; set; }
        public double BR_X { get; set; }

        public double BR_B { get; set; }
        public double RATE_A { get; set; }

        public double RATE_B { get; set; }

        public double RATE_C { get; set; }
        public double degrees { get; set; }
        public float TAP { get; set; }
        public bool INSERVIcE { get; set; }

        public double ANGMIN { get; set; } = 360.0;
        public double ANGMAX { get; set; } = -360.0;
        /*
        PF          = 13   # real power injected at "from" bus end (MW)
        QF          = 14   # reactive power injected at "from" bus end (MVAr)
        PT          = 15   # real power injected at "to" bus end (MW)
        QT          = 16   # reactive power injected at "to" bus end (MVAr)

        # included in opf solution, not necessarily in input
        # assume objective function has units, u
        MU_SF       = 17   # Kuhn-Tucker multiplier on MVA limit at "from" bus (u/MVA)
        MU_ST       = 18   # Kuhn-Tucker multiplier on MVA limit at "to" bus (u/MVA)
        MU_ANGMIN   = 19   # Kuhn-Tucker multiplier lower angle difference limit
        MU_ANGMAX   = 20   # Kuhn-Tucker multiplier upper angle differenc
        */

        public double PF { get; set; }
        public double QF { get; set; }
        public double PT { get; set; }
        public double QT { get; set; }
        public double MU_SF { get; set; }
        public double MU_ST { get; set; }
        public double MU_ANGMIN { get; set; }
        public double MU_ANGMAX { get; set; }

        public BranchDataWrapper()
        {

        }
        public BranchDataWrapper(BranchDataWrapper branchData)
        {
            ID = branchData.ID;
            F_Bus = branchData.F_Bus;
            T_Bus = branchData.T_Bus;
            BR_R = branchData.BR_R;
            BR_X = branchData.BR_X;
            BR_B = branchData.BR_B;
            RATE_A = branchData.RATE_A;
            RATE_B = branchData.RATE_B;
            RATE_C = branchData.RATE_C;
            this.degrees = branchData.degrees;
            TAP = branchData.TAP;
            INSERVIcE = branchData.INSERVIcE;
            ANGMIN = branchData.ANGMIN;
            ANGMAX = branchData.ANGMAX;
            PF = branchData.PF;
            QF = branchData.QF;
            PT = branchData.PT;
            QT = branchData.QT;
            MU_SF = branchData.MU_SF;
            MU_ST = branchData.MU_ST;
            MU_ANGMIN = branchData.MU_ANGMIN;
            MU_ANGMAX = branchData.MU_ANGMAX;
        }

        public override string ToString()
        {

            return "Branch " + F_Bus + "," + T_Bus + "," + " BR_R  = " + BR_R + "," + "BR_X = " + BR_X + "," + BR_B + "," + RATE_A + "," + RATE_B + "," + RATE_B + "," + RATE_C + "," + "dEGREE = " + degrees + "," + "TAP   = " + TAP + "," + " in servic" + INSERVIcE + "," + ANGMIN + "," + ANGMAX;
        }
    }
}
