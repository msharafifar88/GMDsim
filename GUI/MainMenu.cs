/*using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Controls;
using Syncfusion.Windows.Tools.Controls;
using System.Data;
using System.Data.Odbc;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Telerik.WinControls.UI;
using System.Drawing.Printing;
using BL;
using GUI.New_concept;
using network;
using GUI.bus;
using persistent;
using System.Runtime.CompilerServices;
using GUI.generator;
using GUI.Load;
using GUI.contextMenu;
using GUI.New_concept_WPF;
using Syncfusion.UI.Xaml.Diagram;
using Syncfusion.UI.Xaml.TreeView.Engine;
using Syncfusion.UI.Xaml.Diagram.Utility;
using GUI.Line;
using Syncfusion.Windows.Forms.Tools.Navigation;
using Syncfusion.UI.Xaml.Diagram.Controls;
using GUI.New_concept_WPF.Utility;
using GUI.Transformer;
using GUI.FileController;
using GUI.DataAccess;
using persistent.common;

namespace GUI
{
    public partial class MainMenu : RadRibbonForm
    {
        //Static variables that are employed to transmit information from and to ToolDiagram_Form
        private static NodeViewModel nodeGeneral = null;
        private static bool isNew = false;
        private static bool isTreeDoubleClicked = false;
        //Case-related variables that are used to create and manage case instances
        private Case cases = null;
        private CaseBL caseBL = null;
        //Inner variables used to pass information from and to MainMenu's functions
        private ItemEnum shapeToBeCreated ;
        private System.Drawing.Point position { get; set; }
        private bool isNetworkOptionsOpen = false;

        public MainMenu()
        {
            InitializeComponent();
            //Subscribing new function 
            this.radRibbonBar1.CommandTabSelected += new CommandTabEventHandler(this.radRibbonBar1_CommandTabSelected);
            //Forcing the GUI to shows the Ribbontab1 each time the program is started
            this.ribbonTab1.IsSelected = true;
            this.schemeColor(getIsNew());
            TreeNodeCreator treeNodeCreator = new TreeNodeCreator();
            treeNodeCreator.init();
           
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

        internal static bool getIsTreeDoubleClicked()
        {
            return isTreeDoubleClicked;
        }

        internal static void setIsTreeDoubleClicked(bool isActive)
        {
            isTreeDoubleClicked = isActive;
        }

        //Getter and Setter to tranfer shape information between the MainMenu and the Diagram_Form.
        internal static NodeViewModel getNode()
        {
            return nodeGeneral;
        }

        internal static void setNode(NodeViewModel node)
        {
            nodeGeneral = node;
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

        //radRibbonBar1_CommandTabSelected() closes the NetworkButton's drop down menu if ribbonTab3 is not selected
        private void radRibbonBar1_CommandTabSelected(object sender, CommandTabEventArgs args)
        {
            if (!this.ribbonTab3.IsSelected && isNetworkOptionsOpen)
            {
                this.NetworkOptions.Height = 0;
                isNetworkOptionsOpen = false;
            }
        }
        private void ModelExplorButtonElement_Click(object sender, EventArgs e)
        {
            //this.WindowState = FormWindowState.Minimized;
            //open ModelExplorForm
            this.IsMdiContainer = true;
            if (CustomContentControl.getCurrentCase() != null)
            {
                ModelExplorForm ModelForm = new ModelExplorForm();
                ModelForm.TopLevel = false;
                // this.WindowState = FormWindowState.Maximized;
                ModelForm.MdiParent = this;
                // ModelForm.ShowDialog();
                ModelForm.Show();
            }
            else
            {
                string caption = "Database error message";
                MessageBox.Show("A case must be opened to access its data", caption);

            }

        }

        //timer_Tick() allows to display a dropmenu button, that contains buttons to create the different components
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isNetworkOptionsOpen)
            {
                NetworkOptions.Height -= 17;
                if (NetworkOptions.Height == 0)
                {
                    timer1.Stop();
                    isNetworkOptionsOpen = false;
                }
            }
            else
            {
                NetworkOptions.Height += 17;
                if (NetworkOptions.Height == 170)
                {
                    timer1.Stop();
                    isNetworkOptionsOpen = true;
                }
            }
        }

        //NetworkButton_Click() is the event listener for the Components button. It opens and close
        //a dropdown menu that contains the buttons that creates the components.
        private void radBusesButton_Click(object sender, EventArgs e)
        {
            if (getIsNew())
            {
                this.timer1.Start();
            }
        }

        //schemeColor() allows to change the color palette of NetworkButton depending if the
        //Diagram_Form was created or not.
        private void schemeColor(bool status)
        {
            if (status)
            {
                
                this.radBusesButton.ButtonFillElement.BackColor = Color.FromArgb(229, 239, 255);
                this.radBusesButton.ButtonFillElement.GradientPercentage = 0;
                this.radBusesButton.ButtonFillElement.Opacity = 1f;
                this.radBusesButton.ForeColor = Color.FromArgb(21, 66, 139);
            }
            else
            {
                this.radBusesButton.ButtonFillElement.BackColor = Color.FromArgb(185, 185, 185);
                this.radBusesButton.ButtonFillElement.Opacity = 0.5f;
                this.radBusesButton.ForeColor = Color.Gray;
                this.radBusesButton.ButtonFillElement.GradientPercentage = 100;
            }
        }

        private DiagramControl baseDiagram = null;
        public static SfDiagram currentDiagram = null;
        private void radNewButton_Click(object sender, EventArgs e)
        {
            caseBL = new CaseBL();
            Case c = caseBL.addCase();
            setCase(c);
            
            if (!getIsNew())
            {
                setIsNew(true);
                baseDiagram = new DiagramControl();
                this.elementHost1.Child = baseDiagram;
                this.schemeColor(getIsNew());
            }
            CustomContentControl Child = new CustomContentControl(c);
            CustomContentControl.setCurrentCase(c);
            CustomDiagram diagram = new CustomDiagram()
            {
                Nodes = new NodeCollection(),
                Connectors = new Syncfusion.UI.Xaml.Diagram.ConnectorCollection(),
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
            diagram.PreviewKeyDown += Diagram_PreviewKeyDown;
            (diagram.Info as IGraphInfo).MenuItemClickedEvent += MainMenu_MenuItemClickedEvent;
            //Add Node to Nodes property of the Diagram
            (diagram.Info as IGraphInfo).ItemAdded += MainMenu_ItemAdded;
            (diagram.Info as IGraphInfo).ItemTappedEvent += MainMenu_ItemTappedEvent;
            (diagram.Info as IGraphInfo).ItemDeletingEvent += MainMenu_ItemDeletingEvent;
            currentDiagram = diagram;
            Child.Content = diagram;
            DockingManager.SetState(Child, Syncfusion.Windows.Tools.Controls.DockState.Document);
            DockingManager.SetHeader(Child, Child.getCase().name);
            baseDiagram.dockingManager.Children.Add(Child);
            TDILayoutPanel.SetTDIIndex(Child, baseDiagram.dockingManager.Children.Count - 1);
        }

        private void MainMenu_ItemDeletingEvent(object sender, DiagramPreviewEventArgs args)
        {
            if (args.Item is NodeViewModel)
            {
                New_concept_WPF.Utility.Utils.blConnection_WPF((NodeViewModel)args.Item, "Delete");
            }
                
        }

        private void Diagram_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Escape) {
                TypeBus = null;
                MainMenu.currentDiagram.DefaultConnectorType = ConnectorType.Orthogonal;
                if (MainMenu.getIsTreeDoubleClicked())
                {
                    cleanShapesAndFunctions();
                }
            }
        }

        public string TypeBus { get; set; } = null;
        public Generator_Main MainTransformerMenue { get; private set; }

        private void MainMenu_ItemAdded(object sender, ItemAddedEventArgs args)
        {
            if (args.Item is CoreConnector) {
                GUI.New_concept_WPF.Utility.Utils.conSelector(args, TypeBus);
            }
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
                    New_concept_WPF.Utility.Utils.blConnection_WPF(clickedDiagramNode);
                    clickedDiagramNode.IsSelected = false;
                    clickedDiagramNode = null;
                }

            }
            //else if (args.Item.Content.Equals("Delete")) {
            //    if (clickedDiagramNode is NodeViewModel)
            //    {
            //        New_concept_WPF.Utility.Utils.blConnection_WPF(clickedDiagramNode, "Delete");
            //        clickedDiagramNode.IsSelected = false;
            //        clickedDiagramNode = null;
            //    }
            //}
         
            
        }

        private void create_contextMenuContent(CustomDiagram d) {
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
                CommandParameter = new RotateParameter(){
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

        private NodeViewModel clickedDiagramNode = null;
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
                        if (!getIsTreeDoubleClicked())
                        {
                            if (DiagramControl.getIslockedNode())
                            {
                                nodeCreation(System.Windows.Input.Mouse.GetPosition(currentDiagram));
                            }

                            // check here 

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
                    if (args.Item is Shapes.generator.GenShape)
                    {
                        clickedDiagramNode = (Shapes.generator.GenShape)args.Item;
                    }
                    else if (args.Item is Shapes.RLC.AbstractRLCCShape)
                    {
                        clickedDiagramNode = (Shapes.RLC.AbstractRLCCShape)args.Item;
                    }
                    else if (args.Item is Shapes.Transformer.AbstractTShape)
                    {
                        clickedDiagramNode = (Shapes.Transformer.AbstractTShape)args.Item;
                    }
                    else if (args.Item is Shapes.Load.LoadShape)
                    {
                        clickedDiagramNode = (Shapes.Load.LoadShape)args.Item;
                    }
                    else if (args.Item is Shapes.Line.AbstractLineShape)
                    {
                        clickedDiagramNode = (Shapes.Line.AbstractLineShape)args.Item;
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
                    else if (args.Item is Shapes.Load.EVShape)
                    {
                        clickedDiagramNode = (Shapes.Load.EVShape)args.Item;
                    }
                }
            }
        }
        private NodeViewModel generalNode = null;
        private void nodeCreation(System.Windows.Point position) {
            generalNode = MainMenu.getNode();
            generalNode.OffsetX = position.X;
            generalNode.OffsetY = position.Y;
            (currentDiagram.Nodes as NodeCollection).Add(generalNode);
            MainMenu.setNode(null);

        }



        private void Diagram_DragEnter(object sender, ItemDropEventArgs args)
        {
            // args.Source have the data which is dragged for drop.
            if (args.Source is System.Windows.DataObject)
            {
                object dataObject = (args.Source as System.Windows.DataObject).GetData(typeof(DragObject<TreeViewNode>));
                TreeViewNode treeViewItem = (dataObject as DragObject<TreeViewNode>).Source;
               
                //  if (treeViewItem.Level.ToString() != "0")

                //    {
                if ("Generator".Equals(((GUI.New_concept_WPF.TreeNodeWPF)treeViewItem.Content).ElementName))
                {
                    NodeViewModel temp = new Shapes.generator.GenShape();
                    args.Source = temp;
                    clickedDiagramNode = temp;
                    //MessageBox.Show(System.Windows.Input.Mouse.PreviewMouseUpEvent.Name);

                    //MainMenu.setNode(new Shapes.generator.GenShape());

                    //  nodeCreation(args.DragEventArgs.GetPosition(currentDiagram));
                    // setNode(null);
                    //CustomDiagram.setIsDragDrop(false);
                    //DiagramControl.setIslockedNode(false);

                }
                else if ("Three-Phase".Equals(((GUI.New_concept_WPF.TreeNodeWPF)treeViewItem.Content).ElementName))
                {
                    NodeViewModel temp = new Shapes.Line.Singleline3phaseShape();
                    args.Source = temp;
                    clickedDiagramNode = temp;
                }
                else if ("Double circuit".Equals(((GUI.New_concept_WPF.TreeNodeWPF)treeViewItem.Content).ElementName))
                {
                    NodeViewModel temp = new Shapes.Line.DoubleCircuitShape();
                    args.Source = temp;
                    clickedDiagramNode = temp;
                }
                else if ("M-Phase".Equals(((GUI.New_concept_WPF.TreeNodeWPF)treeViewItem.Content).ElementName))
                {
                    NodeViewModel temp = new Shapes.Line.MphaseShape();
                    args.Source = temp;
                    clickedDiagramNode = temp;
                }
                else if (("Triphasic".Equals(((GUI.New_concept_WPF.TreeNodeWPF)treeViewItem.Content).ElementName)))
                {
                    NodeViewModel temp = new Shapes.Transformer.TriTShape();
                    args.Source = temp;
                    clickedDiagramNode = temp;
                }
                else if (("YgDD".Equals(((GUI.New_concept_WPF.TreeNodeWPF)treeViewItem.Content).ElementName)))
                {
                    NodeViewModel temp = new Shapes.Transformer.YgDDTShape();
                    args.Source = temp;
                    clickedDiagramNode = temp;
                }
                else if (("YgYgD".Equals(((GUI.New_concept_WPF.TreeNodeWPF)treeViewItem.Content).ElementName)))
                {
                    NodeViewModel temp = new Shapes.Transformer.YgYgDTShape();
                    args.Source = temp;
                    clickedDiagramNode = temp;
                }
                else if (("Custom".Equals(((GUI.New_concept_WPF.TreeNodeWPF)treeViewItem.Content).ElementName)))
                {
                    NodeViewModel temp = new Shapes.Transformer.CustomTShape();
                    args.Source = temp;
                }
                else if (("Load".Equals(((GUI.New_concept_WPF.TreeNodeWPF)treeViewItem.Content).ElementName)))
                {
                    NodeViewModel temp = new Shapes.Load.LoadShape();
                    args.Source = temp;
                }
                else if (("C".Equals(((GUI.New_concept_WPF.TreeNodeWPF)treeViewItem.Content).ElementName)))
                {
                    NodeViewModel temp = new Shapes.RLC.CShape();
                    args.Source = temp;
                }
                else if (("L".Equals(((GUI.New_concept_WPF.TreeNodeWPF)treeViewItem.Content).ElementName)))
                {
                    NodeViewModel temp = new Shapes.RLC.LShape();
                    args.Source = temp;
                }
                else if (("R".Equals(((GUI.New_concept_WPF.TreeNodeWPF)treeViewItem.Content).ElementName)))
                {
                    NodeViewModel temp = new Shapes.RLC.RShape();
                    args.Source = temp;
                }
                else if (("LC".Equals(((GUI.New_concept_WPF.TreeNodeWPF)treeViewItem.Content).ElementName)))
                {
                    NodeViewModel temp = new Shapes.RLC.LCShape();
                    args.Source = temp;
                }
                else if (("RL".Equals(((GUI.New_concept_WPF.TreeNodeWPF)treeViewItem.Content).ElementName)))
                {
                    NodeViewModel temp = new Shapes.RLC.RLShape();
                    args.Source = temp;
                }
                else if (("RLC".Equals(((GUI.New_concept_WPF.TreeNodeWPF)treeViewItem.Content).ElementName)))
                {
                    NodeViewModel temp = new Shapes.RLC.RLCShape();
                    args.Source = temp;
                }
                else if (("Sync Gen.".Equals(((GUI.New_concept_WPF.TreeNodeWPF)treeViewItem.Content).ElementName)))
                {
                    NodeViewModel temp = new Shapes.generator.SyncGenShape();
                    args.Source = temp;
                }
                else if (("Wind Generator".Equals(((GUI.New_concept_WPF.TreeNodeWPF)treeViewItem.Content).ElementName)))
                {
                    NodeViewModel temp = new Shapes.generator.WindGenShape();
                    args.Source = temp;
                }
                else if (("EV Machin".Equals(((GUI.New_concept_WPF.TreeNodeWPF)treeViewItem.Content).ElementName)))
                {
                    NodeViewModel temp = new Shapes.Load.EVShape();
                    args.Source = temp;
                }
                else if (("PV Panels".Equals(((GUI.New_concept_WPF.TreeNodeWPF)treeViewItem.Content).ElementName)))
                {
                    NodeViewModel temp = new Shapes.generator.PVGenShape();
                    args.Source = temp;
                }
                // }

            }
        }

        private void cleanShapesAndFunctions()
        {
            MainMenu.setIsTreeDoubleClicked(false);
            //MainMenu.currentDiagram.DefaultConnectorType = ConnectorType.;
            //ToolDiagram_Form.setIsLockedCreation(false);
            DiagramControl.setIslockedNode(false);
            shapeToBeCreated=ItemEnum.None;
            //ToolDiagram_Form.setClickedShape(shapeToBeCreated);
            DiagramControl.setClickedNode(shapeToBeCreated);
            //getDiagram().ActiveTool = MouseTool.PointerTool;
            //getDiagram().Cursor = Cursors.Default;
        }

        //NewWindow_Disposed() is triggered once a tab os closed. It provides the user a way of 
        //saving the tab content and ensures a safe way of getting rid of DocumentWindows.
        private void NewWindow_Disposed(object sender, EventArgs e)
        {
            string message = "Do you want to save the current case?";
            string caption = "Cases Closing";

            var resultClose = MessageBox.Show(message, caption,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);

            if (resultClose == DialogResult.Yes)
            {
                MessageBox.Show("the case was saved", "Notification",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                //add code to save case
            }
            caseBL.removeCase(CustomContentControl.getCurrentCase());
            CustomContentControl.setCurrentCase(null);
        }

        //shapeCreation() append a new shape to the radDiagram while settings its starting size and 
        //position

        private void MenuProperty_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Context Menu works");
        }

        OpenFileDialog ofd = new OpenFileDialog();
        private void radOpenButton_Click_1(object sender, EventArgs e)
        {
            ofd.Filter = "Gsim| *.Gsim";
            ofd.ShowDialog();
        }

        SaveFileDialog sfd = new SaveFileDialog();
        private void radSaveButton_Click(object sender, EventArgs e)
        {

            sfd.FileName = "*.Gsim";
            sfd.DefaultExt = "Gsim";
            sfd.Filter = "Gsim files (*.gsim) | *gsim";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                Stream fileStream = sfd.OpenFile();
                StreamWriter sw = new StreamWriter(fileStream);
            }
        }

        private void radPrintButton_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.PrintDialog p1 = new System.Windows.Forms.PrintDialog();
            PrintDocument p2 = new PrintDocument();
            p2.DocumentName = "Print Document";
            p1.Document = p2;
            p1.AllowSelection = true;
            p1.AllowSomePages = true;
            if (p1.ShowDialog() == DialogResult.OK)
            {
                p2.Print();

            }

        }

        private void radExportButton_Click(object sender, EventArgs e)
        {

        }

        private void radCutButton_Click(object sender, EventArgs e)
        {
            *//*
            TextBox txtBox = this.ActiveControl as TextBox;
            if (txtBox.SelectedText != String.Empty)
                Clipboard.SetData(DataFormats.Text, txtBox.SelectedText);
            txtBox.SelectedText = String.Empty; *//*
        }

        private void radCopyButton_Click(object sender, EventArgs e)
        {

        }

        private void radDeleteButton_Click(object sender, EventArgs e)
        {

        }

        private void radUndoButton_Click(object sender, EventArgs e)
        {

        }

        private void radRedoButton_Click(object sender, EventArgs e)
        {

        }

        private void radSelectAllButton_Click(object sender, EventArgs e)
        {

        }

        private void radDBButton_Click(object sender, EventArgs e)
        {
            //this.WindowState = FormWindowState.Minimized;
            //open ModelExplorForm
            this.IsMdiContainer = true;
            if (CustomContentControl.getCurrentCase() != null)
            {
                ModelExplorer ModelForm = new ModelExplorer();
                //ModelForm.TopLevel = false;
                // this.WindowState = FormWindowState.Maximized;
                // ModelForm.MdiParent = this;
                // ModelForm.ShowDialog();
                ModelForm.Show();
            }
            else
            {
                string caption = "Database error message";
                MessageBox.Show("A case must be opened to access its data", caption);

            }
        }

        private void radPhaseAButton_Click(object sender, EventArgs e)
        {
            //currentDiagram.Connectors = new ObservableCollection<ThreePhaseConnector>();
            //(currentDiagram.Connectors as Syncfusion.UI.Xaml.Diagram.ConnectorCollection).Add(new ObservableCollection<ThreePhaseConnector>())
            TypeBus = "A";
            this.timer1.Start();
            //currentDiagram.Tool = Tool.DrawOnce;
            //currentDiagram.DrawingTool = DrawingTool.Connector;
            //currentDiagram.Connectors = new ObservableCollection<ConnectorViewModel>();
        }

        private void radPhaseBButton_Click(object sender, EventArgs e)
        {
            TypeBus = "B";
            this.timer1.Start();
        }

        private void radPhaseCButton_Click(object sender, EventArgs e)
        {
            TypeBus = "C";
            this.timer1.Start();
        }

        private void radBundleButton_Click(object sender, EventArgs e)
        {
            TypeBus = "Bundle";
            this.timer1.Start();
        }

        private void radGeneralSignalButton_Click(object sender, EventArgs e)
        {
            TypeBus = null;
            this.timer1.Start();
        }

        private void radDiagonalSignalButton_Click(object sender, EventArgs e)
        {
            TypeBus = "Diagonal";
            this.timer1.Start();
        }

        private void radThreePhaseBusButton_Click(object sender, EventArgs e)
        {
            TypeBus = "ThreePhase";
            this.timer1.Start();
            MainMenu.currentDiagram.DefaultConnectorType = ConnectorType.Line;
        }

        private void radPolygonButton_Click(object sender, EventArgs e)
        {
            *//*polylineTool = new CustomPolylineTool("Polyline");
            service.ToolList.Add(polylineTool);
            service.ActivateTool("Polyline");*//*
            

        }

        private void radButtonElement1_Click(object sender, EventArgs e)
        {
            FileBrowser fileBrowser = new FileBrowser();
            fileBrowser.ShowDialog();
        }

        private void radButtonElement6_Click(object sender, EventArgs e)
        {
            Generator_Main generator_Main = new Generator_Main();
            generator_Main.ShowDialog();
            *//*TriLine_main load_Main = new TriLine_main();
            load_Main.ShowDialog();*//*
        }

      *//*  private void radRibbonBarButtonGroup1_Click(object sender, EventArgs e)
        {
            MainTransformerMenu mainTransformermenu = new MainTransformerMenu();
            mainTransformermenu.ShowDialog();
            
        }*//*

        private void radButtonElement7_Click(object sender, EventArgs e)
        {
            //ITransformer iTransformer = new C3WTransformerBL();
            Main3WTransformerMenu transformerTypes = new Main3WTransformerMenu(new MainTransformers());
            //  transformerTypes = (TriTransformer)iTransformer.add(CustomContentControl.getCurrentCase());
            // transformerTypes.type = "3Tra";
            //   Transformer_Main transformerMenu = new Transformer_Main(transformerTypes);
            transformerTypes.ShowDialog();
        }
    }
}
 */