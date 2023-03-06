namespace persistent.network.Calculation_entitiy.Transformer
{
    public class Transformer_pu
    {
        // system per unit
        public double R1_2_pu { get; set; }   //resistance
        public double R1_3_pu { get; set; }
        public double R2_3_pu { get; set; }

        public double X1_2_pu { get; set; }   //reactance
        public double X1_3_pu { get; set; }
        public double X2_3_pu { get; set; }

        public double B_pu { get; set; }   //charging susceptance


        /// <summary>
        /// (long term rating),(short term rating),(emergency rating),
        /// </summary>
        public long RATEA_pu { get; set; }   //MVA rating A
        public long RATEB_pu { get; set; }   //MVA rating B
        public long RATEC_pu { get; set; }   //MVA rating C 
        public long RATED_pu { get; set; }   //MVA rating D
        public long RATEE_pu { get; set; }   //MVA rating E
        public long RATEF_pu { get; set; }   //MVA rating F 
    }
}
