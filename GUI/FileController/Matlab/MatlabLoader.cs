
using System;
using System.Collections.Generic;
using network;
using System.IO;
using System.Linq;
using areaandzone;
using persistent.power;
using FaultParameters = persistent.network.Generator.FaultParameters;
using persistent.network.bus_entity;
using persistent.network;
using persistent.network.Transformers;
using persistent.network.generator_entity;
using System.Globalization;
using BL.Calculation_Core;
using System.Windows;

namespace GUI.FileController.Matlab
{
    public class MatlabLoader
    {
        string[] lines;
        List<Bus> buses;
        List<Owner> owners;
        List<Zone> zones;
        List<Area> areas;
        List<Loads> loadList;
        List<MultiPhaseLine> lineBranches;
        List<Generator> generators;
        List<C2WTransformer> transformerBranches;
        int lineRow;

        public MatlabLoader(string filename) {
            lines = File.ReadAllLines(filename);
            if (filename.Contains(".mat"))
            {
               // var reader = new MatReader(filename);
            }

            // radImporterGridView.DataSource = createHeader(lines[0].Length);
            
        }

        public (List<Bus>, List<Generator>, List<MultiPhaseLine>, List<C2WTransformer>) LoadData()
        {
            try
            {
                buses = new List<Bus>();
                generators = new List<Generator>();
                lineBranches = new List<MultiPhaseLine>();
                transformerBranches = new List<C2WTransformer>();
                bool bus, load, generator, line, transformer, owner, zone, area, bus_name;
                bus = load = generator = line = transformer = owner = zone = area = false;
                lineRow = 0;
                foreach (string row in lines)
                {
                    if (row.Contains("];"))
                    {
                        bus = false;
                        bus_name = false;
                        area = false;
                        line = false;
                        transformer = false;
                        generator = false;
                        zone = false;
                        owner = false;
                        continue;
                    }
                    if (bus == true)
                    {
                        BusDataInsert(row);
                    }

                    if (generator == true)
                    {
                        GeneratorDataInsert(row);
                    }
                    //if (load == true && !row.Contains("@!")) { LoadDataInsert(row); }

                    if (line == true) { LineDataInsert(row); }
                    //if (transformer == true) { LineDataInsert(row); }
                    //   if (line == true && !row.Contains("@!")) { TransformersDataInsert(row); }
                    //if (transformer == true) { TransformersDataInsert(row); }
                    //if (area == true && !row.Contains("@!")) { AreaDataInsert(row); }
                    //if (owner == true && !row.Contains("@!")) { OwnerDataInsert(row); }
                    //if (zone == true && !row.Contains("@!")) { ZoneDataInsert(row); }



                    if (row.Contains("mpc.bus "))
                    {
                        bus = true;
                        continue;
                    }
                    if (row.Contains("mpc.gen "))
                    {
                        generator = true;
                        continue;
                    }
                    if (row.Contains("mpc.bus_name "))
                    {
                        bus_name = true;
                        continue;
                    }

                    /* if (row.Contains("BEGIN AREA"))
                     {
                         area = true;
                     }
                     if (row.Contains("BEGIN ZONE"))
                     {
                         zone = true;
                     }
                     if (row.Contains("BEGIN OWNER"))
                     {
                         owner = true;
                     }*/

                    if (row.Contains("mpc.branch "))
                    {
                        // transformer = true;
                        line = true;

                        continue;
                    }
                    /*    if (row.Contains("mpc.branch"))
                        {

                            transformer = true;
                            continue;
                        }*/

                }

               // return (buses, generators, lineBranches, transformerBranches);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Matlab File loder Error is " + ex.Message);
            }
            return (buses, generators, lineBranches, transformerBranches);
        }

    public void BusDataInsert(string row)
        {
            try
            {
                string[] columns = row.Split('\t');

                Bus b = new Bus();
                b.BusNumber = long.Parse(columns[1]);
                b.Bus_Type = (Bus_type)long.Parse(columns[2]);
                if (b.Bus_Type.Equals(Bus_type.Ref)) { b.slack = true; }
                b.PD = Utils.StringToFloat(columns[3]);
                b.QD = Utils.StringToFloat(columns[4]);
                b.ShuntG_pu = Utils.StringToFloat(columns[5]);
                b.ShuntB_pu = Utils.StringToFloat(columns[6]);
                b.areaLong = long.Parse(columns[7]);
                b.Voltagemagnitude = Utils.StringToFloat(columns[8]);
                b.angle = Utils.StringToFloat(columns[9]);
                b.nominalVoltage = Utils.StringToFloat(columns[10]);
                b.ZoneLong = long.Parse(columns[11]);
                b.NominalVmax = Utils.StringToFloat(columns[12]);
                b.NominalVmin = Utils.StringToFloat(columns[13].Replace(";", ""));

                this.buses.Add(b);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Matlab File loder Error is " + ex.Message);
            }
        }

