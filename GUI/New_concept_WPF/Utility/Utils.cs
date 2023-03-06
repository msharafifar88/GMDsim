using Syncfusion.UI.Xaml.Diagram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL;
using network;
using persistent;
using GUI.generator;
using GUI.contextMenu;
using System.Windows;
using persistent.common;
using network.generator.Gentype;
using persistent.network.load_entitiy;
using BL.Load_BL;
using persistent.enumeration;
using persistent.network;
using GUI.bus;
using GUI.New_concept_WPF.Custom_Controls.CustomPort;

namespace GUI.New_concept_WPF.Utility
{
    public class Utils
    {

        public static System.Windows.Controls.Image addImage(string uri, double h , double w)
        {
            System.Windows.Controls.Image img = new System.Windows.Controls.Image();
            System.Windows.Media.Imaging.BitmapImage bmp = new System.Windows.Media.Imaging.BitmapImage();
            bmp.BeginInit();
            bmp.UriSource = new Uri(uri, UriKind.RelativeOrAbsolute);
            bmp.EndInit();
            img.Stretch = System.Windows.Media.Stretch.Fill;
            img.Source = bmp;
            img.Height = h;
            img.Width = w;
            return img;
        }

        public static void conSelector(Syncfusion.UI.Xaml.Diagram.ItemAddedEventArgs args=null, string bus = null) {
            //MessageBox.Show("here");
            System.Windows.Style style = new System.Windows.Style(typeof(System.Windows.Shapes.Path));
            switch (bus){
                case "A":
                    style.Setters.Add(new System.Windows.Setter(System.Windows.Shapes.Path.StrokeProperty, System.Windows.Media.Brushes.Red));
                    style.Setters.Add(new System.Windows.Setter(System.Windows.Shapes.Path.StrokeThicknessProperty, 1d));
                    //MainMenu.currentDiagram.DefaultConnectorType = ConnectorType.PolyLine;
                    (args.Item as CoreConnector).setType("A");
                    break;
                case "B":
                    style.Setters.Add(new System.Windows.Setter(System.Windows.Shapes.Path.StrokeProperty, System.Windows.Media.Brushes.DeepSkyBlue));
                    style.Setters.Add(new System.Windows.Setter(System.Windows.Shapes.Path.StrokeThicknessProperty, 1d));
                    //MainMenu.currentDiagram.DefaultConnectorType = ConnectorType.PolyLine;
                    (args.Item as CoreConnector).setType("B");
                    break;
                case "C":
                    style.Setters.Add(new System.Windows.Setter(System.Windows.Shapes.Path.StrokeProperty, System.Windows.Media.Brushes.LawnGreen));
                    style.Setters.Add(new System.Windows.Setter(System.Windows.Shapes.Path.StrokeThicknessProperty, 1d));
                    //MainMenu.currentDiagram.DefaultConnectorType = ConnectorType.PolyLine;
                    (args.Item as CoreConnector).setType("C");
                    break;
                case "Diagonal":
                    style.Setters.Add(new System.Windows.Setter(System.Windows.Shapes.Path.StrokeProperty, System.Windows.Media.Brushes.Purple));
                    style.Setters.Add(new System.Windows.Setter(System.Windows.Shapes.Path.StrokeThicknessProperty, 2d));
                    //MainMenu.currentDiagram.DefaultConnectorType = ConnectorType.PolyLine;
                    (args.Item as CoreConnector).setType("D-Signal");
                    break;
                case "Bundle":
                    style.Setters.Add(new System.Windows.Setter(System.Windows.Shapes.Path.StrokeProperty, System.Windows.Media.Brushes.Turquoise));
                    style.Setters.Add(new System.Windows.Setter(System.Windows.Shapes.Path.StrokeThicknessProperty, 2d));
                    //MainMenu.currentDiagram.DefaultConnectorType = ConnectorType.PolyLine;
                    (args.Item as CoreConnector).setType("Bundle");
                    break;
                case "ThreePhase":
                    style.Setters.Add(new System.Windows.Setter(System.Windows.Shapes.Path.StrokeProperty, System.Windows.Media.Brushes.OrangeRed));
                    style.Setters.Add(new System.Windows.Setter(System.Windows.Shapes.Path.StrokeThicknessProperty, 5d));
                    Main_Menu.currentDiagram.DefaultConnectorType = ConnectorType.Line;
                    (args.Item as CoreConnector).setType("3-Phase");
                    break;
                case null:
                    style.Setters.Add(new System.Windows.Setter(System.Windows.Shapes.Path.StrokeProperty, System.Windows.Media.Brushes.Black));
                    style.Setters.Add(new System.Windows.Setter(System.Windows.Shapes.Path.StrokeThicknessProperty, 5d));

                   // style.Setters.Add(new System.Windows.Setter(System.Windows.Shapes.Path))
                    //MainMenu.currentDiagram.DefaultConnectorType = ConnectorType.PolyLine;
                    (args.Item as CoreConnector).setType("Bus");
                    break;
                default:
                    style.Setters.Add(new System.Windows.Setter(System.Windows.Shapes.Path.StrokeProperty, System.Windows.Media.Brushes.Black));
                    style.Setters.Add(new System.Windows.Setter(System.Windows.Shapes.Path.StrokeThicknessProperty, 2d));
                    //MainMenu.currentDiagram.DefaultConnectorType = ConnectorType.PolyLine;
                    (args.Item as CoreConnector).setType("Bus");
                    break;
            }
            (args.Item as CoreConnector).ConnectorGeometryStyle = style;  
        }

