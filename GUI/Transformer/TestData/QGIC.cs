using network;
using persistent.network.Transformers;
using Syncfusion.WinForms.DataGrid;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GUI.Transformer.TestData
{
    public partial class QGIC : Form
    {
        List<QGICCharacteristic> qGICCharacteristics;
        public QGIC(MainTransformers transformer)
        {
            InitializeComponent();
            createDataGrid();
            qGICCharacteristics = new List<QGICCharacteristic>();
            QGICCharacteristicDataGrid.DataSource = qGICCharacteristics;
        }

        public void createDataGrid()
        {
            QGICCharacteristicDataGrid.AutoGenerateColumns = false;
            this.QGICCharacteristicDataGrid.Columns.Add(new GridTextColumn() { MappingName = "GIC", HeaderText = "GIC" });
            this.QGICCharacteristicDataGrid.Columns.Add(new GridTextColumn() { MappingName = "MVAR", HeaderText = "MVAR" });
            //this.QGICCharacteristicDataGrid.AutoSizeColumnsMode.
        }
    }
}
