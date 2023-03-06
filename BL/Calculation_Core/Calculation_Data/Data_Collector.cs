using BL.Calculation_Core.ItemWraper;
using BL.Calculation_Core.Transform_Function.Sample_Data;
using network;
using persistent;
using persistent.enumeration;
using persistent.network;
using persistent.network.bus_entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Calculation_Core.Calculation_Data
{
    public class Data_Collector
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
        List<vect_fit_DataWrapper> vect_Fit_DataWrappers = new List<vect_fit_DataWrapper>();

        TypeOfInput typofinput;
        public Data_Collector(Case cases , TypeOfInput typeinput )
        {

            this.typofinput = typeinput;
            findAllBusData(cases);
            findAllGenData(cases);
            findAllBranchData(cases);
            findAllVectorData();
        }
        CBL cBL = new CBL();
        LcBL lcBL = new LcBL();
        LBL lBL = new LBL();
        public void findAllBusData(Case cases)
        {
            List<Bus> buslist = busBL.loadAll(cases);
            List<Loads> loadlist = loadBL.loadAll(cases);
            List<Generator> generatorList = generatorBL.LoadAll(cases);
            foreach (Bus b in buslist)
            {
                BusDataWrapper busDataWrapper = new BusDataWrapper();
                if (typofinput.Equals(TypeOfInput.Local))
                {

                   

                    busDataWrapper.bus_number = b.BusNumber ;
                    if (b.Status == false || b.Bus_Type.Equals(Bus_type.Isolated))
                    {
                        busDataWrapper.bus_type = 4;

                    }
                    else if (b.Status == true && b.slack == true || b.Bus_Type.Equals(Bus_type.Ref))
                    {
                        busDataWrapper.bus_type = 3;

                    }
                    else if (b.Status == true && b.slack == false)
                    {
                        if (0 < generatorBL.findGeneratorHasAVRByBus(cases, b).Count || b.Bus_Type.Equals(Bus_type.PV))
                        {
                            busDataWrapper.bus_type = 2;
                        }
                        else
                        {
                            busDataWrapper.bus_type = 1;
                        }
                    }
                    busDataWrapper.PD = getPDvalue(cases, b);
                    busDataWrapper.QD = getQDvalue(cases, b);

                    //       busDataWrapper.area = b.area.Number;
                    busDataWrapper.VM = b.Voltagemagnitude;
                    busDataWrapper.VA = b.angle;
                    busDataWrapper.Base_KV = b.nominalVoltage;
                    busDataWrapper.VMAX = b.NominalVmax;
                    busDataWrapper.VMIN = b.NominalVmin;
                    busDataWrapper.BS = b.ShuntB_pu;
                    busDataWrapper.GS = b.ShuntG_pu;

                    //      busDataWrapper.ZONE = (int)b.areaLong;

                    busDataWrapperList.Add(busDataWrapper);
                   // Console.WriteLine(busDataWrapper);
                }
                else if (typofinput.Equals(TypeOfInput.Matlab))
                {
                    busDataWrapper.bus_number = b.BusNumber - 1;

                    if (b.Status == false || b.Bus_Type.Equals(Bus_type.Isolated))
                    {
                        busDataWrapper.bus_type = 4;

                    }
                    else if (b.Status == true && b.slack == true || b.Bus_Type.Equals(Bus_type.Ref))
                    {
                        busDataWrapper.bus_type = 3;

                    }
                    else if (b.Status == true && b.slack == false)
                    {
                        if (0 < generatorBL.findGeneratorHasAVRByBus(cases, b).Count || b.Bus_Type.Equals(Bus_type.PV))
                        {
                            busDataWrapper.bus_type = 2;
                        }
                        else
                        {
                            busDataWrapper.bus_type = 1;
                        }
                    }

                    busDataWrapper.PD = b.PD;
                    busDataWrapper.QD = b.QD;
                    busDataWrapper.VM = b.Voltagemagnitude;
                    busDataWrapper.VA = b.angle;
                    busDataWrapper.Base_KV = b.nominalVoltage;
                    busDataWrapper.VMAX = b.NominalVmax;
                    busDataWrapper.VMIN = b.NominalVmin;
                    busDataWrapper.BS = b.ShuntB_pu;
                    busDataWrapper.GS = b.ShuntG_pu;
                    busDataWrapper.area = b.areaLong;
                    busDataWrapper.ZONE = (int)b.ZoneLong;

                    busDataWrapperList.Add(busDataWrapper);
                   // Console.WriteLine(busDataWrapper);
                }
               

             


            }

            Utils.SetupBusDataMatrix(busDataWrapperList);

        }

        public List<BusDataWrapper> GetBusDataWrappers()
        {
            return busDataWrapperList;
        }

        public List<BranchDataWrapper> GetBranchDataWrappers()
        {
            return branchDataWrappersList;

        }

        public List<GeneratorDataWrapper> GetGeneratorDataWrappers()
        {
            return generatorWrapperList;
        }
        public double getPDvalue( Case cases, Bus b)
        {
            Double value = 0d;
            foreach (Loads load in loadBL.findLoadByBus(cases, b))
            {
                value = value + load.loadinformation.P_Power;
            }
            return value;
           
        }
        public double getQDvalue(Case cases, Bus b)
        {
            Double value = 0d;
            foreach (Loads load in loadBL.findLoadByBus(cases, b))
            {
                value = value + load.loadinformation.Q_Power;
            }

            return value;
        }

        public void findAllGenData(Case cases)
        {
            List<Bus> buslist = busBL.loadAll(cases);
            List<Loads> loadlist = loadBL.loadAll(cases);
            List<Generator> generatorList = generatorBL.LoadAll(cases);
            foreach (Generator g in generatorList)
            {

                GeneratorDataWrapper geneDataWrapper = new GeneratorDataWrapper();
                if (typofinput.Equals(TypeOfInput.Local))
                {
                    geneDataWrapper.Gen_bus_number = g.Bus.BusNumber;
                    geneDataWrapper.PG = getPGvalue(cases, g);
                    geneDataWrapper.QG = getQGvalue(cases, g);
                    if (g.powerControl.availableAVR == true)
                    {
                        geneDataWrapper.VG = g.powerControl.setpoint;

                    }
                    else
                    {
                        geneDataWrapper.VG = 1;
                    }
                    geneDataWrapper.QMAX = g.voltageControl.MaxMvars;
                    geneDataWrapper.QMIN = g.voltageControl.MinMvars;


                    geneDataWrapper.MBASE = g.Generator_MVA_BASE;

                    if (g.Inservice == true)
                    {
                        geneDataWrapper.Gen_status = true;
                    }
                    else if (g.Inservice == false) geneDataWrapper.Gen_status = false;

                    geneDataWrapper.PC2 = geneDataWrapper.PMAX = g.powerControl.maxOut;

                    geneDataWrapper.PC1 = geneDataWrapper.PMIN = g.powerControl.minOut;

                    geneDataWrapper.QC1MAX = geneDataWrapper.QC2MAX = g.voltageControl.MaxMvars;
                    geneDataWrapper.QC1MIN = geneDataWrapper.QC2MIN = g.voltageControl.MinMvars;

                    generatorWrapperList.Add(geneDataWrapper);

                  //  Console.WriteLine("Local "+geneDataWrapper);
                }
                else if(typofinput.Equals(TypeOfInput.Matlab))
                {
                    geneDataWrapper.Gen_bus_number = (int)g.Bus.BusNumber  ;
                    geneDataWrapper.PG = g.powerControl.outPut;
                    geneDataWrapper.QG = g.voltageControl.MvarOutput;
                    geneDataWrapper.VG = g.powerControl.setpoint;

                    geneDataWrapper.QMAX = g.voltageControl.MaxMvars;
                    geneDataWrapper.QMIN = g.voltageControl.MinMvars;


                    geneDataWrapper.MBASE = g.Generator_MVA_BASE;

                    if (g.Inservice == true)
                    {
                        geneDataWrapper.Gen_status = true;
                    }
                    else if (g.Inservice == false) geneDataWrapper.Gen_status = false;

                    geneDataWrapper.PMAX = g.powerControl.maxOut;
                    //geneDataWrapper.PC2 = 
                   //geneDataWrapper.PC1 = 
                    geneDataWrapper.PMIN = g.powerControl.minOut;

                   //geneDataWrapper.QC1MAX = geneDataWrapper.QC2MAX = g.voltageControl.MaxMvars;
                   // geneDataWrapper.QC1MIN = geneDataWrapper.QC2MIN = g.voltageControl.MinMvars;

                    generatorWrapperList.Add(geneDataWrapper);

                   // Console.WriteLine(geneDataWrapper);

                }
            }

            generatorWrapperList.Count();
        }

        public double getPGvalue(Case cases, Generator g)
        {
            Double value = 0d;
            foreach (Generator gen in generatorBL.LoadAll(cases))
            {
                if (g.Bus.Equals(gen.Bus)) {
                    value = value + gen.powerControl.outPut;
                }
               
            }
            return value;

        }

        public double getQGvalue(Case cases, Generator g)
        {
            Double value = 0d;
            foreach (Generator gen in generatorBL.LoadAll(cases))
            {
                if (g.Bus.Equals(gen.Bus))
                {
                    value = value + gen.voltageControl.MvarOutput;
                }
            }

            return value;
        }


        
        public void findAllBranchData(Case cases)
        {
            List<Bus> buslist = busBL.loadAll(cases);
            List<C2WTransformer> w2TransformersList = c2WTransformerBL.loadAll(cases);
            List<C3WTransformer> w3TransformerList = c3wTransformerBL.loadAll(cases);
            List<Single3phaseLine> single3PhaseLines = single3PhaseLineBL.loadAll(cases);
            List<DoubleCircuitLine> doubleCircuitLines = doubleCircuitLineBL.loadAll(cases);
            List<MultiPhaseLine> multiPhaseLines = multiPhaseLineBL.loadAll(cases);

            foreach ( C2WTransformer c2W in w2TransformersList)
            {

                BranchDataWrapper br = new BranchDataWrapper();
                br.F_Bus = c2W.PrimaryBUS.BusNumber -1;
                br.T_Bus = c2W.SecondaryBUS.BusNumber -1;
                br.BR_R = c2W.transformer_pu.R1_2_pu;
                br.BR_X = c2W.transformer_pu.X1_2_pu;
                br.BR_B = (c2W.impedances.Magnetization_Susceptance);
                br.RATE_A = c2W.mvalimits.PrimaryNominal;
                br.RATE_B = c2W.mvalimits.PrimarySummer;
                br.RATE_C = c2W.mvalimits.PrimarySummerEmergancy;
                br.TAP = c2W.ltccontrol.FIXPrimNominalTurnRateHV;
                br.number = c2W.number;
                //br.degrees = c2W.
                br.INSERVIcE = c2W.Inservice;
                branchDataWrappersList.Add(br);
            }
            foreach (C3WTransformer c3W in w3TransformerList)
            {

                //winding 1st be 2nd
                BranchDataWrapper br_1to2 = new BranchDataWrapper();
                br_1to2.F_Bus = c3W.PrimaryBUS.BusNumber -1;
                br_1to2.T_Bus = c3W.SecondaryBUS.BusNumber -1;
                br_1to2.BR_R = c3W.transformer_pu.R1_2_pu;
                br_1to2.BR_X = c3W.transformer_pu.X1_2_pu;
                br_1to2.BR_B = (c3W.impedances.Magnetization_Susceptance);
                br_1to2.RATE_A = c3W.mvalimits.PrimaryNominal;
                if (c3W.mvalimits.PrimarySummer != 0)
                {
                    br_1to2.RATE_B = c3W.mvalimits.PrimarySummer; // c3W.mvalimits.PrimaryWinter;
                }
                else { br_1to2.RATE_B = c3W.mvalimits.PrimaryWinter; }

                if (c3W.mvalimits.PrimarySummerEmergancy != 0) { br_1to2.RATE_C = c3W.mvalimits.PrimarySummerEmergancy; }
                else { br_1to2.RATE_C = c3W.mvalimits.PrimaryWinterEmergancy; }
                br_1to2.TAP = c3W.ltccontrol.FIXPrimNominalTurnRateHV;
                //br_1to2.degrees = c3W.
                br_1to2.INSERVIcE = c3W.Inservice;
                br_1to2.number = c3W.number;


                branchDataWrappersList.Add(br_1to2);


                // winding 1st to 3rd
                BranchDataWrapper br_1to3 = new BranchDataWrapper();
                br_1to3.F_Bus = c3W.PrimaryBUS.BusNumber -1;
                br_1to3.T_Bus = c3W.TertiaryBUS.BusNumber -1;
                br_1to3.BR_R = c3W.transformer_pu.R1_3_pu;
                br_1to3.BR_X = c3W.transformer_pu.X1_3_pu;
                br_1to3.BR_B = (c3W.impedances.Magnetization_Susceptance) / 100;
                br_1to3.RATE_A = c3W.mvalimits.PrimaryNominal;
                if (c3W.mvalimits.PrimarySummer != 0)
                {
                    br_1to3.RATE_B = c3W.mvalimits.PrimarySummer; // c3W.mvalimits.PrimaryWinter;
                }
                else { br_1to3.RATE_B = c3W.mvalimits.PrimaryWinter; }

                if (c3W.mvalimits.PrimarySummerEmergancy != 0) { br_1to3.RATE_C = c3W.mvalimits.PrimarySummerEmergancy; }
                else { br_1to3.RATE_C = c3W.mvalimits.PrimaryWinterEmergancy; }
                br_1to3.TAP = c3W.ltccontrol.FIXPrimNominalTurnRateHV;
                //br_1to3.degrees = c3W.
                br_1to3.INSERVIcE = c3W.Inservice;

                // winding 2st to 3rd
                BranchDataWrapper br_2to3 = new BranchDataWrapper();
                br_2to3.F_Bus = c3W.PrimaryBUS.BusNumber -1;
                br_2to3.T_Bus = c3W.TertiaryBUS.BusNumber -1;
                br_2to3.BR_R = c3W.transformer_pu.R2_3_pu;
                br_2to3.BR_X = c3W.transformer_pu.X2_3_pu;
                br_2to3.BR_B = (c3W.impedances.Magnetization_Susceptance) / 100;
                br_2to3.RATE_A = c3W.mvalimits.PrimaryNominal;

                if (c3W.mvalimits.PrimarySummer != 0) {
                br_2to3.RATE_B = c3W.mvalimits.PrimarySummer; // c3W.mvalimits.PrimaryWinter;
                }else {  br_2to3.RATE_B = c3W.mvalimits.PrimaryWinter; }

                if (c3W.mvalimits.PrimarySummerEmergancy != 0) { br_2to3.RATE_C = c3W.mvalimits.PrimarySummerEmergancy; }
                else{ br_2to3.RATE_C = c3W.mvalimits.PrimaryWinterEmergancy; }
                br_2to3.TAP = c3W.ltccontrol.FIXPrimNominalTurnRateHV;
                //br_2to3.degrees = c3W.
                br_2to3.INSERVIcE = c3W.Inservice;
                br_2to3.number = c3W.number;

                branchDataWrappersList.Add(br_2to3);


            }

            foreach (Single3phaseLine Singline in single3PhaseLines)
            {
                BranchDataWrapper br = new BranchDataWrapper();
                br.F_Bus = Singline.FromBus.BusNumber -1;
                br.T_Bus = Singline.ToBus.BusNumber -1;
                br.BR_R = Singline.Resistance;
                br.BR_X = Singline.Reactance;
                br.BR_B = Singline.Charging;
                br.RATE_A = Singline.GetLimitList(0);
                br.RATE_B = Singline.GetLimitList(1);
                br.RATE_C = Singline.GetLimitList(2);
                br.TAP = 0;
                //br.degrees = Singline.
                br.INSERVIcE = Singline.Inservice;
                br.ANGMAX = 0;
                br.ANGMIN = 0;
                br.number = Singline.Number;
                branchDataWrappersList.Add(br);

            }
            foreach (DoubleCircuitLine Doubleline in doubleCircuitLines)
            {
                BranchDataWrapper br = new BranchDataWrapper();
                br.F_Bus = Doubleline.FromBus.BusNumber -1;
                br.T_Bus = Doubleline.ToBus.BusNumber -1;
                br.BR_R = Doubleline.Resistance;
                br.BR_X = Doubleline.Reactance;
                br.BR_B = Doubleline.Charging;
                br.RATE_A = Doubleline.GetLimitList(0);
                br.RATE_B = Doubleline.GetLimitList(1);
                br.RATE_C = Doubleline.GetLimitList(2);
                br.TAP = 0;
                //br.degrees = Doubleline.
                br.INSERVIcE = Doubleline.Inservice;
                br.ANGMAX = 0;
                br.ANGMIN = 0;
                br.number = Doubleline.Number;

                branchDataWrappersList.Add(br);

            }
            foreach (MultiPhaseLine multileline in multiPhaseLines)
            {
                BranchDataWrapper br = new BranchDataWrapper();
                br.F_Bus = multileline.FromBus.BusNumber -1;
                br.T_Bus = multileline.ToBus.BusNumber -1;
                br.BR_R = multileline.Resistance;
                br.BR_X = multileline.Reactance;
                br.BR_B = multileline.Charging;
                br.RATE_A = multileline.GetLimitList(0);
                br.RATE_B = multileline.GetLimitList(1);
                br.RATE_C = multileline.GetLimitList(2);
                br.TAP = 0;
                //br.degrees = multileline.
                br.INSERVIcE = multileline.Inservice;
                br.ANGMAX = multileline.Angmax;
                br.ANGMIN = multileline.Angmin;
                br.number = multileline.Number;

                branchDataWrappersList.Add(br);
            }


            branchDataWrappersList = branchDataWrappersList.OrderBy(x => x.number).ToList();

            
           
        }

        public List<vect_fit_DataWrapper> findAllVectorData()
        {

            vect_Fit_DataWrappers=  SampleData1.createVec_fit_Wrapper();
            return vect_Fit_DataWrappers;


        }
        
        public static string address = AppDomain.CurrentDomain.BaseDirectory + @"\testfile.txt";
        public void printData(Stream strm)
        {
            string s = " ";
            foreach (BusDataWrapper b in busDataWrapperList)
            {
                 s = s+ b.ToString();

                

            }
            foreach (GeneratorDataWrapper g in generatorWrapperList)
            {
                s =s+ g.ToString();
              
            }
            foreach (BranchDataWrapper br in branchDataWrappersList)
            {

                s =s+ br.ToString();
             
            }
            
            FileStream fileStream = new FileStream(address, FileMode.Create, FileAccess.Write);
            StreamWriter streamWriter = new StreamWriter(strm);
            streamWriter.BaseStream.Seek(0, SeekOrigin.End);
            streamWriter.Write(s);
            streamWriter.Flush();
            //streamWriter.Close();

        }

    }


}
