using BL;
using network;
using persistent;
using Syncfusion.UI.Xaml.Diagram;
using Syncfusion.UI.Xaml.Diagram.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using persistent.network.wire;
using GUI.New_concept_WPF.Custom_Controls.CustomPort;
using persistent.enumeration;
using System.Runtime.Serialization;

namespace GUI.New_concept_WPF
{
    public class CoreConnector : ConnectorViewModel
    {
        private Case cases;
        private Bus busItem;
        private Wire wireItem;
        [DataMember]
        public string Status { get; set; }
        [DataMember]
        public string Type { get; set; }
        [DataMember]
        public double Voltage { get; set; }
        [DataMember]
        public double Current { get; set; }
        [DataMember]
        public bool isBusConnector { get; set; }
        [DataMember]
        public bool Ideal { get; set; }

        protected AnnotationEditorViewModel label = new AnnotationEditorViewModel();
        [DataMember]
        public static int Number { get; set; }
        private ResourceDictionary styleResourceDictionary = null;
        [DataMember]
        public Bus ConnectorBusItem
        {
            get { return busItem; }
            set
            {
                if (value != null)
                {
                    busItem = value;
                }
            }
        }

        public CoreConnector()
        {
            cases = CustomContentControl.getCurrentCase();
            BL.WireBL.WireBL wireBL = new BL.WireBL.WireBL();
            wireItem = wireBL.addWire(cases);
        }

        
       
        public void setType(string condef)
        {
            this.Type = condef;
            if (condef == "Bus")
            {
                BusBL busBL = new BusBL();
                if (busItem != null)
                {
                    busBL.createBus(busItem, cases);
                }
                else
                {
                    //Number += 1;
                    busItem = busBL.addBus(cases);
                }

                this.Name = "Bus" + busItem.BusNumber;
                this.wireItem.Type = StabilityType.Bus.ToString();
                busItem.BusName = this.Name;
                styleResourceDictionary = new ResourceDictionary()
                {
                    Source = new Uri(@"/GUI;component/New_concept_WPF/StyleResource.xaml", UriKind.RelativeOrAbsolute)
                };
            }
            else
            {
                this.Name = condef;
                this.wireItem.Type = StabilityType.Wire.ToString();
                //BL.WireBL.WireBL wireBL = new BL.WireBL.WireBL();
                //wireItem = wireBL.addWire(cases);
                //if (this.SourcePort != null)
                //{
                //    wireItem.from = ((this.SourcePort as CustomPort).Node as NodeViewModel).Name;
                //}
                //else if (this.SourceConnector != null)
                //{
                //    wireItem.from = (this.SourceConnector as CoreConnector).Name;
                //}

                //if (this.TargetPort != null)
                //{
                //    wireItem.to = ((this.TargetPort as CustomPort).Node as NodeViewModel).Name;
                //}
                //else if (this.TargetConnector != null)
                //{
                //    wireItem.to = (this.SourceConnector as CoreConnector).Name;
                //}
            }
            label.Content = condef == "Bus" ? "Bus " + busItem.BusNumber : condef;
            //this.Name = condef == "Bus" ? "Bus" + Number : condef;
            label.Offset = new Point(0, -1);
            label.Length = 0.5;
            this.Type = condef;
            label.ReadOnly = true;
            label.Constraints = AnnotationConstraints.Default & ~(AnnotationConstraints.Editable | AnnotationConstraints.InheritEditable) & ~(AnnotationConstraints.Selectable | AnnotationConstraints.InheritSelectable);
            this.Annotations = new ObservableCollection<IAnnotation>() {
                label,
            };

        }

        public string getType() {
            return this.Type;
        }

        public Case getCase()
        {
            return this.cases;
        }

        public void setCase(Case cases)
        {
            this.cases = cases;
        }
        public Bus getBus()
        {
            return this.busItem;
        }

        public Wire getWire()
        {
            return this.wireItem;
        }

        public void setWireFrom(object from)
        {
            this.wireItem.from = from;
        }

        public object getWireFrom()
        {
            return this.wireItem.from;
        }

        public void setWireTo(object to)
        {
            this.wireItem.to = to;
        }

        public object getWireTo()
        {
            return this.wireItem.to;
        }

        public void setWireType(string type)
        {
            this.wireItem.Type = type;
        }

        public object getWireType()
        {
            return this.wireItem.Type;
        }


        ObservableCollection<ConnectorViewModel> RelatedConnectors = new ObservableCollection<ConnectorViewModel>();

