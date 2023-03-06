using areaandzone;
using network;
using network.generator.Gentype;
using persistent;
using persistent.common;
using persistent.network;
using persistent.network.Geo_Zone;
using persistent.network.load_entitiy;
using persistent.network.wire;
using System;
using System.Collections.Generic;

namespace DAO
{
    public class DataStored
    {
        static private List<Case> Cases = new List<Case>();
        // static Dictionary<Case, List<T>> general = new Dictionary<Case, List<T>>();
        static Dictionary<Case, List<Bus>> buses = new Dictionary<Case, List<Bus>>();
        static Dictionary<Case, List<Loads>> loads = new Dictionary<Case, List<Loads>>();
        static Dictionary<Case, List<EV>> evLists = new Dictionary<Case, List<EV>>();
        static Dictionary<Case, List<Generator>> generators = new Dictionary<Case, List<Generator>>();
        static Dictionary<Case, List<SyncGen>> syncGens = new Dictionary<Case, List<SyncGen>>();
        static Dictionary<Case, List<WindGen>> windGens = new Dictionary<Case, List<WindGen>>();
        static Dictionary<Case, List<PVGen>> pvGens = new Dictionary<Case, List<PVGen>>();

        internal static void editWire(Wire wire, Case cases)
        {
            throw new NotImplementedException();
        }

        static Dictionary<Case, List<RLC>> rlcs = new Dictionary<Case, List<RLC>>();
        static Dictionary<Case, List<R>> resistances = new Dictionary<Case, List<R>>();
        static Dictionary<Case, List<L>> inductances = new Dictionary<Case, List<L>>();
        static Dictionary<Case, List<C>> capacitances = new Dictionary<Case, List<C>>();
        static Dictionary<Case, List<RL>> rls = new Dictionary<Case, List<RL>>();
        static Dictionary<Case, List<LC>> lcs = new Dictionary<Case, List<LC>>();
        static Dictionary<Case, List<Single3phaseLine>> single3phaseLines = new Dictionary<Case, List<Single3phaseLine>>();
        static Dictionary<Case, List<DoubleCircuitLine>> doubleCircuitLines = new Dictionary<Case, List<DoubleCircuitLine>>();
        static Dictionary<Case, List<MultiPhaseLine>> multiPhaseLines = new Dictionary<Case, List<MultiPhaseLine>>();
        static Dictionary<Case, List<SwitchBranches>> switchedShunts = new Dictionary<Case, List<SwitchBranches>>();
        static Dictionary<Case, List<TTransformer>> customTransformers = new Dictionary<Case, List<TTransformer>>();
        static Dictionary<Case, List<C3WTransformer>> tritranformers = new Dictionary<Case, List<C3WTransformer>>();
        static Dictionary<Case, List<YgDDTransformer>> ygDDTransformers = new Dictionary<Case, List<YgDDTransformer>>();
        static Dictionary<Case, List<Wire>> wires = new Dictionary<Case, List<Wire>>();
        static Dictionary<Case, List<YgYgDTransformer>> ygYgDTransformers = new Dictionary<Case, List<YgYgDTransformer>>();
        static Dictionary<Case, List<C2WTransformer>> custom2WTransformers = new Dictionary<Case, List<C2WTransformer>>();
        static Dictionary<Case, List<YgDTransformer>> ygDTransformers = new Dictionary<Case, List<YgDTransformer>>();
        static ISet<Area> areas = new HashSet<Area>();
        static ISet<Substations> substations = new HashSet<Substations>();
        static ISet<GeoZone> geozones = new HashSet<GeoZone>();
        static ISet<Zone> zones = new HashSet<Zone>();
        static ISet<Owner> owners = new HashSet<Owner>();
        static ISet<GMDSimTreeNode> rootTree = new HashSet<GMDSimTreeNode>();
        static Dictionary<GMDSimTreeNode, List<GMDSimTreeNode>> MapChild = new Dictionary<GMDSimTreeNode, List<GMDSimTreeNode>>();
        static Dictionary<GMDSimTreeNode, string> MapImage = new Dictionary<GMDSimTreeNode, string>();


        /* Case action*/
        public static ICollection<Case> findAllCase()
        {
            return Cases;
        }
        public static void addCase(Case cases)
        {
            Cases.Add(cases);
        }
        public static void removeCase(Case cases)
        {
            Cases.Remove(cases);
        }
        public static void removeAllCase()
        {
            Cases.Clear();
        }
        public static Case findCase(string name)

