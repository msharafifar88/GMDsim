using network;
using persistent.enumeration;
using persistent.line;
using Syncfusion.WinForms.DataGrid;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;



namespace GUI.Line.Condcutor_Data
{
    public partial class Cable_Standard : UserControl
    {
        LineBranches lineBranches;
        public Cable_Standard(LineBranches line)
        {
            InitializeComponent();
            lineBranches = line;
            setupCableDataGrid();
            setupConductorDataGrid();
            CreateConductorData();
            lengthTypeUnit.DataSource = Enum.GetValues(typeof(LengthUnitType)).Cast<LengthUnitType>().ToList();
            cableTypeCombo.DataSource = Enum.GetValues(typeof(CableTypeEnum)).Cast<CableTypeEnum>().ToList();
            lengthTypeUnit.SelectedItem = LengthUnitType.Metric;
            cableDataGrid.AutoSizeColumnsMode = Syncfusion.WinForms.DataGrid.Enums.AutoSizeColumnsMode.Fill;
        }



        public void setupCableDataGrid()
        {
            cableDataGrid.AutoGenerateColumns = false;
            cableDataGrid.Columns.Add(new GridTextColumn() { MappingName = "CableNumber", HeaderText = "Cable Number" });
            cableDataGrid.Columns.Add(new GridTextColumn() { MappingName = "NumberofConductor", HeaderText = "Number of Conductor" });
            cableDataGrid.Columns.Add(new GridTextColumn() { MappingName = "VerticalDistance", HeaderText = "Vertical Distance" });
            cableDataGrid.Columns.Add(new GridTextColumn() { MappingName = "HorizontalDistance", HeaderText = "Horizontal Distance" });
            cableDataGrid.Columns.Add(new GridTextColumn() { MappingName = "VerticalDistance", HeaderText = "Distance from center of pip (m)" });
            cableDataGrid.Columns.Add(new GridTextColumn() { MappingName = "HorizontalDistance", HeaderText = "Position Angle (deg)" });
            cableDataGrid.Columns.Add(new GridTextColumn() { MappingName = "OuterInsulationRadius", HeaderText = "Outer Insulation Radius" });
        }
        public void setupConductorDataGrid()
        {
            conductorDataGrid.AutoGenerateColumns = false;
            conductorDataGrid.Columns.Add(new GridTextColumn() { MappingName = "CableNumber", HeaderText = "Cable Number" });
            conductorDataGrid.Columns.Add(new GridTextColumn() { MappingName = "ConductorNumber", HeaderText = "Conductor Number" });
            conductorDataGrid.Columns.Add(new GridTextColumn() { MappingName = "InsideRadiudRIn", HeaderText = "Inside Radiud RIn [m]" });
            conductorDataGrid.Columns.Add(new GridTextColumn() { MappingName = "OutsideRadiudRIn", HeaderText = "Outside Radiud Rout [m]" });
            conductorDataGrid.Columns.Add(new GridTextColumn() { MappingName = "ResistivityRho", HeaderText = "Resistivity Rho [ohm-m]" });
            conductorDataGrid.Columns.Add(new GridTextColumn() { MappingName = "RelativePremeability", HeaderText = "Relative Premeability MUE" });
            conductorDataGrid.Columns.Add(new GridTextColumn() { MappingName = "InsulatorRelativePermeability", HeaderText = "Insulator Relative Permeability MUE-IN" });
            conductorDataGrid.Columns.Add(new GridTextColumn() { MappingName = "InsulatorRelativePermittivity", HeaderText = "Insulator Relative Permittivity EPS-IN" });
            conductorDataGrid.Columns.Add(new GridTextColumn() { MappingName = "InsulatorLossFactor", HeaderText = "Insulator Loss Factor LFCT-IN" });
            conductorDataGrid.Columns.Add(new GridTextColumn() { MappingName = "PhaseNumber", HeaderText = "Phase Number KPH" });
        }
        public void CreateConductorData()
        {
            List<CableData> collection = new List<CableData>();
            List<ConductorData> conductorList = new List<ConductorData>();
            // lineBranches = new LineBranches();
            for (int i = 0; i < numberOfCablesval.Value; i++)
            {
                CableData cableData = new CableData();
                cableData.CableNumber = i + 1;
                List<ConductorData> conductors = new List<ConductorData>();
                for (int j = 0; j < cableData.NumberofConductor; j++)
                {
                    ConductorData conductor = new ConductorData();
                    conductor.CableNumber = i + 1;
                    conductor.ConductorNumber = j + 1;
                    conductors.Add(conductor);
                    conductorList.Add(conductor);
                }
                cableData.conductorDatas = conductors;



                conductorDataGrid.AutoSizeColumnsMode = Syncfusion.WinForms.DataGrid.Enums.AutoSizeColumnsMode.Fill;


                collection.Add(cableData);

            }

            conductorDataGrid.DataSource = conductorList;

            conductorDataGrid.TableControl.HorizontalScrollBarVisible = true;



            lineBranches.LineConductor.CableDatas = collection;
            cableDataGrid.DataSource = lineBranches.LineConductor.CableDatas;

        }
        private void numberOfCablesval_ValueChanged(object sender, EventArgs e)
        {
            CreateConductorData();
        }
        private void cableTypeCombo_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cableTypeCombo.SelectedItem.Equals(CableTypeEnum.SingleCore))

            {
                cableDataGrid.Columns[4].Visible = false;
                cableDataGrid.Columns[5].Visible = false;
                cableDataGrid.Columns[2].Visible = true;
                cableDataGrid.Columns[3].Visible = true;

            }

            else if (cableTypeCombo.SelectedItem.Equals(CableTypeEnum.PiPType))

            {
                cableDataGrid.Columns[4].Visible = true;
                cableDataGrid.Columns[5].Visible = true;
                cableDataGrid.Columns[2].Visible = false;
                cableDataGrid.Columns[3].Visible = false;

            }



        }
        private void lengthTypeUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lengthTypeUnit.SelectedItem.Equals(LengthUnitType.Metric))
            {
                labkm.Visible = true;
                labeMile.Visible = false;

            }
            else
            {
                labkm.Visible = false;
                labeMile.Visible = true;
            }
        }


        private void Cable_Standard_Leave(object sender, EventArgs e)
        {
            MessageBox.Show("Don't Leave ME");
        }


    }
}
