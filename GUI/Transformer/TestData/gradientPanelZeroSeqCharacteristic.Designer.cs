namespace GUI.Transformer.TestData
{
    partial class gradientPanelZeroSeqCharacteristic
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
            this.gradientPanel1 = new Syncfusion.Windows.Forms.Tools.GradientPanel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.ZeroSequenceDataGrid = new Syncfusion.WinForms.DataGrid.SfDataGrid();
            this.label131 = new System.Windows.Forms.Label();
            this.ExcitedWindingComboBox = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gradientPanel1)).BeginInit();
            this.gradientPanel1.SuspendLayout();
            this.panel10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ZeroSequenceDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // gradientPanel1
            // 
            this.gradientPanel1.Controls.Add(this.linkLabel1);
            this.gradientPanel1.Controls.Add(this.panel10);
            this.gradientPanel1.Controls.Add(this.label131);
            this.gradientPanel1.Controls.Add(this.ExcitedWindingComboBox);
            this.gradientPanel1.Location = new System.Drawing.Point(12, 12);
            this.gradientPanel1.Name = "gradientPanel1";
            this.gradientPanel1.Size = new System.Drawing.Size(365, 406);
            this.gradientPanel1.TabIndex = 8;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(3, 372);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(131, 13);
            this.linkLabel1.TabIndex = 41;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Preview characteristic plot";
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.ZeroSequenceDataGrid);
            this.panel10.Location = new System.Drawing.Point(6, 35);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(352, 334);
            this.panel10.TabIndex = 40;
            // 
            // ZeroSequenceDataGrid
            // 
            this.ZeroSequenceDataGrid.AccessibleName = "Table";
            this.ZeroSequenceDataGrid.Location = new System.Drawing.Point(3, 3);
            this.ZeroSequenceDataGrid.Name = "ZeroSequenceDataGrid";
            this.ZeroSequenceDataGrid.Size = new System.Drawing.Size(346, 328);
            this.ZeroSequenceDataGrid.TabIndex = 0;
            this.ZeroSequenceDataGrid.Text = "sfDataGrid1";
            // 
            // label131
            // 
            this.label131.AutoSize = true;
            this.label131.Location = new System.Drawing.Point(3, 8);
            this.label131.Name = "label131";
            this.label131.Size = new System.Drawing.Size(84, 13);
            this.label131.TabIndex = 39;
            this.label131.Text = "Excited Winding";
            // 
            // ExcitedWindingComboBox
            // 
            this.ExcitedWindingComboBox.FormattingEnabled = true;
            this.ExcitedWindingComboBox.Location = new System.Drawing.Point(88, 5);
            this.ExcitedWindingComboBox.Name = "ExcitedWindingComboBox";
            this.ExcitedWindingComboBox.Size = new System.Drawing.Size(46, 21);
            this.ExcitedWindingComboBox.TabIndex = 38;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(38, 455);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(273, 455);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 10;
            this.button2.Text = "Cancle";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // gradientPanelZeroSeqCharacteristic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 522);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.gradientPanel1);
            this.Name = "gradientPanelZeroSeqCharacteristic";
            this.Text = "gradientPanelZeroSeqCharacteristic";
            ((System.ComponentModel.ISupportInitialize)(this.gradientPanel1)).EndInit();
            this.gradientPanel1.ResumeLayout(false);
            this.gradientPanel1.PerformLayout();
            this.panel10.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ZeroSequenceDataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Syncfusion.Windows.Forms.Tools.GradientPanel gradientPanel1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Label label131;
        private System.Windows.Forms.ComboBox ExcitedWindingComboBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private Syncfusion.WinForms.DataGrid.SfDataGrid ZeroSequenceDataGrid;
    }
}