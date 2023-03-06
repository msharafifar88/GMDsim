using BL.Calculation_Core.ItemWraper;
using MathNet.Numerics.LinearAlgebra;
using System.Collections.Generic;
using System.Linq;

namespace BL.Calculation_Core.Calculation_Class
{
    public class DCpf
    {/*

     
    """Solves a DC power flow.

    Solves for the bus voltage angles at all but the reference bus, given the
    full system C{B} matrix and the vector of bus real power injections, the
    initial vector of bus voltage angles (in radians), and column vectors with
    the lists of bus indices for the swing bus, PV buses, and PQ buses,
    respectively. Returns a vector of bus voltage angles in radians.

    @see: L{rundcpf}, L{runpf}

    @author: Carlos E. Murillo-Sanchez (PSERC Cornell & Universidad
    Autonoma de Manizales)
    @author: Ray Zimmerman (PSERC Cornell)
    """


    def dcpf(B, Pbus, Va0, ref, pv, pq):
    pvpq = matrix(r_[pv, pq])

    ## initialize result vector
    Va = copy(Va0)

    ## update angles for non-reference buses
    Va[pvpq] = spsolve(B[pvpq.T, pvpq], transpose(Pbus[pvpq] - B[pvpq.T, ref] * Va0[ref]))

    return Va*/

        BusBL busBL = new BusBL();
        LoadBL loadBL = new LoadBL();

        Single3phaseLineBL single3PhaseLineBL = new Single3phaseLineBL();
        DoubleCircuitLineBL doubleCircuitLineBL = new DoubleCircuitLineBL();
        MultiPhaseLineBL multiPhaseLineBL = new MultiPhaseLineBL();
        GeneratorBL generatorBL = new GeneratorBL();
        C2WTransformerBL c2WTransformerBL = new C2WTransformerBL();
        C3WTransformerBL c3wTransformerBL = new C3WTransformerBL();

        List<BusDataWrapper> busDataWrapperList = new List<BusDataWrapper>();
        List<GeneratorDataWrapper> generatorWrapperList = new List<GeneratorDataWrapper>();
        List<BranchDataWrapper> branchDataWrappersList = new List<BranchDataWrapper>();
        int nb = 0;          //number of buses
        int ng = 0;       // number of generator


        // BUS TYPE 2 bus type(1 = PQ, 2 = PV, 3 = ref, 4 = isolated)
        public DCpf(List<BusDataWrapper> busDatas, List<GeneratorDataWrapper> generatorDatas)
        {
            busDataWrapperList = busDatas;
            generatorWrapperList = generatorDatas;
            nb = busDatas.Count();
            ng = generatorDatas.Count();



        }


