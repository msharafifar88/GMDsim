using BL.Calculation_Core.ItemWraper;
using System;
using System.Collections.Generic;
using System.Linq;
using MathNet.Numerics.LinearAlgebra;
using System.Text;
using System.Threading.Tasks;
using static persistent.enumeration.Calculation_RUNPF.Option;
using Complex = System.Numerics.Complex;


namespace BL.Calculation_Core.Calculation_Class.Calculat_runpfmethod
{
    public class Newton_PF
    {

        BusBL busBL = new BusBL();
        LoadBL loadBL = new LoadBL();

        Single3phaseLineBL single3PhaseLineBL = new Single3phaseLineBL();
        DoubleCircuitLineBL doubleCircuitLineBL = new DoubleCircuitLineBL();
        MultiPhaseLineBL multiPhaseLineBL = new MultiPhaseLineBL();
        GeneratorBL generatorBL = new GeneratorBL();
        C2WTransformerBL c2WTransformerBL = new C2WTransformerBL();
        C3WTransformerBL c3wTransformerBL = new C3WTransformerBL();

        List<BusDataWrapper> busDataWrapperList = new List<BusDataWrapper>();
        List<GeneratorDataWrapper> generatorWrapperList = new List<GeneratorDataWrapper>();
        List<BranchDataWrapper> branchDataWrappersList = new List<BranchDataWrapper>();
        int nb = 0;          //number of buses
        int nl = 0;          //number of branchs
        int ng = 0;             // number of Generators

        PF_Option pf_option = new PF_Option();
        CPF_OPTIONS cpf_OPTIONS = new CPF_OPTIONS();
        OPF_Option opf_Option = new OPF_Option();
        OUTPUT_OPTIONS output_OPTIONS = new OUTPUT_OPTIONS();
        GUROBI_OPTIONS gurobi_OPTIONS = new GUROBI_OPTIONS();
        PDIPM_OPTIONS pdipm_OPTION = new PDIPM_OPTIONS();

        public Newton_PF(List<BusDataWrapper> busDatas, List<BranchDataWrapper> branchDatas, List<GeneratorDataWrapper> genDatas)
        {

            busDataWrapperList = busDatas;
            generatorWrapperList = genDatas;
            branchDataWrappersList = branchDatas;
            nb = busDatas.Count();
            ng = genDatas.Count();
            nl = branchDatas.Count();
        }

