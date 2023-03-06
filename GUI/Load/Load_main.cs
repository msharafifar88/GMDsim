using BL;
using network;
using System;
using System.Windows.Forms;

namespace GUI.Load
{
    public partial class Load_Main : Form
    {
        LoadBL loadBL;
        Loads loads;
        Loads load = new Loads();
        Bus bus = new Bus();
        public Load_Main()
        {
            InitializeComponent();
        }
        public Load_Main(Loads load)
        {
            InitializeComponent();
            loadBL = new LoadBL();
            this.loads = load;
            loadData(load);
            //      radioButton2.DataBindings.Add(Shape.Ellipse);
        }

        public void loadData(Loads generator)
        {

            checkBoxInService.Checked = loads.Inservice;
            checkBoxInterruptible.Checked = loads.Interruptible;
            checkBoxScalable.Checked = loads.Scalable;
            checkBoxDGInService.Checked = loads.distributedGeneration.DGinservice;

            if (loads.Bus != null)
            {
                busNumbertxt.Value = (decimal)loads.Bus.BusNumber;
                busNametxt.Text = loads.Bus.BusNumber.ToString();
                areaNumberTXT.Value = (decimal)loads.Bus.area.Number;
                zoneNumberTXT.Value = (decimal)loads.Bus.zone.Number;
                areaNameTXT.Text = loads.Bus.area.Name;
                zoneNameTXT.Text = loads.Bus.zone.Name;

                ownerNumberTXT.Value = (decimal)(loads.Bus.owners[0].Number);
                ownerNameTXT.Text = (loads.Bus.owners[0].Name);

            }
            SubstationNameTXT.Text = loads.substation.Substation_Name;
            SubstationNumberTXT.Value = (decimal)loads.substation.Substation_Number;
            ConstantPowerMVValue.Text = loads.loadinformation.P_Power.ToString();
            ConstantCurrentMVValue.Text = loads.loadinformation.P_Current.ToString();
            ConstantImpedMVValue.Text = loads.loadinformation.P_Impedance.ToString();

            ConstantPowerMVarValue.Text = loads.loadinformation.Q_Power.ToString();
            ConstantCurrentMVarValue.Text = loads.loadinformation.Q_Current.ToString();
            ConstantImpedMVarValue.Text = loads.loadinformation.Q_Impedance.ToString();

            DistributGenerationMVvalue.Text = loads.distributedGeneration.P_GEN.ToString();
            DistributGenerationMVarvalue.Text = loads.distributedGeneration.Q_GEN.ToString();

            DistributGenerationMinMVvalue.Text = loads.distributedGeneration.P_GEN_MIN.ToString();
            DistributGenerationMaxMVarvalue.Text = loads.distributedGeneration.Q_GEN_MIN.ToString();

            LoadIDtxt.Text = loads.Identity.ToString();


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

                if (loads.Bus != null)
                {
                    loads.Bus.BusNumber = long.Parse(busNumbertxt.Text);
                    loads.Bus.BusName = busNametxt.Text;
                    loads.Bus.area.Number = long.Parse(areaNumberTXT.Text);
                    loads.Bus.zone.Number = long.Parse(zoneNumberTXT.Text);
                    loads.Bus.area.Name = areaNameTXT.Text;
                    loads.Bus.zone.Name = zoneNameTXT.Text;
                    loads.Bus.owners[0].Number = long.Parse(ownerNumberTXT.Text);
                    loads.Bus.owners[0].Name = ownerNameTXT.Text;

                }
                loads.Inservice = checkBoxInService.Checked;
                loads.Interruptible = checkBoxInterruptible.Checked;
                loads.Scalable = checkBoxScalable.Checked;
                loads.distributedGeneration.DGinservice = checkBoxDGInService.Checked;
                loads.substation.Substation_Name = SubstationNameTXT.Text;
                loads.substation.Substation_Number = long.Parse(SubstationNumberTXT.Text);
                loads.loadinformation.P_Power = double.Parse(ConstantPowerMVValue.Text);
                loads.loadinformation.P_Current = double.Parse(ConstantCurrentMVValue.Text);
                loads.loadinformation.P_Impedance = double.Parse(ConstantImpedMVValue.Text);
                loads.loadinformation.Q_Power = double.Parse(ConstantPowerMVarValue.Text);
                loads.loadinformation.Q_Current = double.Parse(ConstantCurrentMVarValue.Text);
                loads.loadinformation.Q_Impedance = double.Parse(ConstantImpedMVarValue.Text);
                loads.distributedGeneration.P_GEN = double.Parse(DistributGenerationMVvalue.Text);
                loads.distributedGeneration.Q_GEN = double.Parse(DistributGenerationMVarvalue.Text);
                loads.distributedGeneration.P_GEN_MIN = double.Parse(DistributGenerationMinMVvalue.Text);
                loads.distributedGeneration.Q_GEN_MIN = double.Parse(DistributGenerationMaxMVarvalue.Text);
                loads.Identity = int.Parse(LoadIDtxt.Text);
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

        public Loads GetLoads()
        {
            return loads;
        }

        private void setLoads(Loads load)
        {
            this.loads = load;
        }

        private void LoadInformation_Click(object sender, EventArgs e)
        {

        }
    }
}
