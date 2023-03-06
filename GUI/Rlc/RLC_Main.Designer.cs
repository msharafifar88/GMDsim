namespace GUI.Rlc
{
    partial class RLC_Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.RLCSave = new System.Windows.Forms.Button();
            this.RLCOk = new System.Windows.Forms.Button();
            this.RLCCancel = new System.Windows.Forms.Button();
            this.ScopesTab = new System.Windows.Forms.TabPage();
            this.groupScopesBox = new System.Windows.Forms.GroupBox();
            this.selectAllScopes = new System.Windows.Forms.Button();
            this.clearAllScopes = new System.Windows.Forms.Button();
            this.powerCheck = new System.Windows.Forms.CheckBox();
            this.currentCheck = new System.Windows.Forms.CheckBox();
            this.voltageCheck = new System.Windows.Forms.CheckBox();
            this.IC = new System.Windows.Forms.TabPage();
            this.resetbutton = new System.Windows.Forms.Button();
            this.groupInitialVoltage = new System.Windows.Forms.GroupBox();
            this.VoTextBox = new System.Windows.Forms.TextBox();
            this.VoUnitDropDown = new System.Windows.Forms.ComboBox();
            this.VoForC = new System.Windows.Forms.Label();
            this.groupInitialCurrent = new System.Windows.Forms.GroupBox();
            this.IoUnitDropDown = new System.Windows.Forms.ComboBox();
            this.IoTextBox = new System.Windows.Forms.TextBox();
            this.IoforL = new System.Windows.Forms.Label();
            this.tabvalues = new System.Windows.Forms.TabControl();
            this.Info = new System.Windows.Forms.TabPage();
            this.statusGroup = new System.Windows.Forms.GroupBox();
            this.phasedropbox = new System.Windows.Forms.ComboBox();
            this.singlephase = new System.Windows.Forms.RadioButton();
            this.treephase = new System.Windows.Forms.RadioButton();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.NumberBox = new System.Windows.Forms.NumericUpDown();
            this.ownerNumberTXT = new System.Windows.Forms.NumericUpDown();
            this.zoneNumberTXT = new System.Windows.Forms.NumericUpDown();
            this.areaNumberTXT = new System.Windows.Forms.NumericUpDown();
            this.changeOwner = new System.Windows.Forms.Button();
            this.changeZone = new System.Windows.Forms.Button();
            this.changeArea = new System.Windows.Forms.Button();
            this.ownerLabel = new System.Windows.Forms.Label();
            this.ownerNameTXT = new System.Windows.Forms.TextBox();
            this.zoneNameTXT = new System.Windows.Forms.TextBox();
            this.areaNameTXT = new System.Windows.Forms.TextBox();
            this.zoneLabel = new System.Windows.Forms.Label();
            this.arealabel = new System.Windows.Forms.Label();
            this.findByNameBtn = new System.Windows.Forms.Button();
            this.find = new System.Windows.Forms.Button();
            this.findByNumberBtn = new System.Windows.Forms.Button();
            this.branchText = new System.Windows.Forms.TextBox();
            this.NameText = new System.Windows.Forms.TextBox();
            this.typeLabel = new System.Windows.Forms.Label();
            this.componentNameLabel = new System.Windows.Forms.Label();
            this.busNumbeLabel = new System.Windows.Forms.Label();
            this.Values = new System.Windows.Forms.TabPage();
            this.sfFaradDropDown = new Syncfusion.WinForms.ListView.SfComboBox();
            this.sfHenryDropDown = new Syncfusion.WinForms.ListView.SfComboBox();
            this.sfOhmDropDown = new Syncfusion.WinForms.ListView.SfComboBox();
            this.radNominalFreqText = new System.Windows.Forms.TextBox();
            this.radFaradText = new System.Windows.Forms.TextBox();
            this.radHenryText = new System.Windows.Forms.TextBox();
            this.radOhmText = new System.Windows.Forms.TextBox();
            this.NominalFreqText = new System.Windows.Forms.TextBox();
            this.rOfFreqCheck = new System.Windows.Forms.CheckBox();
            this.labelRofFreq = new System.Windows.Forms.Label();
            this.nominalFreqcheck = new System.Windows.Forms.CheckBox();
            this.labelNominaFreq = new System.Windows.Forms.Label();
            this.groupInductorBox = new System.Windows.Forms.GroupBox();
            this.HenryDropDown = new System.Windows.Forms.ComboBox();
            this.HenryText = new System.Windows.Forms.TextBox();
            this.groupCapacitorBox = new System.Windows.Forms.GroupBox();
            this.FaradDropDown = new System.Windows.Forms.ComboBox();
            this.FaradText = new System.Windows.Forms.TextBox();
            this.groupResistorBox = new System.Windows.Forms.GroupBox();
            this.OhmDropDown = new System.Windows.Forms.ComboBox();
            this.OhmText = new System.Windows.Forms.TextBox();
            this.ScopesTab.SuspendLayout();
            this.groupScopesBox.SuspendLayout();
            this.IC.SuspendLayout();
            this.groupInitialVoltage.SuspendLayout();
            this.groupInitialCurrent.SuspendLayout();
            this.tabvalues.SuspendLayout();
            this.Info.SuspendLayout();
            this.statusGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumberBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ownerNumberTXT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zoneNumberTXT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.areaNumberTXT)).BeginInit();
            this.Values.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sfFaradDropDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sfHenryDropDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sfOhmDropDown)).BeginInit();
            this.groupInductorBox.SuspendLayout();
            this.groupCapacitorBox.SuspendLayout();
            this.groupResistorBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // RLCSave
            // 
            this.RLCSave.AccessibleDescription = "RLCSave";
            this.RLCSave.AccessibleName = "RLCSave";
            this.RLCSave.Location = new System.Drawing.Point(9, 392);
            this.RLCSave.Name = "RLCSave";
            this.RLCSave.Size = new System.Drawing.Size(100, 23);
            this.RLCSave.TabIndex = 40;
            this.RLCSave.Text = "Save";
            this.RLCSave.UseVisualStyleBackColor = true;
            this.RLCSave.Click += new System.EventHandler(this.RLCSave_Click);
            // 
            // RLCOk
            // 
            this.RLCOk.AccessibleDescription = "RLCOk";
            this.RLCOk.AccessibleName = "RLCOk";
            this.RLCOk.Location = new System.Drawing.Point(116, 392);
            this.RLCOk.Name = "RLCOk";
            this.RLCOk.Size = new System.Drawing.Size(100, 23);
            this.RLCOk.TabIndex = 41;
            this.RLCOk.Text = "Ok";
            this.RLCOk.UseVisualStyleBackColor = true;
            this.RLCOk.Click += new System.EventHandler(this.RLCOk_Click);
            // 
            // RLCCancel
            // 
            this.RLCCancel.AccessibleDescription = "RLCCancel";
            this.RLCCancel.AccessibleName = "RLCCancel";
            this.RLCCancel.Location = new System.Drawing.Point(346, 392);
            this.RLCCancel.Name = "RLCCancel";
            this.RLCCancel.Size = new System.Drawing.Size(100, 23);
            this.RLCCancel.TabIndex = 42;
            this.RLCCancel.Text = "Cancel";
            this.RLCCancel.UseVisualStyleBackColor = true;
            this.RLCCancel.Click += new System.EventHandler(this.RLCCancel_Click);
            // 
            // ScopesTab
            // 
            this.ScopesTab.Controls.Add(this.groupScopesBox);
            this.ScopesTab.Location = new System.Drawing.Point(4, 22);
            this.ScopesTab.Name = "ScopesTab";
            this.ScopesTab.Padding = new System.Windows.Forms.Padding(3);
            this.ScopesTab.Size = new System.Drawing.Size(447, 397);
            this.ScopesTab.TabIndex = 3;
            this.ScopesTab.Text = "Scopes";
            this.ScopesTab.UseVisualStyleBackColor = true;
            // 
            // groupScopesBox
            // 
            this.groupScopesBox.AccessibleDescription = "groupScopesBox";
            this.groupScopesBox.AccessibleName = "groupScopesBox";
            this.groupScopesBox.Controls.Add(this.selectAllScopes);
            this.groupScopesBox.Controls.Add(this.clearAllScopes);
            this.groupScopesBox.Controls.Add(this.powerCheck);
            this.groupScopesBox.Controls.Add(this.currentCheck);
            this.groupScopesBox.Controls.Add(this.voltageCheck);
            this.groupScopesBox.Location = new System.Drawing.Point(71, 19);
            this.groupScopesBox.Margin = new System.Windows.Forms.Padding(2);
            this.groupScopesBox.Name = "groupScopesBox";
            this.groupScopesBox.Padding = new System.Windows.Forms.Padding(2);
            this.groupScopesBox.Size = new System.Drawing.Size(304, 58);
            this.groupScopesBox.TabIndex = 0;
            this.groupScopesBox.TabStop = false;
            this.groupScopesBox.Text = "Time-Domain or Frequency Scopes";
            // 
            // selectAllScopes
            // 
            this.selectAllScopes.AccessibleDescription = "selectAllScopes";
            this.selectAllScopes.AccessibleName = "selectAllScopes";
            this.selectAllScopes.Location = new System.Drawing.Point(219, 22);
            this.selectAllScopes.Margin = new System.Windows.Forms.Padding(2);
            this.selectAllScopes.Name = "selectAllScopes";
            this.selectAllScopes.Size = new System.Drawing.Size(75, 23);
            this.selectAllScopes.TabIndex = 4;
            this.selectAllScopes.Text = "Select All";
            this.selectAllScopes.UseVisualStyleBackColor = true;
            this.selectAllScopes.Click += new System.EventHandler(this.selectAllScopes_Click);
            // 
            // clearAllScopes
            // 
            this.clearAllScopes.AccessibleDescription = "clearAllScopes";
            this.clearAllScopes.AccessibleName = "clearAllScopes";
            this.clearAllScopes.Location = new System.Drawing.Point(129, 22);
            this.clearAllScopes.Margin = new System.Windows.Forms.Padding(2);
            this.clearAllScopes.Name = "clearAllScopes";
            this.clearAllScopes.Size = new System.Drawing.Size(75, 23);
            this.clearAllScopes.TabIndex = 3;
            this.clearAllScopes.Text = "Clear All";
            this.clearAllScopes.UseVisualStyleBackColor = true;
            this.clearAllScopes.Click += new System.EventHandler(this.clearAllScopes_Click);
            // 
            // powerCheck
            // 
            this.powerCheck.AccessibleDescription = "powerCheck";
            this.powerCheck.AccessibleName = "powerCheck";
            this.powerCheck.AutoSize = true;
            this.powerCheck.Location = new System.Drawing.Point(74, 26);
            this.powerCheck.Margin = new System.Windows.Forms.Padding(2);
            this.powerCheck.Name = "powerCheck";
            this.powerCheck.Size = new System.Drawing.Size(32, 17);
            this.powerCheck.TabIndex = 2;
            this.powerCheck.Text = "p";
            this.powerCheck.UseVisualStyleBackColor = true;
            // 
            // currentCheck
            // 
            this.currentCheck.AccessibleDescription = "currentCheck";
            this.currentCheck.AccessibleName = "currentCheck";
            this.currentCheck.AutoSize = true;
            this.currentCheck.Location = new System.Drawing.Point(42, 26);
            this.currentCheck.Margin = new System.Windows.Forms.Padding(2);
            this.currentCheck.Name = "currentCheck";
            this.currentCheck.Size = new System.Drawing.Size(28, 17);
            this.currentCheck.TabIndex = 1;
            this.currentCheck.Text = "i";
            this.currentCheck.UseVisualStyleBackColor = true;
            // 
            // voltageCheck
            // 
            this.voltageCheck.AccessibleDescription = "voltageCheck";
            this.voltageCheck.AccessibleName = "voltageCheck";
            this.voltageCheck.AutoSize = true;
            this.voltageCheck.Location = new System.Drawing.Point(10, 26);
            this.voltageCheck.Margin = new System.Windows.Forms.Padding(2);
            this.voltageCheck.Name = "voltageCheck";
            this.voltageCheck.Size = new System.Drawing.Size(32, 17);
            this.voltageCheck.TabIndex = 0;
            this.voltageCheck.Text = "v";
            this.voltageCheck.UseVisualStyleBackColor = true;
            // 
            // IC
            // 
            this.IC.Controls.Add(this.resetbutton);
            this.IC.Controls.Add(this.groupInitialVoltage);
            this.IC.Controls.Add(this.groupInitialCurrent);
            this.IC.Location = new System.Drawing.Point(4, 22);
            this.IC.Name = "IC";
            this.IC.Padding = new System.Windows.Forms.Padding(3);
            this.IC.Size = new System.Drawing.Size(447, 397);
            this.IC.TabIndex = 2;
            this.IC.Text = "IC";
            this.IC.UseVisualStyleBackColor = true;
            // 
            // resetbutton
            // 
            this.resetbutton.AccessibleDescription = "resetbutton";
            this.resetbutton.AccessibleName = "resetbutton";
            this.resetbutton.Location = new System.Drawing.Point(11, 85);
            this.resetbutton.Margin = new System.Windows.Forms.Padding(2);
            this.resetbutton.Name = "resetbutton";
            this.resetbutton.Size = new System.Drawing.Size(75, 23);
            this.resetbutton.TabIndex = 11;
            this.resetbutton.Text = "Reset";
            this.resetbutton.UseVisualStyleBackColor = true;
            this.resetbutton.Click += new System.EventHandler(this.resetbutton_Click);
            // 
            // groupInitialVoltage
            // 
            this.groupInitialVoltage.AccessibleDescription = "groupInitialVoltage";
            this.groupInitialVoltage.AccessibleName = "groupInitialVoltage";
            this.groupInitialVoltage.Controls.Add(this.VoTextBox);
            this.groupInitialVoltage.Controls.Add(this.VoUnitDropDown);
            this.groupInitialVoltage.Controls.Add(this.VoForC);
            this.groupInitialVoltage.Location = new System.Drawing.Point(233, 15);
            this.groupInitialVoltage.Name = "groupInitialVoltage";
            this.groupInitialVoltage.Size = new System.Drawing.Size(207, 58);
            this.groupInitialVoltage.TabIndex = 10;
            this.groupInitialVoltage.TabStop = false;
            this.groupInitialVoltage.Text = "Imposed Initial Voltage";
            // 
            // VoTextBox
            // 
            this.VoTextBox.Location = new System.Drawing.Point(51, 23);
            this.VoTextBox.Name = "VoTextBox";
            this.VoTextBox.Size = new System.Drawing.Size(105, 20);
            this.VoTextBox.TabIndex = 27;
            // 
            // VoUnitDropDown
            // 
            this.VoUnitDropDown.FormattingEnabled = true;
            this.VoUnitDropDown.Location = new System.Drawing.Point(158, 23);
            this.VoUnitDropDown.Name = "VoUnitDropDown";
            this.VoUnitDropDown.Size = new System.Drawing.Size(45, 21);
            this.VoUnitDropDown.TabIndex = 27;
            // 
            // VoForC
            // 
            this.VoForC.AccessibleDescription = "VoForC";
            this.VoForC.AccessibleName = "VoForC";
            this.VoForC.AutoSize = true;
            this.VoForC.Location = new System.Drawing.Point(5, 25);
            this.VoForC.Name = "VoForC";
            this.VoForC.Size = new System.Drawing.Size(39, 13);
            this.VoForC.TabIndex = 0;
            this.VoForC.Text = "V for C";
            // 
            // groupInitialCurrent
            // 
            this.groupInitialCurrent.AccessibleDescription = "groupInitialCurrent";
            this.groupInitialCurrent.AccessibleName = "groupInitialCurrent";
            this.groupInitialCurrent.Controls.Add(this.IoUnitDropDown);
            this.groupInitialCurrent.Controls.Add(this.IoTextBox);
            this.groupInitialCurrent.Controls.Add(this.IoforL);
            this.groupInitialCurrent.Location = new System.Drawing.Point(11, 15);
            this.groupInitialCurrent.Name = "groupInitialCurrent";
            this.groupInitialCurrent.Size = new System.Drawing.Size(207, 58);
            this.groupInitialCurrent.TabIndex = 9;
            this.groupInitialCurrent.TabStop = false;
            this.groupInitialCurrent.Text = "Imposed Initial Current";
            // 
            // IoUnitDropDown
            // 
            this.IoUnitDropDown.FormattingEnabled = true;
            this.IoUnitDropDown.Location = new System.Drawing.Point(156, 24);
            this.IoUnitDropDown.Name = "IoUnitDropDown";
            this.IoUnitDropDown.Size = new System.Drawing.Size(45, 21);
            this.IoUnitDropDown.TabIndex = 26;
            // 
            // IoTextBox
            // 
            this.IoTextBox.Location = new System.Drawing.Point(45, 25);
            this.IoTextBox.Name = "IoTextBox";
            this.IoTextBox.Size = new System.Drawing.Size(105, 20);
            this.IoTextBox.TabIndex = 17;
            // 
            // IoforL
            // 
            this.IoforL.AccessibleDescription = "IoforL";
            this.IoforL.AccessibleName = "IoforL";
            this.IoforL.AutoSize = true;
            this.IoforL.Location = new System.Drawing.Point(5, 26);
            this.IoforL.Name = "IoforL";
            this.IoforL.Size = new System.Drawing.Size(34, 13);
            this.IoforL.TabIndex = 1;
            this.IoforL.Text = "I for L";
            // 
            // tabvalues
            // 
            this.tabvalues.Controls.Add(this.Info);
            this.tabvalues.Controls.Add(this.Values);
            this.tabvalues.Controls.Add(this.IC);
            this.tabvalues.Controls.Add(this.ScopesTab);
            this.tabvalues.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabvalues.Location = new System.Drawing.Point(0, 0);
            this.tabvalues.Name = "tabvalues";
            this.tabvalues.SelectedIndex = 0;
            this.tabvalues.Size = new System.Drawing.Size(455, 423);
            this.tabvalues.TabIndex = 31;
            // 
            // Info
            // 
            this.Info.Controls.Add(this.statusGroup);
            this.Info.Controls.Add(this.label9);
            this.Info.Controls.Add(this.label8);
            this.Info.Controls.Add(this.NumberBox);
            this.Info.Controls.Add(this.ownerNumberTXT);
            this.Info.Controls.Add(this.zoneNumberTXT);
            this.Info.Controls.Add(this.areaNumberTXT);
            this.Info.Controls.Add(this.changeOwner);
            this.Info.Controls.Add(this.changeZone);
            this.Info.Controls.Add(this.changeArea);
            this.Info.Controls.Add(this.ownerLabel);
            this.Info.Controls.Add(this.ownerNameTXT);
            this.Info.Controls.Add(this.zoneNameTXT);
            this.Info.Controls.Add(this.areaNameTXT);
            this.Info.Controls.Add(this.zoneLabel);
            this.Info.Controls.Add(this.arealabel);
            this.Info.Controls.Add(this.findByNameBtn);
            this.Info.Controls.Add(this.find);
            this.Info.Controls.Add(this.findByNumberBtn);
            this.Info.Controls.Add(this.branchText);
            this.Info.Controls.Add(this.NameText);
            this.Info.Controls.Add(this.typeLabel);
            this.Info.Controls.Add(this.componentNameLabel);
            this.Info.Controls.Add(this.busNumbeLabel);
            this.Info.Location = new System.Drawing.Point(4, 22);
            this.Info.Name = "Info";
            this.Info.Padding = new System.Windows.Forms.Padding(3);
            this.Info.Size = new System.Drawing.Size(447, 397);
            this.Info.TabIndex = 4;
            this.Info.Text = "Info";
            this.Info.UseVisualStyleBackColor = true;
            // 
            // statusGroup
            // 
            this.statusGroup.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.statusGroup.Controls.Add(this.phasedropbox);
            this.statusGroup.Controls.Add(this.singlephase);
            this.statusGroup.Controls.Add(this.treephase);
            this.statusGroup.Location = new System.Drawing.Point(294, 214);
            this.statusGroup.Name = "statusGroup";
            this.statusGroup.Size = new System.Drawing.Size(148, 72);
            this.statusGroup.TabIndex = 63;
            this.statusGroup.TabStop = false;
            this.statusGroup.Text = "Connection";
            // 
            // phasedropbox
            // 
            this.phasedropbox.Enabled = false;
            this.phasedropbox.FormattingEnabled = true;
            this.phasedropbox.Location = new System.Drawing.Point(87, 38);
            this.phasedropbox.Name = "phasedropbox";
            this.phasedropbox.Size = new System.Drawing.Size(52, 21);
            this.phasedropbox.TabIndex = 24;
            // 
            // singlephase
            // 
            this.singlephase.AutoSize = true;
            this.singlephase.Location = new System.Drawing.Point(17, 42);
            this.singlephase.Name = "singlephase";
            this.singlephase.Size = new System.Drawing.Size(64, 17);
            this.singlephase.TabIndex = 1;
            this.singlephase.TabStop = true;
            this.singlephase.Text = "1 Phase";
            this.singlephase.UseVisualStyleBackColor = true;
            // 
            // treephase
            // 
            this.treephase.AutoSize = true;
            this.treephase.Checked = true;
            this.treephase.Location = new System.Drawing.Point(17, 19);
            this.treephase.Name = "treephase";
            this.treephase.Size = new System.Drawing.Size(64, 17);
            this.treephase.TabIndex = 0;
            this.treephase.TabStop = true;
            this.treephase.Text = "3 Phase";
            this.treephase.UseVisualStyleBackColor = true;
            this.treephase.CheckedChanged += new System.EventHandler(this.treephase_CheckedChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(357, 97);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 13);
            this.label9.TabIndex = 62;
            this.label9.Text = "Name";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(215, 97);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 13);
            this.label8.TabIndex = 61;
            this.label8.Text = "Number";
            // 
            // NumberBox
            // 
            this.NumberBox.AccessibleDescription = "NumberBox";
            this.NumberBox.AccessibleName = "NumberBox";
            this.NumberBox.Location = new System.Drawing.Point(93, 10);
            this.NumberBox.Name = "NumberBox";
            this.NumberBox.Size = new System.Drawing.Size(124, 20);
            this.NumberBox.TabIndex = 60;
            // 
            // ownerNumberTXT
            // 
            this.ownerNumberTXT.Enabled = false;
            this.ownerNumberTXT.Location = new System.Drawing.Point(193, 177);
            this.ownerNumberTXT.Name = "ownerNumberTXT";
            this.ownerNumberTXT.Size = new System.Drawing.Size(101, 20);
            this.ownerNumberTXT.TabIndex = 59;
            this.ownerNumberTXT.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // zoneNumberTXT
            // 
            this.zoneNumberTXT.Enabled = false;
            this.zoneNumberTXT.Location = new System.Drawing.Point(193, 147);
            this.zoneNumberTXT.Name = "zoneNumberTXT";
            this.zoneNumberTXT.Size = new System.Drawing.Size(100, 20);
            this.zoneNumberTXT.TabIndex = 58;
            this.zoneNumberTXT.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // areaNumberTXT
            // 
            this.areaNumberTXT.Enabled = false;
            this.areaNumberTXT.Location = new System.Drawing.Point(193, 118);
            this.areaNumberTXT.Name = "areaNumberTXT";
            this.areaNumberTXT.Size = new System.Drawing.Size(101, 20);
            this.areaNumberTXT.TabIndex = 57;
            this.areaNumberTXT.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // changeOwner
            // 
            this.changeOwner.Location = new System.Drawing.Point(112, 173);
            this.changeOwner.Name = "changeOwner";
            this.changeOwner.Size = new System.Drawing.Size(75, 23);
            this.changeOwner.TabIndex = 56;
            this.changeOwner.Text = "change";
            this.changeOwner.UseVisualStyleBackColor = true;
            // 
            // changeZone
            // 
            this.changeZone.Location = new System.Drawing.Point(112, 144);
            this.changeZone.Name = "changeZone";
            this.changeZone.Size = new System.Drawing.Size(75, 23);
            this.changeZone.TabIndex = 55;
            this.changeZone.Text = "change";
            this.changeZone.UseVisualStyleBackColor = true;
            // 
            // changeArea
            // 
            this.changeArea.Location = new System.Drawing.Point(112, 115);
            this.changeArea.Name = "changeArea";
            this.changeArea.Size = new System.Drawing.Size(75, 23);
            this.changeArea.TabIndex = 54;
            this.changeArea.Text = "change";
            this.changeArea.UseVisualStyleBackColor = true;
            // 
            // ownerLabel
            // 
            this.ownerLabel.AutoSize = true;
            this.ownerLabel.Location = new System.Drawing.Point(14, 178);
            this.ownerLabel.Name = "ownerLabel";
            this.ownerLabel.Size = new System.Drawing.Size(38, 13);
            this.ownerLabel.TabIndex = 53;
            this.ownerLabel.Text = "Owner";
            // 
            // ownerNameTXT
            // 
            this.ownerNameTXT.Enabled = false;
            this.ownerNameTXT.Location = new System.Drawing.Point(311, 177);
            this.ownerNameTXT.Name = "ownerNameTXT";
            this.ownerNameTXT.Size = new System.Drawing.Size(124, 20);
            this.ownerNameTXT.TabIndex = 52;
            // 
            // zoneNameTXT
            // 
            this.zoneNameTXT.Enabled = false;
            this.zoneNameTXT.Location = new System.Drawing.Point(311, 147);
            this.zoneNameTXT.Name = "zoneNameTXT";
            this.zoneNameTXT.Size = new System.Drawing.Size(124, 20);
            this.zoneNameTXT.TabIndex = 51;
            // 
            // areaNameTXT
            // 
            this.areaNameTXT.Enabled = false;
            this.areaNameTXT.Location = new System.Drawing.Point(311, 118);
            this.areaNameTXT.Name = "areaNameTXT";
            this.areaNameTXT.Size = new System.Drawing.Size(124, 20);
            this.areaNameTXT.TabIndex = 50;
            // 
            // zoneLabel
            // 
            this.zoneLabel.AutoSize = true;
            this.zoneLabel.Location = new System.Drawing.Point(14, 149);
            this.zoneLabel.Name = "zoneLabel";
            this.zoneLabel.Size = new System.Drawing.Size(32, 13);
            this.zoneLabel.TabIndex = 49;
            this.zoneLabel.Text = "Zone";
            // 
            // arealabel
            // 
            this.arealabel.AutoSize = true;
            this.arealabel.Location = new System.Drawing.Point(14, 120);
            this.arealabel.Name = "arealabel";
            this.arealabel.Size = new System.Drawing.Size(29, 13);
            this.arealabel.TabIndex = 48;
            this.arealabel.Text = "Area";
            // 
            // findByNameBtn
            // 
            this.findByNameBtn.Location = new System.Drawing.Point(253, 36);
            this.findByNameBtn.Name = "findByNameBtn";
            this.findByNameBtn.Size = new System.Drawing.Size(100, 23);
            this.findByNameBtn.TabIndex = 47;
            this.findByNameBtn.Text = "Find By Name";
            this.findByNameBtn.UseVisualStyleBackColor = true;
            // 
            // find
            // 
            this.find.Location = new System.Drawing.Point(359, 7);
            this.find.Name = "find";
            this.find.Size = new System.Drawing.Size(75, 23);
            this.find.TabIndex = 46;
            this.find.Text = "Find...";
            this.find.UseVisualStyleBackColor = true;
            // 
            // findByNumberBtn
            // 
            this.findByNumberBtn.Location = new System.Drawing.Point(253, 7);
            this.findByNumberBtn.Name = "findByNumberBtn";
            this.findByNumberBtn.Size = new System.Drawing.Size(100, 23);
            this.findByNumberBtn.TabIndex = 45;
            this.findByNumberBtn.Text = "Find By Number";
            this.findByNumberBtn.UseVisualStyleBackColor = true;
            // 
            // branchText
            // 
            this.branchText.AccessibleDescription = "branchText";
            this.branchText.AccessibleName = "branchText";
            this.branchText.Location = new System.Drawing.Point(93, 67);
            this.branchText.Name = "branchText";
            this.branchText.Size = new System.Drawing.Size(124, 20);
            this.branchText.TabIndex = 44;
            // 
            // NameText
            // 
            this.NameText.AccessibleDescription = "Name";
            this.NameText.AccessibleName = "Name";
            this.NameText.Location = new System.Drawing.Point(93, 38);
            this.NameText.Name = "NameText";
            this.NameText.Size = new System.Drawing.Size(124, 20);
            this.NameText.TabIndex = 43;
            // 
            // typeLabel
            // 
            this.typeLabel.AccessibleDescription = "typeLabel";
            this.typeLabel.AccessibleName = "typeLabel";
            this.typeLabel.AutoSize = true;
            this.typeLabel.Location = new System.Drawing.Point(8, 70);
            this.typeLabel.Name = "typeLabel";
            this.typeLabel.Size = new System.Drawing.Size(31, 13);
            this.typeLabel.TabIndex = 42;
            this.typeLabel.Text = "Type";
            // 
            // componentNameLabel
            // 
            this.componentNameLabel.AccessibleDescription = "componentNameLabel";
            this.componentNameLabel.AccessibleName = "componentNameLabel";
            this.componentNameLabel.AutoSize = true;
            this.componentNameLabel.Location = new System.Drawing.Point(8, 41);
            this.componentNameLabel.Name = "componentNameLabel";
            this.componentNameLabel.Size = new System.Drawing.Size(35, 13);
            this.componentNameLabel.TabIndex = 41;
            this.componentNameLabel.Text = "Name";
            // 
            // busNumbeLabel
            // 
            this.busNumbeLabel.AutoSize = true;
            this.busNumbeLabel.Location = new System.Drawing.Point(8, 12);
            this.busNumbeLabel.Name = "busNumbeLabel";
            this.busNumbeLabel.Size = new System.Drawing.Size(44, 13);
            this.busNumbeLabel.TabIndex = 40;
            this.busNumbeLabel.Text = "Number";
            // 
            // Values
            // 
            this.Values.Controls.Add(this.sfFaradDropDown);
            this.Values.Controls.Add(this.sfHenryDropDown);
            this.Values.Controls.Add(this.sfOhmDropDown);
            this.Values.Controls.Add(this.radNominalFreqText);
            this.Values.Controls.Add(this.radFaradText);
            this.Values.Controls.Add(this.radHenryText);
            this.Values.Controls.Add(this.radOhmText);
            this.Values.Controls.Add(this.NominalFreqText);
            this.Values.Controls.Add(this.rOfFreqCheck);
            this.Values.Controls.Add(this.labelRofFreq);
            this.Values.Controls.Add(this.nominalFreqcheck);
            this.Values.Controls.Add(this.labelNominaFreq);
            this.Values.Controls.Add(this.groupInductorBox);
            this.Values.Controls.Add(this.groupCapacitorBox);
            this.Values.Controls.Add(this.groupResistorBox);
            this.Values.Location = new System.Drawing.Point(4, 22);
            this.Values.Name = "Values";
            this.Values.Padding = new System.Windows.Forms.Padding(3);
            this.Values.Size = new System.Drawing.Size(447, 397);
            this.Values.TabIndex = 0;
            this.Values.Text = "Values";
            this.Values.UseVisualStyleBackColor = true;
            // 
            // sfFaradDropDown
            // 
            this.sfFaradDropDown.DropDownPosition = Syncfusion.WinForms.Core.Enums.PopupRelativeAlignment.Center;
            this.sfFaradDropDown.Location = new System.Drawing.Point(376, 188);
            this.sfFaradDropDown.Name = "sfFaradDropDown";
            this.sfFaradDropDown.Size = new System.Drawing.Size(42, 20);
            this.sfFaradDropDown.Style.TokenStyle.CloseButtonBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sfFaradDropDown.TabIndex = 26;
            // 
            // sfHenryDropDown
            // 
            this.sfHenryDropDown.DropDownPosition = Syncfusion.WinForms.Core.Enums.PopupRelativeAlignment.Center;
            this.sfHenryDropDown.Location = new System.Drawing.Point(263, 239);
            this.sfHenryDropDown.Name = "sfHenryDropDown";
            this.sfHenryDropDown.Size = new System.Drawing.Size(41, 21);
            this.sfHenryDropDown.Style.TokenStyle.CloseButtonBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sfHenryDropDown.TabIndex = 25;
            // 
            // sfOhmDropDown
            // 
            this.sfOhmDropDown.DropDownPosition = Syncfusion.WinForms.Core.Enums.PopupRelativeAlignment.Center;
            this.sfOhmDropDown.Location = new System.Drawing.Point(107, 240);
            this.sfOhmDropDown.Name = "sfOhmDropDown";
            this.sfOhmDropDown.Size = new System.Drawing.Size(43, 20);
            this.sfOhmDropDown.Style.TokenStyle.CloseButtonBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sfOhmDropDown.TabIndex = 24;
            // 
            // radNominalFreqText
            // 
            this.radNominalFreqText.Location = new System.Drawing.Point(311, 162);
            this.radNominalFreqText.Name = "radNominalFreqText";
            this.radNominalFreqText.Size = new System.Drawing.Size(107, 20);
            this.radNominalFreqText.TabIndex = 23;
            // 
            // radFaradText
            // 
            this.radFaradText.Location = new System.Drawing.Point(311, 188);
            this.radFaradText.Name = "radFaradText";
            this.radFaradText.Size = new System.Drawing.Size(64, 20);
            this.radFaradText.TabIndex = 22;
            // 
            // radHenryText
            // 
            this.radHenryText.Location = new System.Drawing.Point(188, 239);
            this.radHenryText.Name = "radHenryText";
            this.radHenryText.Size = new System.Drawing.Size(65, 20);
            this.radHenryText.TabIndex = 21;
            // 
            // radOhmText
            // 
            this.radOhmText.Location = new System.Drawing.Point(29, 240);
            this.radOhmText.Name = "radOhmText";
            this.radOhmText.Size = new System.Drawing.Size(67, 20);
            this.radOhmText.TabIndex = 20;
            // 
            // NominalFreqText
            // 
            this.NominalFreqText.Location = new System.Drawing.Point(127, 83);
            this.NominalFreqText.Name = "NominalFreqText";
            this.NominalFreqText.Size = new System.Drawing.Size(68, 20);
            this.NominalFreqText.TabIndex = 16;
            // 
            // rOfFreqCheck
            // 
            this.rOfFreqCheck.AccessibleDescription = "rOfFreqCheck";
            this.rOfFreqCheck.AccessibleName = "rOfFreqCheck";
            this.rOfFreqCheck.AutoSize = true;
            this.rOfFreqCheck.Location = new System.Drawing.Point(107, 118);
            this.rOfFreqCheck.Margin = new System.Windows.Forms.Padding(2);
            this.rOfFreqCheck.Name = "rOfFreqCheck";
            this.rOfFreqCheck.Size = new System.Drawing.Size(15, 14);
            this.rOfFreqCheck.TabIndex = 13;
            this.rOfFreqCheck.UseVisualStyleBackColor = true;
            this.rOfFreqCheck.Click += new System.EventHandler(this.rOfFreqCheck_Click);
            // 
            // labelRofFreq
            // 
            this.labelRofFreq.AccessibleDescription = "labelRofFreq";
            this.labelRofFreq.AccessibleName = "labelRofFreq";
            this.labelRofFreq.AutoSize = true;
            this.labelRofFreq.Location = new System.Drawing.Point(9, 117);
            this.labelRofFreq.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelRofFreq.Name = "labelRofFreq";
            this.labelRofFreq.Size = new System.Drawing.Size(87, 13);
            this.labelRofFreq.TabIndex = 12;
            this.labelRofFreq.Text = "is R(Frequency)?";
            // 
            // nominalFreqcheck
            // 
            this.nominalFreqcheck.AccessibleDescription = "nominalFreqcheck";
            this.nominalFreqcheck.AccessibleName = "nominalFreqcheck";
            this.nominalFreqcheck.AutoSize = true;
            this.nominalFreqcheck.Location = new System.Drawing.Point(107, 88);
            this.nominalFreqcheck.Margin = new System.Windows.Forms.Padding(2);
            this.nominalFreqcheck.Name = "nominalFreqcheck";
            this.nominalFreqcheck.Size = new System.Drawing.Size(15, 14);
            this.nominalFreqcheck.TabIndex = 11;
            this.nominalFreqcheck.UseVisualStyleBackColor = true;
            this.nominalFreqcheck.Click += new System.EventHandler(this.nominalFreqcheck_Click);
            // 
            // labelNominaFreq
            // 
            this.labelNominaFreq.AccessibleDescription = "labelNominaFreq";
            this.labelNominaFreq.AccessibleName = "labelNominaFreq";
            this.labelNominaFreq.AutoSize = true;
            this.labelNominaFreq.Location = new System.Drawing.Point(7, 86);
            this.labelNominaFreq.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelNominaFreq.Name = "labelNominaFreq";
            this.labelNominaFreq.Size = new System.Drawing.Size(98, 13);
            this.labelNominaFreq.TabIndex = 8;
            this.labelNominaFreq.Text = "Nominal Frequency";
            // 
            // groupInductorBox
            // 
            this.groupInductorBox.AccessibleDescription = "groupInductorBox";
            this.groupInductorBox.AccessibleName = "groupInductorBox";
            this.groupInductorBox.Controls.Add(this.HenryDropDown);
            this.groupInductorBox.Controls.Add(this.HenryText);
            this.groupInductorBox.Location = new System.Drawing.Point(158, 15);
            this.groupInductorBox.Margin = new System.Windows.Forms.Padding(2);
            this.groupInductorBox.Name = "groupInductorBox";
            this.groupInductorBox.Padding = new System.Windows.Forms.Padding(2);
            this.groupInductorBox.Size = new System.Drawing.Size(133, 58);
            this.groupInductorBox.TabIndex = 7;
            this.groupInductorBox.TabStop = false;
            this.groupInductorBox.Text = "Inductor";
            // 
            // HenryDropDown
            // 
            this.HenryDropDown.FormattingEnabled = true;
            this.HenryDropDown.Location = new System.Drawing.Point(77, 19);
            this.HenryDropDown.Name = "HenryDropDown";
            this.HenryDropDown.Size = new System.Drawing.Size(52, 21);
            this.HenryDropDown.TabIndex = 25;
            // 
            // HenryText
            // 
            this.HenryText.Location = new System.Drawing.Point(3, 20);
            this.HenryText.Name = "HenryText";
            this.HenryText.Size = new System.Drawing.Size(68, 20);
            this.HenryText.TabIndex = 24;
            // 
            // groupCapacitorBox
            // 
            this.groupCapacitorBox.AccessibleDescription = "groupCapacitorBox";
            this.groupCapacitorBox.AccessibleName = "groupCapacitorBox";
            this.groupCapacitorBox.Controls.Add(this.FaradDropDown);
            this.groupCapacitorBox.Controls.Add(this.FaradText);
            this.groupCapacitorBox.Location = new System.Drawing.Point(311, 15);
            this.groupCapacitorBox.Margin = new System.Windows.Forms.Padding(2);
            this.groupCapacitorBox.Name = "groupCapacitorBox";
            this.groupCapacitorBox.Padding = new System.Windows.Forms.Padding(2);
            this.groupCapacitorBox.Size = new System.Drawing.Size(133, 58);
            this.groupCapacitorBox.TabIndex = 6;
            this.groupCapacitorBox.TabStop = false;
            this.groupCapacitorBox.Text = "Capacitor";
            // 
            // FaradDropDown
            // 
            this.FaradDropDown.FormattingEnabled = true;
            this.FaradDropDown.Location = new System.Drawing.Point(79, 19);
            this.FaradDropDown.Name = "FaradDropDown";
            this.FaradDropDown.Size = new System.Drawing.Size(52, 21);
            this.FaradDropDown.TabIndex = 27;
            // 
            // FaradText
            // 
            this.FaradText.Location = new System.Drawing.Point(5, 20);
            this.FaradText.Name = "FaradText";
            this.FaradText.Size = new System.Drawing.Size(68, 20);
            this.FaradText.TabIndex = 26;
            // 
            // groupResistorBox
            // 
            this.groupResistorBox.AccessibleDescription = "groupResistorBox";
            this.groupResistorBox.AccessibleName = "groupResistorBox";
            this.groupResistorBox.Controls.Add(this.OhmDropDown);
            this.groupResistorBox.Controls.Add(this.OhmText);
            this.groupResistorBox.Location = new System.Drawing.Point(6, 15);
            this.groupResistorBox.Margin = new System.Windows.Forms.Padding(2);
            this.groupResistorBox.Name = "groupResistorBox";
            this.groupResistorBox.Padding = new System.Windows.Forms.Padding(2);
            this.groupResistorBox.Size = new System.Drawing.Size(133, 58);
            this.groupResistorBox.TabIndex = 5;
            this.groupResistorBox.TabStop = false;
            this.groupResistorBox.Text = "Resistor";
            // 
            // OhmDropDown
            // 
            this.OhmDropDown.FormattingEnabled = true;
            this.OhmDropDown.Location = new System.Drawing.Point(80, 19);
            this.OhmDropDown.Name = "OhmDropDown";
            this.OhmDropDown.Size = new System.Drawing.Size(52, 21);
            this.OhmDropDown.TabIndex = 23;
            // 
            // OhmText
            // 
            this.OhmText.Location = new System.Drawing.Point(6, 20);
            this.OhmText.Name = "OhmText";
            this.OhmText.Size = new System.Drawing.Size(68, 20);
            this.OhmText.TabIndex = 15;
            this.OhmText.TextChanged += new System.EventHandler(this.MWSetPointTXT_TextChanged);
            // 
            // RLC_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 423);
            this.Controls.Add(this.RLCCancel);
            this.Controls.Add(this.RLCOk);
            this.Controls.Add(this.RLCSave);
            this.Controls.Add(this.tabvalues);
            this.Name = "RLC_Main";
            this.ScopesTab.ResumeLayout(false);
            this.groupScopesBox.ResumeLayout(false);
            this.groupScopesBox.PerformLayout();
            this.IC.ResumeLayout(false);
            this.groupInitialVoltage.ResumeLayout(false);
            this.groupInitialVoltage.PerformLayout();
            this.groupInitialCurrent.ResumeLayout(false);
            this.groupInitialCurrent.PerformLayout();
            this.tabvalues.ResumeLayout(false);
            this.Info.ResumeLayout(false);
            this.Info.PerformLayout();
            this.statusGroup.ResumeLayout(false);
            this.statusGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumberBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ownerNumberTXT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zoneNumberTXT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.areaNumberTXT)).EndInit();
            this.Values.ResumeLayout(false);
            this.Values.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sfFaradDropDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sfHenryDropDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sfOhmDropDown)).EndInit();
            this.groupInductorBox.ResumeLayout(false);
            this.groupInductorBox.PerformLayout();
            this.groupCapacitorBox.ResumeLayout(false);
            this.groupCapacitorBox.PerformLayout();
            this.groupResistorBox.ResumeLayout(false);
            this.groupResistorBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button RLCSave;
        private System.Windows.Forms.Button RLCOk;
        private System.Windows.Forms.Button RLCCancel;
        private System.Windows.Forms.TabPage ScopesTab;
        private System.Windows.Forms.TabPage IC;
        private System.Windows.Forms.GroupBox groupInitialCurrent;
        private System.Windows.Forms.Label IoforL;
        private System.Windows.Forms.TabControl tabvalues;
        private System.Windows.Forms.GroupBox groupInitialVoltage;
        private System.Windows.Forms.Label VoForC;
        private System.Windows.Forms.GroupBox groupScopesBox;
        private System.Windows.Forms.Button resetbutton;
        private System.Windows.Forms.Button selectAllScopes;
        private System.Windows.Forms.Button clearAllScopes;
        private System.Windows.Forms.CheckBox powerCheck;
        private System.Windows.Forms.CheckBox currentCheck;
        private System.Windows.Forms.CheckBox voltageCheck;
        private System.Windows.Forms.TabPage Values;
        private System.Windows.Forms.Label labelRofFreq;
        private System.Windows.Forms.CheckBox nominalFreqcheck;
        private System.Windows.Forms.Label labelNominaFreq;
        private System.Windows.Forms.GroupBox groupInductorBox;
        private System.Windows.Forms.GroupBox groupCapacitorBox;
        private System.Windows.Forms.GroupBox groupResistorBox;
        private System.Windows.Forms.CheckBox rOfFreqCheck;
        private System.Windows.Forms.TabPage Info;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown NumberBox;
        private System.Windows.Forms.NumericUpDown ownerNumberTXT;
        private System.Windows.Forms.NumericUpDown zoneNumberTXT;
        private System.Windows.Forms.NumericUpDown areaNumberTXT;
        private System.Windows.Forms.Button changeOwner;
        private System.Windows.Forms.Button changeZone;
        private System.Windows.Forms.Button changeArea;
        private System.Windows.Forms.Label ownerLabel;
        private System.Windows.Forms.TextBox ownerNameTXT;
        private System.Windows.Forms.TextBox zoneNameTXT;
        private System.Windows.Forms.TextBox areaNameTXT;
        private System.Windows.Forms.Label zoneLabel;
        private System.Windows.Forms.Label arealabel;
        private System.Windows.Forms.Button findByNameBtn;
        private System.Windows.Forms.Button find;
        private System.Windows.Forms.Button findByNumberBtn;
        private System.Windows.Forms.TextBox branchText;
        private System.Windows.Forms.TextBox NameText;
        private System.Windows.Forms.Label typeLabel;
        private System.Windows.Forms.Label componentNameLabel;
        private System.Windows.Forms.Label busNumbeLabel;
        private System.Windows.Forms.TextBox OhmText;
        private System.Windows.Forms.ComboBox OhmDropDown;
        private System.Windows.Forms.ComboBox HenryDropDown;
        private System.Windows.Forms.TextBox HenryText;
        private System.Windows.Forms.ComboBox FaradDropDown;
        private System.Windows.Forms.TextBox FaradText;
        private System.Windows.Forms.TextBox NominalFreqText;
        private System.Windows.Forms.TextBox IoTextBox;
        private System.Windows.Forms.TextBox VoTextBox;
        private System.Windows.Forms.ComboBox VoUnitDropDown;
        private System.Windows.Forms.ComboBox IoUnitDropDown;
        private System.Windows.Forms.GroupBox statusGroup;
        private System.Windows.Forms.ComboBox phasedropbox;
        private System.Windows.Forms.RadioButton singlephase;
        private System.Windows.Forms.RadioButton treephase;
        private System.Windows.Forms.TextBox radFaradText;
        private System.Windows.Forms.TextBox radHenryText;
        private System.Windows.Forms.TextBox radOhmText;
        private System.Windows.Forms.TextBox radNominalFreqText;
        private Syncfusion.WinForms.ListView.SfComboBox sfFaradDropDown;
        private Syncfusion.WinForms.ListView.SfComboBox sfHenryDropDown;
        private Syncfusion.WinForms.ListView.SfComboBox sfOhmDropDown;
    }
}