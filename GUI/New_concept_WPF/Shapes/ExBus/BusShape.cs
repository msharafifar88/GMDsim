using GUI.New_concept_WPF;
using network;
using persistent;
using Syncfusion.UI.Xaml.Diagram;
using Syncfusion.UI.Xaml.Diagram.Controls;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Media;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Shapes.ExBus
{
    public class BusShape : BpmnNodeViewModel, IXmlSerializable
    {

        private Case cases;
        private Bus busShape;

        public BusShape()
        {
            this.cases = CustomContentControl.getCurrentCase();
            this.Name = "BusShape";
            this.Shape = new LineGeometry(new Point(10.2, 19.2), new Point(11.11, 22.2));
            //this.Constraints = NodeConstraints.Default & ~(NodeConstraints.Rotatable | NodeConstraints.InheritRotatable) & ~NodeConstraints.Connectable;
            //this.Constraints = NodeConstraints.Default & ~(NodeConstraints.Rotatable | NodeConstraints.InheritRotatable) & ~(NodeConstraints.Resizable | NodeConstraints.InheritResizable) & ~NodeConstraints.Connectable;
            //this.Constraints = NodeConstraints.Rotatable.Equals;
            // & ~NodeConstraints.Resizable & ~NodeConstraints.Rotatable;
            this.setStyles(10, 200);
            this.createChildElements();
            this.ShapeStyle = new Style(typeof(System.Windows.Shapes.Path));
            this.ShapeStyle.Setters.Add(new Setter(System.Windows.Shapes.Path.FillProperty, Brushes.SteelBlue));

        }


        AnnotationEditorViewModel label = new AnnotationEditorViewModel();
        DockPortViewModel port1 = new DockPortViewModel();
        //DockPortViewModel port2 = new DockPortViewModel();
        private void createChildElements()
        {
            //GeneratorBL generatorBL = new GeneratorBL();
            //genShape = generatorBL.addGenerator(cases);
            //label.Content = genShape.powerControl.setpoint.ToString() + " MW";
            label.Content = "BUS";
            label.Offset = new System.Windows.Point(-0.5, 0);
            label.ReadOnly = true;
            this.Annotations = new ObservableCollection<IAnnotation>() {
                label,
            };
            port1.SourcePoint = new Point(0, 0.5);
            port1.TargetPoint = new Point(1, 0.5);
            port1.ShapeStyle = new Style(typeof(System.Windows.Shapes.Path));
            port1.ShapeStyle.Setters.Add(new Setter(System.Windows.Shapes.Path.FillProperty, Brushes.Orange));
            port1.ShapeStyle.Setters.Add(new Setter(System.Windows.Shapes.Path.StrokeThicknessProperty, 100));
            //port1.ConnectorGeometryStyle.
            port1.PortVisibility = PortVisibility.Visible;
            //port2.SourcePoint = new Point(0, 0);
            //port2.TargetPoint = new Point(1, 0);
            //port2.ShapeStyle = new Style(typeof(System.Windows.Shapes.Path));
            //port2.ShapeStyle.Setters.Add(new Setter(System.Windows.Shapes.Path.FillProperty, Brushes.Orange));
            //port2.PortVisibility = PortVisibility.MouseOver;
            (this.Ports as PortCollection).Add(port1);
            //(this.Ports as PortCollection).Add(port2);
        }

        private void setStyles(double h, double w)
        {
            this.UnitHeight = h;
            this.UnitWidth = w;
        }

        public Bus getBus()
        {
            return this.busShape;
        }

        private void setBus(Bus bus)
        {
            this.busShape = bus;
        }

        public void setCase(Case cases)
        {
            this.cases = cases;
        }

        public Case getCase()
        {
            return this.cases;
        }

        public void updateLabel(string name)
        {
            label.Content = name;
        }

        public XmlSchema GetSchema()
        {
            throw new NotImplementedException();
        }

        public void ReadXml(XmlReader reader)
        {
            throw new NotImplementedException();
        }

        public void WriteXml(XmlWriter writer)
        {
            throw new NotImplementedException();
        }
    }
}
