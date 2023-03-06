using BL;
using GUI.New_concept_WPF;
using network;
using persistent;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.WinControls;
using Telerik.WinControls.UI;
//using Telerik.WinControls.UI.Diagrams;

namespace GUI.bus
{
    class BusShape : RadDiagramShape
    {
        /* Variables*/
        private Bus bus;
        private Case cases;
        private Telerik.WinControls.UI.Diagrams.RadDiagramConnector input { get; set; }
        private Telerik.WinControls.UI.Diagrams.RadDiagramConnector output { get; set; }
        //Create others instance variables (use properties)
        /*Cunstractor Mrthod */
        public BusShape()
        {
            this.cases = CustomContentControl.getCurrentCase();
            this.Name = cases.name + "BusShape";
            this.UseDefaultConnectors = false;
            this.customConnectors();
            CreateChildElements();
            this.DiagramShapeElement.Image = Properties.Resources.bus_dia2;
            this.DiagramShapeElement.ImageLayout = System.Windows.Forms.ImageLayout.Zoom;   
        }

        //customConnectors() add connector points to the shape after removing the default ones.
        private void customConnectors()
        {
            this.Connectors.Clear();
            output = new Telerik.WinControls.UI.Diagrams.RadDiagramConnector()
            {
                Offset = new Telerik.Windows.Diagrams.Core.Point(1, 0.5),
                Name = this.Name + "Out",
                ZIndex = 3
            };
            input = new Telerik.WinControls.UI.Diagrams.RadDiagramConnector()
            {
                Offset = new Telerik.Windows.Diagrams.Core.Point(0, 0.5),
                Name = this.Name + "In",
                ZIndex = 3
            };
            output.Height = 3;
            input.Height = 3;
            output.Width = 10;
            input.Width = 10;
            output.BackColor = Color.FromArgb(255, 94, 0);
            input.BackColor = Color.FromArgb(255, 94, 0);
            output.PositionOffset = new SizeF(1, 0);
            input.PositionOffset = new SizeF(-5, 0);
            this.Connectors.Add(output);
            this.Connectors.Add(input);
        }

         //CreateChildElements() instanciates a LightVisualElement class, allowing to define a label 
        //for the recently created BusShape object, and then append it to the BusShape.
        LightVisualElement label = new LightVisualElement();
        private new void CreateChildElements()
        {
          //  base.CreateChildElements();
            BusBL busBL = new BusBL();
            bus = busBL.addBus(cases);
            this.Size = new Size(bus.display.Width, bus.display.Size);
            label.Text = "" + bus.BusName;
            label.AllowDrag = true;
            label.Font = new Font("Segoe UI", 8F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            label.DrawFill = false;
            label.PositionOffset = new SizeF(-50, -10);
            this.DiagramShapeElement.Children.Add(label);
        }

        public void setlabel(string name) {
            label.Text = name;
        }

        /* Setter And Getter Method*/
        public void setBus(Bus bus)
        {
            this.bus = bus;
        }

        public Bus getBus()
        {
            return this.bus;
        }
        public void setCase(Case cases)
        {
            this.cases = cases;
        }

        public Case getCase()
        {
            return this.cases;
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
                connector.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            }
        }


        protected override SizeF ArrangeOverride(SizeF finalSize)
        {
            SizeF sz = base.ArrangeOverride(finalSize);
            foreach (Telerik.Windows.Diagrams.Core.IConnector connector in this.Connectors)
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

