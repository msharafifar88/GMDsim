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
using Telerik.WinControls;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Diagrams;
using Telerik.Windows.Diagrams.Core;

namespace GUI.Load
{
    class LoadShape : RadDiagramShape
    {
        /* private static int counter = 0;
         public double mVar { get; set; }
         public double mWatts { get; set; }*/
        private Case cases;
        private Loads load;
        public LoadShape()
        {
            /* setLoadCounter(getLoadCounter() + 1);*/
            this.cases = CustomContentControl.getCurrentCase();
            this.Name = "LoadShape";
            this.UseDefaultConnectors = false;
            this.DiagramShapeElement.Image = Properties.Resources.load_off1;
        /*    this.mVar = 0;
            this.mWatts = 0;*/
            this.DiagramShapeElement.ImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.customConnectors();
        }

        //customConnectors() add connector points to the shape after removing the default ones.
        private void customConnectors()
        {
            this.Connectors.Clear();
            RadDiagramConnector conn_1 = new RadDiagramConnector()
            {
                Offset = new Telerik.Windows.Diagrams.Core.Point(0.5, 1),
                Name = this.Name + "Conn_1"
            };
            /*input = new Telerik.WinControls.UI.Diagrams.RadDiagramConnector()
            {
                Offset = new Telerik.Windows.Diagrams.Core.Point(0.5, 1),
                Name = this.Name + "In"
            };*/
            conn_1.Height = 10;
            conn_1.Width = 3;
            conn_1.BackColor = System.Drawing.Color.FromArgb(255, 94, 0);
            conn_1.PositionOffset = new SizeF(-1, 5);
            this.Connectors.Add(conn_1);
        }

        /*    public LoadShape(Dictionary<string, object> data)
        {
            //TOOD: call appropriate setters
         //   setLoadCounter(getLoadCounter() + 1);
            this.DiagramShapeElement.Image = Properties.Resources.load_off1;
         *//*   this.mVar = 0;
            this.mWatts = 0;*//*
            this.DiagramShapeElement.ImageLayout = System.Windows.Forms.ImageLayout.Zoom;
        }*/

        //CreateChildElements() instanciates a LightVisualElement class, allowing to define 2 labels 
        //for the recently created LoadShape object, and then append it to the LoadShape.
        LightVisualElement label = new LightVisualElement();
        LightVisualElement label2 = new LightVisualElement();
        private new void CreateChildElements()
        {
            // base.CreateChildElements();
            LoadBL loadBL = new LoadBL();
            load = loadBL.addLoad(cases);
            label.Text = load.Code + " MW";
            label2.Text = load.Code + " Mvar";
            label.Font = new Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            label2.Font = new Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            label2.DrawFill = false;
            label.DrawFill = false;
            label.PositionOffset = new SizeF(50, -60);
            label2.PositionOffset = new SizeF(50, -50);
            this.DiagramShapeElement.Children.Add(label);
            this.DiagramShapeElement.Children.Add(label2);
        }

        //turnOnGenerators() allows to modify the figure of the instance of LoadShape on the go.
        public void turnOnLoad(bool on)
        {//TODO: add the rest of the logic and the .png
            if (on)
            {
                this.DiagramShapeElement.Image = Properties.Resources.load_on1;
            }
        }


        /* public static int getLoadCounter()
         {
             return LoadShape.counter;
         }

         private static void setLoadCounter(int newVal)
         {
             LoadShape.counter = newVal;
         }*/
        public Loads getLoad()
         {
             return load;
         }

         public void setLoad(Loads load)
         {
            this.load = load;
         }

        public Case getCase()
        {
            return this.cases;
        }
        public void setCase(Case cases)
        {
            this.cases = cases;
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

