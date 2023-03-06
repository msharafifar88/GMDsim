using BL;
using GUI.Line.Condcutor_Data;
using GUI.New_concept_WPF;
using GUI.Stability;
using network;
using persistent.enumeration;
using persistent.line;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GUI.Line
{
    public partial class Single3PhaseLine_main : Form
    {
        //It is finished!!!
        Single3phaseLineBL single3PhaseLineBL;
        Single3phaseLine single3Phase;
        List<string> selectedList = new List<string>();
        TransmissionLine_Standard transmission_standard;
        TransmissionLine_CondcutorData transmissionLine_CondcutorData;
        Cable_Standard cable_Standard;
        public Single3PhaseLine_main(Single3phaseLine input)
        {
            InitializeComponent();
            single3PhaseLineBL = new Single3phaseLineBL();
            single3Phase = input;
            EMTModelTypeCombo.DataSource = Enum.GetValues(typeof(EMTModelTypeEnum)).Cast<EMTModelTypeEnum>().ToList();
            LineLengthUnitTypeCombo.DataSource = Enum.GetValues(typeof(LengthType)).Cast<LengthType>().ToList();
            TypeofLoadLimitCombo.DataSource = Enum.GetValues(typeof(TypeLimit)).Cast<TypeLimit>().ToList();
            InpustDataTransmitionLine.DataSource = Enum.GetValues(typeof(ConductorTypeEnum)).Cast<ConductorTypeEnum>().ToList();
            Identitytxt.Text = single3Phase.Identity;
            LineName.Text = single3Phase.Name;
            /*single3Phase.LineConductor.CableDatas.Add(cableData);*/
            Init();

        }

        private void Init()
        {
            //  lineLengthvalue.Value = (decimal)single3Phase.LineLengthvalue;
            transmission_standard = new TransmissionLine_Standard(single3Phase);
            transmissionLine_CondcutorData = new TransmissionLine_CondcutorData(single3Phase);
            cable_Standard = new Cable_Standard(single3Phase);
            LineLengthUnitTypeCombo.SelectedItem = single3Phase.lengthType;
            EMTModelTypeCombo.SelectedItem = single3Phase.eMTModelTypeEnum;
            RzeroSeqImp.Text = single3Phase.RzeroSequence.ToString();
            XzeroSeqImp.Text = single3Phase.XzeroSequence.ToString();
            BzeroSeqImp.Text = single3Phase.BzeroSequence.ToString();
            GzeroSeqImp.Text = single3Phase.GzeroSequence.ToString();
            if (single3Phase.ToBus != null)
            {
                ToBusName.Text = single3Phase.ToBus.BusName;
                ToBusNumber.Text = single3Phase.ToBus.BusNumber.ToString();
                ToBusArea.Text = single3Phase.ToBus.area.Name;
                ToBusNominal.Text = single3Phase.ToBus.nominalVoltage.ToString();
            }
            if (single3Phase.FromBus != null)
            {
                FromBusName.Text = single3Phase.FromBus.BusName;
                FromBusNumber.Text = single3Phase.FromBus.BusNumber.ToString();
                FromBusArea.Text = single3Phase.FromBus.area.Name;
                FromBusNominal.Text = single3Phase.FromBus.nominalVoltage.ToString();
            }

            SerseReistanceTXT.Text = single3Phase.Resistance.ToString();
            SeriseReactancexTXT.Text = single3Phase.Reactance.ToString();
            SeriseChargingTXT.Text = single3Phase.Charging.ToString();
            SeriseConductanceTXT.Text = single3Phase.Conductance.ToString();
            single3Phase.LineConductor.LineConductorType = LineConductorTypeEnum.TransmissionLine;
            //    Identitytxt.Text = single3Phase.Identity.ToString();
            lineLengthval.Text = single3Phase.LineLengthvalue.ToString();
            LineName.Text = single3Phase.Name;
            Lineinservice.Checked = single3Phase.Inservice;
            //    OWF1.Text = single3Phase.GetOwner(0).Percentage.ToString();
            createLimitTextBox();

        }


        public bool Save()
        {
            try
            {
                single3Phase.eMTModelTypeEnum = (EMTModelTypeEnum)EMTModelTypeCombo.SelectedItem;
                if (single3Phase.ToBus != null)
                {
                    single3Phase.ToBus.BusNumber = long.Parse(ToBusNumber.Text);
                    single3Phase.ToBus.BusName = ToBusName.Text;
                    single3Phase.ToBus.area.Name = ToBusArea.Text;
                    single3Phase.ToBus.nominalVoltage = float.Parse(ToBusNominal.Text);
                }
                if (single3Phase.FromBus != null)
                {
                    single3Phase.FromBus.BusName = FromBusName.Text;
                    single3Phase.FromBus.BusNumber = long.Parse(FromBusNumber.Text);
                    single3Phase.FromBus.area.Name = FromBusArea.Text;
                    single3Phase.FromBus.nominalVoltage = float.Parse(FromBusNominal.Text);
                }
                ///
                single3Phase.lengthType = (LengthType)LineLengthUnitTypeCombo.SelectedItem;
                single3Phase.eMTModelTypeEnum = (EMTModelTypeEnum)EMTModelTypeCombo.SelectedItem;
                single3Phase.RzeroSequence = float.Parse(RzeroSeqImp.Text);
                single3Phase.XzeroSequence = float.Parse(XzeroSeqImp.Text);
                single3Phase.BzeroSequence = float.Parse(BzeroSeqImp.Text);
                single3Phase.GzeroSequence = float.Parse(GzeroSeqImp.Text);

                single3Phase.Resistance = float.Parse(SerseReistanceTXT.Text);
                single3Phase.Reactance = float.Parse(SeriseReactancexTXT.Text);
                single3Phase.Charging = float.Parse(SeriseChargingTXT.Text);
                single3Phase.Conductance = float.Parse(SeriseConductanceTXT.Text);
                single3Phase.LineConductor.LineConductorType = LineConductorTypeEnum.TransmissionLine;
                //    Identitytxt.Text = single3Phase.Identity.ToString();
                single3Phase.LineLengthvalue = float.Parse(lineLengthval.Text);
                single3Phase.Name = LineName.Text;
                single3Phase.Inservice = Lineinservice.Checked;
                ///
                single3Phase.Identity = Identitytxt.Text;
                single3PhaseLineBL.edit(single3Phase, CustomContentControl.getCurrentCase());
                return true;
            }
            catch
            {
                MessageBox.Show("Save Record Exception");
                return false;
            }

        }
        /// <summary>
        /// Create Dynamiclly 
        /// </summary>
        /// <param name="input"></param>
        public void createLimitTextBox()
        {
            int txtno = 16;
            int pointX = 15;
            int pointY = 40;
            int WidthL = 45;
            int HeightL = 13;
            int WidthTB = 83;
            int HeightTB = 20;
            MVALimitsGB.Controls.Clear();
            for (int i = 1; i < single3Phase.LimitList.Count(); i++)
            {
                TextBox textBox = new TextBox();
                textBox.Text = single3Phase.GetLimitList(i).ToString();
                textBox.Name = i.ToString();
                textBox.Size = new Size(WidthTB, HeightTB);
                textBox.Location = new Point(pointX + 50, pointY);
                Label lbl = new Label();
                lbl.Name = "Limit" + Convert.ToChar(i + 64);
                lbl.Text = "Limit" + Convert.ToChar(i + 64);
                lbl.Size = new Size(WidthL, HeightL);
                lbl.Location = new Point(pointX, pointY);


                MVALimitsGB.Controls.Add(lbl);
                MVALimitsGB.Controls.Add(textBox);
                MVALimitsGB.Show();
                pointY += 21;
            }

        }
        public void getDataLimitTextBox()
        {

            foreach (Control c in MVALimitsGB.Controls)
            {
                if (c is TextBox)
                {
                    single3Phase.SetLimitList(Int32.Parse(c.Name), Convert.ToDouble(c.Text));
                }
            }
        }
        /* public TriLine_main(single3Phase input)
         {

             InitializeComponent();
             this.Enter += TriLine_main_Enter;
         }*/

        //TriLine_main_Emter allows to refresh the control when the mouse enter in it.
        /* private void TriLine_main_Enter(object sender, EventArgs e)
         {
             if(ModelTypeMenu.getSelectedModel() != null)
             {
                 radDropDownTypeofRelay.Items.Add(ModelTypeMenu.getSelectedModel());
                 ModelTypeMenu.setSelectedModel(null);
             }

         }*/

        private void LineLength_CheckedChanged(object sender, EventArgs e)
        {
            if (!LineLength.Checked)
            {
                lineLengthval.Enabled = false;
                LineLengthUnitTypeCombo.Enabled = false;
            }
            else if (LineLength.Checked)
            {
                lineLengthval.Enabled = true;
                LineLengthUnitTypeCombo.Enabled = true;
            }

        }

        private void buttonRelayInsert_Click(object sender, EventArgs e)
        {
            ModelTypeMenu modelTypeMenu = new ModelTypeMenu(StabilityType.Line);
            modelTypeMenu.ShowDialog();

            StabilityLine line = new StabilityLine();

            line.LineModel = (LineModelType)modelTypeMenu.getSelectedModel();
            line.status = true;
            single3Phase.StabilityLines.Add(line);
            TypeStabilityRelayCombo.Items.Add(line);
            TypeStabilityRelayCombo.SelectedItem = line;

        }


        private void FindModelAuto_CheckedChanged(object sender, EventArgs e)
        {
            if (FindModelAuto.Checked == false)
            {
                ModelFrequnceValu.Enabled = true;
                ModelFrequnceValu.ReadOnly = false;
            }
            else if (FindModelAuto.Checked == true)
            {

                ModelFrequnceValu.Enabled = false;
                ModelFrequnceValu.ReadOnly = true;
                //   ModelFrequnceValu = 0;
            }
        }





        private void Calculate_Impedences_Click(object sender, EventArgs e)
        {
            this.tabvalues.SelectedTab = tabvalues.TabPages[4];
        }







        private void tabEMTModel_Click(object sender, EventArgs e)
        {

        }

        private void EMTModelTypeCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (EMTModelTypeCombo.SelectedItem.Equals(EMTModelTypeEnum.FD))
            {
                ComplexTi.Enabled = false;
                Frequecyrange.Visible = true;

                BalancedLine.Checked = true;
                Doublecircuitline.Checked = false;
                DFQ.Checked = false;
                RealTi.Checked = false;
                RealTi.Enabled = true;
                ///plot
                QuickFit.Enabled = true;
                MaxNumOfPolse.Enabled = true;
                PlotFitting.Enabled = true;
                Exteradynamic.Enabled = true;
            }
            else if (EMTModelTypeCombo.SelectedItem.Equals(EMTModelTypeEnum.CP))
            {
                Frequecyrange.Visible = false;
                ComplexTi.Enabled = true;

                BalancedLine.Checked = true;
                Doublecircuitline.Checked = false;
                DFQ.Checked = false;
                RealTi.Checked = false;
                RealTi.Enabled = true;
                ///plot
                QuickFit.Enabled = false;
                MaxNumOfPolse.Enabled = false;
                PlotFitting.Enabled = false;
                Exteradynamic.Enabled = false;


            }
            else if (EMTModelTypeCombo.SelectedItem.Equals(EMTModelTypeEnum.ExactPI))
            {
                RealTi.Enabled = false;

                BalancedLine.Checked = true;
                Doublecircuitline.Checked = false;
                DFQ.Checked = false;

                Frequecyrange.Visible = true;
                //plot
                QuickFit.Enabled = true;
                MaxNumOfPolse.Enabled = true;
                PlotFitting.Enabled = true;
                Exteradynamic.Enabled = true;


            }
            else if (EMTModelTypeCombo.SelectedItem.Equals(EMTModelTypeEnum.NominalPI))
            {
                Frequecyrange.Visible = true;
                ComplexTi.Enabled = false;

                RealTi.Enabled = true;
                BalancedLine.Checked = true;
                Doublecircuitline.Checked = false;
                DFQ.Checked = false;
                RealTi.Checked = false;
                ///plot
                QuickFit.Enabled = false;
                MaxNumOfPolse.Enabled = false;
                PlotFitting.Enabled = false;
                Exteradynamic.Enabled = false;
            }
        }

        /*   private void Linear_CheckedChanged(object sender, EventArgs e)
           {

                   groupBoxLinear.Visible = true;
                   groupBoxLograithmic.Visible = false;

                   Logaritmic.Checked = false;



           }

           private void Logaritmic_CheckedChanged(object sender, EventArgs e)
           {
               groupBoxLinear.Visible = false;
               groupBoxLograithmic.Visible = true;
               Linear.Checked = false;



           }
   */
        private void Linear_Click(object sender, EventArgs e)
        {

            //  groupBoxLinear.Visible = true;
            //  groupBoxLograithmic.Visible = false;
            Linear.Checked = true;
            Logaritmic.Checked = false;

            NumofDecades.Enabled = false;
            PointsandDecade.Enabled = false;
            FminL.Enabled = false;

            DeltaF.Enabled = true;
            FminLinear.Enabled = true;
            FmaxL.Enabled = true;
        }

        private void Logaritmic_Click(object sender, EventArgs e)
        {
            //  groupBoxLinear.Visible = false;
            // groupBoxLograithmic.Visible = true;
            Linear.Checked = false;
            Logaritmic.Checked = true;

            NumofDecades.Enabled = true;
            PointsandDecade.Enabled = true;
            FminL.Enabled = true;

            DeltaF.Enabled = false;
            FminLinear.Enabled = false;
            FmaxL.Enabled = false;


        }


        /* public void CreateChart()
         {
             LineSeries tempSeries = new LineSeries();
             tempSeries.DataPoints.Add(new CategoricalDataPoint(0, "0"));
             tempSeries.DataPoints.Add(new CategoricalDataPoint(-10, "5"));
             tempSeries.DataPoints.Add(new CategoricalDataPoint(-15, "10"));
             tempSeries.DataPoints.Add(new CategoricalDataPoint(-14, "15"));
             tempSeries.DataPoints.Add(new CategoricalDataPoint(-10, "20"));
             tempSeries.DataPoints.Add(new CategoricalDataPoint(-5, "25"));
             tempSeries.DataPoints.Add(new CategoricalDataPoint(-2, "30"));
             tempSeries.DataPoints.Add(new CategoricalDataPoint(5, "35"));
             tempSeries.DataPoints.Add(new CategoricalDataPoint(11, "40"));
             tempSeries.DataPoints.Add(new CategoricalDataPoint(7, "45"));
             tempSeries.DataPoints.Add(new CategoricalDataPoint(0, "50"));
             tempSeries.DataPoints.Add(new CategoricalDataPoint(5, "55"));
             tempSeries.DataPoints.Add(new CategoricalDataPoint(3, "60"));
             tempSeries.DataPoints.Add(new CategoricalDataPoint(-1, "66"));
             tempSeries.DataPoints.Add(new CategoricalDataPoint(-3, "70"));
             tempSeries.DataPoints.Add(new CategoricalDataPoint(0, "75"));
             tempSeries.DataPoints.Add(new CategoricalDataPoint(-2, "80"));
             tempSeries.DataPoints.Add(new CategoricalDataPoint(-12, "85"));
             tempSeries.DataPoints.Add(new CategoricalDataPoint(-18, "90"));
             tempSeries.DataPoints.Add(new CategoricalDataPoint(-30, "95"));

             PlotChart.Series.Add(tempSeries);
             CategoricalAxis tempHorizontalAxis = tempSeries.HorizontalAxis as CategoricalAxis;
             tempHorizontalAxis.StartPositionAxis = tempSeries.VerticalAxis;
             tempHorizontalAxis.StartPositionValue = 0;
             tempHorizontalAxis.Title = "F";
             LinearAxis tempVerticalAxis = tempSeries.VerticalAxis as LinearAxis;
             tempVerticalAxis.Title = " PLOT ";

         }*/

        private void PlotFitting_CheckedChanged(object sender, EventArgs e)
        {
            if (PlotFitting.Checked == true)
            {
                //  CreateChart();
                //  PlotChart.Visible = true;


            }
            else if (PlotFitting.Checked == false)
            {

                //PlotChart.Visible = false;

            }
        }

        private void textBoxLimitA_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8)
            {

                e.Handled = true;
            }
        }


        private void textBoxLimit_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validation.NumberValidation(sender, e);
        }






        private void CalculationImedances_Click(object sender, EventArgs e)
        {
            this.tabvalues.SelectedTab = tabvalues.TabPages[0];
        }


        private void InpustDataTransmitionLine_SelectedValueChanged(object sender, EventArgs e)
        {

            if (InpustDataTransmitionLine.SelectedItem.Equals(ConductorTypeEnum.Standad_Conductor_data) && single3Phase.LineConductor.LineConductorType.Equals(LineConductorTypeEnum.TransmissionLine))
            {

                Main_ConductorPanel.Controls.Clear();
                transmission_standard.Dock = DockStyle.Fill;
                Main_ConductorPanel.Controls.Add(transmission_standard);


            }
            else if (InpustDataTransmitionLine.SelectedItem.Equals(ConductorTypeEnum.Condactor_data_for_Rebuild) && single3Phase.LineConductor.LineConductorType.Equals(LineConductorTypeEnum.TransmissionLine))
            {

                Main_ConductorPanel.Controls.Clear();
                transmissionLine_CondcutorData.Dock = DockStyle.Fill;
                Main_ConductorPanel.Controls.Add(transmissionLine_CondcutorData);


            }

            else if (InpustDataTransmitionLine.SelectedItem.Equals(ConductorTypeEnum.NotAvaileble) && single3Phase.LineConductor.LineConductorType.Equals(LineConductorTypeEnum.TransmissionLine))
            {
                Main_ConductorPanel.Controls.Clear();

            }
            ////

            else if (InpustDataTransmitionLine.SelectedItem.Equals(ConductorTypeEnum.NotAvaileble) && single3Phase.LineConductor.LineConductorType.Equals(LineConductorTypeEnum.Cable))
            {
                Main_ConductorPanel.Controls.Clear();


            }
            else if (InpustDataTransmitionLine.SelectedItem.Equals(ConductorTypeEnum.Standad_Conductor_data) && single3Phase.LineConductor.LineConductorType.Equals(LineConductorTypeEnum.Cable))
            {
                Main_ConductorPanel.Controls.Clear();
                cable_Standard.Dock = DockStyle.Fill;
                Main_ConductorPanel.Controls.Add(cable_Standard);


            }

            else if (InpustDataTransmitionLine.SelectedItem.Equals(ConductorTypeEnum.Condactor_data_for_Rebuild) && single3Phase.LineConductor.LineConductorType.Equals(LineConductorTypeEnum.Cable))
            {
                InpustDataTransmitionLine.SelectedItem.Equals(ConductorTypeEnum.Standad_Conductor_data);
                Main_ConductorPanel.Controls.Clear();
                cable_Standard.Dock = DockStyle.Fill;
                Main_ConductorPanel.Controls.Add(cable_Standard);

            }

        }




        private void tabvalues_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabvalues_Click(object sender, EventArgs e)
        {
            TransmissinLineConductor.Checked = true;

        }
        private void buttonRelay_Delete_Click(object sender, EventArgs e)
        {
            StabilityLine line = new StabilityLine();
            line = (StabilityLine)TypeStabilityRelayCombo.SelectedItem;
            // line.status = true;
            single3Phase.StabilityLines.Remove(line);
            TypeStabilityRelayCombo.Items.Remove(line);
        }

        private void TypeStabilityRelayCombo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void Lineinservice_CheckedChanged(object sender, EventArgs e)
        {
            if (Lineinservice.Checked == true)
            {

            }
        }

        private void Single_Save_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void Single3PhaseLine_main_Load(object sender, EventArgs e)
        {

        }

        private void Ok_Click(object sender, EventArgs e)
        {
            Save();
            Close();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void TransmissinLineConductor_CheckedChanged(object sender, EventArgs e)
        {
            if (TransmissinLineConductor.Checked == true)
            {
                radioButtonCable.Checked = false;

                single3Phase.LineConductor.LineConductorType = LineConductorTypeEnum.TransmissionLine;
                InpustDataTransmitionLine_SelectedValueChanged(sender, e);
            }
        }

        private void radioButtonCable_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonCable.Checked == true)
            {
                TransmissinLineConductor.Checked = false;

                single3Phase.LineConductor.LineConductorType = LineConductorTypeEnum.Cable;
                InpustDataTransmitionLine_SelectedValueChanged(sender, e);
            }
        }
    }
}