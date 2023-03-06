using System;
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
using persistent.network.generator_entity;

namespace GUI.generator
{
    public partial class Generator_Main : Form
    {
        GeneratorBL generatorBl;
        Generator generator;
      
        public Generator_Main()
        {
            InitializeComponent();
            useLDCCombo.DataSource = Enum.GetValues(typeof(LineDropCompensationEnum)).Cast<LineDropCompensationEnum>().ToList();
            useLDCCombo.SelectedItem = LineDropCompensationEnum.No;
            generatorBl = new GeneratorBL();
            datasetCapabilityCurve();
            //      radioButton2.DataBindings.Add(Shape.Ellipse);

            GeneratorMenuTab.SizeMode = TabSizeMode.FillToRight;
           
                this.FormBorderStyle = FormBorderStyle.Sizable;
                this.MaximizeBox = true;
                this.MinimizeBox = true;
            ColorForm.ChangeCollorOFLabel(this);
           

        }

        public Generator_Main(Generator generator)
        {
            InitializeComponent();

            generatorBl = new GeneratorBL();
            this.generator = generator;
      
            // cc.

            
            loadData(generator);
            datasetCapabilityCurve();

           
            // CapabilityCurveDataGrid.Columns.Add(new grid)

            //      radioButton2.DataBindings.Add(Shape.Ellipse);
        }

        public void datasetCapabilityCurve()
        {
            this.CapabilityCurveDataGrid.AutoGenerateRelations = false;
            this.CapabilityCurveDataGrid.AutoSizeColumnsMode = Syncfusion.WinForms.DataGrid.Enums.AutoSizeColumnsMode.Fill;
            
            CapabilityCurveDataGrid.Columns.Add(new GridTextColumn() { MappingName = "Name", HeaderText = "Name" });
            CapabilityCurveDataGrid.Columns.Add(new GridTextColumn() { MappingName = "MW", HeaderText = "MW" });
            CapabilityCurveDataGrid.Columns.Add(new GridTextColumn() { MappingName = "MVAR", HeaderText = "MVAR" });

           
            // CapabilityCurveDataGrid.Columns.Add(new grid)

        }

