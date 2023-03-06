using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BL;
using network;
using persistent.enumeration;
using persistent.line;
using Syncfusion.WinForms.DataGrid;

namespace GUI.Line.Condcutor_Data
{
    public partial class TransmissionLine_Standard : UserControl
    {
        Single3phaseLineBL single3PhaseLineBL;
        LineBranches line;
        List<string> selectedList = new List<string>();
        public TransmissionLine_Standard(LineBranches lineBranches)
        {
           

            InitializeComponent();
            this.line = lineBranches;
            GenerationValueOnTransmissionLinedataGrid();
            lengthTypeUnitT.DataSource = Enum.GetValues(typeof(LengthUnitType)).Cast<LengthUnitType>().ToList();
            

        }
        private void ThickDiam_CheckedChanged(object sender, EventArgs e)
        {
            if (ThickDiam.CheckState.Equals(CheckState.Checked))
            {
                ThickDiam.Checked = true;
                None.Checked = false;
                Solidconductor.Checked = false;
                Thickvalue.Enabled = true;
                Thickvalue.Value = line.LineConductor.skinEffect.Thick;

            }
            else if (ThickDiam.CheckState.Equals(CheckState.Unchecked)) {

                ThickDiam.Checked = false;
                Thickvalue.Enabled = false;
                None.Checked = false;
                Solidconductor.Checked = false;
            }

        }
        private void Solidconductor_Click(object sender, EventArgs e)
        {
            if (Solidconductor.Checked == true)
            {
                Solidconductor.Checked = true;
                ThickDiam.Checked = false;
                None.Checked = false;
                Thickvalue.Enabled = false;
                Thickvalue.Value = 0;

            }
            else if (Solidconductor.Checked == false)
            {

                Solidconductor.Checked = false;
                Thickvalue.Enabled = false;
                ThickDiam.Checked = false;
                None.Checked = false;

            }
        }
        private void None_Click(object sender, EventArgs e)
        {
            if (None.CheckState.Equals(CheckState.Checked))
            {
                None.Checked = true;
                ThickDiam.Checked = false;
                Solidconductor.Checked = false;
                Thickvalue.Enabled = false;
                Thickvalue.Value = 0;

            }
            else if (None.CheckState.Equals(CheckState.Unchecked))
            {

                None.Checked = false;
                Thickvalue.Enabled = false;
                ThickDiam.Checked = false;
                Solidconductor.Checked = false;

            }

        }
        private void ThickDiam_Click(object sender, EventArgs e)
        {
            if (ThickDiam.CheckState.Equals(CheckState.Checked))
            {
                ThickDiam.Checked = true;
                None.Checked = false;
                Solidconductor.Checked = false;
                Thickvalue.Enabled = true;
                Thickvalue.Value = line.LineConductor.skinEffect.Thick;
                

            }
            else if (ThickDiam.CheckState.Equals(CheckState.Unchecked))
            {

                ThickDiam.Checked = false;
                Thickvalue.Enabled = false;
                None.Checked = false;
                Solidconductor.Checked = false;
            }
        }
        
        private void Bundledconductor_CheckedChanged(object sender, EventArgs e)
        {


            if (Bundledconductor.CheckState.Equals(CheckState.Checked))
            {
                Bundledconductor.Checked = true;
                numofconductorvalue.Enabled = true;
                spacingvalue.Enabled = true;
                Angularpositionvalue.Enabled = true;

                numofconductorvalue.Value = line.LineConductor.skinEffect.NumberConductorBundle;
                spacingvalue.Value = line.LineConductor.skinEffect.Spacing;
                Angularpositionvalue.Value = line.LineConductor.skinEffect.AngularPosition;

            }
            else if (Bundledconductor.CheckState.Equals(CheckState.Unchecked))
            {

                Bundledconductor.Checked = false;
                numofconductorvalue.Enabled = false;
                spacingvalue.Enabled = false;
                Angularpositionvalue.Enabled = false;

            }



        }
        