        {
            foreach (Case cases in Cases)
            {
                if (cases.name.Equals(name))
                {
                    return cases;
                }
            }
            return null;
        }


        /* Bus Action*/
        public static ICollection<Bus> findAllBuses(Case cases)
        {
            return DataStoredUtils.findAll(cases, buses);

        }
        public static void addBus(Bus bus, Case cases)
        {
            DataStoredUtils.add(bus, cases, buses);
        }
        public static void editBus(Bus bus, Case cases)
        {
            DataStoredUtils.edit(bus, cases, buses);
        }

        public static void removeBus(Bus bus, Case cases)
        {
            DataStoredUtils.remove(bus, cases, buses);

        }
        public static void removeAllBuses(Case cases)
        {
            DataStoredUtils.removeAll(cases, buses);
        }

        /* Load action*/
        public static ICollection<Loads> findAllLoads(Case cases)
        {
            return DataStoredUtils.findAll(cases, loads);
        }
        public static void addLoad(Case cases, Loads load)
        {
            DataStoredUtils.add(load, cases, loads);
        }
        public static void editLoad(Case cases, Loads load)
        {
            DataStoredUtils.edit(load, cases, loads);
        }
        public static void removeLoad(Case cases, Loads load)
        {
            DataStoredUtils.remove(load, cases, loads);
        }
        public static void removeAllLoads(Case cases)
        {
            DataStoredUtils.removeAll(cases, loads);
        }


        /* EV action*/
        public static ICollection<EV> findAllEVs(Case cases)
        {
            return DataStoredUtils.findAll(cases, evLists);
        }
        public static void addEV(Case cases, EV ev)
        {
            DataStoredUtils.add(ev, cases, evLists);
        }
        public static void editEV(Case cases, EV ev)
        {
            DataStoredUtils.edit(ev, cases, evLists);
        }
        public static void removeEV(Case cases, EV ev)
        {
            DataStoredUtils.remove(ev, cases, evLists);
        }

        public static void removeAllEVs(Case cases)
        {
            DataStoredUtils.removeAll(cases, evLists);
        }

        /* Generator action*/
        public static ICollection<Generator> findAllGenerator(Case cases)
        {
            return DataStoredUtils.findAll(cases, generators);

        }
        public static void addGenerator(Generator generator, Case cases)
        {
            DataStoredUtils.add(generator, cases, generators);
        }
        public static void editGenerator(Generator generator, Case cases)
        {
            DataStoredUtils.edit(generator, cases, generators);
        }

        public static void removeGenerator(Generator generator, Case cases)
        {
            DataStoredUtils.remove(generator, cases, generators);
        }

        public static void removeAllGenerator(Case cases)
        {
            DataStoredUtils.removeAll(cases, generators);
        }

        /* SyncGen action*/
        public static ICollection<SyncGen> findAllSyncGen(Case cases)
        {
            return DataStoredUtils.findAll(cases, syncGens);

        }
        public static void addSyncGen(SyncGen syncGen, Case cases)
        {
            DataStoredUtils.add(syncGen, cases, syncGens);
        }
        public static void editSyncGen(SyncGen syncGen, Case cases)
        {

            DataStoredUtils.edit(syncGen, cases, syncGens);

        }

        public static void removeSyncGen(SyncGen syncGen, Case cases)
        {
            DataStoredUtils.remove(syncGen, cases, syncGens);
        }

        public static void removeAllSyncGen(Case cases)
        {
            DataStoredUtils.removeAll(cases, syncGens);
        }

        /* WindGen action*/
        public static ICollection<WindGen> findAllWindGen(Case cases)
        {
            return DataStoredUtils.findAll(cases, windGens);

        }
        public static void addwindGen(WindGen windGen, Case cases)
        {
            DataStoredUtils.add(windGen, cases, windGens);
        }
        public static void editWindGen(WindGen windGen, Case cases)
        {

            DataStoredUtils.edit(windGen, cases, windGens);

        }

        public static void removeWindGen(WindGen windGen, Case cases)
        {
            DataStoredUtils.remove(windGen, cases, windGens);
        }
        public static void removeAllWindGen(Case cases)
        {
            DataStoredUtils.removeAll(cases, windGens);
        }

