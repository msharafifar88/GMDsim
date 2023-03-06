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
using GUI.New_concept;
using Telerik.Windows.Diagrams.Core;
using Telerik.WinControls;
using network;
using BL;

namespace GUI.Transformer
{
    class TTransformerShape : AbstractTRShape
    {
        private MainTransformers transformerTypes;
        public TTransformerShape()
        {
            this.Name = "TTransformerShape";
            this.UseDefaultConnectors = false;
            this.DiagramShapeElement.Image = Properties.Resources.tritr_generalNew;
            this.DiagramShapeElement.ImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.DiagramShapeElement.ZIndex = 0;
            this.customConnectors();
            this.CreateChildElements();
        }

        private void customConnectors()
        {
            this.Connectors.Clear();
            RadDiagramConnector conn_1 = new RadDiagramConnector()
            {
                Offset = new Telerik.Windows.Diagrams.Core.Point(0, 0.49),
                Name = this.Name + "Conn_1"
            };
            RadDiagramConnector conn_2 = new RadDiagramConnector()
            {
                Offset = new Telerik.Windows.Diagrams.Core.Point(1, 0.31),
                Name = this.Name + "Conn_2"
            };
            RadDiagramConnector conn_3 = new RadDiagramConnector()
            {
                Offset = new Telerik.Windows.Diagrams.Core.Point(1, 0.69),
                Name = this.Name + "Conn_3"
            };
            conn_1.Height = 3;
            conn_2.Height = 3;
            conn_3.Height = 3;
            conn_1.Width = 10;
            conn_2.Width = 10;
            conn_3.Width = 10;
            conn_1.BackColor = System.Drawing.Color.FromArgb(255, 94, 0);
            conn_2.BackColor = System.Drawing.Color.FromArgb(255, 94, 0);
            conn_3.BackColor = System.Drawing.Color.FromArgb(255, 94, 0);
            conn_1.PositionOffset = new SizeF(-6, 0);
            conn_2.PositionOffset = new SizeF(2, 0);
            conn_3.PositionOffset = new SizeF(2, 0);
            this.Connectors.Add(conn_1);
            this.Connectors.Add(conn_2);
            this.Connectors.Add(conn_3);
        }

        //CreateChildElements() instanciates a LightVisualElement class, allowing to define 2 labels 
        //for the recently created LoadShape object, and then append it to the LoadShape.
        LightVisualElement label = new LightVisualElement();
        //CreateChildElements() instanciates a LightVisualElement class, allowing to define 2 labels 
        //for the recently created LoadShape object, and then append it to the LoadShape.
        LightVisualElement imTypeA = new LightVisualElement();
        LightVisualElement imTypeB = new LightVisualElement();
        LightVisualElement imTypeC = new LightVisualElement();
        protected new void CreateChildElements()
        {
            //base.CreateChildElements();
            ITransformer iTransformer = new TTransformerBL();
            transformerTypes = (TTransformer)iTransformer.add(base.cases);
            transformerTypes.type = "Custom";
            label.Text = "Custom " + transformerTypes.number;
            imTypeA.Image = imageLocation["empty"];
            //imTypeA.Image = UtilitiesShape.Resize(imageLocation["Y"], new System.Drawing.Size(15,15));
            imTypeB.Image = imageLocation["empty"];
            //imTypeB.Image = imageLocation["Y"];
            imTypeC.Image = imageLocation["empty"];
            //imTypeC.Image = new Bitmap(imageLocation["Y"], new System.Drawing.Size(15, 15));
            //label2.Text = this.mVar + " Mvar";
            label.Font = new Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            //label2.Font = new Font("Segoe UI", 7.5F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            //label2.DrawFill = false;
            label.DrawFill = false;
            imTypeA.DrawFill = false;
            imTypeB.DrawFill = false;
            imTypeC.DrawFill = false;
            //imTypeA.Location = new Telerik.Windows.Diagrams.Core.Point(1, 1);
            imTypeA.PositionOffset = new SizeF(-14, 0);
            imTypeA.ZIndex = -1;
            imTypeB.PositionOffset = new SizeF(12, -14);
            imTypeB.ZIndex = -1;
            imTypeC.PositionOffset = new SizeF(12, 14);
            imTypeC.ZIndex = -1;
            label.PositionOffset = new SizeF(40, -40);
            //label2.PositionOffset = new SizeF(50, -50);
            this.DiagramShapeElement.Children.Add(label);
            this.DiagramShapeElement.Children.Add(imTypeA);
            this.DiagramShapeElement.Children.Add(imTypeB);
            this.DiagramShapeElement.Children.Add(imTypeC);
            //this.DiagramShapeElement.Children.Add(label2);
        }


        private static Dictionary<string, System.Drawing.Image> imageLocation = new Dictionary<string, System.Drawing.Image>() 
        {
            { "Delta", Properties.Resources.tr_tDeltapng },
            { "Y", Properties.Resources.tr_tY },
            { "Yg", Properties.Resources.tr_tYg },
            { "Yzg", Properties.Resources.tr_tYzg },
            { "Z", Properties.Resources.tr_tZ },
            { "Zg", Properties.Resources.tr_tZg },
            { "Zzg", Properties.Resources.tr_tZzg},
            { "empty", Properties.Resources.empty}
        };

        private static List<System.Drawing.Image> imageListLocation = new List<System.Drawing.Image>()
        {

            Properties.Resources.empty, 
            Properties.Resources.tr_tY, Properties.Resources.tr_tYg,
            Properties.Resources.tr_tZ, Properties.Resources.tr_tZg,
            Properties.Resources.tr_tDeltapng, 
            Properties.Resources.tr_tYzg, 
            Properties.Resources.tr_tZzg
        };

        //Setters for the LightVisualElements
        public void setImTypeA(string type) 
        {
            imTypeA.Image = imageLocation[type];
        }

        public void setImTypeB(string type)
        {
            imTypeB.Image = imageLocation[type];
        }

        public void setImTypeC(string type)
        {
            imTypeC.Image = imageLocation[type];
        }

        public void setImAll(string typeA, string typeB, string typeC) 
        {
            imTypeA.Image = imageLocation[typeA];
            imTypeB.Image = imageLocation[typeB];
            imTypeC.Image = imageLocation[typeC];
        }

        public void setImAll(int typeA, int typeB, int typeC, bool isZAZero = true, bool isZBZero = true, bool isZCZero = true)
        {
            if (typeA != 0 && typeB != 0 && typeC != 0)
            {
                imTypeA.Image = imageListLocation[isZAZero ? typeA : ((typeA == 1 || typeA == 2) ? 6 : ((typeA == 3 || typeA == 4) ? 7 : 0))];
                imTypeB.Image = imageListLocation[isZBZero ? typeB : ((typeB == 1 || typeB == 2) ? 6 : ((typeB == 3 || typeB == 4) ? 7 : 0))];
                imTypeC.Image = imageListLocation[isZCZero ? typeC : ((typeC == 1 || typeC == 2) ? 6 : ((typeC == 3 || typeC == 4) ? 7 : 0))];
            }
            else {
                imTypeA.Image = imageLocation["empty"];
                imTypeB.Image = imageLocation["empty"];
                imTypeC.Image = imageLocation["empty"];
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
            this.label.Text = long.TryParse(name, out _) ? "Custom " + name : name;
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