        public void GeneratorDataInsert(string row)
        {
            try {

                Generator g = new Generator();
                PowerControl powerControl = new PowerControl();
                VoltageControl voltageControl = new VoltageControl();
                FaultParameters faultParameters = new FaultParameters();
                string[] columns = row.Split('\t');
                g.Bus = FindBusByCode(long.Parse(columns[1]));
                powerControl.outPut = Utils.StringToFloat(columns[2]);
                voltageControl.MvarOutput = Utils.StringToFloat(columns[3]);
                voltageControl.MaxMvars = Utils.StringToFloat(columns[4]);
                voltageControl.MinMvars = Utils.StringToFloat(columns[5]);
                powerControl.setpoint = Utils.StringToFloat(columns[6]);
                g.Generator_MVA_BASE = Utils.StringToFloat(columns[7]);
                g.Inservice = Convert.ToBoolean(int.Parse(columns[8].Trim()));
                powerControl.maxOut = Utils.StringToFloat(columns[9]);
                powerControl.minOut = Utils.StringToFloat(columns[10]);


                voltageControl.SetPointVoltage = Utils.StringToFloat(columns[6]);
                g.Generator_MVA_BASE = Utils.StringToFloat(columns[7]);



                powerControl.minOut = Utils.StringToFloat(columns[10]);
                powerControl.maxOut = Utils.StringToFloat(columns[9]);
                CapabilityCurve pc1 = new CapabilityCurve();
                pc1.Name = "PC1";
                pc1.MVAR = 0; ;
                pc1.MW = Utils.StringToFloat(columns[11]); ;
                g.capabilityCurves.Add(pc1);
                CapabilityCurve pc2 = new CapabilityCurve();
                pc2.Name = "PC2";
                pc2.MVAR = 0; ;
                pc2.MW = Utils.StringToFloat(columns[12]); ;
                g.capabilityCurves.Add(pc2);
                CapabilityCurve QC1min = new CapabilityCurve();
                QC1min.Name = "QC1min";
                QC1min.MVAR = Utils.StringToFloat(columns[13]); ;
                QC1min.MW = 0; ;
                g.capabilityCurves.Add(QC1min);
                CapabilityCurve QC1max = new CapabilityCurve();
                QC1max.Name = "QC1max";
                QC1max.MVAR = Utils.StringToFloat(columns[14]); ;
                QC1max.MW = 0; ;
                g.capabilityCurves.Add(QC1max);
                CapabilityCurve QC2min = new CapabilityCurve();
                QC2min.Name = "QC2min";
                QC2min.MVAR = Utils.StringToFloat(columns[15]); ;
                QC2min.MW = 0; ;
                g.capabilityCurves.Add(QC2min);
                CapabilityCurve QC2max = new CapabilityCurve();
                QC2max.Name = "QC2max";
                QC2max.MVAR = Utils.StringToFloat(columns[16]); ;
                QC2max.MW = 0; ;
                g.capabilityCurves.Add(QC2max);

                g.powerControl = powerControl;
                g.voltageControl = voltageControl;
                g.faultParameters = faultParameters;
                //  g.capabilityCurves.Max();

                /*  PC1 * 11 lower real power output of PQ capability curve(MW)
                  PC2 * 12 upper real power output of PQ capability curve(MW)
                  QC1MIN * 13 minimum reactive power output at PC1(MVAr)
                  QC1MAX * 14 maximum reactive power output at PC1(MVAr)
                  QC2MIN * 15 minimum reactive power output at PC2(MVAr)
                  QC2MAX * 16 maximum reactive power output at PC2(MVAr)
                  RAMP AGC*17 ramp rate for load following/ AGC(MW / min)
                  RAMP 10 * 18 ramp rate for 10 minute reserves(MW)
                  RAMP 30 * 19 ramp rate for 30 minute reserves(MW)
                  RAMP Q * 20 ramp rate for reactive power (2 sec timescale) (MVAr / min)
                  APF * 21 area participation factor



                  faultParameters.ISI_Zero_R = float.Pa*//*rse(columns[9]);
                  faultParameters.ISI_Zero_X = Utils.StringToFloat(columns[10]);
                  faultParameters.Generatoe_Step_Transformer_R = Utils.StringToFloat(columns[11]);
                  faultParameters.Generatoe_Step_Transformer_X = Utils.StringToFloat(columns[12]);
                  faultParameters.Generatoe_Step_Transformer_Tap = Utils.StringToFloat(columns[13]);*/
                //            g.Status = bool.Parse(columns[14]);
                //g.Status = bool.Parse(columns[15]);

                //powerControl.minOut = Utils.StringToFloat(columns[16]);
                //powerControl.minOut = Utils.StringToFloat(columns[16]);
                //powerControl.minOut = Utils.StringToFloat(columns[16]);
                //g.powerControl = powerControl;
                //g.voltageControl = voltageControl;
                //g.faultParameters = faultParameters;

                this.generators.Add(g);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Matlab File  loder Error is " + ex.Message);
            }
        }
        
