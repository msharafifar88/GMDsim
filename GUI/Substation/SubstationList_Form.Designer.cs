namespace GUI.Substation
{
    partial class SubstationList_Form
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
            this.sfDataGrid1 = new Syncfusion.WinForms.DataGrid.SfDataGrid();
            this.Save = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.sfDataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // sfDataGrid1
            // 
            this.sfDataGrid1.AccessibleName = "Table";
            this.sfDataGrid1.Location = new System.Drawing.Point(12, 12);
            this.sfDataGrid1.Name = "sfDataGrid1";
            this.sfDataGrid1.Size = new System.Drawing.Size(657, 379);
            this.sfDataGrid1.TabIndex = 0;
            this.sfDataGrid1.Text = "sfDataGrid1";
            this.sfDataGrid1.SelectionChanged += new Syncfusion.WinForms.DataGrid.Events.SelectionChangedEventHandler(this.sfDataGrid1_SelectionChanged);
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(12, 407);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(95, 31);
            this.Save.TabIndex = 1;
            this.Save.Text = "Select";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(113, 407);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(95, 31);
            this.Cancel.TabIndex = 2;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // SubstationList_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 450);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.sfDataGrid1);
            this.Name = "SubstationList_Form";
            this.Text = "SubstationList";
            ((System.ComponentModel.ISupportInitialize)(this.sfDataGrid1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Syncfusion.WinForms.DataGrid.SfDataGrid sfDataGrid1;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.Button Cancel;
    }
}