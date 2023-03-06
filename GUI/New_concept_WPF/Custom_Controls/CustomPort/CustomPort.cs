using Syncfusion.UI.Xaml.Diagram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GUI.New_concept_WPF.Custom_Controls.CustomPort
{
    public class CustomPort : NodePortViewModel
    {
        private string owner_;
        private string name_;
        private int maxConn = 1;
        private bool infiniteConn = false;
        //private List<NodeViewModel> nodeSrc;
        //private List<CoreConnector> connSrc;
        [DataMember]
        public string Owner
        {
            get
            {
                return owner_;
            }
            set
            {
                owner_ = value;
            }
        }
        [DataMember]
        public string Name
        {
            get
            {
                return name_;
            }
            set
            {
                name_ = value;
            }
        }
        [DataMember]
        public int MaxConn
        {
            get
            {
                return maxConn;
            }
            set
            {
                maxConn = value;
            }
        }
        [DataMember]
        public bool InfiniteConn
        {
            get
            {
                return infiniteConn;
            }
            set
            {
                infiniteConn = value;
            }
        }
        public CustomPort()
        {
            //Enabling ConnectionDirection constraint to the port(green color circle)
            Constraints |= PortConstraints.ConnectionDirection;

            //Specifying connection direction as top.

            ConnectionDirection = ConnectionDirection.Top;

        }
        public CustomPort(bool isUnlimited = false, int conns = 1) {

            Constraints |= PortConstraints.ConnectionDirection;

            ConnectionDirection = ConnectionDirection.Top;
            
            if (isUnlimited)
            {
                infiniteConn = isUnlimited;
                maxConn = -999;
            }
            else {
                maxConn = conns;
            }
            
        }

        public bool CanConnect()
        {
            if (this.Info is INodePortInfo)
            {
                var connectors = (this.Info as INodePortInfo).Connectors;
                return (connectors == null || connectors.Count() < maxConn || infiniteConn) ? true : false;
            }

            return true;
        }

        public int getCount() {

            return (this.Info as INodePortInfo).Connectors.Count();
        }

    }
}
