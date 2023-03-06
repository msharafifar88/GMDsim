using areaandzone;
using bases;
using fluxModel;
using persistent.enumeration;
using persistent.enumeration.Transformer;
using persistent.network;
using persistent.network.Calculation_entitiy.Transformer;
using persistent.network.Transformers;
using System.Collections.Generic;

namespace network
{
    public class MainTransformers : BaseEntity
    {
        private static List<double> currentList = new List<double>() { 0.002, 0.01, 0.025, 0.05, 0.1, 2.0 };
        private static List<double> fluxList = new List<double>() { 1, 1.075, 1.15, 1.2, 1.23, 1.72 };
        static List<CurrentFlux> temp = new List<CurrentFlux>() {
            new CurrentFlux(currentList[0], fluxList[0]),
            new CurrentFlux(currentList[1], fluxList[1]),
            new CurrentFlux(currentList[2], fluxList[2]),
            new CurrentFlux(currentList[3], fluxList[3]),
            new CurrentFlux(currentList[4], fluxList[4]),
            new CurrentFlux(currentList[5], fluxList[5])};

        public string name { get; set; }
        public float nominalFrequency { get; set; } = 60;
        public long number { get; set; } = 1L;
        public string type { get; set; }
        public double fluxoPhaseA { get; set; } = 0;
        public int fluxoPhaseAUnit { get; set; } = 1;
        public string Identity { get; set; }
        public bool Inservice { get; set; } = true;
        public double fluxoPhaseB { get; set; } = 0;
        public int fluxoPhaseBUnit { get; set; } = 1;
        public double fluxoPhaseC { get; set; } = 0;
        public int fluxoPhaseCUnit { get; set; } = 1;
        public long magResistance { get; set; } = 500;
        public int magResistanceUnit { get; set; } = 4;
        public bool ExcludeMagModel { get; set; } = true;
        public int currentFluxUnit { get; set; } = 1;
        public bool nominalInductanceVoltage { get; set; } = false;
        public bool nominalInductanceCurrent { get; set; } = false;
        public bool nominalInductanceFlux { get; set; } = false;
        public int windingRUnit { get; set; } = 4;
        public int windingXUnit { get; set; } = 4;
        public List<CurrentFlux> currentFluxes { get; set; } = temp;
        //        public Area area { get; set; }
        //        public Zone zone { get; set; }
        public Substations substation { get; set; } = new Substations();
        public Bus PrimaryBUS { get; set; }

        public Bus SecondaryBUS { get; set; }
        public Bus TertiaryBUS { get; set; }
        public NominalData nominalData { get; set; } = new NominalData();

        public TransformerType transformertype { get; set; } = TransformerType.ThreePhase;

        public CoreConstruction coreConstruction { get; set; } = CoreConstruction.ThreeLeggedCoreType;
        //   public TransformerImpedance transformerImpedance { get; set; } = new TransformerImpedance();
        public LTCControl ltccontrol { get; set; } = new LTCControl();

        public Impedances impedances { get; set; } = new Impedances();
        public MVALimits mvalimits { get; set; } = new MVALimits();
        public Topology topology { get; set; } = new Topology();
        public TestData testData { get; set; } = new TestData();
        public EMT emt { get; set; } = new EMT();
        public Reliability reliability { get; set; } = new Reliability();
        public PSSETransmorerTypeIO pSSETransmorerTypeIO { get; set; } = new PSSETransmorerTypeIO();
        public TemperaturesLimits tempLimits { get; set; } = new TemperaturesLimits();
        public List<Owner> ownerList { get; set; } = new List<Owner>(7);
        public Transformer_pu transformer_pu { get; set; } = new Transformer_pu();

        public bool X1R1check { get; set; } = false;
        public bool PSCcheck { get; set; } = true;
        public bool ZeroSeqAvailable { get; set; } = true;

        public bool no_load { get; set; } = false;

        public bool magnetization { get; set; } = true;




    }
}
