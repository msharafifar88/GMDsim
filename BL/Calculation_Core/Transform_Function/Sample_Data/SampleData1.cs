using BL.Calculation_Core.ItemWraper;
using System.Collections.Generic;

namespace BL.Calculation_Core.Transform_Function.Sample_Data
{
    public class SampleData1
    {
        public static List<vect_fit_DataWrapper> createVec_fit_Wrapper()
        {
            List<vect_fit_DataWrapper> vectorfit = new List<vect_fit_DataWrapper>();
            vect_fit_DataWrapper data1 = new vect_fit_DataWrapper();
            data1.Fs = -6; data1.Fe = 2; data1.Ns = 2000; data1.Nl = 13;
            data1.Ro = new List<double> { 90, 100, 1.5e4, 100, 200, 250, 158, 29, 8, 2.4, 0.89, 0.47, 10 };
            data1.Hi = new List<double> { 30, 6e2, 1.44e4, 2.5e4, 1.5e4, 6e4, 1.5e5, 1.60e5, 1.1e5, 1.5e5, 2.3e5, 1e5 };
            vectorfit.Add(data1);
            return vectorfit;

        }


    }
}
