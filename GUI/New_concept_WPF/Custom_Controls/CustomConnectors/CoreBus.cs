using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.New_concept_WPF.Custom_Controls.CustomConnectors
{
    class CoreBus : CoreConnector
    {
        public CoreBus() {
            setType("Bus");
            System.Windows.Style style = new System.Windows.Style(typeof(System.Windows.Shapes.Path));
            style.Setters.Add(new System.Windows.Setter(System.Windows.Shapes.Path.StrokeProperty, System.Windows.Media.Brushes.Gray));
            style.Setters.Add(new System.Windows.Setter(System.Windows.Shapes.Path.StrokeThicknessProperty, 2d));
            this.ConnectorGeometryStyle = style;
        }
    }
}
