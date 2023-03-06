using Syncfusion.UI.Xaml.Diagram;
using Syncfusion.UI.Xaml.Diagram.Utility;
using Syncfusion.UI.Xaml.TreeView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using BL;
using Syncfusion.Windows.Forms.Tools.Navigation;
using System.Windows.Forms;
using Syncfusion.UI.Xaml.Diagram.Controls;
using GUI.New_concept_WPF.Custom_Controls.CustomPort;
using GUI.New_concept_WPF.Utility;
using network;
using persistent.enumeration;
using network.generator.Gentype;

namespace GUI.New_concept_WPF
{
    public class CustomDiagram : SfDiagram
    {
        //private static string clickedShaped = null;
        //private static bool isLockedCreation = false;
        private ResourceDictionary resourceDictionary = null;
        private ResourceDictionary styleResourceDictionary = null;
        private static bool isDragDrop = false;
        private bool verticalAxis;
        private bool horizontalAxis;
        
        public CustomDiagram()
        {
            resourceDictionary = new ResourceDictionary()
            {
                Source = new Uri(@"/Syncfusion.SfDiagram.Wpf;component/Resources/BasicShapes.xaml", UriKind.RelativeOrAbsolute)
            };

            styleResourceDictionary = new ResourceDictionary()
            {
                Source = new Uri(@"/GUI;component/New_concept_WPF/StyleResource.xaml", UriKind.RelativeOrAbsolute)
            };

            this.KnownTypes = () => new List<Type>()
            {
                typeof(Shapes.generator.GenShape),
                
                typeof(bases.BaseEntity),
                typeof(Bus),
                typeof(SyncGen),
                typeof(WindGen),
                typeof(PVGen),
                typeof(Generator),
                
                typeof(Shapes.Line.MphaseShape),
                typeof(Shapes.Line.DoubleCircuitShape),
                typeof(Shapes.Line.Singleline3phaseShape),
                typeof(Shapes.Line.LineShape),
            

                typeof(DoubleCircuitLine),
                typeof(LineBranches),
                typeof(MultiPhaseLine),
                typeof(Single3phaseLine),
                //typeof(Custom_Controls.CustomPort.CustomPort)
            };

            //var myBinding = new System.Windows.Data.Binding("rsDict")
            //{
            //    Source = resourceDictionary
            //};
            //var myBindingStyle = new System.Windows.Data.Binding("rsStyleDict")
            //{
            //    Source = styleResourceDictionary
            //};
            //this.SetBinding(CustomDiagram.ConnectorsProperty, myBinding);
            //this.SetBinding(CustomDiagram.StyleProperty, myBindingStyle);
            //(this.Info as IGraphInfo).ObjectDrawn += CustomDiagram_ObjectDrawn;
            //this.Constraints.Add(GraphConstraints.AutomaticPortCreation);
            //(this.Info as IGraphInfo).Constraints = NodeConstraints.Default & ~(NodeConstraints.Rotatable | NodeConstraints.InheritRotatable) & ~(NodeConstraints.Resizable | NodeConstraints.InheritResizable) & ~NodeConstraints.Connectable;
        }

        public static bool getIsDragDrop()
        {
            return isDragDrop;
        }

        public static void setIsDragDrop(bool dragDrop)
        {
            CustomDiagram.isDragDrop = dragDrop;
        }

