using BL;
using GUI.New_concept_WPF;
using network;
using network.generator.Gentype;
using persistent.network;
using Syncfusion.UI.Xaml.Diagram;
using System;
using System.Windows.Forms;

namespace GUI.contextMenu
{
    public partial class ChangeNameForm : Form
    {
        NodeViewModel node;

        public ChangeNameForm(ref NodeViewModel node)
        {
            InitializeComponent();
            this.Load += ChangeNameForm_Load;
            this.node = node;
            this.Text = "[ " + node.Name + " ] Name Menu";
            this.StartPosition = FormStartPosition.Manual;
            this.Location = Cursor.Position;
        }

        private void ChangeNameForm_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            string nodeName = null;
            if (this.node is Shapes.ExBus.BusShape)
            {
                Bus bus = ((Shapes.ExBus.BusShape)node).getBus();
                nodeName = bus.BusName;

            }
            else if (this.node is Shapes.generator.GenShape)
            {
                Generator gen = ((Shapes.generator.GenShape)node).GeneratorItem;
                ;
                nodeName = gen.Name;

            }
            else if (this.node is Shapes.generator.PVGenShape)
            {
                PVGen pvgen = ((Shapes.generator.PVGenShape)node).PVGeneratorItem;

                nodeName = pvgen.Name;


            }
            // Line Double Circuitline
            else if (this.node is Shapes.Line.DoubleCircuitShape)
            {
                DoubleCircuitLine line = ((Shapes.Line.DoubleCircuitShape)node).DoubleCircuitLineItem;
                nodeName = line.Name;
            }

            else if (this.node is Shapes.Load.LoadShape)
            {
                Loads loads = ((Shapes.Load.LoadShape)node).getLoad();
                nodeName = loads.Name;
            }
            else if (this.node is Shapes.RLC.RLCShape)
            {
                RLCbranches rlc = ((Shapes.RLC.RLCShape)node).getRLCBranch();
                nodeName = rlc.name;
            }
            else if (this.node is Shapes.Transformer.AbstractTShape)
            {
                MainTransformers transformer = ((Shapes.Transformer.AbstractTShape)node).getTransformerType();
                nodeName = transformer.name;

            }
            this.textNameBox.Text = nodeName;
        }

