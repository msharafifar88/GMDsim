using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Diagrams;

namespace GUI.Transformer
{
    class TransformerShape : RadDiagramShape
    {
        private static int counter = 0;
        public TransformerShape()
        {

            setLineCounter(getLineCounter() + 1);
            this.Name = "TransformerShape";
            this.DiagramShapeElement.Image = Properties.Resources.YgDD_transformer;
            this.DiagramShapeElement.ImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.customConnectors();
        }

        private void customConnectors()
        {
            this.Connectors.Clear();
            RadDiagramConnector output_2 = new RadDiagramConnector()
            {
                Offset = new Telerik.Windows.Diagrams.Core.Point(1, 0.666),
                Name = this.Name + "Out_2"
            };
            RadDiagramConnector input_2 = new RadDiagramConnector()
            {
                Offset = new Telerik.Windows.Diagrams.Core.Point(1, 0.333),
                Name = this.Name + "In_2"
            };
            RadDiagramConnector input_1 = new RadDiagramConnector()
            {
                Offset = new Telerik.Windows.Diagrams.Core.Point(0, 0.666),
                Name = this.Name + "In_1"
            };
            RadDiagramConnector output_1 = new RadDiagramConnector()
            {
                Offset = new Telerik.Windows.Diagrams.Core.Point(0, 0.333),
                Name = this.Name + "Out_1"
            };
            output_1.Height = 3;
            output_2.Height = 3;
            input_1.Height = 3;
            input_2.Height = 3;
            output_1.Width = 10;
            output_2.Width = 10;
            input_1.Width = 10;
            input_2.Width = 10;
            output_1.BackColor = System.Drawing.Color.FromArgb(255, 94, 0);
            input_1.BackColor = System.Drawing.Color.FromArgb(255, 94, 0);
            output_2.BackColor = System.Drawing.Color.FromArgb(255, 94, 0);
            input_2.BackColor = System.Drawing.Color.FromArgb(255, 94, 0);
            output_1.PositionOffset = new SizeF(1, 0);
            input_1.PositionOffset = new SizeF(-5, 0);
            output_2.PositionOffset = new SizeF(1, 0);
            input_2.PositionOffset = new SizeF(-5, 0);
            this.Connectors.Add(output_1);
            this.Connectors.Add(output_2);
            this.Connectors.Add(input_1);
            this.Connectors.Add(input_2);
        }

        //CreateChildElements() instanciates a LightVisualElement class, allowing to define 2 labels 
        //for the recently created LoadShape object, and then append it to the LoadShape.
        LightVisualElement label = new LightVisualElement();
        //LightVisualElement label2 = new LightVisualElement();
        protected override void CreateChildElements()
        {
            base.CreateChildElements();
            label.Text = "Tra " + getLineCounter();
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
            return TransformerShape.counter;
        }

        private static void setLineCounter(int newVal)
        {
            TransformerShape.counter = newVal;
        }
    }
}
