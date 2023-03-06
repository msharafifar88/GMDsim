using persistent.stability;

namespace GUI.Stability.Generator_Stability
{
    public partial class GenSAL : StabilityForm
    {

        public GENSAL genSAL;
        public GenSAL()
        {

            InitializeComponent();
            genSAL = new GENSAL();
            base.stability = genSAL;

        }
    }
}