        private void Solidconductor_CheckedChanged(object sender, EventArgs e)
        {
            if (Solidconductor.CheckState.Equals(CheckState.Checked))
            {
                Solidconductor.Checked = true;
                ThickDiam.Checked = false;
                None.Checked = false;
                Thickvalue.Enabled = false;
                Thickvalue.Value = 0;

            }
            else if (None.CheckState.Equals(CheckState.Unchecked))
            {

                Solidconductor.Checked = false;
                Thickvalue.Enabled = false;
                ThickDiam.Checked = false;
                None.Checked = false;

            }
        }
        private void None_CheckedChanged(object sender, EventArgs e)
        {
            if (None.CheckState.Equals(CheckState.Checked))
            {
                None.Checked = true;
                ThickDiam.Checked = false;
                Solidconductor.Checked = false;
                Thickvalue.Enabled = false;
                Thickvalue.Value = 0;

            }
            else if (None.CheckState.Equals(CheckState.Unchecked))
            {

                None.Checked = false;
                Thickvalue.Enabled = false;
                ThickDiam.Checked = false;
                Solidconductor.Checked = false;

            }
        }
        public void GenerationValueOnTransmissionLinedataGrid()
        {
            var PhaseCount= Numberof3phasecircuitsvalue.Value; 
             var SheildCount = NumberofSkywiresShieldwiresvalue.Value;
            List<TransmissionLineData> transmissionLineDatas = new List<TransmissionLineData>();
            for (int i =0 ; i < PhaseCount; i++)
            {

                transmissionLineDatas.AddRange(LineConductor.CreateTransmissionLineData(Convert.ToInt32(SheildCount)));

            }
            dataGridTransmission.AutoGenerateColumns = false;

            dataGridTransmission.Columns.Add(new GridTextColumn() { MappingName = "Cirrcuit", HeaderText = "Cirrcuit" });
            dataGridTransmission.Columns.Add(new GridTextColumn() { MappingName = "TypeEnum", HeaderText = "Phase-A" });
            dataGridTransmission.Columns.Add(new GridTextColumn() { MappingName = "TypeEnum", HeaderText = "Phase-B" });
            dataGridTransmission.Columns.Add(new GridTextColumn() { MappingName = "TypeEnum", HeaderText = "Phase-C" });
            dataGridTransmission.Columns.Add(new GridTextColumn() { MappingName = "TypeEnum", HeaderText = "Skywire/Shieldwire" });
            dataGridTransmission.Columns.Add(new GridTextColumn() { MappingName = "Wire", HeaderText = "Wire" });
            dataGridTransmission.Columns.Add(new GridTextColumn() { MappingName = "DCresistance", HeaderText = "DCresistance" });
            dataGridTransmission.Columns.Add(new GridTextColumn() { MappingName = "Outside", HeaderText = "Outsidediameter" });
            dataGridTransmission.Columns.Add(new GridTextColumn() { MappingName = "Horizontaldistance", HeaderText = "Horizontaldistance" });
            dataGridTransmission.Columns.Add(new GridTextColumn() { MappingName = "VerticalHeigthAtTower", HeaderText = "VerticalHeigthattower" });
            dataGridTransmission.Columns.Add(new GridTextColumn() { MappingName = "VerticalHeigthAtMidspan", HeaderText = "VerticalHeigthatMidspan" });

            dataGridTransmission.DataSource = transmissionLineDatas;

        }

        private void ThickDiam_CheckedChanged_1(object sender, EventArgs e)
        {
            if(ThickDiam.Checked == true)
            {
                Thickvalue.Enabled = true;
            }else if (ThickDiam.Checked == false)
            {
                Thickvalue.Enabled = false;
            }
        }

        private void Bundledconductor_CheckedChanged_1(object sender, EventArgs e)
        {

            if (Bundledconductor.Checked == true)
            {
                numofconductorvalue.Enabled = true;
                spacingvalue.Enabled = true;
                Angularpositionvalue.Enabled = true;
            }
            else if (Bundledconductor.Checked == false)
            {
                numofconductorvalue.Enabled = false;
                spacingvalue.Enabled = false;
                Angularpositionvalue.Enabled = false;
            }
        }

        private void lengthTypeUnitT_SelectedIndexChanged(object sender, EventArgs e)
        {
         

                if (lengthTypeUnitT.SelectedItem.Equals(LengthUnitType.Metric))
                {
                    kmT.Visible = true;
                    mileT.Visible = false;

                }
                else
                {
                    kmT.Visible = false;
                    mileT.Visible = true;
                }
            
        }

        private void Numberof3phasecircuitsvalue_ValueChanged(object sender, EventArgs e)
        {
            GenerationValueOnTransmissionLinedataGrid();
           // if (. == 1 && e.RowIndex == 1)
            {

            }
        }

        private void NumberofSkywiresShieldwiresvalue_ValueChanged(object sender, EventArgs e)
        {
            GenerationValueOnTransmissionLinedataGrid();
        }

        private void Transmission_Maingroupbox_Leave(object sender, EventArgs e)
        {
            MessageBox.Show("Don't Leave ME");
        }
    }
    
}
