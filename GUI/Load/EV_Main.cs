using BL.Load_BL;
using network;
using persistent.network.load_entitiy;
using System;
using System.Windows.Forms;

namespace GUI.Load
{
    public partial class EV_Main : Form
    {
        EVBL evBL;
        EV ev;
        Loads load = new Loads();
        Bus bus = new Bus();
        public EV_Main()
        {
            InitializeComponent();
        }
        public EV_Main(EV ev)
        {
            InitializeComponent();
            evBL = new EVBL();
            this.ev = ev;
            loadData(ev);
            //      radioButton2.DataBindings.Add(Shape.Ellipse);
        }

        public void loadData(EV ev)
        {

            checkBoxInService.Checked = ev.Inservice;
            checkBoxInterruptible.Checked = ev.Interruptible;
            checkBoxScalable.Checked = ev.Scalable;
            checkBoxDGInService.Checked = ev.distributedGeneration.DGinservice;

            if (ev.Bus != null)
            {
                busNumbertxt.Text = ev.Bus.BusNumber.ToString();
                busNametxt.Text = ev.Bus.BusName;
                areaNumberTXT.Text = ev.Bus.area.Number.ToString();
                zoneNumberTXT.Text = ev.Bus.zone.Number.ToString();
                areaNameTXT.Text = ev.Bus.area.Name;
                zoneNameTXT.Text = ev.Bus.zone.Name;

                ownerNumberTXT.Text = (ev.Bus.owners[0].Number).ToString();
                ownerNameTXT.Text = (ev.Bus.owners[0].Name);

            }
            SubstationNameTXT.Text = ev.substation.Substation_Name;
            SubstationNumberTXT.Text = ev.substation.Substation_Number.ToString();
            ConstantPowerMVValue.Text = ev.loadinformation.P_Power.ToString();
            ConstantCurrentMVValue.Text = ev.loadinformation.P_Current.ToString();
            ConstantImpedMVValue.Text = ev.loadinformation.P_Impedance.ToString();

            ConstantPowerMVarValue.Text = ev.loadinformation.Q_Power.ToString();
            ConstantCurrentMVarValue.Text = ev.loadinformation.Q_Current.ToString();
            ConstantImpedMVarValue.Text = ev.loadinformation.Q_Impedance.ToString();

            DistributGenerationMVvalue.Text = ev.distributedGeneration.P_GEN.ToString();
            DistributGenerationMVarvalue.Text = ev.distributedGeneration.Q_GEN.ToString();

            DistributGenerationMinMVvalue.Text = ev.distributedGeneration.P_GEN_MIN.ToString();
            DistributGenerationMaxMVarvalue.Text = ev.distributedGeneration.Q_GEN_MIN.ToString();

            LoadIDtxt.Text = ev.Identity.ToString();


            /*    MaxMWOutputTXT.Text = Convert.ToString(generator.powerControl.maxOut);
                MinMWOutputTXT.Text = Convert.ToString(generator.powerControl.minOut);
                MWSetPointTXT.Text = Convert.ToString(generator.powerControl.setpoint);
                MWOutputTXT.Text = Convert.ToString(generator.powerControl.outPut);

                PartFactorTXT.Text = Convert.ToString(generator.powerControl.factor);
                MaxMvarsTXT.Text = Convert.ToString(generator.voltageControl.MaxMvars);
                MinMvarsTXT.Text = Convert.ToString(generator.voltageControl.MinMvars);
                MvarOutputTXT.Text = Convert.ToString(generator.voltageControl.MvarOutput);
                RemoteRegFactorTXT.Text = Convert.ToString(generator.voltageControl.RegFactor);
                SetPointVoltageTXT.Text = Convert.ToString(generator.voltageControl.SetPointVoltage);
    */

        }

        public Boolean save()
        {
            try
            {

                if (ev.Bus != null)
                {
                    ev.Bus.BusNumber = long.Parse(busNumbertxt.Text);
                    ev.Bus.BusName = busNametxt.Text;
                    ev.Bus.area.Number = long.Parse(areaNumberTXT.Text);
                    ev.Bus.zone.Number = long.Parse(zoneNumberTXT.Text);
                    ev.Bus.area.Name = areaNameTXT.Text;
                    ev.Bus.zone.Name = zoneNameTXT.Text;
                    ev.Bus.owners[0].Number = long.Parse(ownerNumberTXT.Text);
                    ev.Bus.owners[0].Name = ownerNameTXT.Text;

                }
                ev.Inservice = checkBoxInService.Checked;
                ev.Interruptible = checkBoxInterruptible.Checked;
                ev.Scalable = checkBoxScalable.Checked;
                ev.distributedGeneration.DGinservice = checkBoxDGInService.Checked;
                ev.substation.Substation_Name = SubstationNameTXT.Text;
                ev.substation.Substation_Number = long.Parse(SubstationNumberTXT.Text);
                ev.loadinformation.P_Power = double.Parse(ConstantPowerMVValue.Text);
                ev.loadinformation.P_Current = double.Parse(ConstantCurrentMVValue.Text);
                ev.loadinformation.P_Impedance = double.Parse(ConstantImpedMVValue.Text);
                ev.loadinformation.Q_Power = double.Parse(ConstantPowerMVarValue.Text);
                ev.loadinformation.Q_Current = double.Parse(ConstantCurrentMVarValue.Text);
                ev.loadinformation.Q_Impedance = double.Parse(ConstantImpedMVarValue.Text);
                ev.distributedGeneration.P_GEN = double.Parse(DistributGenerationMVvalue.Text);
                ev.distributedGeneration.Q_GEN = double.Parse(DistributGenerationMVarvalue.Text);
                ev.distributedGeneration.P_GEN_MIN = double.Parse(DistributGenerationMinMVvalue.Text);
                ev.distributedGeneration.Q_GEN_MIN = double.Parse(DistributGenerationMaxMVarvalue.Text);
                ev.Identity = int.Parse(LoadIDtxt.Text);
                return true;
            }
            catch
            {
                MessageBox.Show("Save Record Exception");
                return false;
            }

        }


        private void LoadDisplayWidth_ValueChanged(object sender, EventArgs e)
        {
            ResizeRedraw = true;

        }

        private void OK_load_Click(object sender, EventArgs e)
        {
            save();
            Close();

        }

        private void Save_load_Click(object sender, EventArgs e)
        {


            save();
        }

        private void Cancel_Load_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Load_Main_Load(object sender, EventArgs e)
        {

        }

        private void LoadDisplayInfo_Enter(object sender, EventArgs e)
        {

        }

        public EV GetEV()
        {
            return ev;
        }

        private void setEV(EV ev)
        {
            this.ev = ev;
        }

        private void LoadInformation_Click(object sender, EventArgs e)
        {

        }
    }
}