        private void CustomDiagram_ObjectDrawn(object sender, ObjectDrawnEventArgs args)
        {
            //SourcePort should be set on Started state
            if (args.State == DragState.Started)
            {
                CustomDiagram.setIsDragDrop(true);
                if (args.Item is IConnector)
                {
                    IConnector connector = args.Item as IConnector;
                    if (connector.SourceNode != null)
                    {
                        if ((connector.SourceNode as NodeViewModel).Ports == null)
                        {
                            //Initialize the Port collection
                            (connector.SourceNode as NodeViewModel).Ports = new ObservableCollection<IPort>();
                        }
                        //Set the TargetPort as NodePort to the Node
                        args.SourcePort = new NodePortViewModel();
                    }
                    if (connector.SourceConnector != null)
                    {
                        if ((connector.SourceConnector as ConnectorViewModel) != null)
                        {
                            if ((connector.SourceConnector as ConnectorViewModel).Ports == null)
                                //Initialize the Port collection
                                (connector.SourceConnector as ConnectorViewModel).Ports = new ObservableCollection<IPort>();
                            //Set the TargetPort as ConnectorPort to the Connector
                            args.SourcePort = new ConnectorPortViewModel();
                        }
                        else if ((connector.SourceConnector as DockPortViewModel) != null)
                        {
                            if ((connector.SourceConnector as DockPortViewModel).Ports == null)
                                //Initialize the Port collection
                                (connector.SourceConnector as DockPortViewModel).Ports = new ObservableCollection<IPort>();
                            //Set the TargetPort as ConnectorPort to the Connector
                            args.SourcePort = new DockPortViewModel();
                        }
                    }
                }
            }

            //TargetPort should be set on Started state
            if (args.State == DragState.Completed)
            {
                if (args.Item is IConnector)
                {
                    IConnector connector = args.Item as IConnector;
                    if (connector.TargetNode != null)
                    {
                        if ((connector.TargetNode as NodeViewModel).Ports == null)
                            //Initialize the Port collection
                            (connector.TargetNode as NodeViewModel).Ports = new ObservableCollection<IPort>();
                        //Set the TargetPort as NodePort to the Node
                        args.TargetPort = new NodePortViewModel();
                    }
                    if (connector.TargetConnector != null)
                    {
                        if ((connector.TargetConnector as ConnectorViewModel) != null)
                        {
                            if ((connector.TargetConnector as ConnectorViewModel).Ports == null)
                                //Initialize the Port collection
                                (connector.TargetConnector as ConnectorViewModel).Ports = new ObservableCollection<IPort>();
                            //Set the TargetPort as ConnectorPort to the Connector
                            args.TargetPort = new ConnectorPortViewModel();
                        }
                        else if ((connector.TargetConnector as DockPortViewModel) != null)
                        {
                            if ((connector.TargetConnector as DockPortViewModel).Ports == null)
                                //Initialize the Port collection
                                (connector.TargetConnector as DockPortViewModel).Ports = new ObservableCollection<IPort>();
                            //Set the TargetPort as ConnectorPort to the Connector
                            args.TargetPort = new DockPortViewModel();

                        }
                    }
                }
            }

        }

        //Override the SetTool method
        protected override void SetTool(SetToolArgs args)
        {
            // Check Control Key for Connection
            if (args.Source is CustomPort)
            {
                if ((args.Source as CustomPort).CanConnect())
                {
                    args.Action = ActiveTool.Draw;
                }
                else
                {
                    args.Action = ActiveTool.None;
                }
            }
            else if ((args.Source is NodePortViewModel || args.Source is IConnector) && (Control.ModifierKeys & Keys.Control) == Keys.Control)
            {
                args.Action = ActiveTool.Draw;
            }
            else
            {
                base.SetTool(args);
            }
        }

        public bool Horizontal
        {
            get { return horizontalAxis; }
            set
            {
                if (horizontalAxis != value)
                {
                    horizontalAxis = value;
                    OnPropertyChanged("Horizontal");
                }
            }
        }

        public bool Vertical
        {
            get { return verticalAxis; }
            set
            {
                if (verticalAxis != value)
                {
                    verticalAxis = value;
                    OnPropertyChanged("Vertical");
                }
            }
        }
        //Method to return in-port to set target port.
        private IPort GetInPort(INode node)
        {
            var ports = node.Ports as PortCollection;
            if (ports != null)
            {
                foreach (var port in ports)
                {
                    // Port validation, which can be modified based on requirements
                    if (port.ID is string && port.ID.ToString().Contains("InPort"))
                    {
                        var portInfo = port.Info as IPortInfo;
                        if (portInfo != null && (portInfo.InConnectors == null || portInfo.InConnectors.Count() == 0))
                        {
                            return port;
                        }
                    }
                }

                return ports.FirstOrDefault();
            }

            return null;
        }

