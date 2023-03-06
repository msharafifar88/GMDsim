using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.WinControls.UI;
using System.Drawing;
using Telerik.WinControls.Primitives;
using Telerik.WinControls;
using Telerik.Windows.Diagrams.Core;

namespace GUI.schunt
{
    class SchuntShape : RadDiagramShape
    {

        private static int counter = 0;
        public double mVar { get; set; }
        private Telerik.WinControls.UI.Diagrams.RadDiagramConnector input { get; set; }
        private Telerik.WinControls.UI.Diagrams.RadDiagramConnector output { get; set; }

        public SchuntShape()
        {
            setSchuntCounter(getSchuntCounter() + 1);
            this.Name = "SchuntShape";
            this.UseDefaultConnectors = false;
            this.DiagramShapeElement.Image = Properties.Resources.schunt_off1;
            this.mVar = 0;
            this.DiagramShapeElement.ImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Connectors.Clear();
            this.customConnectors();
        }

        //customConnectors() add connector points to the shape after removing the default ones.
        private void customConnectors()
        {
            this.Connectors.Clear();
            output = new Telerik.WinControls.UI.Diagrams.RadDiagramConnector()
            {
                Offset = new Telerik.Windows.Diagrams.Core.Point(0.5, 0),
                Name = this.Name + "Out"
            };
            input = new Telerik.WinControls.UI.Diagrams.RadDiagramConnector()
            {
                Offset = new Telerik.Windows.Diagrams.Core.Point(0.5, 1),
                Name = this.Name + "In"
            };
            output.Height = 10;
            input.Height = 10;
            output.Width = 3;
            input.Width = 3;
            output.BackColor = Color.FromArgb(255, 94, 0);
            input.BackColor = Color.FromArgb(255, 94, 0);
            output.PositionOffset = new SizeF(0, -6);
            input.PositionOffset = new SizeF(0, 2);
            this.Connectors.Add(output);
            this.Connectors.Add(input);
        }

        public SchuntShape(Dictionary<string, object> data)
        {
            //TOOD: call appropriate setters
            setSchuntCounter(getSchuntCounter() + 1);
            this.DiagramShapeElement.Image = Properties.Resources.schunt_off1;
            this.mVar = 0;
            this.DiagramShapeElement.ImageLayout = System.Windows.Forms.ImageLayout.Zoom;
        }
        //TextPrimitive label = new TextPrimitive();
        LightVisualElement label = new LightVisualElement();
        protected override void CreateChildElements()
        {
            base.CreateChildElements();
            label.Text = this.mVar + " MW";
            label.Font = new Font("Segoe UI", 7.5F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            label.DrawFill = false;
            label.PositionOffset = new SizeF(50, -50);
            this.DiagramShapeElement.Children.Add(label);
        }

        public void turnOnSchunt(bool on)
        {
            if (on)
            {
                this.DiagramShapeElement.Image = Properties.Resources.schunt_on1;
            }
        }


        public static int getSchuntCounter()
        {
            return SchuntShape.counter;
        }

        private static void setSchuntCounter(int newVal)
        {
            SchuntShape.counter = newVal;
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
