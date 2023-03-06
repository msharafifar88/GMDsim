using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BL;
using network;

using areaandzone;
using persistent.power;
using GUI.New_concept_WPF;
using Syncfusion.WinForms.DataGrid;
using GUI.Stability.Generator_Stability;
using persistent.Generator;
using GUI.Stability;
using persistent.stability;
using persistent.stability.Generator.Stabilizers;
using GUI.GUIUtils;
using network.generator.Gentype;
using persistent.network.generator_entity;

namespace GUI.generator
{
    public partial class WindGenerator_Main : Form
    {
        WindGenBL windGenBL;
        WindGen windGen;
        public WindGenerator_Main()
        {
            InitializeComponent();
            useLDCCombo.DataSource = Enum.GetValues(typeof(LineDropCompensationEnum)).Cast<LineDropCompensationEnum>().ToList();
            useLDCCombo.SelectedItem = LineDropCompensationEnum.No;
            windGenBL = new WindGenBL();
            datasetCapabilityCurve();
            //      radioButton2.DataBindings.Add(Shape.Ellipse);

            GeneratorMenuTab.SizeMode = TabSizeMode.FillToRight;
           
                this.FormBorderStyle = FormBorderStyle.Sizable;
                this.MaximizeBox = true;
                this.MinimizeBox = true;
            ColorForm.ChangeCollorOFLabel(this);
           

        }

        public WindGenerator_Main(WindGen windGen)
        {
            InitializeComponent();
            windGenBL = new WindGenBL();
            this.windGen = windGen;
            loadData(windGen);
            datasetCapabilityCurve();
            //      radioButton2.DataBindings.Add(Shape.Ellipse);
        }

        public void datasetCapabilityCurve()
        {
            this.CapabilityCurveDataGrid.AutoGenerateRelations = false;
            this.CapabilityCurveDataGrid.AutoSizeColumnsMode = Syncfusion.WinForms.DataGrid.Enums.AutoSizeColumnsMode.Fill;

            CapabilityCurveDataGrid.Columns.Add(new GridTextColumn() { MappingName = "Name", HeaderText = "Name" });
            CapabilityCurveDataGrid.Columns.Add(new GridTextColumn() { MappingName = "MW", HeaderText = "MW" });
            CapabilityCurveDataGrid.Columns.Add(new GridTextColumn() { MappingName = "MVAR", HeaderText = "MVAR" });

        }

