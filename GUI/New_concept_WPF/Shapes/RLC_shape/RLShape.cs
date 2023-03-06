using BL;
using GUI.New_concept_WPF;
using GUI.New_concept_WPF.Custom_Controls.CustomPort;
using GUI.New_concept_WPF.Utility;
using network;
using Syncfusion.UI.Xaml.Diagram;
using Syncfusion.UI.Xaml.Diagram.Controls;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Media;

namespace Shapes.RLC
{

    class RLShape : AbstractRLCCShape, ICloneable, IDiagramShape
    {
        private RLCbranches rlcBranches;
        private string urlImg = "/Image/rl.png";
        private int xDim = 30, yDim = 50;

        public RLShape()
        {
            this.Name = "RLShape";
            this.Content = Utils.addImage(urlImg, xDim, yDim);
            this.Constraints = NodeConstraints.Default & ~(NodeConstraints.Rotatable | NodeConstraints.InheritRotatable) & ~(NodeConstraints.Resizable | NodeConstraints.InheritResizable) & ~NodeConstraints.Connectable;
            this.PortVisibility = PortVisibility.Collapse;
            this.setStyles(30, 50);
        }

        public RLShape(bool isCloneOne)
        {
            this.isClonedOne = isCloneOne;
            this.cases = CustomContentControl.getCurrentCase();
            this.Name = "RLShape";
            this.Content = Utils.addImage(urlImg, xDim, yDim);
            this.Constraints = NodeConstraints.Default & ~(NodeConstraints.Rotatable | NodeConstraints.InheritRotatable) & ~(NodeConstraints.Resizable | NodeConstraints.InheritResizable) & ~NodeConstraints.Connectable;
            this.PortVisibility = PortVisibility.Collapse;
            this.setStyles(30, 50);
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
        CustomPort port1 = new CustomPort(true);
        CustomPort port2 = new CustomPort(true);

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
            IRlcBL rlBL = new RlBL();
            rlcBranches = (RL)rlBL.add(base.cases);
            rlcBranches.branch = "RL";
            label.Content = "RL " + rlcBranches.number;
            label.Offset = new System.Windows.Point(-0.5, 0);
            //Margin = new System.Windows.Thickness(23, 10, 0, 0),
            label2.Content = rlcBranches.number;
            label2.Offset = new System.Windows.Point(-0.5, 0.2);

            port1.Owner = "RLC";
            port1.UnitHeight = 7;
            port1.UnitWidth = 7;
            port1.NodeOffsetX = 1;
            port1.NodeOffsetY = 0.6;
            port1.Displacement = new Thickness(0.5, 1, 1, 1);
            port1.Shape = new RectangleGeometry() { Rect = new Rect(0, 0, 10, 10) };
            port1.ShapeStyle.Setters.Add(new Setter(System.Windows.Shapes.Path.FillProperty, Brushes.Orange));
            port1.ShapeStyle.Setters.Add(new Setter(System.Windows.Shapes.Path.StrokeProperty, Brushes.Orange));
            port1.Constraints = PortConstraints.Connectable & ~PortConstraints.InheritConnectable;
            port1.PortVisibility = PortVisibility.MouseOver;
            port1.HitPadding = 10;
            port2.Owner = "RLC";
            port2.UnitHeight = 7;
            port2.UnitWidth = 7;
            port2.NodeOffsetX = 0;
            port2.NodeOffsetY = 0.6;
            port2.Displacement = new Thickness(0, 0.5, 1, 0);
            port2.Constraints = PortConstraints.Connectable & ~PortConstraints.InheritConnectable;
            port2.Shape = new RectangleGeometry() { Rect = new Rect(0, 0, 10, 10) };
            port2.ShapeStyle.Setters.Add(new Setter(System.Windows.Shapes.Path.FillProperty, Brushes.Orange));
            port2.ShapeStyle.Setters.Add(new Setter(System.Windows.Shapes.Path.StrokeProperty, Brushes.Orange));
            port2.PortVisibility = PortVisibility.MouseOver;
            port2.HitPadding = 10;
        }

        public override void setLabel(string name)
        {
            this.label.Content = long.TryParse(name, out _) ? "LC " + name : name; ;
        }

        public override RLCbranches getRLCBranch()
        {
            return rlcBranches;
        }

        public override void setRLCBranch(RLCbranches rlcbranch)
        {
            this.rlcBranches = rlcbranch;
        }

        private void setStyles(double h, double w)
        {
            this.UnitHeight = h;
            this.UnitWidth = w;
        }

        public override object Clone()
        {
            //throw new NotImplementedException();
            RLShape clonedObject = new RLShape(true);
            clonedObject.cases = this.cases;
            clonedObject.rlcBranches = this.rlcBranches;
            return clonedObject;
        }
    }
}
