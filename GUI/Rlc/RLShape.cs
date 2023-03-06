using GUI.customDocumentWindow;
using persistent;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Diagrams;
using network;
using BL;
using Telerik.WinControls;

namespace GUI.Rlc
{
    class RLShape : AbstractRLCShape
    {
        private RLCbranches branch;
        public RLShape()
        {
            this.Name = "RLShape";
            this.DiagramShapeElement.Image = Properties.Resources.rl1;
            this.DiagramShapeElement.ImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.DiagramShapeElement.ZIndex = 0;
            this.UseDefaultConnectors = false;
            this.customConnectors();
            CreateChildElements();
        }

        //CreateChildElements() instanciates a LightVisualElement class, allowing to define 2 labels 
        //for the recently created LoadShape object, and then append it to the LoadShape.
        LightVisualElement label = new LightVisualElement();
        private new void CreateChildElements()
        {
            IRlcBL rl = new RlBL();
            branch = (RL)rl.add(base.cases);
            branch.branch = "RL";
            label.Text = "RL " + branch.number;
            label.Font = new Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            label.DrawFill = false;
            label.PositionOffset = new SizeF(50, -60);
            this.DiagramShapeElement.Children.Add(label);
        }

        public override void setLabel(string name)
        {
            this.label.Text = long.TryParse(name, out _) ? "RL " + name : name; ;
        }

        public override RLCbranches getRlcBranch()
        {
            return branch;
        }

        public override void setRlcBranch(RLCbranches rlcbranch)
        {
            this.branch = rlcbranch;
        }

        private void customConnectors()
        {
            this.Connectors.Clear();
            RadDiagramConnector conn_1 = new RadDiagramConnector()
            {
                Offset = new Telerik.Windows.Diagrams.Core.Point(0, 0.55),
                Name = this.Name + "Conn_1",
                ZIndex = 3
            };
            RadDiagramConnector conn_2 = new RadDiagramConnector()
            {
                Offset = new Telerik.Windows.Diagrams.Core.Point(1, 0.55),
                Name = this.Name + "Conn_2",
                ZIndex = 3
            };
            conn_1.Height = 3;
            conn_2.Height = 3;
            conn_1.Width = 10;
            conn_2.Width = 10;
            conn_1.BackColor = System.Drawing.Color.FromArgb(255, 94, 0);
            conn_2.BackColor = System.Drawing.Color.FromArgb(255, 94, 0);
            conn_1.PositionOffset = new SizeF(-6, 0);
            conn_2.PositionOffset = new SizeF(2, 0);
            this.Connectors.Add(conn_1);
            this.Connectors.Add(conn_2);
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