       /* public static string elementToNode(string selection)
        {
            string node = null;
            switch (selection)
            {
                case "Bus":
                    node = "BusShape";
                    break;
                case "Generator":
                    node = "GenShape";
                    break;
                case "Load":
                    node = "LoadShape";
                    break;
                case "Switch":
                    node = "SchuntShape";
                    break;
                case "Triphasic":
                    node = "TriTransformerShape";
                    break;
                case "Custom 2W":
                    node = "2WTransformerShape";
                    break;
                case "YgDD":
                    node = "YgDDTransformerShape";
                    break;
                case "YgYgD":
                    node = "YgYgDTransformerShape";
                    break;
                case "Custom":
                    node = "TTransformerShape";
                    break;
                case "C":
                    node = "CShape";
                    break;
                case "L":
                    node = "LShape";
                    break;
                case "R":
                    node = "RShape";
                    break;
                case "LC":
                    node = "LCShape";
                    break;
                case "RL":
                    node = "RLShape";
                    break;
                case "RLC":
                    node = "RLCShape";
                    break;
                case "Three-Phase":
                    node = "ThreePhaseShape";
                    break;
                case "Double circuit":
                    node = "DoubleCircuitShape";
                    break;
                case "M-Phase":
                    node = "MultiPhaseShape";
                    break;
                default:
                    node = null;
                    break;
            }
            return node;
        }*/

