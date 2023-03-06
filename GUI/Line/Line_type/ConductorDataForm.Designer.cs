namespace GUI.Line.Line_type
{
    partial class ConductorDataForm
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
            Syncfusion.WinForms.DataGrid.GridTextColumn gridTextColumn1 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            this.ConductorData = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.numberOfCablesval = new System.Windows.Forms.NumericUpDown();
            this.numberOfCablesLBL = new System.Windows.Forms.Label();
            this.cableTypeLBL = new System.Windows.Forms.Label();
            this.cableTypeCombo = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.sfConductorData = new Syncfusion.WinForms.DataGrid.SfDataGrid();
            this.ConductorData.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numberOfCablesval)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sfConductorData)).BeginInit();
            this.SuspendLayout();
            // 
            // ConductorData
            // 
            this.ConductorData.Controls.Add(this.panel2);
            this.ConductorData.Controls.Add(this.panel1);
            this.ConductorData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ConductorData.Location = new System.Drawing.Point(0, 0);
            this.ConductorData.Name = "ConductorData";
            this.ConductorData.Size = new System.Drawing.Size(616, 395);
            this.ConductorData.TabIndex = 1;
            this.ConductorData.TabStop = false;
            this.ConductorData.Text = "Conductor Data";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.numberOfCablesval);
            this.panel1.Controls.Add(this.numberOfCablesLBL);
            this.panel1.Controls.Add(this.cableTypeLBL);
            this.panel1.Controls.Add(this.cableTypeCombo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.ImeMode = System.Windows.Forms.ImeMode.On;
            this.panel1.Location = new System.Drawing.Point(3, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(610, 33);
            this.panel1.TabIndex = 2;
            // 
            // numberOfCablesval
            // 
            this.numberOfCablesval.Location = new System.Drawing.Point(412, 6);
            this.numberOfCablesval.Name = "numberOfCablesval";
            this.numberOfCablesval.Size = new System.Drawing.Size(120, 20);
            this.numberOfCablesval.TabIndex = 7;
            // 
            // numberOfCablesLBL
            // 
            this.numberOfCablesLBL.AutoSize = true;
            this.numberOfCablesLBL.Location = new System.Drawing.Point(316, 8);
            this.numberOfCablesLBL.Name = "numberOfCablesLBL";
            this.numberOfCablesLBL.Size = new System.Drawing.Size(90, 13);
            this.numberOfCablesLBL.TabIndex = 6;
            this.numberOfCablesLBL.Text = "Number of cables";
            // 
            // cableTypeLBL
            // 
            this.cableTypeLBL.AutoSize = true;
            this.cableTypeLBL.Location = new System.Drawing.Point(65, 9);
            this.cableTypeLBL.Name = "cableTypeLBL";
            this.cableTypeLBL.Size = new System.Drawing.Size(58, 13);
            this.cableTypeLBL.TabIndex = 5;
            this.cableTypeLBL.Text = "CableType";
            // 
            // cableTypeCombo
            // 
            this.cableTypeCombo.FormattingEnabled = true;
            this.cableTypeCombo.Location = new System.Drawing.Point(132, 6);
            this.cableTypeCombo.Name = "cableTypeCombo";
            this.cableTypeCombo.Size = new System.Drawing.Size(121, 21);
            this.cableTypeCombo.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.sfConductorData);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 49);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(610, 343);
            this.panel2.TabIndex = 3;
            // 
            // sfConductorData
            // 
            this.sfConductorData.AccessibleName = "Table";
            gridTextColumn1.HeaderText = "Wire";
            gridTextColumn1.MappingName = "Wire";
            this.sfConductorData.Columns.Add(gridTextColumn1);
            this.sfConductorData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sfConductorData.Location = new System.Drawing.Point(0, 0);
            this.sfConductorData.Name = "sfConductorData";
            this.sfConductorData.Size = new System.Drawing.Size(610, 343);
            this.sfConductorData.TabIndex = 2;
            this.sfConductorData.Text = "sfConductorData";
            // 
            // ConductorDataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(616, 395);
            this.Controls.Add(this.ConductorData);
            this.Name = "ConductorDataForm";
            this.Text = "ConductorDataForm";
            this.ConductorData.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numberOfCablesval)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sfConductorData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox ConductorData;
        private System.Windows.Forms.Panel panel2;
        private Syncfusion.WinForms.DataGrid.SfDataGrid sfConductorData;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.NumericUpDown numberOfCablesval;
        private System.Windows.Forms.Label numberOfCablesLBL;
        private System.Windows.Forms.Label cableTypeLBL;
        private System.Windows.Forms.ComboBox cableTypeCombo;
    }
}