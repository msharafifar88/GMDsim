using network;
using persistent.enumeration;
using persistent.network;
using System;

namespace GUI.Calculation.Transformer_pu
{
    public class Convert_w2ctransformer_pu
    {

        public static double Rpu { get; private set; }
        public static double Xpu { get; private set; }

        // Type 0 --> 2W   , Type 1--> 3w
        public static double calculateR_puPsc(C2WTransformer transformer)
        {
            if (transformer.nominalData.NominalRatingUnit.Equals(NominalRatingUnit.kVA))
            {
                double Sbase = Math.Min(transformer.nominalData.PrimaryNominalRating, transformer.nominalData.SecondaryNominalRating);
                Rpu = (transformer.impedances.Psc_HVLV) / (Sbase);
            }
            else if (transformer.nominalData.NominalRatingUnit.Equals(NominalRatingUnit.MVA))
            {

                Rpu = (transformer.impedances.Psc_HVLV) / ((transformer.nominalData.PrimaryNominalRating) * 1000);
            }

            return Rpu;
        }

        public static double calculateX_puPsc(C2WTransformer transformer)
        {
            double z = transformer.impedances.Z1_HVLV / 100;

            Xpu = Math.Sqrt(Math.Pow(z, 2) - Math.Pow(Rpu, 2));

            return Xpu;


        }

        public static double calculateR_puX1R1(C2WTransformer transformer)
        {
            if (transformer.nominalData.NominalRatingUnit.Equals(NominalRatingUnit.kVA))
            {
                double Sbase = Math.Min(transformer.nominalData.PrimaryNominalRating, transformer.nominalData.SecondaryNominalRating);
                Rpu = ((transformer.impedances.R1_HVLV) / 100) / (Sbase);
            }
            else if (transformer.nominalData.NominalRatingUnit.Equals(NominalRatingUnit.MVA))
            {

                Rpu = (transformer.impedances.R1_HVLV) / ((transformer.nominalData.PrimaryNominalRating) * 1000);
            }

            return Rpu;
        }

        public static double calculateX_puX1R1(C2WTransformer transformer)
        {
            Xpu = transformer.impedances.X1_HVLV / 100;



            return Xpu;


        }
    }

    public class Convert_w3ctransformer_pu
    {




        public static double Rpu { get; private set; }
        public static double Xpu { get; private set; }
        // for 3wining between winding HV and LV
        public static double calculateR1_2_puPsc(C3WTransformer transformer)
        {
            double Sbase = Math.Min(transformer.nominalData.PrimaryNominalRating, transformer.nominalData.SecondaryNominalRating);
            double Rpu = 0d;

            if (transformer.nominalData.NominalRatingUnit.Equals(NominalRatingUnit.kVA))
            {

                Rpu = (transformer.impedances.Psc_HVLV) / (Sbase);
            }
            else if (transformer.nominalData.NominalRatingUnit.Equals(NominalRatingUnit.MVA))
            {

                Rpu = (transformer.impedances.Psc_HVLV) / (Sbase) * 1000;
            }

            return Rpu;
        }

        public static double calculateX1_2_puPsc(C3WTransformer transformer)
        {
            double Xpu = 0d;
            double z = transformer.impedances.Z1_HVLV / 100;

            Xpu = Math.Sqrt(Math.Pow(Rpu, 2) - Math.Pow(z, 2));

            return Xpu;


        }

        public static double calculateR1_3_puPsc(C3WTransformer transformer)
        {
            double Sbase = Math.Min(transformer.nominalData.PrimaryNominalRating, transformer.nominalData.SecondaryNominalRating);

            if (transformer.nominalData.NominalRatingUnit.Equals(NominalRatingUnit.kVA))
            {

                Rpu = (transformer.impedances.Psc_HVTV) / (Sbase);
            }
            else if (transformer.nominalData.NominalRatingUnit.Equals(NominalRatingUnit.MVA))
            {

                Rpu = (transformer.impedances.Psc_HVTV) / (Sbase) * 1000;
            }

            return Rpu;
        }