        public static NodeViewModel node_selector(ItemEnum selection)
        {
            NodeViewModel node = null;
            switch (selection)
            {
                case ItemEnum.Bus:
                    node = new Shapes.ExBus.BusShape();
                    break;
                case ItemEnum.Generator:
                    node = new Shapes.generator.GenShape();
                    break;
                case ItemEnum.PVPnels:
                    node = new Shapes.generator.PVGenShape();
                    break;
                case ItemEnum.Wind:
                    node = new Shapes.generator.WindGenShape();
                    break;
                case ItemEnum.SyncGen:
                    node = new Shapes.generator.SyncGenShape();
                    break;
                case ItemEnum.Load:
                    node = new Shapes.Load.LoadShape();
                    break;
                case ItemEnum.EvMachine:
                    node = new Shapes.Load.EVShape();
                    break;
                //case "schuntshape":
                //  node = new schunt.schuntshape();
                // break;
               case ItemEnum.Triphasic:
                    node = new Shapes.Transformer.TriTShape();
                    break;
               case ItemEnum.C2WindingThransformer:
                    node = new Shapes.Transformer.C2WTShape();
                    break;
                case ItemEnum.YgDD:
                    node = new Shapes.Transformer.YgDDTShape();
                    break;
                case ItemEnum.YgYgD:
                    node = new Shapes.Transformer.YgYgDTShape();
                    break;
                case ItemEnum.YgD:
                    node = new Shapes.Transformer.YgDTShape();
                    break;
                case ItemEnum.Custom3wT:
                    node = new Shapes.Transformer.CustomC3WShape();
                    break;
                case ItemEnum.C:
                    node = new Shapes.RLC.CShape();
                    break;
                case ItemEnum.L:
                    node = new Shapes.RLC.LShape();
                    break;
                case ItemEnum.R:
                    node = new Shapes.RLC.RShape();
                    break;
                case ItemEnum.LC:
                    node = new Shapes.RLC.LCShape();
                    break;
                case ItemEnum.RL:
                    node = new Shapes.RLC.RLShape();
                    break;
                case ItemEnum.RLC:
                    node = new Shapes.RLC.RLCShape();
                    break;
                case ItemEnum.MPhase:
                    node = new Shapes.Line.MphaseShape();
                    break;
                case ItemEnum.DoubleCircuit:
                    node = new Shapes.Line.DoubleCircuitShape();
                    break;
                case ItemEnum.Singleline3phase:
                    node = new Shapes.Line.Singleline3phaseShape();
                    break;
                default:
                    node = null;
                    break;
            }
            return node;
        }

        public static void blConn_WPF(CoreConnector conn, int mode = 0, string type = "Properties", string name = null)
        {
            if (mode == 0)
            {
                if (type.Equals("Properties"))
                {
                    Bus busdef = conn.getBus();
                    Bus_Main bus_main = new Bus_Main(busdef);
                    bus_main.ShowDialog();
                }
            }
            if (mode == 1)
            {
                if (type.Equals("Properties"))
                {
                    persistent.network.wire.Wire wire = conn.getWire();
                    WireMain.Wire_Main wireMain = new WireMain.Wire_Main(wire);
                    wireMain.ShowDialog();
                }
            }
        }


