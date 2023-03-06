using BL;
using GUI.GUIUtils;
using GUI.New_concept_WPF;
using GUI.Stability;
using GUI.Stability.Generator_Stability;
using network.generator.Gentype;
using persistent.Generator;
using persistent.network.generator_entity;
using persistent.stability;
using persistent.stability.Generator.Stabilizers;
using Syncfusion.WinForms.DataGrid;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace GUI.generator
{
    public partial class SyncGen_main : Form
    {
        /*GeneratorBL generatorBl;
        Generator generator;*/
        SyncGen syncGen;
        SyncGenBL syncGenBL;
        public SyncGen_main()
        {
            InitializeComponent();
            useLDCCombo.DataSource = Enum.GetValues(typeof(LineDropCompensationEnum)).Cast<LineDropCompensationEnum>().ToList();
            useLDCCombo.SelectedItem = LineDropCompensationEnum.No;
            syncGenBL = new SyncGenBL();
            datasetCapabilityCurve();
            //      radioButton2.DataBindings.Add(Shape.Ellipse);

            GeneratorMenuTab.SizeMode = TabSizeMode.FillToRight;

            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.MinimizeBox = true;
            ColorForm.ChangeCollorOFLabel(this);


        }

        public SyncGen_main(SyncGen syncGen)
        {
            InitializeComponent();
            syncGenBL = new SyncGenBL();
            this.syncGen = syncGen;
            loadData(syncGen);
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

        public void loadData(SyncGen syncGen)
        {
            if (syncGen.Bus != null)
            {
                busNumber.Text = syncGen.Bus.BusNumber.ToString();
                busName.Text = syncGen.Bus.BusName.ToString();
            }
            GenInservice.Checked = syncGen.Inservice;


            MaxMWOutputTXT.Text = Convert.ToString(syncGen.powerControl.maxOut);
            MinMWOutputTXT.Text = Convert.ToString(syncGen.powerControl.minOut);
            MWSetPointTXT.Text = Convert.ToString(syncGen.powerControl.setpoint);
            MWOutputTXT.Text = Convert.ToString(syncGen.powerControl.outPut);
            Gen_name.Text = syncGen.Name;
            PartFactorTXT.Text = Convert.ToString(syncGen.powerControl.factor);
            MaxMvarsTXT.Text = Convert.ToString(syncGen.voltageControl.MaxMvars);
            MinMvarsTXT.Text = Convert.ToString(syncGen.voltageControl.MinMvars);
            MvarOutputTXT.Text = Convert.ToString(syncGen.voltageControl.MvarOutput);
            RemoteRegFactorTXT.Text = Convert.ToString(syncGen.voltageControl.RegFactor);
            SetPointVoltageTXT.Text = Convert.ToString(syncGen.voltageControl.SetPointVoltage);
            GeneratorBase.Text = syncGen.Generator_MVA_BASE.ToString();
            GeneratorStepTransR.Text = syncGen.faultParameters.Generatoe_Step_Transformer_R.ToString();
            GeneratorStepTransX.Text = syncGen.faultParameters.Generatoe_Step_Transformer_X.ToString();
            GeneratorStepTransTap.Text = syncGen.faultParameters.Generatoe_Step_Transformer_Tap.ToString();

            NeurraltoGroundImpedanceR.Text = syncGen.faultParameters.Neutral_Ground_Impedance_R.ToString();
            NeurraltoGroundImpedanceX.Text = syncGen.faultParameters.Neutral_Ground_Impedance_X.ToString();

            GenInservice.Checked = syncGen.Inservice;
            AvailableforAVRCheck.Checked = syncGen.powerControl.availableAVR;
            InternalSquenceImpedances_ZeroX.Text = syncGen.faultParameters.ISI_Zero_X.ToString();
            InternalSquenceImpedances_ZeroR.Text = syncGen.faultParameters.ISI_Zero_R.ToString();
            InternalSquenceImpedances_positiveX.Text = syncGen.faultParameters.ISI_Positive_X.ToString();
            InternalSquenceImpedances_positiveR.Text = syncGen.faultParameters.ISI_Positive_R.ToString();
            InternalSquenceImpedances_NegativeX.Text = syncGen.faultParameters.ISI_Negative_X.ToString();
            InternalSquenceImpedances_NegativeR.Text = syncGen.faultParameters.ISI_Negative_R.ToString();
            CapabilityCurve pc1 = new CapabilityCurve();
            pc1.Name = "PC1";
            pc1.MVAR = 0;
            pc1.MW = 0;
            syncGen.capabilityCurves.Add(pc1);
            CapabilityCurve pc2 = new CapabilityCurve();
            pc2.Name = "PC2";
            pc2.MVAR = 0;
            pc2.MW = 0;
            syncGen.capabilityCurves.Add(pc2);
            CapabilityCurve QC1min = new CapabilityCurve();
            QC1min.Name = "QC1min";
            QC1min.MVAR = 0;
            QC1min.MW = 0;
            syncGen.capabilityCurves.Add(QC1min);
            CapabilityCurve QC1max = new CapabilityCurve();
            QC1max.Name = "QC1max";
            QC1max.MVAR = 0;
            QC1max.MW = 0;
            syncGen.capabilityCurves.Add(QC1max);
            CapabilityCurve QC2min = new CapabilityCurve();
            QC2min.Name = "QC2min";
            QC2min.MVAR = 0;
            QC2min.MW = 0;
            syncGen.capabilityCurves.Add(QC2min);
            CapabilityCurve QC2max = new CapabilityCurve();
            QC2max.Name = "QC2max";
            QC2max.MVAR = 0;
            QC2max.MW = 0;
            syncGen.capabilityCurves.Add(QC2max);
            // name.Text = generator.Name;
            code.Text = syncGen.Code.ToString();
            powerFactorTXT.Text = syncGen.windControlMode.PowerFactor.ToString();
            CapabilityCurveDataGrid.DataSource = syncGen.capabilityCurves;

        }
        public Boolean save()
        {
            try
            {

                if (syncGen.Bus != null)
                {
                    syncGen.Bus.BusNumber = long.Parse(busNumber.Text);
                    syncGen.Bus.BusName = busName.Text;
                }

                syncGen.Inservice = GenInservice.Checked;

                syncGen.powerControl.maxOut = float.Parse(MaxMWOutputTXT.Text);
                syncGen.powerControl.minOut = float.Parse(MinMWOutputTXT.Text);
                syncGen.powerControl.setpoint = float.Parse(MWSetPointTXT.Text);
                syncGen.powerControl.outPut = float.Parse(MWOutputTXT.Text);

                syncGen.powerControl.factor = float.Parse(PartFactorTXT.Text);
                syncGen.voltageControl.MaxMvars = float.Parse(MaxMvarsTXT.Text);
                syncGen.voltageControl.MinMvars = float.Parse(MinMvarsTXT.Text);
                syncGen.voltageControl.MvarOutput = float.Parse(MvarOutputTXT.Text);
                syncGen.voltageControl.RegFactor = float.Parse(RemoteRegFactorTXT.Text);
                syncGen.voltageControl.SetPointVoltage = float.Parse(SetPointVoltageTXT.Text);

                syncGen.Generator_MVA_BASE = double.Parse(GeneratorBase.Text);
                syncGen.faultParameters.Generatoe_Step_Transformer_R = double.Parse(GeneratorStepTransR.Text);
                syncGen.faultParameters.Generatoe_Step_Transformer_X = double.Parse(GeneratorStepTransX.Text);
                syncGen.faultParameters.Generatoe_Step_Transformer_Tap = double.Parse(GeneratorStepTransTap.Text);

                syncGen.faultParameters.Neutral_Ground_Impedance_R = double.Parse(NeurraltoGroundImpedanceR.Text);
                syncGen.faultParameters.Neutral_Ground_Impedance_X = double.Parse(NeurraltoGroundImpedanceX.Text);

                syncGen.powerControl.availableAVR = AvailableforAVRCheck.Checked;
                syncGen.faultParameters.ISI_Zero_X = double.Parse(InternalSquenceImpedances_ZeroX.Text);
                syncGen.faultParameters.ISI_Zero_R = double.Parse(InternalSquenceImpedances_ZeroR.Text);
                syncGen.faultParameters.ISI_Positive_X = double.Parse(InternalSquenceImpedances_positiveX.Text);
                syncGen.faultParameters.ISI_Positive_R = double.Parse(InternalSquenceImpedances_positiveR.Text);
                syncGen.faultParameters.ISI_Negative_X = double.Parse(InternalSquenceImpedances_NegativeX.Text);
                syncGen.faultParameters.ISI_Negative_R = double.Parse(InternalSquenceImpedances_NegativeR.Text);
                syncGen.Code = long.Parse(code.Text);
                syncGen.windControlMode.PowerFactor = double.Parse(powerFactorTXT.Text);
                syncGenBL.edit(syncGen, CustomContentControl.getCurrentCase());
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



        public SyncGen getSyncGen()
        {
            return syncGen;
        }

        private void setSyncGen(SyncGen syncGen)
        {
            this.syncGen = syncGen;
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
            ModelTypeMenu modalTypeMenu = new ModelTypeMenu(persistent.enumeration.StabilityType.Generator, StabilityGeneratorTabEnum.MachineModels);
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
            else if (((LineDropCompensationEnum)useLDCCombo.SelectedItem).Equals(LineDropCompensationEnum.Yes))
            {

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
            ModelTypeMenu modalTypeMenu = new ModelTypeMenu(persistent.enumeration.StabilityType.Generator, StabilityGeneratorTabEnum.Exciters);
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
