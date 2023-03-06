namespace DAO
{
    using areaandzone;
    using bases;
    using display;
    using fluxModel;
    using network;
    using network.generator.Gentype;
    using persistent.network;
    using persistent.network.Geo_Zone;
    using persistent.network.load_entitiy;
    using persistent.network.wire;
    using System.Data.Entity;

    public class GmdsimModel : DbContext
    {
        // Your context has been configured to use a 'GmdsimModel' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'DAO.GmdsimModel' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'GmdsimModel' 
        // connection string in the application configuration file.
        public GmdsimModel()
            : base("name=gmdsimConnection")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public virtual DbSet<Bus> Buses { get; set; }
        public virtual DbSet<BusInformation> BusInformations { get; set; }
        public virtual DbSet<Display> Displays { get; set; }
        public virtual DbSet<Property> Properties { get; set; }
        public virtual DbSet<Generator> Generators { get; set; }
        public virtual DbSet<WindGen> WindGens { get; set; }
        public virtual DbSet<SyncGen> SyncGens { get; set; }
        public virtual DbSet<PVGen> PVGens { get; set; }
        public virtual DbSet<Loads> Loads { get; set; }
        public virtual DbSet<EV> EVlist { get; set; }
        public virtual DbSet<Area> Areas { get; set; }
        public virtual DbSet<Zone> Zones { get; set; }
        public virtual DbSet<Owner> Owners { get; set; }
        public virtual DbSet<RLC> RLCs { get; set; }
        public virtual DbSet<RL> RLs { get; set; }
        public virtual DbSet<LC> LCs { get; set; }
        public virtual DbSet<R> Resistances { get; set; }
        public virtual DbSet<L> Inductances { get; set; }
        public virtual DbSet<C> Capacitances { get; set; }
        public virtual DbSet<Single3phaseLine> Single3phaseLines { get; set; }
        public virtual DbSet<DoubleCircuitLine> BiLines { get; set; }
        public virtual DbSet<MultiPhaseLine> TriLines { get; set; }
        public virtual DbSet<TTransformer> CustomTransformers { get; set; }
        public virtual DbSet<C3WTransformer> TriTransformers { get; set; }
        public virtual DbSet<YgYgDTransformer> YgYgDTransformers { get; set; }
        public virtual DbSet<YgDDTransformer> YgDDTransformers { get; set; }
        public virtual DbSet<YgDTransformer> YgDTransformers { get; set; }
        public virtual DbSet<SwitchBranches> SwitchedShunts { get; set; }
        public virtual DbSet<CurrentFlux> CurrentFluxes { get; set; }
        public virtual DbSet<Substations> Substations { get; set; }
        public virtual DbSet<C2WTransformer> Custom2WTransformers { get; set; }
        public virtual DbSet<GeoZone> GeoZones { get; set; }
        public virtual DbSet<Wire> wires { get; set; }

    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}