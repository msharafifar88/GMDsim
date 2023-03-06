using areaandzone;
using BL;
using GUI.FileController.Matlab;
using GUI.FileController.PSSE;
using GUI.New_concept_WPF;
using GUI.Save_And_Cancel_Form;
using network;
using persistent;
using persistent.enumeration;
using persistent.network;
using persistent.network.Generator;
using persistent.power;
using Syncfusion.WinForms.DataGrid;
using Syncfusion.WinForms.DataGrid.Enums;
using Syncfusion.WinForms.DataGrid.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.FileController
{
    public partial class FileBrowser : Form
    {
        List<Bus> buses;
        List<Owner> owners;
        List<Zone> zones;
        List<Area> areas;
        List<Loads> loadList;
        List<MultiPhaseLine> lineBranches;
        List<PSSETransformersWrapper> transformerTypes;
        List<Generator> generators;
        PSSEConfiguration configuration;
        List<C2WTransformer> transformerBranches;
        FileType fileType;
        public FileBrowser(FileType type)
        {
            try { InitializeComponent();
                contentTab.Alignment = TabAlignment.Bottom;
                BusCreator();
                GeneratorCreator();
                LoadCreator();
                LineCreator();
                OwnerCreator();
                ZoneCreator();
                AreaCreator();
                TransformerCreator();
                fileType = type;
                //   Programsetting();
            }
            catch(Exception ex)
            {
                MessageBox.Show("File loder Error is " + ex.Message);
            }
            }

        private void SelectorBTN_Click(object sender, EventArgs e)
        {
            buses = new List<Bus>();
            loadList = new List<Loads>();
            generators = new List<Generator>();
            lineBranches = new List<MultiPhaseLine>();
            transformerBranches = new List<C2WTransformer>();
            owners = new List<Owner>();
            zones = new List<Zone>();
            areas = new List<Area>();
            transformerTypes = new List<PSSETransformersWrapper>();
            configuration = new PSSEConfiguration();


            try
            {
                fileUploaderDialog = new OpenFileDialog();
                
                fileUploaderDialog.ShowDialog();
                
                string fileName = fileUploaderDialog.FileName;
                if (fileType.Equals(FileType.PSSE))
                {
                    PSSELoader(fileName);
                }else if (fileType.Equals(FileType.MatPower))
                {
                    MatlabLoader matloader = new MatlabLoader(fileName);
                    (buses, generators, lineBranches, transformerBranches) = matloader.LoadData();
                    this.areaDataGrid.DataSource = areas;
                    this.zoneDataGrid.DataSource = zones;
                    this.busDataGrid.DataSource = buses;
                    this.loadDataGrid.DataSource = loadList;
                    this.ownerDataGrid.DataSource = owners;
                    this.generatorDataGrid.DataSource = generators;
                    this.lineDataGrid.DataSource = lineBranches;
                    this.transformerDataGrid.DataSource = transformerBranches;
                }
                

            }
            catch (Exception ex)
            {
                MessageBox.Show("File loder Error is " + ex.Message);
            }
        }

        private void PSSELoader(string fileName)
        {
            try
            {
                if (File.Exists(fileName))
                {
                    string[] lines = File.ReadAllLines(fileName);
                    using (StreamReader fileReader = new StreamReader(fileName))
                    {

                        string inputrecord = fileReader.ReadLine();
                        string[] inputfields;

                        // The remainder of your code seems to be correct, but a check on the actual
                        // length of the array resulting from the Split call should be added for safety
                    }
                    // radImporterGridView.DataSource = createHeader(lines[0].Length);
                    string s = lines[1].ToString();
                    string[] columns = s.Split(',');


                    configuration.IC = float.Parse(columns[0]);
                    configuration.SBASE = float.Parse(columns[1]);
                    configuration.REV = float.Parse(columns[2]);
                    configuration.XFRRAT = float.Parse(columns[3]);
                    configuration.NXFRAT = float.Parse(columns[4]);
                    string[] temp = columns[5].Split('/');
                    configuration.BASFRQ = float.Parse(temp[0]);


                    this.IC.Text = configuration.IC.ToString();
                    this.Sbase.Text = configuration.SBASE.ToString();
                    this.REV.Text = configuration.REV.ToString();
                    this.XFRRAT.Text = configuration.XFRRAT.ToString();
                    this.NXFRAT.Text = configuration.NXFRAT.ToString();
                    this.BASEFRQ.Text = configuration.BASFRQ.ToString();

                    ProgramSettingGP.Visible = true;


                    bool bus, load, generator, line, transformers, owner, zone, area;
                    bus = load = generator = line = transformers = owner = zone = area = false;

                    foreach (string row in lines)
                    {
                        if (row.Contains("END OF BUS"))
                        {
                            bus = false;
                            this.busDataGrid.AutoGenerateColumns = false;
                            this.busDataGrid.QueryRowStyle += SfDataGrid_QueryRowStyle;
                        }
                        if (row.Contains("END OF AREA"))
                        {
                            area = false;
                            this.areaDataGrid.AutoGenerateColumns = false;

                            this.areaDataGrid.QueryRowStyle += SfDataGrid_QueryRowStyle;
                        }
                        if (row.Contains("END OF LOAD"))
                        {
                            load = false;
                            this.loadDataGrid.AutoGenerateColumns = false;

                            this.loadDataGrid.QueryRowStyle += SfDataGrid_QueryRowStyle;
                        }
                        if (row.Contains("END OF OWNER"))
                        {
                            owner = false;
                            this.ownerDataGrid.AutoGenerateColumns = false;

                            this.ownerDataGrid.QueryRowStyle += SfDataGrid_QueryRowStyle;
                        }
                        if (row.Contains("END OF ZONE"))
                        {
                            zone = false;
                            this.zoneDataGrid.AutoGenerateColumns = false;

                            this.zoneDataGrid.QueryRowStyle += SfDataGrid_QueryRowStyle;
                        }
                        if (row.Contains("END OF GENERATOR"))
                        {
                            generator = false;
                            this.generatorDataGrid.AutoGenerateColumns = false;

                            this.generatorDataGrid.QueryRowStyle += SfDataGrid_QueryRowStyle;
                        }
                        if (row.Contains("END OF LINE") || row.Contains("END OF BRANCH"))
                        {
                            line = false;
                            this.lineDataGrid.AutoGenerateColumns = false;

                            this.lineDataGrid.QueryRowStyle += SfDataGrid_QueryRowStyle;
                        }

                        if (bus == true && !row.Contains("@!")) { BusDataInsert(row); }
                        if (load == true && !row.Contains("@!")) { LoadDataInsert(row); }
                        if (generator == true && !row.Contains("@!")) { GeneratorDataInsert(row); }
                        if (line == true && !row.Contains("@!")) { LineDataInsert(row); }
                        //   if (line == true && !row.Contains("@!")) { TransformersDataInsert(row); }
                        //if (transformers = true) { TransformersDataInsert(row); }
                        if (area == true && !row.Contains("@!")) { AreaDataInsert(row); }
                        if (owner == true && !row.Contains("@!")) { OwnerDataInsert(row); }
                        if (zone == true && !row.Contains("@!")) { ZoneDataInsert(row); }



                        if (row.Contains("BEGIN BUS"))
                        {
                            bus = true;
                        }
                        if (row.Contains("BEGIN LOAD"))
                        {
                            load = true;
                        }
                        if (row.Contains("BEGIN AREA"))
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
                        }
                        if (row.Contains("BEGIN GENERATOR"))
                        {
                            generator = true;
                        }
                        if (row.Contains("BEGIN LINE") || row.Contains("BEGIN BRANCH"))
                        {
                            line = true;
                        }




                    }

                    BusCheckingData();
                    this.areaDataGrid.DataSource = areas;
                    this.zoneDataGrid.DataSource = zones;
                    this.busDataGrid.DataSource = buses;
                    this.loadDataGrid.DataSource = loadList;
                    this.ownerDataGrid.DataSource = owners;
                    this.generatorDataGrid.DataSource = generators;
                    this.lineDataGrid.DataSource = lineBranches;


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("File loder Error is " + ex.Message);
            }

        }
    /*    public void Programsetting()
        {
            this.ProgramSettingDataGrid.Columns.Add(new GridTextColumn() { MappingName = "IC", HeaderText = "IC" });
            this.ProgramSettingDataGrid.Columns.Add(new GridTextColumn() { MappingName = "Sbase", HeaderText = "Sbase" });
            this.ProgramSettingDataGrid.Columns.Add(new GridTextColumn() { MappingName = "REV", HeaderText = "REV" });
            this.ProgramSettingDataGrid.Columns.Add(new GridTextColumn() { MappingName = "XFRRAT", HeaderText = "XFRRAT" });
            this.ProgramSettingDataGrid.Columns.Add(new GridTextColumn() { MappingName = "NXFRAT", HeaderText = "NXFRAT" });
            this.ProgramSettingDataGrid.Columns.Add(new GridTextColumn() { MappingName = "BASFRQ", HeaderText = "BASFRQ" });
        }*/
        public void BusCreator()
        {
            try
            {
                // this.busDataGrid.Columns.Add(new GridTextColumn() { MappingName = "ID", HeaderText = "ID" });
                this.busDataGrid.Columns.Add(new GridTextColumn() { MappingName = "BusNumber", HeaderText = "Bus Number" });
                this.busDataGrid.Columns.Add(new GridTextColumn() { MappingName = "BusName", HeaderText = "Bus Name" });
                this.busDataGrid.Columns.Add(new GridTextColumn() { MappingName = "voltage", HeaderText = "Voltage" });
                this.busDataGrid.Columns.Add(new GridTextColumn() { MappingName = "angle", HeaderText = "Angle" });
                this.busDataGrid.Columns.Add(new GridTextColumn() { MappingName = "area.Name", HeaderText = "Area Number" });
                this.busDataGrid.Columns.Add(new GridTextColumn() { MappingName = "area.Number", HeaderText = "Area Name" });
                this.busDataGrid.Columns.Add(new GridTextColumn() { MappingName = "zone.Number", HeaderText = "Zone Number" });
                this.busDataGrid.Columns.Add(new GridTextColumn() { MappingName = "zone.Name", HeaderText = "Zone Name" });
                this.busDataGrid.Columns.Add(new GridTextColumn() { MappingName = "OwnerNumber", HeaderText = "Owner Number" });

                this.busDataGrid.Columns.Add(new GridTextColumn() { MappingName = "voltage", HeaderText = "Normal Vmax" });
                this.busDataGrid.Columns.Add(new GridTextColumn() { MappingName = "voltage", HeaderText = "Normal Vmin" });
                this.busDataGrid.Columns.Add(new GridTextColumn() { MappingName = "voltage", HeaderText = "Emergency Vmax" });
                this.busDataGrid.Columns.Add(new GridTextColumn() { MappingName = "voltage", HeaderText = "Emergency Vmin" });


            }
            catch (Exception ex)
            {
                MessageBox.Show("File loder Error is " + ex.Message);
            }
        }
        private void SfDataGrid_QueryRowStyle(object sender, QueryRowStyleEventArgs e)
        {
            try
            {
                if (e.RowType == RowType.DefaultRow)
                {
                    if (e.RowIndex % 2 == 0)
                        e.Style.BackColor = Color.LightGray;
                    else
                        e.Style.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("File loder Error is " + ex.Message);
            }
        }

        //Load (Branch)
        public void LoadCreator()
        {
            try
            {
                this.loadDataGrid.Columns.Add(new GridTextColumn() { MappingName = "Bus.BusNumber", HeaderText = "Bus Number" });
                this.loadDataGrid.Columns.Add(new GridTextColumn() { MappingName = "Bus.BusName", HeaderText = "From Bus Name" });
                this.loadDataGrid.Columns.Add(new GridTextColumn() { MappingName = "linebranches.Identity", HeaderText = "ID" });
                this.loadDataGrid.Columns.Add(new GridTextColumn() { MappingName = "Bus.area.Number", HeaderText = "Area Number" });
                this.loadDataGrid.Columns.Add(new GridTextColumn() { MappingName = "Bus.area.Name", HeaderText = "Area Name" });
                this.loadDataGrid.Columns.Add(new GridTextColumn() { MappingName = "Bus.zone.Number", HeaderText = "Zone Number" });
                this.loadDataGrid.Columns.Add(new GridTextColumn() { MappingName = "Bus.zone.Name", HeaderText = "Zone Name" });
                this.loadDataGrid.Columns.Add(new GridTextColumn() { MappingName = "Bus.Owners[0].Number", HeaderText = "Zone Number" });
                this.loadDataGrid.Columns.Add(new GridTextColumn() { MappingName = "Bus.Owners[0].Name", HeaderText = "Zone Name" });
                this.loadDataGrid.Columns.Add(new GridTextColumn() { MappingName = "loadinformation.P_Power", HeaderText = "Constant Power(MV)" });
                this.loadDataGrid.Columns.Add(new GridTextColumn() { MappingName = "loadinformation.P_Current", HeaderText = "Constant Current(MV)" });
                this.loadDataGrid.Columns.Add(new GridTextColumn() { MappingName = "loadinformation.P_Impedance", HeaderText = "Constant Impedance (MV)" });
                this.loadDataGrid.Columns.Add(new GridTextColumn() { MappingName = "loadinformation.Q_Power", HeaderText = "Constant Power(MVar)" });
                this.loadDataGrid.Columns.Add(new GridTextColumn() { MappingName = "loadinformation.Q_Current", HeaderText = "Constant Current(MVar)" });
                this.loadDataGrid.Columns.Add(new GridTextColumn() { MappingName = "loadinformation.Q_Impedance", HeaderText = "Constant Impedance (MVar)" });
                this.loadDataGrid.Columns.Add(new GridTextColumn() { MappingName = "distributedGeneration.P_GEN", HeaderText = "Distribut Generation (MV)" });
                this.loadDataGrid.Columns.Add(new GridTextColumn() { MappingName = "distributedGeneration.Q_GEN", HeaderText = " Distribut Generation (MVar)" });
                this.loadDataGrid.Columns.Add(new GridCheckBoxColumn() { MappingName = "Inservice", HeaderText = "Inservice" });
                this.loadDataGrid.Columns.Add(new GridCheckBoxColumn() { MappingName = "Interruptible", HeaderText = "Interruptible" });
                this.loadDataGrid.Columns.Add(new GridCheckBoxColumn() { MappingName = "Scalable", HeaderText = "Scalable" });
                this.loadDataGrid.Columns.Add(new GridCheckBoxColumn() { MappingName = "distributedGeneration.DGinservice", HeaderText = "Distributed Generationinservice" });

            }
            catch (Exception ex)
            {
                MessageBox.Show("File loder Error is " + ex.Message);
            }
        }


        public void LineCreator()
        {
            try {
                this.lineDataGrid.Columns.Add(new GridTextColumn() { MappingName = "FromBus.BusNumber", HeaderText = "From Bus Number" });
                this.lineDataGrid.Columns.Add(new GridTextColumn() { MappingName = "FromBus.BusName", HeaderText = "From Bus Name" });
                this.lineDataGrid.Columns.Add(new GridTextColumn() { MappingName = "ToBus.BusNumber", HeaderText = "To Bus Number" });
                this.lineDataGrid.Columns.Add(new GridTextColumn() { MappingName = "ToBus.BusName", HeaderText = "To Bus Name" });
                this.lineDataGrid.Columns.Add(new GridTextColumn() { MappingName = "linebranches.Identity", HeaderText = "ID" });
                this.lineDataGrid.Columns.Add(new GridTextColumn() { MappingName = "linebranches.Name", HeaderText = "Name" });
                this.lineDataGrid.Columns.Add(new GridTextColumn() { MappingName = "FromBus.nominalVoltage", HeaderText = "From Bus Nominal Voltage" });
                this.lineDataGrid.Columns.Add(new GridTextColumn() { MappingName = "ToBus.nominalVoltage", HeaderText = "To Bus Nominal Voltage" });

                this.lineDataGrid.Columns.Add(new GridTextColumn() { MappingName = "Resistance", HeaderText = "Serise Resistance (R)" });
                this.lineDataGrid.Columns.Add(new GridTextColumn() { MappingName = "Reactance", HeaderText = "Serise Reactance (X)" });
                this.lineDataGrid.Columns.Add(new GridTextColumn() { MappingName = "Charging", HeaderText = "Shunt Charging (B)" });
                this.lineDataGrid.Columns.Add(new GridTextColumn() { MappingName = "Conductance", HeaderText = "Shunt Conductance (G)" });

                this.lineDataGrid.Columns.Add(new GridTextColumn() { MappingName = "RzeroSequence", HeaderText = "R Zero Sequence" });
                this.lineDataGrid.Columns.Add(new GridTextColumn() { MappingName = "XzeroSequence", HeaderText = "X Zero Sequence" });
                this.lineDataGrid.Columns.Add(new GridTextColumn() { MappingName = "BzeroSequence", HeaderText = "B Zero Sequence" });
                this.lineDataGrid.Columns.Add(new GridTextColumn() { MappingName = "GzeroSequence", HeaderText = "G Zero Sequence" });


                this.lineDataGrid.Columns.Add(new GridTextColumn() { MappingName = "LineLengthvalue", HeaderText = "Length" });

                this.lineDataGrid.Columns.Add(new GridTextColumn() { MappingName = "LimitList[0]", HeaderText = "Limit List 1" });
                this.lineDataGrid.Columns.Add(new GridTextColumn() { MappingName = "LimitList[1]", HeaderText = "Limit List 2" });
                this.lineDataGrid.Columns.Add(new GridTextColumn() { MappingName = "linebranches.LimitList[2]", HeaderText = "Limit List 3" });
                this.lineDataGrid.Columns.Add(new GridTextColumn() { MappingName = "linebranches.LimitList[3]", HeaderText = "Limit List 4" });
                this.lineDataGrid.Columns.Add(new GridTextColumn() { MappingName = "linebranches.LimitList[4]", HeaderText = "Limit List 5" });
                this.lineDataGrid.Columns.Add(new GridTextColumn() { MappingName = "linebranches.LimitList[5]", HeaderText = "Limit List 6" });
                this.lineDataGrid.Columns.Add(new GridTextColumn() { MappingName = "linebranches.LimitList[6]", HeaderText = "Limit List 7" });
                this.lineDataGrid.Columns.Add(new GridTextColumn() { MappingName = "linebranches.LimitList[7]", HeaderText = "Limit List 8" });
                this.lineDataGrid.Columns.Add(new GridTextColumn() { MappingName = "linebranches.LimitList[8]", HeaderText = "Limit List 9" });
                this.lineDataGrid.Columns.Add(new GridTextColumn() { MappingName = "linebranches.LimitList[9]", HeaderText = "Limit List 10" });
                this.lineDataGrid.Columns.Add(new GridTextColumn() { MappingName = "linebranches.LimitList[10]", HeaderText = "Limit List 11" });
                this.lineDataGrid.Columns.Add(new GridTextColumn() { MappingName = "linebranches.LimitList[11]", HeaderText = "Limit List 12" });
                this.lineDataGrid.Columns.Add(new GridTextColumn() { MappingName = "linebranches.LimitList[12]", HeaderText = "Limit List 13" });
                this.lineDataGrid.Columns.Add(new GridTextColumn() { MappingName = "linebranches.LimitList[13]", HeaderText = "Limit List 14" });
                this.lineDataGrid.Columns.Add(new GridTextColumn() { MappingName = "linebranches.LimitList[14]", HeaderText = "Limit List 15" });
                this.lineDataGrid.Columns.Add(new GridTextColumn() { MappingName = "linebranches.LimitList[15]", HeaderText = "Limit List 16" });

                this.lineDataGrid.Columns.Add(new GridTextColumn() { MappingName = "Owners[0].Percentage", HeaderText = "Owner1 %" });
                this.lineDataGrid.Columns.Add(new GridTextColumn() { MappingName = "Owners[0].Name", HeaderText = "Owner1 Name" });
                this.lineDataGrid.Columns.Add(new GridTextColumn() { MappingName = "Owners[1].Percentage", HeaderText = "Owner2 %" });
                this.lineDataGrid.Columns.Add(new GridTextColumn() { MappingName = "Owners[1].Name", HeaderText = "Owner2 Name" });
                this.lineDataGrid.Columns.Add(new GridTextColumn() { MappingName = "Owners[2].Percentage", HeaderText = "Owner3 %" });
                this.lineDataGrid.Columns.Add(new GridTextColumn() { MappingName = "Owners[2].Name", HeaderText = "Owner3 Name" });
                this.lineDataGrid.Columns.Add(new GridTextColumn() { MappingName = "Owners[3].Percentage", HeaderText = "Owner4 %" });
                this.lineDataGrid.Columns.Add(new GridTextColumn() { MappingName = "Owners[4].Name", HeaderText = "Owner4 Name" });
                this.lineDataGrid.Columns.Add(new GridTextColumn() { MappingName = "Owners[5].Percentage", HeaderText = "Owner5 %" });
                this.lineDataGrid.Columns.Add(new GridTextColumn() { MappingName = "Owners[5].Name", HeaderText = "Owner5 Name" });

                /*this.lineDataGrid.Columns.Add(new GridTextColumn() { MappingName = "powerControl.minOut", HeaderText = "PB" });
                this.lineDataGrid.Columns.Add(new GridTextColumn() { MappingName = "powerControl.maxOut", HeaderText = "O1" });
                this.lineDataGrid.Columns.Add(new GridTextColumn() { MappingName = "F1", HeaderText = "F1" });
                this.lineDataGrid.Columns.Add(new GridTextColumn() { MappingName = "F2", HeaderText = "F2" });
                this.lineDataGrid.Columns.Add(new GridTextColumn() { MappingName = "O3", HeaderText = "O3" });
                this.lineDataGrid.Columns.Add(new GridTextColumn() { MappingName = "F3", HeaderText = "F3" });
                this.lineDataGrid.Columns.Add(new GridTextColumn() { MappingName = "O4", HeaderText = "O4" });
                this.lineDataGrid.Columns.Add(new GridTextColumn() { MappingName = "F4", HeaderText = "F4" });
                this.lineDataGrid.Columns.Add(new GridTextColumn() { MappingName = "WMOD", HeaderText = "WMOD" });
                this.lineDataGrid.Columns.Add(new GridTextColumn() { MappingName = "WPF", HeaderText = "WPF" });*/
            }
            catch (Exception ex)
            {
                MessageBox.Show("File loder Error is " + ex.Message);
            }
        }

        public void GeneratorCreator()
        {
            try
            {
                this.generatorDataGrid.Columns.Add(new GridTextColumn() { MappingName = "Bus.BusNumber", HeaderText = "Bus Number" });
                this.generatorDataGrid.Columns.Add(new GridTextColumn() { MappingName = "Bus.BusName", HeaderText = "Bus Name" });
                this.generatorDataGrid.Columns.Add(new GridTextColumn() { MappingName = "Name", HeaderText = "Name" });
                this.generatorDataGrid.Columns.Add(new GridTextColumn() { MappingName = "Identity", HeaderText = "ID" });
                this.generatorDataGrid.Columns.Add(new GridTextColumn() { MappingName = "powerControl.setpoint", HeaderText = "Setpoint(MW)" });
                this.generatorDataGrid.Columns.Add(new GridTextColumn() { MappingName = "powerControl.outPut", HeaderText = "OutPut (MW)" });
                this.generatorDataGrid.Columns.Add(new GridTextColumn() { MappingName = "powerControl.maxOut", HeaderText = "MAX OutPut (MW)" });
                this.generatorDataGrid.Columns.Add(new GridTextColumn() { MappingName = "powerControl.minOut", HeaderText = "MIN OutPut (MW)" });
                this.generatorDataGrid.Columns.Add(new GridTextColumn() { MappingName = "Generator_MVA_BASE", HeaderText = "Generator Base (MVA)" });
                this.generatorDataGrid.Columns.Add(new GridTextColumn() { MappingName = "voltageControl.MvarOutput", HeaderText = "Voltage Output (Mvar)" });
                this.generatorDataGrid.Columns.Add(new GridTextColumn() { MappingName = "voltageControl.MaxMvars", HeaderText = "MAX Voltage Output  (Mvar)" });
                this.generatorDataGrid.Columns.Add(new GridTextColumn() { MappingName = "voltageControl.MinMvars", HeaderText = "MIN Voltage Output (Mvar)" });


                this.generatorDataGrid.Columns.Add(new GridTextColumn() { MappingName = "faultParameters.ISI_Zero_R", HeaderText = "Internal Squence Impedances Zero R" });
                this.generatorDataGrid.Columns.Add(new GridTextColumn() { MappingName = "faultParameters.ISI_Zero_X", HeaderText = "Internal Squence Impedances Zero X" });
                this.generatorDataGrid.Columns.Add(new GridTextColumn() { MappingName = "faultParameters.Generatoe_Step_Transformer_R", HeaderText = "Generatoe Step Transformer R" });
                this.generatorDataGrid.Columns.Add(new GridTextColumn() { MappingName = "faultParameters.Generatoe_Step_Transformer_X", HeaderText = "Generatoe Step Transformer X" });
                this.generatorDataGrid.Columns.Add(new GridTextColumn() { MappingName = "faultParameters.Generatoe_Step_Transformer_Tap", HeaderText = "Generatoe Step Transformer Tap" });

                this.generatorDataGrid.Columns.Add(new GridTextColumn() { MappingName = "F1", HeaderText = "F1" });
                this.generatorDataGrid.Columns.Add(new GridTextColumn() { MappingName = "F2", HeaderText = "F2" });
                this.generatorDataGrid.Columns.Add(new GridTextColumn() { MappingName = "O3", HeaderText = "O3" });
                this.generatorDataGrid.Columns.Add(new GridTextColumn() { MappingName = "F3", HeaderText = "F3" });
                this.generatorDataGrid.Columns.Add(new GridTextColumn() { MappingName = "O4", HeaderText = "O4" });
                this.generatorDataGrid.Columns.Add(new GridTextColumn() { MappingName = "F4", HeaderText = "F4" });
                this.generatorDataGrid.Columns.Add(new GridTextColumn() { MappingName = "WMOD", HeaderText = "WMOD" });
                this.generatorDataGrid.Columns.Add(new GridTextColumn() { MappingName = "WPF", HeaderText = "WPF" });
                this.generatorDataGrid.AllowEditing = false;
                this.generatorDataGrid.AutoGenerateColumns = false;
                this.busDataGrid.QueryRowStyle += SfDataGrid_QueryRowStyle;
            }
            catch (Exception ex)
            {
                MessageBox.Show("File loder Error is " + ex.Message);
            }

        }
        public void OwnerCreator()
        {
            //this.ownerDataGrid.Columns.Add(new GridTextColumn() { MappingName = "ID", HeaderText = "ID" });
            this.ownerDataGrid.Columns.Add(new GridTextColumn() { MappingName = "Number", HeaderText = "Owner Number" });
            this.ownerDataGrid.Columns.Add(new GridTextColumn() { MappingName = "Name", HeaderText = "Owner Name" });


        }
        public void ZoneCreator()
        {
            //this.zoneDataGrid.Columns.Add(new GridTextColumn() { MappingName = "ID", HeaderText = "ID" });
            this.zoneDataGrid.Columns.Add(new GridTextColumn() { MappingName = "Number", HeaderText = "Zone Number" });
            this.zoneDataGrid.Columns.Add(new GridTextColumn() { MappingName = "Name", HeaderText = "Zone Name" });

        }
        public void AreaCreator()
        {
          //  this.areaDataGrid.Columns.Add(new GridTextColumn() { MappingName = "ID", HeaderText = "ID" });
            this.areaDataGrid.Columns.Add(new GridTextColumn() { MappingName = "Number", HeaderText = "Area Number" });
            this.areaDataGrid.Columns.Add(new GridTextColumn() { MappingName = "Name", HeaderText = "Area Name" });
            this.areaDataGrid.Columns.Add(new GridTextColumn() { MappingName = "voltage", HeaderText = "Tolerance" });
            this.areaDataGrid.Columns.Add(new GridTextColumn() { MappingName = "voltage", HeaderText = "Area swing Bus" });

        }

        public void TransformerCreator()
        {
            try {
                this.transformerDataGrid.Columns.Add(new GridTextColumn() { MappingName = "PrimaryBUS.BusNumber", HeaderText = "Primary (HV) Bus Number" });
                this.transformerDataGrid.Columns.Add(new GridTextColumn() { MappingName = "PrimaryBUS.nominalVoltage", HeaderText = "Primary (HV) Bus nominalVoltage" });
                this.transformerDataGrid.Columns.Add(new GridTextColumn() { MappingName = "PrimaryBUS.BusName", HeaderText = "Primary (HV) Bus Name" });

                this.transformerDataGrid.Columns.Add(new GridTextColumn() { MappingName = "SecondaryBUS.BusNumber", HeaderText = "Secondary (LV) Bus Number" });
                this.transformerDataGrid.Columns.Add(new GridTextColumn() { MappingName = "SecondaryBUS.nominalVoltage", HeaderText = "Secondary (LV) Bus nominalVoltage" });
                this.transformerDataGrid.Columns.Add(new GridTextColumn() { MappingName = "SecondaryBUS.BusName", HeaderText = "Secondary (LV) Bus Name" });

                this.transformerDataGrid.Columns.Add(new GridTextColumn() { MappingName = "TertiaryBUS.BusNumber", HeaderText = "Tertiary (TV) Bus Number" });
                this.transformerDataGrid.Columns.Add(new GridTextColumn() { MappingName = "TertiaryBUS.nominalVoltage", HeaderText = "Tertiary (TV) Bus nominalVoltage" });
                this.transformerDataGrid.Columns.Add(new GridTextColumn() { MappingName = "TertiaryBUS.BusName", HeaderText = "Tertiary (TV) Bus Name" });

                this.transformerDataGrid.Columns.Add(new GridTextColumn() { MappingName = "PrimaryBUS.area.Name", HeaderText = "Primary (HV) Bus Area Name" });
                this.transformerDataGrid.Columns.Add(new GridTextColumn() { MappingName = "SecondaryBUS.area.Name", HeaderText = "Secondary (LV) Bus Area Name" });
                this.transformerDataGrid.Columns.Add(new GridTextColumn() { MappingName = "TertiaryBUS.area.Name", HeaderText = "Tertiary (TV) Bus Area Name" });

                this.transformerDataGrid.Columns.Add(new GridTextColumn() { MappingName = "Identity", HeaderText = "Transformer Identity" });



                this.transformerDataGrid.Columns.Add(new GridTextColumn() { MappingName = "pSSETransmorerTypeIO.WindingIO", HeaderText = "Winding I/O" });
                this.transformerDataGrid.Columns.Add(new GridTextColumn() { MappingName = "pSSETransmorerTypeIO.ImpedanceIO", HeaderText = "Impedance I/O" });
                this.transformerDataGrid.Columns.Add(new GridTextColumn() { MappingName = "pSSETransmorerTypeIO.AdmittanceIO", HeaderText = "Admittance I/O" });


                this.transformerDataGrid.Columns.Add(new GridTextColumn() { MappingName = "transformerImpedance.magnetizationConductance", HeaderText = "Mag. G" });
                this.transformerDataGrid.Columns.Add(new GridTextColumn() { MappingName = "transformerImpedance.magnetizationSusceptance", HeaderText = "Mag. B" });


                this.transformerDataGrid.Columns.Add(new GridTextColumn() { MappingName = "name", HeaderText = "Transformer Name" });
                this.transformerDataGrid.Columns.Add(new GridTextColumn() { MappingName = "Inservice", HeaderText = "In Service" });



                this.transformerDataGrid.Columns.Add(new GridTextColumn() { MappingName = "Owners[0].Percentage", HeaderText = "Owner1 %" });
                this.transformerDataGrid.Columns.Add(new GridTextColumn() { MappingName = "Owners[0].Name", HeaderText = "Owner1 Name" });
                this.transformerDataGrid.Columns.Add(new GridTextColumn() { MappingName = "Owners[1].Percentage", HeaderText = "Owner2 %" });
                this.transformerDataGrid.Columns.Add(new GridTextColumn() { MappingName = "Owners[1].Name", HeaderText = "Owner2 Name" });
                this.transformerDataGrid.Columns.Add(new GridTextColumn() { MappingName = "Owners[2].Percentage", HeaderText = "Owner3 %" });
                this.transformerDataGrid.Columns.Add(new GridTextColumn() { MappingName = "Owners[2].Name", HeaderText = "Owner3 Name" });
                this.transformerDataGrid.Columns.Add(new GridTextColumn() { MappingName = "Owners[3].Percentage", HeaderText = "Owner4 %" });
                this.transformerDataGrid.Columns.Add(new GridTextColumn() { MappingName = "Owners[4].Name", HeaderText = "Owner4 Name" });
                this.transformerDataGrid.Columns.Add(new GridTextColumn() { MappingName = "Owners[5].Percentage", HeaderText = "Owner5 %" });
                this.transformerDataGrid.Columns.Add(new GridTextColumn() { MappingName = "Owners[5].Name", HeaderText = "Owner5 Name" });



                this.transformerDataGrid.Columns.Add(new GridTextColumn() { MappingName = "VECGRP", HeaderText = "VECGRP" });
                this.transformerDataGrid.Columns.Add(new GridTextColumn() { MappingName = "ZCOD", HeaderText = "ZCOD" });
                this.transformerDataGrid.Columns.Add(new GridTextColumn() { MappingName = "R1_2", HeaderText = "R1_2" });
                this.transformerDataGrid.Columns.Add(new GridTextColumn() { MappingName = "X1_2", HeaderText = "X1_2" });
                this.transformerDataGrid.Columns.Add(new GridTextColumn() { MappingName = "SBASE1_2", HeaderText = "SBASE1_2" });
                this.transformerDataGrid.Columns.Add(new GridTextColumn() { MappingName = "R2_3", HeaderText = "R2_3" });
                this.transformerDataGrid.Columns.Add(new GridTextColumn() { MappingName = "X2_3", HeaderText = "X2_3" });
                this.transformerDataGrid.Columns.Add(new GridTextColumn() { MappingName = "SBASE2_3", HeaderText = "SBASE2_3" });
                this.transformerDataGrid.Columns.Add(new GridTextColumn() { MappingName = "R3_1", HeaderText = "R3_1" });
                this.transformerDataGrid.Columns.Add(new GridTextColumn() { MappingName = "X3_1", HeaderText = "X3_1" });
                this.transformerDataGrid.Columns.Add(new GridTextColumn() { MappingName = "SBASE3_1", HeaderText = "SBASE3_1" });
            }
            catch (Exception ex)
            {
                MessageBox.Show("File loder Error is " + ex.Message);
            }
        }

        public void BusDataInsert(string row)
        {
            try
            {
                string[] columns = row.Split(',');

                Bus b = new Bus();
                b.BusNumber = long.Parse(columns[0]);
                b.BusName = columns[1];
                b.nominalVoltage = float.Parse(columns[2]);
                b.Identity = int.Parse(columns[3]);
                b.areaLong = long.Parse(columns[4]);
                b.ZoneLong = long.Parse(columns[5]);
                //b.owners[0] = { long.Parse(columns[6])};
                b.voltage = float.Parse(columns[7]);
                b.angle = float.Parse(columns[8]);
                b.NominalVmax = float.Parse(columns[9]);
                b.NominalVmin = float.Parse(columns[10]);
                b.EmerVmax = float.Parse(columns[11]);
                b.EmerVmin = float.Parse(columns[12]);
                // b.voltage = long.Parse(buses[2]);
                this.buses.Add(b);
            }
            catch (Exception ex)
            {
                MessageBox.Show("File loder Error is " + ex.Message);
            }
        }
        public void LoadDataInsert(string row)
        {
            try
            {
                string[] columns = row.Split(',');

                Loads l = new Loads();
                l.Bus = FindBusByCode(long.Parse(columns[0]));
                // l.Identity = int.Parse(columns[1]);
                l.Inservice = Convert.ToBoolean(int.Parse(columns[2].Trim()));
                // area (columns[3]); from Bus
                // Zone Columns [4] from bus
                l.loadinformation.P_Power = double.Parse(columns[5]);
                l.loadinformation.Q_Power = double.Parse(columns[6]);
                l.loadinformation.P_Current = double.Parse(columns[7]);
                l.loadinformation.Q_Current = double.Parse(columns[8]);
                l.loadinformation.P_Impedance = double.Parse(columns[9]);
                l.loadinformation.Q_Impedance = double.Parse(columns[10]);
                l.Scalable = Convert.ToBoolean(int.Parse(columns[12].Trim()));
                l.Interruptible = Convert.ToBoolean(int.Parse(columns[13].Trim()));
                l.distributedGeneration.P_GEN = double.Parse(columns[14]);
                l.distributedGeneration.Q_GEN = double.Parse(columns[15]);
                l.distributedGeneration.DGinservice = Convert.ToBoolean(int.Parse(columns[16].Trim()));
                // b.voltage = long.Parse(buses[2]);
                this.loadList.Add(l);
            }
            catch (Exception ex)
            {
                MessageBox.Show("File loder Error is " + ex.Message);
            }
        }
        public void GeneratorDataInsert(string row)
        {
            try
            {
                string[] columns = row.Split(',');

                Generator g = new Generator();
                PowerControl powerControl = new PowerControl();
                VoltageControl voltageControl = new VoltageControl();
                FaultParameters faultParameters = new FaultParameters();
                g.Bus = FindBusByCode(long.Parse(columns[0]));
                //           g.Identity = long.Parse(columns[1]);
                powerControl.setpoint = float.Parse(columns[2]);
                voltageControl.MvarOutput = float.Parse(columns[3]);
                voltageControl.MaxMvars = float.Parse(columns[4]);
                voltageControl.MinMvars = float.Parse(columns[5]);
                g.Generator_MVA_BASE = float.Parse(columns[8]);
                faultParameters.ISI_Zero_R = float.Parse(columns[9]);
                faultParameters.ISI_Zero_X = float.Parse(columns[10]);
                faultParameters.Generatoe_Step_Transformer_R = float.Parse(columns[11]);
                faultParameters.Generatoe_Step_Transformer_X = float.Parse(columns[12]);
                faultParameters.Generatoe_Step_Transformer_Tap = float.Parse(columns[13]);
                //            g.Status = bool.Parse(columns[14]);
                //g.Status = bool.Parse(columns[15]);
                powerControl.minOut = float.Parse(columns[16]);
                powerControl.maxOut = float.Parse(columns[17]);
                //powerControl.minOut = float.Parse(columns[16]);
                //powerControl.minOut = float.Parse(columns[16]);
                //powerControl.minOut = float.Parse(columns[16]);
                g.powerControl = powerControl;
                g.voltageControl = voltageControl;
                g.faultParameters = faultParameters;

                this.generators.Add(g);

            }
            catch (Exception ex)
            {
                MessageBox.Show("File loder Error is " + ex.Message);
            }
        }
        public void LineDataInsert(string row)
        {
            try
            {
                string[] columns = row.Split(',');

                MultiPhaseLine l = new MultiPhaseLine();
                l.FromBus = FindBusByCode(long.Parse(columns[0]));
                l.ToBus = FindBusByCode(long.Parse(columns[1]));
                l.Identity = columns[2];
                l.Resistance = float.Parse(columns[3]);
                l.Reactance = float.Parse(columns[4]);
                l.Charging = float.Parse(columns[5]);
                l.Name = columns[6];
                l.LimitList[0] = double.Parse(columns[7]);
                l.LimitList[1] = double.Parse(columns[8]);
                l.LimitList[2] = double.Parse(columns[9]);
                l.LimitList[3] = double.Parse(columns[10]);
                l.LimitList[4] = double.Parse(columns[11]);
                l.LimitList[5] = double.Parse(columns[12]);
                l.LimitList[6] = double.Parse(columns[13]);
                l.LimitList[7] = double.Parse(columns[14]);
                l.LimitList[8] = double.Parse(columns[15]);
                l.LimitList[9] = double.Parse(columns[16]);
                l.LimitList[10] = double.Parse(columns[17]);
                l.LimitList[11] = double.Parse(columns[18]);
                l.Inservice = Convert.ToBoolean(int.Parse(columns[23].Trim()));
                l.LineLengthvalue = float.Parse(columns[25]);

                l.Owners[0] = OwnerCreator(float.Parse(columns[27]), "Owner1", long.Parse(columns[26]));
                //l.SetOwner(1, OwnerCreator(float.Parse(columns[30]), "Owner2", long.Parse(columns[29])));
                //l.SetOwner(2, OwnerCreator(float.Parse(columns[32]), "Owner3", long.Parse(columns[31])));
                //l.SetOwner(3, OwnerCreator(float.Parse(columns[34]), "Owner4", long.Parse(columns[33])));


                // b.voltage = long.Parse(buses[2]);
                this.lineBranches.Add(l);

            }
            catch (Exception ex)
            {
                MessageBox.Show("File loder Error is " + ex.Message);
            }
        }
            
            public void OwnerDataInsert(string row)
        {
            string[] columns = row.Split(',');

            Owner o = new Owner();
            o.Number = long.Parse(columns[0]);
            o.Name = columns[1];
            // b.voltage = long.Parse(buses[2]);
            this.owners.Add(o);

        }
        public void ZoneDataInsert(string row)
        {
            string[] columns = row.Split(',');

            Zone z = new Zone();
            z.Number = long.Parse(columns[0]);
            z.Name = columns[1];
            // b.voltage = long.Parse(buses[2]);
            this.zones.Add(z);

        }
        public void AreaDataInsert(string row)
        {
            string[] columns = row.Split(',');

            Area a = new Area();
            a.Number = long.Parse(columns[0]);
            a.Name = columns[4];
            // b.voltage = long.Parse(buses[2]);
            this.areas.Add(a);

        }

      


        private Owner OwnerCreator(float percentage , string name , long code)
        {
            Owner o = new Owner();
            o.Percentage = percentage;
            o.Number = code;
            o.Name = name;
            return o;
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
        public Area FindAreaByCode(long code)
        {
            foreach (Area area in areas)
            {
                if (area.Number == code)
                {
                    return area;
                }
            }
            return null;
        }
        public Zone FindZoneByCode(long code)
        {
            foreach (Zone zone in zones)
            {
                if (zone.Number == code)
                {
                    return zone;
                }
            }
            return null;
        }

        public void BusCheckingData()
        {
            foreach (Bus bus in buses)
            {
                bus.area = FindAreaByCode(bus.areaLong);
                bus.zone = FindZoneByCode(bus.ZoneLong);
            }

        }

       

        private void Save_Click(object sender, EventArgs e)
        {
             try
            {
                DataStore_Util datautil = new DataStore_Util();
                if (CustomContentControl.getCurrentCase() != null)
                {
                    Case cases = CustomContentControl.getCurrentCase();
                    if (datautil.DataStore_HasData(cases) == true) 
                    { 
                       SaveData(cases);
                        this.Close();
                        this.Refresh();
                    }
                    else{
                        Save_Cancel_for_loadData saveform = new Save_Cancel_for_loadData(this);
                        saveform.Location = new Point(this.Location.X + this.Width / 2 - saveform.Width / 2, this.Location.Y + this.Height / 2 - saveform.Height / 2);
                        saveform.ShowDialog();

                    }
                }
             }
            catch (Exception ex)
            {
                MessageBox.Show("An Error occurred during the loading process(Load File)" + ex.Message);
            }
        
        }

        private void generatorDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Object o = generatorDataGrid.SelectedItem;
        }

        public void SaveData(Case cases)
        {
            BusBL busBL = new BusBL();
            foreach (Bus b in buses)
            {
                busBL.createBus(b, cases);
            }
            GeneratorBL generatorBL = new GeneratorBL();
            foreach (Generator g in generators)
            {
                generatorBL.create(g, cases);
            }
            LoadBL loadBL = new LoadBL();
            foreach (Loads l in loadList)
            {
                loadBL.createLoad(cases, l);
            }
            AreaBL areaBL = new AreaBL();
            foreach (Area a in areas)
            {
                areaBL.createArea(a);
            }
            OwnerBL ownerBL = new OwnerBL();
            foreach (Owner o in owners)
            {
                ownerBL.createOwner(o);
            }
            ZoneBL zoneBL = new ZoneBL();
            foreach (Zone z in zones)
            {
                zoneBL.createZone(z);
            }

            C2WTransformerBL c2WTransformerBL = new C2WTransformerBL();

            foreach (C2WTransformer c2w in transformerBranches)
            {
                c2WTransformerBL.create(c2w, cases);
            }

            MultiPhaseLineBL single3Phaseline = new MultiPhaseLineBL();

            foreach (MultiPhaseLine lin in lineBranches)
            {
                single3Phaseline.create(lin, cases);
            }
        }

    }
}


/*   public void TransformersDataInsert(string row)
               {
                   string[] columns = row.Split(',');

                   PSSDTransformersWrapper t = new PSSDTransformersWrapper();
                   long  l = long.Parse(columns[2]);
                   int checkR1x1andPsc = int.Parse(columns[5]);
                   int checkLTC = int.Parse(columns[4]);
                  // int checkZcod = int.Parse(columns[21]);
                   if (l > 0)
                   {
                       TriTransformer W3 = new TriTransformer();

                       W3.PrimaryBUS = FindBusByCode(long.Parse(columns[0]));
                       W3.SecondaryBUS = FindBusByCode(long.Parse(columns[1]));
                       W3.TertiaryBUS = FindBusByCode(long.Parse(columns[2]));
                       W3.Identity = columns[3];
                       *//* Check with Fazel *//*

                       if (checkR1x1andPsc == 2) { W3.impedances.checkPsc = true; }
                       if (checkR1x1andPsc == 1) { W3.impedances.checkR1X1 = true; }
                       //W3.checkedWindingImpedance = long.Parse(columns[4]);
                       // W3.fluxoPhaseB = long.Parse(columns[5]);
                      int i =  int.Parse(columns[6]);
                       W3.impedances.checkMagnetization = 
                       W3.impedances.checkNoLoad = !bool.Parse(columns[6]);
                       if (i==0) {
                           W3.impedances.Magnetization_Conductance = double.Parse(columns[7]);
                           W3.impedances.Magnetization_Susceptance = double.Parse(columns[8]);
                       }
                       else if (i == 1)
                       {
                           W3.impedances.NoLosses = double.Parse(columns[7]);
                           W3.impedances.MagnetizConductace_Current = double.Parse(columns[8]);
                       }

                      // if (checkLTC == 1) { W3.ch}

                       long.Parse(columns[9]);
                       W3.name = (columns[10]);
                       W3.Inservice = bool.Parse(columns[11]);

                       Owner o1 = new Owner();
                       o1.Number = long.Parse(columns[12]);
                       o1.Percentage = float.Parse(columns[13]);
                       Owner o2 = new Owner();
                       o1.Number = long.Parse(columns[14]);
                       o1.Percentage = float.Parse(columns[15]);
                       Owner o3 = new Owner();
                       o1.Number = long.Parse(columns[16]);
                       o1.Percentage = float.Parse(columns[17]);
                       Owner o4 = new Owner();
                       o1.Number = long.Parse(columns[18]);
                       o1.Percentage = float.Parse(columns[19]);

                       List<Owner> owners = new List<Owner>() { o1, o2, o3, o4 };
                       W3.ownerList = owners;
                       string vectorGroup1 = columns[20];
                       string vectorGroup2 = columns[21];

                       if (W3.impedances.checkPsc)
                       {
                           W3.impedances.Z1_HVLV = long.Parse(columns[22]);
                          long.Parse(columns[22]);
                       }




                   }
                   else if (l== 0)
                   {

                       C2WTransformer W2 = new C2WTransformer();
                       W2.PrimaryBUS = FindBusByCode(long.Parse(columns[0]));
                       W2.SecondaryBUS = FindBusByCode(long.Parse(columns[1]));
                       // W2.checkedWindingImpedance = long.Parse(columns[4]);
                       W2.fluxoPhaseB = long.Parse(columns[5]);
                       W2.fluxoPhaseA = long.Parse(columns[6]);
                       W2.fluxoPhaseA = long.Parse(columns[7]);
                       W2.fluxoPhaseA = long.Parse(columns[8]);
                       W2.fluxoPhaseA = long.Parse(columns[9]);
                       W2.fluxoPhaseA = long.Parse(columns[10]);
                       W2.fluxoPhaseA = long.Parse(columns[11]);
                       W2.fluxoPhaseA = long.Parse(columns[12]);
                       W2.fluxoPhaseA = long.Parse(columns[13]);
                       W2.fluxoPhaseA = long.Parse(columns[14]);
                       W2.fluxoPhaseA = long.Parse(columns[15]);
                       W2.fluxoPhaseA = long.Parse(columns[16]);
                       W2.fluxoPhaseA = long.Parse(columns[17]);
                       W2.fluxoPhaseA = long.Parse(columns[18]);
                       W2.fluxoPhaseA = long.Parse(columns[19]);
                       W2.fluxoPhaseA = long.Parse(columns[20]);



                   }
                   t.name = columns[1];
                   // b.voltage = long.Parse(buses[2]);
                   this.transformerTypes.Add(t);

               }*/