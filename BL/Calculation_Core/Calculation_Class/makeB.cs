using BL.Calculation_Core.ItemWraper;
using MathNet.Numerics.LinearAlgebra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Calculation_Core.Calculation_Class
{
    public class MakeB
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
        int nl = 0;       // number of lines
        int alg_ = 0;
        int baseMVA_ = 0;
        public MakeB(int baseMVA,List<BusDataWrapper> busDatas, List<BranchDataWrapper> branchDatas, int alg)
        {
            busDataWrapperList = busDatas;
            branchDataWrappersList = branchDatas;
      
            nb = busDatas.Count();
            nl = branchDatas.Count();
            alg_ = alg;
            baseMVA_ = baseMVA;

        }
        public (Matrix<double>, Matrix<double>) Cal_MakeB()
        {
            Matrix<double> Bp = Matrix<double>.Build.Dense(nl, nb);
            Matrix<double> Bpp = Matrix<double>.Build.Dense(nl, nb);
           
            //-----  form Bp (B prime)  -----
            List<BusDataWrapper> temp_bus = new List<BusDataWrapper>();

            foreach (BusDataWrapper busData in busDataWrapperList)
            {
                BusDataWrapper bus = new BusDataWrapper(busData);
                temp_bus.Add(bus);
            }
            branchDataWrappersList[0].GetHashCode();
            List<BranchDataWrapper> temp_Branch = new List<BranchDataWrapper>();
            foreach(BranchDataWrapper branchData in branchDataWrappersList)
            {
                BranchDataWrapper branch = new BranchDataWrapper(branchData);
                temp_Branch.Add(branch);
            }
            temp_Branch[0].GetHashCode();
            List<BranchDataWrapper> temp_Branch_Bpp = new List<BranchDataWrapper>();
            foreach (BranchDataWrapper branchData in branchDataWrappersList)
            {
                BranchDataWrapper branch = new BranchDataWrapper(branchData);
                temp_Branch_Bpp.Add(branch);
            }
           
            temp_Branch_Bpp[0].GetHashCode();

            for (int i = 0; i < nb; i++)
            {
                temp_bus[i].BS = 0;
            }

            for (int i = 0; i < nl; i++)
            {
                temp_Branch[i].BR_B = 0;
                temp_Branch[i].TAP = 1;
            }


            if (alg_ == 2)
            {
                for (int i = 0; i < nl; i++)
                {
                    temp_Branch[i].BR_R = 0;

                }
            }
            MakeYbus makeYbus_Bp = new MakeYbus(baseMVA_, temp_bus, temp_Branch);
            var (Ybus_bp, Yf_bp, Yt_bp) = makeYbus_Bp.Cal_MakeYbus();
            Bp = -1 * Ybus_bp.Imaginary();

            //-----  form Bpp (B double prime)  -----
            
            for (int i = 0; i < nl; i++)
            {
                temp_Branch_Bpp[i].degrees = 0;

            }
            if (alg_ == 3)
            {
                for (int i = 0; i < nl; i++)
                {
                    temp_Branch_Bpp[i].BR_R = 0;

                }
            }
            MakeYbus makeYbus_Bpp = new MakeYbus(baseMVA_, busDataWrapperList, temp_Branch_Bpp);
            var (Ybus_Bpp, Yf_Bpp, Yt_Bpp) = makeYbus_Bpp.Cal_MakeYbus();
            Bpp = -1 * Ybus_Bpp.Imaginary();

            return (Bp, Bpp);
        }

        public List<BranchDataWrapper> Clone(List<BranchDataWrapper> branchDatas)
        {
            // Create a new list object
            List<BranchDataWrapper> temp = new List<BranchDataWrapper>();

            // Copy private data from this to clone
            temp = branchDatas;

            // Return the new list object containing the copied data
            return temp;
        }
    }
}
