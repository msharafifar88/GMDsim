namespace BL.Calculation_Core.ItemWraper
{
    public class GeneratorDataWrapper
    {
        /*
            GEN BUS     1       bus number
            PG          2       real power output (MW)
            QG          3       reactive power output (MVAr)
            QMAX        4       maximum reactive power output (MVAr)
            QMIN        5        minimum reactive power output (MVAr)
            VG‡ 6 voltage magnitude setpoint (p.u.)
            MBASE 7 total MVA base of machine, defaults to baseMVA
            GEN STATUS 8 machine status,
            > 0 = machine in-service
             0 = machine out-of-service
            PMAX 9 maximum real power output (MW)
            PMIN 10 minimum real power output (MW)
            PC1* 11 lower real power output of PQ capability curve (MW)
            PC2* 12 upper real power output of PQ capability curve (MW)
            QC1MIN* 13 minimum reactive power output at PC1 (MVAr)
            QC1MAX* 14 maximum reactive power output at PC1 (MVAr)
            QC2MIN* 15 minimum reactive power output at PC2 (MVAr)
            QC2MAX* 16 maximum reactive power output at PC2 (MVAr)
            RAMP AGC* 17 ramp rate for load following/AGC (MW/min)
            RAMP 10* 18 ramp rate for 10 minute reserves (MW)
            RAMP 30* 19 ramp rate for 30 minute reserves (MW)
            RAMP Q* 20 ramp rate for reactive power (2 sec timescale) (MVAr/min)
            APF* 21 area participation factor
         */
        //public string bus_name { get; set; }
        private long _Gen_bus_number;
        public long Gen_bus_number
        {
            get { if (_Gen_bus_number == 0) { return 0; } else { return _Gen_bus_number - 1; } }
            set { _Gen_bus_number = value; }
        }


        public double PG { get; set; }
        public double QG { get; set; }
        public double QMAX { get; set; }

        public double QMIN { get; set; }
        public float VG { get; set; } = 1.0f;

        public double MBASE { get; set; }

        public bool Gen_status { get; set; }
        public double PMAX { get; set; }
        public double PMIN { get; set; }
        public double PC1 { get; set; }
        public double PC2 { get; set; }
        public double QC1MIN { get; set; }
        public double QC1MAX { get; set; }
        public double QC2MIN { get; set; }
        public double QC2MAX { get; set; }
        public double RAMP_AGC { get; set; } = 0.0;
        public double RAMP10 { get; set; } = 0.0;
        public double RAMP30 { get; set; } = 0.0;
        public double RAMP_Q { get; set; } = 0.0;
        public double APF { get; set; } = 0.0;

        public override string ToString()
        {
            return "Generator :" + Gen_bus_number + " , " + PG + " , " + QG + " , " + QMAX + " , " + QMIN + " , " + " vg = " + VG + " , " + MBASE + " , " + Gen_status + " , " + PMAX + " , " + PMIN + " , " + PC1 + " , " + PC2 + " , " + QC1MIN + " , " + QC1MAX + " , " + QC2MIN +
                " , " + QC2MAX + " , " + RAMP_AGC + " , " + RAMP10 + " , " + RAMP30 + " , " + RAMP_Q + " , " + APF;
        }
    }
}
