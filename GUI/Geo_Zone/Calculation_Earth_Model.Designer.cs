namespace GUI.Geo_Zone
{
    partial class Calculation_Earth_Model
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Geozone_Start_Numbox = new Syncfusion.Windows.Forms.Tools.DoubleTextBox();
            this.Geozone_End_Num = new Syncfusion.Windows.Forms.Tools.DoubleTextBox();
            this.Geozone_point = new Syncfusion.Windows.Forms.Tools.DoubleTextBox();
            this.Ca = new System.Windows.Forms.Button();
            this.saveBTN = new System.Windows.Forms.Button();
            this.logarithmic_rangebox = new System.Windows.Forms.RadioButton();
            this.Linear_rangebox = new System.Windows.Forms.RadioButton();
            this.Function_OrderBox = new Syncfusion.Windows.Forms.Tools.DoubleTextBox();
            this.Function_Orderradio = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.Plot = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.Geozone_Start_Numbox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Geozone_End_Num)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Geozone_point)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Function_OrderBox)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Starting Frequency";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "End Frequency";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Number of Point";
            // 
            // Geozone_Start_Numbox
            // 
            this.Geozone_Start_Numbox.BeforeTouchSize = new System.Drawing.Size(72, 20);
            this.Geozone_Start_Numbox.DoubleValue = 1D;
            this.Geozone_Start_Numbox.Location = new System.Drawing.Point(185, 59);
            this.Geozone_Start_Numbox.Name = "Geozone_Start_Numbox";
            this.Geozone_Start_Numbox.NumberDecimalDigits = 0;
            this.Geozone_Start_Numbox.NumberGroupSeparator = "";
            this.Geozone_Start_Numbox.Size = new System.Drawing.Size(104, 20);
            this.Geozone_Start_Numbox.TabIndex = 7;
            this.Geozone_Start_Numbox.Text = "1";
            // 
            // Geozone_End_Num
            // 
            this.Geozone_End_Num.BeforeTouchSize = new System.Drawing.Size(72, 20);
            this.Geozone_End_Num.DoubleValue = 1D;
            this.Geozone_End_Num.Location = new System.Drawing.Point(185, 87);
            this.Geozone_End_Num.Name = "Geozone_End_Num";
            this.Geozone_End_Num.NumberDecimalDigits = 0;
            this.Geozone_End_Num.NumberGroupSeparator = "";
            this.Geozone_End_Num.Size = new System.Drawing.Size(104, 20);
            this.Geozone_End_Num.TabIndex = 8;
            this.Geozone_End_Num.Text = "1";
            // 
            // Geozone_point
            // 
            this.Geozone_point.BeforeTouchSize = new System.Drawing.Size(72, 20);
            this.Geozone_point.DoubleValue = 1D;
            this.Geozone_point.Location = new System.Drawing.Point(185, 113);
            this.Geozone_point.Name = "Geozone_point";
            this.Geozone_point.NumberDecimalDigits = 0;
            this.Geozone_point.NumberGroupSeparator = "";
            this.Geozone_point.Size = new System.Drawing.Size(104, 20);
            this.Geozone_point.TabIndex = 9;
            this.Geozone_point.Text = "1";
            // 
            // Ca
            // 
            this.Ca.Location = new System.Drawing.Point(209, 189);
            this.Ca.Name = "Ca";
            this.Ca.Size = new System.Drawing.Size(80, 23);
            this.Ca.TabIndex = 13;
            this.Ca.Text = "Cancel";
            this.Ca.UseVisualStyleBackColor = true;
            // 
            // saveBTN
            // 
            this.saveBTN.Location = new System.Drawing.Point(8, 189);
            this.saveBTN.Name = "saveBTN";
            this.saveBTN.Size = new System.Drawing.Size(78, 23);
            this.saveBTN.TabIndex = 12;
            this.saveBTN.Text = "Save";
            this.saveBTN.UseVisualStyleBackColor = true;
            this.saveBTN.Click += new System.EventHandler(this.saveBTN_Click);
            // 
            // logarithmic_rangebox
            // 
            this.logarithmic_rangebox.AutoSize = true;
            this.logarithmic_rangebox.Location = new System.Drawing.Point(12, 26);
            this.logarithmic_rangebox.Name = "logarithmic_rangebox";
            this.logarithmic_rangebox.Size = new System.Drawing.Size(114, 17);
            this.logarithmic_rangebox.TabIndex = 35;
            this.logarithmic_rangebox.TabStop = true;
            this.logarithmic_rangebox.Text = "Logarithmic Range";
            this.logarithmic_rangebox.UseVisualStyleBackColor = true;
            // 
            // Linear_rangebox
            // 
            this.Linear_rangebox.AutoSize = true;
            this.Linear_rangebox.Location = new System.Drawing.Point(185, 26);
            this.Linear_rangebox.Name = "Linear_rangebox";
            this.Linear_rangebox.Size = new System.Drawing.Size(89, 17);
            this.Linear_rangebox.TabIndex = 36;
            this.Linear_rangebox.TabStop = true;
            this.Linear_rangebox.Text = "Linear Range";
            this.Linear_rangebox.UseVisualStyleBackColor = true;
            // 
            // Function_OrderBox
            // 
            this.Function_OrderBox.BeforeTouchSize = new System.Drawing.Size(72, 20);
            this.Function_OrderBox.DoubleValue = 1D;
            this.Function_OrderBox.Location = new System.Drawing.Point(185, 141);
            this.Function_OrderBox.Name = "Function_OrderBox";
            this.Function_OrderBox.NumberDecimalDigits = 0;
            this.Function_OrderBox.NumberGroupSeparator = "";
            this.Function_OrderBox.ReadOnly = true;
            this.Function_OrderBox.Size = new System.Drawing.Size(104, 20);
            this.Function_OrderBox.TabIndex = 38;
            this.Function_OrderBox.Text = "1";
            // 
            // Function_Orderradio
            // 
            this.Function_Orderradio.AutoSize = true;
            this.Function_Orderradio.Location = new System.Drawing.Point(12, 144);
            this.Function_Orderradio.Name = "Function_Orderradio";
            this.Function_Orderradio.Size = new System.Drawing.Size(95, 17);
            this.Function_Orderradio.TabIndex = 39;
            this.Function_Orderradio.TabStop = true;
            this.Function_Orderradio.Text = "Function Order";
            this.Function_Orderradio.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(106, 189);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(82, 23);
            this.button1.TabIndex = 40;
            this.button1.Text = "Run";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Plot
            // 
            this.Plot.Location = new System.Drawing.Point(346, 12);
            this.Plot.Name = "Plot";
            this.Plot.Size = new System.Drawing.Size(669, 514);
            this.Plot.TabIndex = 41;
            this.Plot.TabStop = false;
            this.Plot.Text = "Characteristics";
            // 
            // Calculation_Earth_Model
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1027, 538);
            this.Controls.Add(this.Plot);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Function_Orderradio);
            this.Controls.Add(this.Function_OrderBox);
            this.Controls.Add(this.Linear_rangebox);
            this.Controls.Add(this.logarithmic_rangebox);
            this.Controls.Add(this.Ca);
            this.Controls.Add(this.saveBTN);
            this.Controls.Add(this.Geozone_point);
            this.Controls.Add(this.Geozone_End_Num);
            this.Controls.Add(this.Geozone_Start_Numbox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Calculation_Earth_Model";
            this.Text = "Geo_Zone_calculation";
            ((System.ComponentModel.ISupportInitialize)(this.Geozone_Start_Numbox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Geozone_End_Num)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Geozone_point)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Function_OrderBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private Syncfusion.Windows.Forms.Tools.DoubleTextBox Geozone_Start_Numbox;
        private Syncfusion.Windows.Forms.Tools.DoubleTextBox Geozone_End_Num;
        private Syncfusion.Windows.Forms.Tools.DoubleTextBox Geozone_point;
        private System.Windows.Forms.Button Ca;
        private System.Windows.Forms.Button saveBTN;
        private System.Windows.Forms.RadioButton logarithmic_rangebox;
        private System.Windows.Forms.RadioButton Linear_rangebox;
        private Syncfusion.Windows.Forms.Tools.DoubleTextBox Function_OrderBox;
        private System.Windows.Forms.RadioButton Function_Orderradio;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox Plot;
    }
}