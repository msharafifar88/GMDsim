namespace GUI.search
{
    partial class ChangeForm
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
            this.Save = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.informationDataGrid = new Syncfusion.WinForms.DataGrid.SfDataGrid();
            this.Add = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.informationDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(13, 616);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(75, 23);
            this.Save.TabIndex = 1;
            this.Save.Text = "Save";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // cancel
            // 
            this.cancel.Location = new System.Drawing.Point(373, 616);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(75, 23);
            this.cancel.TabIndex = 2;
            this.cancel.Text = "Cancel";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Add);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(460, 81);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.informationDataGrid);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 81);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(460, 435);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            // 
            // informationDataGrid
            // 
            this.informationDataGrid.AccessibleName = "Table";
            this.informationDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.informationDataGrid.Location = new System.Drawing.Point(3, 16);
            this.informationDataGrid.Name = "informationDataGrid";
            this.informationDataGrid.Size = new System.Drawing.Size(454, 416);
            this.informationDataGrid.TabIndex = 1;
            this.informationDataGrid.Text = "sfDataGrid1";
            // 
            // Add
            // 
            this.Add.Location = new System.Drawing.Point(13, 29);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(75, 23);
            this.Add.TabIndex = 0;
            this.Add.Text = "Add";
            this.Add.UseVisualStyleBackColor = true;
            this.Add.Click += new System.EventHandler(this.Add_Click);
            // 
            // ChangeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 682);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.Save);
            this.Name = "ChangeForm";
            this.Text = "ChangeForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.informationDataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button Add;
        private System.Windows.Forms.GroupBox groupBox2;
        private Syncfusion.WinForms.DataGrid.SfDataGrid informationDataGrid;
    }
}