        public Vector<double> cal_DCpf(List<BusDataWrapper> pv, List<BusDataWrapper> pq, Vector<double> Va0, Matrix<double> B, Matrix<double> Bbf, Vector<double> Pbus, Vector<double> PPfin)
        {

            List<BusDataWrapper> PVPQBus = new List<BusDataWrapper>();
            List<BusDataWrapper> RefBus = new List<BusDataWrapper>();
            List<BusDataWrapper> PVBus = new List<BusDataWrapper>();
            List<BusDataWrapper> PQBus = new List<BusDataWrapper>();
            List<BusDataWrapper> allbus = new List<BusDataWrapper>();

            busDataWrapperList.ForEach(bus =>
           {
               if (bus.bus_type.Equals(1))
               {
                   PQBus.Add(bus);
               }
           });

            PQBus.OrderBy(bus => bus.bus_number);


            busDataWrapperList.ForEach(bus =>
            {
                if (bus.bus_type.Equals(2))
                {
                    PVBus.Add(bus);
                }
            });
            PVBus.OrderBy(bus => bus.bus_number);

            busDataWrapperList.ForEach(bus =>
            {
                if (bus.bus_type.Equals(3))
                {
                    RefBus.Add(bus);
                }
            });

            RefBus.OrderBy(bus => bus.bus_number);




            PVPQBus.AddRange(PVBus);
            PVPQBus.AddRange(PQBus);

            allbus.AddRange(busDataWrapperList);


            /*     string s = " ";
                 foreach (BusDataWrapper b in PVPQBus)
                 {
                     s = s + b.ToString();

                     Console.WriteLine("PVPQBus +++++++++++++++++++++++++"+ b);

                 }*/

            var B_PVPQ = Matrix<double>.Build.Dense(PVPQBus.Count, PVPQBus.Count);
            foreach (BusDataWrapper busDataWrapper in PVPQBus)
            {
                foreach (BusDataWrapper busData in PVPQBus)
                {
                    B_PVPQ[PVPQBus.IndexOf(busDataWrapper), PVPQBus.IndexOf(busData)] = (B[(int)busDataWrapper.bus_number, (int)busData.bus_number]);
                }

            }


            var Cal_PbusPVPQ = Vector<double>.Build.Dense(PVPQBus.Count);
            foreach (BusDataWrapper busDataWrapper in PVPQBus)
            {

                Cal_PbusPVPQ[PVPQBus.IndexOf(busDataWrapper)] = Pbus[(int)busDataWrapper.bus_number];


            }


            var B_PVPQ_ref = Matrix<double>.Build.Dense(PVPQBus.Count, RefBus.Count);
            foreach (BusDataWrapper busDataWrapper in PVPQBus)
            {
                foreach (BusDataWrapper busData in RefBus)
                {
                    B_PVPQ_ref[PVPQBus.IndexOf(busDataWrapper), RefBus.IndexOf(busData)] = (B[(int)busDataWrapper.bus_number, (int)busData.bus_number]);
                }

            }


            var Cal_Va0_ref = Vector<double>.Build.Dense(RefBus.Count);
            foreach (BusDataWrapper busRef in RefBus)
            {

                Cal_Va0_ref[RefBus.IndexOf(busRef)] = busRef.VA;

            }
            Vector<double> a = B_PVPQ_ref.Multiply(Cal_Va0_ref);

            Vector<double> c = Cal_PbusPVPQ.Subtract(a);

            ////// whyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyy


            MathNet.Numerics.Providers.SparseSolver.ManagedSparseSolverProvider solverProvider = new MathNet.Numerics.Providers.SparseSolver.ManagedSparseSolverProvider();
            /*            MathNet.Numerics.Providers.SparseSolver.SparseSolverControl sparse = new MathNet.Numerics.Providers.SparseSolver.SparseSolverControl();

             Vector<double> Va_PVPQ = solverProvider.Solve(B_PVPQ,c);*/



            /*B([pv; pq], [pv; pq]) \ ...
                (Pbus([pv; pq]) - B([pv; pq], ref) * Va0(ref))*/

            Vector<double> va = Vector<double>.Build.Dense(Va0.Count);
            va = Va0;
            //////////////////
            ///

            Vector<double> Va_PVPQ = B_PVPQ.Solve(c);


            for (int i = 0; i < Va_PVPQ.Count; i++)
            {
                PVPQBus[i].VA = Va_PVPQ[i];
            }


            List<int> orderIndex = new List<int>();
            /* foreach (BusDataWrapper refBus in RefBus)
             {
                 foreach(BusDataWrapper busData in busDataWrapperList)
                 {
                     if (busData.Equals(refBus))
                     {
                         orderIndex.Add(busDataWrapperList.IndexOf(busData));
                     }
                 }

             }*/
            foreach (BusDataWrapper pvB in PVBus)
            {
                foreach (BusDataWrapper busData in busDataWrapperList)
                {
                    if (busData.Equals(pvB))
                    {
                        orderIndex.Add(busDataWrapperList.IndexOf(busData));
                    }
                }

            }
            foreach (BusDataWrapper pqBus in PQBus)
            {
                foreach (BusDataWrapper busData in busDataWrapperList)
                {
                    if (busData.Equals(pqBus))
                    {
                        orderIndex.Add(busDataWrapperList.IndexOf(busData));
                    }
                }

            }

            // RefBus.ForEach(rb => va.Add(0));
            for (int i = 0; i < busDataWrapperList.Count; i++)
            {
                va[i] = busDataWrapperList[i].VA;
            }


            //  var Cal_PVPQ = Matrix<MathNet.Numerics.Complex32>.Build.Dense(PV, PQ);

            return va;




        }
    }
}
