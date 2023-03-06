using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BL;
using persistent;
using Syncfusion.Windows.Forms.Tools.XPMenus;
using Syncfusion.WinForms.Controls;
using GUI.New_concept_WPF;
using Syncfusion.UI.Xaml.Diagram;
using Syncfusion.UI.Xaml.Diagram;
using Syncfusion.UI.Xaml.Diagram.Controls;
using Syncfusion.UI.Xaml.TreeView.Engine;
using Syncfusion.UI.Xaml.Diagram.Utility;
using GUI.Line;
using Syncfusion.Windows.Forms.Tools.Navigation;
using Syncfusion.UI.Xaml.Diagram.Controls;
using Syncfusion.Windows.Tools.Controls;
using persistent.common;
using GUI.DataAccess;
using GUI.New_concept_WPF.Utility;
using network.generator.Gentype;
using GUI.generator;
using Shapes.generator;
using network;
using Shapes.Line;
using persistent.network.load_entitiy;
using GUI.bus;
using GUI.Transformer;
using persistent.network;
using GUI.New_concept_WPF.Custom_Controls.CustomPort;
using System.IO;
using GUI.FileController;
using areaandzone;
using GUI.Substation;
using GUI.Geo_Zone;
using BL.Calculation_Core.Calculation_Class.Calculat_runpfmethod.Test;
using BL.Calculation_Core.Transform_Function;
using persistent.enumeration;

namespace GUI
{
    public partial class Main_Menu : SfForm
    {
        //Case-related variables that are used to create and manage case instances
        private Case cases = null;
        private CaseBL caseBL = null;
        //Static variables that are employed to transmit information from and to ToolDiagram_Form
        private static bool isNew = false;
        private static bool isTreeDoubleClicked = false;
        private DiagramControl baseDiagram = null;
        public static CustomDiagram currentDiagram = null;
        private static NodeViewModel clickedDiagramNode = null;
        private static CoreConnector clickedDiagramBus = null;
        private static CoreConnector clickedDiagramWire = null;
        //Inner variables used to pass information from and to MainMenu's functions
        private ItemEnum shapeToBeCreated;
        private NodeViewModel nodeGeneral = null;

        public Main_Menu()
        {
            InitializeComponent();
            CalculatorTester cal = new CalculatorTester();
            this.Style.InactiveBorder = new Pen(Color.LightGray, 2);
            this.Style.Border = new Pen(Color.SkyBlue, 2);
            cal.TestMethod1();
            this.Text = "GMDSimulator" + " [" + DateTime.Today.ToString("d") + "] ";
            //Panel panelBase = new Panel();
            //setMainToolbar(ref panelBase);
            //this.DropShadow = true;
            //this.Text = 
            //this.BorderThickness = 5;
            //this.BorderColor = Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(158)))), ((int)(((byte)(218)))));
            //this.CaptionBarColor = Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(158)))), ((int)(((byte)(218)))));
            //this.CaptionButtonColor = System.Drawing.Color.White;
            //this.CaptionBarHeight = 20;
            //this.CaptionButtonHoverColor = Color.Blue;
            TreeNodeCreator treeNodeCreator = new TreeNodeCreator();
            treeNodeCreator.init();
            this.Quick_New.Click += Quick_new_Click;
            this.Network_ModelExplorer.Click += ModelExplorer_Click;
            this.VerticalBus.Click += VerticalBus_Click;
            this.HorizontalBus.Click += HorizontalBus_Click;
            this.Matpower.Click += Matpower_Click;
            this.PSSE.Click += PSSE_Click;
            

        }

      

        ////getIsNew() and setIsNew() allows to communicate to other functions and forms if a 
        internal static bool getIsNew()
        {
            return isNew;
        }

        internal static void setIsNew(bool isnew)
        {
            isNew = isnew;
        }

        /*  internal static bool getIsTreeDoubleClicked()
          {
              return isTreeDoubleClicked;
          }

          internal static void setIsTreeDoubleClicked(bool isActive)
          {
              isTreeDoubleClicked = isActive;
          }*/

        internal static void SetCurrentDiagram(CustomDiagram diagram) {
            Main_Menu.currentDiagram = diagram;
        }

        internal static CustomDiagram GetCurrentDiagram()
        {
            return Main_Menu.currentDiagram as CustomDiagram;
        }

        private void ModelExplorer_Click(object sender, EventArgs e) 
      {
            this.IsMdiContainer = true;
            if (CustomContentControl.getCurrentCase() != null)
            {
                ModelExplorer ModelForm = new ModelExplorer();
           
                ModelForm.Show();
            }
            else
            {
                string caption = "Database error message";
                MessageBox.Show("A case must be opened to access its data", caption);

            }

        }

