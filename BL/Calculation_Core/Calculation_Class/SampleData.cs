using BL.Calculation_Core.ItemWraper;
using System.Collections.Generic;

namespace BL.Calculation_Core.Calculation_Class
{
    public class SampleData
    {
        // bus_i type Pd Qd Gs Bs area Vm Va baseKV zone Vmax Vmin
        // ppc["bus"] = array([
        //    [0, 3, 50,  30.99,  0, 0, 1, 1, 0, 230, 1, 1.1, 0.9],
        //    [1, 1, 170, 105.35, 0, 0, 1, 1, 0, 230, 1, 1.1, 0.9],
        //    [2, 1, 200, 123.94, 0, 0, 1, 1, 0, 230, 1, 1.1, 0.9],
        //    [3, 2, 80,  49.58,  0, 0, 1, 1, 0, 230, 1, 1.1, 0.9]
        // ]) 


        public static List<BusDataWrapper> createBusDataWrapper()
        {
            List<BusDataWrapper> busDataWrappers = new List<BusDataWrapper>();
            BusDataWrapper testCase1 = new BusDataWrapper(); testCase1.bus_number = 0; testCase1.bus_type = 3;
            testCase1.PD = 50; testCase1.QD = 30.99; testCase1.GS = 0; testCase1.BS = 0; testCase1.area = 1;
            testCase1.VM = 1; testCase1.VA = 0; testCase1.Base_KV = 230; testCase1.ZONE = 1;
            testCase1.VMAX = 1.1; testCase1.VMIN = 0.9;
            busDataWrappers.Add(testCase1);
            BusDataWrapper testCase2 = new BusDataWrapper(); testCase2.bus_number = 1; testCase2.bus_type = 1;
            testCase2.PD = 170; testCase2.QD = 105.35; testCase2.GS = 0; testCase2.BS = 0; testCase2.area = 1;
            testCase2.VM = 1; testCase2.VA = 0; testCase2.Base_KV = 230; testCase2.ZONE = 1;
            testCase2.VMAX = 1.1; testCase2.VMIN = 0.9;
            busDataWrappers.Add(testCase2);
            BusDataWrapper testCase3 = new BusDataWrapper(); testCase3.bus_number = 2; testCase3.bus_type = 1;
            testCase3.PD = 200; testCase3.QD = 123.94; testCase3.GS = 0; testCase3.BS = 0; testCase3.area = 1;
            testCase3.VM = 1; testCase3.VA = 0; testCase3.Base_KV = 230; testCase3.ZONE = 1;
            testCase3.VMAX = 1.1; testCase3.VMIN = 0.9;
            busDataWrappers.Add(testCase3);
            BusDataWrapper testCase4 = new BusDataWrapper(); testCase4.bus_number = 3; testCase4.bus_type = 2;
            testCase4.PD = 80; testCase4.QD = 49.58; testCase4.GS = 0; testCase4.BS = 0; testCase4.area = 1;
            testCase4.VM = 1; testCase4.VA = 0; testCase4.Base_KV = 230; testCase4.ZONE = 1;
            testCase4.VMAX = 1.1; testCase4.VMIN = 0.9;
            busDataWrappers.Add(testCase4);

            return busDataWrappers;
        }

