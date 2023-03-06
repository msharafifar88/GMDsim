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
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Shapes.Line
{
    public class LineShape : NodeViewModel, ICloneable, IDiagramShape
    {
        private Case cases;
        private Single3phaseLine single3phaseLineitem;
        private string urlImg = "/Image/line_shape.png";
        private bool isClonedOne;
        private int xDim = 60, yDim = 70;

        public LineShape()
        {
            this.cases = CustomContentControl.getCurrentCase();
            this.Name = "LineShape";
            this.Content = Utils.addImage("/Image/line_shape.png", xDim, yDim);
            this.Constraints = NodeConstraints.Default & ~(NodeConstraints.Rotatable | NodeConstraints.InheritRotatable) & ~(NodeConstraints.Resizable | NodeConstraints.InheritResizable) & ~NodeConstraints.Connectable;
            this.PortVisibility = PortVisibility.Collapse;
            this.setStyles(70, 70);
        }

        public LineShape(bool isCloneOne)
        {
            this.isClonedOne = isCloneOne;
            this.cases = CustomContentControl.getCurrentCase();
            this.Name = "LineShape";
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
            Single3phaseLineBL single3phaseLineBL = new Single3phaseLineBL();
            single3phaseLineitem = single3phaseLineBL.addLine(this.cases);

            single3phaseLineitem.Branch = "DoubleCircuit";
            label.Content = "Double" + single3phaseLineitem.Number;
            label.Offset = new System.Windows.Point(-0.5, 0);
            //Margin = new System.Windows.Thickness(23, 10, 0, 0),
            label2.Content = single3phaseLineitem.Number;
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
        private void setStyles(double h, double w)
        {
            this.UnitHeight = h;
            this.UnitWidth = w;
        }

        public Single3phaseLine GetLine()
        {
            return single3phaseLineitem;
        }

        public void setLine(Single3phaseLine line)
        {
            this.single3phaseLineitem = line;
        }

        public void setLabel(string name)
        {
            this.label.Content = long.TryParse(name, out _) ? "LineShape " + name : name;
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
            LineShape clonedObject = new LineShape(true);
            clonedObject.cases = this.cases;
            clonedObject.single3phaseLineitem = this.single3phaseLineitem;
            return clonedObject;
        }
    }
}



