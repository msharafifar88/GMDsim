using BL.Calculation_Core.ItemWraper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics;
using Numpy;
using MathNet.Numerics.LinearAlgebra;

namespace BL.Calculation_Core.Calculation_Class
{
    public class MakeYbus
    {
        List<BusDataWrapper> busDataWrapperList = new List<BusDataWrapper>();
        List<BranchDataWrapper> branchWrapperList = new List<BranchDataWrapper>();
        

        int nb = 0;          //number of buses
        int nl = 0;       // number of Branch

        int basemva = 0;
        public MakeYbus(int baseMVA, List<BusDataWrapper> busDatas, List<BranchDataWrapper> branchDatas)
        {
            busDataWrapperList = busDatas;

            basemva = baseMVA;
            branchWrapperList = branchDatas ;
            nb = busDatas.Count();
            nl = branchDatas.Count(); 
            
        }
        public (Matrix<System.Numerics.Complex>, Matrix<System.Numerics.Complex>, Matrix<System.Numerics.Complex>) Cal_MakeYbus() { 

            List<System.Numerics.Complex> Ys = new List<System.Numerics.Complex>();
            for (int i = 0; i < nl; i++)
            {
                if (branchWrapperList[i].INSERVIcE == true)
                {

                    System.Numerics.Complex ys_ = new System.Numerics.Complex(branchWrapperList[i].BR_R, branchWrapperList[i].BR_X);
                    if (ys_.Real == 0 && ys_.Imaginary == 0)
                    {
                        Ys.Add(0);
                    }
                    else //if(ys_.Real == 0 && ys_.Imaginary !=0) 
                    {              
                        Ys.Add(1 / ys_);
                    }
                   // Console.WriteLine("ys = " + Ys[i].Real + "+" + Ys[i].Imaginary + "j");
                }
          
            }

            List<double> BC = new List<double>();
            for (int i = 0; i < nl; i++)
            {
                if (branchWrapperList[i].INSERVIcE == true)
                {

                    BC.Add(Math.Round(branchWrapperList[i].BR_B, 5));


                }
                else
                    BC.Add(0);

               // Console.WriteLine(" BC ==  " + BC[i]);
            }

            //test result
            var vtt = new System.Numerics.Complex(0, 0);
            var vft = new System.Numerics.Complex(0, 0);
            var vtf = new System.Numerics.Complex(0, 0);
            var vff = new System.Numerics.Complex(0, 0);
            //double sum =BC.Sum();
            //Console.WriteLine(sum);
            Vector<System.Numerics.Complex> tab = Vector<System.Numerics.Complex>.Build.Dense(nl,x=>1);

            for (int i = 0; i < tab.Count; i++)
            {
                if (branchWrapperList[i].TAP != 0 )
                {
                    tab[i] =  new System.Numerics.Complex(Math.Round( branchWrapperList[i].TAP,5), Math.Round((Math.PI)* branchWrapperList[i].degrees,5));
                }
            }
           
        
           
           
            List<System.Numerics.Complex> Ytt = new List<System.Numerics.Complex>();
            for (int i = 0; i < nl; i++)
            {

                Ytt.Add(new System.Numerics.Complex(Math.Round(Ys[i].Real,5), Math.Round((BC[i] / 2) + Ys[i].Imaginary,5)));
                Console.WriteLine("Ytt  = " + Ytt[i]);
                vtt = vtt + Ytt[i];
            }
           // Console.WriteLine();

            List<System.Numerics.Complex> Yff = new List<System.Numerics.Complex>();
            for (int i = 0; i < nl; i++)
            {
                Yff.Add(Ytt[i] / (tab[i] * System.Numerics.Complex.Conjugate(tab[i])));
                // yff.Add(new System.Numerics.Complex(Ys[i].Real, (BC[i] / 2) + Ys[i].Imaginary));
                //Console.WriteLine("Yff  =  " + Yff[i]);
                vff = vff + Yff[i];
            }


            List<System.Numerics.Complex> Yft = new List<System.Numerics.Complex>();
            for (int i = 0; i < nl; i++)
            {
                Yft.Add(-Ys[i] / System.Numerics.Complex.Conjugate(tab[i]));
                // yff.Add(new System.Numerics.Complex(Ys[i].Real, (BC[i] / 2) + Ys[i].Imaginary));

                vft = vft +  Yft[i];
            }
           

            List<System.Numerics.Complex> Ytf = new List<System.Numerics.Complex>();
           
            for (int i = 0; i < nl; i++)
            {
                Ytf.Add(-Ys[i] / tab[i]);
                vtf = vtf + Ytf[i];
                // yff.Add(new System.Numerics.Complex(Ys[i].Real, (BC[i] / 2) + Ys[i].Imaginary));


            }
            
            Console.WriteLine(vtt);
            Console.WriteLine(vff);
            Console.WriteLine(vtf);
            Console.WriteLine(vft);

            List<int> F_bus = new List<int>();
            
            
            List<int> T_bus = new List<int>();
            for (int i = 0; i < nl; i++)
            {
                F_bus.Add((int)branchWrapperList[i].F_Bus);
                T_bus.Add((int)branchWrapperList[i].T_Bus);
               /* Console.WriteLine("yaaaakhode khoda " + F_bus[i]);
                Console.WriteLine("yaaaakhode khoda " + T_bus[i]);*/
            }
            var Yf = Matrix<System.Numerics.Complex>.Build.Dense(nl,nb);
            var Yt = Matrix<System.Numerics.Complex>.Build.Dense(nl, nb);
            //Console.WriteLine("yaaaakhode khoda " + test2);
            var f_t_bus = F_bus.Concat(T_bus);
            var CF = Matrix<System.Numerics.Complex>.Build.Dense(nl, nb);
            var CT = Matrix<System.Numerics.Complex>.Build.Dense(nl, nb);
            // var branc_cal = new List<int>(nb * 2);
            // Matrix<System.Numerics.Complex> test1 = Matrix<System.Numerics.Complex>.Build.Sparse(nl,nb, Yff);
            //var test = Matrix<System.Numerics.Complex>.Build.SparseFromCompressedSparseRowFormat(4, 4, 8, F_bus.ToArray() , T_bus.ToArray() , Yff.ToArray());
            for (int i = 0; i < nl; i++)
            {
                for (int j=0 ; j < nb; j++)
                {
                    if (branchWrapperList[i].F_Bus == busDataWrapperList[j].bus_number)
                    {
                        Yf[i, j] = Yff[i];
                        Yt[i, j] = Yft[i];
                        CF[i, j] = 1;
                        //Yf[j, i] = Yft[i];
                    }
                    else if (branchWrapperList[i].T_Bus == busDataWrapperList[j].bus_number)
                    {
                        Yf[i, j] = Ytf[i];
                        Yt[i, j] = Ytt[i];
                        CT[i, j] = 1;
                    }
                    else
                    {
                        Yf[i, j] = 0;
                    }
                   
                }
            }
                //Matrix<System.Numerics.Complex> test2 = Matrix<System.Numerics.Complex>.Build.SparseFromCompressedSparseRowFormat(8, 8,8, F_bus.ToArray(), T_bus.ToArray(), Yft.ToArray());
     
            List<System.Numerics.Complex> Ysh = new List<System.Numerics.Complex> (nb);
            Vector<System.Numerics.Complex> Vector_Ysh = Vector<System.Numerics.Complex>.Build.Dense(nb);
            var vsh =new System.Numerics.Complex(0, 0);
            foreach (BusDataWrapper bus in busDataWrapperList)
            {
                Ysh.Add(new System.Numerics.Complex(bus.GS, bus.BS)/basemva);
                
                //Console.WriteLine("Ysh =  " + Ysh);
            }
            for (int i=0; i < Ysh.Count; i++)
            {
                vsh = vsh + Ysh[i];
               
            }
            Console.WriteLine(vsh);
            Matrix<System.Numerics.Complex> Mstrix_Ysh = Matrix<System.Numerics.Complex>.Build.Dense(nb,nb);
            for (int i = 0; i < nb; i++)
            {
                for (int j = 0; j < nb; j++)
                {
                    if (busDataWrapperList[i].bus_number == busDataWrapperList[j].bus_number)
                        Mstrix_Ysh[i, j] = Ysh[i];

                }
            }
    


      
     

            //Console.WriteLine("Mstrix_Ysh =  " + Mstrix_Ysh);
            var Ybus = Matrix<System.Numerics.Complex>.Build.Dense(nb, nb);
            
            Ybus = (CF.Transpose() * Yf + CT.Transpose() * Yt + Mstrix_Ysh) ;
          
            System.Numerics.Complex b = 0;
            for (int i = 0; i < nb; i++)
            {
                for (int j = 0; j < nb; j++)
                {
                    if (Ybus[i, j] != 0)
                    {
                     
                        Console.WriteLine("Ybus (" + i + " " + j + " ) " + Ybus[i, j]);
                        b = (b + Ybus[i, j]);
                        
                    }
                }
            }

            
            Console.WriteLine("Ybus  = " + b);
       /*     System.Numerics.Complex qqq = 0;
            for (int i =0; i< nl; i++)
            {
                jjj = jjj + Ybus[i];
                
            }
                Console.WriteLine("ytt = " +  qqq);*/
            return (Ybus, Yf, Yt);
        }

       
    }

   
}
