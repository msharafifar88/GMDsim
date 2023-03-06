using BL.Calculation_Core.ItemWraper;
using MathNet.Numerics.LinearAlgebra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static persistent.enumeration.Calculation_RUNPF.Option;

namespace BL.Calculation_Core.Calculation_Class.Calculat_runpfmethod
{
    public class PF_Soln
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

        public PF_Soln(List<BusDataWrapper> busDatas, List<BranchDataWrapper> branchDatas, List<GeneratorDataWrapper> genDatas)
        {
            busDataWrapperList = busDatas;
            generatorWrapperList = genDatas;
            branchDataWrappersList = branchDatas;
            nb = busDatas.Count();
            ng = genDatas.Count();
            nl = branchDatas.Count();
         



        }

        public (List<BusDataWrapper>, List<GeneratorDataWrapper>, List<BranchDataWrapper>) pfsoln_cal(List<BusDataWrapper> busList, List<GeneratorDataWrapper> generatorList, List<BranchDataWrapper> branchList, Matrix<System.Numerics.Complex> ybus, Matrix<System.Numerics.Complex> yf, Matrix<System.Numerics.Complex> yt, Vector<System.Numerics.Complex> V, List<BusDataWrapper> bus_ref, List<BusDataWrapper> pv, List<BusDataWrapper> pq, double baseMVA)
        {

            //  initialize return values

            List<BusDataWrapper> Bus = new List<BusDataWrapper>();
            List<GeneratorDataWrapper> Generator = new List<GeneratorDataWrapper>();
            List<BranchDataWrapper> Breanch = new List<BranchDataWrapper>();
            Bus = busList;
            Generator = generatorList;
            Breanch = branchList;

            //Update Bus VM VA
            for (int i = 0; i < V.Count; i++)
            {

                busDataWrapperList[i].VM = System.Numerics.Complex.Abs(V[i]);
                busDataWrapperList[i].VA = Math.Atan(V[i].Imaginary / V[i].Real);
             //   Console.WriteLine(" Mag(pu) = " + busDataWrapperList[i].VM + " Ang(deg) = " + (busDataWrapperList[i].VA * 180) / Math.PI);

            }
            List<double> k = new List<double>();

            List<long> gen_busnum_temp = new List<long>();


            var Gen_on = generatorList.FindAll(g => g.Gen_status = true).ToList();


            for (int i = 0; i < busList.Count(); i++)
            {
                for (int j = 0; j < generatorList.Count(); j++)
                {
                    if (busList[i].bus_number == generatorList[j].Gen_bus_number && generatorList[j].Gen_status == true)
                    {
                        gen_busnum_temp.Add(generatorList[j].Gen_bus_number);


                    }

                }
            }
            // Vector<System.Numerics.Complex> temp_v = new Vector<System.Numerics.Complex>.Build.Dense(gen_busnum_temp.Count());
            Matrix<double> matrix_ = Matrix<double>.Build.Dense(gen_busnum_temp.Count, busList.Count);

            //List<System.Numerics.Complex>  = new List<System.Numerics.Complex>();
            Vector<System.Numerics.Complex> Sbus = Vector<System.Numerics.Complex>.Build.Dense(gen_busnum_temp.Count());
            Vector<System.Numerics.Complex> _temp = Vector<System.Numerics.Complex>.Build.Dense(gen_busnum_temp.Count());
            Vector<System.Numerics.Complex> V_temp = Vector<System.Numerics.Complex>.Build.Dense(gen_busnum_temp.Count());
            for (int i = 0; i < gen_busnum_temp.Count; i++)
            {
                for (int j = 0; j < busList.Count(); j++)
                {
                    if (gen_busnum_temp[i] == busList[j].bus_number)
                    {
                        var test = ybus.Row(j) * V;
                        _temp[i] = test;

                        V_temp[i] = V[j];
                        Sbus = V_temp.PointwiseMultiply(_temp.Conjugate());
                    }
                }

            }


            for (int j = 0; j < generatorList.Count(); j++)
            {
                generatorList[j].QG = 0;
                if (generatorList[j].Gen_status == true) {
                    for (int i = 0; i < busList.Count; i++)
                    {
                        if (generatorList[j].Gen_bus_number == busList[i].bus_number)
                        {

                            generatorList[j].QG = Sbus[j].Imaginary * baseMVA + busList[i].QD;

                        }
                    }
                }
            }

            if (Gen_on.Count() > 1)
            {

                ng = Gen_on.Count();
                var cg = Matrix<System.Numerics.Complex>.Build.Dense(nb, ng);
                int cgl = 0;
                foreach(GeneratorDataWrapper generatorData in generatorList)
                {
                    cg[generatorList.IndexOf(generatorData),cgl] = 1l;
                    cgl++;
                    //Console.WriteLine("sbus  " + generatorData.Gen_bus_number);
                }
/*
                for (int i = 0; i < ng; i++)
                {


                    cg[(int)generatorWrapperList[i].Gen_bus_number, i] = 1l;

                    Console.WriteLine("sbus  " + generatorWrapperList[i].Gen_bus_number);
                }*/

                var Ngg = Matrix<double>.Build.Dense(Gen_on.Count, 1);




                for (int j = 0; j < generatorList.Count(); j++)
                {
                    int count = 0;
                    for (int i = 0; i < generatorList.Count(); i++)
                    {
                        if (generatorList[i].Gen_bus_number == generatorList[j].Gen_bus_number && generatorList[j].Gen_status == true)
                        {
                            count++;

                        }

                    }
                    Ngg[j, 0] = (count);

                }

                var n = generatorList;
                for (int j = 0; j < generatorList.Count(); j++) {
                    if (generatorList[j].Gen_status == true)
                    {
                        generatorList[j].QG = generatorList[j].QG / Ngg[j, 0];
                    }
                }

                var Cmin = Matrix<double>.Build.Dense(Gen_on.Count, nb);
                var Cmax = Matrix<double>.Build.Dense(Gen_on.Count, nb);
                for (int j = 0; j < Gen_on.Count(); j++)
                {
                    for (int i = 0; i < busList.Count(); i++)
                    {
                        if (Gen_on[j].Gen_bus_number == busList[i].bus_number)
                        {
                            Cmin[j, i] = Gen_on[j].QMIN;
                            Cmax[j, i] = Gen_on[j].QMAX;
                        }


                    }
                }

               // Console.WriteLine("Cmin = " + Cmin + " \nCmax  " + Cmax);

                var Qg_min = Matrix<double>.Build.Dense(busList.Count, 1);
                var Qg_max = Matrix<double>.Build.Dense(busList.Count, 1);
                Vector<double> QG_min_vec = Vector<double>.Build.Dense(nb);
                Vector<double> QG_max_vec = Vector<double>.Build.Dense(nb);

                for (int i = 0; i < busList.Count(); i++)
                {
                    double count_min = 0;
                    double count_max = 0;
                    for (int j = 0; j < Gen_on.Count(); j++)
                    {
                        if (busList[i].bus_number == Gen_on[j].Gen_bus_number && Gen_on[j].Gen_status == true)
                        {
                            count_min += Gen_on[j].QMIN;
                            count_max += Gen_on[j].QMAX;

                        }

                    }
                    Qg_min[i, 0] = count_min;
                    Qg_max[i, 0] = count_max;
                    QG_min_vec[i] = count_min;
                    QG_max_vec[i] = count_max;

                }
                var Cg_Treans = cg.Transpose().Real() * QG_min_vec;
                Vector<double> QG_vec = Vector<double>.Build.Dense(Gen_on.Count);
                for (int i = 0; i < Gen_on.Count; i++)
                {
                    QG_vec[i] = Gen_on[i].QG;


                }

                List<double> ig = new List<double>();
                foreach (GeneratorDataWrapper gen in Gen_on) {
                    if (cg.Transpose().Real() * QG_min_vec == cg.Transpose().Real() * QG_max_vec) { ig.Add(gen.Gen_bus_number); }

                }

                // Qg_save  ???
                var Qg_total = cg.Real() * QG_vec;


                Vector<double> temp1 = Vector<double>.Build.Dense(busList.Count);
                for (int i = 0; i < busList.Count; i++)
                {


                    temp1[i] = ((Qg_total[i] - QG_min_vec[i]) / (QG_max_vec[i] - QG_min_vec[i] + 2.220446049250313e-16));
                   // var part1 = (cg.Real() * temp[i]);
                    
                   
                   
                   
                    /*var part2 = Gen_on[i].QMAX - Gen_on[i].QMIN;


                    var part3 = part1 * part2;
                    Gen_on[i].QG = Gen_on[i].QMIN + part3;
                  
                    Console.WriteLine("Testtttt    =  "     +Gen_on[i].QG);*/
                }
                var temp = cg.Transpose().Real() * temp1;

                for (int i = 0; i < Gen_on.Count; i++)
                {
                    var part2 = Gen_on[i].QMAX - Gen_on[i].QMIN;
                    Gen_on[i].QG = Gen_on[i].QMIN + (temp[i] * (Gen_on[i].QMAX - Gen_on[i].QMIN));
                }
               // Console.WriteLine(Qg_max + "\n" + Qg_min);
                var aa = Cmin;
            }


            List<GeneratorDataWrapper> gen_ref = new List<GeneratorDataWrapper>();


            for (int i = 0; i < Gen_on.Count(); i++)
            {
                for (int j = 0; j < bus_ref.Count(); j++)

                {

                    if (Gen_on[i].Gen_bus_number == bus_ref[j].bus_number && Gen_on[i].Gen_status == true)
                    {
                        gen_ref.Add(Gen_on[i]);
                        Gen_on[0].PG = Sbus[0].Real * baseMVA + bus_ref[j].PD;

                    }
                    
                   
                        
                }
               
            }
            if (gen_ref.Count() > 1)
            {
                for (int m = 1; m < gen_ref.Count(); m++)
                {
                    gen_ref[0].PG = gen_ref[0].PG - gen_ref[m].PG;
                }
            }

            {
                
            }

            List<BranchDataWrapper> B_out = new List<BranchDataWrapper>();
                B_out = branchList.FindAll(b => b.INSERVIcE = false).ToList();
                List<BranchDataWrapper> B_On = new List<BranchDataWrapper>();
                B_On = branchList.FindAll(b => b.INSERVIcE = true).ToList();
                /*
                 Sf = V[ branch[br, F_BUS].astype(int) ] * conj(Yf[br, :] * V) * baseMVA
                ## complex power injected at "to" bus
                 St = V[ branch[br, T_BUS].astype(int) ] * conj(Yt[br, :] * V) * baseMVA
                branch[ ix_(br, [PF, QF, PT, QT]) ] = c_[Sf.real, Sf.imag, St.real, St.imag]
                branch[ ix_(out, [PF, QF, PT, QT]) ] = zeros((len(out), 4))
                 */
                var Sf = Vector<System.Numerics.Complex>.Build.Dense(B_On.Count);
                var St = Vector<System.Numerics.Complex>.Build.Dense(B_On.Count);
                var SOut = Vector<System.Numerics.Complex>.Build.Dense(B_out.Count) ;
                Vector<System.Numerics.Complex> SF_V = Vector<System.Numerics.Complex>.Build.Dense(B_On.Count);
                Vector<System.Numerics.Complex> ST_V = Vector<System.Numerics.Complex>.Build.Dense(B_On.Count);
                List<long> Bfbus = new List<long>();
                foreach (BranchDataWrapper branchData in B_On)
                {
                /*Bfbus.Add(B_On[i].F_Bus);
                busList.IndexOf()*/

                busList.IndexOf(busList.Find(wrapper => wrapper.bus_number.Equals(branchData.F_Bus)));
                SF_V[B_On.IndexOf(branchData)] = V[busList.IndexOf(busList.Find(wrapper => wrapper.bus_number.Equals(branchData.F_Bus)))];
                ST_V[B_On.IndexOf(branchData)] = V[busList.IndexOf(busList.Find(wrapper => wrapper.bus_number.Equals(branchData.T_Bus)))];

                }

        /*    for (int i = 0; i < B_On.Count; i++)
            {
                *//*Bfbus.Add(B_On[i].F_Bus);
                busList.IndexOf()*//*
                
                
                SF_V[i] = V[(int)B_On[i].F_Bus];
                ST_V[i] = V[(int)B_On[i].T_Bus];

            }*/
            Sf = SF_V.PointwiseMultiply((yf.Conjugate() * V.Conjugate())) * baseMVA;
                 St = ST_V.PointwiseMultiply((yt.Conjugate() * V.Conjugate())) * baseMVA;
                SOut = SOut * 0;
                foreach (BranchDataWrapper branch in branchList)
                {
                    //PF, QF, PT, QT    Sf.real, Sf.imag, St.real, St.imag
                    if (branch.INSERVIcE == true)
                    {
                        branch.PF = Sf[(int)B_On.IndexOf(B_On.First(b => b.Equals(branch)))].Real;
                        branch.QF = Sf[(int)B_On.IndexOf(B_On.First(b => b.Equals(branch)))].Imaginary;
                        branch.PT = St[(int)B_On.IndexOf(B_On.First(b => b.Equals(branch)))].Real;
                        branch.QT = St[(int)B_On.IndexOf(B_On.First(b => b.Equals(branch)))].Imaginary;
                    }
                    if (branch.INSERVIcE == false)
                    {
                        branch.PF = 0;
                        branch.QF =0;
                        branch.PT = 0;
                        branch.QT = 0;
                    }
                }
                var aaa = branchList;

                var aaaa = 9;
                /*if (B_On.Count() != branchList.Count) {


                    for (int j = 0; j < branchList.Count; j++)
                    {
                        if (B_On[i].F_Bus == branchList[j].F_Bus && branchList[j].INSERVIcE == true) {
                            V_on[i] = V[j];
                            YF_on[i,j] = yf[i,j];
                            YT_on[i,j] = yt[i,j];

                        }
                    }
                }*/


            
        
                var a = 0;
            return (Bus, Generator, Breanch);
           
        }
   
        
    }
}
