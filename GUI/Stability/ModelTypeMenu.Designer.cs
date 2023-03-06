namespace GUI.Stability
{
    partial class ModelTypeMenu
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
            this.Select = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.PWOnly = new System.Windows.Forms.CheckBox();
            this.GE = new System.Windows.Forms.CheckBox();
            this.BPA = new System.Windows.Forms.CheckBox();
            this.PTI = new System.Windows.Forms.CheckBox();
            this.LimitModels = new System.Windows.Forms.CheckBox();
            this.ShowUsedModel = new System.Windows.Forms.CheckBox();
            this.GEandPTI = new System.Windows.Forms.CheckBox();
            this.ModelTypeTree = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // Select
            // 
            this.Select.Location = new System.Drawing.Point(10, 380);
            this.Select.Name = "Select";
            this.Select.Size = new System.Drawing.Size(75, 23);
            this.Select.TabIndex = 0;
            this.Select.Text = "Select";
            this.Select.UseVisualStyleBackColor = true;
            this.Select.Click += new System.EventHandler(this.Select_Click);
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(153, 380);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(75, 23);
            this.Cancel.TabIndex = 1;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // PWOnly
            // 
            this.PWOnly.AutoSize = true;
            this.PWOnly.Location = new System.Drawing.Point(17, 262);
            this.PWOnly.Name = "PWOnly";
            this.PWOnly.Size = new System.Drawing.Size(68, 17);
            this.PWOnly.TabIndex = 3;
            this.PWOnly.Text = "PW Only";
            this.PWOnly.UseVisualStyleBackColor = true;
            this.PWOnly.CheckedChanged += new System.EventHandler(this.PWOnly_CheckedChanged);
            // 
            // GE
            // 
            this.GE.AutoSize = true;
            this.GE.Location = new System.Drawing.Point(148, 288);
            this.GE.Name = "GE";
            this.GE.Size = new System.Drawing.Size(41, 17);
            this.GE.TabIndex = 4;
            this.GE.Text = "GE";
            this.GE.UseVisualStyleBackColor = true;
            // 
            // BPA
            // 
            this.BPA.AutoSize = true;
            this.BPA.Location = new System.Drawing.Point(17, 288);
            this.BPA.Name = "BPA";
            this.BPA.Size = new System.Drawing.Size(47, 17);
            this.BPA.TabIndex = 5;
            this.BPA.Text = "BPA";
            this.BPA.UseVisualStyleBackColor = true;
            // 
            // PTI
            // 
            this.PTI.AutoSize = true;
            this.PTI.Location = new System.Drawing.Point(148, 262);
            this.PTI.Name = "PTI";
            this.PTI.Size = new System.Drawing.Size(43, 17);
            this.PTI.TabIndex = 6;
            this.PTI.Text = "PTI";
            this.PTI.UseVisualStyleBackColor = true;
            // 
            // LimitModels
            // 
            this.LimitModels.AutoSize = true;
            this.LimitModels.Location = new System.Drawing.Point(17, 357);
            this.LimitModels.Name = "LimitModels";
            this.LimitModels.Size = new System.Drawing.Size(174, 17);
            this.LimitModels.TabIndex = 7;
            this.LimitModels.Text = "Limit Models by Machine Modle";
            this.LimitModels.UseVisualStyleBackColor = true;
            // 
            // ShowUsedModel
            // 
            this.ShowUsedModel.AutoSize = true;
            this.ShowUsedModel.Location = new System.Drawing.Point(17, 334);
            this.ShowUsedModel.Name = "ShowUsedModel";
            this.ShowUsedModel.Size = new System.Drawing.Size(142, 17);
            this.ShowUsedModel.TabIndex = 8;
            this.ShowUsedModel.Text = "Only Show Used Models";
            this.ShowUsedModel.UseVisualStyleBackColor = true;
            // 
            // GEandPTI
            // 
            this.GEandPTI.AutoSize = true;
            this.GEandPTI.Location = new System.Drawing.Point(17, 311);
            this.GEandPTI.Name = "GEandPTI";
            this.GEandPTI.Size = new System.Drawing.Size(107, 17);
            this.GEandPTI.TabIndex = 9;
            this.GEandPTI.Text = "Both GE and PTI";
            this.GEandPTI.UseVisualStyleBackColor = true;
            // 
            // ModelTypeTree
            // 
            this.ModelTypeTree.Location = new System.Drawing.Point(17, 13);
            this.ModelTypeTree.Name = "ModelTypeTree";
            this.ModelTypeTree.Size = new System.Drawing.Size(211, 234);
            this.ModelTypeTree.TabIndex = 10;
            // 
            // ModelTypeMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(240, 415);
            this.Controls.Add(this.ModelTypeTree);
            this.Controls.Add(this.GEandPTI);
            this.Controls.Add(this.ShowUsedModel);
            this.Controls.Add(this.LimitModels);
            this.Controls.Add(this.PTI);
            this.Controls.Add(this.BPA);
            this.Controls.Add(this.GE);
            this.Controls.Add(this.PWOnly);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.Select);
            this.Name = "ModelTypeMenu";
            this.Text = "ModelTypeMenu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Select;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.CheckBox PWOnly;
        private System.Windows.Forms.CheckBox GE;
        private System.Windows.Forms.CheckBox BPA;
        private System.Windows.Forms.CheckBox PTI;
        private System.Windows.Forms.CheckBox LimitModels;
        private System.Windows.Forms.CheckBox ShowUsedModel;
        private System.Windows.Forms.CheckBox GEandPTI;
        private System.Windows.Forms.TreeView ModelTypeTree;
    }
}