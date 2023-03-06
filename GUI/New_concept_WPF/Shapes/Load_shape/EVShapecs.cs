using BL;
using network;
using persistent;
using Syncfusion.UI.Xaml.Diagram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Syncfusion.UI.Xaml.Diagram.Controls;
using GUI.New_concept_WPF.Utility;
using System.Windows;
using System.Windows.Media;
using GUI.New_concept_WPF;
using GUI.New_concept_WPF.Custom_Controls.CustomPort;
using persistent.network.load_entitiy;
using BL.Load_BL;

namespace Shapes.Load
{
    public class EVShape : NodeViewModel, ICloneable, IDiagramShape
    {
        private Case cases;
        private EV ev;
        private string urlImg = "/Image/EV.png";
        private bool isClonedOne;
        private int xDim = 50, yDim = 50;

        public EVShape()
        {
            this.cases = CustomContentControl.getCurrentCase();
            this.Name = "Ev_Shape";
            this.Content = Utils.addImage(urlImg, xDim, yDim);
            this.Constraints = NodeConstraints.Default & ~(NodeConstraints.Rotatable | NodeConstraints.InheritRotatable) & ~(NodeConstraints.Resizable | NodeConstraints.InheritResizable) & ~NodeConstraints.Connectable;
            this.PortVisibility = PortVisibility.Collapse;
            this.setStyles(50 ,50);
        }

        public EVShape(bool isCloneOne)
        {
            this.isClonedOne = isCloneOne;
            this.cases = CustomContentControl.getCurrentCase();
            this.Name = "Ev_Shape";
            this.Content = Utils.addImage(urlImg, xDim, yDim);
            this.Constraints = NodeConstraints.Default & ~(NodeConstraints.Rotatable | NodeConstraints.InheritRotatable) & ~(NodeConstraints.Resizable | NodeConstraints.InheritResizable) & ~NodeConstraints.Connectable;
            this.PortVisibility = PortVisibility.Collapse;
            this.setStyles(50, 50);
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

                if (this.Ports is PortCollection ports && ports.Count == 1)
                {
                    port1 = ports[0] as CustomPort;
                }
            }

            this.createChildElements();

            if (!isLoadAction)
            {
                this.Annotations = new ObservableCollection<IAnnotation>() { label, label2 };
                this.Ports = new PortCollection() { port1 };
            }
        }


        AnnotationEditorViewModel label = new AnnotationEditorViewModel();
        AnnotationEditorViewModel label2 = new AnnotationEditorViewModel();
        CustomPort port1 = new CustomPort();

        public void ResetChildElements()
        {
            // Reset local variable of annotation on load
            if (this.Annotations is ObservableCollection<IAnnotation> annotations && annotations.Count == 2)
            {
                label = annotations[0] as AnnotationEditorViewModel;
                label2 = annotations[1] as AnnotationEditorViewModel;
            }

            if (this.Ports is PortCollection ports && ports.Count == 1)
            {
                port1.Shape = new RectangleGeometry() { Rect = new Rect(0, 0, 10, 10) };
                port1.ShapeStyle.Setters.Add(new Setter(System.Windows.Shapes.Path.FillProperty, Brushes.Pink));
                port1.ShapeStyle.Setters.Add(new Setter(System.Windows.Shapes.Path.StrokeProperty, Brushes.Pink));
                port1.PortVisibility = PortVisibility.MouseOver;
                port1.HitPadding = 10;
            }
        }
        private void createChildElements()
        {
            EVBL evBL = new EVBL();
            ev = evBL.addEV(cases);
            label.Content = "MV " + ev.Name;
            label.Offset = new System.Windows.Point(-0.5, 0);
            //Margin = new System.Windows.Thickness(23, 10, 0, 0),
            label2.Content = "Mvar "+ ev.Code;
            label2.Offset = new System.Windows.Point(-0.5, 0.4);

            port1.Owner = this.Name;
            port1.UnitHeight = 7;
            port1.UnitWidth = 7;
            port1.NodeOffsetX = 0.5;
            port1.NodeOffsetY = 0.5;
            port1.Displacement = new Thickness(0.5, 1, 1, 1);
            port1.Shape = new RectangleGeometry() { Rect = new Rect(0, 0, 10, 10) };
            port1.ShapeStyle.Setters.Add(new Setter(System.Windows.Shapes.Path.FillProperty, Brushes.Pink));
            port1.ShapeStyle.Setters.Add(new Setter(System.Windows.Shapes.Path.StrokeProperty, Brushes.Pink));
            port1.Constraints = PortConstraints.Connectable & ~PortConstraints.InheritConnectable;
            port1.PortVisibility = PortVisibility.MouseOver;
            port1.HitPadding = 10;
        }

        private void setStyles(double h, double w)
        {
            this.UnitHeight = h;
            this.UnitWidth = w;
        }

        public void setImage(string image) {
            if (image.Contains("off"))
            {
                this.Content = Utils.addImage("/Image/load_off1.png", 80, 40);
            }
            else {
                this.Content = Utils.addImage("/Image/load_on1.png", 80, 40);
            }
        }

        public EV getEV() {
            return this.ev;
        }

        public void setEV(EV ev)
        {
            this.ev = ev;
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
            EVShape clonedObject = new EVShape(true);
            clonedObject.cases = this.cases;
            clonedObject.ev = this.ev;
            return clonedObject;
        }
    }
}
