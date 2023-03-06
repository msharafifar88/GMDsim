using GUI.New_concept_WPF;
using network;
using persistent;
using Syncfusion.UI.Xaml.Diagram;
using System;

namespace Shapes.Line
{
    abstract class AbstractLineShape : NodeViewModel, ICloneable
    {
        protected Case cases;
        public AbstractLineShape()
        {
            cases = CustomContentControl.getCurrentCase();
        }
        public abstract void setLabel(string name);
        public abstract LineBranches getNodeObject();
        public abstract void setNodeObject(LineBranches linebranch);
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
