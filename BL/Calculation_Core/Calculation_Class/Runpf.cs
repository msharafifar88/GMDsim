
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Calculation_Core.ItemWraper;
using BL.Calculation_Core.Calculation_Data;
using persistent;
using BL.Calculation_Core.Calculation_Class;
using MathNet.Numerics.LinearAlgebra;
using persistent.enumeration.Calculation_RUNPF;
using static persistent.enumeration.Calculation_RUNPF.Option;
using BL.Calculation_Core.Calculation_Class.Calculat_runpfmethod;
using persistent.enumeration;

namespace BL.Calculation_Core
{
    public class Runpf
    {
        List<BusDataWrapper> busList;
        List<BranchDataWrapper> branchList;
        List<GeneratorDataWrapper> generatorList;
       // Option option = new Option();
        PF_Option pf_option = new PF_Option();
        CPF_OPTIONS cpf_OPTIONS = new CPF_OPTIONS();
        OPF_Option opf_Option = new OPF_Option();
        OUTPUT_OPTIONS output_OPTIONS =new OUTPUT_OPTIONS();
        GUROBI_OPTIONS gurobi_OPTIONS = new GUROBI_OPTIONS();
        PDIPM_OPTIONS pdipm_OPTION = new PDIPM_OPTIONS();
        
      
        bool dc;
        bool qlim;
        Verbose verbose;
        

        public Runpf(Case cases, TypeOfInput typeinput)
        {

           
        }
        public (List<BusDataWrapper>, List<GeneratorDataWrapper>, List<BranchDataWrapper>, Vector<System.Numerics.Complex>, bool, int) init(Case cases, TypeOfInput typeinput)
        {
            Data_Collector data_Collector = new Data_Collector(cases , typeinput);
            busList = data_Collector.GetBusDataWrappers();
            branchList = data_Collector.GetBranchDataWrappers();
            generatorList = data_Collector.GetGeneratorDataWrappers();

           /* busList = SampleData.createBusDataWrapper();
            branchList = SampleData.createBranchDataWrapper();
            generatorList = SampleData.createGeneratorDataWrapper();*/

            // double pi = 3.141592653589793;
            //double pi = 3.14159265358979323846;
            //   var p = Numpy.np.ones();
            //   var z = Numpy.np.zeros();
            //var shape = np.matmul();
            // var t = spsolve;

             verbose = output_OPTIONS.verbose;
             qlim = pf_option.enforce_q_lims;
             dc = pf_option.pf_dc;

            if (dc == true)
            {
                return DC(); }
            else{
                return notDC();
            }

        





        }

