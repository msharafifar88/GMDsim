using BL.Calculation_Core.Calculation_Data;
using BL.Calculation_Core.ItemWraper;
//using MathNet.Numerics;
//using MathNet.Numerics.LinearAlgebra;
using persistent;
using persistent.enumeration;
using System;
using System.Collections.Generic;
using System.Numerics;

namespace BL.Calculation_Core.Transform_Function
{
    public class Vect_Fitting
    {

        Data_Collector data_Collector;
        List<vect_fit_DataWrapper> fitting = new List<vect_fit_DataWrapper>();


        int nv = 0;
        double mo = 0.0d;
        int ns;
        double fs;
        double fe;
        List<double> sigma;
        List<double> Thickness;
        public Vect_Fitting(Case cases, TypeOfInput typeOfInput)
        {



            mo = 4 * Math.PI * 1e-7;
            data_Collector = new Data_Collector(cases, typeOfInput);
            fitting = data_Collector.findAllVectorData();

            foreach (vect_fit_DataWrapper test in fitting)
            {
                nv = test.Hi.Count;
                ns = test.Ns;
                fs = test.Fs;
                fe = test.Fe;
                Thickness = test.Hi;
                sigma = test.Ro;

            }


            cal_vecfitting();
        }
        public List<double> cal_vecfitting()
        {
            // var freq =Generate.LogSpaced(ns, fs, fe);
            List<double> Tf = new List<double>();
            MathNet.Numerics.LinearAlgebra.Vector<Complex> test = MathNet.Numerics.LinearAlgebra.Vector<Complex>.Build.Dense(10, x => 1);
            /* MathNet.Numerics.LinearAlgebra.Vector<Complex> gama = Vector<double>.Build;
             Vector<Complex> etta = new Vector<Complex>(nv - 1);
             Vector<Complex> R = new Vector<Complex>(nv);
             Vector<Complex> alpha = new Vector<Complex>(nv - 1);
             Vector<Complex> Z = new Vector<Complex>(nv);
             Vector<Complex> Ze = new Vector<Complex>(ns);
             Vector<Complex> low_pass = new Vector<Complex>(ns);
             Vector<Complex> mag = new Vector<Complex>(ns);*/
            for (int i = 0; i < sigma.Count; i++)
            {
                sigma[i] = 1 / sigma[i];

            }

            for (int i = 0; i < ns; i++)
            {
                //new System.Numerics.Complex(Math.Round( branchWrapperList[i].TAP,5), Math.Round((Math.PI)* branchWrapperList[i].degrees,5));
                // double w =  2 * Math.PI * freq[i];
                //Z[nv - 1] = new System.Numerics.Complex(0, Math.Sqrt(w * mo / sigma[nv - 1]));

            }


            return Tf;
        }
    }
}