        /* PVGen action*/
        public static ICollection<PVGen> findAllPVGen(Case cases)
        {
            return DataStoredUtils.findAll(cases, pvGens);

        }
        public static void addPVGen(PVGen pvGen, Case cases)
        {
            DataStoredUtils.add(pvGen, cases, pvGens);
        }
        public static void editPVGen(PVGen pvGen, Case cases)
        {

            DataStoredUtils.edit(pvGen, cases, pvGens);

        }

        public static void removePVGen(PVGen pvGen, Case cases)
        {
            DataStoredUtils.remove(pvGen, cases, pvGens);
        }

        public static void removeAllPVGen(Case cases)
        {
            DataStoredUtils.removeAll(cases, pvGens);
        }

        /* RLC action*/
        public static ICollection<RLC> findAllRLC(Case cases)
        {
            return DataStoredUtils.findAll(cases, rlcs);

        }
        public static void addRlc(RLC rlc, Case cases)
        {
            DataStoredUtils.add(rlc, cases, rlcs);
        }
        public static void editRLC(RLC rlc, Case cases)
        {

            DataStoredUtils.edit(rlc, cases, rlcs);

        }

        public static void removeRLC(RLC rlc, Case cases)
        {
            DataStoredUtils.remove(rlc, cases, rlcs);
        }
        public static void removeAllRLC(Case cases)
        {
            DataStoredUtils.removeAll(cases, rlcs);
        }
        /* R actions */

        public static ICollection<R> findAllR(Case cases)
        {
            return DataStoredUtils.findAll(cases, resistances);
        }
        public static void addR(R resistance, Case cases)
        {
            DataStoredUtils.add(resistance, cases, resistances);
        }
        public static void editR(R resistance, Case cases)
        {
            DataStoredUtils.edit(resistance, cases, resistances);
        }
        public static void removeR(R resistance, Case cases)
        {
            DataStoredUtils.remove(resistance, cases, resistances);
        }
        public static void removeAllR(Case cases)
        {
            DataStoredUtils.removeAll(cases, resistances);
        }
        /* L actions */

        public static ICollection<L> findAllL(Case cases)
        {
            return DataStoredUtils.findAll(cases, inductances);
        }
        public static void addL(L inductance, Case cases)
        {
            DataStoredUtils.add(inductance, cases, inductances);
        }
        public static void editL(L inductance, Case cases)
        {
            DataStoredUtils.edit(inductance, cases, inductances);
        }
        public static void removeL(L inductance, Case cases)
        {
            DataStoredUtils.remove(inductance, cases, inductances);
        }
        public static void removeAllL(Case cases)
        {
            DataStoredUtils.removeAll(cases, inductances);
        }

        /* C actions */

        public static ICollection<C> findAllC(Case cases)
        {
            return DataStoredUtils.findAll(cases, capacitances);
        }
        public static void addC(C capacitance, Case cases)
        {
            DataStoredUtils.add(capacitance, cases, capacitances);
        }
        public static void editC(C capacitance, Case cases)
        {
            DataStoredUtils.edit(capacitance, cases, capacitances);
        }
        public static void removeC(C capacitance, Case cases)
        {
            DataStoredUtils.remove(capacitance, cases, capacitances);
        }
        public static void removeAllC(Case cases)
        {
            DataStoredUtils.removeAll(cases, capacitances);
        }

        /* LC actions */

        public static ICollection<LC> findAllLC(Case cases)
        {
            return DataStoredUtils.findAll(cases, lcs);
        }
        public static void addLC(LC lc, Case cases)
        {
            DataStoredUtils.add(lc, cases, lcs);
        }
        public static void editLC(LC lc, Case cases)
        {
            DataStoredUtils.edit(lc, cases, lcs);
        }
        public static void removeLC(LC lc, Case cases)
        {
            DataStoredUtils.remove(lc, cases, lcs);
        }
        public static void removeAllLC(Case cases)
        {
            DataStoredUtils.removeAll(cases, lcs);
        }

        /* RL actions */

