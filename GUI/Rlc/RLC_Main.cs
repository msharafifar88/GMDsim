using BL;
using GUI.New_concept_WPF;
using network;
using persistent.enumeration;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GUI.Rlc
{
    public partial class RLC_Main : Form
    {
        IRlcBL irlcBL;
        RLCbranches rlcBranch;

        public RLC_Main()
        {
            InitializeComponent();
        }

        public RLC_Main(RLCbranches input)
        {
            InitializeComponent();
            this.Load += RLC_Main_Load;
            if (!(input is RLC))
            {
                switch (input.GetType().Name)
                {
                    case "R":
                        this.irlcBL = new RBL();
                        this.rlcBranch = (R)input;
                        this.Text = this.rlcBranch.branch = "R";
                        this.groupCapacitorBox.Visible = false;
                        this.groupInductorBox.Visible = false;
                        this.groupInitialCurrent.Visible = false;
                        this.groupInitialVoltage.Visible = false;
                        this.resetbutton.Visible = false;
                        break;
                    case "L":
                        this.irlcBL = new LBL();
                        this.rlcBranch = (L)input;
                        this.Text = this.rlcBranch.branch = "L";
                        this.groupResistorBox.Visible = false;
                        this.groupCapacitorBox.Visible = false;
                        this.groupInductorBox.Location = new Point(6, 15);
                        this.groupInitialVoltage.Visible = false;
                        break;
                    case "C":
                        this.irlcBL = new CBL();
                        this.rlcBranch = (C)input;
                        this.Text = this.rlcBranch.branch = "C";
                        this.groupInductorBox.Visible = false;
                        this.groupResistorBox.Visible = false;
                        this.groupCapacitorBox.Location = new Point(6, 15);
                        this.groupInitialCurrent.Visible = false;
                        this.groupInitialVoltage.Location = new Point(11, 15);
                        break;
                    case "RL":
                        this.irlcBL = new RlBL();
                        this.rlcBranch = (RL)input;
                        this.Text = this.rlcBranch.branch = "RL";
                        this.groupCapacitorBox.Visible = false;
                        this.groupInitialVoltage.Visible = false;
                        break;
                    case "LC":
                        this.irlcBL = new LcBL();
                        this.rlcBranch = (LC)input;
                        this.Text = this.rlcBranch.branch = "LC";
                        this.groupResistorBox.Visible = false;
                        //this.groupInductorBox.Location = new Point(9, 23);
                        //this.groupCapacitorBox.Location = new Point(237, 23);
                        this.groupInductorBox.Location = new Point(6, 15);
                        this.groupCapacitorBox.Location = new Point(158, 15);
                        break;
                }
            }
            else
            {
                this.irlcBL = new RlcBL();
                this.rlcBranch = (RLC)input;
                this.Text = this.rlcBranch.branch = "RLC";
            }
            loadData(this.rlcBranch);
        }

        private void RLC_Main_Load(object sender, EventArgs e)
        {
            this.checkScopes(false);
            this.NominalFreqText.ReadOnly = true;
            this.branchText.ReadOnly = true;
            this.OhmDropDown.DataSource = Enum.GetValues(typeof(ResistorUnitType)).Cast<ResistorUnitType>().ToList();
            this.sfOhmDropDown.DataSource = Enum.GetValues(typeof(ResistorUnitType)).Cast<ResistorUnitType>().ToList();
            this.FaradDropDown.DataSource = Enum.GetValues(typeof(CapacitorUnitType)).Cast<CapacitorUnitType>().ToList();
            this.sfFaradDropDown.DataSource = Enum.GetValues(typeof(CapacitorUnitType)).Cast<CapacitorUnitType>().ToList();
            this.HenryDropDown.DataSource = Enum.GetValues(typeof(InductorUnitType)).Cast<InductorUnitType>().ToList();
            this.sfHenryDropDown.DataSource = Enum.GetValues(typeof(InductorUnitType)).Cast<InductorUnitType>().ToList();
            this.VoUnitDropDown.DataSource = Enum.GetValues(typeof(ImposedInitialVoltage)).Cast<ImposedInitialVoltage>().ToList();
            this.IoUnitDropDown.DataSource = Enum.GetValues(typeof(ImposedInitialCurrent)).Cast<ImposedInitialCurrent>().ToList();
            this.phasedropbox.DataSource = Enum.GetValues(typeof(phaseConnect)).Cast<phaseConnect>().ToList();
        }


        public void loadData(RLCbranches rlcbranch)
        {
            NumberBox.Value = rlcbranch.number;
            NameText.Text = long.TryParse(rlcbranch.name, out _) ? rlcbranch.branch + rlcbranch.name : rlcbranch.name;
            branchText.Text = rlcbranch.branch;
            NominalFreqText.Text = rlcbranch.nominalFrequency.ToString();
            rOfFreqCheck.Checked = rlcbranch.rOfFrequency;
            voltageCheck.Checked = rlcbranch.voltage;
            currentCheck.Checked = rlcbranch.current;
            powerCheck.Checked = rlcbranch.power;
            areaNumberTXT.Text = Convert.ToString(rlcbranch.area.Number);
            areaNameTXT.Text = rlcbranch.area.Name;
            zoneNumberTXT.Text = Convert.ToString(rlcbranch.zone.Number);
            this.getData(rlcbranch);
        }

        private void getData(RLCbranches rlcbranch)
        {
            switch (rlcbranch.branch)
            {
                case "R":
                    this.OhmText.Text = (((R)rlcbranch).resistance).ToString();
                    this.OhmDropDown.SelectedItem = ResistorUnitType.Ω;
                    //this.treephase.Checked = true;

                    break;
                case "L":
                    this.HenryText.Text = (((L)rlcbranch).inductance).ToString();
                    this.HenryDropDown.SelectedItem = InductorUnitType.H;
                    this.IoTextBox.Text = (((L)rlcbranch).initialCurrent).ToString();
                    this.IoUnitDropDown.SelectedItem = ImposedInitialCurrent.A;
                    break;
                case "C":
                    this.FaradText.Text = (((C)rlcbranch).capacitance).ToString();
                    this.FaradDropDown.SelectedItem = CapacitorUnitType.F;
                    this.VoTextBox.Text = (((C)rlcbranch).initialVoltage).ToString();
                    this.VoUnitDropDown.SelectedItem = ImposedInitialVoltage.V;
                    break;
                case "LC":
                    this.HenryText.Text = (((LC)rlcbranch).inductance).ToString();
                    this.HenryDropDown.SelectedItem = InductorUnitType.H;
                    this.FaradText.Text = (((LC)rlcbranch).capacitance).ToString();
                    this.FaradDropDown.SelectedItem = CapacitorUnitType.F;
                    this.IoTextBox.Text = (((LC)rlcbranch).initialCurrent).ToString();
                    this.VoTextBox.Text = (((LC)rlcbranch).initialVoltage).ToString();
                    this.IoUnitDropDown.SelectedItem = ImposedInitialCurrent.A;
                    this.VoUnitDropDown.SelectedItem = ImposedInitialVoltage.V;
                    break;
                case "RL":
                    this.OhmText.Text = (((RL)rlcbranch).resistance).ToString();
                    this.OhmDropDown.SelectedItem = ResistorUnitType.Ω;
                    this.HenryText.Text = (((RL)rlcbranch).inductance).ToString();
                    this.HenryDropDown.SelectedItem = InductorUnitType.H;
                    this.IoTextBox.Text = (((RL)rlcbranch).initialCurrent).ToString();
                    this.IoUnitDropDown.SelectedItem = ImposedInitialCurrent.A;
                    break;
                default:
                    this.OhmText.Text = (((RLC)rlcbranch).resistance).ToString();
                    this.OhmDropDown.SelectedItem = ResistorUnitType.Ω;
                    this.HenryText.Text = (((RLC)rlcbranch).inductance).ToString();
                    this.HenryDropDown.SelectedItem = InductorUnitType.H;
                    this.FaradText.Text = (((RLC)rlcbranch).capacitance).ToString();
                    this.FaradDropDown.SelectedItem = CapacitorUnitType.F;
                    this.IoTextBox.Text = (((RLC)rlcbranch).initialCurrent).ToString();
                    this.VoTextBox.Text = (((RLC)rlcbranch).initialVoltage).ToString();
                    this.IoUnitDropDown.SelectedItem = ImposedInitialCurrent.A;
                    this.VoUnitDropDown.SelectedItem = ImposedInitialVoltage.V;
                    break;
            }
        }

        public Boolean save()
        {
            try
            {
                rlcBranch.number = (long)NumberBox.Value;
                this.saveData();
                rlcBranch.name = this.NameText.Text;
                rlcBranch.rOfFrequency = this.rOfFreqCheck.Checked;
                rlcBranch.current = this.currentCheck.Checked;
                rlcBranch.voltage = this.voltageCheck.Checked;
                rlcBranch.power = this.powerCheck.Checked;
                this.irlcBL.edit(rlcBranch, CustomContentControl.getCurrentCase());
            }
            catch
            {
                MessageBox.Show("Save Record Exception");
            }
            return false;
        }

        private void saveData()
        {
            switch (rlcBranch.branch)
            {
                case "R":
                    ((R)rlcBranch).resistance = float.Parse(this.OhmText.Text);
                    ((R)rlcBranch).resistanceUnit = this.OhmDropDown.SelectedIndex;
                    //((R)rlcBranch).
                    break;
                case "L":
                    ((L)rlcBranch).inductance = float.Parse(this.HenryText.Text);
                    ((L)rlcBranch).inductanceUnit = this.HenryDropDown.SelectedIndex;
                    ((L)rlcBranch).initialCurrent = float.Parse(this.IoTextBox.Text);
                    ((L)rlcBranch).currentUnit = this.IoUnitDropDown.SelectedIndex;
                    break;
                case "C":
                    ((C)rlcBranch).capacitance = float.Parse(this.FaradText.Text);
                    ((C)rlcBranch).capacitanceUnit = this.FaradDropDown.SelectedIndex;
                    ((C)rlcBranch).initialVoltage = float.Parse(this.VoTextBox.Text);
                    ((C)rlcBranch).voltageUnit = this.VoUnitDropDown.SelectedIndex;
                    break;
                case "LC":
                    ((LC)rlcBranch).inductance = float.Parse(this.HenryText.Text);
                    ((LC)rlcBranch).inductanceUnit = this.HenryDropDown.SelectedIndex;
                    ((LC)rlcBranch).capacitance = float.Parse(this.FaradText.Text);
                    ((LC)rlcBranch).capacitanceUnit = this.FaradDropDown.SelectedIndex;
                    ((LC)rlcBranch).initialCurrent = float.Parse(this.IoTextBox.Text);
                    ((LC)rlcBranch).initialVoltage = float.Parse(this.VoTextBox.Text);
                    ((LC)rlcBranch).currentUnit = this.IoUnitDropDown.SelectedIndex;
                    ((LC)rlcBranch).voltageUnit = this.VoUnitDropDown.SelectedIndex;
                    break;
                case "RL":
                    ((RL)rlcBranch).resistance = float.Parse(this.OhmText.Text);
                    ((RL)rlcBranch).resistanceUnit = this.OhmDropDown.SelectedIndex;
                    ((RL)rlcBranch).inductance = float.Parse(this.HenryText.Text);
                    ((RL)rlcBranch).inductanceUnit = this.HenryDropDown.SelectedIndex;
                    ((RL)rlcBranch).initialCurrent = float.Parse(this.IoTextBox.Text);
                    ((RL)rlcBranch).currentUnit = this.IoUnitDropDown.SelectedIndex;
                    break;
                default:
                    ((RLC)rlcBranch).resistance = float.Parse(this.OhmText.Text);
                    ((RLC)rlcBranch).resistanceUnit = this.OhmDropDown.SelectedIndex;
                    ((RLC)rlcBranch).inductance = float.Parse(this.HenryText.Text);
                    ((RLC)rlcBranch).inductanceUnit = this.HenryDropDown.SelectedIndex;
                    ((RLC)rlcBranch).capacitance = float.Parse(this.FaradText.Text);
                    ((RLC)rlcBranch).capacitanceUnit = this.FaradDropDown.SelectedIndex;
                    ((RLC)rlcBranch).initialCurrent = float.Parse(this.IoTextBox.Text);
                    ((RLC)rlcBranch).initialVoltage = float.Parse(this.VoTextBox.Text);
                    ((RLC)rlcBranch).currentUnit = this.IoUnitDropDown.SelectedIndex;
                    ((RLC)rlcBranch).voltageUnit = this.VoUnitDropDown.SelectedIndex;
                    break;
            }
        }

        public void cancel()
        {
            this.loadData(rlcBranch);
        }


        private Boolean validation(Bus bus)
        {
            return true;
        }

        private void changeArea_Click(object sender, EventArgs e)
        {
            /* SearchForm searchForm = new SearchForm();
             searchForm.findAllArea();
             searchForm.ShowDialog();*/
        }

        private void nominalFreqcheck_Click(object sender, EventArgs e)
        {
            switch (this.nominalFreqcheck.CheckState)
            {

                case CheckState.Checked:
                    this.NominalFreqText.ReadOnly = false;
                    break;
                case CheckState.Unchecked:
                    this.NominalFreqText.ReadOnly = true;
                    break;
            }
        }

        private void resetbutton_Click(object sender, EventArgs e)
        {
            this.VoTextBox.Text = "0";
            this.IoTextBox.Text = "0";
            this.IoUnitDropDown.SelectedIndex = 1;
            this.VoUnitDropDown.SelectedIndex = 1;
        }

        private void selectAllScopes_Click(object sender, EventArgs e)
        {
            checkScopes(true);
        }

        private void clearAllScopes_Click(object sender, EventArgs e)
        {
            checkScopes(false);
        }

        private void checkScopes(bool clicked)
        {

            this.currentCheck.Checked = clicked;
            this.voltageCheck.Checked = clicked;
            this.powerCheck.Checked = clicked;
        }

        private void RLCCancel_Click(object sender, EventArgs e)
        {
            this.cancel();
            this.Close();
        }

        private void RLCOk_Click(object sender, EventArgs e)
        {
            this.save();
        }

        private void RLCSave_Click(object sender, EventArgs e)
        {
            this.save();
            this.Close();
        }

        private void rOfFreqCheck_Click(object sender, EventArgs e)
        {
            switch (this.rOfFreqCheck.CheckState)
            {

                case CheckState.Checked:

                    break;
                case CheckState.Unchecked:

                    break;

            }
        }



        public RLCbranches getRLC()
        {
            return rlcBranch;
        }

        private void MWSetPointTXT_TextChanged(object sender, EventArgs e)
        {

        }

        private void treephase_CheckedChanged(object sender, EventArgs e)
        {
            if (treephase.Checked == true)
            {
                phasedropbox.Enabled = false;
                //singlephase.Checked = false;
            }
            else if (singlephase.Checked == true)
            {
                phasedropbox.Enabled = true;
                //  treephase.Checked = false;
            }
        }


    }
}