        public void loadData(WindGen windGen)
        {

            if (windGen.Bus != null)
                {
                    busNumber.Text = windGen.Bus.BusNumber.ToString();
                    busName.Text = windGen.Bus.BusName.ToString();
                }
            GenInservice.Checked = windGen.Inservice;

            MaxMWOutputTXT.Text = Convert.ToString(windGen.powerControl.maxOut);
            MinMWOutputTXT.Text = Convert.ToString(windGen.powerControl.minOut);
            MWSetPointTXT.Text = Convert.ToString(windGen.powerControl.setpoint);
            MWOutputTXT.Text = Convert.ToString(windGen.powerControl.outPut);
            Gen_name.Text = windGen.Name;
            PartFactorTXT.Text = Convert.ToString(windGen.powerControl.factor);
            MaxMvarsTXT.Text = Convert.ToString(windGen.voltageControl.MaxMvars);
            MinMvarsTXT.Text = Convert.ToString(windGen.voltageControl.MinMvars);
            MvarOutputTXT.Text = Convert.ToString(windGen.voltageControl.MvarOutput);
            RemoteRegFactorTXT.Text = Convert.ToString(windGen.voltageControl.RegFactor);
            SetPointVoltageTXT.Text = Convert.ToString(windGen.voltageControl.SetPointVoltage);
            GeneratorBase.Text = windGen.Generator_MVA_BASE.ToString();
            GeneratorStepTransR.Text = windGen.faultParameters.Generatoe_Step_Transformer_R.ToString();
            GeneratorStepTransX.Text = windGen.faultParameters.Generatoe_Step_Transformer_X.ToString();
            GeneratorStepTransTap.Text = windGen.faultParameters.Generatoe_Step_Transformer_Tap.ToString();

            NeurraltoGroundImpedanceR.Text = windGen.faultParameters.Neutral_Ground_Impedance_R.ToString();
            NeurraltoGroundImpedanceX.Text = windGen.faultParameters.Neutral_Ground_Impedance_X.ToString();

            GenInservice.Checked = windGen.Inservice;
            AvailableforAVRCheck.Checked = windGen.powerControl.availableAVR;
            InternalSquenceImpedances_ZeroX.Text = windGen.faultParameters.ISI_Zero_X.ToString();
            InternalSquenceImpedances_ZeroR.Text = windGen.faultParameters.ISI_Zero_R.ToString();
            InternalSquenceImpedances_positiveX.Text = windGen.faultParameters.ISI_Positive_X.ToString();
            InternalSquenceImpedances_positiveR.Text = windGen.faultParameters.ISI_Positive_R.ToString();
            InternalSquenceImpedances_NegativeX.Text = windGen.faultParameters.ISI_Negative_X.ToString();
            InternalSquenceImpedances_NegativeR.Text = windGen.faultParameters.ISI_Negative_R.ToString();
            CapabilityCurve pc1 = new CapabilityCurve();
            pc1.Name = "PC1";
            pc1.MVAR = 0;
            pc1.MW = 0;
            windGen.capabilityCurves.Add(pc1);
            CapabilityCurve pc2 = new CapabilityCurve();
            pc2.Name = "PC2";
            pc2.MVAR = 0;
            pc2.MW = 0;
            windGen.capabilityCurves.Add(pc2);
            CapabilityCurve QC1min = new CapabilityCurve();
            QC1min.Name = "QC1min";
            QC1min.MVAR = 0;
            QC1min.MW = 0;
            windGen.capabilityCurves.Add(QC1min);
            CapabilityCurve QC1max = new CapabilityCurve();
            QC1max.Name = "QC1max";
            QC1max.MVAR = 0;
            QC1max.MW = 0;
            windGen.capabilityCurves.Add(QC1max);
            CapabilityCurve QC2min = new CapabilityCurve();
            QC2min.Name = "QC2min";
            QC2min.MVAR = 0;
            QC2min.MW = 0;
            windGen.capabilityCurves.Add(QC2min);
            CapabilityCurve QC2max = new CapabilityCurve();
            QC2max.Name = "QC2max";
            QC2max.MVAR = 0;
            QC2max.MW = 0;
            windGen.capabilityCurves.Add(QC2max);
            // name.Text = generator.Name;
            code.Text = windGen.Code.ToString();
            powerFactorTXT.Text = windGen.windControlMode.PowerFactor.ToString();
            CapabilityCurveDataGrid.DataSource = windGen.capabilityCurves;


        }
        public Boolean save()
        {
            try
            {
                if (windGen.Bus != null)
                {
                    windGen.Bus.BusNumber = long.Parse(busNumber.Text);
                    windGen.Bus.BusName = busName.Text;
                }
                windGen.Inservice = GenInservice.Checked;

                windGen.powerControl.maxOut = float.Parse(MaxMWOutputTXT.Text);
                windGen.powerControl.minOut = float.Parse(MinMWOutputTXT.Text);
                windGen.powerControl.setpoint = float.Parse(MWSetPointTXT.Text);
                windGen.powerControl.outPut = float.Parse(MWOutputTXT.Text);
                windGen.Name = Gen_name.Text;
                windGen.powerControl.factor = float.Parse(PartFactorTXT.Text);
                windGen.voltageControl.MaxMvars = float.Parse(MaxMvarsTXT.Text);
                windGen.voltageControl.MinMvars = float.Parse(MinMvarsTXT.Text);
                windGen.voltageControl.MvarOutput = float.Parse(MvarOutputTXT.Text);
                windGen.voltageControl.RegFactor = float.Parse(RemoteRegFactorTXT.Text);
                windGen.voltageControl.SetPointVoltage = float.Parse(SetPointVoltageTXT.Text);

                windGen.Generator_MVA_BASE = double.Parse(GeneratorBase.Text);
                windGen.faultParameters.Generatoe_Step_Transformer_R = double.Parse(GeneratorStepTransR.Text);
                windGen.faultParameters.Generatoe_Step_Transformer_X = double.Parse(GeneratorStepTransX.Text);
                windGen.faultParameters.Generatoe_Step_Transformer_Tap = double.Parse(GeneratorStepTransTap.Text);

                windGen.faultParameters.Neutral_Ground_Impedance_R = double.Parse(NeurraltoGroundImpedanceR.Text);
                windGen.faultParameters.Neutral_Ground_Impedance_X = double.Parse(NeurraltoGroundImpedanceX.Text);

                windGen.powerControl.availableAVR = AvailableforAVRCheck.Checked;
                windGen.faultParameters.ISI_Zero_X = double.Parse(InternalSquenceImpedances_ZeroX.Text);
                windGen.faultParameters.ISI_Zero_R = double.Parse(InternalSquenceImpedances_ZeroR.Text);
                windGen.faultParameters.ISI_Positive_X = double.Parse(InternalSquenceImpedances_positiveX.Text);
                windGen.faultParameters.ISI_Positive_R = double.Parse(InternalSquenceImpedances_positiveR.Text);
                windGen.faultParameters.ISI_Negative_X = double.Parse(InternalSquenceImpedances_NegativeX.Text);
                windGen.faultParameters.ISI_Negative_R = double.Parse(InternalSquenceImpedances_NegativeR.Text);
                windGen.Code = long.Parse(code.Text);
                windGen.windControlMode.PowerFactor = double.Parse(powerFactorTXT.Text);

                windGenBL.edit(windGen, CustomContentControl.getCurrentCase());
                return true;
            }
            catch
            {
                MessageBox.Show("Save Record Exception");
                return false;
            }


        }
        private void savebtn_Click(object sender, EventArgs e)
        {
            save();

        }