        public static ICollection<RL> findAllRL(Case cases)
        {
            return DataStoredUtils.findAll(cases, rls);
        }
        public static void addRL(RL rl, Case cases)
        {
            DataStoredUtils.add(rl, cases, rls);
        }
        public static void editRL(RL rl, Case cases)
        {
            DataStoredUtils.edit(rl, cases, rls);
        }
        public static void removeRL(RL rl, Case cases)
        {
            DataStoredUtils.remove(rl, cases, rls);
        }
        public static void removeAllRL(Case cases)
        {
            DataStoredUtils.removeAll(cases, rls);
        }

        /* Single3phaseLine actions */

        public static ICollection<Single3phaseLine> findAllSingle3phaseLine(Case cases)
        {
            return DataStoredUtils.findAll(cases, single3phaseLines);
        }
        public static void addSingle3phaseLine(Single3phaseLine monoLine, Case cases)
        {
            DataStoredUtils.add(monoLine, cases, single3phaseLines);
        }
        public static void editSingle3phaseLine(Single3phaseLine monoLine, Case cases)
        {
            DataStoredUtils.edit(monoLine, cases, single3phaseLines);
        }
        public static void removeSingle3phaseLine(Single3phaseLine monoLine, Case cases)
        {
            DataStoredUtils.remove(monoLine, cases, single3phaseLines);
        }
        public static void removeAllSingle3phaseLine(Case cases)
        {
            DataStoredUtils.removeAll(cases, single3phaseLines);
        }

        /* DoubleCircuitLine actions */

        public static ICollection<DoubleCircuitLine> findAllDoubleCircuitLine(Case cases)
        {
            return DataStoredUtils.findAll(cases, doubleCircuitLines);
        }
        public static void addDoubleCircuitLine(DoubleCircuitLine biLine, Case cases)
        {
            DataStoredUtils.add(biLine, cases, doubleCircuitLines);
        }
        public static void editDoubleCircuitLine(DoubleCircuitLine biLine, Case cases)
        {
            DataStoredUtils.edit(biLine, cases, doubleCircuitLines);
        }
        public static void removeDoubleCircuitLine(DoubleCircuitLine biLine, Case cases)
        {
            DataStoredUtils.remove(biLine, cases, doubleCircuitLines);
        }
        public static void removeAllDoubleCircuitLine(Case cases)
        {
            DataStoredUtils.removeAll(cases, doubleCircuitLines);
        }

        /* MultiPhaseLine actions */

        public static ICollection<MultiPhaseLine> findAllMultiPhaseLine(Case cases)
        {
            return DataStoredUtils.findAll(cases, multiPhaseLines);
        }
        public static void addMultiPhaseLine(MultiPhaseLine triLine, Case cases)
        {
            DataStoredUtils.add(triLine, cases, multiPhaseLines);
        }
        public static void editMultiPhaseLine(MultiPhaseLine triLine, Case cases)
        {
            DataStoredUtils.edit(triLine, cases, multiPhaseLines);
        }
        public static void removeMultiPhaseLine(MultiPhaseLine triLine, Case cases)
        {
            DataStoredUtils.remove(triLine, cases, multiPhaseLines);
        }
        public static void removeAllMultiPhaseLine(Case cases)
        {
            DataStoredUtils.removeAll(cases, multiPhaseLines);
        }

        /* SwitchBranches actions */

        public static ICollection<SwitchBranches> findAllSwitchedShunt(Case cases)
        {
            return DataStoredUtils.findAll(cases, switchedShunts);
        }
        public static void addSwitchedShunt(SwitchBranches switchedShunt, Case cases)
        {
            DataStoredUtils.add(switchedShunt, cases, switchedShunts);
        }
        public static void editSwitchedShunt(SwitchBranches switchedShunt, Case cases)
        {
            DataStoredUtils.edit(switchedShunt, cases, switchedShunts);
        }
        public static void removeSwitchedShunt(SwitchBranches switchedShunt, Case cases)
        {
            DataStoredUtils.remove(switchedShunt, cases, switchedShunts);
        }
        public static void removeAllSwitchedShunt(Case cases)
        {
            DataStoredUtils.removeAll(cases, switchedShunts);
        }

        /* TTransformer actions */

