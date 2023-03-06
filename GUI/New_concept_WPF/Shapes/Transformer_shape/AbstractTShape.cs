using GUI.New_concept_WPF;
using network;
using persistent;
using Syncfusion.UI.Xaml.Diagram;
using System;

namespace Shapes.Transformer
{
    abstract class AbstractTShape : NodeViewModel, ICloneable
    {
        protected Case cases;
        protected bool isClonedOne;

        public AbstractTShape()
        {
            cases = CustomContentControl.getCurrentCase();
        }
        public abstract void setLabel(string name);
        public abstract MainTransformers getTransformerType();
        public abstract void setTransformerType(MainTransformers transformer);
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