        public void setInserviceBus(bool isInservice)
        {
            if (isInservice)
            {
                RelatedConnectors.Clear();
                this.ConnectorGeometryStyle = this.styleResourceDictionary["CustomConnectorStyle"] as Style;

                if ((Main_Menu.GetCurrentDiagram().SelectedItems as SelectorViewModel).SelectedItem is CoreConnector)
                {
                    if (((Main_Menu.GetCurrentDiagram().SelectedItems as SelectorViewModel).SelectedItem as CoreConnector).Name.Contains("Bus"))
                    {

                        ConnectorViewModel selectedconnector = (Main_Menu.GetCurrentDiagram().SelectedItems as SelectorViewModel).SelectedItem as ConnectorViewModel;

                        if (selectedconnector.Ports != null && selectedconnector.Ports is PortCollection)
                        {
                            foreach (ConnectorPortViewModel port in selectedconnector.Ports as PortCollection)
                            {
                                foreach (ConnectorViewModel conns in (port.Info as IConnectorPortInfo).InConnectors as IEnumerable<IConnector>)
                                {
                                    (conns as CoreConnector).Status = "IN";
                                    RelatedConnectors.Add(conns);
                                }

                                foreach (ConnectorViewModel conns in (port.Info as IConnectorPortInfo).OutConnectors as IEnumerable<IConnector>)
                                {
                                    (conns as CoreConnector).Status = "OUT";
                                    RelatedConnectors.Add(conns);
                                }
                            }
                        }
                    }

                    foreach (ConnectorViewModel elem in RelatedConnectors)
                    {
                        elem.ConnectorGeometryStyle = this.styleResourceDictionary["InactiveConnectorStyle"] as Style;
                        if ((elem as CoreConnector).Status.Contains("IN"))
                        {
                            (elem as CoreConnector).SourceDecoratorStyle = styleResourceDictionary["DecoratorFailStyle"] as Style;
                        }
                        else
                        {
                            (elem as CoreConnector).TargetDecoratorStyle = styleResourceDictionary["DecoratorFailStyle"] as Style;
                        }
                    }

                }


                //if ((this.Info as INodeInfo) != null) {
                //    System.Diagnostics.Debug.WriteLine("inodeInfo not null");
                //}

                //if ((this.Info as INodePortInfo) != null)
                //{
                //    System.Diagnostics.Debug.WriteLine("inodePortInfo not null");
                //}
                //if ((this.Info as INodePort) != null)
                //{
                //    System.Diagnostics.Debug.WriteLine("inodePort not null");
                //}
                //if ((this.Info as INode) != null)
                //{
                //    System.Diagnostics.Debug.WriteLine("inode not null");
                //}
                //foreach (ConnectorViewModel elm in this.Ports) {

                //    elm.ConnectorGeometryStyle = this.styleResourceDictionary["InactiveConnectorStyle"] as Style;

                //}




                //for (int i = 0; i < 4; i++) {
                //    System.Diagnostics.Debug.WriteLine((this.Ports as NodePortViewModel).Node.ToString()); 
                //};



            }
            else
            {
                RelatedConnectors.Clear();
                this.ConnectorGeometryStyle = this.styleResourceDictionary["DefaultConnectorStyle"] as Style;
                if ((Main_Menu.GetCurrentDiagram().SelectedItems as SelectorViewModel).SelectedItem is CoreConnector)
                {
                    if (((Main_Menu.GetCurrentDiagram().SelectedItems as SelectorViewModel).SelectedItem as CoreConnector).Name.Contains("Bus"))
                    {

                        ConnectorViewModel selectedconnector = (Main_Menu.GetCurrentDiagram().SelectedItems as SelectorViewModel).SelectedItem as ConnectorViewModel;

                        if (selectedconnector.Ports != null && selectedconnector.Ports is PortCollection)
                        {
                            foreach (ConnectorPortViewModel port in selectedconnector.Ports as PortCollection)
                            {
                                foreach (ConnectorViewModel conns in (port.Info as IConnectorPortInfo).InConnectors as IEnumerable<IConnector>)
                                {
                                    (conns as CoreConnector).Status = "IN";
                                    RelatedConnectors.Add(conns);
                                }

                                foreach (ConnectorViewModel conns in (port.Info as IConnectorPortInfo).OutConnectors as IEnumerable<IConnector>)
                                {
                                    (conns as CoreConnector).Status = "OUT";
                                    RelatedConnectors.Add(conns);
                                }
                            }
                        }
                    }

                    foreach (ConnectorViewModel elem in RelatedConnectors)
                    {
                        elem.ConnectorGeometryStyle = this.styleResourceDictionary["ActiveConnectorStyle"] as Style;
                        if ((elem as CoreConnector).Status.Contains("IN"))
                        {
                            (elem as CoreConnector).SourceDecoratorStyle = styleResourceDictionary["DecoratorSuccessStyle"] as Style;
                        }
                        else
                        {
                            (elem as CoreConnector).TargetDecoratorStyle = styleResourceDictionary["DecoratorSuccessStyle"] as Style;
                        }
                    }

                }

            }
        }

    }
}
