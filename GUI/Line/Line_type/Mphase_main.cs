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
    public partial class Mphase_main : Form
    {
        //It is finished!!!
        MultiPhaseLineBL multiPhaseLineBL;
        MultiPhaseLine multiPhaseLine;
        List<string> selectedList = new List<string>();
        TransmissionLine_Standard transmission_standard;
        TransmissionLine_CondcutorData transmissionLine_CondcutorData;
        Cable_Standard cable_Standard;
        public Mphase_main(MultiPhaseLine input)
        {
            InitializeComponent();
            multiPhaseLineBL = new MultiPhaseLineBL();
            multiPhaseLine = input;
            EMTModelTypeCombo.DataSource = Enum.GetValues(typeof(EMTModelTypeEnum)).Cast<EMTModelTypeEnum>().ToList();
            LineLengthUnitTypeCombo.DataSource = Enum.GetValues(typeof(LengthType)).Cast<LengthType>().ToList();
            TypeofLoadLimitCombo.DataSource = Enum.GetValues(typeof(TypeLimit)).Cast<TypeLimit>().ToList();
            InpustDataTransmitionLine.DataSource = Enum.GetValues(typeof(ConductorTypeEnum)).Cast<ConductorTypeEnum>().ToList();
            Identitytxt.Text = multiPhaseLine.Identity;
            LineName.Text = multiPhaseLine.Name;
            Init();

        }

        private void Init()
        {
            transmission_standard = new TransmissionLine_Standard(multiPhaseLine);
            transmissionLine_CondcutorData = new TransmissionLine_CondcutorData(multiPhaseLine);
            cable_Standard = new Cable_Standard(multiPhaseLine);
            //  lineLengthvalue.Value = (decimal)multiPhaseLine.LineLengthvalue;
            LineLengthUnitTypeCombo.SelectedItem = multiPhaseLine.lengthType;

            RzeroSeqImp.Text = multiPhaseLine.RzeroSequence.ToString();
            XzeroSeqImp.Text = multiPhaseLine.XzeroSequence.ToString();
            BzeroSeqImp.Text = multiPhaseLine.BzeroSequence.ToString();
            GzeroSeqImp.Text = multiPhaseLine.GzeroSequence.ToString();
            if (multiPhaseLine.ToBus != null)
            {
                ToBusName.Text = multiPhaseLine.ToBus.BusName;
                ToBusNumber.Text = multiPhaseLine.ToBus.BusNumber.ToString();
                ToBusArea.Text = multiPhaseLine.ToBus.area.Name;
                ToBusNominal.Text = multiPhaseLine.ToBus.nominalVoltage.ToString();
            }
            if (multiPhaseLine.FromBus != null)
            {
                FromBusName.Text = multiPhaseLine.FromBus.BusName;
                FromBusNumber.Text = multiPhaseLine.FromBus.BusNumber.ToString();
                FromBusArea.Text = multiPhaseLine.FromBus.area.Name;
                FromBusNominal.Text = multiPhaseLine.FromBus.nominalVoltage.ToString();
            }

            SerseReistanceTXT.Text = multiPhaseLine.Resistance.ToString();
            SeriseReactancexTXT.Text = multiPhaseLine.Reactance.ToString();
            SeriseChargingTXT.Text = multiPhaseLine.Charging.ToString();
            SeriseConductanceTXT.Text = multiPhaseLine.Conductance.ToString();
            multiPhaseLine.LineConductor.LineConductorType = LineConductorTypeEnum.TransmissionLine;
            //    Identitytxt.Text = multiPhaseLine.Identity.ToString();
            lineLengthval.Text = multiPhaseLine.LineLengthvalue.ToString();
            LineName.Text = multiPhaseLine.Name;
            Lineinservice.Checked = multiPhaseLine.Inservice;
            //    OWF1.Text = multiPhaseLine.GetOwner(0).Percentage.ToString();
            createLimitTextBox();

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
            for (int i = 0; i < multiPhaseLine.LimitList.Count(); i++)
            {
                TextBox textBox = new TextBox();
                textBox.Text = multiPhaseLine.GetLimitList(i).ToString();
                textBox.Name = i.ToString();
                textBox.Size = new Size(WidthTB, HeightTB);
                textBox.Location = new Point(pointX + 50, pointY);
                Label lbl = new Label();
                lbl.Name = "Limit" + i + 1;
                lbl.Text = "Limit" + i + 1;
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
                    multiPhaseLine.SetLimitList(Int32.Parse(c.Name), Convert.ToDouble(c.Text));
                }
            }
        }
        /* public TriLine_main(multiPhaseLine input)
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
            multiPhaseLine.StabilityLines.Add(line);
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
                ComplexTi.Enabled = true;
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
                ComplexTi.Enabled = false;
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
                RealTi.Enabled = true;
                BalancedLine.Checked = true;
                Doublecircuitline.Checked = false;
                DFQ.Checked = false;
                ComplexTi.Checked = false;
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
                ComplexTi.Enabled = true;
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


        /*public void CreateChart()
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
                // CreateChart();
                //PlotChart.Visible = true;


            }
            else if (PlotFitting.Checked == false)
            {

                //PlotChart.Visible = false;

            }
        }

        public void CreateConductor()
        {
            //Create Header
            // Create Value
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



        private void radioButtonCable_Click(object sender, EventArgs e)
        {
            radioButtonCable.Checked = true;
            TransmissinLineConductor.Checked = false;
            multiPhaseLine.LineConductor.LineConductorType = LineConductorTypeEnum.Cable;
        }

        private void radioButtonTransmissin_Click(object sender, EventArgs e)
        {
            TransmissinLineConductor.Checked = true;
            radioButtonCable.Checked = false;
            multiPhaseLine.LineConductor.LineConductorType = LineConductorTypeEnum.TransmissionLine;
            //  GenerationValueOnTransmissionLinedataGrid();

        }


        private void CalculationImedances_Click(object sender, EventArgs e)
        {
            this.tabvalues.SelectedTab = tabvalues.TabPages[0];
        }

        private void InpustDataTransmitionLine_SelectedValueChanged(object sender, EventArgs e)
        {

            if (InpustDataTransmitionLine.SelectedItem.Equals(ConductorTypeEnum.Standad_Conductor_data) && multiPhaseLine.LineConductor.LineConductorType.Equals(LineConductorTypeEnum.TransmissionLine))
            {

                Main_ConductorPanel.Controls.Clear();
                transmission_standard.Dock = DockStyle.Fill;
                Main_ConductorPanel.Controls.Add(transmission_standard);

            }
            else if (InpustDataTransmitionLine.SelectedItem.Equals(ConductorTypeEnum.Condactor_data_for_Rebuild) && multiPhaseLine.LineConductor.LineConductorType.Equals(LineConductorTypeEnum.TransmissionLine))
            {
                Main_ConductorPanel.Controls.Clear();
                transmissionLine_CondcutorData.Dock = DockStyle.Fill;
                Main_ConductorPanel.Controls.Add(transmissionLine_CondcutorData);

            }

            else if (InpustDataTransmitionLine.SelectedItem.Equals(ConductorTypeEnum.NotAvaileble) && multiPhaseLine.LineConductor.LineConductorType.Equals(LineConductorTypeEnum.TransmissionLine))
            {

                Main_ConductorPanel.Controls.Clear();
            }
            ////

            else if (InpustDataTransmitionLine.SelectedItem.Equals(ConductorTypeEnum.NotAvaileble) && multiPhaseLine.LineConductor.LineConductorType.Equals(LineConductorTypeEnum.Cable))
            {

                Main_ConductorPanel.Controls.Clear();
                cable_Standard.Dock = DockStyle.Fill;
                Main_ConductorPanel.Controls.Add(cable_Standard);


            }
            else if (InpustDataTransmitionLine.SelectedItem.Equals(ConductorTypeEnum.Standad_Conductor_data) && multiPhaseLine.LineConductor.LineConductorType.Equals(LineConductorTypeEnum.Cable))
            {
                Main_ConductorPanel.Controls.Clear();
                cable_Standard.Dock = DockStyle.Fill;
                Main_ConductorPanel.Controls.Add(cable_Standard);

            }

            else if (InpustDataTransmitionLine.SelectedItem.Equals(ConductorTypeEnum.Condactor_data_for_Rebuild) && multiPhaseLine.LineConductor.LineConductorType.Equals(LineConductorTypeEnum.Cable))
            {
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
            multiPhaseLine.StabilityLines.Remove(line);
            TypeStabilityRelayCombo.Items.Remove(line);
        }

        private void TypeStabilityRelayCombo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cableTypeCombo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Lineinservice_CheckedChanged(object sender, EventArgs e)
        {
            if (Lineinservice.Checked == true)
            {

            }
        }

        private void MphaseSave_Click(object sender, EventArgs e)
        {
            Save();
        }
        public bool Save()
        {
            try
            {
                multiPhaseLine.eMTModelTypeEnum = (EMTModelTypeEnum)EMTModelTypeCombo.SelectedItem;
                if (multiPhaseLine.ToBus != null)
                {
                    multiPhaseLine.ToBus.BusNumber = long.Parse(ToBusNumber.Text);
                    multiPhaseLine.ToBus.BusName = ToBusName.Text;
                    multiPhaseLine.ToBus.area.Name = ToBusArea.Text;
                    multiPhaseLine.ToBus.nominalVoltage = float.Parse(ToBusNominal.Text);
                }
                if (multiPhaseLine.FromBus != null)
                {
                    multiPhaseLine.FromBus.BusName = FromBusName.Text;
                    multiPhaseLine.FromBus.BusNumber = long.Parse(FromBusNumber.Text);
                    multiPhaseLine.FromBus.area.Name = FromBusArea.Text;
                    multiPhaseLine.FromBus.nominalVoltage = float.Parse(FromBusNominal.Text);
                }
                ///
                multiPhaseLine.lengthType = (LengthType)LineLengthUnitTypeCombo.SelectedItem;
                multiPhaseLine.eMTModelTypeEnum = (EMTModelTypeEnum)EMTModelTypeCombo.SelectedItem;
                multiPhaseLine.RzeroSequence = float.Parse(RzeroSeqImp.Text);
                multiPhaseLine.XzeroSequence = float.Parse(XzeroSeqImp.Text);
                multiPhaseLine.BzeroSequence = float.Parse(BzeroSeqImp.Text);
                multiPhaseLine.GzeroSequence = float.Parse(GzeroSeqImp.Text);

                multiPhaseLine.Resistance = float.Parse(SerseReistanceTXT.Text);
                multiPhaseLine.Reactance = float.Parse(SeriseReactancexTXT.Text);
                multiPhaseLine.Charging = float.Parse(SeriseChargingTXT.Text);
                multiPhaseLine.Conductance = float.Parse(SeriseConductanceTXT.Text);
                multiPhaseLine.LineConductor.LineConductorType = LineConductorTypeEnum.TransmissionLine;
                //    Identitytxt.Text = multiPhaseLine.Identity.ToString();
                multiPhaseLine.LineLengthvalue = float.Parse(lineLengthval.Text);
                multiPhaseLine.Name = LineName.Text;
                multiPhaseLine.Inservice = Lineinservice.Checked;
                ///
                multiPhaseLine.Identity = Identitytxt.Text;
                multiPhaseLineBL.edit(multiPhaseLine, CustomContentControl.getCurrentCase());
                return true;
            }
            catch
            {
                MessageBox.Show("Save Record Exception");
                return false;
            }

        }

        private void MphaseOk_Click(object sender, EventArgs e)
        {
            Save();
            Close();
        }

        private void MphaseCancel_Click(object sender, EventArgs e)
        {
            Close();
        }






        /* private void CondactorDataGroup_Enter(object sender, EventArgs e)
         {
             if (this.MaximizeBox)
             {

                 CondactorDataGroup.Dock = DockStyle.Left;
                 CondactorDataGroup.Dock = DockStyle.Right;
             }
         }

         private void Infocablegroupbox_Enter(object sender, EventArgs e)
         {
             if (this.MaximizeBox)
             {

                 Infocablegroupbox.Dock = DockStyle.Left;
                 Infocablegroupbox.Dock = DockStyle.Right;
             }
         }*/
    }
}
