using BL;
using GUI.New_concept_WPF;
using GUI.New_concept_WPF.Custom_Controls.CustomPort;
using GUI.New_concept_WPF.Utility;
using network;
using persistent;
using Syncfusion.UI.Xaml.Diagram;
using Syncfusion.UI.Xaml.Diagram.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Shapes.Line
{
    public class DoubleCircuitShape : NodeViewModel, ICloneable, IDiagramShape
    {
        [DataMember]
        private Case cases;
        [DataMember]
        private DoubleCircuitLine doubleCircuitLineitem;
        private string urlImg = "/Image/biphasic_line.png";
        private bool isClonedOne;
        private int xDim = 30, yDim = 70;

        [DataMember]
        public DoubleCircuitLine DoubleCircuitLineItem
        {
            get { return doubleCircuitLineitem; }
            set { if (value != doubleCircuitLineitem) { doubleCircuitLineitem = value; } }
        }
        public DoubleCircuitShape()
        {
            this.cases = CustomContentControl.getCurrentCase();
            this.Name = "DoubleCircuitShape";
            this.Content = Utils.addImage(urlImg, xDim, yDim);
            this.Constraints = NodeConstraints.Default & ~(NodeConstraints.Rotatable | NodeConstraints.InheritRotatable) & ~(NodeConstraints.Resizable | NodeConstraints.InheritResizable) & ~NodeConstraints.Connectable;
            this.PortVisibility = PortVisibility.Collapse;
            this.setStyles(70, 70);
        }

        public DoubleCircuitShape(bool isCloneOne)
        {
            this.isClonedOne = isCloneOne;
            this.cases = CustomContentControl.getCurrentCase();
            this.Name = "DoubleCircuitShape";
            this.Content = Utils.addImage(urlImg, xDim, yDim);
            this.Constraints = NodeConstraints.Default & ~(NodeConstraints.Rotatable | NodeConstraints.InheritRotatable) & ~(NodeConstraints.Resizable | NodeConstraints.InheritResizable) & ~NodeConstraints.Connectable;
            this.PortVisibility = PortVisibility.Collapse;
            this.setStyles(70, 70);
        }

        public void Init(bool isLoadAction)
        {
            if (isLoadAction)
            {
                if (this.Annotations is ObservableCollection<IAnnotation> annotations && annotations.Count == 2)
                {
                    label = annotations[0] as AnnotationEditorViewModel;
                    label2 = annotations[1] as AnnotationEditorViewModel;
                }

                if (this.Ports is PortCollection ports && ports.Count == 2)
                {
                    port1 = ports[0] as CustomPort;
                    port2 = ports[1] as CustomPort;
                }
            }

            this.createChildElements();

            if (!isLoadAction)
            {
                this.Annotations = new ObservableCollection<IAnnotation>() { label, label2 };
                this.Ports = new PortCollection() { port1, port2 };
            }
        }

        AnnotationEditorViewModel label = new AnnotationEditorViewModel();
        AnnotationEditorViewModel label2 = new AnnotationEditorViewModel();
        CustomPort port1 = new CustomPort();
        CustomPort port2 = new CustomPort();

        public void ResetChildElements()
        {
            if (this.Annotations is ObservableCollection<IAnnotation> annotations && annotations.Count == 2)
            {
                label = annotations[0] as AnnotationEditorViewModel;
                label2 = annotations[1] as AnnotationEditorViewModel;
            }

            if (this.Ports is PortCollection ports && ports.Count == 2)
            {
                port1 = ports[0] as CustomPort;
                port1.Shape = new RectangleGeometry() { Rect = new Rect(0, 0, 10, 10) };
                port1.ShapeStyle.Setters.Add(new Setter(System.Windows.Shapes.Path.FillProperty, Brushes.Orange));
                port1.ShapeStyle.Setters.Add(new Setter(System.Windows.Shapes.Path.StrokeProperty, Brushes.Orange));
                port1.PortVisibility = PortVisibility.MouseOver;
                port1.HitPadding = 10;

                port2 = ports[1] as CustomPort;
                port2.Shape = new RectangleGeometry() { Rect = new Rect(0, 0, 10, 10) };
                port2.ShapeStyle.Setters.Add(new Setter(System.Windows.Shapes.Path.FillProperty, Brushes.Orange));
                port2.ShapeStyle.Setters.Add(new Setter(System.Windows.Shapes.Path.StrokeProperty, Brushes.Orange));
                port2.PortVisibility = PortVisibility.MouseOver;
                port2.HitPadding = 10;
            }
        }

        private void createChildElements()
        {
            DoubleCircuitLineBL doubleCircuitLineBL = new DoubleCircuitLineBL();
            if (doubleCircuitLineitem != null)
            {
                doubleCircuitLineBL.create(doubleCircuitLineitem, cases);
            }
            else
            {
                doubleCircuitLineitem = doubleCircuitLineBL.addLine(cases);
            }
            // Update shape
            updateStatus(doubleCircuitLineitem.Inservice);

            doubleCircuitLineitem.Branch = "DoubleCircuit";
            label.Content = "Double" + doubleCircuitLineitem.Number;
            label.Offset = new System.Windows.Point(-0.5, 0);
            label2.Content = doubleCircuitLineitem.Number;
            label2.Offset = new System.Windows.Point(-0.5, 0.2);

            port1.Owner = this.Name;
            port1.Name = "port1";
            port1.UnitHeight = 7;
            port1.UnitWidth = 7;
            port1.NodeOffsetX = 1;
            port1.NodeOffsetY = 0.5;
            port1.Displacement = new Thickness(0.5, 1, 1, 1);
            port1.Shape = new RectangleGeometry() { Rect = new Rect(0, 0, 10, 10) };
            port1.ShapeStyle.Setters.Add(new Setter(System.Windows.Shapes.Path.FillProperty, Brushes.Orange));
            port1.ShapeStyle.Setters.Add(new Setter(System.Windows.Shapes.Path.StrokeProperty, Brushes.Orange));
            port1.Constraints = PortConstraints.Connectable & ~PortConstraints.InheritConnectable;
            port1.PortVisibility = PortVisibility.MouseOver;
            port1.HitPadding = 10;
            port2.Owner = this.Name;
            port2.Name = "port2";
            port2.UnitHeight = 7;
            port2.UnitWidth = 7;
            port2.NodeOffsetX = 0;
            port2.NodeOffsetY = 0.5;
            port2.Displacement = new Thickness(0, 0.5, 1, 0);
            port2.Constraints = PortConstraints.Connectable & ~PortConstraints.InheritConnectable;
            port2.Shape = new RectangleGeometry() { Rect = new Rect(0, 0, 10, 10) };
            port2.ShapeStyle.Setters.Add(new Setter(System.Windows.Shapes.Path.FillProperty, Brushes.Orange));
            port2.ShapeStyle.Setters.Add(new Setter(System.Windows.Shapes.Path.StrokeProperty, Brushes.Orange));
            port2.PortVisibility = PortVisibility.MouseOver;
            port2.HitPadding = 10;
        }

        public void updateStatus(Boolean status)
        {
            if (status)
            {
                this.Content = Utils.addImage(uri: "/Image/biphasic_line.png", xDim, yDim);
            }
            else
            {
                this.Content = Utils.addImage("/Image/biphasic_line.png", xDim, yDim);
            }
        }
        private void setStyles(double h, double w)
        {
            this.UnitHeight = h;
            this.UnitWidth = w;
        }

        public  DoubleCircuitLine GetDoubleCircuitLine()
        {
            return doubleCircuitLineitem;
        }

        public  void setDoubleCircuitLine(DoubleCircuitLine line)
        {
            this.doubleCircuitLineitem = line;
        }

        public  void setLabel(string name)
        {
            this.label.Content = long.TryParse(name, out _) ? "Double " + name : name;
        }

        public void setCase(Case cases)
        {
            this.cases = cases;
        }

        public Case getCase()
        {
            return this.cases;
        }

        public object Clone()
        {
            //throw new NotImplementedException();
            DoubleCircuitShape clonedObject = new DoubleCircuitShape(true);
            clonedObject.cases = this.cases;
            clonedObject.doubleCircuitLineitem = this.doubleCircuitLineitem;
            return clonedObject;
        }
    }
}