        private void cancelbtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void OKbtn_Click(object sender, EventArgs e)
        {

            save();
            Close();
        }

        private void displayTab_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        public WindGen getWindGen()
        {
            return windGen;
        }

        private void setGWindGen(WindGen windGen)
        {
            this.windGen = windGen;
        }

        private void TypeStabilityRelayCombo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void buttonRelay_Delete_Click(object sender, EventArgs e)
        {

        }

        private void buttonRelayInsert_Click(object sender, EventArgs e)
        {

        }

        private void checkBoxRelayStat_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void buttonSet_to_defaults_Click(object sender, EventArgs e)
        {

        }

        public void addPannel()

        {
            GenROU genROU = new GenROU();


            genROU.TopLevel = false;
            ParametersPanel.Controls.Add(genROU);
            genROU.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            genROU.Dock = DockStyle.Fill;
            genROU.Show();

        }

        private void buttonRelayInsert_Click_1(object sender, EventArgs e)
        {
            ModelTypeMenu modalTypeMenu = new ModelTypeMenu(persistent.enumeration.StabilityType.Generator,StabilityGeneratorTabEnum.MachineModels);
            modalTypeMenu.ShowDialog();
            var selectModel = modalTypeMenu.getSelectedModel();
            if (selectModel != null)
            {
                StabilityForm form = StabilityCreator.CreateForm((GeneratorModelType)selectModel);
                if (form != null)
                {
                    TypeStabilityRelayCombo.Items.Add(form.GetStability());
                    TypeStabilityRelayCombo.SelectedItem = form.GetStability();
                    ParametersPanel.Controls.Add(form);
                    form.Show();
                }
            }
        }

        private void UseCapabilityCurveCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (UseCapabilityCurveCheck.Checked == false)
            {
                CapabilityCurveDataGrid.Enabled = false;
              //  CapabilityCurveDataGrid.ReadOnly = false;
            }
            else if (UseCapabilityCurveCheck.Checked == true)
            {

                CapabilityCurveDataGrid.Enabled = true;
              //  CapabilityCurveDataGrid.ReadOnly = true;
            }
        }