        public static double calculateX1_3_puPsc(C3WTransformer transformer)
        {
            double z = transformer.impedances.Z1_HVTV / 100;

            Xpu = Math.Sqrt(Math.Pow(Rpu, 2) - Math.Pow(z, 2));

            return Xpu;


        }

        public static double calculateR2_3_puPsc(C3WTransformer transformer)
        {
            double Sbase = Math.Min(transformer.nominalData.SecondaryNominalRating, transformer.nominalData.TertiaryNominalRating);

            if (transformer.nominalData.NominalRatingUnit.Equals(NominalRatingUnit.kVA))
            {

                Rpu = (transformer.impedances.Psc_LVTV) / (Sbase);
            }
            else if (transformer.nominalData.NominalRatingUnit.Equals(NominalRatingUnit.MVA))
            {

                Rpu = (transformer.impedances.Psc_LVTV) / (Sbase) * 1000;
            }

            return Rpu;
        }

        public static double calculateX2_3_puPsc(C3WTransformer transformer)
        {
            double z = transformer.impedances.Z1_LVTV / 100;

            Xpu = Math.Sqrt(Math.Pow(Rpu, 2) - Math.Pow(z, 2));

            return Xpu;


        }

        public static double calculateR1_2_puX1R1(C3WTransformer transformer)
        {
            double Sbase = Math.Min(transformer.nominalData.PrimaryNominalRating, transformer.nominalData.SecondaryNominalRating);
            double Rpu = 0d;

            if (transformer.nominalData.NominalRatingUnit.Equals(NominalRatingUnit.kVA))
            {

                Rpu = ((transformer.impedances.R1_HVLV) / 100) / (Sbase);
            }
            else if (transformer.nominalData.NominalRatingUnit.Equals(NominalRatingUnit.MVA))
            {

                Rpu = ((transformer.impedances.R1_HVLV) / 100) / (Sbase) * 1000;
            }

            return Rpu;
        }

        public static double calculateX1_2_puX1R1(C3WTransformer transformer)
        {


            Xpu = transformer.impedances.Z0_HVLV / 100;

            return Xpu;


        }

        public static double calculateR1_3_puX1R1(C3WTransformer transformer)
        {
            double Sbase = Math.Min(transformer.nominalData.PrimaryNominalRating, transformer.nominalData.SecondaryNominalRating);

            if (transformer.nominalData.NominalRatingUnit.Equals(NominalRatingUnit.kVA))
            {

                Rpu = ((transformer.impedances.R1_HVTV) / 100) / (Sbase);
            }
            else if (transformer.nominalData.NominalRatingUnit.Equals(NominalRatingUnit.MVA))
            {

                Rpu = ((transformer.impedances.R1_HVTV) / 100) / (Sbase) * 1000;
            }

            return Rpu;
        }

        public static double calculateX1_3_puX1R1(C3WTransformer transformer)
        {


            Xpu = transformer.impedances.Z0_HVTV / 100;
            return Xpu;


        }

        public static double calculateR2_3_puX1R1(C3WTransformer transformer)
        {
            double Sbase = Math.Min(transformer.nominalData.SecondaryNominalRating, transformer.nominalData.TertiaryNominalRating);

            if (transformer.nominalData.NominalRatingUnit.Equals(NominalRatingUnit.kVA))
            {

                Rpu = ((transformer.impedances.R1_LVTV) / 100) / (Sbase);
            }
            else if (transformer.nominalData.NominalRatingUnit.Equals(NominalRatingUnit.MVA))
            {

                Rpu = ((transformer.impedances.R1_LVTV) / 100) / (Sbase) * 1000;
            }

            return Rpu;
        }

        public static double calculateX2_3_puX1R1(C3WTransformer transformer)
        {


            Xpu = transformer.impedances.Z0_LVTV / 100;

            return Xpu;


        }



    }

}
