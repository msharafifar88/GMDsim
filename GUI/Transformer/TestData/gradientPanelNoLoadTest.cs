using network;
using persistent.enumeration;
using persistent.enumeration.Transformer;
using persistent.network.Transformers;
using Syncfusion.WinForms.DataGrid;
using Syncfusion.WinForms.DataGrid.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace GUI.Transformer.TestData
{
    public partial class gradientPanelNoLoadTest : Form
    {
        List<CurrentVoltageLossUnit> currentVoltageLosses;
        public gradientPanelNoLoadTest(MainTransformers transformer)
        {
            InitializeComponent();
            createDataGrid();
            CVLComboBox();
            ExcitedWindingComboBox.DataSource = Enum.GetValues(typeof(ExcitedWindingEnum)).Cast<ExcitedWindingEnum>().ToList();
            currentVoltageLosses = new List<CurrentVoltageLossUnit>();
            NoLoadTestDataGrid.DataSource = currentVoltageLosses;
            HysteresisLossVAL.Text = transformer.testData.hypsteresisCharacteristic.HL.ToString();
            ECLval.Text = transformer.testData.hypsteresisCharacteristic.ECL.ToString();
            ELval.Text = transformer.testData.hypsteresisCharacteristic.HL.ToString();

        }

        public void createDataGrid()
        {
            NoLoadTestDataGrid.AutoGenerateColumns = false;
            this.NoLoadTestDataGrid.Columns.Add(new GridTextColumn() { MappingName = "Current", HeaderText = "Current (ARMS)" });
            this.NoLoadTestDataGrid.Columns.Add(new GridTextColumn() { MappingName = "Voltage", HeaderText = "Voltage (pu)" });
            this.NoLoadTestDataGrid.Columns.Add(new GridTextColumn() { MappingName = "Loss", HeaderText = "Flux (kW)" });
            this.NoLoadTestDataGrid.AddNewRowPosition = RowPosition.FixedTop;
            this.NoLoadTestDataGrid.AddNewRowText = "Click to add new row";
        }

        public void CVLComboBox()
        {
            List<string> s = new List<string>();
            s.Add(EnumUtil.GetDisplayName(CurrentVoltageLossUnitsEnum.A_PU_KW));
            s.Add(EnumUtil.GetDisplayName(CurrentVoltageLossUnitsEnum.PU_PU_PU));
            this.CLVunit.DataSource = s;
        }

        private void checkBoxUseHypsteresisCharacteristic_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxUseHypsteresisCharacteristic.Checked == true)
            {
                gradientPanelPowerLossConribut.Enabled = true;
            }
            else if (checkBoxUseHypsteresisCharacteristic.Checked == false)
            {
                gradientPanelPowerLossConribut.Enabled = false;
            }
        }

        private void HysteresisLossVAL_TextChanged(object sender, EventArgs e)
        {

            ELval.Text = (100 - (double.Parse(ECLval.Text) + double.Parse(HysteresisLossVAL.Text))).ToString();
        }

        private void ECLval_TextChanged(object sender, EventArgs e)
        {
            ELval.Text = (100 - (double.Parse(ECLval.Text) + double.Parse(HysteresisLossVAL.Text))).ToString();
        }

        private void checkBoxUnknown_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxUnknown.Checked == true)
            {
                ExcitedWindingComboBox.Enabled = false;
            }
            else if (checkBoxUnknown.Checked == false)
            {
                ExcitedWindingComboBox.Enabled = true;
            }
        }

        private void NoLoadTestDataGrid_Click(object sender, EventArgs e)
        {

        }
    }
}