        public void loadData(Generator generator)
        {
            if (generator.Bus != null)
            {
                busNumber.Text = generator.Bus.BusNumber.ToString();
                busName.Text = generator.Bus.BusName.ToString();
            }
            GenInservice.Checked = generator.Inservice;
          
            MaxMWOutputTXT.Text = Convert.ToString(generator.powerControl.maxOut);
            MinMWOutputTXT.Text = Convert.ToString(generator.powerControl.minOut);
            MWSetPointTXT.Text = Convert.ToString(generator.powerControl.setpoint);
            MWOutputTXT.Text = Convert.ToString(generator.powerControl.outPut);
            Gen_name.Text = generator.Name;
            PartFactorTXT.Text = Convert.ToString(generator.powerControl.factor);
            MaxMvarsTXT.Text = Convert.ToString(generator.voltageControl.MaxMvars);
            MinMvarsTXT.Text = Convert.ToString(generator.voltageControl.MinMvars);
            MvarOutputTXT.Text = Convert.ToString(generator.voltageControl.MvarOutput);
            RemoteRegFactorTXT.Text = Convert.ToString(generator.voltageControl.RegFactor);
            SetPointVoltageTXT.Text = Convert.ToString(generator.voltageControl.SetPointVoltage);
            GeneratorBase.Text = generator.Generator_MVA_BASE.ToString();
            GeneratorStepTransR.Text = generator.faultParameters.Generatoe_Step_Transformer_R.ToString();
            GeneratorStepTransX.Text = generator.faultParameters.Generatoe_Step_Transformer_X.ToString();
            GeneratorStepTransTap.Text = generator.faultParameters.Generatoe_Step_Transformer_Tap.ToString();

            NeurraltoGroundImpedanceR.Text = generator.faultParameters.Neutral_Ground_Impedance_R.ToString();
            NeurraltoGroundImpedanceX.Text = generator.faultParameters.Neutral_Ground_Impedance_X.ToString();

            GenInservice.Checked = generator.Inservice;
            AvailableforAVRCheck.Checked = generator.powerControl.availableAVR;
            InternalSquenceImpedances_ZeroX.Text = generator.faultParameters.ISI_Zero_X.ToString();
            InternalSquenceImpedances_ZeroR.Text = generator.faultParameters.ISI_Zero_R.ToString();
            InternalSquenceImpedances_positiveX.Text = generator.faultParameters.ISI_Positive_X.ToString();
            InternalSquenceImpedances_positiveR.Text = generator.faultParameters.ISI_Positive_R.ToString();
            InternalSquenceImpedances_NegativeX.Text = generator.faultParameters.ISI_Negative_X.ToString();
            InternalSquenceImpedances_NegativeR.Text = generator.faultParameters.ISI_Negative_R.ToString();
            CapabilityCurve pc1 = new CapabilityCurve();
            pc1.Name = "PC1";
            pc1.MVAR = 0;
            pc1.MW = 0;
            generator.capabilityCurves.Add(pc1);
            CapabilityCurve pc2 = new CapabilityCurve();
            pc2.Name = "PC2";
            pc2.MVAR = 0;
            pc2.MW = 0;
            generator.capabilityCurves.Add(pc2);
            CapabilityCurve QC1min = new CapabilityCurve();
            QC1min.Name = "QC1min";
            QC1min.MVAR = 0;
            QC1min.MW = 0;
            generator.capabilityCurves.Add(QC1min);
            CapabilityCurve QC1max = new CapabilityCurve();
            QC1max.Name = "QC1max";
            QC1max.MVAR = 0;
            QC1max.MW = 0;
            generator.capabilityCurves.Add(QC1max);
            CapabilityCurve QC2min = new CapabilityCurve();
            QC2min.Name = "QC2min";
            QC2min.MVAR = 0;
            QC2min.MW = 0;
            generator.capabilityCurves.Add(QC2min);
            CapabilityCurve QC2max = new CapabilityCurve();
            QC2max.Name = "QC2max";
            QC2max.MVAR = 0;
            QC2max.MW = 0;
            generator.capabilityCurves.Add(QC2max);
            // name.Text = generator.Name;
            code.Text = generator.Code.ToString();
            powerFactorTXT.Text = generator.windControlMode.PowerFactor.ToString();
            CapabilityCurveDataGrid.DataSource = generator.capabilityCurves;


        }
        public Boolean save()
        {
            try
            {


                if (generator.Bus != null)
                {
                    generator.Bus.BusNumber = long.Parse( busNumber.Text);
                    generator.Bus.BusName = busName.Text;
                }
                generator.Inservice = GenInservice.Checked;
                
                generator.powerControl.maxOut = float.Parse(MaxMWOutputTXT.Text);
                generator.powerControl.minOut = float.Parse(MinMWOutputTXT.Text);
                generator.powerControl.setpoint = float.Parse(MWSetPointTXT.Text);
                generator.powerControl.outPut = float.Parse(MWOutputTXT.Text);
                generator.Name = Gen_name.Text;
                generator.powerControl.factor = float.Parse(PartFactorTXT.Text);
                generator.voltageControl.MaxMvars = float.Parse(MaxMvarsTXT.Text);
                generator.voltageControl.MinMvars = float.Parse(MinMvarsTXT.Text);
                generator.voltageControl.MvarOutput = float.Parse(MvarOutputTXT.Text);
                generator.voltageControl.RegFactor = float.Parse(RemoteRegFactorTXT.Text);
                generator.voltageControl.SetPointVoltage = float.Parse(SetPointVoltageTXT.Text);

                generator.Generator_MVA_BASE = double.Parse(GeneratorBase.Text);
                generator.faultParameters.Generatoe_Step_Transformer_R = double.Parse(GeneratorStepTransR.Text );
                generator.faultParameters.Generatoe_Step_Transformer_X = double.Parse(GeneratorStepTransX.Text);
                generator.faultParameters.Generatoe_Step_Transformer_Tap= double.Parse(GeneratorStepTransTap.Text );

                generator.faultParameters.Neutral_Ground_Impedance_R = double.Parse(NeurraltoGroundImpedanceR.Text);
                generator.faultParameters.Neutral_Ground_Impedance_X = double.Parse( NeurraltoGroundImpedanceX.Text );
         
                generator.powerControl.availableAVR = AvailableforAVRCheck.Checked;
                generator.faultParameters.ISI_Zero_X = double.Parse(InternalSquenceImpedances_ZeroX.Text);
                generator.faultParameters.ISI_Zero_R = double.Parse(InternalSquenceImpedances_ZeroR.Text);
                generator.faultParameters.ISI_Positive_X =double.Parse(InternalSquenceImpedances_positiveX.Text);
                generator.faultParameters.ISI_Positive_R =double.Parse(InternalSquenceImpedances_positiveR.Text);
                generator.faultParameters.ISI_Negative_X=double.Parse (InternalSquenceImpedances_NegativeX.Text);
                generator.faultParameters.ISI_Negative_R= double.Parse(InternalSquenceImpedances_NegativeR.Text);
                generator.Code =long.Parse(code.Text) ;
                generator.windControlMode.PowerFactor = double.Parse(powerFactorTXT.Text);
                             
                generatorBl.edit(generator, CustomContentControl.getCurrentCase());
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
        public Generator getGenerator()
        {
            return generator;
        }

        private void setGenerator(Generator generator)
        {
            this.generator = generator;
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

       
        private void name_Click(object sender, EventArgs e)
        {

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
