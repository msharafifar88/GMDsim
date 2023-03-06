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

namespace GUI.Transformer
{
    abstract class AbstractTRShape : RadDiagramShape
    {
        protected Case cases;
        public AbstractTRShape()
        {
            cases = CustomContentControl.getCurrentCase();
            this.UseDefaultConnectors = false;
        }
        public abstract void setLabel(string name);
        public abstract MainTransformers getTransformerType();
        public abstract void setTransformerType(MainTransformers transformer);
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
