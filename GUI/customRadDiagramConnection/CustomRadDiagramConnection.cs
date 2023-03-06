using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.Svg;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Diagrams;

namespace GUI.customRadDiagramConnection
{
    public class CustomRadDiagramConnection : RadDiagramConnection
    {
        private string name { get; set; }
        private double signalVoltage { get; set; }
        List<RadDiagramConnector> conn = new List<RadDiagramConnector>();
       
        public CustomRadDiagramConnection(Color color, string type) {
           
            this.IsFocusable = true;
            this.signalVoltage = 0;
            this.name = "BUS";
            base.BackColor = color;
            base.IsConnectorsManipulationEnabled = false;
            base.ConnectionType = Telerik.Windows.Diagrams.Core.ConnectionType.Polyline;
            base.IsHitTestVisible = true;
            this.IsEditable = false;
            this.DoubleClickEnabled = true;
            //base.IsMouseDown = true;
            this.conn.Clear();
            this.signalVoltage = 0;
            this.name = type;
            this.MouseDoubleClick += CustomRadDiagramConnection_MouseDoubleClick;
            this.IsSelected = true;
           
        }
        

        private void CustomRadDiagramConnection_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("hey");
        }

        public Dictionary<string, object> getData() {
            Dictionary<string, object> temp = new Dictionary<string, object>() { 
                {"name", this.name },
                {"signalVoltage", this.signalVoltage } };
            return temp;
        } 

        private void CustomRadDiagramConnection_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            var location = e.Location;
            if (e.Clicks == 1) {

                /*conn.Add(new RadDiagramConnector()
                {
                    Offset = new Telerik.Windows.Diagrams.Core.Point(location),
                    Name = this.Name + "Conn " + conn.Count()
                }); */
                this.AddConnectionPoint(location);

            }
        }
    }
}
