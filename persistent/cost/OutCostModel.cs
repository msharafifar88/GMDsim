using persistent.enumeration;

namespace persistent.cost
{
    public class OutCostModel
    {
        private long id { get; set; }
        private CostModel costModel { get; set; }
        private float UnitFuelCost { get; set; }
        private float variable { get; set; }
        private float IndependentValue { get; set; }
        private float DependentValue { get; set; }
    }
}
