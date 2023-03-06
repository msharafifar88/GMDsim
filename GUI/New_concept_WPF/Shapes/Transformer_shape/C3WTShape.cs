using Syncfusion.UI.Xaml.Diagram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using persistent;
using network;
using GUI.New_concept_WPF;
using BL;
using System.Collections.ObjectModel;
using Syncfusion.UI.Xaml.Diagram.Controls;
using GUI.New_concept_WPF.Utility;
using GUI.New_concept_WPF.Custom_Controls.CustomPort;
using System.Windows.Media;
using System.Windows;

namespace Shapes.Transformer
{
    public class C3WTShape : NodeViewModel
    {
        private Case cases;
        private MainTransformers TriShape;
        protected bool isClonedOne;
        private string urlImg = "/Image/TirTrans.png";
        private int xDim = 68, yDim = 100;
       
        public C3WTShape()
        {
            this.cases = CustomContentControl.getCurrentCase();
            this.Name = "Custom3wT";
            this.Content = Utils.addImage(urlImg, xDim, yDim);
            this.setStyles(70, 70);
            this.createChildElements();
        }

        public C3WTShape(bool isCloneOne)
        {
            this.isClonedOne = isCloneOne;
            this.cases = CustomContentControl.getCurrentCase();
            this.Name = "Custom3wT";
            this.Content = Utils.addImage(urlImg, xDim, yDim);
            this.Constraints = NodeConstraints.Default & ~(NodeConstraints.Rotatable | NodeConstraints.InheritRotatable) & ~(NodeConstraints.Resizable | NodeConstraints.InheritResizable) & ~NodeConstraints.Connectable;
            this.PortVisibility = PortVisibility.Collapse;
            this.setStyles(70, 70);
        }

        
        private AnnotationEditorViewModel imType1 = new AnnotationEditorViewModel();
        private AnnotationEditorViewModel imType2 = new AnnotationEditorViewModel();
        private AnnotationEditorViewModel imType3 = new AnnotationEditorViewModel();
        private AnnotationEditorViewModel imType1clone = new AnnotationEditorViewModel();
        private AnnotationEditorViewModel imType2clone = new AnnotationEditorViewModel();
        private AnnotationEditorViewModel imType3clone = new AnnotationEditorViewModel();
        private CustomPort port1 = new CustomPort();
        private CustomPort port2 = new CustomPort();
        private CustomPort port3 = new CustomPort();

        public void ResetChildElements()
        {
            // Reset local variable of annotation on load
            if (this.Annotations is ObservableCollection<IAnnotation> annotations && annotations.Count == 3)
            {
                imType1 = annotations[0] as AnnotationEditorViewModel;
                imType2 = annotations[1] as AnnotationEditorViewModel;
                imType3 = annotations[2] as AnnotationEditorViewModel;
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

        AnnotationEditorViewModel label = new AnnotationEditorViewModel();
        AnnotationEditorViewModel label2 = new AnnotationEditorViewModel();
        private void createChildElements()
        {
            C3WTransformerBL TriTra = new C3WTransformerBL();
            TriShape = TriTra.add(cases);
            /* label.Content = TriShape.powerControl.setpoint.ToString() + " tttt";
             label.Offset = new System.Windows.Point(-0.5, 0);
             //Margin = new System.Windows.Thickness(23, 10, 0, 0),
             label2.Content = (TriShape.voltageControl.MvarOutput.ToString() + " asdasdasdasd");
             label2.Offset = new System.Windows.Point(-0.5, 0.2);
            this.Annotations = new ObservableCollection<IAnnotation>() {
                label,
                label2,
            };*/
        }
        private void setStyles(double h, double w)
        {
            this.UnitHeight = h;
            this.UnitWidth = w;
        }
        public MainTransformers getTransformerType()
        {
            return TriShape;
        }

        private void setLine(MainTransformers line)
        {
            this.TriShape = line;
        }

        public void setCase(Case cases)
        {
            this.cases = cases;
        }

        public Case getCase()
        {
            return this.cases;
        }

        public void setImAll(int type1, int type2, int type3)
        {
            imType1.Content = imageListLocation[type1];
            imType2.Content = imageListLocation[type2];
            imType3.Content = imageListLocation[type3];
            imType1clone.Content = imageListLocation[type1];
            imType2clone.Content = imageListLocation[type2];
            imType3clone.Content = imageListLocation[type3];
        }
        private static List<string> imageListLocation = new List<string>()
        {
            "/Image/tr_tY.png",
            "/Image/tr_tYg.png",
            "/Image/tr_tZg.png",
            "/Image/tr_tZ.png",
            "/Image/tr_delta.png",
            "/Image/tr_deltaOp.png"
        };
    }
}
