using BL.Calculation_Core.ItemWraper;
using MathNet.Numerics.LinearAlgebra;
//using MathNet.Numerics.LinearAlgebra;
using System.Collections.Generic;
using System.Linq;

namespace BL.Calculation_Core.Calculation_Class
{
    public class MakeSbus
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
        int ng = 0;       // number of generator



        public MakeSbus(List<BusDataWrapper> busDatas, List<GeneratorDataWrapper> genDatas)
        {
            busDataWrapperList = busDatas;
            generatorWrapperList = genDatas;
            nb = busDatas.Count();
            ng = genDatas.Count();


            //  Console.WriteLine("number of ng  " + ng);
        }

        public Vector<System.Numerics.Complex> Cal_Sbus()
        {
            var cg = Matrix<System.Numerics.Complex>.Build.Dense(nb, ng);
            for (int i = 0; i < ng; i++)
            {

                GeneratorDataWrapper test = generatorWrapperList[i];
                BusDataWrapper b_F = busDataWrapperList.Find(bus => bus.bus_number.Equals(test.Gen_bus_number));
                cg[(int)busDataWrapperList.IndexOf(b_F), i] = 1l;

                //   Console.WriteLine("sbus  " + test.Gen_bus_number);
            }
            //var CG = cg.Inverse();
            //  Console.WriteLine("cg  ====  " + cg);
            //    Console.WriteLine("sbus  " + CG);
            //Sbusg = Cg * (gen(on, PG) + 1j* gen(on, QG)) / baseMVA;
            //

            //public Complex (double real, double imaginary);
            var sbusg = Vector<System.Numerics.Complex>.Build.Dense(ng);

            for (int i = 0; i < ng; i++)
            {


                GeneratorDataWrapper list = generatorWrapperList[i];
                if (list.Gen_status == true)
                {
                    /*bool test123 = list.Gen_status;
                    if (test123 == true)
                    {

                    }*/
                    float real = (float)list.PG;
                    float imaginary = (float)list.QG;
                    System.Numerics.Complex pg_ = new System.Numerics.Complex(real, imaginary);
                    sbusg[i] = pg_;
                }

            }
            // Console.WriteLine("sbusg ===  " + sbusg);

            sbusg = cg * sbusg;

            //  Console.WriteLine("sbusg = cg * sbusg ====   " + sbusg);
            /*
                        Console.WriteLine("sbusg +++++++++++++  " + sbusg);
            */
            var pdtest = Vector<System.Numerics.Complex>.Build.Dense(nb);
            var qdtest = Vector<System.Numerics.Complex>.Build.Dense(nb);

            var Sbusd = Vector<System.Numerics.Complex>.Build.Dense(nb);
            for (int i = 0; i < nb; i++)
            {

                BusDataWrapper list = busDataWrapperList[i];
                if (list.PD != null)
                {

                    float real = (float)list.PD;
                    float imaginary = (float)list.QD;
                    System.Numerics.Complex pd_ = new System.Numerics.Complex(real, imaginary);
                    pdtest[i] = pd_;
                    /* float QD_real = (float)list.QD;
                     float QD_imaginary = 1;
                     MathNet.Numerics.Complex32 qd_ = new MathNet.Numerics.Complex32(QD_real, QD_imaginary);
                     qdtest[i] = qd_;*/
                    Sbusd[i] = pd_;

                    // Console.WriteLine("Sbusd ========  " + Sbusd[i]);
                }
                //Console.WriteLine("Sbusd  ==   " + Sbusd);

                //Console.WriteLine("Sbusd ========  " + pdtest);
            }


            var Sbus = Vector<System.Numerics.Complex>.Build.Dense(nb);
            Sbus = sbusg / 100 - Sbusd / 100;
            // Console.WriteLine("resulte ========  " + Sbus);


            return Sbus;
        }


    }
}

