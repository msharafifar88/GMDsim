using BL;
using GUI.customDocumentWindow;
using GUI.New_concept_WPF;
using network;
using persistent;
using persistent.enumeration;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Diagrams;

namespace GUI.Rlc
{
    abstract class AbstractRLCShape : RadDiagramShape
    {
        protected Case cases;
        public AbstractRLCShape(){
            cases = CustomContentControl.getCurrentCase();
            this.UseDefaultConnectors = false;  
        }
        public abstract void setLabel(string name);
        public abstract RLCbranches getRlcBranch();
        public abstract void setRlcBranch(RLCbranches rlcbranch);
        public Case getCase()
        {
            return this.cases;
        }
        public void setCase(Case cases)
        {
            this.cases = cases;
        }

    }
}