    public static void blConnection_WPF(NodeViewModel node, string type = "Properties", int mode = 0, string name = null, Bus bus = null ,CustomPort customPort = null)
        {
            if (node is Shapes.generator.GenShape)
            {
                Shapes.generator.GenShape genShape = ((Shapes.generator.GenShape)node);
                Generator generator = genShape.GeneratorItem;
                if (type.Equals("Properties"))
                {
                    Generator_Main generator_main = new Generator_Main(generator);
                    generator_main.ShowDialog();
                    genShape.updateLabel(generator_main.getGenerator().powerControl.setpoint);
                    genShape.updateLabel2(generator_main.getGenerator().voltageControl.MvarOutput);
                }
                else if (type.Equals("Name"))
                {
                    ChangeNameForm shapeName = new ChangeNameForm(ref node);
                    shapeName.ShowDialog();
                }
                else if (type.Equals("Delete"))
                {
                    GeneratorBL genBL = new GeneratorBL();
                    genBL.remove(generator, genShape.getCase());
                    //MessageBox.Show(genShape.Name + " was erased");
                }
                else if (type.Equals(UtilsKeywords.Registration.ToString()))
                {
                    generator.Bus = bus;
                }

            }
            else if (node is Shapes.generator.SyncGenShape)
            {
                Shapes.generator.SyncGenShape syncGenShape = ((Shapes.generator.SyncGenShape)node);
                SyncGen syncGen = syncGenShape.GetSyncGen();
                if (type.Equals("Properties"))
                {
                    SyncGen_main syncGen_Main = new SyncGen_main(syncGen);
                    syncGen_Main.ShowDialog();
                    syncGenShape.updateLabel(syncGen_Main.getSyncGen().powerControl.setpoint);
                    syncGenShape.updateLabel2(syncGen_Main.getSyncGen().voltageControl.MvarOutput);
                }
                else if (type.Equals("Name"))
                {
                    ChangeNameForm shapeName = new ChangeNameForm(ref node);
                    shapeName.ShowDialog();
                }
                else if (type.Equals("Delete"))
                {
                    SyncGenBL genBL = new SyncGenBL();
                    genBL.remove(syncGen, syncGenShape.getCase());
                    //MessageBox.Show(genShape.Name + " was erased");
                }
                else if (type.Equals(UtilsKeywords.Registration.ToString()))
                {
                    syncGen.Bus = bus;
                }

            }
            else if (node is Shapes.generator.SyncGenShape)
            {
                Shapes.generator.SyncGenShape syncGenShape = ((Shapes.generator.SyncGenShape)node);
                SyncGen syncGen = syncGenShape.GetSyncGen();
                if (type.Equals("Properties"))
                {
                    SyncGen_main syncGen_Main = new SyncGen_main(syncGen);
                    syncGen_Main.ShowDialog();
                    syncGenShape.updateLabel(syncGen_Main.getSyncGen().powerControl.setpoint);
                    syncGenShape.updateLabel2(syncGen_Main.getSyncGen().voltageControl.MvarOutput);
                }
                else if (type.Equals("Name"))
                {
                    ChangeNameForm shapeName = new ChangeNameForm(ref node);
                    shapeName.ShowDialog();
                }
                else if (type.Equals("Delete"))
                {
                    SyncGenBL genBL = new SyncGenBL();
                    genBL.remove(syncGen, syncGenShape.getCase());
                    //MessageBox.Show(genShape.Name + " was erased");
                }
                else if (type.Equals(UtilsKeywords.Registration.ToString()))
                {
                    syncGen.Bus = bus;
                }

            }
            else if (node is Shapes.generator.WindGenShape)
            {
                Shapes.generator.WindGenShape windGenShape = ((Shapes.generator.WindGenShape)node);
                WindGen windGen = windGenShape.getWindGen();
                if (type.Equals("Properties"))
                {
                    WindGenerator_Main windGenerator_Main = new WindGenerator_Main(windGen);
                    windGenerator_Main.ShowDialog();
                    windGenShape.updateLabel(windGenerator_Main.getWindGen().powerControl.setpoint);
                    windGenShape.updateLabel2(windGenerator_Main.getWindGen().voltageControl.MvarOutput);
                }
                else if (type.Equals("Name"))
                {
                    ChangeNameForm shapeName = new ChangeNameForm(ref node);
                    shapeName.ShowDialog();
                }
                else if (type.Equals("Delete"))
                {
                    WindGenBL windBL = new WindGenBL();
                    windBL.remove(windGen, windGenShape.getCase());
                    //MessageBox.Show(genShape.Name + " was erased");
                }
                else if (type.Equals(UtilsKeywords.Registration.ToString()))
                {
                    windGen.Bus = bus;
                }

            }
            else if (node is Shapes.generator.PVGenShape)
            {
                Shapes.generator.PVGenShape pvGenShape = ((Shapes.generator.PVGenShape)node);
                PVGen pvGen = pvGenShape.PVGeneratorItem;
                if (type.Equals("Properties"))
                {
                    PV_Main pv_Main = new PV_Main(pvGen);
                    pv_Main.ShowDialog();
                    pvGenShape.updateLabel(pv_Main.getPVGen().powerControl.setpoint);
                    pvGenShape.updateLabel2(pv_Main.getPVGen().voltageControl.MvarOutput);
                }
                else if (type.Equals("Name"))
                {
                    ChangeNameForm shapeName = new ChangeNameForm(ref node);
                    shapeName.ShowDialog();
                }
                else if (type.Equals("Delete"))
                {
                    PVGenBL pvgenBL = new PVGenBL();
                    pvgenBL.remove(pvGen, pvGenShape.getCase());
                    //MessageBox.Show(genShape.Name + " was erased");
                }
                else if (type.Equals(UtilsKeywords.Registration.ToString()))
                {
                    pvGen.Bus = bus;
                }


            }

            else if (node is Shapes.Load.LoadShape)
            {
                Shapes.Load.LoadShape loadShape = (Shapes.Load.LoadShape)node;
                Loads loads = loadShape.getLoad();
                if (type.Equals("Properties"))
                {
                    GUI.Load.Load_Main load_Main = new GUI.Load.Load_Main(loads);
                    load_Main.ShowDialog();
                }
                else if (type.Equals("Name"))
                {
                    ChangeNameForm shapeName = new ChangeNameForm(ref node);
                    shapeName.ShowDialog();
                }
                else if (type.Equals("Delete"))
                {
                    LoadBL loadBL = new LoadBL();
                    loadBL.removeLoad(loads, loadShape.getCase());
                }
                else if (type.Equals(UtilsKeywords.Registration.ToString()))
                {
                    loads.Bus = bus;
                }
            }
            else if (node is Shapes.Load.EVShape)
            {
                Shapes.Load.EVShape evShape = (Shapes.Load.EVShape)node;
                EV loads = evShape.getEV();
                if (type.Equals("Properties"))
                {
                    GUI.Load.EV_Main ev_Main = new GUI.Load.EV_Main(loads);
                    ev_Main.ShowDialog();
                }
                else if (type.Equals("Name"))
                {
                    ChangeNameForm shapeName = new ChangeNameForm(ref node);
                    shapeName.ShowDialog();
                }
                else if (type.Equals("Delete"))
                {
                    EVBL loadBL = new EVBL();
                    loadBL.removeEV(loads, evShape.getCase());
                }
                else if (type.Equals(UtilsKeywords.Registration.ToString()))
                {
                    loads.Bus = bus;
                }
            }
            else if (node is Shapes.RLC.AbstractRLCCShape)
            {
                Shapes.RLC.AbstractRLCCShape rlcShape = (Shapes.RLC.AbstractRLCCShape)node;
                RLCbranches rlc = rlcShape.getRLCBranch();
                if (type.Equals("Properties"))
                {
                    Rlc.RLC_Main rlc_main = new Rlc.RLC_Main(rlc);
                    rlc_main.ShowDialog();
                    rlcShape.setLabel(rlc_main.getRLC().name);
                }
                else if (type.Equals("Name"))
                {
                    ChangeNameForm shapeName = new ChangeNameForm(ref node);
                    shapeName.ShowDialog();
                }
                else if (type.Equals("Delete"))
                {
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
                    rlcBL.remove(rlc, rlcShape.getCase());
                    //checkAndPront(rlc.name, rlc.branch);
                }
                else if (type.Equals(UtilsKeywords.Registration.ToString()))
                {
                    rlc.Bus = bus;
                }

            }

            ////
            else if (node is Shapes.Transformer.C2WTShape)
            {
                Shapes.Transformer.C2WTShape c2wShape = (Shapes.Transformer.C2WTShape)node;
                C2WTransformer c2w = (C2WTransformer)c2wShape.getTransformerType();
                if (type.Equals("Properties"))
                {
                    GUI.Transformer.Main2WTransformerMenu c2w_Main = new GUI.Transformer.Main2WTransformerMenu(c2w);
                    c2w_Main.ShowDialog();
                }
                else if (type.Equals("Name"))
                {
                    ChangeNameForm shapeName = new ChangeNameForm(ref node);
                    shapeName.ShowDialog();
                }
                else if (type.Equals("Delete"))
                {
                    C2WTransformerBL c2wBL = new C2WTransformerBL();
                    c2wBL.remove(c2w, c2wShape.getCase());
                }
                else if (type.Equals(UtilsKeywords.Registration.ToString()))
                {
                    if (customPort != null)
                    {
                        //c2w.PrimaryBUS == null || c2w.PrimaryBUS != null && c2w.PrimaryBUS != bus
                        if (customPort.Name.Contains("port1"))
                        {
                            c2w.PrimaryBUS = bus;
                        }
                        else //if ((c2w.SecondaryBUS == null && c2w.PrimaryBUS != null || c2w.SecondaryBUS != null && c2w.SecondaryBUS != bus))
                        {
                            c2w.SecondaryBUS = bus;
                        }
                    }
                }
                
            }
            else if (node is Shapes.Transformer.CustomC3WShape)
            {
                Shapes.Transformer.CustomC3WShape c3wShape = (Shapes.Transformer.CustomC3WShape)node;
                C3WTransformer c3w = (C3WTransformer)c3wShape.getTransformerType();
                if (type.Equals("Properties"))
                {
                    GUI.Transformer.Main3WTransformerMenu c3w_Main = new GUI.Transformer.Main3WTransformerMenu(c3w);
                    c3w_Main.ShowDialog();
                }
                else if (type.Equals("Name"))
                {
                    ChangeNameForm shapeName = new ChangeNameForm(ref node);
                    shapeName.ShowDialog();
                }
                else if (type.Equals("Delete"))
                {
                    C3WTransformerBL c3wBL = new C3WTransformerBL();
                    c3wBL.remove(c3w, c3wShape.getCase());
                }
                else if (type.Equals(UtilsKeywords.Registration.ToString()))
                {
                    if (customPort != null)
                    {
                        //c2w.PrimaryBUS == null || c2w.PrimaryBUS != null && c2w.PrimaryBUS != bus
                        if (customPort.Name.Contains("port1"))
                        {
                            c3w.PrimaryBUS = bus;
                        }
                        else if (customPort.Name.Contains("port2"))
                        {
                            c3w.SecondaryBUS = bus;
                        }
                        else 
                        {
                            c3w.TertiaryBUS = bus;
                        }
                    }
                }
            }

            else if (node is Shapes.Line.DoubleCircuitShape)
            {
                Shapes.Line.DoubleCircuitShape lineShape = (Shapes.Line.DoubleCircuitShape)node;
                DoubleCircuitLine doubleCircuit = lineShape.DoubleCircuitLineItem;
                if (type.Equals("Properties"))
                {
                    Line.Doublecircuit_main line_main = new Line.Doublecircuit_main(doubleCircuit);
                    line_main.ShowDialog();
                }
                else if (type.Equals("Name"))
                {
                    ChangeNameForm shapeName = new ChangeNameForm(ref node);
                    shapeName.ShowDialog();
                }
                else if (type.Equals("Delete"))
                {
                    DoubleCircuitLineBL doubleCircuitLineBL = new DoubleCircuitLineBL();
                    doubleCircuitLineBL.remove(doubleCircuit, lineShape.getCase());
                }
                else if (type.Equals(UtilsKeywords.Registration.ToString()))
                {
                    if (customPort != null)
                    {
                        //c2w.PrimaryBUS == null || c2w.PrimaryBUS != null && c2w.PrimaryBUS != bus
                        if (customPort.Name.Contains("port1"))
                        {
                            doubleCircuit.FromBus = bus;
                        }
                        else //if ((c2w.SecondaryBUS == null && c2w.PrimaryBUS != null || c2w.SecondaryBUS != null && c2w.SecondaryBUS != bus))
                        {
                            doubleCircuit.ToBus = bus;
                        }
                    }
                }
            }
            else if (node is Shapes.Line.MphaseShape)
            {
                Shapes.Line.MphaseShape lineShape = (Shapes.Line.MphaseShape)node;
                MultiPhaseLine multiPhaseLine = lineShape.GetMMltiPhaseLine();
                if (type.Equals("Properties"))
                {
                    Line.Mphase_main line_main = new Line.Mphase_main(multiPhaseLine);
                    line_main.ShowDialog();
                }
                else if (type.Equals("Name"))
                {
                    ChangeNameForm shapeName = new ChangeNameForm(ref node);
                    shapeName.ShowDialog();
                }
                else if (type.Equals("Delete"))
                {
                    MultiPhaseLineBL multiPhaseLineBL = new MultiPhaseLineBL();
                    multiPhaseLineBL.remove(multiPhaseLine, lineShape.getCase());
                }
                else if (type.Equals(UtilsKeywords.Registration.ToString()))
                {
                    if (customPort != null)
                    {
                        //c2w.PrimaryBUS == null || c2w.PrimaryBUS != null && c2w.PrimaryBUS != bus
                        if (customPort.Name.Contains("port1"))
                        {
                            multiPhaseLine.FromBus = bus;
                        }
                        else //if ((c2w.SecondaryBUS == null && c2w.PrimaryBUS != null || c2w.SecondaryBUS != null && c2w.SecondaryBUS != bus))
                        {
                            multiPhaseLine.ToBus = bus;
                        }
                    }
                }
            }
            else if (node is Shapes.Line.Singleline3phaseShape)
            {
                Shapes.Line.Singleline3phaseShape lineShape = (Shapes.Line.Singleline3phaseShape)node;
                Single3phaseLine single3PhaseLine = lineShape.GetSingle3PhaseLine();
                if (type.Equals("Properties"))
                {
                    Line.Single3PhaseLine_main line_main = new Line.Single3PhaseLine_main(single3PhaseLine);
                    line_main.ShowDialog();
                }
                else if (type.Equals("Name"))
                {
                    ChangeNameForm shapeName = new ChangeNameForm(ref node);
                    shapeName.ShowDialog();
                }
                else if (type.Equals("Delete"))
                {
                    Single3phaseLineBL single3PhaseLineBL = new Single3phaseLineBL();
                    single3PhaseLineBL.remove(single3PhaseLine, lineShape.getCase());
                }
                else if (type.Equals(UtilsKeywords.Registration.ToString()))
                {
                    if (customPort != null)
                    {
                        //c2w.PrimaryBUS == null || c2w.PrimaryBUS != null && c2w.PrimaryBUS != bus
                        if (customPort.Name.Contains("port1"))
                        {
                            single3PhaseLine.FromBus = bus;
                        }
                        else //if ((c2w.SecondaryBUS == null && c2w.PrimaryBUS != null || c2w.SecondaryBUS != null && c2w.SecondaryBUS != bus))
                        {
                            single3PhaseLine.ToBus = bus;
                        }
                    }
                }
            }
            

        }