        public Bus FindBusByCode(long code)
        {
            foreach (Bus b in buses)
            {
                if (b.BusNumber == code)
                {
                    return b;
                }
            }
            return null;
        }
        public void LineDataInsert(string row)
        {
            try
            {
                string[] columns = row.Split('\t');
                float check = Utils.StringToFloat(columns[9]);
                
                if (check == 0)
                {
                    MultiPhaseLine l = new MultiPhaseLine();
                    lineRow=lineRow+1;
                    l.Number = lineRow;
                  
                    l.FromBus = FindBusByCode(long.Parse(columns[1]));
                    l.ToBus = FindBusByCode(long.Parse(columns[2]));
                    l.Resistance = Utils.StringToFloat(columns[3]);
                    l.Reactance = Utils.StringToFloat(columns[4]);
                    l.Charging = Utils.StringToFloat(columns[5]);
                    l.LimitList[0] = Utils.StringToDouble(columns[6]);
                    l.LimitList[1] = Utils.StringToDouble(columns[7]);
                    l.LimitList[2] = Utils.StringToDouble(columns[8]);
                    l.Inservice = Convert.ToBoolean(int.Parse(columns[11].Trim()));
                    /*  l.Angmin  = Utils.StringToFloat(columns[12]);
                      l.Angmax = Utils.StringToFloat(columns[13]);*/
                    //l.Owners[0]= OwnerCreator( Utils.StringToFloat(columns[27]),"Owner1", long.Parse(columns[26]));
                    //l.SetOwner(1, OwnerCreator(Utils.StringToFloat(columns[30]), "Owner2", long.Parse(columns[29])));
                    //l.SetOwner(2, OwnerCreator(Utils.StringToFloat(columns[32]), "Owner3", long.Parse(columns[31])));
                    //l.SetOwner(3, OwnerCreator(Utils.StringToFloat(columns[34]), "Owner4", long.Parse(columns[33])));


                    // b.voltage = long.Parse(buses[2]);
                    this.lineBranches.Add(l);

                }


                else if (check > 0)
                {
                    C2WTransformer t = new C2WTransformer();
                    LTCControl ltc = new LTCControl();
                    LoadTapChanger ltch = new LoadTapChanger();
                    MVALimits mvalim = new MVALimits();
                    Impedances impedances = new Impedances();
                    lineRow = lineRow+1;
                    t.number = lineRow;
                    t.PrimaryBUS = FindBusByCode(long.Parse(columns[1]));
                    t.SecondaryBUS = FindBusByCode(long.Parse(columns[2]));
                    t.transformer_pu.R1_2_pu = float.Parse(columns[3]);
                   // t.transformer_pu.R1_2_pu = Utils.StringToFloat(columns[3]);
                    t.transformer_pu.X1_2_pu = Utils.StringToFloat(columns[4]);
                    impedances.Magnetization_Susceptance = Utils.StringToFloat(columns[5]);
                    t.impedances = impedances;
                    //check here

                    mvalim.PrimaryNominal = Utils.StringToDouble(columns[6]);
                    mvalim.PrimarySummer = Utils.StringToDouble(columns[7]);
                    mvalim.PrimaryWinter = Utils.StringToDouble(columns[8]);
                    t.mvalimits = mvalim;

                    t.ltccontrol.FIXPrimNominalTurnRateHV = Utils.StringToFloat(columns[9]);
                    ltc.FIXSecPhaseLV = Utils.StringToFloat(columns[10]);
                    
                    t.Inservice = Convert.ToBoolean(int.Parse(columns[11].Trim()));
                    /*  var format = new NumberFormatInfo();
                      format.NegativeSign = "-";
                      format.NumberDecimalSeparator = ".";
                      ltch.Tap_Min = Utils.StringToDouble(columns[12] , format);
                      ltch.Tap_Max = Utils.StringToDouble(columns[13]);*/




                    this.transformerBranches.Add(t);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("File loder Error is " + ex.Message);
            }
        }

      
    }
}