        private void Savebutton_Click(object sender, EventArgs e)
        {
            // Save BUS
            if (this.node is Shapes.ExBus.BusShape)
            {
                Bus bus = ((Shapes.ExBus.BusShape)node).getBus();
                bus.BusName = this.textNameBox.Text;
                BusBL busBL = new BusBL();
                busBL.editBus(bus, CustomContentControl.getCurrentCase());
                ((Shapes.ExBus.BusShape)node).updateLabel(this.textNameBox.Text);
            }
            //Save regolar Generator 
            else if (this.node is Shapes.generator.GenShape)
            {
                Generator gen = ((Shapes.generator.GenShape)node).GeneratorItem;
                gen.Name = this.textNameBox.Text;
                GeneratorBL genBL = new GeneratorBL();
                genBL.edit(gen, CustomContentControl.getCurrentCase());
                //((Shapes.generator.GenShape)node).updateLabel(this.textNameBox.Text);
            }
            //Save PV Generator
            else if (this.node is Shapes.generator.PVGenShape)
            {
                PVGen pvgen = ((Shapes.generator.PVGenShape)node).PVGeneratorItem;
                pvgen.Name = this.textNameBox.Text;
                PVGenBL pvgenBL = new PVGenBL();
                pvgenBL.edit(pvgen, CustomContentControl.getCurrentCase());
                //((Shapes.generator.GenShape)node).updateLabel(this.textNameBox.Text);
            }
            /*
            else if (this.node is Shapes.generator.GenShape)
            {
                Generator gen = ((Shapes.generator.GenShape)node).GeneratorItem;
                gen.Name = this.textNameBox.Text;
                GeneratorBL genBL = new GeneratorBL();
                genBL.edit(gen, CustomContentControl.getCurrentCase());
                //((Shapes.generator.GenShape)node).updateLabel(this.textNameBox.Text);
            }
            else if (this.node is Shapes.generator.GenShape)
            {
                Generator gen = ((Shapes.generator.GenShape)node).GeneratorItem;
                gen.Name = this.textNameBox.Text;
                GeneratorBL genBL = new GeneratorBL();
                genBL.edit(gen, CustomContentControl.getCurrentCase());
                //((Shapes.generator.GenShape)node).updateLabel(this.textNameBox.Text);
            }*/

            // Line Double Circuitline
            else if (this.node is Shapes.Line.DoubleCircuitShape)
            {
                DoubleCircuitLine line = ((Shapes.Line.DoubleCircuitShape)node).DoubleCircuitLineItem;
                line.Name = this.textNameBox.Text;
                DoubleCircuitLineBL lineBL = new DoubleCircuitLineBL();
                lineBL.edit(line, CustomContentControl.getCurrentCase());

            }
            else if (this.node is Shapes.Load.LoadShape)
            {
                Loads loads = ((Shapes.Load.LoadShape)node).getLoad();
                loads.Name = this.textNameBox.Text;
                LoadBL loadBL = new LoadBL();
                loadBL.editLoad(loads, CustomContentControl.getCurrentCase());
            }
            else if (this.node is Shapes.RLC.RLCShape)
            {
                RLCbranches rlc = ((Shapes.RLC.RLCShape)node).getRLCBranch();
                rlc.name = this.textNameBox.Text;
                IRlcBL rlcBL = null;
                if (node is Shapes.RLC.RShape)
                {
                    rlcBL = new RBL();
                }
                else if (node is Shapes.RLC.LShape)
                {
                    rlcBL = new LBL();
                }
                else if (node is Shapes.RLC.CShape)
                {
                    rlcBL = new CBL();
                }
                else if (node is Shapes.RLC.LCShape)
                {
                    rlcBL = new LcBL();
                }
                else if (node is Shapes.RLC.RLShape)
                {
                    rlcBL = new RlBL();
                }
                else if (node is Shapes.RLC.RLCShape)
                {
                    rlcBL = new RlcBL();
                }

                rlcBL.edit(rlc, CustomContentControl.getCurrentCase());
                ((Shapes.RLC.RLCShape)node).setLabel(this.textNameBox.Text);
            }
            else if (this.node is Shapes.Transformer.AbstractTShape)
            {
                MainTransformers transformer = ((Shapes.Transformer.AbstractTShape)node).getTransformerType();
                transformer.name = this.textNameBox.Text;
                ITransformer transformerBL = null;
                if (node is Shapes.Transformer.C2WTShape)
                {
                    C2WTransformerBL c2wtransformerBL = new C2WTransformerBL();

                    c2wtransformerBL.edit((C2WTransformer)transformer, CustomContentControl.getCurrentCase());
                }
                else if (node is Shapes.Transformer.TriTShape)
                {
                    C3WTransformerBL c3WTransformerBL = new C3WTransformerBL();
                    c3WTransformerBL.edit((C3WTransformer)transformer, CustomContentControl.getCurrentCase());
                }
                else if (node is Shapes.Transformer.CustomTShape)
                {
                    transformerBL = new TTransformerBL();
                    transformerBL.edit(transformer, CustomContentControl.getCurrentCase());
                }
                else if (node is Shapes.Transformer.YgDDTShape)
                {
                    transformerBL = new YgDDTransformerBL();
                    transformerBL.edit(transformer, CustomContentControl.getCurrentCase());
                }
                else if (node is Shapes.Transformer.YgYgDTShape)
                {
                    transformerBL = new YgYgDTransformerBL();
                    transformerBL.edit(transformer, CustomContentControl.getCurrentCase());
                }

            }
            this.Close();
        }

        private void Cancelbutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
