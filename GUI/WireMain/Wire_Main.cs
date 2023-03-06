using BL.WireBL;
using GUI.New_concept_WPF;
using GUI.New_concept_WPF.Utility;
using persistent.network.wire;
using Syncfusion.UI.Xaml.Diagram;
using System.Windows.Forms;

namespace GUI.WireMain
{
    public partial class Wire_Main : Form
    {

        Wire wire;
        WireBL wirebl;
        public Wire_Main(Wire wires)
        {
            InitializeComponent();
            this.wire = wires;
            wirebl = new WireBL();
            loaddata();
            //this.wire = wire;
        }

        public void loaddata()
        {
            string tempFrom = "Disconnect";
            string tempTo = "Disconnect";
            if (this.wire.from != null)
            {
                if (this.wire.from is CoreConnector)
                {

                    tempFrom = (this.wire.from as CoreConnector).Name;
                }
                if (this.wire.from is NodeViewModel)
                {
                    tempFrom = Utils.WireEnd(this.wire.from as NodeViewModel);
                    //tempFrom = (this.wire.from as NodeViewModel).Name;
                }
            }
            Fromwire.Text = tempFrom;
            if (this.wire.to != null)
            {
                if (this.wire.to is CoreConnector)
                {
                    tempTo = (this.wire.to as CoreConnector).Name;
                }
                if (this.wire.to is NodeViewModel)
                {
                    tempTo = Utils.WireEnd(this.wire.to as NodeViewModel);
                    //tempTo = (this.wire.to as NodeViewModel).Name;
                }
            }

            towire.Text = tempTo;

        }
    }
}
