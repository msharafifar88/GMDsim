using GUI.New_concept_WPF;
using network;
using persistent;
using Syncfusion.UI.Xaml.Diagram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes.RLC
{
    abstract class AbstractRLCCShape : NodeViewModel, ICloneable
    {
        protected Case cases;
        protected bool isClonedOne;
       
        public AbstractRLCCShape()
        {
            cases = CustomContentControl.getCurrentCase();
        }
        public abstract void setLabel(string name);
        public abstract RLCbranches getRLCBranch();
        public abstract void setRLCBranch(RLCbranches rlcbranch);
        public abstract object Clone();

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