        public (List<BusDataWrapper>, List<GeneratorDataWrapper>, List<BranchDataWrapper>, Vector<System.Numerics.Complex>, bool, int) DC()
        {
            
            var baseMVA = 100;
            var nb = busList.Count();
            var ng = generatorList.Count();
            var nbranch = branchList.Count();

            List<BusDataWrapper> _Bus = new List<BusDataWrapper>();
            List<GeneratorDataWrapper> _Generator = new List<GeneratorDataWrapper>();
            List<BranchDataWrapper> _Branch = new List<BranchDataWrapper>();
            Vector<System.Numerics.Complex> V = Vector<System.Numerics.Complex>.Build.Dense(_Branch.Count);
            bool success = false;
            int index_of_iterator = 0;
            MackBdc mackBdc = new MackBdc(busList, branchList);
            MakeSbus makeSbus = new MakeSbus(busList, generatorList);
            double pi = 3.141592653589793;
            mackBdc.Cal_MakeBdc();
            makeSbus.Cal_Sbus();
            BusType busType = new BusType(busList);
            var (bus_ref, pv, pq) = busType.findBusBytype();
            Vector<double> Va0 = Vector<double>.Build.Dense(nb);


            // ## initial state
            for (int i = 0; i < busList.Count(); i++)
            {

                
                Va0[i] = busList[i].VA * (Math.PI   / 180);
            }
            DCpf dCpf = new DCpf(busList, generatorList);

            branchList.ForEach(branch => branch.QF = 0.0d);
            branchList.ForEach(branch => branch.QT = 0.0d);
            //  ## build B matrices and phase shift injections
            (Matrix<double> B, Matrix<double> Bbf, Vector<double> Pbusinj, Vector<double> PPfinj) = mackBdc.Cal_MakeBdc();



          /*  branchList.ForEach(branch =>
            {
                Console.WriteLine("number of ---------- Oghdeyi Baziiiii  " + branch.PF);
            });*/
            branchList.ForEach(branch =>
            {
                branch.PT = -branch.PF;
            });

            List<BusDataWrapper> busDatas = new List<BusDataWrapper>(bus_ref.Count());
            for (int i = 0; i < bus_ref.Count(); i++)
            {
                /*foreach (BusDataWrapper bus in gbus) {
                    if (bus_ref[i].Equals())
                    {
                buss refreanse gbas bayad begirim busi ke be gen vaslan
                    }
                }*/


            }
            Vector<float> busGS = Vector<float>.Build.Dense(busDatas.Count);
            busDatas.ForEach(bus => busGS.Add((float)bus.GS / baseMVA));
            Vector<float> PbusinjF = Vector<float>.Build.Dense(Pbusinj.Count);
            for (int i = 0; i < Pbusinj.Count; i++)
            {
                PbusinjF[i] = (float)Pbusinj[i];
            }


            var Pbus = makeSbus.Cal_Sbus().Real();// - PbusinjF - busGS ;
         

            Vector<double> Va = dCpf.cal_DCpf(pv, pq, Va0, B, Bbf, Pbus, PPfinj);

      /*      for (int i = 0; i < nb; i++)
            {
                Console.WriteLine(" Va ==================== " + Va[i]);
            }
            Console.WriteLine("++++++PBUS++++", Va);*/

            // ## update data matrices with solution

            Vector<double> cal_branch = Vector<double>.Build.Dense(nbranch);
              for (int i = 0; i < branchList.Count(); i++)
              {
                  Vector<double> m = Bbf.Multiply(Va);
                  branchList[i].PF = (m[i] + PPfinj[i]) * baseMVA;
                  branchList[i].PT = -branchList[i].PF;
              }
              for (int i = 0; i < busList.Count(); i++)
              {

                  
                  busList[i].VM = 1;
                  busList[i].VA = Va[i] * (Math.PI / 180);
              }

            /*
               ## update Pg for slack generator (1st gen at ref bus)
               ## (note: other gens at ref bus are accounted for in Pbus)
               ##      Pg = Pinj + Pload + Gs
               ##      newPg = oldPg + newPinj - oldPinj
            */
            List<GeneratorDataWrapper> Ref_gen = new List<GeneratorDataWrapper>();
            for (int i = 0; i < bus_ref.Count(); i++)
            {
                var gen = generatorList.FindAll(g => g.Gen_bus_number.Equals(bus_ref[i].bus_number)).ToList();
                Ref_gen.Add(gen[0]);

            }
            List<int> pointer_bus_refrence = new List<int>();
            busList.ForEach(b => {
                if (bus_ref.Contains(b))
                {
                    pointer_bus_refrence.Add(busList.IndexOf(b));
                }
            });
            var cal_B_ref = Matrix<double>.Build.Dense(bus_ref.Count, nb);

            foreach (int i in pointer_bus_refrence)
            {
                foreach (BusDataWrapper bus in busList)
                {
                    cal_B_ref[pointer_bus_refrence.IndexOf(i), busList.IndexOf(bus)] = B[i, (int)busList.IndexOf(bus)];

                }
            }


            /*    for (int i = 0; i < Ref_gen.Count(); i++)
                {
                    Ref_gen[i].PG = Ref_gen[i].PG + (B)

                }*/



            /*         var B_gen_ref = Matrix<double>.Build.Dense();


                         foreach (GeneratorDataWrapper gen in Ref_gen)
                     {
                         gen.PG + B(reff) * Va - Pbus(reff) * baseMVA;
                     }*/

            success = true;
            return (_Bus, _Generator, _Branch , V, success, index_of_iterator);

        }

