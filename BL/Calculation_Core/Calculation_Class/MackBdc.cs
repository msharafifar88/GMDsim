using BL.Calculation_Core.ItemWraper;
using Numpy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics;

using BL.Calculation_Core.SparseMatrixGMDC;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;

namespace BL.Calculation_Core.Calculation_Class
{
    public class MackBdc
    {

        /*
            """Builds the B matrices and phase shift injections for DC power flow.

    Returns the B matrices and phase shift injection vectors needed for a
    DC power flow.
    The bus real power injections are related to bus voltage angles by::
        P = Bbus * Va + PBusinj
    The real power flows at the from end the lines are related to the bus
    voltage angles by::
        Pf = Bf * Va + Pfinj
    Does appropriate conversions to p.u.

    @see: L{dcpf}

    @author: Carlos E. Murillo-Sanchez (PSERC Cornell & Universidad
    Autonoma de Manizales)
    @author: Ray Zimmerman (PSERC Cornell)
    """
        */

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
        int nb= 0;          //number of buses
        int nl= 0;       // number of lines

        public MackBdc(List<BusDataWrapper> busDatas,List<BranchDataWrapper> branchDatas)
        {
            busDataWrapperList = busDatas;
            branchDataWrappersList = branchDatas;
            nb = busDatas.Count();
            nl = branchDatas.Count();

            

        }
        public (Matrix<double>, Matrix<double>, Vector<double>, Vector<double>) Cal_MakeBdc()
        {

            // find 1/reactance
            List<double> bList = new List<double>();
            foreach (BranchDataWrapper branchData in branchDataWrappersList)
            {
                if (branchData.INSERVIcE)
                {
                    bList.Add((double)(1 / branchData.BR_X));
                    
                }


            }

            // chnage tab  ( it is 0 in line and it has number in transformer)
           // var t = np.ones(nl);
            List<double> tap = new List<double>();
            foreach (BranchDataWrapper branchDataWrapper in branchDataWrappersList)
            {
                if (branchDataWrapper.TAP == 0)
                {
                    branchDataWrapper.TAP = 1;
                    tap.Add((double)(branchDataWrapper.TAP));

                } else tap.Add((double)(branchDataWrapper.TAP));
            }

            //  bList = [int(b) / int(t) for b, t in zip(bList, tap)];
            for (int i = 0 ; i < bList.Count() ; i++)
            {
                bList[i] = bList[i] / tap[i];
                
            }
            List<double> BBlist = bList;
            List<long> f_bus = new List<long>();
            foreach (BranchDataWrapper branchData in branchDataWrappersList)
            {
                
                    bList.Add((long)branchData.F_Bus);
            }
            List<long> t_bus = new List<long>();
            foreach (BranchDataWrapper branchData in branchDataWrappersList)
            {

                bList.Add((long)branchData.T_Bus);
            }

            List<double> double_list = new List<double>(nl);
            // double_list = (List<double>)double_list.Concat<double>(double_list);

            var Cft_ = new SparseMatrix<double>(nl, nb); //, double[] diagonal));
            var CTF = Matrix<double>.Build.Dense(nl, nb);
            for (int i = 0; i < branchDataWrappersList.Count; i++)
            { 

                BranchDataWrapper test = branchDataWrappersList[i];
                BusDataWrapper b_F = busDataWrapperList.Find(bus => bus.bus_number.Equals(test.F_Bus));
                BusDataWrapper b_T = busDataWrapperList.Find(bus => bus.bus_number.Equals(test.T_Bus));



                CTF[i, (int)busDataWrapperList.IndexOf(b_F) ] = 1l;

                CTF[i, (int)busDataWrapperList.IndexOf(b_T)] = -1l;
                    
                    

            }
            
            

            var bf = Matrix<double>.Build.Dense(nl, nb);
            for (int i = 0; i < branchDataWrappersList.Count; i++)
            {

                BranchDataWrapper test = branchDataWrappersList[i];
                BusDataWrapper b_F = busDataWrapperList.Find(bus => bus.bus_number.Equals(test.F_Bus));
                BusDataWrapper b_T = busDataWrapperList.Find(bus => bus.bus_number.Equals(test.T_Bus));
                bf[i, (int)busDataWrapperList.IndexOf(b_F)]  = (double)(1 / test.BR_X);
                bf[i, (int)busDataWrapperList.IndexOf(b_T)]  = -(double)(1 / test.BR_X);

            }
          
            Matrix<double> Bbf = bf;

            // transpose matrix
            var tm = CTF.Transpose();
            //Console.WriteLine(tm);


            // build phase shift injection vectors
            //  Pfinj = b.* (-branch(:, SHIFT) * pi / 180);
            int count = branchDataWrappersList.Count;
            var Pfinj = Vector<double>.Build.Dense(count);
            for (int i = 0; i < branchDataWrappersList.Count; i++)
            {

                Pfinj[i] = bList[i]* ((branchDataWrappersList[i].degrees) * (Math.PI / 180));

            }
            //Console.WriteLine(Pfinj);
            Vector<double> PPfinj = Pfinj;
            Vector<double> Pbusinj = tm * Pfinj;


          //  Console.WriteLine(Pbusinj);

            // build Bf such that Bf * Va is the vector of real branch powers injected
            // at each branch's "from" bus
            // build Bbus

            Matrix<double> Bbus = tm * bf;

            //Console.WriteLine(" B_Bus"+Bbus);



            return (Bbus, Bbf, Pbusinj, PPfinj);

        }

    }
}