        public static ICollection<TTransformer> findAllTTransformer(Case cases)
        {
            return DataStoredUtils.findAll(cases, customTransformers);
        }
        public static void addTTransformer(TTransformer customTransformer, Case cases)
        {
            DataStoredUtils.add(customTransformer, cases, customTransformers);
        }
        public static void editTTransformer(TTransformer customTransformer, Case cases)
        {
            DataStoredUtils.edit(customTransformer, cases, customTransformers);
        }
        public static void removeTTransformer(TTransformer customTransformer, Case cases)
        {
            DataStoredUtils.remove(customTransformer, cases, customTransformers);
        }
        public static void removeAllTTransformer(Case cases)
        {
            DataStoredUtils.removeAll(cases, customTransformers);
        }

        /* C2Wransformer actions */

        public static ICollection<C2WTransformer> findAllC2WTransformer(Case cases)
        {
            return DataStoredUtils.findAll(cases, custom2WTransformers);
        }
        public static void addC2WTransformer(C2WTransformer customTransformer, Case cases)
        {
            DataStoredUtils.add(customTransformer, cases, custom2WTransformers);
        }
        public static void editC2WTransformer(C2WTransformer customTransformer, Case cases)
        {
            DataStoredUtils.edit(customTransformer, cases, custom2WTransformers);
        }
        public static void removeC2WTransformer(C2WTransformer customTransformer, Case cases)
        {
            DataStoredUtils.remove(customTransformer, cases, custom2WTransformers);
        }
        public static void removeAllC2WTransformer(Case cases)
        {
            DataStoredUtils.removeAll(cases, custom2WTransformers);
        }

        /* TriTransformer actions */

        public static ICollection<C3WTransformer> findAllTriTransformer(Case cases)
        {
            return DataStoredUtils.findAll(cases, tritranformers);
        }
        public static void addTriTransformer(C3WTransformer tritranformer, Case cases)
        {
            DataStoredUtils.add(tritranformer, cases, tritranformers);
        }
        public static void editTriTransformer(C3WTransformer tritranformer, Case cases)
        {
            DataStoredUtils.edit(tritranformer, cases, tritranformers);
        }
        public static void removeTriTransformer(C3WTransformer tritranformer, Case cases)
        {
            DataStoredUtils.remove(tritranformer, cases, tritranformers);
        }
        public static void removeAllTriTransformer(Case cases)
        {
            DataStoredUtils.removeAll(cases, tritranformers);
        }

        /* YgDDTransformer actions */

        public static ICollection<YgDDTransformer> findAllYgDDTransformer(Case cases)
        {
            return DataStoredUtils.findAll(cases, ygDDTransformers);
        }
        public static void addYgDDTransformer(YgDDTransformer ygDDTransformer, Case cases)
        {
            DataStoredUtils.add(ygDDTransformer, cases, ygDDTransformers);
        }
        public static void editYgDDTransformer(YgDDTransformer ygDDTransformer, Case cases)
        {
            DataStoredUtils.edit(ygDDTransformer, cases, ygDDTransformers);
        }
        public static void removeYgDDTransformer(YgDDTransformer ygDDTransformer, Case cases)
        {
            DataStoredUtils.remove(ygDDTransformer, cases, ygDDTransformers);
        }

        public static void removeAllYgDDTransformer(Case cases)
        {
            DataStoredUtils.removeAll(cases, ygDDTransformers);
        }
        /* YgDTransformer actions */

        public static ICollection<YgDTransformer> findAllYgDTransformer(Case cases)
        {
            return DataStoredUtils.findAll(cases, ygDTransformers);
        }
        public static void addYgDTransformer(YgDTransformer ygDTransformer, Case cases)
        {
            DataStoredUtils.add(ygDTransformer, cases, ygDTransformers);
        }
        public static void editYgDTransformer(YgDTransformer ygDTransformer, Case cases)
        {
            DataStoredUtils.edit(ygDTransformer, cases, ygDTransformers);
        }
        public static void removeYgDTransformer(YgDTransformer ygDTransformer, Case cases)
        {
            DataStoredUtils.remove(ygDTransformer, cases, ygDTransformers);
        }
        public static void removeAllYgDTransformer(Case cases)
        {
            DataStoredUtils.removeAll(cases, ygDTransformers);
        }
        /* YgYgTransformer actions */

