namespace BL.Calculation_Core.ItemWraper
{
    public class BusDataWrapper
    {
        //public string bus_name { get; set; }
        public long bus_number { get; set; }
        //PQ      = 1   PV      = 2   REF     = 3  NONE    = 4
        public int bus_type { get; set; }

        public double PD { get; set; }
        public double QD { get; set; }
        public double GS { get; set; }

        public double BS { get; set; } = 0.0;
        public long area { get; set; }

        public double VM { get; set; }

        public double VA { get; set; }
        public double Base_KV { get; set; }
        public int ZONE { get; set; }
        public double VMAX { get; set; }
        public double VMIN { get; set; }

        public override bool Equals(object obj)
        {
            return obj is BusDataWrapper wrapper &&
                   bus_number == wrapper.bus_number &&
                   bus_type == wrapper.bus_type &&
                   PD == wrapper.PD &&
                   QD == wrapper.QD &&
                   GS == wrapper.GS &&
                   BS == wrapper.BS &&
                   area == wrapper.area &&
                   VM == wrapper.VM &&
                   VA == wrapper.VA &&
                   Base_KV == wrapper.Base_KV &&
                   ZONE == wrapper.ZONE &&
                   VMAX == wrapper.VMAX &&
                   VMIN == wrapper.VMIN;
        }

        public override int GetHashCode()
        {
            int hashCode = -1817003114;
            hashCode = hashCode * -1521134295 + bus_number.GetHashCode();
            hashCode = hashCode * -1521134295 + bus_type.GetHashCode();
            hashCode = hashCode * -1521134295 + PD.GetHashCode();
            hashCode = hashCode * -1521134295 + QD.GetHashCode();
            hashCode = hashCode * -1521134295 + GS.GetHashCode();
            hashCode = hashCode * -1521134295 + BS.GetHashCode();
            hashCode = hashCode * -1521134295 + area.GetHashCode();
            hashCode = hashCode * -1521134295 + VM.GetHashCode();
            hashCode = hashCode * -1521134295 + VA.GetHashCode();
            hashCode = hashCode * -1521134295 + Base_KV.GetHashCode();
            hashCode = hashCode * -1521134295 + ZONE.GetHashCode();
            hashCode = hashCode * -1521134295 + VMAX.GetHashCode();
            hashCode = hashCode * -1521134295 + VMIN.GetHashCode();
            return hashCode;
        }
        public BusDataWrapper() { }
        public BusDataWrapper(BusDataWrapper busdata)
        {
            this.bus_number = busdata.bus_number;
            this.bus_type = busdata.bus_type;
            PD = busdata.PD;
            QD = busdata.QD;
            GS = busdata.GS;
            BS = busdata.BS;
            this.area = busdata.area;
            VM = busdata.VM;
            VA = busdata.VA;
            Base_KV = busdata.Base_KV;
            ZONE = busdata.ZONE;
            VMAX = busdata.VMAX;
            VMIN = busdata.VMIN;
        }

        //  public double VAU { get; set; }

        public override string ToString()
        {

            return "Bus = " + bus_number + "   , bus_type =  " + bus_type + "   , PD = " + PD + "   ,  QD = " + QD + "   , GS = " + GS + "   , BS =  " + BS + "   , area = " + area + "   ,  VM = " + VM + "   , VA = " + VA + "   , Base_KV = " + Base_KV + "   , ZONE = " + ZONE + "   , VMAX = " + VMAX + "   ,  VMIN =  " + VMIN;
        }



        /*

        BUS I bus number(positive integer)
                BUS TYPE 2 bus type(1 = PQ, 2 = PV, 3 = ref, 4 = isolated)
                PD real power demand(MW)
                QD reactive power demand(MVAr)
                GS shunt conductance(MW demanded at V = 1.0 p.u.)
                BS shunt susceptance(MVAr injected at V = 1.0 p.u.)
                BUS AREA    area number(positive integer)
                VM voltage magnitude(p.u.)
                VA voltage angle(degrees)
                BASE KV     base voltage(kV)
                ZONE loss zone(positive integer)
                VMAX maximum voltage magnitude(p.u.)
                VMIN minimum voltage magnitude(p.u.)
        */
    }
}