        private void Matpower_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            if (CustomContentControl.getCurrentCase() != null)
            {
                CustomContentControl.setTypeOfInput(TypeOfInput.Matlab);
                FileBrowser PSSEfileUploaderDialog = new FileBrowser(FileType.MatPower);
                PSSEfileUploaderDialog.ShowDialog();

                //fileBrowser.Show();
            }
            else
            {
                string caption = "Database error message";
                MessageBox.Show("A case must be opened to access its data", caption);

            }

        }
        private void PSSE_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            if (CustomContentControl.getCurrentCase() != null)
            {
                CustomContentControl.setTypeOfInput(TypeOfInput.Psse);
                FileBrowser PSSEfileUploaderDialog = new FileBrowser(FileType.PSSE);
                PSSEfileUploaderDialog.ShowDialog();

                //fileBrowser.Show();
            }
            else
            {
                string caption = "Database error message";
                MessageBox.Show("A case must be opened to access its data", caption);

            }
        }
        private void Quick_new_Click(object sender, EventArgs e)
        {
            caseBL = new CaseBL();
            Case c = caseBL.addCase();
            setCase(c);

            if (!getIsNew())
            {
                setIsNew(true);
                baseDiagram = new DiagramControl();
                this.elementHost1.Child = baseDiagram;
               
            }
            CustomContentControl Child = new CustomContentControl(c);
            CustomContentControl.setCurrentCase(c);
            CustomDiagram diagram = new CustomDiagram()
            {
                Nodes = new NodeCollection(),
                Connectors = new ConnectorCollection(),
            };
            diagram.SingleSelectionMode = SingleSelectionMode.Select;
            diagram.Connectors = new ObservableCollection<CoreConnector>();
            diagram.Constraints = GraphConstraints.Default;
            create_contextMenuContent(diagram);
            diagram.SnapSettings = new SnapSettings()
            {
                SnapConstraints = SnapConstraints.ShowLines,
            };
            SelectorViewModel quickCommand = (diagram.SelectedItems as SelectorViewModel);
            quickCommand.SelectorConstraints = quickCommand.SelectorConstraints & ~SelectorConstraints.QuickCommands & ~SelectorConstraints.Rotator & SelectorConstraints.None;
            (diagram.Info as IGraphInfo).DragEnter += Diagram_DragEnter;
            (diagram.Info as IGraphInfo).DragOver += Main_Menu_DragOver;
            //diagram.PreviewKeyDown += Diagram_PreviewKeyDown;
            diagram.PreviewMouseUp += Diagram_PreviewMouseUp;
            diagram.KeyDown += Diagram_KeyDown;
            (diagram.Info as IGraphInfo).MenuItemClickedEvent += MainMenu_MenuItemClickedEvent;
            //Add Node to Nodes property of the Diagram
            (diagram.Info as IGraphInfo).ItemAdded += Main_Menu_ItemAdded; ;
            (diagram.Info as IGraphInfo).ItemDoubleTappedEvent += Main_Menu_ItemDoubleTappedEvent;
            
            (diagram.Info as IGraphInfo).ItemTappedEvent += MainMenu_ItemTappedEvent;
          //  (diagram.Info as IGraphInfo).ItemTappedEvent += test;
            //(diagram.Info as IGraphInfo).ItemDeletingEvent += Main_Menu_ItemDeletingEvent;
            (diagram.Info as IGraphInfo).AnnotationChanged += Main_Menu_AnnotationChanged;
            currentDiagram = diagram;
            Child.Content = diagram;
            DockingManager.SetState(Child, Syncfusion.Windows.Tools.Controls.DockState.Document);
            DockingManager.SetHeader(Child, Child.getCase().name);
            baseDiagram.dockingManager.Children.Add(Child);
            TDILayoutPanel.SetTDIIndex(Child, baseDiagram.dockingManager.Children.Count - 1);
            
        }

       

        private void Main_Menu_AnnotationChanged(object sender, ChangeEventArgs<object, AnnotationChangedEventArgs> args)
        {
            if (args.Item is CoreConnector)
            {
                // To Cancel Annotation editing
                args.Cancel = true;
            }
        }

        public static string address = AppDomain.CurrentDomain.BaseDirectory + @"\abcfile.xml";
        
        private void SaveDiagram()
        {
            //The save function seems to be working. However, the output is not loadedby the system.
            //I ensured that the load and save functions does not run unless the/a diagram was instantiated
            //and that it is currently selected.
            //the load functions trigger a NullException but its origen is not clear at all.
            if (getIsNew())
            {
                if (GetCurrentDiagram() != null)
                {
                    Microsoft.Win32.SaveFileDialog dialog = new Microsoft.Win32.SaveFileDialog();
                    if (dialog.ShowDialog() == true)
                    {
                        using (Stream test1 = System.IO.File.Open(dialog.FileName, FileMode.Create))
                        {
                            GetCurrentDiagram().Save(test1);
                        }
                    }
                }
            }

            //To Save as memory stream
            /*   MemoryStream str = new MemoryStream();
               GetCurrentDiagram().Save(str);*/



            /*  FileStream fileStream = new FileStream(address, FileMode.Create, FileAccess.Write);
              currentDiagram.Save(fileStream);*/
        }
        private void LoadDiagram()
        {
            if (getIsNew())
            {
                if (GetCurrentDiagram() != null)
                {
                    //assemblies variables is declared, but it is not used at all. I do not understand
                    //why that line was required by Syncfusion Dev team!
                    var assemblies = AppDomain.CurrentDomain.GetAssemblies();

                    Microsoft.Win32.OpenFileDialog dialog = new Microsoft.Win32.OpenFileDialog();
                    if (dialog.ShowDialog() == true)
                    {
                        try
                        {
                            using (Stream myStream = dialog.OpenFile())
                            {
                                myStream.Position = 0;
                                SfDiagram diagram = GetCurrentDiagram();
                                //diagram.Load throws an exception. It is not caught by the try-catch block
                                diagram.Load(myStream);
                            }
                           
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("An Error occurred during the loading process" + ex.InnerException.ToString());
                        }
                    }
                }
            }

            //Load from saved memory stream

        }

         

        


        private void Main_Menu_DragOver(object sender, ItemDropEventArgs args)
        {
            if (args.Target != null && (!(args.Target is SfDiagram)) && args.Source is NodeViewModel)
            {
                System.Diagnostics.Debug.WriteLine("here");
                if (args.Target is IEnumerable<object>)
                {
                    System.Diagnostics.Debug.WriteLine("here2");
                    foreach (object obj in (args.Target as IEnumerable<object>))
                    {
                        if (obj is CoreConnector)
                        {
                            System.Diagnostics.Debug.WriteLine("here3");
                            CoreConnector oldcon = obj as CoreConnector;

                            CoreConnector newcon = new CoreConnector()
                            {
                                SourcePort = args.Source as CustomPort,
                                TargetPort = oldcon.TargetPort,
                            };
                            (currentDiagram.Connectors as ObservableCollection<CoreConnector>).Add(newcon);
                            //(currentDiagram.Connectors as ConnectorCollection).Add(newcon);

                            oldcon.TargetPort = args.Source as CustomPort;
                        }
                    }
                }
            }
        }

        private void Main_Menu_ItemDoubleTappedEvent(object sender, DiagramEventArgs args)
        {
            if (args.Item is NodeViewModel)
            {
                if (args.Item is Shapes.generator.GenShape)
                {
                    Shapes.generator.GenShape genShape = (Shapes.generator.GenShape)args.Item;
                    Generator generator = genShape.GeneratorItem;
                    Generator_Main generator_main = new Generator_Main(generator);
                    generator_main.ShowDialog();
                    
                    genShape.updateStatus(generator_main.getGenerator().Inservice);
                }


                else if (args.Item is Shapes.generator.PVGenShape)
                {
                    Shapes.generator.PVGenShape pvGenShape = (Shapes.generator.PVGenShape)args.Item;
                    PVGen pvGen = pvGenShape.PVGeneratorItem;
                    PV_Main pv_Main = new PV_Main(pvGen);
                    pv_Main.ShowDialog();

                    pvGenShape.updateStatus(pv_Main.getPVGen().Inservice);
                }

                else if (args.Item is Shapes.generator.SyncGenShape)
                {
                    Shapes.generator.SyncGenShape synGenShape = (Shapes.generator.SyncGenShape)args.Item;
                    SyncGen syncGen = synGenShape.SyncGenerator;
                    SyncGen_main syncGen_Main = new SyncGen_main(syncGen);
                    syncGen_Main.ShowDialog();
                    synGenShape.UpdateStatus(syncGen_Main.getSyncGen().Inservice);
                }

                else if (args.Item is Shapes.generator.WindGenShape)
                {
                    Shapes.generator.WindGenShape windGenShape = ((Shapes.generator.WindGenShape)args.Item);
                    WindGen windGen = windGenShape.WindGenerator;
                    WindGenerator_Main windGenerator_Main = new WindGenerator_Main(windGen);
                    windGenerator_Main.ShowDialog();
                }
                else if (args.Item is Shapes.Load.LoadShape)
                {
                    Shapes.Load.LoadShape loadShape = (Shapes.Load.LoadShape)args.Item;
                    Loads loads = loadShape.getLoad();
                    GUI.Load.Load_Main load_Main = new GUI.Load.Load_Main(loads);
                    load_Main.ShowDialog();
                }
                else if (args.Item is Shapes.Load.EVShape)
                {
                    Shapes.Load.EVShape evShape = (Shapes.Load.EVShape)args.Item;
                    EV evs = evShape.getEV();
                    GUI.Load.EV_Main ev_Main = new GUI.Load.EV_Main(evs);
                    ev_Main.ShowDialog();
                }
                else if (args.Item is Shapes.Line.LineShape)
                {

                    Shapes.Line.LineShape lineShape = (Shapes.Line.LineShape)args.Item;
                    Single3phaseLine lines = lineShape.GetLine();
                    GUI.Line.Single3PhaseLine_main line_Main = new GUI.Line.Single3PhaseLine_main(lines);
                    line_Main.ShowDialog();
                }
                else if (args.Item is Shapes.Line.Singleline3phaseShape)
                {

                    Shapes.Line.Singleline3phaseShape singlineShape = (Shapes.Line.Singleline3phaseShape)args.Item;
                    Single3phaseLine lines = singlineShape.GetSingle3PhaseLine();
                    GUI.Line.Single3PhaseLine_main line_Main = new GUI.Line.Single3PhaseLine_main(lines);
                    line_Main.ShowDialog();
                }
                else if (args.Item is Shapes.Line.DoubleCircuitShape)
                {

                    Shapes.Line.DoubleCircuitShape doublineShape = (Shapes.Line.DoubleCircuitShape)args.Item;
                    DoubleCircuitLine lines = doublineShape.DoubleCircuitLineItem;
                    GUI.Line.Doublecircuit_main line_Main = new GUI.Line.Doublecircuit_main(lines);
                    line_Main.ShowDialog();
                }
                else if (args.Item is Shapes.Line.MphaseShape)
                {

                    Shapes.Line.MphaseShape lineShape = (Shapes.Line.MphaseShape)args.Item;
                    MultiPhaseLine lines = lineShape.GetMMltiPhaseLine();
                    GUI.Line.Mphase_main line_Main = new GUI.Line.Mphase_main(lines);
                    line_Main.ShowDialog();
                }
                else if (args.Item is Shapes.Transformer.C2WTShape)
                {

                    Shapes.Transformer.C2WTShape c2shape = (Shapes.Transformer.C2WTShape)args.Item;
                    C2WTransformer twowinding = (C2WTransformer)c2shape.getTransformerType();
                    GUI.Transformer.Main2WTransformerMenu twowind = new GUI.Transformer.Main2WTransformerMenu(twowinding);
                    twowind.ShowDialog();
                }
                else if (args.Item is Shapes.Transformer.CustomC3WShape)
                {

                    try
                    {
                        Shapes.Transformer.CustomC3WShape c3shape = (Shapes.Transformer.CustomC3WShape)args.Item;
                        C3WTransformer threewinding = (C3WTransformer)c3shape.getTransformerType();
                        GUI.Transformer.Main3WTransformerMenu threewind = new GUI.Transformer.Main3WTransformerMenu(threewinding);
                        threewind.ShowDialog();
                    }
                    catch (Exception err)
                    {
                        var e = err.ToString();
                    }
                }
                else if (args.Item is Shapes.RLC.RLCShape)
                {

                    Shapes.RLC.RLCShape rlcshape = (Shapes.RLC.RLCShape)args.Item;
                    RLC rlc = (RLC)rlcshape.getRLCBranch();
                    GUI.Rlc.RLC_Main rlc_main = new GUI.Rlc.RLC_Main(rlc);
                    rlc_main.ShowDialog();

                }
                else if (args.Item is Shapes.RLC.CShape)
                {

                    Shapes.RLC.CShape cshape = (Shapes.RLC.CShape)args.Item;
                    C c = (C)cshape.getRLCBranch();
                    GUI.Rlc.RLC_Main c_main = new GUI.Rlc.RLC_Main(c);
                    c_main.ShowDialog();

                }
                else if (args.Item is Shapes.RLC.LShape)
                {

                    Shapes.RLC.LShape lshape = (Shapes.RLC.LShape)args.Item;
                    L l = (L)lshape.getRLCBranch();
                    GUI.Rlc.RLC_Main l_main = new GUI.Rlc.RLC_Main(l);
                    l_main.ShowDialog();
                }
                else if (args.Item is Shapes.RLC.RShape)
                {

                    Shapes.RLC.RShape rshape = (Shapes.RLC.RShape)args.Item;
                    R r = (R)rshape.getRLCBranch();
                    GUI.Rlc.RLC_Main r_main = new GUI.Rlc.RLC_Main(r);
                    r_main.ShowDialog();
                }
                else if (args.Item is Shapes.RLC.LCShape)
                {

                    Shapes.RLC.LCShape lcshape = (Shapes.RLC.LCShape)args.Item;
                    LC lc = (LC)lcshape.getRLCBranch();
                    GUI.Rlc.RLC_Main lc_main = new GUI.Rlc.RLC_Main(lc);
                    lc_main.ShowDialog();

                }
                else if (args.Item is Shapes.RLC.RLShape)
                {

                    Shapes.RLC.RLShape lshape = (Shapes.RLC.RLShape)args.Item;
                    RL rl = (RL)lshape.getRLCBranch();
                    GUI.Rlc.RLC_Main rl_main = new GUI.Rlc.RLC_Main(rl);
                    rl_main.ShowDialog();
                }





            }

            if (args.Item is CoreConnector)
            {
                if ((args.Item as CoreConnector).Name.Contains("Bus"))
                {
                    CoreConnector corbus = (CoreConnector)args.Item;
                    Bus bus = corbus.getBus();
                    Bus_Main bus_main = new Bus_Main(bus);
                    bus_main.ShowDialog();
                }
                else {
                    CoreConnector corbus = (CoreConnector)args.Item;
                    persistent.network.wire.Wire wire = corbus.getWire();
                    WireMain.Wire_Main wireMain = new WireMain.Wire_Main(wire);
                    wireMain.ShowDialog();
                }

            }
        }

        private void Main_Menu_ItemAdded(object sender, ItemAddedEventArgs args)
        {
            if (args.Item is Shapes.IDiagramShape shape)
            {
                shape.Init(args.ItemSource == ItemSource.Load);
            }

            if (args.ItemSource == ItemSource.Load || args.ItemSource == ItemSource.ClipBoard)
            {
                if (args.Item is CoreConnector coreConnector && coreConnector.Type == "Bus")
                {
                    Utils.conSelector(args);
                }
            }
            else if (args.Item is CoreConnector && isBus)
            {
                CoreConnector connector = args.Item as CoreConnector;
                connector.isBusConnector = true;
                Utils.conSelector(args);
                connector.Constraints = connector.Constraints.Remove(ConnectorConstraints.InheritAutomaticPortCreation);
                connector.Constraints = connector.Constraints.Add(ConnectorConstraints.AutomaticPortCreation);
            }
        }

        private void Diagram_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Escape)
            {
                Main_Menu.currentDiagram.DefaultConnectorType = ConnectorType.Orthogonal;
                if (Main_Menu.GetIsTreeDoubleClicked())
                {
                    cleanShapesAndFunctions();
                }
            }
        }

        //getCase() and setCase() returns and sets the current case, respectively.
        private Case getCase()
        {
            return cases;
        }
        private void setCase(Case cases)
        {
            this.cases = cases;
        }

        private void Diagram_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            MessageBox.Show("here");
            if (e.Key == System.Windows.Input.Key.Escape)
            {
                //MainMenu.currentDiagram.DefaultConnectorType = ConnectorType.Orthogonal;
                if (Main_Menu.GetIsTreeDoubleClicked())
                {
                    cleanShapesAndFunctions();
                }
            }
        }

        private void cleanShapesAndFunctions()
        {
            Main_Menu.setIsTreeDoubleClicked(false);
            DiagramControl.setIslockedNode(false);
            shapeToBeCreated = ItemEnum.None;
            DiagramControl.setClickedNode(shapeToBeCreated);
            currentDiagram.SingleSelectionMode = SingleSelectionMode.Select;
            //currentDiagram.MultipleSelectionMode = MultipleSelectionMode.
            currentDiagram.Tool = Tool.None;
            currentDiagram.Tool = Tool.MultipleSelect;
            currentDiagram.DrawingTool = DrawingTool.Connector;
            currentDiagram.DefaultConnectorType = ConnectorType.Orthogonal;

        }
     
        private void create_contextMenuContent(CustomDiagram d)
        {
            IGraphInfo graphinfo = d.Info as IGraphInfo;
            graphinfo.MenuItemClickedEvent += MainMenu_MenuItemClickedEvent;
            DiagramMenuItem menu1 = new DiagramMenuItem()
            {
                Content = "Delete",
                Command = graphinfo.Commands.Delete,
                

            };
            d.Menu.MenuItems.Add(menu1);
            DiagramMenuItem menu2 = new DiagramMenuItem()
            {
                Content = "Properties...",

            };
            d.Menu.MenuItems.Add(menu2);
            DiagramMenuItem menu3 = new DiagramMenuItem()
            {
                Content = "Name",
            };
            d.Menu.MenuItems.Add(menu3);
            DiagramMenuItem menu4 = new DiagramMenuItem()
            {
                Content = "Rotation",
            };
            DiagramMenuItem rotA = new DiagramMenuItem()
            {
                Content = "Rotation 0º",
                Command = graphinfo.Commands.Rotate,
                CommandParameter = new RotateParameter()
                {
                    RotationDirection = Syncfusion.UI.Xaml.Diagram.RotationDirection.Clockwise,
                    Angle = 0
                }
            };
            DiagramMenuItem rotB = new DiagramMenuItem()
            {
                Content = "Rotation 90º",
                Command = graphinfo.Commands.Rotate,
                CommandParameter = new RotateParameter()
                {
                    RotationDirection = Syncfusion.UI.Xaml.Diagram.RotationDirection.Clockwise,
                    Angle = 90
                }
            };
            DiagramMenuItem rotC = new DiagramMenuItem()
            {
                Content = "Rotation 180º",
                Command = graphinfo.Commands.Rotate,
                CommandParameter = new RotateParameter()
                {
                    RotationDirection = Syncfusion.UI.Xaml.Diagram.RotationDirection.Clockwise,
                    Angle = 180
                }
            };
            DiagramMenuItem rotD = new DiagramMenuItem()
            {
                Content = "Rotation 270º",
                Command = graphinfo.Commands.Rotate,
                CommandParameter = new RotateParameter()
                {
                    RotationDirection = Syncfusion.UI.Xaml.Diagram.RotationDirection.Clockwise,
                    Angle = 270
                }
            };
            menu4.Items = new System.Collections.ObjectModel.ObservableCollection<DiagramMenuItem>();
            menu4.Items.Add(rotA);
            menu4.Items.Add(rotB);
            menu4.Items.Add(rotC);
            menu4.Items.Add(rotD);
            d.Menu.MenuItems.Add(menu4);
        }

        private void MainMenu_MenuItemClickedEvent(object sender, MenuItemClickedEventArgs args)
        {

            if (args.Item.Content.Equals("Name"))
            {
                if (clickedDiagramNode is NodeViewModel)
                {
                    New_concept_WPF.Utility.Utils.blConnection_WPF(clickedDiagramNode, "Name");
                    clickedDiagramNode.IsSelected = false;
                    clickedDiagramNode = null;

                    //currentDiagram.SelectedItems = null;
                }
            }
            else if (args.Item.Content.Equals("Properties..."))
            {

                if (clickedDiagramNode is NodeViewModel)
                {
                    //System.Diagnostics.Debug.WriteLine(clickedDiagramNode);
                    setNode(clickedDiagramNode);
                    New_concept_WPF.Utility.Utils.blConnection_WPF(clickedDiagramNode);
                    setNode(null);
                    clickedDiagramNode.IsSelected = false;
                    clickedDiagramNode = null;
                }
                if (clickedDiagramBus != null && clickedDiagramBus is CoreConnector)
                {
                    Utils.blConn_WPF(clickedDiagramBus);
                    clickedDiagramBus.IsSelected = false;
                    clickedDiagramBus = null;
                }
                else if (clickedDiagramWire != null && clickedDiagramWire is CoreConnector)
                {
                    Utils.blConn_WPF(clickedDiagramWire, 1);
                    clickedDiagramWire.IsSelected = false;
                    clickedDiagramWire = null;
                }

            } else if (args.Item.Content.Equals("Delete"))
            {
                if (clickedDiagramNode is NodeViewModel)
                {
                    
                    setNode(clickedDiagramNode);
                    New_concept_WPF.Utility.Utils.blConnection_WPF(clickedDiagramNode, "Delete");
                    setNode(null);
                    clickedDiagramNode.IsSelected = false;
                    clickedDiagramNode = null;
                }

            }
        }

        private void setMainToolbar(ref Panel panel) {
            
            XPToolBar MainXpToolBar = new XPToolBar();
            BarItem file = new BarItem() {
                Text = "File"
            };
            ParentBarItem edit = new ParentBarItem() { 
                Text = "Edit",
               
            };
            MainXpToolBar.Bar.Items.AddRange(new BarItem[] { file, edit, });
            panel.Controls.Add(MainXpToolBar);
            this.Controls.Add(panel);
        }



        private void Diagram_DragEnter(object sender, ItemDropEventArgs args)
        {
            
            // args.Source have the data which is dragged for drop.
            if (args.Source is System.Windows.DataObject)
            {
                object dataObject = (args.Source as System.Windows.DataObject).GetData(typeof(DragObject<TreeViewNode>));
                TreeViewNode treeViewItem = (dataObject as DragObject<TreeViewNode>).Source;

                if (ItemEnum.Generator.Equals(((GUI.New_concept_WPF.TreeNodeWPF)treeViewItem.Content).EnumItem))
                {
                    NodeViewModel temp = new Shapes.generator.GenShape();
                    args.Source = temp;
                    clickedDiagramNode = temp;
                }
                else if (ItemEnum.Singleline3phase.Equals(((GUI.New_concept_WPF.TreeNodeWPF)treeViewItem.Content).EnumItem))
                {
                    NodeViewModel temp = new Shapes.Line.Singleline3phaseShape();
                    args.Source = temp;
                    clickedDiagramNode = temp;
                }
                else if (ItemEnum.DoubleCircuit.Equals(((GUI.New_concept_WPF.TreeNodeWPF)treeViewItem.Content).EnumItem))
                {
                    NodeViewModel temp = new Shapes.Line.DoubleCircuitShape();
                    args.Source = temp;
                    clickedDiagramNode = temp;
                }
                else if (ItemEnum.MPhase.Equals(((GUI.New_concept_WPF.TreeNodeWPF)treeViewItem.Content).EnumItem))
                {
                    NodeViewModel temp = new Shapes.Line.MphaseShape();
                    args.Source = temp;
                    clickedDiagramNode = temp;
                }
                else if ((ItemEnum.Line.Equals(((GUI.New_concept_WPF.TreeNodeWPF)treeViewItem.Content).ElementName))) 
                { 
                    NodeViewModel temp = new Shapes.Line.LineShape();
                    args.Source = temp;
                    clickedDiagramNode = temp;
                }
                else if ((ItemEnum.Triphasic.Equals(((GUI.New_concept_WPF.TreeNodeWPF)treeViewItem.Content).EnumItem)))
                {
                    NodeViewModel temp = new Shapes.Transformer.TriTShape();
                    args.Source = temp;
                    clickedDiagramNode = temp;
                }
                else if ((ItemEnum.YgDD.Equals(((GUI.New_concept_WPF.TreeNodeWPF)treeViewItem.Content).EnumItem)))
                {
                    NodeViewModel temp = new Shapes.Transformer.YgDDTShape();
                    args.Source = temp;
                    clickedDiagramNode = temp;
                }
                else if ((ItemEnum.YgYgD.Equals(((GUI.New_concept_WPF.TreeNodeWPF)treeViewItem.Content).EnumItem)))
                {
                    NodeViewModel temp = new Shapes.Transformer.YgYgDTShape();
                    args.Source = temp;
                    clickedDiagramNode = temp;
                }
                else if ((ItemEnum.Custom3wT.Equals(((GUI.New_concept_WPF.TreeNodeWPF)treeViewItem.Content).EnumItem)))
                {
                    NodeViewModel temp = new Shapes.Transformer.CustomC3WShape(); 
                    args.Source = temp;
                    clickedDiagramNode = temp;
                }
                else if ((ItemEnum.C2WindingThransformer.Equals(((GUI.New_concept_WPF.TreeNodeWPF)treeViewItem.Content).EnumItem)))
                {
                    NodeViewModel temp = new Shapes.Transformer.C2WTShape();
                    args.Source = temp;
                    clickedDiagramNode = temp;
                }
                else if ((ItemEnum.YgD.Equals(((GUI.New_concept_WPF.TreeNodeWPF)treeViewItem.Content).EnumItem)))
                {
                    NodeViewModel temp = new Shapes.Transformer.YgDTShape();
                    args.Source = temp;
                    clickedDiagramNode = temp;
                }
                else if ((ItemEnum.Load.Equals(((GUI.New_concept_WPF.TreeNodeWPF)treeViewItem.Content).EnumItem)))
                {
                    NodeViewModel temp = new Shapes.Load.LoadShape();
                    args.Source = temp;
                    clickedDiagramNode = temp;
                }
                else if ((ItemEnum.C.Equals(((GUI.New_concept_WPF.TreeNodeWPF)treeViewItem.Content).EnumItem)))
                {
                    NodeViewModel temp = new Shapes.RLC.CShape();
                    args.Source = temp;
                    clickedDiagramNode = temp;
                }
                else if ((ItemEnum.L.Equals(((GUI.New_concept_WPF.TreeNodeWPF)treeViewItem.Content).EnumItem)))
                {
                    NodeViewModel temp = new Shapes.RLC.LShape();
                    args.Source = temp;
                    clickedDiagramNode = temp;
                }
                else if ((ItemEnum.R.Equals(((GUI.New_concept_WPF.TreeNodeWPF)treeViewItem.Content).EnumItem)))
                {
                    NodeViewModel temp = new Shapes.RLC.RShape();
                    args.Source = temp;
                    clickedDiagramNode = temp;
                }
                else if ((ItemEnum.LC.Equals(((GUI.New_concept_WPF.TreeNodeWPF)treeViewItem.Content).EnumItem)))
                {
                    NodeViewModel temp = new Shapes.RLC.LCShape();
                    args.Source = temp;
                    clickedDiagramNode = temp;
                }
                else if ((ItemEnum.RL.Equals(((GUI.New_concept_WPF.TreeNodeWPF)treeViewItem.Content).EnumItem)))
                {
                    NodeViewModel temp = new Shapes.RLC.RLShape();
                    args.Source = temp;
                    clickedDiagramNode = temp;
                }
                else if ((ItemEnum.RLC.Equals(((GUI.New_concept_WPF.TreeNodeWPF)treeViewItem.Content).EnumItem)))
                {
                    NodeViewModel temp = new Shapes.RLC.RLCShape();
                    args.Source = temp;
                    clickedDiagramNode = temp;
                }
                else if ((ItemEnum.SyncGen.Equals(((GUI.New_concept_WPF.TreeNodeWPF)treeViewItem.Content).EnumItem)))
                {
                    NodeViewModel temp = new Shapes.generator.SyncGenShape();
                    args.Source = temp;
                    clickedDiagramNode = temp;
                }
                else if ((ItemEnum.Wind.Equals(((GUI.New_concept_WPF.TreeNodeWPF)treeViewItem.Content).EnumItem)))
                {
                    NodeViewModel temp = new Shapes.generator.WindGenShape();
                    args.Source = temp;
                    clickedDiagramNode = temp;
                }
                else if (ItemEnum.EvMachine.Equals(((GUI.New_concept_WPF.TreeNodeWPF)treeViewItem.Content).EnumItem))
                {
                    NodeViewModel temp = new Shapes.Load.EVShape();
                    args.Source = temp;
                    clickedDiagramNode = temp;
                }
                else if ((ItemEnum.PVPnels.Equals(((GUI.New_concept_WPF.TreeNodeWPF)treeViewItem.Content).EnumItem)))
                {
                    NodeViewModel temp = new Shapes.generator.PVGenShape();
                    args.Source = temp;
                    clickedDiagramNode = temp;
                }

                else if ((ItemEnum.Substation.Equals(((GUI.New_concept_WPF.TreeNodeWPF)treeViewItem.Content).EnumItem)))
                {
                    SubstationForm temp = new SubstationForm();
                   temp.ShowDialog();
                }
            }
        }


        private void MainMenu_ItemTappedEvent(object sender, DiagramEventArgs args)
        {
            if (CustomContentControl.getCurrentCase() != null)
            {
                if (args.Item is CustomDiagram)
                {
                    shapeToBeCreated = DiagramControl.getClickedNode();
                    if (!shapeToBeCreated.Equals(ItemEnum.None))
                    {
                        setNode(New_concept_WPF.Utility.Utils.node_selector(shapeToBeCreated));
                        if (!GetIsTreeDoubleClicked())
                        {
                            if (DiagramControl.getIslockedNode())
                            {
                                nodeCreation(System.Windows.Input.Mouse.GetPosition(currentDiagram));
                            }


                            DiagramControl.setClickedNode(ItemEnum.None);
                            DiagramControl.setIslockedNode(false);
                        }
                        else
                        {
                            nodeCreation(System.Windows.Input.Mouse.GetPosition(currentDiagram));
                        }
                    }
                }

                if (args.Item is NodeViewModel)
                {
                    // generators
                    if (args.Item is Shapes.generator.GenShape)
                    {
                        clickedDiagramNode = (Shapes.generator.GenShape)args.Item;
                    }
                    else if (args.Item is Shapes.generator.SyncGenShape)
                    {
                        clickedDiagramNode = (Shapes.generator.SyncGenShape)args.Item;
                    }
                    else if (args.Item is Shapes.generator.PVGenShape)
                    {
                        clickedDiagramNode = (Shapes.generator.PVGenShape)args.Item;
                    }
                    else if (args.Item is Shapes.generator.WindGenShape)
                    {
                        clickedDiagramNode = (Shapes.generator.WindGenShape)args.Item;
                    }
                    //RLC
                    else if (args.Item is Shapes.RLC.AbstractRLCCShape)
                    {
                        clickedDiagramNode = (Shapes.RLC.AbstractRLCCShape)args.Item;
                    }
                    //Transformers
                    else if (args.Item is Shapes.Transformer.AbstractTShape)
                    {
                        clickedDiagramNode = (Shapes.Transformer.AbstractTShape)args.Item;
                    }
                    //load
                    else if (args.Item is Shapes.Load.LoadShape)
                    {
                        clickedDiagramNode = (Shapes.Load.LoadShape)args.Item;
                    }
                        
                    else if (args.Item is Shapes.Load.EVShape)
                    {
                        clickedDiagramNode = (Shapes.Load.EVShape)args.Item;
                    }
                    // line
                    else if (args.Item is Shapes.Line.MphaseShape)
                    {
                        clickedDiagramNode = (Shapes.Line.MphaseShape)args.Item;
                    }
                    else if (args.Item is Shapes.Line.LineShape)
                    {
                        clickedDiagramNode = (Shapes.Line.LineShape)args.Item;
                    }
                    else if (args.Item is Shapes.Line.Singleline3phaseShape)
                    {
                        clickedDiagramNode = (Shapes.Line.Singleline3phaseShape)args.Item;
                    }
                    else if (args.Item is Shapes.Line.DoubleCircuitShape)
                    {
                        clickedDiagramNode = (Shapes.Line.DoubleCircuitShape)args.Item;
                    }
                }

                if (args.Item is CoreConnector) 
                {
                    clickedDiagramBus = null;
                    clickedDiagramWire = null;
                    if ((args.Item as CoreConnector).Name.Contains("Bus"))
                    {
                        clickedDiagramBus = (CoreConnector)args.Item;
                    }
                    else {
                        clickedDiagramWire = (CoreConnector)args.Item;
                    }

                
                }
               
            }
        }

        private NodeViewModel generalNode = null;
        private void nodeCreation(System.Windows.Point position)
        {
            try
            {
                generalNode = getNode();
                generalNode.OffsetX = position.X;
                generalNode.OffsetY = position.Y;
                (currentDiagram.Nodes as NodeCollection).Add(generalNode);
                setNode(null);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
          

        }
        internal NodeViewModel getNode()
        {
            return nodeGeneral;
        }
        internal void setNode(NodeViewModel node)
        {
            nodeGeneral = node;
        }

        internal static void SetClickedDiagramNode(NodeViewModel node)
        {
            clickedDiagramNode = node;
        }

        internal static NodeViewModel GetClickedDiagramNode()
        {
            return clickedDiagramNode;
        }

        internal static void SetClickedDiagramBus(CoreConnector bus)
        {
            clickedDiagramBus = bus;
        }

        internal static CoreConnector GetClickedDiagramBus()
        {
            return clickedDiagramBus;
        }

        internal static bool GetIsTreeDoubleClicked()
        {
            return isTreeDoubleClicked;
        }

        internal static void setIsTreeDoubleClicked(bool isActive)
        {
            isTreeDoubleClicked = isActive;
        }
    
        private void Main_Menu_Load(object sender, EventArgs e)
        {
            

        
        }

        private static bool isBus = false;
        //private SyncGenShape node;

        public static bool getIsBus() 
        {
            return isBus;
        }

        public static void setIsBus(bool isBus_) 
        {
            isBus = isBus_;
        }

        private void Network_Bus_Click(object sender, EventArgs e)
        {
            if (getIsNew())
            { 
                isBus = true;
                //Utils.conSelector();
                currentDiagram.Tool = Tool.ContinuesDraw;
                currentDiagram.DrawingTool = DrawingTool.Connector;
                currentDiagram.DefaultConnectorType = ConnectorType.Line;
            }
        }

        private void Diagram_PreviewMouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (isBus)
            {
                currentDiagram.SingleSelectionMode = SingleSelectionMode.Select;
                currentDiagram.Tool = Tool.MultipleSelect;
                currentDiagram.DrawingTool = DrawingTool.Connector;
                currentDiagram.DefaultConnectorType = ConnectorType.Orthogonal;
                isBus = false;
                currentDiagram.Vertical = false;
                currentDiagram.Horizontal = false;
            }
        }

        private void xpNetworkToolBar_Click(object sender, EventArgs e)
        {

        }

        private void Tool_Pan_Click(object sender, EventArgs e)
        {
           // currentDiagram.Tool = Tool.ZoomPan;
        }

        private void Network_Pan_Click(object sender, EventArgs e)
        {
            if (getIsNew())
            {
                currentDiagram.Tool = Tool.ZoomPan;
            }
        }

        private void Network_Pencil_Click(object sender, EventArgs e)
        {
            if (getIsNew())
            {
                currentDiagram.Tool = Tool.ContinuesDraw;
                currentDiagram.DrawingTool = DrawingTool.FreeHand;
            }
        }


        private void Network_Text_Click(object sender, EventArgs e)
        {
            if (getIsNew())
            {
                currentDiagram.DrawingTool = DrawingTool.TextNode;
                currentDiagram.Tool = Tool.ContinuesDraw;
            }
        }

        private void Network_SSelect_Click(object sender, EventArgs e)
        {
            if (getIsNew())
            {
                currentDiagram.Tool = Tool.SingleSelect;
            }
        }

        private void Network_MSelect_Click(object sender, EventArgs e)
        {
            if (getIsNew())
            {
                currentDiagram.Tool = Tool.MultipleSelect;
            }
        }

        private void Network_Connector_Click(object sender, EventArgs e)
        {
            if (getIsNew())
            {
                currentDiagram.DrawingTool = DrawingTool.Connector;
                currentDiagram.Tool = Tool.DrawOnce | Tool.MultipleSelect;
            }
        }

        private void Network_ModelExplorer_Click(object sender, EventArgs e)
        {
            if (getIsNew())
            {

            }
        }

        private void HorizontalBus_Click(object sender, EventArgs e)
        {
            if (getIsNew())
            {
                isBus = true;
                currentDiagram.Tool = Tool.ContinuesDraw;
                currentDiagram.DrawingTool = DrawingTool.Connector;
                currentDiagram.DefaultConnectorType = ConnectorType.Line;
                currentDiagram.Vertical = false;
                currentDiagram.Horizontal = true;
            }

        }

        private void VerticalBus_Click(object sender, EventArgs e)
        {
            if (getIsNew())
            {
                isBus = true;
                currentDiagram.Tool = Tool.ContinuesDraw;
                currentDiagram.DrawingTool = DrawingTool.Connector;
                currentDiagram.DefaultConnectorType = ConnectorType.Line;
                currentDiagram.Horizontal = false;
                currentDiagram.Vertical = true;
            }
        }

        private void Quick_Save_Click(object sender, EventArgs e)
        {

            SaveDiagram();


        }

        private void Quick_Open_Click(object sender, EventArgs e)
        {
            LoadDiagram();
        }

        private void Network_RunPF_Click(object sender, EventArgs e)
        {
            Vect_Fitting vect = new Vect_Fitting(cases, CustomContentControl.GetTypeOfInput());

        }

        private void Network_sub_Click(object sender, EventArgs e)
        {
            SubstationForm temp = new SubstationForm();
            
            temp.StartPosition = FormStartPosition.CenterParent;
            temp.ShowDialog();
        }

        private void Network_Geo_Zone_Click(object sender, EventArgs e)
        {
            if (getIsNew())
            {
                Geo_Zone_menu geo = new Geo_Zone_menu();
                geo.StartPosition = FormStartPosition.CenterParent;
                geo.ShowDialog();
            }
        }

        private void Network_Geo_Click(object sender, EventArgs e)
        {
            if (getIsNew())
            {
                Geo_Zone_Form_Create create_geo = new Geo_Zone_Form_Create();
                create_geo.StartPosition = FormStartPosition.CenterParent;
                create_geo.ShowDialog();
            }
        }
    }
}