        public static ICollection<YgYgDTransformer> findAllYgYgDTransformer(Case cases)
        {
            return DataStoredUtils.findAll(cases, ygYgDTransformers);
        }
        public static void addYgYgDTransformer(YgYgDTransformer ygYgDTransformer, Case cases)
        {
            DataStoredUtils.add(ygYgDTransformer, cases, ygYgDTransformers);
        }
        public static void editYgYgDTransformer(YgYgDTransformer ygYgDTransformer, Case cases)
        {
            DataStoredUtils.edit(ygYgDTransformer, cases, ygYgDTransformers);
        }
        public static void removeYgYgDTransformer(YgYgDTransformer ygYgDTransformer, Case cases)
        {
            DataStoredUtils.remove(ygYgDTransformer, cases, ygYgDTransformers);
        }
        public static void removeAllYgYgDTransformer(Case cases)
        {
            DataStoredUtils.removeAll(cases, ygYgDTransformers);
        }

        /* Area Action action*/
        public static ICollection<Area> findAllArea()
        {
            return areas;
        }
        public static void addArea(Area area)
        {
            areas.Add(area);
        }

        public static void removeArea(Area area)
        {
            areas.Remove(area);
        }
        public static void removeAllArea()
        {
            areas.Clear();
        }
        /* Substation Action action*/
        public static ICollection<Substations> findAllSubstation()
        {
            return substations;
        }
        public static void addSubstation(Substations substation)
        {
            substations.Add(substation);
        }

        public static void removeSubstation(Substations substation)
        {
            substations.Remove(substation);
        }
        public static void removeAllSubstation()
        {
            substations.Clear();
        }
        /* Zone Action action*/
        public static ICollection<Zone> findAllZone()
        {
            return zones;
        }
        public static void addZone(Zone zone)
        {
            zones.Add(zone);
        }

        public static void removeZone(Zone zone)
        {
            zones.Remove(zone);
        }
        public static void removeAllZone()
        {
            zones.Clear();
        }
        /* Owner Action action*/
        public static ICollection<Owner> findAllOwner()
        {
            return owners;
        }
        public static void addOwner(Owner owner)
        {
            owners.Add(owner);
        }

        public static void removeOwner(Owner owner)
        {
            owners.Remove(owner);
        }
        public static void removeAllOwner()
        {
            owners.Clear();
        }
        // wire action
        public static ICollection<Wire> findAllwires(Case cases)
        {
            return DataStoredUtils.findAll(cases, wires);
        }
        public static void addWire(Case cases, Wire wire)
        {
            DataStoredUtils.add(wire, cases, wires);
        }
        public static void editWire(Case cases, Wire wire)
        {
            DataStoredUtils.edit(wire, cases, wires);
        }
        public static void removeWire(Case cases, Wire wire)
        {
            DataStoredUtils.remove(wire, cases, wires);
        }
        public static void removeAllWire(Case cases)
        {
            DataStoredUtils.removeAll(cases, wires);
        }

        //Geozone
        public static ICollection<GeoZone> findAllGeoZone()
        {
            return geozones;
        }
        public static void addGeoZone(GeoZone geozone)
        {
            geozones.Add(geozone);
        }