        public (List<BusDataWrapper>,  List<GeneratorDataWrapper>, List<BranchDataWrapper>, Vector<System.Numerics.Complex>, bool, int) notDC()
        {
            var baseMVA = 100;
            var nb = busList.Count();
            var ng = generatorList.Count();
            var nbranch = branchList.Count();

            List<BusDataWrapper> _Bus = new List<BusDataWrapper>();
            List<GeneratorDataWrapper> _Generator = new List<GeneratorDataWrapper>();
            List<BranchDataWrapper> _Breanch = new List<BranchDataWrapper>();

            MackBdc mackBdc = new MackBdc(busList, branchList);
            MakeSbus makeSbus = new MakeSbus(busList, generatorList);
            
            mackBdc.Cal_MakeBdc();
            makeSbus.Cal_Sbus();
            BusType busType = new BusType(busList);
            var (bus_ref, pv, pq) = busType.findBusBytype();
            Vector<double> Va0 = Vector<double>.Build.Dense(nb);


            // ## initial state
            for (int i = 0; i < busList.Count(); i++)
            {
                double pi = 3.1415926535897931;
                Va0[i] = busList[i].VA * (Math.PI / 180);
            }
            DCpf dCpf = new DCpf(busList, generatorList);




            branchList.ForEach(branch => branch.QF = 0.0d);
            branchList.ForEach(branch => branch.QT = 0.0d);
            

            var alg = pf_option.pf_alg;
            string solver = "";
            Console.WriteLine((int)alg);
            if (verbose > 0)
            {
                if ((int)alg == 1)
                {
                    solver = "Newton";
                }
                else if  ((int)alg == 2){ 
                    solver = "fast-decoupled, XB"; }
                else if ((int)alg == 3){
                    solver = "fast-decoupled, BX"; }
                else if ((int)alg == 4){
                    solver = "Gauss-Seidel"; }
                else
                    solver = "unknown";

                Console.WriteLine("-- AC Power Flow ( "+ solver +" )");
            }

            //  initial state
            //  V0    = ones(bus.shape[0])            ## flat start

            Vector<System.Numerics.Complex> V0 = Vector<System.Numerics.Complex>.Build.Dense(nb);

    


            // ## initial state
            for (int i = 0; i < busList.Count(); i++)
            {
                
                V0[i] = (busList[i].VM) * System.Numerics.Complex.Exp(new System.Numerics.Complex(0, ((Math.PI / 180) * (busList[i].VA))));

               
            }
            
            Vector<double> vcb_pq = Vector<double>.Build.Dense(nb);
            for (int i = 0; i < busList.Count(); i++)
            {
                if (pq.Contains(busList[i]))
                {
                    vcb_pq[i] = 0;

                }
                else
                {
                    vcb_pq[i] = 1;
                }

               
            }
            Console.WriteLine("Vcb_pq = " + vcb_pq);


            ISet<double> k = new HashSet<double>();

            for (int i = 0; i < generatorList.Count(); i++)
            {
                for (int j = 0; j < busList.Count(); j++) {
                    if (pq.Contains(busList[j]))
                    {
                        k.Add( generatorList[i].Gen_bus_number);
                        
                    }

                }
            
            }
           // Console.WriteLine("K  = " + k);

           // Vector<System.Numerics.Complex> P = Vector<System.Numerics.Complex>.Build.Dense(ng);
            Vector<System.Numerics.Complex> V0_test = Vector<System.Numerics.Complex>.Build.Dense(ng);
            V0_test = V0.Clone();
          //  foreach(var v in V0) { V0_test = V0.Clone();  }
            for (int i = 0; i < generatorList.Count(); i++)
            {
                if (generatorList[i].Gen_status == true)
                {
                    for (int j = 0; j < busList.Count(); j++)
                    {
                        if (k.Contains(busList[j].bus_number))
                        {

                            //* System.Numerics.Complex Cal_v0 = new System.Numerics.Complex(Math.Cos((Math.PI / 180) * (busList[j].VA)), Math.Sin(Math.PI / 180) * (busList[j].VA));
                           //  Console.WriteLine("P [MW] real = " + Cal_v0.Real + " Q [MVAR] ima   = " + Cal_v0.Imaginary);
                            // System.Numerics.Complex test = System.Numerics.Complex.Exp(new System.Numerics.Complex(0, (Math.PI / 180) * (busList[j].VA)));


                            //V0[j]=(generatorList[i].VG) /  System.Numerics.Complex.Abs(V0[j]) * V0[j] ;

                            V0_test[j] = generatorList[i].VG / System.Numerics.Complex.Abs(V0_test[j]) * V0_test[j];
                           // Console.WriteLine("P [MW] real" + P_test[i].Real + "Q [MVAR] ima   = " + P_test[i].Imaginary);

                        }

                        //   Console.WriteLine(" P[i]   = " + P[i]);
                       // k.Add(generatorList[i].Gen_bus_number);

                    }

                   
                   
                    
                }
            }

           



            if (qlim)
            {
                List<double> varef0 = new List<double>();
                bus_ref.ForEach(bus => { varef0.Add(bus.VA); });


            }

            MakeYbus makeYbus = new MakeYbus(baseMVA, busList, branchList);
            var (Ybus, Yf, Yt) = makeYbus.Cal_MakeYbus();
            Vector<System.Numerics.Complex> V = Vector<System.Numerics.Complex>.Build.Dense(nb);
            bool success = false;
            int index_of_iterator = 0;
            bool repeat = true;
            while (repeat)
            {
                // p +j*q
                var Sbus = makeSbus.Cal_Sbus();
         
                var run_cal_method = pf_option.pf_alg;
                var Verbose = output_OPTIONS.verbose;

               
          
                FD_PF fd_PF = new FD_PF(busList, branchList, generatorList);
                alg = PF_ALG.Newton;

                if ((int)alg == 1)
                {
                    Newton_PF newton_PF = new Newton_PF(busList, branchList, generatorList);
                    (V, success, index_of_iterator) = newton_PF.Cal_Newton_PF(Ybus, Sbus, V0, bus_ref, pv, pq);
                    PF_Soln pF_Soln = new PF_Soln(busList, branchList, generatorList);
                    (_Bus, _Generator, _Breanch) =pF_Soln.pfsoln_cal(busList,generatorList,branchList, Ybus, Yf, Yt, V, bus_ref, pv, pq,baseMVA);
                   
                }
                else if ((int)alg == 2 || (int)alg == 3)
                {
                    MakeB makeB = new MakeB(baseMVA, busList, branchList, (int)alg);

                    var (Bp, Bpp) = makeB.Cal_MakeB();

                    (V, success, index_of_iterator) = fd_PF.Cal_FD_PF(Ybus, Sbus, V0, Bp, Bpp, bus_ref, pv, pq);
                }

                else if ((int)alg == 4)
                {

                }
                else
                 

                    solver = "unknown";
                //here
                Console.WriteLine("-- AC Power Flow ( " + solver + " )");
                repeat = false;

            }

            Console.WriteLine("stop");
            return (_Bus, _Generator, _Breanch , V, success, index_of_iterator);

        }
         
       
    }
}