        public (Vector<System.Numerics.Complex>, bool, int) Cal_Newton_PF(
                Matrix<System.Numerics.Complex>  Ybus, 
                Vector<System.Numerics.Complex>  Sbus, 
                Vector<System.Numerics.Complex> V0, 
                List<BusDataWrapper> bus_ref, 
                List<BusDataWrapper> pv, 
                List<BusDataWrapper> pq)
        {



            

            //options
            int Num_PV = pv.Count;
            int Num_pq = pq.Count;
            double tol_ = (double) pf_option.pf_tol;
            double PF_MAX_IT_ = (double)pf_option.pf_max_it;
            int VERBOSE = (int)output_OPTIONS.verbose;
            //initialize

            Vector<System.Numerics.Complex> V = V0.Clone();
            bool converged = false;
            int index_of_iterator = 0;

            for (int i = 0; i < V.Count; i++)
            {

                busDataWrapperList[i].VM = System.Numerics.Complex.Abs(V[i]);
                busDataWrapperList[i].VA = Math.Atan(V[i].Imaginary / V[i].Real);
              

            }

            // set up indexing for updating V

            List<BusDataWrapper> PVPQ = new List<BusDataWrapper>();
            PVPQ.AddRange(pv.Concat(pq));
        
            int num_pv = pv.Count();
            int num_pq = pq.Count();

            int j1 = 0;     int j2 = num_pv;
            int j3 = j2;    int j4 = j2 + num_pq;
            int j5 = j4;    int j6 = j4 + num_pq;

            //   evaluate F(x0)
            System.Numerics.Complex a = 0;
            System.Numerics.Complex b = 0;
            for (int i =0; i < Ybus.RowCount; i++)
            {
                for (int j =0; j < Ybus.ColumnCount; j++)
                {
                    if (Ybus[i,j] != 0)
                    {
                        a = Ybus[i, j] + a;
                        b = Ybus[j, i] + b;
                        Console.WriteLine( "Ybus ("+ i +" "+j +" ) "+  Ybus[i, j]);
                        Console.WriteLine(" C = " + (a - b));
                    }
                }
            }
            var c = a - b;
            var cal_ = Ybus * V;
            cal_ = cal_.Conjugate();
            cal_ = cal_;
            Vector<System.Numerics.Complex>  mis = V.PointwiseMultiply(cal_) - Sbus;

            //  F = r_[  mis[pv].real, mis[pq].real, mis[pq].imag  ]
            List<double> F = new List<double>();

            List<double> Fpv = new List<double>();
            List<double> Fpqreal = new List<double>();
            List<double> Fpqimg = new List<double>();
            List<BusDataWrapper> FindPV = Utils.FindPV(busDataWrapperList);
            List<BusDataWrapper> FindPQ = Utils.FindPQ(busDataWrapperList);

            for (int i = 0; i < nb; i++)
            {
                if (busDataWrapperList[i].bus_type.Equals(2))
                {
                    Fpv.Add(mis[i].Real);
                }
                if (busDataWrapperList[i].bus_type.Equals(1))
                {
                    Fpqreal.Add(mis[i].Real);
                }
                if (busDataWrapperList[i].bus_type.Equals(1))
                {
                    Fpqimg.Add(mis[i].Imaginary);
                }
            }

            F.AddRange(Fpv.Concat(Fpqreal.Concat(Fpqimg)));

            //check tolerance
            Vector<double> F_vector = Vector<double>.Build.Dense(F.Count);
          
            for (int i = 0; i < F.Count; i++)
            {
                var test = F[i];
                F_vector[i] = test;
            }

            double NormF = F_vector.AbsoluteMaximum();
            var aaaa = F_vector.InfinityNorm();
            //  Console.WriteLine(" NormF ==================== " + NormF);



            if (VERBOSE > 1)
            {
                Console.WriteLine(" index of iterator " + index_of_iterator  +" Normalaize " + NormF);
            }
            if(VERBOSE < tol_)
            {
                converged = true;
                if (VERBOSE > 1)
                {
                    Console.WriteLine(" Successfully converged!");
                }

            }

            //     do Newton iterations
            while ( converged == false && index_of_iterator < PF_MAX_IT_)
            {
                index_of_iterator = index_of_iterator + 1;
                dSbus_dV dsbus_dv = new dSbus_dV(busDataWrapperList, branchDataWrappersList, generatorWrapperList);
                var (dS_dVm, dS_dVa) = dsbus_dv.Cal_Dsbus_dV(Ybus,V);
            /*    for (int i = 0; i < dS_dVa.RowCount; i++)
                {
                    for (int j = 0; j < dS_dVa.ColumnCount; j++)
                    {
                        if (Ybus[i, j] != 0)
                        {

                            Console.WriteLine("dS_dVa (" + i + " " + j + " ) " + dS_dVa[i, j]);
                            //Console.WriteLine(" C = " + (a - b));
                        }
                    }
                }*/


                // evaluate Jacobian


                var J11 = Utils.Cal_dS_dVa_PVPQ_Real(dS_dVa,busDataWrapperList); ;
              /*  
                for (int i = 0; i < J11.RowCount; i++)
                {
                    for (int j = 0; j < J11.ColumnCount; j++)
                    {
                        if (J11[i, j] != 0)
                        {

                            Console.WriteLine("J11 (" + i + " " + j + " ) " + J11[i, j]);
                            //Console.WriteLine(" C = " + (a - b));
                        }
                    }
                }*/
                var J12 = Utils.Cal_dS_dVm_PVPQ_Real(dS_dVm, busDataWrapperList);    
                var J21 = Utils.Cal_dS_dVa_PQ_Imaginery(dS_dVa, busDataWrapperList);
                var J22 = Utils.Cal_dS_dVm_PQ_Imaginery(dS_dVm, busDataWrapperList);

                var J11_12 = J11.Append(J12) ;
                var J21_22 = J21.Append(J22);
                Matrix<double> J = J11_12.Stack(J21_22);

 
                for (int i = 0; i < F.Count; i++)
                {
                    var test = F[i];
                    F_vector[i] = test; 
                }

               
                Vector<double> dx = -1 * J.Solve(F_vector);
                // Console.WriteLine(" dx = " + dx);
                int DX_counter = 0;
                //  ## update voltage
                if (Num_PV != 0)
                {

                    for (int i = j1; i < j2; i++)
                    {
                        FindPV[i].VA = FindPV[i].VA+ dx[DX_counter];
                        DX_counter++;

                    // = test;

                    busDataWrapperList.Find(bus => bus.Equals(FindPV[i])).VA = FindPV[i].VA;
                        //foreach (BusDataWrapper bus_vs in busDataWrapperList) { if (bus_vs.Equals(FindPV[i])){ bus_vs.VA = FindPV[i].VA; } }
                    
                    }

                }
                if (Num_pq != 0)
                {
                    for(int i = j3; i <j4; i++)
                    {
                        FindPQ[i-j2].VA =( FindPQ[i-j2].VA + dx[DX_counter]);
                        DX_counter++;
                        busDataWrapperList.Find(bus => bus.Equals(FindPQ[i - j2])).VA = FindPQ[i - j2].VA;
                        // foreach (BusDataWrapper bus_vs in busDataWrapperList) { if (bus_vs.bus_type.Equals(3)) { bus_vs.VA = FindPQ[i - j2].VA; } }

                    }

                    for (int i = j5; i < j6; i++)
                    {
                        FindPQ[i-j4].VM = FindPQ[i-j4].VM + dx[DX_counter];
                        DX_counter++;
                        busDataWrapperList.Find(bus => bus.Equals(FindPQ[i - j4])).VM = FindPQ[i - j4].VM;
                        // Console.WriteLine("  FindPQ[i-j4].VM = " + FindPQ[i - j4].VM);
                        // foreach (BusDataWrapper bus_vs in busDataWrapperList) { if (bus_vs.bus_type.Equals(3)) { bus_vs.VM = FindPQ[i - j4].VM; } }
                        //Vm[i - j4] = FindPQ[i - j4].VM;

                        //Console.WriteLine("   Vm[i - j4] = " + Vm[i - j4]);
                    }
                }

              
                for (int i = 0; i < nb; i++)
                {

                    
                    V[i] = (busDataWrapperList[i].VM) * System.Numerics.Complex.Exp(new System.Numerics.Complex(0, (busDataWrapperList[i].VA))); 
                   // V[i] = (busDataWrapperList[i].VM) * System.Numerics.Complex.Exp(new System.Numerics.Complex(0,  (busDataWrapperList[i].VA)));
                   // V[i] = busDataWrapperList[i].VM * MathNet.Numerics.ComplexExtensions.Exp(new System.Numerics.Complex(0, busDataWrapperList[i].VA));

                    //Console.WriteLine(" New V = " +  V[i]);
                }
                for (int i = 0; i < V.Count; i++)
                {

                    busDataWrapperList[i].VM = System.Numerics.Complex.Abs(V[i]);
                    busDataWrapperList[i].VA = Math.Atan(V[i].Imaginary / V[i].Real) ;
                   // Console.WriteLine(" Mag(pu) = " + busDataWrapperList[i].VM + " Ang(deg) = "  + busDataWrapperList[i].VA);
                   
                }

                
                // ## evalute F(x)

                mis = V.PointwiseMultiply( (Ybus * V ).Conjugate()) - Sbus;

               // var mis_new = t.PointwiseMultiply(cal_1) - Sbus;


                int PVPointer = 0;
                for (int i = 0; i < nb; i++)
                {
                    if (busDataWrapperList[i].bus_type.Equals(2))
                    {
                        
                        var test = mis[i].Real;
                        Fpv[PVPointer]=(test);
                        PVPointer++;
                    }
                    

                }
                int PQPointer = 0;
                for (int i = 0; i < nb; i++)
                {
                    if (busDataWrapperList[i].bus_type.Equals(1))
                    {
                        var test = mis[i].Real;
                        Fpqreal[PQPointer ]=(test);

                        PQPointer++;
                    }
                    
                }
                PQPointer = 0;
                for (int i = 0; i < nb; i++)
                {
                    if (busDataWrapperList[i].bus_type.Equals(1))
                    {
                        var test = mis[i].Imaginary;
                        Fpqimg[PQPointer] = (test); ;

                        PQPointer++;
                    }

                }

                List<double> new_F = new List<double>();
                new_F.AddRange( Fpv.Concat(Fpqreal.Concat(Fpqimg)));

                for (int i = 0; i < F.Count; i++)
                {
                    F[i] = new_F[i];
                    var test = F[i];
                    F_vector[i] = test;
                }



                //check for convergence
                // norme left

                
                NormF = F_vector.InfinityNorm();

                Console.WriteLine("NormF   = " + NormF);


                if (VERBOSE > 1)
                {
                    Console.WriteLine(" index of iterator " + index_of_iterator + " Normalaize " + NormF);
                }
                if (NormF < tol_)
                {
                    converged = true;
                    if (VERBOSE > 1)
                    {
                        Console.WriteLine(" Newton's method power flow converged in!");
                    }

                }




            }



            if (VERBOSE > 1)
                if (converged == false)
                {
                    Console.WriteLine(" Newton's method power did not converge in");
                }


            /*
            for (int i = 0; i < V.Count; i++)
            {


                busDataWrapperList[i].VA = (busDataWrapperList[i].VA * Math.PI)/180;
            }*/
            return (V, converged, index_of_iterator);
        }
    }
}



/*    for (int i = 0; i < nb; i++)
       {
           if (busDataWrapperList[i].bus_type.Equals(2))
           {

               var test = mis[i].Real;
               Fpv.Add(test);
           }


       }
       for (int i = 0; i < nb; i++)
       {
           if (busDataWrapperList[i].bus_type.Equals(1))
           {
               var test = mis[i].Real;
               Fpqreal.Add(test);


           }
       }
       for (int i = 0; i < nb; i++)
       {
           if (busDataWrapperList[i].bus_type.Equals(1))
           {
               var test = mis[i].Imaginary;
               Fpqimg.Add(test); 


           }
       }*/