        public static void removeGeoZone(GeoZone geozone)
        {
            geozones.Remove(geozone);
        }
        public static void removeAllGeoZone()
        {
            geozones.Clear();
        }
        /* Create  Tree Data*/
        public static void addRootNode()
        {
            GMDSimTreeNode node = new GMDSimTreeNode(persistent.common.ItemEnum.root, "Machines", null);
            MapChild.Add(node, new List<GMDSimTreeNode>()

                                        {
                     new GMDSimTreeNode(persistent.common.ItemEnum.Generator, "Generator", null),
                     new GMDSimTreeNode(persistent.common.ItemEnum.SyncGen, "Sync Gen.", null),
                     new GMDSimTreeNode(persistent.common.ItemEnum.Wind, "Wind Generator", null),
                     new GMDSimTreeNode(persistent.common.ItemEnum.PVPnels, "PV Panels", null)
            });
            MapImage.Add(node, "generator_tree.png");
            rootTree.Add(node);
            ////////////////////////////
            node = new GMDSimTreeNode(persistent.common.ItemEnum.root, "Buses", null);
            MapChild.Add(node, new List<GMDSimTreeNode>()
                                        {new GMDSimTreeNode(persistent.common.ItemEnum.Bus, "Bus", null)}
                                         );

            MapImage.Add(node, "bus_tree.png");
            rootTree.Add(node);
            ////////////////////////////
            node = new GMDSimTreeNode(persistent.common.ItemEnum.root, "Loads", null);
            MapChild.Add(node, new List<GMDSimTreeNode>()
                                        {new GMDSimTreeNode(persistent.common.ItemEnum.Load, "Load", null),
                                         new GMDSimTreeNode(persistent.common.ItemEnum.EvMachine, "Ev", null)}
                                        );
            MapImage.Add(node, "load2_tree.png");
            rootTree.Add(node);
            ////////////////////////////
            node = new GMDSimTreeNode(persistent.common.ItemEnum.root, "Transformers", null);
            MapChild.Add(node, new List<GMDSimTreeNode>()
                                        {new GMDSimTreeNode(persistent.common.ItemEnum.Triphasic, "Triphasic", null),
                                          new GMDSimTreeNode(persistent.common.ItemEnum.YgD, "YgD", null),
                                         new GMDSimTreeNode(persistent.common.ItemEnum.YgDD, "YgDD", null),
                                         new GMDSimTreeNode(persistent.common.ItemEnum.C2WindingThransformer, "Custom 2W", null),
                                         new GMDSimTreeNode(persistent.common.ItemEnum.Custom3wT, "Custom", null)
                                        });
            MapImage.Add(node, "transformer_tree.png");
            rootTree.Add(node);
            ////////////////////////////
            node = new GMDSimTreeNode(persistent.common.ItemEnum.root, "Lines", null);
            MapChild.Add(node, new List<GMDSimTreeNode>()
                                        {new GMDSimTreeNode(persistent.common.ItemEnum.Singleline3phase, "Singel-3Phase", null),
                                         new GMDSimTreeNode(persistent.common.ItemEnum.DoubleCircuit, "Double circuit", null),
                                         new GMDSimTreeNode(persistent.common.ItemEnum.MPhase, "M-Phase", null)
                                        });
            MapImage.Add(node, "lines_tree.png");
            rootTree.Add(node);
            ////////////////////////////
            node = new GMDSimTreeNode(persistent.common.ItemEnum.root, "Shunts", null);
            MapChild.Add(node, new List<GMDSimTreeNode>()
                                        {new GMDSimTreeNode(persistent.common.ItemEnum.Switch, "Switch", null)
                                        });
            MapImage.Add(node, "schunt_tree.png");
            rootTree.Add(node);
            ////////////////////////////
            node = new GMDSimTreeNode(persistent.common.ItemEnum.root, "RLC Elements", null);
            MapChild.Add(node, new List<GMDSimTreeNode>()
                                        {new GMDSimTreeNode(persistent.common.ItemEnum.C, "C", null),
                                         new GMDSimTreeNode(persistent.common.ItemEnum.L, "L", null),
                                         new GMDSimTreeNode(persistent.common.ItemEnum.R, "R", null),
                                         new GMDSimTreeNode(persistent.common.ItemEnum.LC, "LC", null),
                                         new GMDSimTreeNode(persistent.common.ItemEnum.RL, "RL", null),
                                         new GMDSimTreeNode(persistent.common.ItemEnum.RLC, "RLC", null),
                                        });
            MapImage.Add(node, "rlc_tree.png");
            rootTree.Add(node);
            ////////////////////////////
            ///
            node = new GMDSimTreeNode(persistent.common.ItemEnum.root, "Substation", null);
            MapChild.Add(node, new List<GMDSimTreeNode>()
                                        {new GMDSimTreeNode(persistent.common.ItemEnum.Substation, "Create Substation", null) });
            rootTree.Add(node);
        }
        public static List<GMDSimTreeNode> fetchRootTree()
        {
            return new List<GMDSimTreeNode>(rootTree);
        }
        public static List<GMDSimTreeNode> fetchChildTreeNode(GMDSimTreeNode s)
        {
            List<GMDSimTreeNode> child = new List<GMDSimTreeNode>();
            var childTreeNode = MapChild;
            foreach (var childTree in childTreeNode)
            {
                if (childTree.Key.Equals(s))
                {
                    return childTree.Value;
                }
            }
            return new List<GMDSimTreeNode>(0);

        }
        public static string fetchRootTree(GMDSimTreeNode s)
        {

            var childTreeNode = MapImage;
            foreach (var childTree in childTreeNode)
            {
                if (childTree.Key.Equals(s))
                {
                    return childTree.Value;
                }
            }
            return null;
        }


        //////WPF:sfViewTree manager

    }
}
