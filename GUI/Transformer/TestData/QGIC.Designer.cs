namespace GUI.Transformer.TestData
{
    partial class QGIC
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
            this.QGICCharacteristicDataGrid = new Syncfusion.WinForms.DataGrid.SfDataGrid();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.QGICPlot = new System.Windows.Forms.LinkLabel();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.QGICCharacteristicDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.QGICPlot);
            this.groupBox1.Controls.Add(this.QGICCharacteristicDataGrid);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(384, 386);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Q - GIC Characteristic";
            // 
            // QGICCharacteristicDataGrid
            // 
            this.QGICCharacteristicDataGrid.AccessibleName = "Table";
            this.QGICCharacteristicDataGrid.Location = new System.Drawing.Point(6, 19);
            this.QGICCharacteristicDataGrid.Name = "QGICCharacteristicDataGrid";
            this.QGICCharacteristicDataGrid.Size = new System.Drawing.Size(372, 340);
            this.QGICCharacteristicDataGrid.TabIndex = 0;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(321, 415);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 12;
            this.button2.Text = "Cancle";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 415);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // QGICPlot
            // 
            this.QGICPlot.AutoSize = true;
            this.QGICPlot.Location = new System.Drawing.Point(7, 364);
            this.QGICPlot.Name = "QGICPlot";
            this.QGICPlot.Size = new System.Drawing.Size(131, 13);
            this.QGICPlot.TabIndex = 42;
            this.QGICPlot.TabStop = true;
            this.QGICPlot.Text = "Preview characteristic plot";
            // 
            // QGIC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 450);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Name = "QGIC";
            this.Text = "QGIC";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.QGICCharacteristicDataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private Syncfusion.WinForms.DataGrid.SfDataGrid QGICCharacteristicDataGrid;
        private System.Windows.Forms.LinkLabel QGICPlot;
    }
}