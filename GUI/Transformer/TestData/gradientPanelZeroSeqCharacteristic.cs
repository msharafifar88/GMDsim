using network;
using persistent.enumeration.Transformer;
using persistent.network.Transformers;
using Syncfusion.WinForms.DataGrid;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace GUI.Transformer.TestData
{
    public partial class gradientPanelZeroSeqCharacteristic : Form
    {
        List<ZeroSequenceCharacteristc> zeroSequenceCharacteristcs;
        public gradientPanelZeroSeqCharacteristic(MainTransformers transformer)
        {
            InitializeComponent();
            CreateDataGrid();
            this.ExcitedWindingComboBox.DataSource = Enum.GetValues(typeof(ExcitedWindingEnum)).Cast<ExcitedWindingEnum>().ToList();
            zeroSequenceCharacteristcs = new List<ZeroSequenceCharacteristc>();
            ZeroSequenceDataGrid.DataSource = zeroSequenceCharacteristcs;
        }


        public void CreateDataGrid()
        {
            ZeroSequenceDataGrid.AutoGenerateColumns = false;
            this.ZeroSequenceDataGrid.Columns.Add(new GridTextColumn() { MappingName = "Current", HeaderText = "Current (A)" });
            this.ZeroSequenceDataGrid.Columns.Add(new GridTextColumn() { MappingName = "Flux", HeaderText = "Flux (V.s)" });
        }
    }
}
