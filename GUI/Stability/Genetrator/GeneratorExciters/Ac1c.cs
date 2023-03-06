using persistent.stability;

namespace GUI.Stability.GeneratorExciters
{
    public partial class Ac1c : StabilityForm
    {
        public AC1C ac1c;
        public Ac1c()
        {
            InitializeComponent();
            ac1c = new AC1C();
            base.stability = ac1c;

        }


    }
}
