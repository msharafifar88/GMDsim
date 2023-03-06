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
using System.Windows;
using System.Windows.Media;
using GUI.New_concept_WPF.Custom_Controls.CustomPort;
using System.Xml.Serialization;
using System.Xml.Schema;
using System.Xml;
using System.Runtime.Serialization;
using network.generator.Gentype;

namespace Shapes.generator
{
    public class PVGenShape : NodeViewModel, ICloneable, IDiagramShape
    {
        [DataMember]
        private Case cases;
        [DataMember]
        private PVGen PVgenitem;
        private bool isClonedOne;
        private int xDim = 40, yDim = 60;

        [DataMember]
        public PVGen PVGeneratorItem
        {
            get { return PVgenitem; }
            set { if (value != PVgenitem) { PVgenitem = value; } }
        }

        public PVGenShape()
        {
            this.cases = CustomContentControl.getCurrentCase();
            this.Name = "PVGen";

            //this.Content = Utils.addImage("/Image/gen_on_new.png", xDim, yDim);
            this.Constraints = NodeConstraints.Default & ~(NodeConstraints.Rotatable | NodeConstraints.InheritRotatable) & ~(NodeConstraints.Resizable | NodeConstraints.InheritResizable) & ~NodeConstraints.Connectable;
            this.PortVisibility = PortVisibility.Collapse;
            this.setStyles(40, 60);
        }

        public PVGenShape(bool isCloneOne)
        {
            this.isClonedOne = isCloneOne;
            this.cases = CustomContentControl.getCurrentCase();
            this.Name = "PVGen";
            //this.Content = Utils.addImage("/Image/gen_on_new.png", xDim, yDim);
            this.Constraints = NodeConstraints.Default & ~(NodeConstraints.Rotatable | NodeConstraints.InheritRotatable) & ~(NodeConstraints.Resizable | NodeConstraints.InheritResizable) & ~NodeConstraints.Connectable;
            this.PortVisibility = PortVisibility.Collapse;
            this.setStyles(50, 50);
        }

        public void Init(bool isLoadAction)
        {
            if (isLoadAction)
            {
                // Annoation and Ports are reset to local variable after model is loaded from saved file
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
                port1 = ports[0] as CustomPort;

                port1.Shape = new RectangleGeometry() { Rect = new Rect(0, 0, 10, 10) };
                port1.ShapeStyle.Setters.Add(new Setter(System.Windows.Shapes.Path.FillProperty, Brushes.Orange));
                port1.ShapeStyle.Setters.Add(new Setter(System.Windows.Shapes.Path.StrokeProperty, Brushes.Orange));
                port1.PortVisibility = PortVisibility.MouseOver;
                port1.HitPadding = 10;
            }
        }

        private void createChildElements()
        {
            PVGenBL pvGenBL = new PVGenBL();
            if (PVgenitem != null)
            {
                pvGenBL.create(PVgenitem, cases);
            }
            else
            {
                PVgenitem = pvGenBL.addPVGen(cases);
            }

            updateStatus(PVgenitem.Inservice);

            //generatoritem.Name = this.Name;
            label.Content = PVgenitem.powerControl.setpoint.ToString() + " MW";
            label.Offset = new System.Windows.Point(-0.5, 0);
            label.ReadOnly = true;
            //Margin = new System.Windows.Thickness(23, 10, 0, 0),
            label2.Content = (PVgenitem.voltageControl.MvarOutput.ToString() + " MVar");
            label2.Offset = new System.Windows.Point(-0.5, 0.2);
            label2.ReadOnly = true;


            port1.Owner = this.Name;
            port1.UnitHeight = 9;
            port1.UnitWidth = 9;
            port1.NodeOffsetX = 0.77;
            port1.NodeOffsetY = 0.95;
            port1.Displacement = new Thickness(0.5, 1, 1, 1);
            port1.Shape = new RectangleGeometry() { Rect = new Rect(0, 0, 10, 10) };
            port1.ShapeStyle.Setters.Add(new Setter(System.Windows.Shapes.Path.FillProperty, Brushes.Orange));
            port1.ShapeStyle.Setters.Add(new Setter(System.Windows.Shapes.Path.StrokeProperty, Brushes.Orange));
            port1.Constraints = PortConstraints.Connectable & ~PortConstraints.InheritConnectable; ;
            port1.PortVisibility = PortVisibility.MouseOver;
            port1.HitPadding = 10;
        }

        public void updateStatus(Boolean status)
        {
            if (status)
            {
                this.Content = Utils.addImage(uri: "/Image/solarpanel.png", xDim, yDim);
            }
            else
            {
                this.Content = Utils.addImage("/Image/solarpanel_off.png", xDim, yDim);
            }
        }



        private void setStyles(double h, double w)
        {
            this.UnitHeight = h;
            this.UnitWidth = w;
        }

        /*public Generator getGenerator()
        {
            return generatoritem;
        }*/

        private void setGenerator(PVGen pvGen)
        {
            this.PVgenitem = pvGen;
        }

        public void setCase(Case cases)
        {
            this.cases = cases;
        }

        public Case getCase()
        {
            return this.cases;
        }

        public void updateLabel(double mW)
        {
            label.Content = mW.ToString() + " MW";
        }

        public void updateLabel2(double mVar)
        {
            label2.Content = mVar.ToString() + " MVar";
        }




        public object Clone()
        {
            //throw new NotImplementedException();
            PVGenShape clonedObject = new PVGenShape(true);
            clonedObject.cases = this.cases;
            clonedObject.PVgenitem = this.PVgenitem;
            return clonedObject;
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
