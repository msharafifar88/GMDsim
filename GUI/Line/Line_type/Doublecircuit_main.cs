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
    public partial class Doublecircuit_main : Form
    {
        //It is finished!!!
        DoubleCircuitLineBL doubleCircuitLineBL;
        DoubleCircuitLine doubleCircuitLine;
        List<string> selectedList = new List<string>();
        TransmissionLine_Standard transmission_standard;
        TransmissionLine_CondcutorData transmissionLine_CondcutorData;
        Cable_Standard cable_Standard;

        public Doublecircuit_main(DoubleCircuitLine input)
        {
            InitializeComponent();
            doubleCircuitLine = input;
            EMTModelTypeCombo.DataSource = Enum.GetValues(typeof(EMTModelTypeEnum)).Cast<EMTModelTypeEnum>().ToList();
            LineLengthUnitTypeCombo.DataSource = Enum.GetValues(typeof(LengthType)).Cast<LengthType>().ToList();
            TypeofLoadLimitCombo.DataSource = Enum.GetValues(typeof(TypeLimit)).Cast<TypeLimit>().ToList();
            InpustDataTransmitionLine.DataSource = Enum.GetValues(typeof(ConductorTypeEnum)).Cast<ConductorTypeEnum>().ToList();
            Identitytxt.Text = doubleCircuitLine.Identity;
            LineName.Text = doubleCircuitLine.Name;
            doubleCircuitLineBL = new DoubleCircuitLineBL();
            Init();
        }
        private void Init()
        {
            transmission_standard = new TransmissionLine_Standard(doubleCircuitLine);
            transmissionLine_CondcutorData = new TransmissionLine_CondcutorData(doubleCircuitLine);
            cable_Standard = new Cable_Standard(doubleCircuitLine);
            //  lineLengthvalue.Value = (decimal)doubleCircuitLine.LineLengthvalue;
            LineLengthUnitTypeCombo.SelectedItem = doubleCircuitLine.lengthType;

            RzeroSeqImp.Text = doubleCircuitLine.RzeroSequence.ToString();
            XzeroSeqImp.Text = doubleCircuitLine.XzeroSequence.ToString();
            BzeroSeqImp.Text = doubleCircuitLine.BzeroSequence.ToString();
            GzeroSeqImp.Text = doubleCircuitLine.GzeroSequence.ToString();
            if (doubleCircuitLine.ToBus != null)
            {
                ToBusName.Text = doubleCircuitLine.ToBus.BusName;
                ToBusNumber.Text = doubleCircuitLine.ToBus.BusNumber.ToString();
                ToBusArea.Text = doubleCircuitLine.ToBus.area.Name;
                ToBusNominal.Text = doubleCircuitLine.ToBus.nominalVoltage.ToString();
            }
            if (doubleCircuitLine.FromBus != null)
            {
                FromBusName.Text = doubleCircuitLine.FromBus.BusName;
                FromBusNumber.Text = doubleCircuitLine.FromBus.BusNumber.ToString();
                FromBusArea.Text = doubleCircuitLine.FromBus.area.Name;
                FromBusNominal.Text = doubleCircuitLine.FromBus.nominalVoltage.ToString();
            }

            SerseReistanceTXT.Text = doubleCircuitLine.Resistance.ToString();
            SeriseReactancexTXT.Text = doubleCircuitLine.Reactance.ToString();
            SeriseChargingTXT.Text = doubleCircuitLine.Charging.ToString();
            SeriseConductanceTXT.Text = doubleCircuitLine.Conductance.ToString();
            doubleCircuitLine.LineConductor.LineConductorType = LineConductorTypeEnum.TransmissionLine;
            //    Identitytxt.Text = doubleCircuitLine.Identity.ToString();
            lineLengthval.Text = doubleCircuitLine.LineLengthvalue.ToString();
            LineName.Text = doubleCircuitLine.Name;
            Lineinservice.Checked = doubleCircuitLine.Inservice;
            //    OWF1.Text = doubleCircuitLine.GetOwner(0).Percentage.ToString();
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
            for (int i = 0; i < doubleCircuitLine.LimitList.Count(); i++)
            {
                TextBox textBox = new TextBox();
                textBox.Text = doubleCircuitLine.GetLimitList(i).ToString();
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
                    doubleCircuitLine.SetLimitList(Int32.Parse(c.Name), Convert.ToDouble(c.Text));
                }
            }
        }
        /* public TriLine_main(doubleCircuitLine input)
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
            doubleCircuitLine.StabilityLines.Add(line);
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

        /*    private void PlotFitting_CheckedChanged(object sender, EventArgs e)
            {
                if (PlotFitting.Checked == true)
                {
                    CreateChart();
                    PlotChart.Visible = true;


                }
                else if (PlotFitting.Checked == false)
                {

                    //PlotChart.Visible = false;

                }
            }*/

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

            doubleCircuitLine.LineConductor.LineConductorType = LineConductorTypeEnum.Cable;


        }

        private void radioButtonTransmissin_Click(object sender, EventArgs e)
        {
            TransmissinLineConductor.Checked = true;

            radioButtonCable.Checked = false;
            doubleCircuitLine.LineConductor.LineConductorType = LineConductorTypeEnum.TransmissionLine;
            //  GenerationValueOnTransmissionLinedataGrid();

        }

        private void CalculationImedances_Click(object sender, EventArgs e)
        {
            this.tabvalues.SelectedTab = tabvalues.TabPages[0];
        }

        private void InpustDataTransmitionLine_SelectedValueChanged(object sender, EventArgs e)
        {

            if (InpustDataTransmitionLine.SelectedItem.Equals(ConductorTypeEnum.Standad_Conductor_data) && doubleCircuitLine.LineConductor.LineConductorType.Equals(LineConductorTypeEnum.TransmissionLine))
            {

                Main_ConductorPanel.Controls.Clear();
                transmission_standard.Dock = DockStyle.Fill;
                Main_ConductorPanel.Controls.Add(transmission_standard);

            }
            else if (InpustDataTransmitionLine.SelectedItem.Equals(ConductorTypeEnum.Condactor_data_for_Rebuild) && doubleCircuitLine.LineConductor.LineConductorType.Equals(LineConductorTypeEnum.TransmissionLine))
            {
                Main_ConductorPanel.Controls.Clear();
                transmissionLine_CondcutorData.Dock = DockStyle.Fill;
                Main_ConductorPanel.Controls.Add(transmissionLine_CondcutorData);

            }

            else if (InpustDataTransmitionLine.SelectedItem.Equals(ConductorTypeEnum.NotAvaileble) && doubleCircuitLine.LineConductor.LineConductorType.Equals(LineConductorTypeEnum.TransmissionLine))
            {

                Main_ConductorPanel.Controls.Clear();
            }
            ////

            else if (InpustDataTransmitionLine.SelectedItem.Equals(ConductorTypeEnum.NotAvaileble) && doubleCircuitLine.LineConductor.LineConductorType.Equals(LineConductorTypeEnum.Cable))
            {

                Main_ConductorPanel.Controls.Clear();
                cable_Standard.Dock = DockStyle.Fill;
                Main_ConductorPanel.Controls.Add(cable_Standard);


            }
            else if (InpustDataTransmitionLine.SelectedItem.Equals(ConductorTypeEnum.Standad_Conductor_data) && doubleCircuitLine.LineConductor.LineConductorType.Equals(LineConductorTypeEnum.Cable))
            {
                Main_ConductorPanel.Controls.Clear();
                cable_Standard.Dock = DockStyle.Fill;
                Main_ConductorPanel.Controls.Add(cable_Standard);

            }

            else if (InpustDataTransmitionLine.SelectedItem.Equals(ConductorTypeEnum.Condactor_data_for_Rebuild) && doubleCircuitLine.LineConductor.LineConductorType.Equals(LineConductorTypeEnum.Cable))
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
            doubleCircuitLine.StabilityLines.Remove(line);
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

        private void DoubleCircuitSave_Click(object sender, EventArgs e)
        {
            Save();
        }
        public bool Save()
        {
            try
            {
                doubleCircuitLine.eMTModelTypeEnum = (EMTModelTypeEnum)EMTModelTypeCombo.SelectedItem;
                if (doubleCircuitLine.ToBus != null)
                {
                    doubleCircuitLine.ToBus.BusNumber = long.Parse(ToBusNumber.Text);
                    doubleCircuitLine.ToBus.BusName = ToBusName.Text;
                    doubleCircuitLine.ToBus.area.Name = ToBusArea.Text;
                    doubleCircuitLine.ToBus.nominalVoltage = float.Parse(ToBusNominal.Text);
                }
                if (doubleCircuitLine.FromBus != null)
                {
                    doubleCircuitLine.FromBus.BusName = FromBusName.Text;
                    doubleCircuitLine.FromBus.BusNumber = long.Parse(FromBusNumber.Text);
                    doubleCircuitLine.FromBus.area.Name = FromBusArea.Text;
                    doubleCircuitLine.FromBus.nominalVoltage = float.Parse(FromBusNominal.Text);
                }
                ///
                doubleCircuitLine.lengthType = (LengthType)LineLengthUnitTypeCombo.SelectedItem;
                doubleCircuitLine.eMTModelTypeEnum = (EMTModelTypeEnum)EMTModelTypeCombo.SelectedItem;
                doubleCircuitLine.RzeroSequence = float.Parse(RzeroSeqImp.Text);
                doubleCircuitLine.XzeroSequence = float.Parse(XzeroSeqImp.Text);
                doubleCircuitLine.BzeroSequence = float.Parse(BzeroSeqImp.Text);
                doubleCircuitLine.GzeroSequence = float.Parse(GzeroSeqImp.Text);

                doubleCircuitLine.Resistance = float.Parse(SerseReistanceTXT.Text);
                doubleCircuitLine.Reactance = float.Parse(SeriseReactancexTXT.Text);
                doubleCircuitLine.Charging = float.Parse(SeriseChargingTXT.Text);
                doubleCircuitLine.Conductance = float.Parse(SeriseConductanceTXT.Text);
                doubleCircuitLine.LineConductor.LineConductorType = LineConductorTypeEnum.TransmissionLine;
                //    Identitytxt.Text = doubleCircuitLine.Identity.ToString();
                doubleCircuitLine.LineLengthvalue = float.Parse(lineLengthval.Text);
                doubleCircuitLine.Name = LineName.Text;
                doubleCircuitLine.Inservice = Lineinservice.Checked;
                ///
                doubleCircuitLine.Identity = Identitytxt.Text;
                doubleCircuitLineBL.edit(doubleCircuitLine, CustomContentControl.getCurrentCase());
                return true;
            }
            catch
            {
                MessageBox.Show("Save Record Exception");
                return false;
            }

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
