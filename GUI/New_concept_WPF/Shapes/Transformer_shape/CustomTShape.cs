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
using System.Windows.Controls;
using System.Windows.Media;

namespace Shapes.Transformer
{
    class CustomTShape : AbstractTShape, ICloneable, IDiagramShape
    {
        private MainTransformers transformerTypes;
        protected bool isClonedOne;
        private string urlImg = "/Image/tritr_generalNew.png";
        private int xDim = 70, yDim = 70;
        public CustomTShape()
        {
            this.Name = "TTransformerShape";
            this.Content = Utils.addImage(urlImg, xDim, yDim);
            this.Constraints = NodeConstraints.Default & ~(NodeConstraints.Rotatable | NodeConstraints.InheritRotatable) & ~(NodeConstraints.Resizable | NodeConstraints.InheritResizable) & ~NodeConstraints.Connectable;
            this.PortVisibility = PortVisibility.Collapse;
            this.setStyles(70, 72);
            transformerRegistration();
            
        }

        public CustomTShape(bool isCloneOne)
        {
            this.isClonedOne = isCloneOne;
            this.cases = CustomContentControl.getCurrentCase();
            this.Name = "TTransformerShape";
            this.Content = Utils.addImage(urlImg, xDim, yDim);
            this.Constraints = NodeConstraints.Default & ~(NodeConstraints.Rotatable | NodeConstraints.InheritRotatable) & ~(NodeConstraints.Resizable | NodeConstraints.InheritResizable) & ~NodeConstraints.Connectable;
            this.PortVisibility = PortVisibility.Collapse;
            this.setStyles(70, 72);
        }

        public void Init(bool isLoadAction)
        {
            this.CreateChildElements();
        }

        private void transformerRegistration()
        {
            ITransformer iTransformer = new TTransformerBL();
            transformerTypes = (MainTransformers)iTransformer.add(base.cases);
            transformerTypes.type = "Custom";
            label.Content = "Custom " + transformerTypes.number;
            label.Offset = new Point(-0.5, 0);
            label.ReadOnly = true;
        }

        private AnnotationEditorViewModel label = new AnnotationEditorViewModel();
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
            if (this.Annotations is ObservableCollection<IAnnotation> annotations && annotations.Count == 2)
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

        private void CreateChildElements()
        {
            //ITransformer iTransformer = new TTransformerBL();
            //transformerTypes = (TTransformer)iTransformer.add(base.cases);
            //transformerTypes.type = "Custom";
            //label.Content = "Custom " + transformerTypes.number;
            //label.Offset = new Point(-0.5, 0);
            //label.ReadOnly = true;

            //var resource = new System.Windows.ResourceDictionary() { Source = new Uri(@"________________", UriKind.RelativeOrAbsolute) };
            DataTemplate dataTemplate = new DataTemplate();
            FrameworkElementFactory element = new FrameworkElementFactory(typeof(Image));
            element.SetBinding(Image.SourceProperty, new System.Windows.Data.Binding("Content"));// Utils.addImage("/Image/tritr_generalNew.png", 20, 20));
            element.SetValue(Image.HeightProperty, 16d);
            element.SetValue(Image.WidthProperty, 16d);
            dataTemplate.VisualTree = element;
            dataTemplate.Seal();
            if (!isClonedOne)
            {
                imType1.Content = "/Image/blank.png";// Utils.addImage("/Image/tritr_generalNew.png", 20, 20);
                imType1.ViewTemplate = dataTemplate;
                imType1.Offset = new Point(0.30, 0.5);
                imType2.Content = "/Image/blank.png";// Utils.addImage("/Image/tritr_generalNew.png", 20, 20);
                imType2.ViewTemplate = dataTemplate;
                imType2.Offset = new Point(0.67, 0.275);
                imType3.Content = "/Image/blank.png";// Utils.addImage("/Image/tritr_generalNew.png", 20, 20);
                imType3.ViewTemplate = dataTemplate;
                imType3.Offset = new Point(0.67, 0.72);
                this.Annotations = new ObservableCollection<IAnnotation>() {
                    label,
                    imType1,
                    imType2,
                    imType3
                };
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
                port2.NodeOffsetY = 0.24;
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
                port3.NodeOffsetY = 0.70;
                port3.Displacement = new Thickness(0, 0.5, 1, 0);
                port3.Constraints = PortConstraints.Connectable & ~PortConstraints.InheritConnectable;
                port3.Shape = new RectangleGeometry() { Rect = new Rect(0, 0, 10, 10) };
                port3.ShapeStyle.Setters.Add(new Setter(System.Windows.Shapes.Path.FillProperty, Brushes.Orange));
                port3.ShapeStyle.Setters.Add(new Setter(System.Windows.Shapes.Path.StrokeProperty, Brushes.Orange));
                port3.PortVisibility = PortVisibility.MouseOver;
                port3.HitPadding = 10;
                this.Ports = new PortCollection()
                {
                     port1,
                     port2,
                     port3,
                };
            }
            else {
                imType1clone.Content = "/Image/blank.png";// Utils.addImage("/Image/tritr_generalNew.png", 20, 20);
                imType1clone.ViewTemplate = dataTemplate;
                imType1clone.Offset = new Point(0.30, 0.5);
                imType2clone.Content = "/Image/blank.png";// Utils.addImage("/Image/tritr_generalNew.png", 20, 20);
                imType2clone.ViewTemplate = dataTemplate;
                imType2clone.Offset = new Point(0.67, 0.275);
                imType3clone.Content = "/Image/blank.png";// Utils.addImage("/Image/tritr_generalNew.png", 20, 20);
                imType3clone.ViewTemplate = dataTemplate;
                imType3clone.Offset = new Point(0.67, 0.72);
                this.Annotations = new ObservableCollection<IAnnotation>() {
                    label,
                    imType1clone,
                    imType2clone,
                    imType3clone
                };
            }

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
            this.label.Content = long.TryParse(name, out _) ? "Custom " + name : name;
        }

