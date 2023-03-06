using BL;
using GUI.customDocumentWindow;
using GUI.New_concept_WPF;
using network;
using persistent;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using Telerik.Windows.Diagrams.Core;

namespace GUI.generator
{
    class GenShape : RadDiagramShape
    {
        private Case cases;
        private Generator generator;
        private Telerik.WinControls.UI.Diagrams.RadDiagramConnector output { get; set; }
        public GenShape()
        {
            //  setCustCounter(getCustCounter() + 1);
            this.cases = CustomContentControl.getCurrentCase();
            this.Name = "GenShape";
            this.IsHitTestVisible = true;
            this.UseDefaultConnectors = false;
            this.DiagramShapeElement.Image = Properties.Resources.gen_off1;
            // this.mVar = 0;
            // this.mWatts = 0;
            CreateChildElements();
            this.DiagramShapeElement.ImageLayout = ImageLayout.Zoom;
            this.customConnectors();
        }

        //customConnectors() add connector points to the shape after removing the default ones.
        private void customConnectors() {
            this.Connectors.Clear();
            output = new Telerik.WinControls.UI.Diagrams.RadDiagramConnector()
            {
                Offset = new Telerik.Windows.Diagrams.Core.Point(0.5, 0),
                Name = this.Name + "Out",
                ZIndex = 5,
                Height = 10,
                Width = 3
            };
            output.BackColor = Color.FromArgb(255, 94, 0);
            output.PositionOffset = new SizeF(0, -6);
            this.Connectors.Add(output);
        }

      /*  public GenShape(Dictionary<string, object> data)
        {
            //TOOD: call appropriate setters
           // setCustCounter(getCustCounter() + 1);
            this.DiagramShapeElement.Image = Properties.Resources.gen_off1;
           // this.mVar = 0;
          //  this.mWatts = 0;
            this.DiagramShapeElement.ImageLayout = System.Windows.Forms.ImageLayout.Zoom;
        }*/

        //CreateChildElements() instanciates a LightVisualElement class, allowing to define 2 labels 
        //for the recently created GenShape object, and then append it to the GenShape.
        LightVisualElement label = new LightVisualElement();
        LightVisualElement label2 = new LightVisualElement();
        private new void CreateChildElements()
        {
           // base.CreateChildElements();
            GeneratorBL generatorBL = new GeneratorBL();
            generator=generatorBL.addGenerator(cases);
            label.Text = generator.powerControl.setpoint.ToString() + "MW";
            label2.Text = generator.voltageControl.MvarOutput.ToString() + "MVar";
            label.Font = new Font("Segoe UI", 7.5F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            label2.Font = new Font("Segoe UI", 7.5F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            label2.DrawFill = false;
            label.DrawFill = false;
            label.PositionOffset = new SizeF(50, 50);
            label2.PositionOffset = new SizeF(50, 60);
            this.DiagramShapeElement.Children.Add(label);
            this.DiagramShapeElement.Children.Add(label2);
        }

        //turnOnGenerators() allows to modify the figure of the instance of GenShape on the go.
        public void turnOnGenerators(bool on, string type = "Dog Bone")
        {//TODO: add the rest of the logic and the .png
            if (on)
            {
                if (type.Equals("Dog Bone"))
                {
                    this.DiagramShapeElement.Image = Properties.Resources.gen_on1;
                }
            }
        }

     
        public Generator getGenerator()
        {
            return generator;
        }

        private  void setGenerator(Generator generator)
        {
            this.generator = generator;
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
            label.Text = mW.ToString() + " MW";
        }

        public void updateLabel2(double mVar)
        {
            label2.Text = mVar.ToString() + " MVar";
        }

        protected override void OnIsSelectedChanged(bool oldValue, bool newValue)
        {
            base.OnIsSelectedChanged(oldValue, newValue);

            foreach (RadElement connector in this.Connectors)
            {
                connector.Visibility = ElementVisibility.Visible;
            }
        }

        protected override void UpdateVisualStates()
        {
            foreach (RadElement connector in this.Connectors)
            {
                connector.Visibility = ElementVisibility.Visible;
            }
        }


        protected override SizeF ArrangeOverride(SizeF finalSize)
        {
            SizeF sz = base.ArrangeOverride(finalSize);
            foreach (IConnector connector in this.Connectors)
            {
                RadElement connectorElement = (RadElement)connector;
                SizeF size = connectorElement.DesiredSize;
                double x = connector.Offset.X * finalSize.Width - size.Width / 2;
                x = Math.Max(0, x);
                double y = connector.Offset.Y * finalSize.Height - size.Height / 2;
                y = Math.Max(0, y);
                connectorElement.Arrange(new RectangleF((float)x, (float)y, size.Width, size.Height));
            }

            return sz;
        }


    }
}

