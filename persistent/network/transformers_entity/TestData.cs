using bases;
using persistent.enumeration.Transformer;
using System.Collections.Generic;

namespace persistent.network.Transformers
{
    public class TestData : BaseEntity
    {


        public ExcitedWindingEnum excitedWinding { get; set; }
        public List<QGICCharacteristic> qGICs { get; set; }
        public List<CurrentVoltageLossUnit> currentVoltageLossUnits { get; set; }

        public WindingDCResistances windingDCResistances { get; set; } = new WindingDCResistances();
        public WindingCapacitances windingCapacitances { get; set; } = new WindingCapacitances();
        public ZeroSequenceImpedanceMeasurement zeroSequenceImpedance { get; set; }
        public ZeroSequenceCharacteristc sequenceCharacteristc { get; set; }
        public ExcitedWindingEnum Zero_Seq_Char_ExcitedWinding { get; set; }
        public GrandientPanel grandientPanel { get; set; } = new GrandientPanel();
        public HypsteresisCharacteristic hypsteresisCharacteristic { get; set; } = new HypsteresisCharacteristic();
        public double HysteresisLoss { get; set; }
        public double EddyCurrentLoss { get; set; }
    }
}
