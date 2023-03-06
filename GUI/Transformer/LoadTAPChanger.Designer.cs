namespace GUI.Transformer
{
    partial class LoadTAPChanger
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBUS = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.gp2_textbox_2 = new Syncfusion.WinForms.Input.SfNumericTextBox();
            this.gp2_textbox_3 = new Syncfusion.WinForms.Input.SfNumericTextBox();
            this.gp2_textbox_1 = new Syncfusion.WinForms.Input.SfNumericTextBox();
            this.label_g2_l1 = new System.Windows.Forms.Label();
            this.label_g2_l2 = new System.Windows.Forms.Label();
            this.label_g2_l3 = new System.Windows.Forms.Label();
            this.label_VoltageControl5 = new System.Windows.Forms.Label();
            this.label_VoltageControl3 = new System.Windows.Forms.Label();
            this.label_VoltageControl1 = new System.Windows.Forms.Label();
            this.tap_group = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.NumOfTab = new System.Windows.Forms.NumericUpDown();
            this.label22 = new System.Windows.Forms.Label();
            this.tap_kv_step = new System.Windows.Forms.TextBox();
            this.tap_kv_max = new System.Windows.Forms.TextBox();
            this.tap_kv_min = new System.Windows.Forms.TextBox();
            this.olu = new System.Windows.Forms.Label();
            this.tap_max_txt = new Syncfusion.WinForms.Input.SfNumericTextBox();
            this.tap_step_txt = new Syncfusion.WinForms.Input.SfNumericTextBox();
            this.tap_min_txt = new Syncfusion.WinForms.Input.SfNumericTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.timedelay_groupbox = new System.Windows.Forms.GroupBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.operatinig_txt = new Syncfusion.WinForms.Input.SfNumericTextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.initial_txt = new Syncfusion.WinForms.Input.SfNumericTextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.groupLineDropCompensation = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.reactance_txt = new Syncfusion.WinForms.Input.SfNumericTextBox();
            this.resistance_txt = new Syncfusion.WinForms.Input.SfNumericTextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.LineDropCompensation = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tap_group.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumOfTab)).BeginInit();
            this.timedelay_groupbox.SuspendLayout();
            this.groupLineDropCompensation.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBUS);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(538, 92);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Regulated Bus";
            // 
            // comboBUS
            // 
            this.comboBUS.FormattingEnabled = true;
            this.comboBUS.Location = new System.Drawing.Point(92, 33);
            this.comboBUS.Name = "comboBUS";
            this.comboBUS.Size = new System.Drawing.Size(387, 21);
            this.comboBUS.TabIndex = 1;
            this.comboBUS.SelectionChangeCommitted += new System.EventHandler(this.comboBUS_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bus ID:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.gp2_textbox_2);
            this.groupBox2.Controls.Add(this.gp2_textbox_3);
            this.groupBox2.Controls.Add(this.gp2_textbox_1);
            this.groupBox2.Controls.Add(this.label_g2_l1);
            this.groupBox2.Controls.Add(this.label_g2_l2);
            this.groupBox2.Controls.Add(this.label_g2_l3);
            this.groupBox2.Controls.Add(this.label_VoltageControl5);
            this.groupBox2.Controls.Add(this.label_VoltageControl3);
            this.groupBox2.Controls.Add(this.label_VoltageControl1);
            this.groupBox2.Location = new System.Drawing.Point(12, 110);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(538, 112);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Voltage Control";
            // 
            // gp2_textbox_2
            // 
            this.gp2_textbox_2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gp2_textbox_2.Location = new System.Drawing.Point(388, 32);
            this.gp2_textbox_2.Name = "gp2_textbox_2";
            this.gp2_textbox_2.Size = new System.Drawing.Size(101, 20);
            this.gp2_textbox_2.Style.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.gp2_textbox_2.TabIndex = 8;
            // 
            // gp2_textbox_3
            // 
            this.gp2_textbox_3.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gp2_textbox_3.Location = new System.Drawing.Point(388, 73);
            this.gp2_textbox_3.Name = "gp2_textbox_3";
            this.gp2_textbox_3.Size = new System.Drawing.Size(101, 20);
            this.gp2_textbox_3.Style.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.gp2_textbox_3.TabIndex = 7;
            // 
            // gp2_textbox_1
            // 
            this.gp2_textbox_1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gp2_textbox_1.Location = new System.Drawing.Point(130, 50);
            this.gp2_textbox_1.Name = "gp2_textbox_1";
            this.gp2_textbox_1.Size = new System.Drawing.Size(101, 20);
            this.gp2_textbox_1.Style.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.gp2_textbox_1.TabIndex = 6;
            // 
            // label_g2_l1
            // 
            this.label_g2_l1.AutoSize = true;
            this.label_g2_l1.Location = new System.Drawing.Point(497, 35);
            this.label_g2_l1.Name = "label_g2_l1";
            this.label_g2_l1.Size = new System.Drawing.Size(15, 13);
            this.label_g2_l1.TabIndex = 5;
            this.label_g2_l1.Text = "%";
            // 
            // label_g2_l2
            // 
            this.label_g2_l2.AutoSize = true;
            this.label_g2_l2.Location = new System.Drawing.Point(498, 77);
            this.label_g2_l2.Name = "label_g2_l2";
            this.label_g2_l2.Size = new System.Drawing.Size(15, 13);
            this.label_g2_l2.TabIndex = 4;
            this.label_g2_l2.Text = "%";
            // 
            // label_g2_l3
            // 
            this.label_g2_l3.AutoSize = true;
            this.label_g2_l3.Location = new System.Drawing.Point(239, 52);
            this.label_g2_l3.Name = "label_g2_l3";
            this.label_g2_l3.Size = new System.Drawing.Size(15, 13);
            this.label_g2_l3.TabIndex = 3;
            this.label_g2_l3.Text = "%";
            // 
            // label_VoltageControl5
            // 
            this.label_VoltageControl5.AutoSize = true;
            this.label_VoltageControl5.Location = new System.Drawing.Point(316, 77);
            this.label_VoltageControl5.Name = "label_VoltageControl5";
            this.label_VoltageControl5.Size = new System.Drawing.Size(64, 13);
            this.label_VoltageControl5.TabIndex = 2;
            this.label_VoltageControl5.Text = "Lower Band";
            // 
            // label_VoltageControl3
            // 
            this.label_VoltageControl3.AutoSize = true;
            this.label_VoltageControl3.Location = new System.Drawing.Point(314, 35);
            this.label_VoltageControl3.Name = "label_VoltageControl3";
            this.label_VoltageControl3.Size = new System.Drawing.Size(64, 13);
            this.label_VoltageControl3.TabIndex = 1;
            this.label_VoltageControl3.Text = "Upper Band";
            // 
            // label_VoltageControl1
            // 
            this.label_VoltageControl1.AutoSize = true;
            this.label_VoltageControl1.Location = new System.Drawing.Point(39, 55);
            this.label_VoltageControl1.Name = "label_VoltageControl1";
            this.label_VoltageControl1.Size = new System.Drawing.Size(85, 13);
            this.label_VoltageControl1.TabIndex = 0;
            this.label_VoltageControl1.Text = "Voltage Setpoint";
            // 
            // tap_group
            // 
            this.tap_group.Controls.Add(this.label4);
            this.tap_group.Controls.Add(this.label3);
            this.tap_group.Controls.Add(this.NumOfTab);
            this.tap_group.Controls.Add(this.label22);
            this.tap_group.Controls.Add(this.tap_kv_step);
            this.tap_group.Controls.Add(this.tap_kv_max);
            this.tap_group.Controls.Add(this.tap_kv_min);
            this.tap_group.Controls.Add(this.olu);
            this.tap_group.Controls.Add(this.tap_max_txt);
            this.tap_group.Controls.Add(this.tap_step_txt);
            this.tap_group.Controls.Add(this.tap_min_txt);
            this.tap_group.Controls.Add(this.label8);
            this.tap_group.Controls.Add(this.label9);
            this.tap_group.Controls.Add(this.label10);
            this.tap_group.Controls.Add(this.label11);
            this.tap_group.Controls.Add(this.label12);
            this.tap_group.Controls.Add(this.label13);
            this.tap_group.Location = new System.Drawing.Point(12, 228);
            this.tap_group.Name = "tap_group";
            this.tap_group.Size = new System.Drawing.Size(352, 179);
            this.tap_group.TabIndex = 2;
            this.tap_group.TabStop = false;
            this.tap_group.Text = "Tap";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(104, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "(deg.)";
            this.label4.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(93, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Phase Angle";
            this.label3.Visible = false;
            // 
            // NumOfTab
            // 
            this.NumOfTab.Location = new System.Drawing.Point(263, 126);
            this.NumOfTab.Name = "NumOfTab";
            this.NumOfTab.Size = new System.Drawing.Size(50, 20);
            this.NumOfTab.TabIndex = 14;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(260, 99);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(53, 13);
            this.label22.TabIndex = 13;
            this.label22.Text = "# of Taps";
            // 
            // tap_kv_step
            // 
            this.tap_kv_step.Location = new System.Drawing.Point(178, 126);
            this.tap_kv_step.Name = "tap_kv_step";
            this.tap_kv_step.ReadOnly = true;
            this.tap_kv_step.Size = new System.Drawing.Size(63, 20);
            this.tap_kv_step.TabIndex = 12;
            // 
            // tap_kv_max
            // 
            this.tap_kv_max.Location = new System.Drawing.Point(178, 91);
            this.tap_kv_max.Name = "tap_kv_max";
            this.tap_kv_max.ReadOnly = true;
            this.tap_kv_max.Size = new System.Drawing.Size(63, 20);
            this.tap_kv_max.TabIndex = 11;
            // 
            // tap_kv_min
            // 
            this.tap_kv_min.Location = new System.Drawing.Point(178, 51);
            this.tap_kv_min.Name = "tap_kv_min";
            this.tap_kv_min.ReadOnly = true;
            this.tap_kv_min.Size = new System.Drawing.Size(63, 20);
            this.tap_kv_min.TabIndex = 10;
            // 
            // olu
            // 
            this.olu.AutoSize = true;
            this.olu.Location = new System.Drawing.Point(105, 23);
            this.olu.Name = "olu";
            this.olu.Size = new System.Drawing.Size(37, 13);
            this.olu.TabIndex = 9;
            this.olu.Text = "% Tap";
            // 
            // tap_max_txt
            // 
            this.tap_max_txt.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tap_max_txt.Location = new System.Drawing.Point(92, 90);
            this.tap_max_txt.Name = "tap_max_txt";
            this.tap_max_txt.Size = new System.Drawing.Size(68, 20);
            this.tap_max_txt.Style.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.tap_max_txt.TabIndex = 8;
            // 
            // tap_step_txt
            // 
            this.tap_step_txt.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tap_step_txt.Location = new System.Drawing.Point(91, 126);
            this.tap_step_txt.Name = "tap_step_txt";
            this.tap_step_txt.Size = new System.Drawing.Size(68, 20);
            this.tap_step_txt.Style.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.tap_step_txt.TabIndex = 7;
            // 
            // tap_min_txt
            // 
            this.tap_min_txt.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tap_min_txt.Location = new System.Drawing.Point(92, 50);
            this.tap_min_txt.Name = "tap_min_txt";
            this.tap_min_txt.Size = new System.Drawing.Size(68, 20);
            this.tap_min_txt.Style.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.tap_min_txt.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(497, 35);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(15, 13);
            this.label8.TabIndex = 5;
            this.label8.Text = "%";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(498, 77);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(15, 13);
            this.label9.TabIndex = 4;
            this.label9.Text = "%";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(191, 23);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(42, 13);
            this.label10.TabIndex = 3;
            this.label10.Text = "kV Tap";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(39, 128);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 13);
            this.label11.TabIndex = 2;
            this.label11.Text = "Step";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(39, 94);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(27, 13);
            this.label12.TabIndex = 1;
            this.label12.Text = "Max";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(39, 52);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(27, 13);
            this.label13.TabIndex = 0;
            this.label13.Text = "Min.";
            // 
            // timedelay_groupbox
            // 
            this.timedelay_groupbox.Controls.Add(this.label21);
            this.timedelay_groupbox.Controls.Add(this.label20);
            this.timedelay_groupbox.Controls.Add(this.operatinig_txt);
            this.timedelay_groupbox.Controls.Add(this.label17);
            this.timedelay_groupbox.Controls.Add(this.initial_txt);
            this.timedelay_groupbox.Controls.Add(this.label14);
            this.timedelay_groupbox.Controls.Add(this.label15);
            this.timedelay_groupbox.Controls.Add(this.label16);
            this.timedelay_groupbox.Controls.Add(this.label19);
            this.timedelay_groupbox.Location = new System.Drawing.Point(370, 228);
            this.timedelay_groupbox.Name = "timedelay_groupbox";
            this.timedelay_groupbox.Size = new System.Drawing.Size(180, 179);
            this.timedelay_groupbox.TabIndex = 3;
            this.timedelay_groupbox.TabStop = false;
            this.timedelay_groupbox.Text = "Time Delay";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(59, 34);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(31, 13);
            this.label21.TabIndex = 10;
            this.label21.Text = "Initial";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(44, 99);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(53, 13);
            this.label20.TabIndex = 9;
            this.label20.Text = "Operating";
            // 
            // operatinig_txt
            // 
            this.operatinig_txt.ForeColor = System.Drawing.SystemColors.WindowText;
            this.operatinig_txt.Location = new System.Drawing.Point(30, 121);
            this.operatinig_txt.Name = "operatinig_txt";
            this.operatinig_txt.Size = new System.Drawing.Size(91, 20);
            this.operatinig_txt.Style.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.operatinig_txt.TabIndex = 8;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(127, 124);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(27, 13);
            this.label17.TabIndex = 7;
            this.label17.Text = "sec.";
            // 
            // initial_txt
            // 
            this.initial_txt.ForeColor = System.Drawing.SystemColors.WindowText;
            this.initial_txt.Location = new System.Drawing.Point(30, 54);
            this.initial_txt.Name = "initial_txt";
            this.initial_txt.Size = new System.Drawing.Size(91, 20);
            this.initial_txt.Style.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.initial_txt.TabIndex = 6;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(497, 35);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(15, 13);
            this.label14.TabIndex = 5;
            this.label14.Text = "%";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(498, 77);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(15, 13);
            this.label15.TabIndex = 4;
            this.label15.Text = "%";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(239, 52);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(15, 13);
            this.label16.TabIndex = 3;
            this.label16.Text = "%";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(127, 58);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(27, 13);
            this.label19.TabIndex = 0;
            this.label19.Text = "sec.";
            // 
            // groupLineDropCompensation
            // 
            this.groupLineDropCompensation.Controls.Add(this.label2);
            this.groupLineDropCompensation.Controls.Add(this.reactance_txt);
            this.groupLineDropCompensation.Controls.Add(this.resistance_txt);
            this.groupLineDropCompensation.Controls.Add(this.label24);
            this.groupLineDropCompensation.Controls.Add(this.label25);
            this.groupLineDropCompensation.Controls.Add(this.label26);
            this.groupLineDropCompensation.Controls.Add(this.label28);
            this.groupLineDropCompensation.Enabled = false;
            this.groupLineDropCompensation.Location = new System.Drawing.Point(12, 445);
            this.groupLineDropCompensation.Name = "groupLineDropCompensation";
            this.groupLineDropCompensation.Size = new System.Drawing.Size(538, 80);
            this.groupLineDropCompensation.TabIndex = 4;
            this.groupLineDropCompensation.TabStop = false;
            this.groupLineDropCompensation.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(228, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "( % of system MVA )";
            // 
            // reactance_txt
            // 
            this.reactance_txt.ForeColor = System.Drawing.SystemColors.WindowText;
            this.reactance_txt.Location = new System.Drawing.Point(405, 29);
            this.reactance_txt.Name = "reactance_txt";
            this.reactance_txt.Size = new System.Drawing.Size(84, 20);
            this.reactance_txt.Style.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.reactance_txt.TabIndex = 7;
            // 
            // resistance_txt
            // 
            this.resistance_txt.ForeColor = System.Drawing.SystemColors.WindowText;
            this.resistance_txt.Location = new System.Drawing.Point(130, 29);
            this.resistance_txt.Name = "resistance_txt";
            this.resistance_txt.Size = new System.Drawing.Size(101, 20);
            this.resistance_txt.Style.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.resistance_txt.TabIndex = 6;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(498, 33);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(15, 13);
            this.label24.TabIndex = 4;
            this.label24.Text = "%";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(239, 31);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(15, 13);
            this.label25.TabIndex = 3;
            this.label25.Text = "%";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(316, 33);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(76, 13);
            this.label26.TabIndex = 2;
            this.label26.Text = "Reactance (X)";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(39, 34);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(77, 13);
            this.label28.TabIndex = 0;
            this.label28.Text = "Resistance (R)";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(91, 544);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(62, 34);
            this.button1.TabIndex = 5;
            this.button1.Text = "Help";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(370, 544);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(62, 34);
            this.button2.TabIndex = 6;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(232, 544);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(62, 34);
            this.button3.TabIndex = 7;
            this.button3.Text = "OK";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // LineDropCompensation
            // 
            this.LineDropCompensation.AutoSize = true;
            this.LineDropCompensation.Location = new System.Drawing.Point(12, 422);
            this.LineDropCompensation.Name = "LineDropCompensation";
            this.LineDropCompensation.Size = new System.Drawing.Size(142, 17);
            this.LineDropCompensation.TabIndex = 10;
            this.LineDropCompensation.Text = "Line Drop Compensation";
            this.LineDropCompensation.UseVisualStyleBackColor = true;
            this.LineDropCompensation.Visible = false;
            this.LineDropCompensation.CheckedChanged += new System.EventHandler(this.LineDropCompensation_CheckedChanged);
            // 
            // LoadTAPChanger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 601);
            this.Controls.Add(this.LineDropCompensation);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupLineDropCompensation);
            this.Controls.Add(this.timedelay_groupbox);
            this.Controls.Add(this.tap_group);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "LoadTAPChanger";
            this.Text = "LoadTAPChanger";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tap_group.ResumeLayout(false);
            this.tap_group.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumOfTab)).EndInit();
            this.timedelay_groupbox.ResumeLayout(false);
            this.timedelay_groupbox.PerformLayout();
            this.groupLineDropCompensation.ResumeLayout(false);
            this.groupLineDropCompensation.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private Syncfusion.WinForms.Input.SfNumericTextBox gp2_textbox_2;
        private Syncfusion.WinForms.Input.SfNumericTextBox gp2_textbox_3;
        private Syncfusion.WinForms.Input.SfNumericTextBox gp2_textbox_1;
        private System.Windows.Forms.Label label_g2_l1;
        private System.Windows.Forms.Label label_g2_l2;
        private System.Windows.Forms.Label label_g2_l3;
        private System.Windows.Forms.Label label_VoltageControl5;
        private System.Windows.Forms.Label label_VoltageControl3;
        private System.Windows.Forms.Label label_VoltageControl1;
        private System.Windows.Forms.GroupBox tap_group;
        private System.Windows.Forms.Label olu;
        private Syncfusion.WinForms.Input.SfNumericTextBox tap_max_txt;
        private Syncfusion.WinForms.Input.SfNumericTextBox tap_step_txt;
        private Syncfusion.WinForms.Input.SfNumericTextBox tap_min_txt;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.GroupBox timedelay_groupbox;
        private Syncfusion.WinForms.Input.SfNumericTextBox operatinig_txt;
        private System.Windows.Forms.Label label17;
        private Syncfusion.WinForms.Input.SfNumericTextBox initial_txt;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.NumericUpDown NumOfTab;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox tap_kv_step;
        private System.Windows.Forms.TextBox tap_kv_max;
        private System.Windows.Forms.TextBox tap_kv_min;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.GroupBox groupLineDropCompensation;
        private Syncfusion.WinForms.Input.SfNumericTextBox reactance_txt;
        private Syncfusion.WinForms.Input.SfNumericTextBox resistance_txt;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.CheckBox LineDropCompensation;
        private System.Windows.Forms.ComboBox comboBUS;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}