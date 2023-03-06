using network;
using persistent.enumeration.Transformer;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace GUI.Transformer.TestData
{
    public partial class gradientPanelZeroSeqImpedance : Form
    {
        public gradientPanelZeroSeqImpedance(MainTransformers transformer)
        {
            InitializeComponent();
            ExcitedWindingComboBox.DataSource = Enum.GetValues(typeof(ExcitedWindingEnum)).Cast<ExcitedWindingEnum>().ToList();
            GrandientPanelZ0.Text = transformer.testData.grandientPanel.Z0.ToString();
            GrandientPanelX0R0.Text = transformer.testData.grandientPanel.X0R0.ToString();
        }
    }
}
