using BL;
using GUI.bus;
using GUI.contextMenu;
using GUI.customDocumentWindow;
using GUI.generator;
using GUI.Load;
using GUI.Rlc;
using GUI.Transformer;
using network;
using persistent;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace GUI.New_concept
{
    public static class UtilitiesShape
    {

        public static RadDiagramShape shape_selector(string selection)
        {
            RadDiagramShape shape = null;
            switch (selection)
            {
                case "BusShape":
                    shape = new bus.BusShape();
                    break;
                case "GenShape":
                    shape = new generator.GenShape();
                    break;
                case "LoadShape":
                    shape = new Load.LoadShape();
                    break;
                case "SchuntShape":
                    shape = new schunt.SchuntShape();
                    break;
                case "TriTransformerShape":
                    shape = new Transformer.TriTransformerShape();
                    break;
                case "YgDDTransformerShape":
                    shape = new Transformer.YgDDTransformerShape();
                    break;
                case "YgYgDTransformerShape":
                    shape = new Transformer.YgYgDTransformerShape();
                    break;
                case "TTransformerShape":
                    shape = new Transformer.TTransformerShape();
                    break;
                case "CShape":
                    shape = new Rlc.CShape();
                    break;
                case "LShape":
                    shape = new Rlc.LShape();
                    break;
                case "RShape":
                    shape = new Rlc.RShape();
                    break;
                case "LCShape":
                    shape = new Rlc.LCShape();
                    break;
                case "RLShape":
                    shape = new Rlc.RLShape();
                    break;
                case "RLCShape":
                    shape = new Rlc.RLCShape();
                    break;
                case "MonoLineShape":
                    shape = new Line.MonoLineShape();
                    break;
                case "BiLineShape":
                    shape = new Line.BiLineShape();
                    break;
                case "TriLineShape":
                    shape = new Line.TriLineShape();
                    break;
                default:
                    shape = null;
                    break;
            }
            return shape;
        }

        public static RadDiagramShape shapeTree_selector(string nodeText, Case cases)
        {
            RadDiagramShape shape = null;
            switch (nodeText)
            {
                case "Bus":
                    shape = new bus.BusShape();
                    break;
                case "Generator":
                    shape = new generator.GenShape();
                    break;
                case "Load":
                    shape = new Load.LoadShape();
                    break;
                case "Switch":
                    shape = new schunt.SchuntShape();
                    break;
                case "Triphasic":
                    shape = new Transformer.TriTransformerShape();
                    break;
                case "YgDD":
                    shape = new Transformer.YgDDTransformerShape();
                    break;
                case "YgYgD":
                    shape = new Transformer.YgYgDTransformerShape();
                    break;
                case "Custom":
                    shape = new Transformer.TTransformerShape();
                    break;
                case "C":
                    shape = new Rlc.CShape();
                    break;
                case "L":
                    shape = new Rlc.LShape();
                    break;
                case "R":
                    shape = new Rlc.RShape();
                    break;
                case "LC":
                    shape = new Rlc.LCShape();
                    break;
                case "RL":
                    shape = new Rlc.RLShape();
                    break;
                case "RLC":
                    shape = new Rlc.RLCShape();
                    break;
                case "Three-Phase":
                    shape = new Line.MonoLineShape();
                    break;
                case "Double circuit":
                    shape = new Line.BiLineShape();
                    break;
                case "M-Phase":
                    shape = new Line.TriLineShape();
                    break;
                default:
                    shape = null;
                    break;
            }
            return shape;
        }

        public static string shapeToolDiagram_selector(string selection)
        {
            string shape = null;
            switch (selection)
            {
                case "Bus":
                    shape = "BusShape";
                    break;
                case "Generator":
                    shape = "GenShape";
                    break;
                case "Load":
                    shape = "LoadShape";
                    break;
                case "Switch":
                    shape = "SchuntShape";
                    break;
                case "Triphasic":
                    shape = "TriTransformerShape";
                    break;
                case "YgDD":
                    shape = "YgDDTransformerShape";
                    break;
                case "YgYgD":
                    shape = "YgYgDTransformerShape";
                    break;
                case "Custom":
                    shape = "TTransformerShape";
                    break;
                case "C":
                    shape = "CShape";
                    break;
                case "L":
                    shape = "LShape";
                    break;
                case "R":
                    shape = "RShape";
                    break;
                case "LC":
                    shape = "LCShape";
                    break;
                case "RL":
                    shape = "RLShape";
                    break;
                case "RLC":
                    shape = "RLCShape";
                    break;
                case "Three-Phase":
                    shape = "MonoLineShape";
                    break;
                case "Double circuit":
                    shape = "BiLineShape";
                    break;
                case "M-Phase":
                    shape = "TriLineShape";
                    break;
                default:
                    shape = null;
                    break;
            }
            return shape;
        }

        internal static Image Resize(Image image, Size size)
        {
            double aspectRatio = (double)image.Width / image.Height;
            double boxRatio = (double)size.Width / size.Height;
            double scaleFactor;

            if (boxRatio > aspectRatio)
            {
                scaleFactor = (double)size.Height / image.Height;
            }
            else
            {
                scaleFactor = (double)size.Width / image.Width;
            }

            int newWidth = (int)(image.Width * scaleFactor);
            int newHeight = (int)(image.Height * scaleFactor);

            Image newImage = new Bitmap(newWidth, newHeight);
            using (Graphics graphics = Graphics.FromImage(newImage))
            {
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                graphics.DrawImage(image, new Rectangle(0, 0, newWidth, newHeight));
            }
            return newImage;
        }

        public static void blConnection_support(RadDiagramShape shape, string type = "Properties", int mode = 0, string name = null)
        {
            if (shape is bus.BusShape)
            {
                bus.BusShape busShape = ((GUI.bus.BusShape)shape);
                Bus bus = busShape.getBus();
                if (type.Equals("Properties"))
                {
                    Bus_Main bus_main = new Bus_Main(bus);
                    bus_main.ShowDialog();
                }
                else if (type.Equals("Name"))
                {
                    ChangeName_Form shapeName = new ChangeName_Form(ref shape);
                    shapeName.ShowDialog();
                }
                else if (type.Equals("Delete")) 
                {
                    BL.BusBL busBL = new BL.BusBL();
                    busBL.removeBus(bus, busShape.getCase());
                    if (mode == 0) 
                    { 
                        busShape.Dispose(); 
                    }
                    MessageBox.Show(bus.BusName + " was erased");
                }
            }
            else if(shape is generator.GenShape)
            {
                generator.GenShape genShape = ((GUI.generator.GenShape)shape);
                Generator generator = genShape.getGenerator();
                if (type.Equals("Properties"))
                {
                    Generator_Main generator_main = new Generator_Main(generator);
                    generator_main.ShowDialog();
                    genShape.updateLabel(generator_main.getGenerator().powerControl.setpoint);
                    genShape.updateLabel2(generator_main.getGenerator().voltageControl.MvarOutput);
                }
                else if (type.Equals("Name")) 
                {
                    ChangeName_Form shapeName= new ChangeName_Form(ref shape);
                    shapeName.ShowDialog();
                }
                else if (type.Equals("Delete"))
                {
                    GeneratorBL genBL = new GeneratorBL();
                    genBL.remove(generator, genShape.getCase());
                    if (mode == 0)
                    {
                        genShape.Dispose();
                    }
                    MessageBox.Show(genShape.Name + " was erased");
                }

            }
            else if (shape is Load.LoadShape)
            {
                Load.LoadShape loadShape = ((GUI.Load.LoadShape)shape);
                Loads loads = loadShape.getLoad();
                if (type.Equals("Properties"))
                {
                    Load_Main load_Main = new Load_Main(loads);
                    load_Main.ShowDialog();
                }
                else if (type.Equals("Name"))
                {
                    ChangeName_Form shapeName = new ChangeName_Form(ref shape);
                    shapeName.ShowDialog();
                }
                else if (type.Equals("Delete"))
                {
                    LoadBL loadBL = new LoadBL();
                    loadBL.removeLoad(loads, loadShape.getCase());
                    if (mode == 0)
                    {
                        loadShape.Dispose();
                    }
                    MessageBox.Show(loads.Name + " was erased");
                }
            }
            else if (shape is Rlc.AbstractRLCShape)
            {
                AbstractRLCShape rlcShape = ((AbstractRLCShape)shape);
                RLCbranches rlc = rlcShape.getRlcBranch();
                if (type.Equals("Properties"))
                {
                    RLC_Main rlc_main = new RLC_Main(rlc);
                    rlc_main.ShowDialog();
                    rlcShape.setLabel(rlc.name);
                }
                else if (type.Equals("Name"))
                {
                    ChangeName_Form shapeName = new ChangeName_Form(ref shape);
                    shapeName.ShowDialog();
                }
                else if (type.Equals("Delete"))
                {
                    IRlcBL rlcBL = null;
                    if (shape is RShape)
                    {
                        rlcBL = new RBL();
                    }
                    else if (shape is LShape)
                    {
                        rlcBL = new LBL();
                    }
                    else if (shape is CShape)
                    {
                        rlcBL = new CBL();
                    }
                    else if (shape is LCShape)
                    {
                        rlcBL = new LcBL();
                    }
                    else if (shape is RLShape)
                    {
                        rlcBL = new RlBL();
                    }
                    else if (shape is RLCShape)
                    {
                        rlcBL = new RlcBL();
                    }
                    rlcBL.remove(rlc, rlcShape.getCase());
                    if (mode == 0)
                    {
                        rlcShape.Dispose();
                    }
                    checkAndPront(rlc.name, rlc.branch);
                }

            }
            else if (shape is Transformer.AbstractTRShape)
            {
                AbstractTRShape transformerShape = ((AbstractTRShape)shape);
                MainTransformers transformer = transformerShape.getTransformerType();
                if (type.Equals("Properties"))
                {
                    Transformer_Main transformer_Main = new Transformer_Main(transformer);
                    transformer_Main.ShowDialog();
                    transformerShape.setLabel(transformer.name);
                    if (shape is TTransformerShape) {
                        var temp = (TTransformer)transformer;
                        ((TTransformerShape)transformerShape).setImAll(temp.windingA, temp.windingB, temp.windingC,
                                                                       temp.windingAZ == 0 ? true : false,
                                                                       temp.windingBZ == 0 ? true : false,
                                                                       temp.windingCZ == 0 ? true : false);
                    }
                }
                else if (type.Equals("Name"))
                {
                    ChangeName_Form shapeName = new ChangeName_Form(ref shape);
                    shapeName.ShowDialog();
                }
                else if (type.Equals("Delete"))
                {
                    ITransformer transformerBL = null;
                    if (shape is TriTransformerShape)
                    {
                        transformerBL = new TriTransformerBL();
                    }
                    else if (shape is YgDDTransformerShape)
                    {
                        transformerBL = new YgDDTransformerBL();
                    }
                    else if (shape is YgYgDTransformerShape)
                    {
                        transformerBL = new YgYgDTransformerBL();
                    }
                    else if (shape is TTransformerShape) 
                    {
                        transformerBL = new TTransformerBL();
                    }
                    transformerBL.remove(transformer, transformerShape.getCase());
                    if (mode == 0)
                    {
                        transformerShape.Dispose();
                    }
                    checkAndPront(transformer.name, transformer.type);
                }
            }
        }


        private static void checkAndPront(string name, string component) 
        {
            var description = long.TryParse(name, out _) ? (component + " " + name) : name;
            MessageBox.Show(description + " was erased");
        }
    }
}
