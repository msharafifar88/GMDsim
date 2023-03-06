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
    public partial class PV_Main : Form
    {
        PVGenBL pvGenBl;
        PVGen pvGen;
        public PV_Main()
        {
            InitializeComponent();
            useLDCCombo.DataSource = Enum.GetValues(typeof(LineDropCompensationEnum)).Cast<LineDropCompensationEnum>().ToList();
            useLDCCombo.SelectedItem = LineDropCompensationEnum.No;
            pvGenBl = new PVGenBL();
            datasetCapabilityCurve();
            //      radioButton2.DataBindings.Add(Shape.Ellipse);

            GeneratorMenuTab.SizeMode = TabSizeMode.FillToRight;
           
                this.FormBorderStyle = FormBorderStyle.Sizable;
                this.MaximizeBox = true;
                this.MinimizeBox = true;
            ColorForm.ChangeCollorOFLabel(this);
           

        }

        public PV_Main(PVGen pvGen)
        {
            InitializeComponent();
            pvGenBl = new PVGenBL();
            this.pvGen = pvGen;
            loadData(pvGen);
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

        public void loadData(PVGen pvgen)
        {

            if (pvgen.Bus != null)
            {
                busNumber.Text = pvgen.Bus.BusNumber.ToString();
                busName.Text = pvgen.Bus.BusName.ToString();
            }
            GenInservice.Checked = pvgen.Inservice;

            MaxMWOutputTXT.Text = Convert.ToString(pvgen.powerControl.maxOut);
            MinMWOutputTXT.Text = Convert.ToString(pvgen.powerControl.minOut);
            MWSetPointTXT.Text = Convert.ToString(pvgen.powerControl.setpoint);
            MWOutputTXT.Text = Convert.ToString(pvgen.powerControl.outPut);
            Gen_name.Text = pvgen.Name;
            PartFactorTXT.Text = Convert.ToString(pvgen.powerControl.factor);
            MaxMvarsTXT.Text = Convert.ToString(pvgen.voltageControl.MaxMvars);
            MinMvarsTXT.Text = Convert.ToString(pvgen.voltageControl.MinMvars);
            MvarOutputTXT.Text = Convert.ToString(pvgen.voltageControl.MvarOutput);
            RemoteRegFactorTXT.Text = Convert.ToString(pvgen.voltageControl.RegFactor);
            SetPointVoltageTXT.Text = Convert.ToString(pvgen.voltageControl.SetPointVoltage);
            GeneratorBase.Text = pvgen.Generator_MVA_BASE.ToString();
            GeneratorStepTransR.Text = pvgen.faultParameters.Generatoe_Step_Transformer_R.ToString();
            GeneratorStepTransX.Text = pvgen.faultParameters.Generatoe_Step_Transformer_X.ToString();
            GeneratorStepTransTap.Text = pvgen.faultParameters.Generatoe_Step_Transformer_Tap.ToString();

            NeurraltoGroundImpedanceR.Text = pvgen.faultParameters.Neutral_Ground_Impedance_R.ToString();
            NeurraltoGroundImpedanceX.Text = pvgen.faultParameters.Neutral_Ground_Impedance_X.ToString();

            GenInservice.Checked = pvgen.Inservice;
            AvailableforAVRCheck.Checked = pvgen.powerControl.availableAVR;
            InternalSquenceImpedances_ZeroX.Text = pvgen.faultParameters.ISI_Zero_X.ToString();
            InternalSquenceImpedances_ZeroR.Text = pvgen.faultParameters.ISI_Zero_R.ToString();
            InternalSquenceImpedances_positiveX.Text = pvgen.faultParameters.ISI_Positive_X.ToString();
            InternalSquenceImpedances_positiveR.Text = pvgen.faultParameters.ISI_Positive_R.ToString();
            InternalSquenceImpedances_NegativeX.Text = pvgen.faultParameters.ISI_Negative_X.ToString();
            InternalSquenceImpedances_NegativeR.Text = pvgen.faultParameters.ISI_Negative_R.ToString();
            CapabilityCurve pc1 = new CapabilityCurve();
            pc1.Name = "PC1";
            pc1.MVAR = 0;
            pc1.MW = 0;
            pvgen.capabilityCurves.Add(pc1);
            CapabilityCurve pc2 = new CapabilityCurve();
            pc2.Name = "PC2";
            pc2.MVAR = 0;
            pc2.MW = 0;
            pvgen.capabilityCurves.Add(pc2);
            CapabilityCurve QC1min = new CapabilityCurve();
            QC1min.Name = "QC1min";
            QC1min.MVAR = 0;
            QC1min.MW = 0;
            pvgen.capabilityCurves.Add(QC1min);
            CapabilityCurve QC1max = new CapabilityCurve();
            QC1max.Name = "QC1max";
            QC1max.MVAR = 0;
            QC1max.MW = 0;
            pvgen.capabilityCurves.Add(QC1max);
            CapabilityCurve QC2min = new CapabilityCurve();
            QC2min.Name = "QC2min";
            QC2min.MVAR = 0;
            QC2min.MW = 0;
            pvgen.capabilityCurves.Add(QC2min);
            CapabilityCurve QC2max = new CapabilityCurve();
            QC2max.Name = "QC2max";
            QC2max.MVAR = 0;
            QC2max.MW = 0;
            pvgen.capabilityCurves.Add(QC2max);
            // name.Text = generator.Name;
            code.Text = pvgen.Code.ToString();
            powerFactorTXT.Text = pvgen.windControlMode.PowerFactor.ToString();
            CapabilityCurveDataGrid.DataSource = pvgen.capabilityCurves;


        }
        public Boolean save()
        {
            try
            {

                if (pvGen.Bus != null)
                {
                    pvGen.Bus.BusNumber = long.Parse(busNumber.Text);
                    pvGen.Bus.BusName = busName.Text;
                }
                pvGen.Inservice = GenInservice.Checked;

                pvGen.powerControl.maxOut = float.Parse(MaxMWOutputTXT.Text);
                pvGen.powerControl.minOut = float.Parse(MinMWOutputTXT.Text);
                pvGen.powerControl.setpoint = float.Parse(MWSetPointTXT.Text);
                pvGen.powerControl.outPut = float.Parse(MWOutputTXT.Text);
                pvGen.Name = Gen_name.Text;
                pvGen.powerControl.factor = float.Parse(PartFactorTXT.Text);
                pvGen.voltageControl.MaxMvars = float.Parse(MaxMvarsTXT.Text);
                pvGen.voltageControl.MinMvars = float.Parse(MinMvarsTXT.Text);
                pvGen.voltageControl.MvarOutput = float.Parse(MvarOutputTXT.Text);
                pvGen.voltageControl.RegFactor = float.Parse(RemoteRegFactorTXT.Text);
                pvGen.voltageControl.SetPointVoltage = float.Parse(SetPointVoltageTXT.Text);

                pvGen.Generator_MVA_BASE = double.Parse(GeneratorBase.Text);
                pvGen.faultParameters.Generatoe_Step_Transformer_R = double.Parse(GeneratorStepTransR.Text);
                pvGen.faultParameters.Generatoe_Step_Transformer_X = double.Parse(GeneratorStepTransX.Text);
                pvGen.faultParameters.Generatoe_Step_Transformer_Tap = double.Parse(GeneratorStepTransTap.Text);

                pvGen.faultParameters.Neutral_Ground_Impedance_R = double.Parse(NeurraltoGroundImpedanceR.Text);
                pvGen.faultParameters.Neutral_Ground_Impedance_X = double.Parse(NeurraltoGroundImpedanceX.Text);

                pvGen.powerControl.availableAVR = AvailableforAVRCheck.Checked;
                pvGen.faultParameters.ISI_Zero_X = double.Parse(InternalSquenceImpedances_ZeroX.Text);
                pvGen.faultParameters.ISI_Zero_R = double.Parse(InternalSquenceImpedances_ZeroR.Text);
                pvGen.faultParameters.ISI_Positive_X = double.Parse(InternalSquenceImpedances_positiveX.Text);
                pvGen.faultParameters.ISI_Positive_R = double.Parse(InternalSquenceImpedances_positiveR.Text);
                pvGen.faultParameters.ISI_Negative_X = double.Parse(InternalSquenceImpedances_NegativeX.Text);
                pvGen.faultParameters.ISI_Negative_R = double.Parse(InternalSquenceImpedances_NegativeR.Text);
                pvGen.Code = long.Parse(code.Text);
                pvGen.windControlMode.PowerFactor = double.Parse(powerFactorTXT.Text);

                pvGenBl.edit(pvGen, CustomContentControl.getCurrentCase());
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
        public PVGen getPVGen()
        {
            return pvGen;
        }

        private void setPVGen(PVGen pvgen)
        {
            this.pvGen = pvgen;
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
