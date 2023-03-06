using BL;
using BL.Calculation_Core.ItemWraper;
using GUI.New_concept_WPF;
using MathNet.Numerics.LinearAlgebra;
using network;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Windows.Forms;

namespace GUI.PF_Results
{
    public partial class PF_result : Form
    {
        List<BusDataWrapper> busData;
        List<BranchDataWrapper> branchData;
        List<GeneratorDataWrapper> generatorData;

        Vector<Complex> v;
        bool success;
        int index_of_iterator;

        public PF_result()
        {
            InitializeComponent();

        }

        public PF_result(List<BusDataWrapper> bus, List<GeneratorDataWrapper> generator, List<BranchDataWrapper> branch, Vector<Complex> v, bool success, int index_of_iterator)
        {
            InitializeComponent();
            this.busData = bus;
            this.generatorData = generator;
            this.branchData = branch;
            this.v = v;
            this.success = success;
            this.index_of_iterator = index_of_iterator;
            loadData(busData, generatorData, branchData, v, success, index_of_iterator);
        }

        public void loadData(List<BusDataWrapper> bus, List<GeneratorDataWrapper> generator, List<BranchDataWrapper> branch, Vector<Complex> v, bool success, int index_of_iterator)
        {
            busData = bus;
            if (busData.Count == 0)
            {
                throw new InvalidOperationException("Empty list");
            }
            if (branchData.Count == 0)
            {
                throw new InvalidOperationException("Empty list");
            }
            double max_mag = double.MinValue;
            double min_mag = double.MaxValue;
            double max_ang = double.MinValue;
            double min_ang = double.MaxValue;
            long busmax = 0; long busmin = 0;
            long busAmax = 0; long busAmin = 0;
            foreach (BusDataWrapper _bus in busData)
            {
                _bus.VA = _bus.VA * (180 / Math.PI);
                if (_bus.VM > max_mag)
                {
                    max_mag = _bus.VM;
                    busmax = _bus.bus_number + 1;

                }
                if (_bus.VM < min_mag)
                {
                    min_mag = _bus.VM;
                    busmin = _bus.bus_number + 1;
                }
                if (_bus.VA > max_ang)
                {
                    max_ang = _bus.VA;
                    busAmax = _bus.bus_number + 1;

                }
                if (_bus.VA < min_ang)
                {
                    min_ang = _bus.VA;
                    busAmin = _bus.bus_number + 1;
                }

            }

            double Pmax = double.MinValue;
            double PTo = double.MaxValue;

            double pLossmax = double.MinValue;
            long BusF_ploss = 0; long BusT_ploss = 0;
            foreach (BranchDataWrapper _branch in branchData)
            {
                Pmax = (_branch.PF + _branch.PT);
                if (Pmax > pLossmax)
                {

                    pLossmax = Pmax;
                    BusF_ploss = _branch.F_Bus + 1; BusT_ploss = _branch.T_Bus + 1;
                }

            }


            double Qmax = 0d;
            double QTo = double.MaxValue;

            double QLossmax = double.MinValue;
            long BusF_Qloss = 0; long BusT_Qloss = 0;
            foreach (BranchDataWrapper _branch in branchData)
            {
                Qmax = _branch.QF + _branch.QT;
                if (Qmax > QLossmax)
                {
                    QLossmax = Qmax;
                    BusF_Qloss = _branch.F_Bus + 1; BusT_Qloss = _branch.T_Bus + 1;
                }

            }

            Ploss.Text = pLossmax.ToString();
            Ploadfrom_to.Text = BusF_ploss.ToString() + " - " + BusT_ploss.ToString();
            Qloss.Text = QLossmax.ToString();
            QlossFrom_to.Text = BusF_Qloss.ToString() + " - " + BusT_Qloss.ToString();
            Max_mag.Text = max_mag.ToString();
            Max_Mbus.Text = busmax.ToString();
            Min_Mbus.Text = busmin.ToString();
            Min_mag.Text = min_mag.ToString();

            Max_Ang.Text = max_ang.ToString();
            Max_Abus.Text = busAmax.ToString();
            Min_Abus.Text = busAmin.ToString();
            Min_Ang.Text = min_ang.ToString();

        }

        private void savebtn_Click(object sender, EventArgs e)
        {
            BusBL busbl = new BusBL();
            foreach (BusDataWrapper _bus in busData)
            {
                Bus bus = busbl.findByCode(CustomContentControl.getCurrentCase(), _bus.bus_number);
                bus.Va_angle = (float)_bus.VA;
                bus.voltage = (float)_bus.Base_KV;
                bus.Va_mag = (float)_bus.VM;

            }
        }
    }
}
