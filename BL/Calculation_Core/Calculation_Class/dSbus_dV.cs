using BL.Calculation_Core.ItemWraper;
using MathNet.Numerics.LinearAlgebra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Calculation_Core.Calculation_Class
{
    public class dSbus_dV
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


        public dSbus_dV(List<BusDataWrapper> busDatas, List<BranchDataWrapper> branchDatas, List<GeneratorDataWrapper> genDatas)
        {

            busDataWrapperList = busDatas;
            generatorWrapperList = genDatas;
            branchDataWrappersList = branchDatas;
            nb = busDatas.Count();
            ng = genDatas.Count();
            nl = branchDatas.Count();
        }
        public (Matrix<System.Numerics.Complex> , Matrix<System.Numerics.Complex>) Cal_Dsbus_dV(Matrix<System.Numerics.Complex> Ybus, Vector<System.Numerics.Complex> V)
        {
            var ib = V.Count();

            Matrix<System.Numerics.Complex> dS_dVm;
            Matrix<System.Numerics.Complex> dS_dVa;
            Matrix<System.Numerics.Complex> diagV;
            Matrix<System.Numerics.Complex> diagIbus;
            Matrix<System.Numerics.Complex> diagVnorm;
            if (true)
            {
                //var Ibus = Ybus * ( V);
                Vector<System.Numerics.Complex> Ibus = Vector<System.Numerics.Complex>.Build.Dense(V.Count); 
                for (int i =0; i < Ybus.RowCount;  i++)
                {
                    for(int j=0; j< Ybus.ColumnCount; j++)
                    {
                        Ibus[i] += Ybus[j, i] * V[j]   ;
                    }
                }
                var testttttt = Ibus; 
                diagV = Utils.createSparseMatirix(ib, ib, V);
               
              //  Console.WriteLine("diagV =  " + diagV);

                diagIbus = Utils.createSparseMatirix(ib, ib, Ibus);
                //Console.WriteLine("diagIbus =  " + diagIbus);
                var abs_v = V.PointwiseAbs();
                diagVnorm = Utils.createSparseMatirix(ib, ib, V / abs_v);
                //Console.WriteLine("diagVnorm =  " + diagVnorm);
            }
            else
            {

                /*var Ibus = Ybus * asmatrix(V).T

                  Matrix<System.Numerics.Complex> diagV = Matrix<System.Numerics.Complex>.Build(v))
                 diagIbus = asmatrix(diag(asarray(Ibus).flatten()))
                  diagVnorm = asmatrix(diag(V / abs(V)))*/

            }

            dS_dVm = diagV * (Ybus * diagVnorm).Conjugate() + diagIbus.Conjugate() * diagVnorm;
            dS_dVa = diagV * (diagIbus - Ybus * diagV).Conjugate();
            for (int i = 0; i < dS_dVa.RowCount; i++)
            {
                for (int j = 0; j < dS_dVa.ColumnCount; j++)
                {
                    dS_dVa[i, j] = new System.Numerics.Complex(-dS_dVa[i, j].Imaginary, dS_dVa[i, j].Real);
                }
            }
         /*   Console.WriteLine("dS_dVa =  " + dS_dVa);
            Console.WriteLine("dS_dVm =  " + dS_dVm);*/
            return (dS_dVm, dS_dVa);
        }

    }
}