        public void setImType1(int type)
        {
            imType1.Content = imageListLocation[type];
        }

        public void setImType2(int type)
        {
            imType2.Content = imageListLocation[type];
        }

        public void setImType3(int type)
        {
            imType3.Content = imageListLocation[type];
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

        public void setImAll(int typeA, int typeB, int typeC, bool isZAZero = true, bool isZBZero = true, bool isZCZero = true)
        {
            if (typeA != 0 && typeB != 0 && typeC != 0)
            {
                //imTypeA.Image = imageListLocation[isZAZero ? typeA : ((typeA == 1 || typeA == 2) ? 6 : ((typeA == 3 || typeA == 4) ? 7 : 0))];
                //imTypeB.Image = imageListLocation[isZBZero ? typeB : ((typeB == 1 || typeB == 2) ? 6 : ((typeB == 3 || typeB == 4) ? 7 : 0))];
                //imTypeC.Image = imageListLocation[isZCZero ? typeC : ((typeC == 1 || typeC == 2) ? 6 : ((typeC == 3 || typeC == 4) ? 7 : 0))];
            }
            else
            {
                //imTypeA.Image = imageLocation["empty"];
                //imTypeB.Image = imageLocation["empty"];
                //imTypeC.Image = imageLocation["empty"];
            }
        }

        private static Dictionary<string, System.Drawing.Image> imageLocation = new Dictionary<string, System.Drawing.Image>()
        {
            //{ "Delta", Properties.Resources.tr_tDeltapng },
            //{ "Y", Properties.Resources.tr_tY },
            //{ "Yg", Properties.Resources.tr_tYg },
            //{ "Yzg", Properties.Resources.tr_tYzg },
            //{ "Z", Properties.Resources.tr_tZ },
            //{ "Zg", Properties.Resources.tr_tZg },
            //{ "Zzg", Properties.Resources.tr_tZzg},
            //{ "empty", Properties.Resources.empty}
        };

        private static List<string> imageListLocation = new List<string>()
        {
            "/Image/tr_tY.png",
            "/Image/tr_tYg.png",
            "/Image/tr_tZg.png",
            "/Image/tr_tZ.png",
            "/Image/tr_delta.png",
            "/Image/tr_deltaOp.png"
        };

        private void setStyles(double h, double w)
        {
            this.UnitHeight = h;
            this.UnitWidth = w;
        }

        public override object Clone()
        {
            CustomTShape clonedObject = new CustomTShape(true);
            clonedObject.cases = this.cases;
            clonedObject.transformerTypes = this.transformerTypes;
            return clonedObject;
        }
    }
}
