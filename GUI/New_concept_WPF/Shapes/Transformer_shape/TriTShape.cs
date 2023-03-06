using BL;
using GUI.New_concept_WPF;
using GUI.New_concept_WPF.Custom_Controls.CustomPort;
using GUI.New_concept_WPF.Utility;
using network;
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

namespace Shapes.Transformer
{
    class TriTShape : AbstractTShape, IDiagramShape
    {
        private MainTransformers transformerTypes;
        private string urlImg = "/Image/triphasic_transformer.png";
        private int xDim = 45, yDim = 70;

        public TriTShape()
        {
            this.Name = "TriTransformerShape";
            this.Content = Utils.addImage(urlImg, xDim, yDim);
            this.Constraints = NodeConstraints.Default & ~(NodeConstraints.Rotatable | NodeConstraints.InheritRotatable) & ~(NodeConstraints.Resizable | NodeConstraints.InheritResizable) & ~NodeConstraints.Connectable;
            this.PortVisibility = PortVisibility.Collapse;
            this.setStyles(70, 72);
        }

        public TriTShape(bool isCloneOne)
        {
            this.isClonedOne = isCloneOne;
            this.cases = CustomContentControl.getCurrentCase();
            this.Name = "TriTransformerShape";
            this.Content = Utils.addImage(urlImg, xDim, yDim);
            this.Constraints = NodeConstraints.Default & ~(NodeConstraints.Rotatable | NodeConstraints.InheritRotatable) & ~(NodeConstraints.Resizable | NodeConstraints.InheritResizable) & ~NodeConstraints.Connectable;
            this.PortVisibility = PortVisibility.Collapse;
            this.setStyles(70, 72);
        }

        public void Init(bool isLoadAction)
        {
            this.CreateChildElements();
        }

        AnnotationEditorViewModel label = new AnnotationEditorViewModel();
        CustomPort port1 = new CustomPort();
        CustomPort port2 = new CustomPort();

        public void ResetChildElements()
        {
            // Reset local variable of annotation on load
            if (this.Annotations is ObservableCollection<IAnnotation> annotations && annotations.Count == 1)
            {
                label = annotations[0] as AnnotationEditorViewModel;
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
        private void CreateChildElements()
        {
            C3WTransformerBL c3wTransformer = new C3WTransformerBL();
            transformerTypes = (C3WTransformer)c3wTransformer.add(base.cases);
            transformerTypes.type = "3Tra";
            label.Content = "3Tra " + transformerTypes.number;
            label.Offset = new System.Windows.Point(-0.5, 0);
            label.ReadOnly = true;
            this.Annotations = new ObservableCollection<IAnnotation>() {
                label,
            };
            port1.Owner = this.Name;
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

            this.Ports = new PortCollection()
            {
                 port1,
                 port2,
            };

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
            this.label.Content = long.TryParse(name, out _) ? "3Tra " + name : name;
        }

        private void setStyles(double h, double w)
        {
            this.UnitHeight = h;
            this.UnitWidth = w;
        }


        public override object Clone()
        {
            TriTShape clonedObject = new TriTShape(true);
            clonedObject.cases = this.cases;
            clonedObject.transformerTypes = this.transformerTypes;
            return clonedObject;
        }
    }
}