        //Method to return out-port to set source port.
        private IPort GetOutPort(INode node)
        {
            var ports = node.Ports as PortCollection;
            if (ports != null)
            {
                foreach (var port in ports)
                {
                    // Port validation, which can be modified based on requirements
                    if (port.ID is string && port.ID.ToString().Contains("OutPort"))
                    {
                        var portInfo = port.Info as IPortInfo;
                        if (portInfo != null && (portInfo.OutConnectors == null || portInfo.OutConnectors.Count() == 0))
                        {
                            return port;
                        }
                    }
                }

                return ports.FirstOrDefault();
            }

            return null;
        }
        protected override void ValidateConnection(ConnectionParameter args)
        {
            #region Bus Orientation
            //This allows to create a horizontal or vertical bus
            if (Main_Menu.getIsBus())
            {
                if (args.TargetPoint != (args.Connector as ConnectorViewModel).TargetPoint)
                {
                    if (Horizontal)
                    {
                        args.TargetPoint = new Point(args.TargetPoint.X, (args.Connector as ConnectorViewModel).TargetPoint.Y);
                    }
                    else if (Vertical)
                    {
                        args.TargetPoint = new Point((args.Connector as ConnectorViewModel).TargetPoint.X, args.TargetPoint.Y);
                    }
                }
                base.ValidateConnection(args);
            }
            #endregion

            #region Variable Definitions
            var sPort = (args.Connector as CoreConnector).SourcePort;
            var tPort = (args.Connector as CoreConnector).TargetPort;
            var sConn = (args.Connector as CoreConnector).SourceConnector;
            var tConn = (args.Connector as CoreConnector).TargetConnector;
            var isConn = (args.Connector as CoreConnector).Name.Contains("Bus");
            Style style = new Style(typeof(System.Windows.Shapes.Path));
            var scPort = args.SourcePort as CustomPort;
            var trPort = args.TargetPort as CustomPort;
            var scConn = args.SourceConnector as CoreConnector;
            var trConn = args.TargetConnector as CoreConnector;
            #endregion

            #region General Style
            if (args.SourceNode == null && args.TargetNode == null)
            {
                //If the start of the connector is linked to a port or a Bus
                if ((sPort != null || sConn != null) && !isConn)
                {
                    (args.Connector as CoreConnector).SourceDecorator = resourceDictionary["Ellipse"];
                    (args.Connector as CoreConnector).SourceDecoratorStyle = styleResourceDictionary["DecoratorSuccessStyle"] as Style;
                    
                    object temp = null;
                    if (sConn != null)
                    {
                        temp = sConn as CoreConnector;
                    }
                    else if (sPort != null) 
                    {
                        temp = ((sPort as CustomPort).Node as NodeViewModel);
                    }
                    (args.Connector as CoreConnector).setWireFrom(temp);
                
                }
                //If the start of the connector is not linked to a port or Bus
                if (sPort == null && sConn == null && !isConn)
                {
                    (args.Connector as CoreConnector).SourceDecorator = resourceDictionary["BlackSlash"];
                    (args.Connector as CoreConnector).SourceDecoratorStyle = styleResourceDictionary["DecoratorFailStyle"] as Style;
                    
                    (args.Connector as CoreConnector).setWireFrom(null);
                    
                    
                }
                //If the end of the connector ends is not linked to a port or Bus
                if (tPort == null && tConn == null && !isConn)
                {
                    (args.Connector as CoreConnector).TargetDecorator = resourceDictionary["BlackSlash"];
                    (args.Connector as CoreConnector).TargetDecoratorStyle = styleResourceDictionary["DecoratorFailStyle"] as Style;
                    
                    (args.Connector as CoreConnector).setWireTo(null);
                    
                }
                //If the connection with the Bus is successful
                if (args.TargetConnector != null)
                {
                    (args.Connector as CoreConnector).TargetDecorator = resourceDictionary["Ellipse"];
                    (args.Connector as CoreConnector).TargetDecoratorStyle = styleResourceDictionary["DecoratorSuccessStyle"] as Style;
                    
                    (args.Connector as CoreConnector).setWireTo(args.TargetConnector as CoreConnector);
                    

                }
            }
            #endregion

            #region Bus Linking
            if (tConn != null || sConn != null || trConn != null)
            {
                try
                {
                    if ((args.TargetPort != null && args.TargetConnector == null && sConn != null))
                    {
                        object o = ((NodePortViewModel)args.TargetPort).Node;
                        Utils.blConnection_WPF(o as NodeViewModel, UtilsKeywords.Registration.ToString(), 0, null, ((CoreConnector)(args.Connector as CoreConnector).SourceConnector).getBus(), (CustomPort)args.TargetPort);
                        (args.Connector as CoreConnector).TargetDecorator = resourceDictionary["Ellipse"];
                       // (args.Connector as CoreConnector).TargetDecoratorPivot = new Point(-1, 1);
                        (args.Connector as CoreConnector).TargetDecoratorStyle = styleResourceDictionary["DecoratorSuccessStyle"] as Style;
                        (args.Connector as CoreConnector).setWireTo(o as NodeViewModel);

                    }

                    if (args.TargetConnector != null && sPort != null && sConn == null)
                    {
                        object o = ((NodePortViewModel)(args.Connector as CoreConnector).SourcePort).Node;
                        Utils.blConnection_WPF(o as NodeViewModel, UtilsKeywords.Registration.ToString(), 0, null, ((CoreConnector)(args.TargetConnector)).getBus(), (CustomPort)(args.Connector as CoreConnector).SourcePort);
                        (args.Connector as CoreConnector).SourceDecorator = resourceDictionary["Ellipse"];
                        // (args.Connector as CoreConnector).SourceDecoratorPivot = new Point(1, 0);
                        // (args.Connector as CoreConnector).TargetDecoratorPivot = new Point(1,1);
                        //Defining target padding value for target decorators.

                        (args.Connector as CoreConnector).TargetPadding = -6.5;
                        (args.Connector as CoreConnector).SourceDecoratorStyle = styleResourceDictionary["DecoratorSuccessStyle"] as Style;

                    }

                    if ((args.Connector as CoreConnector).SourceConnector != null && args.TargetConnector is CoreConnector && args.TargetConnector != null)
                    {
                        if (((args.Connector as CoreConnector).SourceConnector as CoreConnector).Name == (args.TargetConnector as CoreConnector).Name)
                        {
                            args.TargetConnector = null;
                            (args.Connector as CoreConnector).TargetDecorator = resourceDictionary["BlackSlash"];
                            (args.Connector as CoreConnector).TargetDecoratorStyle = styleResourceDictionary["DecoratorFailStyle"] as Style;
                            (args.Connector as CoreConnector).setWireTo(null);
                        }
                    }
                } catch(Exception exception)
                {
                    System.Windows.MessageBox.Show(exception.Message);
                }
            }
            #endregion

            #region Nodes Connections
            if (args.ConnectorEnd == ConnectorEnd.Target)
            {
                //var sPort = (args.Connector as CoreConnector).SourcePort;
                if (args.TargetPort != null)
                {
                    if (sPort != null && sConn == null)
                    {
                        //var trPort = args.TargetPort;

                        if ((sPort as CustomPort).Owner.Contains("RLC") || (trPort != null &&  trPort.Owner.Contains("RLC"))) //(trPort != null && (sPort as CustomPort).Owner != trPort.Owner) ||
                        {
                            //NOTE" ask bussiness rule hew. Can RLC ports connect to more than one node
                            if (trPort.CanConnect())
                            {
                                (args.Connector as CoreConnector).TargetDecorator = resourceDictionary["Ellipse"];
                                (args.Connector as CoreConnector).TargetDecoratorStyle = styleResourceDictionary["DecoratorSuccessStyle"] as Style;
                                (args.Connector as CoreConnector).setWireTo(trPort.Node as NodeViewModel);
                            }
                            else {
                                (args.Connector as CoreConnector).TargetDecorator = resourceDictionary["BlackSlash"];
                                (args.Connector as CoreConnector).TargetDecoratorStyle = styleResourceDictionary["DecoratorFailStyle"] as Style;
                                (args.Connector as CoreConnector).setWireTo(null);
                                args.TargetPort = null;
                                args.TargetNode = null;
                            }
                        } else if ((trPort != null && (sPort as CustomPort).Owner == trPort.Owner || (trPort != null && (sPort as CustomPort).Owner != trPort.Owner)) && !(sPort as CustomPort).Owner.Contains("RLC"))
                        {
                                (args.Connector as CoreConnector).TargetDecorator = resourceDictionary["BlackSlash"];
                                (args.Connector as CoreConnector).TargetDecoratorStyle = styleResourceDictionary["DecoratorFailStyle"] as Style;
                                args.TargetPort = null;
                                args.TargetNode = null;
                        }
                    }
                }
            }
            else if(args.ConnectorEnd == ConnectorEnd.Source)
            {
                //var tPort = (args.Connector as CoreConnector).TargetPort;
                if (args.SourcePort != null)
                {
                    if (tPort != null && tConn == null)
                    {
                        if ((tPort as CustomPort).Owner == scPort.Owner && !(tPort as CustomPort).Owner.Contains("RLC"))
                        {
                            (args.Connector as CoreConnector).SourceDecorator = resourceDictionary["BlackSlash"];
                            (args.Connector as CoreConnector).SourceDecoratorStyle = styleResourceDictionary["DecoratorFailStyle"] as Style;
                            args.SourcePort = null;
                            args.SourceNode = null;

                        }
                        else if ((tPort as CustomPort).Owner != scPort.Owner || (tPort as CustomPort).Owner.Contains("RLC") || scPort.Owner.Contains("RLC"))
                        {
                            if (scPort.CanConnect())
                            {
                                (args.Connector as CoreConnector).SourceDecorator = resourceDictionary["Ellipse"];
                                (args.Connector as CoreConnector).SourceDecoratorStyle = styleResourceDictionary["DecoratorSuccessStyle"] as Style;
                                (args.Connector as CoreConnector).setWireFrom(scPort.Node as NodeViewModel);
                            }
                            else {
                                (args.Connector as CoreConnector).SourceDecorator = resourceDictionary["BlackSlash"];
                                (args.Connector as CoreConnector).SourceDecoratorStyle = styleResourceDictionary["DecoratorFailStyle"] as Style;
                                (args.Connector as CoreConnector).setWireFrom(null);
                                args.SourcePort = null;
                                args.SourceNode = null;
                            }
                        }


                    }
                }
            }
            #endregion

            base.ValidateConnection(args);
            return;
            
                //if (args.SourceNode == null && args.TargetNode == null)
                //{


                    #region General Style
                    //If the start of the connector is linked to a port or a Bus
                    //if ((sPort != null || sConn != null) && !isConn)
                    //{
                    //    (args.Connector as CoreConnector).SourceDecorator = resourceDictionary["Ellipse"];
                    //    (args.Connector as CoreConnector).SourceDecoratorStyle = styleResourceDictionary["DecoratorSuccessStyle"] as Style;
                    //}
                    ////If the start of the connector is not linked to a port or Bus
                    //if (sPort == null && sConn == null && !isConn)
                    //{
                    //    (args.Connector as CoreConnector).SourceDecorator = resourceDictionary["BlackSlash"];
                    //    (args.Connector as CoreConnector).SourceDecoratorStyle = styleResourceDictionary["DecoratorFailStyle"] as Style;
                    //}
                    ////If the end of the connector ends is not linked to a port or Bus
                    //if (tPort == null && tConn == null && !isConn)
                    //{
                    //    (args.Connector as CoreConnector).TargetDecorator = resourceDictionary["BlackSlash"];
                    //    (args.Connector as CoreConnector).TargetDecoratorStyle = styleResourceDictionary["DecoratorFailStyle"] as Style;
                    //}
                    ////If the connection with the Bus is successful
                    //if (args.TargetConnector != null)
                    //{
                    //    (args.Connector as CoreConnector).TargetDecorator = resourceDictionary["Ellipse"];
                    //    (args.Connector as CoreConnector).TargetDecoratorStyle = styleResourceDictionary["DecoratorSuccessStyle"] as Style;
                    //}
                    #endregion

                    #region WORK IN PROGRESS
                    if (sPort is CustomPort && tPort is CustomPort && tConn == null && sConn == null)
                    {
                        if (((sPort != null && (sPort as CustomPort).Owner.Contains("RLC")) || (trPort != null && trPort.Owner.Contains("RLC"))))
                        {
                            var sourcePort = args.SourcePort as CustomPort;
                            var targetPort = args.TargetPort as CustomPort;

                            if (sourcePort != null && !sourcePort.CanConnect())
                            {
                                args.SourcePort = null;
                                (args.Connector as CoreConnector).SourcePort = null;
                                (args.Connector as CoreConnector).SourceDecorator = resourceDictionary["BlackSlash"];
                                (args.Connector as CoreConnector).SourceDecoratorStyle = styleResourceDictionary["DecoratorFailStyle"] as Style;

                            }
                            else if (sourcePort != null && sourcePort.CanConnect())
                            {
                                (args.Connector as CoreConnector).SourceDecorator = resourceDictionary["Ellipse"];
                                (args.Connector as CoreConnector).SourceDecoratorStyle = styleResourceDictionary["DecoratorSuccessStyle"] as Style;
                            }


                            if (targetPort != null && !targetPort.CanConnect())
                            {
                                System.Diagnostics.Debug.WriteLine("HERE44");
                                args.TargetPort = null;
                                (args.Connector as CoreConnector).TargetPort = null;
                                (args.Connector as CoreConnector).TargetDecorator = resourceDictionary["BlackSlash"];
                                (args.Connector as CoreConnector).TargetDecoratorStyle = styleResourceDictionary["DecoratorFailStyle"] as Style;
                            }
                            else if (targetPort != null && targetPort.CanConnect())
                            {
                                (args.Connector as CoreConnector).TargetDecorator = resourceDictionary["Ellipse"];
                                (args.Connector as CoreConnector).TargetDecoratorStyle = styleResourceDictionary["DecoratorSuccessStyle"] as Style;


                            }

                        }


                        if (((sPort as CustomPort).Owner == (tPort as CustomPort).Owner) && !(sPort as CustomPort).Owner.Contains("RLC"))
                        {
                            (args.Connector as CoreConnector).TargetDecorator = resourceDictionary["BlackSlash"];
                            (args.Connector as CoreConnector).TargetDecoratorStyle = styleResourceDictionary["DecoratorFailStyle"] as Style;
                            //args.TargetPort.Constraints = ~PortConstraints.Connectable;
                            args.TargetPort = null;
                            args.TargetNode = null;

                        }
                        else if ((sPort as CustomPort).Owner != (tPort as CustomPort).Owner || (trPort != null && (sPort as CustomPort).Owner != trPort.Owner) || ((sPort as CustomPort).Owner.Contains("RLC") && (tPort as CustomPort).Owner.Contains("RLC")))
                        {

                            //if (args.TargetPort != null)
                            //{
                            //    args.TargetPort.Constraints = PortConstraints.Connectable & ~PortConstraints.InheritConnectable;
                            //}

                            if ((tPort as CustomPort).CanConnect())
                            {
                                (args.Connector as CoreConnector).TargetDecorator = resourceDictionary["Ellipse"];
                                (args.Connector as CoreConnector).TargetDecoratorStyle = styleResourceDictionary["DecoratorSuccessStyle"] as Style;
                            }

                        }

                    }
                    #endregion

                    //if ((args.Connector as CoreConnector).SourcePort == null && tPort != null) {
                    //    //System.Diagnostics.Debug.WriteLine(((args.Connector as ConnectorViewModel).Info as INodePortInfo).Connectors.Count());
                    //    //System.Diagnostics.Debug.WriteLine("HEEEEEEEEEEEEEEEERE");
                    //    args.SourcePort = null;

                    //}
                    //if ((args.Connector as CoreConnector).TargetPort == null)
                    //{
                    //    System.Diagnostics.Debug.WriteLine("NOOOOOOOOOOOOOOOOOO");
                    //}

                    //This section runs if a Bus is the target or the source of the conenction
                    #region Bus Linking
                    //if (tConn != null || sConn != null || trConn != null)
                    //{

                    //    if ((args.TargetPort != null && args.TargetConnector == null && sConn != null))
                    //    {
                    //        object o = ((NodePortViewModel)args.TargetPort).Node;
                    //        Utils.blConnection_WPF(o as NodeViewModel, UtilsKeywords.Registration.ToString(), 0, null, ((CoreConnector)(args.Connector as CoreConnector).SourceConnector).getBus());
                    //        (args.Connector as CoreConnector).TargetDecorator = resourceDictionary["Ellipse"];
                    //        (args.Connector as CoreConnector).TargetDecoratorStyle = styleResourceDictionary["DecoratorSuccessStyle"] as Style;
                    //    }

                    //    if (args.TargetConnector != null && sPort != null && sConn == null)
                    //    {
                    //        object o = ((NodePortViewModel)(args.Connector as CoreConnector).SourcePort).Node;
                    //        Utils.blConnection_WPF(o as NodeViewModel, UtilsKeywords.Registration.ToString(), 0, null, ((CoreConnector)(args.TargetConnector)).getBus());
                    //        (args.Connector as CoreConnector).SourceDecorator = resourceDictionary["Ellipse"];
                    //        (args.Connector as CoreConnector).SourceDecoratorPivot = new Point(0.5, 0.5);
                    //        (args.Connector as CoreConnector).SourceDecoratorStyle = styleResourceDictionary["DecoratorSuccessStyle"] as Style;

                    //    }

                    //    if ((args.Connector as CoreConnector).SourceConnector != null && args.TargetConnector is CoreConnector && args.TargetConnector != null)
                    //    {
                    //        if (((args.Connector as CoreConnector).SourceConnector as CoreConnector).Name == (args.TargetConnector as CoreConnector).Name)
                    //        {
                    //            args.TargetConnector = null;
                    //            (args.Connector as CoreConnector).TargetDecorator = resourceDictionary["BlackSlash"];
                    //            (args.Connector as CoreConnector).TargetDecoratorStyle = styleResourceDictionary["DecoratorFailStyle"] as Style;

                    //        }
                    //    }

                        //if (args.TargetPort == null && args.TargetConnector == null)
                        //{
                        //    (args.Connector as CoreConnector).TargetDecorator = resourceDictionary["BlackSlash"];
                        //    (args.Connector as CoreConnector).TargetDecoratorStyle = styleResourceDictionary["DecoratorFailStyle"] as Style;
                        //}
                    //}
                    #endregion
                //}
                //else if (args.SourceNode != null)
                //{
                //    args.SourceNode = null;
                //    args.SourceConnector = null;
                //    args.SourcePort = null;
                //    (args.Connector as CoreConnector).SourceDecorator = resourceDictionary["BlackSlash"];
                //    (args.Connector as CoreConnector).SourceDecoratorStyle = styleResourceDictionary["DecoratorFailStyle"] as Style;

                //}
                //else if (args.TargetNode != null || (args.Connector as CoreConnector).TargetNode != null)
                //{
                //    args.TargetNode = null;
                //    args.TargetPort = null;
                //    args.TargetConnector = null;
                //    (args.Connector as CoreConnector).TargetDecorator = resourceDictionary["BlackSlash"];
                //    (args.Connector as CoreConnector).TargetDecoratorStyle = styleResourceDictionary["DecoratorFailStyle"] as Style;

                //}
                //else
                //{
                //    args.TargetNode = null;
                //    args.SourceNode = null;
                //    (args.Connector as CoreConnector).SourceDecorator = resourceDictionary["BlackSlash"];
                //    (args.Connector as CoreConnector).SourceDecoratorStyle = styleResourceDictionary["DecoratorFailStyle"] as Style;
                //    (args.Connector as CoreConnector).TargetDecorator = resourceDictionary["BlackSlash"];
                //    (args.Connector as CoreConnector).TargetDecoratorStyle = styleResourceDictionary["DecoratorFailStyle"] as Style;

                //}
            }
        }
    }

