using BL;
using GUI.New_concept_WPF;
using GUI.New_concept_WPF.Utility;
using network;
using persistent;
using persistent.network;
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
using System.Windows.Controls;
using GUI.New_concept_WPF.Custom_Controls.CustomPort;
using System.Runtime.Serialization;

namespace Shapes.Transformer
{
    class C2WTShape : AbstractTShape, ICloneable, IDiagramShape
    {
        private MainTransformers Custom2WShape;
        private string urlImg = "/Image/2w_transformer.png";
        private int xDim = 40, yDim = 78;
        DataTemplate datatemplate = new DataTemplate();
        FrameworkElementFactory element = new FrameworkElementFactory(typeof(Image));

        [DataMember]
        private MainTransformers Custom2WTransformer
        {
            get { return Custom2WShape; }
            set { if (Custom2WShape != value) { Custom2WShape = value; } }
        }

        public C2WTShape()
        {
            this.Name = "C2WShape";
            this.Content = Utils.addImage(urlImg, xDim, yDim);
            this.Constraints = NodeConstraints.Default & ~(NodeConstraints.Rotatable | NodeConstraints.InheritRotatable) & ~(NodeConstraints.Resizable | NodeConstraints.InheritResizable) & ~NodeConstraints.Connectable;
            this.PortVisibility = PortVisibility.Collapse;
            this.setStyles(70, 77);
            this.transformerRegistration();
        }

        public C2WTShape(bool isCloneOne)
        {
            this.isClonedOne = isCloneOne;
            this.cases = CustomContentControl.getCurrentCase();
            this.Name = "C2WShape";
            this.Content = Utils.addImage(urlImg, xDim, yDim);
            this.Constraints = NodeConstraints.Default & ~(NodeConstraints.Rotatable | NodeConstraints.InheritRotatable) & ~(NodeConstraints.Resizable | NodeConstraints.InheritResizable) & ~NodeConstraints.Connectable;
            this.PortVisibility = PortVisibility.Collapse;
            this.setStyles(70, 72);
        }

        public void Init(bool isLoadAction)
        {
            if (isLoadAction)
            {
                if (this.Ports is PortCollection ports && ports.Count == 2)
                {
                    port1 = ports[0] as CustomPort;
                    port2 = ports[1] as CustomPort;
                }
            }

            this.createChildElements();

            if (!isLoadAction)
            {
                this.Ports = new PortCollection() { port1, port2 };
            }

            element.SetBinding(Image.SourceProperty, new System.Windows.Data.Binding("Content"));
            element.SetValue(Image.HeightProperty, 16d);
            element.SetValue(Image.WidthProperty, 16d);
            datatemplate.VisualTree = element;
            if (isLoadAction)
            {
                foreach (var annotation in Annotations as AnnotationCollection)
                {
                    annotation.ViewTemplate = datatemplate as DataTemplate;
                }
            }
            else
            {
                Annotations = new AnnotationCollection()
                {
                    new AnnotationEditorViewModel()
                    {
                        ViewTemplate = datatemplate as DataTemplate,
                        Offset = new Point(0.32, 0.55),
                        Content = "/Image/blank.png",
                        ReadOnly = true

                    },
                    new AnnotationEditorViewModel()
                    {
                        ViewTemplate = datatemplate as DataTemplate,
                        Offset = new Point(0.69, 0.55),
                        Content = "/Image/blank.png",
                        ReadOnly = true
                    }
                };
            }
            
            datatemplate.Seal();
        }

        private void transformerRegistration() 
        {
            C2WTransformerBL iTransformer = new C2WTransformerBL();
            if (Custom2WShape != null)
            {
                iTransformer.create(Custom2WShape as C2WTransformer, cases);
            }
            else
            {
                Custom2WShape = (C2WTransformer)iTransformer.add(base.cases);
            }

            Custom2WShape.type = "2WTra";
            label.Content = "2WTra " + Custom2WShape.number;
            label.Offset = new Point(-0.5, 0);
            label.ReadOnly = true;
        }

        private AnnotationEditorViewModel label = new AnnotationEditorViewModel();
        private AnnotationEditorViewModel imType1 = new AnnotationEditorViewModel();
        private AnnotationEditorViewModel imType2 = new AnnotationEditorViewModel();
        private AnnotationEditorViewModel imType1clone = new AnnotationEditorViewModel();
        private AnnotationEditorViewModel imType2clone = new AnnotationEditorViewModel();
        private CustomPort port1 = new CustomPort();
        private CustomPort port2 = new CustomPort();

        public void ResetChildElements()
        {
            // Reset local variable of annotation on load
            if (this.Annotations is ObservableCollection<IAnnotation> annotations && annotations.Count == 2)
            {
                imType1 = annotations[0] as AnnotationEditorViewModel;
                imType1.ViewTemplate = datatemplate as DataTemplate;
                imType2 = annotations[1] as AnnotationEditorViewModel;
                imType2.ViewTemplate = datatemplate as DataTemplate;
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
            if (!isClonedOne)
            {
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
            else
            {
                //imType1clone.Content = "/Image/blank.png";
                //imType1clone.ViewTemplate = dataTemplate;
                //imType1clone.Offset = new Point(0.32, 0.55);
                //imType2clone.Content = "/Image/blank.png";
                //imType2clone.ViewTemplate = dataTemplate;
                //imType2clone.Offset = new Point(0.69, 0.55);
                //this.Annotations = new ObservableCollection<IAnnotation>() {
                //    label,
                //    imType1clone,
                //    imType2clone
                //};
            }

        }

        private void setStyles(double h, double w)
        {
            this.UnitHeight = h;
            this.UnitWidth = w;
        }

        public override MainTransformers getTransformerType()
        {
            return Custom2WShape;
        }

        public override void setTransformerType(MainTransformers transformer)
        {
            this.Custom2WShape = transformer;
        }

        public override void setLabel(string name)
        {
            this.label.Content = long.TryParse(name, out _) ? "2WTra " + name : name;
        }

        //public void setImType1(int type)
        //{
        //    imType1.Content = imageListLocation[type];
        //}

        //public void setImType2(int type)
        //{
        //    imType2.Content = imageListLocation[type];
        //}

        //public void setImAll(int type1, int type2)
        //{
        //    imType1.Content = imageListLocation[type1];
        //    imType2.Content = imageListLocation[type2];
        //    imType1clone.Content = imageListLocation[type1];
        //    imType2clone.Content = imageListLocation[type2];

        //    System.Diagnostics.Debug.WriteLine("here");
        //}

        private static List<string> imageListLocation = new List<string>()
        {
            "/Image/tr_tY.png",
            "/Image/tr_tYg.png",
            "/Image/tr_tZg.png",
            "/Image/tr_tZ.png",
            "/Image/tr_delta.png",
            "/Image/tr_deltaOp.png"
        };

        public List<string> getImageList() {
            return imageListLocation;
        }

        public override object Clone()
        {

            C2WTShape clonedObject = new C2WTShape(true);
            clonedObject.cases = this.cases;
            clonedObject.Custom2WShape = this.Custom2WShape;
            return clonedObject;
        }

    }
}