        public static List<GeneratorDataWrapper> createGeneratorDataWrapper()
        {
            List<GeneratorDataWrapper> generatorDataWrapper = new List<GeneratorDataWrapper>();
            GeneratorDataWrapper testCase1 = new GeneratorDataWrapper(); testCase1.Gen_bus_number = 3; testCase1.PG = 318;
            testCase1.QG = 0; testCase1.QMAX = 100; testCase1.QMIN = -100; testCase1.VG = 1.02f; testCase1.MBASE = 100;
            testCase1.Gen_status = true; testCase1.PMAX = 318; testCase1.PMIN = 0; testCase1.PC1 = 0;
            testCase1.PC2 = 0; testCase1.QC1MIN = 0; testCase1.QC1MAX = 0; testCase1.QC2MIN = 0; testCase1.QC2MAX = 0; testCase1.RAMP_AGC = 0;
            testCase1.RAMP10 = 0; testCase1.RAMP30 = 0; testCase1.RAMP_Q = 0; testCase1.APF = 0;
            generatorDataWrapper.Add(testCase1);

            GeneratorDataWrapper testCase2 = new GeneratorDataWrapper(); testCase2.Gen_bus_number = 0; testCase2.PG = 0;
            testCase2.QG = 0; testCase2.QMAX = 100; testCase2.QMIN = -100; testCase2.VG = 1f; testCase2.MBASE = 100;
            testCase2.Gen_status = true; testCase2.PMAX = 0; testCase2.PMIN = 0; testCase2.PC1 = 0;
            testCase2.PC2 = 0; testCase2.QC1MIN = 0; testCase2.QC1MAX = 0; testCase2.QC2MIN = 0; testCase2.QC2MAX = 0; testCase2.RAMP_AGC = 0;
            testCase2.RAMP10 = 0; testCase2.RAMP30 = 0; testCase2.RAMP_Q = 0; testCase2.APF = 0;
            generatorDataWrapper.Add(testCase2);

            return generatorDataWrapper;
        }

        public static List<BranchDataWrapper> createBranchDataWrapper()
        {
            List<BranchDataWrapper> branchDataWrapper = new List<BranchDataWrapper>();
            BranchDataWrapper testCase1 = new BranchDataWrapper(); testCase1.F_Bus = 0; testCase1.T_Bus = 1;
            testCase1.BR_R = 0.01008; testCase1.BR_X = 0.0504; testCase1.BR_B = 0.1025; testCase1.RATE_A = 250; testCase1.RATE_B = 250;
            testCase1.RATE_C = 250; testCase1.degrees = 0; testCase1.TAP = 0; testCase1.INSERVIcE = true;
            testCase1.ANGMIN = -360; testCase1.ANGMAX = 360;
            branchDataWrapper.Add(testCase1);


            BranchDataWrapper testCase2 = new BranchDataWrapper(); testCase2.F_Bus = 0; testCase2.T_Bus = 2;
            testCase2.BR_R = 0.00744; testCase2.BR_X = 0.0372; testCase2.BR_B = 0.0775; testCase2.RATE_A = 250; testCase2.RATE_B = 250;
            testCase2.RATE_C = 250; testCase2.degrees = 0; testCase2.TAP = 0; testCase2.INSERVIcE = true;
            testCase2.ANGMIN = -360; testCase2.ANGMAX = 360;
            branchDataWrapper.Add(testCase2);

            BranchDataWrapper testCase3 = new BranchDataWrapper(); testCase3.F_Bus = 1; testCase3.T_Bus = 3;
            testCase3.BR_R = 0.00744; testCase3.BR_X = 0.0372; testCase3.BR_B = 0.0775; testCase3.RATE_A = 250; testCase3.RATE_B = 250;
            testCase3.RATE_C = 250; testCase3.degrees = 0; testCase3.TAP = 0; testCase3.INSERVIcE = true;
            testCase3.ANGMIN = -360; testCase3.ANGMAX = 360;
            branchDataWrapper.Add(testCase3);

            BranchDataWrapper testCase4 = new BranchDataWrapper(); testCase4.F_Bus = 2; testCase4.T_Bus = 3;
            testCase4.BR_R = 0.01272; testCase4.BR_X = 0.0636; testCase4.BR_B = 0.1275; testCase4.RATE_A = 250; testCase4.RATE_B = 250;
            testCase4.RATE_C = 250; testCase4.degrees = 0; testCase4.TAP = 0; testCase4.INSERVIcE = true;
            testCase4.ANGMIN = -360; testCase4.ANGMAX = -360;
            branchDataWrapper.Add(testCase4);



            return branchDataWrapper;
        }
    }
}
