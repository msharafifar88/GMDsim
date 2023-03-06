namespace persistent.network.Calculation_entitiy.Line_pu
{
    public class Line_pu
    {
        public long R_pu { get; set; }   //resistance
        public long X_pu { get; set; }   //reactance
        public long B_pu { get; set; }   //charging susceptance


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