        public static string WireEnd(NodeViewModel item) {
            var temp = "";
            if (item is Shapes.generator.GenShape)
            {
                temp = (item as Shapes.generator.GenShape).GeneratorItem.Name;
            }
            else if (item is Shapes.generator.SyncGenShape)
            {
                temp = (item as Shapes.generator.SyncGenShape).GetSyncGen().Name;
            }
            else if (item is Shapes.generator.PVGenShape)
            {
                temp = (item as Shapes.generator.PVGenShape).PVGeneratorItem.Name;
            }
            else if (item is Shapes.generator.WindGenShape) 
            {
                temp = (item as Shapes.generator.WindGenShape).getWindGen().Name;
            }
            else if (item is Shapes.Load.LoadShape) 
            {
                temp = (item as Shapes.Load.LoadShape).getLoad().Name;
            }
            else if (item is Shapes.Load.EVShape) 
            {
                temp = (item as Shapes.Load.EVShape).getEV().Name;
            }
            else if (item is Shapes.RLC.AbstractRLCCShape)
            {
                temp = (item as Shapes.RLC.AbstractRLCCShape).getRLCBranch().name;
            }
            else if (item is Shapes.Transformer.C2WTShape)
            {
                temp = (item as Shapes.Transformer.C2WTShape).getTransformerType().name;
            }
            else if (item is Shapes.Transformer.CustomC3WShape)
            {
                temp = (item as Shapes.Transformer.CustomC3WShape).getTransformerType().name;
            }
            else if (item is Shapes.Line.DoubleCircuitShape)
            {
                temp = (item as Shapes.Line.DoubleCircuitShape).DoubleCircuitLineItem.Name;
            }
            else if (item is Shapes.Line.MphaseShape)
            {
                temp = (item as Shapes.Line.MphaseShape).GetMMltiPhaseLine().Name;
            }
            else if (item is Shapes.Line.Singleline3phaseShape)
            {
                temp = (item as Shapes.Line.Singleline3phaseShape).GetSingle3PhaseLine().Name;
            }


            return temp;
        }

        private static void checkAndPront(string name, string component)
        {
            var description = long.TryParse(name, out _) ? (component + " " + name) : name;
        }

    }
}
