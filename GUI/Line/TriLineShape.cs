using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Diagrams;
using Telerik.Windows.Diagrams.Core;

namespace GUI.Line
{
    class TriLineShape : RadDiagramShape
    {
        private static int counter = 0;
        public TriLineShape()
        {

            setLineCounter(getLineCounter() + 1);
            this.Name = "TriLineShape";
            this.UseDefaultConnectors = false;
            this.DiagramShapeElement.Image = Properties.Resources.triphasic_line;
            this.DiagramShapeElement.ImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.DiagramShapeElement.ZIndex = 0;
            this.customConnectors();
        }

        private void customConnectors()
        {
            this.Connectors.Clear();
            RadDiagramConnector output_1 = new RadDiagramConnector()
            {
                Offset = new Telerik.Windows.Diagrams.Core.Point(1, 0.31),
                Name = this.Name + "Out_1",
                ZIndex = 3
            };
            RadDiagramConnector output_2 = new RadDiagramConnector()
            {
                Offset = new Telerik.Windows.Diagrams.Core.Point(1, 0.50),
                Name = this.Name + "Out_2",
                ZIndex = 3
            };
            RadDiagramConnector output_3 = new RadDiagramConnector()
            {
                Offset = new Telerik.Windows.Diagrams.Core.Point(1, 0.68),
                Name = this.Name + "Out_3",
                ZIndex = 3
            };
            RadDiagramConnector input_1 = new RadDiagramConnector()
            {
                Offset = new Telerik.Windows.Diagrams.Core.Point(0, 0.31),
                Name = this.Name + "In_1",
                ZIndex = 3
            };
            RadDiagramConnector input_2 = new RadDiagramConnector()
            {
                Offset = new Telerik.Windows.Diagrams.Core.Point(0, 0.50),
                Name = this.Name + "In_2",
                ZIndex = 3
            };
            RadDiagramConnector input_3 = new RadDiagramConnector()
            {
                Offset = new Telerik.Windows.Diagrams.Core.Point(0, 0.68),
                Name = this.Name + "In_3",
                ZIndex = 3
            };
            output_1.Height = 3;
            output_2.Height = 3;
            output_3.Height = 3;
            input_1.Height = 3;
            input_2.Height = 3;
            input_3.Height = 3;
            output_1.Width = 10;
            output_2.Width = 10;
            output_3.Width = 10;
            input_1.Width = 10;
            input_2.Width = 10;
            input_3.Width = 10;
            output_1.BackColor = System.Drawing.Color.FromArgb(255, 94, 0);
            input_1.BackColor = System.Drawing.Color.FromArgb(255, 94, 0);
            output_2.BackColor = System.Drawing.Color.FromArgb(255, 94, 0);
            input_2.BackColor = System.Drawing.Color.FromArgb(255, 94, 0);
            output_3.BackColor = System.Drawing.Color.FromArgb(255, 94, 0);
            input_3.BackColor = System.Drawing.Color.FromArgb(255, 94, 0);
            output_1.PositionOffset = new SizeF(1, 0);
            input_1.PositionOffset = new SizeF(-6, 0);
            output_2.PositionOffset = new SizeF(1, 0);
            input_2.PositionOffset = new SizeF(-6, 0);
            output_3.PositionOffset = new SizeF(1, 0);
            input_3.PositionOffset = new SizeF(-6, 0);
            this.Connectors.Add(output_1);
            this.Connectors.Add(output_2);
            this.Connectors.Add(output_3);
            this.Connectors.Add(input_1);
            this.Connectors.Add(input_2);
            this.Connectors.Add(input_3);
        }

        //CreateChildElements() instanciates a LightVisualElement class, allowing to define 2 labels 
        //for the recently created LoadShape object, and then append it to the LoadShape.
        LightVisualElement label = new LightVisualElement();
        //LightVisualElement label2 = new LightVisualElement();
        protected override void CreateChildElements()
        {
            base.CreateChildElements();
            label.Text = "TLine " + getLineCounter();
            //label2.Text = this.mVar + " Mvar";
            label.Font = new Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            //label2.Font = new Font("Segoe UI", 7.5F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            //label2.DrawFill = false;
            label.DrawFill = false;
            label.PositionOffset = new SizeF(50, -60);
            //label2.PositionOffset = new SizeF(50, -50);
            this.DiagramShapeElement.Children.Add(label);
            //this.DiagramShapeElement.Children.Add(label2);
        }


        public static int getLineCounter()
        {
            return TriLineShape.counter;
        }

        private static void setLineCounter(int newVal)
        {
            TriLineShape.counter = newVal;
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
