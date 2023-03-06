using BL.Calculation_Core.ItemWraper;
using MathNet.Numerics.LinearAlgebra;
using System;
using System.Collections.Generic;
using System.Linq;
using static persistent.enumeration.Calculation_RUNPF.Option;

namespace BL.Calculation_Core.Calculation_Class.Calculat_runpfmethod
{
    public class FD_PF
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

        public FD_PF(List<BusDataWrapper> busDatas, List<BranchDataWrapper> branchDatas, List<GeneratorDataWrapper> genDatas)
        {

            busDataWrapperList = busDatas;
            generatorWrapperList = genDatas;
            branchDataWrappersList = branchDatas;
            nb = busDatas.Count();
            ng = genDatas.Count();
            nl = branchDatas.Count();
        }

        public (Vector<System.Numerics.Complex>, bool, int) Cal_FD_PF(Matrix<System.Numerics.Complex> Ybus, Vector<System.Numerics.Complex> Sbus, Vector<System.Numerics.Complex> V0, Matrix<double> Bp, Matrix<double> Bpp, List<BusDataWrapper> bus_ref, List<BusDataWrapper> pv, List<BusDataWrapper> pq)
        {
            Vector<System.Numerics.Complex> V = Vector<System.Numerics.Complex>.Build.Dense(nb);
            List<BusDataWrapper> FindPV = Utils.FindPV(busDataWrapperList);
            List<BusDataWrapper> FindPQ = Utils.FindPQ(busDataWrapperList);
            List<BusDataWrapper> PVPQ = new List<BusDataWrapper>();
            List<BusDataWrapper> allBus = new List<BusDataWrapper>();
            //options
            int Num_PV = pv.Count;
            int Num_pq = pq.Count;
            double tol_ = (double)pf_option.pf_tol;
            double PF_MAX_IT_ = (double)pf_option.pf_max_it_fd;
            int VERBOSE = (int)output_OPTIONS.verbose;
            bool converged = false;
            allBus = busDataWrapperList;
            //initialize


            int index_of_iterator = 0;

            List<BusDataWrapper> VM = busDataWrapperList;

            for (int i = 0; i < nb; i++)
            {

                if (VM[i].bus_type.Equals(2))
                {
                    for (int j = 0; j < ng; j++)
                    {
                        if (VM[i].bus_number == generatorWrapperList[j].Gen_bus_number)
                        {
                            VM[i].VM = generatorWrapperList[j].VG;
                        }
                    }

                }
                VM[i].VM = Math.Abs(VM[i].VM);

            }

            Vector<System.Numerics.Complex> Vm_abs = Vector<System.Numerics.Complex>.Build.Dense(nb);
            for (int i = 0; i < VM.Count; i++)
            {
                Vm_abs[i] = VM[i].VM;
            }

            // set up indexing for updating V
            PVPQ.AddRange(pv.Concat(pq));

            int num_pv = pv.Count();
            int num_pq = pq.Count();

            V = V0;

            //    ## evaluate F(x0)
            //   mis = V * conj(Ybus * V) - Sbus
            var cal_ = Ybus * V;
            var con_Ybus = cal_.Conjugate();
            var mis = ((V.PointwiseMultiply(con_Ybus)) - Sbus) / Vm_abs;


            List<double> Ppvreal = new List<double>();
            List<double> Ppqreal = new List<double>();
            List<double> P_pvpqreal = new List<double>();
            List<double> Qpqimg = new List<double>();
            List<double> Va_PV = new List<double>();
            List<double> Va_PQ = new List<double>();
            List<double> Va_PVPQ = new List<double>();
            /* Vector<double> Fpv = Vector<double>.Build.Dense(pv.Count);
             Vector<double> Fpqreal = Vector<double>.Build.Dense(pq.Count);
             Vector<double> Fpqimg = Vector<double>.Build.Dense(pq.Count);*/


            for (int i = 0; i < nb; i++)
            {
                if (busDataWrapperList[i].bus_type.Equals(2))
                {
                    var test_pv = allBus[i].VA;
                    var test = mis[i].Real;
                    Ppvreal.Add(test);
                    Va_PV.Add(test_pv);
                }


            }
            for (int i = 0; i < nb; i++)
            {
                if (busDataWrapperList[i].bus_type.Equals(1))
                {
                    var test = mis[i].Real;
                    Ppqreal.Add(test);
                    var test_pq = allBus[i].VA;
                    Va_PQ.Add(test_pq);
                }
            }
            for (int i = 0; i < nb; i++)
            {
                if (busDataWrapperList[i].bus_type.Equals(1))
                {
                    var test = mis[i].Imaginary;
                    Qpqimg.Add(test);


                }
            }



            P_pvpqreal.AddRange(Ppvreal.Concat(Ppqreal));
            Va_PVPQ.AddRange(Va_PV.Concat(Va_PQ));
            Vector<double> VA_PVPQ_vector = Vector<double>.Build.Dense(Va_PVPQ.Count);

            for (int i = 0; i < Va_PVPQ.Count; i++)
            {
                var test = Va_PVPQ[i];
                VA_PVPQ_vector[i] = test;
            }
            //check tolerance
            Vector<double> P_PVPQ_vector = Vector<double>.Build.Dense(P_pvpqreal.Count);
            for (int i = 0; i < P_pvpqreal.Count; i++)
            {
                var test = P_pvpqreal[i];
                P_PVPQ_vector[i] = test;
            }
            var NormP = P_PVPQ_vector.InfinityNorm();

            Vector<double> Q_PQ_vector = Vector<double>.Build.Dense(Qpqimg.Count);
            for (int i = 0; i < Qpqimg.Count; i++)
            {
                var test = Qpqimg[i];
                Q_PQ_vector[i] = test;
            }
            var NormQ = Q_PQ_vector.InfinityNorm();


            if (VERBOSE > 1)
            {
                Console.WriteLine(" index of iterator = " + index_of_iterator + " P =  " + NormP + " Q = " + NormQ);
            }
            if (NormP < tol_ && NormQ < tol_)
            {
                converged = true;
                if (VERBOSE > 1)
                {
                    Console.WriteLine(" Successfully converged!");
                }

            }




            var BP_pvpq = Utils.Cal_BP_PVPQ(Bp, busDataWrapperList);
            var Bpp_pv = Utils.Cal_Bpp_PQ_PQ(Bpp, busDataWrapperList);
            var Bp_solvrt = BP_pvpq.LU();
            var Bpp_solvrt = Bpp_pv.LU();




























            //// do P and Q iterations
            while (converged == false && index_of_iterator < PF_MAX_IT_)
            {
                index_of_iterator = index_of_iterator + 1;
                //      do P iteration, update Va
                //      update voltage
                var DVa = -Bp_solvrt.Solve(P_PVPQ_vector);

                //  Update VA
                int DX_counter = 0;

                if (Num_PV != 0)
                {

                    for (int i = 0; i < num_pv; i++)
                    {
                        //FindPV[i].VA = FindPV[i].VA + DVa[DX_counter];


                        // = test;

                        busDataWrapperList.Find(bus => bus.Equals(FindPV[i])).VA = FindPV[i].VA + DVa[DX_counter];
                        DX_counter++;
                        //foreach (BusDataWrapper bus_vs in busDataWrapperList) { if (bus_vs.Equals(FindPV[i])){ bus_vs.VA = FindPV[i].VA; } }

                    }

                }
                if (Num_pq != 0)
                {
                    for (int i = 0; i < num_pq; i++)
                    {
                        // FindPQ[i].VA = FindPQ[i].VA + DVa[DX_counter];
                        // DX_counter++;
                        busDataWrapperList.Find(bus => bus.Equals(FindPQ[i])).VA = FindPQ[i].VA + DVa[DX_counter];
                        DX_counter++;
                        //foreach (BusDataWrapper bus_vs in busDataWrapperList) { if (bus_vs.bus_type.Equals(3)) { bus_vs.VA = FindPQ[i].VA; } }

                    }
                }

                // Update Voltage
                for (int i = 0; i < nb; i++)
                {

                    V[i] = busDataWrapperList[i].VM * MathNet.Numerics.ComplexExtensions.Exp(new System.Numerics.Complex(0, busDataWrapperList[i].VA));

                }


                //  evalute mismatch

                mis = (V.PointwiseMultiply((Ybus * V).Conjugate()) - Sbus) / Vm_abs;

                int PVPointer = 0;
                for (int i = 0; i < nb; i++)
                {
                    if (busDataWrapperList[i].bus_type.Equals(2))
                    {

                        var test = mis[i].Real;
                        Ppvreal[PVPointer] = (test);
                        PVPointer++;
                    }


                }
                PVPointer = 0;
                for (int i = 0; i < nb; i++)
                {
                    if (busDataWrapperList[i].bus_type.Equals(1))
                    {
                        var test = mis[i].Real;
                        Ppqreal[PVPointer] = (test);

                        PVPointer++;
                    }

                }
                for (int i = 0; i < P_PVPQ_vector.Count; i++)
                {
                    if (i < Ppvreal.Count)
                    {
                        P_PVPQ_vector[i] = Ppqreal[i];
                    }
                    else if (i < Ppvreal.Count + Ppqreal.Count)
                    {
                        P_PVPQ_vector[i] = Ppqreal[i - Ppvreal.Count];
                    }

                }
                /*List<double> New_P_pvpqreal =new List<double>();
                New_P_pvpqreal.AddRange(Ppvreal.Concat(Ppqreal));*/


                int PQPointer = 0;

                for (int i = 0; i < nb; i++)
                {
                    if (busDataWrapperList[i].bus_type.Equals(1))
                    {
                        var test = mis[i].Imaginary;
                        Q_PQ_vector[PQPointer] = (test); ;

                        PQPointer++;
                    }

                }

                // convert list to vector P_PVPQ

                /*for (int i = 0; i < P_pvpqreal.Count; i++)
                {
                    var test = New_P_pvpqreal[i];
                    P_PVPQ_vector[i] = test;
                  //  PVPointer_vector++;
                }*/




                // convert list to vector Q_PQ

                /*     for (int i = 0; i < Qpqimg.Count; i++)
                     {
                         var test = Qpqimg[i];
                         Q_PQ_vector[i] = test;
                        // PVPointer_vector++;
                     }*/

                //

                NormP = P_PVPQ_vector.InfinityNorm();
                NormQ = Q_PQ_vector.InfinityNorm();


                if (VERBOSE > 1)
                {
                    Console.WriteLine(" index of iterator " + index_of_iterator + " Normalaize " + NormP + NormQ);
                }
                if (NormP < tol_ && NormQ < tol_)
                {
                    converged = true;
                    if (VERBOSE > 1)
                    {
                        Console.WriteLine(" Newton's method power flow converged in!");
                    }
                    break;

                }


                //   -----  do Q iteration, update Vm  -----


                var DVm = -Bpp_solvrt.Solve(Q_PQ_vector);

                int DQ_counter = 0;

                if (Num_pq != 0)
                {
                    for (int i = 0; i < num_pq; i++)
                    {
                        FindPQ[i].VM = FindPQ[i].VM + DVm[DQ_counter];
                        DQ_counter++;
                        busDataWrapperList.Find(bus => bus.Equals(FindPQ[i])).VM = FindPQ[i].VM;


                    }
                }
                //
                for (int i = 0; i < nb; i++)
                {


                    VM[i].VM = Math.Abs(VM[i].VM);

                }


                for (int i = 0; i < VM.Count; i++)
                {
                    Vm_abs[i] = VM[i].VM;
                }


                //
                for (int i = 0; i < nb; i++)
                {

                    V[i] = busDataWrapperList[i].VM * MathNet.Numerics.ComplexExtensions.Exp(new System.Numerics.Complex(0, busDataWrapperList[i].VA));

                }

                //  evalute mismatch

                mis = (V.PointwiseMultiply((Ybus * V).Conjugate()) - Sbus) / Vm_abs;

                int PVPointer_for_Q = 0;
                for (int i = 0; i < nb; i++)
                {
                    if (busDataWrapperList[i].bus_type.Equals(2))
                    {

                        var test = mis[i].Real;
                        Ppvreal[PVPointer_for_Q] = (test);
                        PVPointer_for_Q++;
                    }


                }
                PVPointer_for_Q = 0;
                for (int i = 0; i < nb; i++)
                {
                    if (busDataWrapperList[i].bus_type.Equals(1))
                    {
                        var test = mis[i].Real;
                        Ppqreal[PVPointer_for_Q] = (test);

                        PVPointer_for_Q++;
                    }

                }

                List<double> New_Q_pvpqreal = new List<double>();
                New_Q_pvpqreal.AddRange(Ppvreal.Concat(Ppqreal));


                int PQPointer_for_Q = 0;

                for (int i = 0; i < nb; i++)
                {
                    if (busDataWrapperList[i].bus_type.Equals(1))
                    {
                        var test = mis[i].Imaginary;
                        Qpqimg[PQPointer_for_Q] = (test); ;

                        PQPointer_for_Q++;
                    }

                }

                for (int i = 0; i < P_pvpqreal.Count; i++)
                {
                    var test = New_Q_pvpqreal[i];
                    P_PVPQ_vector[i] = test;
                    //  PVPointer_vector++;
                }



                for (int i = 0; i < Qpqimg.Count; i++)
                {
                    var test = Qpqimg[i];
                    Q_PQ_vector[i] = test;
                    // PVPointer_vector++;
                }

                NormP = P_PVPQ_vector.InfinityNorm();
                NormQ = Q_PQ_vector.InfinityNorm();

                if (VERBOSE > 1)
                {
                    Console.WriteLine(" index of iterator " + index_of_iterator + " Normalaize " + NormP + NormQ);
                }
                if (NormP < tol_ && NormQ < tol_)
                {
                    converged = true;
                    if (VERBOSE > 1)
                    {
                        Console.WriteLine(" Newton's method power flow converged in!");
                    }
                    break;

                }
            }

            if (VERBOSE > 1)
                if (converged == false)
                {
                    Console.WriteLine(" Newton's method power did not converge in");
                }

            return (V, converged, index_of_iterator);
        }
    }
}
