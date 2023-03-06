using BL;
using GUI.New_concept_WPF;
using GUI.New_concept_WPF.Custom_Controls.CustomPort;
using GUI.New_concept_WPF.Utility;
using network;
using Syncfusion.UI.Xaml.Diagram;
using Syncfusion.UI.Xaml.Diagram.Controls;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Media;

namespace Shapes.Transformer
{
    class YgDDTShape : AbstractTShape, IDiagramShape
    {
        private MainTransformers transformerTypes;
        private string urlImg = "/Image/YgDD_transformer.png";
        private int xDim = 70, yDim = 70;

        public YgDDTShape()
        {
            this.Name = "YgDDTransformerShape";
            this.Content = Utils.addImage(urlImg, xDim, yDim);
            this.Constraints = NodeConstraints.Default & ~(NodeConstraints.Rotatable | NodeConstraints.InheritRotatable) & ~(NodeConstraints.Resizable | NodeConstraints.InheritResizable) & ~NodeConstraints.Connectable;
            this.PortVisibility = PortVisibility.Collapse;
            this.setStyles(70, 72);
        }

        public YgDDTShape(bool isCloneOne)
        {
            this.isClonedOne = isCloneOne;
            this.cases = CustomContentControl.getCurrentCase();
            this.Name = "YgDDTransformerShape";
            this.Content = Utils.addImage(urlImg, xDim, yDim);
            this.Constraints = NodeConstraints.Default & ~(NodeConstraints.Rotatable | NodeConstraints.InheritRotatable) & ~(NodeConstraints.Resizable | NodeConstraints.InheritResizable) & ~NodeConstraints.Connectable;
            this.PortVisibility = PortVisibility.Collapse;
            this.setStyles(70, 72);
        }

        public void Init(bool isLoadAction)
        {
            if (isLoadAction)
            {
                if (this.Annotations is ObservableCollection<IAnnotation> annotations && annotations.Count == 1)
                {
                    label = annotations[0] as AnnotationEditorViewModel;
                }

                if (this.Ports is PortCollection ports && ports.Count == 3)
                {
                    port1 = ports[0] as CustomPort;
                    port2 = ports[1] as CustomPort;
                    port3 = ports[2] as CustomPort;
                }
            }

            this.CreateChildElements();

            if (!isLoadAction)
            {
                this.Annotations = new ObservableCollection<IAnnotation>() { label };
                this.Ports = new PortCollection() { port1, port2, port3 };
            }
        }

        AnnotationEditorViewModel label = new AnnotationEditorViewModel();
        CustomPort port1 = new CustomPort();
        CustomPort port2 = new CustomPort();
        CustomPort port3 = new CustomPort();

        public void ResetChildElements()
        {
            // Reset local variable of annotation on load
            if (this.Annotations is ObservableCollection<IAnnotation> annotations && annotations.Count == 1)
            {
                label = annotations[0] as AnnotationEditorViewModel;
            }
            if (this.Ports is PortCollection ports && ports.Count == 3)
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

                port3 = ports[2] as CustomPort;
                port3.Shape = new RectangleGeometry() { Rect = new Rect(0, 0, 10, 10) };
                port3.ShapeStyle.Setters.Add(new Setter(System.Windows.Shapes.Path.FillProperty, Brushes.Orange));
                port3.ShapeStyle.Setters.Add(new Setter(System.Windows.Shapes.Path.StrokeProperty, Brushes.Orange));
                port3.PortVisibility = PortVisibility.MouseOver;
                port3.HitPadding = 10;
            }
        }

        private void CreateChildElements()
        {
            ITransformer iTransformer = new YgDDTransformerBL();
            transformerTypes = (YgDDTransformer)iTransformer.add(base.cases);
            transformerTypes.type = "YgDD";
            label.Content = "YgDD " + transformerTypes.number;
            label.Offset = new System.Windows.Point(-0.5, 0);
            label.ReadOnly = true;

            port1.UnitHeight = 7;
            port1.UnitWidth = 7;
            port1.NodeOffsetX = 0;
            port1.NodeOffsetY = 0.5;
            port1.Displacement = new Thickness(0.5, 1, 1, 1);
            port1.Shape = new RectangleGeometry() { Rect = new Rect(0, 0, 10, 10) };
            port1.ShapeStyle.Setters.Add(new Setter(System.Windows.Shapes.Path.FillProperty, Brushes.Orange));
            port1.ShapeStyle.Setters.Add(new Setter(System.Windows.Shapes.Path.StrokeProperty, Brushes.Orange));
            port1.Constraints = PortConstraints.Connectable & ~PortConstraints.InheritConnectable;
            port1.PortVisibility = PortVisibility.MouseOver;
            port1.HitPadding = 10;
            port2.UnitHeight = 7;
            port2.UnitWidth = 7;
            port2.NodeOffsetX = 1;
            port2.NodeOffsetY = 0.28;
            port2.Displacement = new Thickness(0, 0.5, 1, 0);
            port2.Constraints = PortConstraints.Connectable & ~PortConstraints.InheritConnectable;
            port2.Shape = new RectangleGeometry() { Rect = new Rect(0, 0, 10, 10) };
            port2.ShapeStyle.Setters.Add(new Setter(System.Windows.Shapes.Path.FillProperty, Brushes.Orange));
            port2.ShapeStyle.Setters.Add(new Setter(System.Windows.Shapes.Path.StrokeProperty, Brushes.Orange));
            port2.PortVisibility = PortVisibility.MouseOver;
            port2.HitPadding = 10;
            port3.UnitHeight = 7;
            port3.UnitWidth = 7;
            port3.NodeOffsetX = 1;
            port3.NodeOffsetY = 0.68;
            port3.Displacement = new Thickness(0, 0.5, 1, 0);
            port3.Constraints = PortConstraints.Connectable & ~PortConstraints.InheritConnectable;
            port3.Shape = new RectangleGeometry() { Rect = new Rect(0, 0, 10, 10) };
            port3.ShapeStyle.Setters.Add(new Setter(System.Windows.Shapes.Path.FillProperty, Brushes.Orange));
            port3.ShapeStyle.Setters.Add(new Setter(System.Windows.Shapes.Path.StrokeProperty, Brushes.Orange));
            port3.PortVisibility = PortVisibility.MouseOver;
            port3.HitPadding = 10;
        }

        public override MainTransformers getTransformerType()
        {
            return transformerTypes;
        }

        public override void setTransformerType(MainTransformers transformer)
        {
            this.transformerTypes = transformer;
        }

        public override void setLabel(string name)
        {
            this.label.Content = long.TryParse(name, out _) ? "YgDD " + name : name;
        }

        private void setStyles(double h, double w)
        {
            this.UnitHeight = h;
            this.UnitWidth = w;
        }

        public override object Clone()
        {
            YgDDTShape clonedObject = new YgDDTShape(true);
            clonedObject.cases = this.cases;
            clonedObject.transformerTypes = this.transformerTypes;
            return clonedObject;
        }
    }
}