        private void useLDCCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((LineDropCompensationEnum)useLDCCombo.SelectedItem).Equals(LineDropCompensationEnum.No))
            {
                xcompTXT.Enabled = false;
                rcompTXT.Enabled = false;
                voltageDroopControl.Enabled = false;

            }
            else if(((LineDropCompensationEnum)useLDCCombo.SelectedItem).Equals(LineDropCompensationEnum.Yes)){

                xcompTXT.Enabled = true;
                rcompTXT.Enabled = true;
                voltageDroopControl.Enabled = false;
            }
            else if (((LineDropCompensationEnum)useLDCCombo.SelectedItem).Equals(LineDropCompensationEnum.PostCTG))
            {

                xcompTXT.Enabled = true;
                rcompTXT.Enabled = true;
                voltageDroopControl.Enabled = true;
            }
        }

        private void ParametersPanel_Enter(object sender, EventArgs e)
        {

        }

        private void ExcitersInsertButton_Click(object sender, EventArgs e)
        {
            ModelTypeMenu modalTypeMenu = new ModelTypeMenu(persistent.enumeration.StabilityType.Generator,StabilityGeneratorTabEnum.Exciters);
            modalTypeMenu.ShowDialog();
            var selectModel = modalTypeMenu.getSelectedModel();
            if (selectModel != null) 
            { 
                StabilityForm form = StabilityCreator.CreateForm((GeneratorExcitersModelType)selectModel);
                if (form != null)
                {
                    GenExcitCombo.Items.Add(form.GetStability());
                    GenExcitCombo.SelectedItem = form.GetStability();
                    GenExitersPanel.Controls.Add(form);
                    form.Show();
                }
            }
        }

        private void GovernorsInsertButton_SelectedIndexChanged(object sender, EventArgs e)
        {
            ModelTypeMenu modalTypeMenu = new ModelTypeMenu(persistent.enumeration.StabilityType.Generator, StabilityGeneratorTabEnum.Governors);
            modalTypeMenu.ShowDialog();
            var selectModel = modalTypeMenu.getSelectedModel();
            if (selectModel != null)
            {
                StabilityForm form = StabilityCreator.CreateForm((GeneratorGovernorsModelType)selectModel);
                if (form != null)
                {
                    GenGovernorsCombo.Items.Add(form.GetStability());
                    GenGovernorsCombo.SelectedItem = form.GetStability();
                    GenGovernerPanel.Controls.Add(form);
                    form.Show();
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BusSetpointValues_Click(object sender, EventArgs e)
        {

        }

        private void StabilizersInsertButton_Click(object sender, EventArgs e)
        {
            ModelTypeMenu modalTypeMenu = new ModelTypeMenu(persistent.enumeration.StabilityType.Generator, StabilityGeneratorTabEnum.Stabiizers);
            modalTypeMenu.ShowDialog();
            var selectModel = modalTypeMenu.getSelectedModel();
            if (selectModel != null)
            {
                StabilityForm form = StabilityCreator.CreateForm((GeneratorStabilizersModelType)selectModel);
                if (form != null)
                {
                    GenGovernorsCombo.Items.Add(form.GetStability());
                    GenGovernorsCombo.SelectedItem = form.GetStability();
                    GenGovernerPanel.Controls.Add(form);
                    form.Show();
                }
            }

        }

        private void AvailableforAVRCheck_CheckStateChanged(object sender, EventArgs e)
        {
            if (AvailableforAVRCheck.Checked == false)
            {

                RegulatedBusNumberTXT.ReadOnly = true;
                SetPointVoltageTXT.ReadOnly = true;
                SetPointVoltageTolTXT.ReadOnly = true;
                RemoteRegFactorTXT.ReadOnly = true;

            }
            else if (AvailableforAVRCheck.Checked == true)
            {
                RegulatedBusNumberTXT.ReadOnly = false;
                SetPointVoltageTXT.ReadOnly = false;
                SetPointVoltageTolTXT.ReadOnly = false;
                RemoteRegFactorTXT.ReadOnly = false;
            }
        }

        private void GenInservice_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (GenInservice.Checked == true)
                {
                    GenInservice.Checked = true;

                    //   (Main_Menu.GetClickedDiagramBus() as CoreConnector).setInserviceBus(false);
                    //(Main_Menu.GetClickedDiagramBus() as CoreConnector).setInserviceGenerator(true);

                }
                else if (GenInservice.Checked == false)
                {

                    //   (Main_Menu.GetClickedDiagramBus() as CoreConnector).setInserviceBus(true);
                    GenInservice.Checked = false;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
    
}
