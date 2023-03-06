
namespace GUI.Line
{
    partial class LineModelTypeSelection
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
            this.ModelTypeTree = new System.Windows.Forms.TreeView();
            this.SelectionModelTypeOK = new System.Windows.Forms.Button();
            this.SelectionModelTypeCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ModelTypeTree
            // 
            this.ModelTypeTree.Location = new System.Drawing.Point(12, 12);
            this.ModelTypeTree.Name = "ModelTypeTree";
            this.ModelTypeTree.Size = new System.Drawing.Size(240, 389);
            this.ModelTypeTree.TabIndex = 0;
            // 
            // SelectionModelTypeOK
            // 
            this.SelectionModelTypeOK.Location = new System.Drawing.Point(13, 408);
            this.SelectionModelTypeOK.Name = "SelectionModelTypeOK";
            this.SelectionModelTypeOK.Size = new System.Drawing.Size(75, 23);
            this.SelectionModelTypeOK.TabIndex = 1;
            this.SelectionModelTypeOK.Text = "OK";
            this.SelectionModelTypeOK.UseVisualStyleBackColor = true;
            // 
            // SelectionModelTypeCancel
            // 
            this.SelectionModelTypeCancel.Location = new System.Drawing.Point(177, 408);
            this.SelectionModelTypeCancel.Name = "SelectionModelTypeCancel";
            this.SelectionModelTypeCancel.Size = new System.Drawing.Size(75, 23);
            this.SelectionModelTypeCancel.TabIndex = 3;
            this.SelectionModelTypeCancel.Text = "Cancel";
            this.SelectionModelTypeCancel.UseVisualStyleBackColor = true;
            // 
            // LineModelTypeSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(265, 489);
            this.Controls.Add(this.SelectionModelTypeCancel);
            this.Controls.Add(this.SelectionModelTypeOK);
            this.Controls.Add(this.ModelTypeTree);
            this.Name = "LineModelTypeSelection";
            this.Text = "LineModelTypeSelection";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView ModelTypeTree;
        private System.Windows.Forms.Button SelectionModelTypeOK;
        private System.Windows.Forms.Button SelectionModelTypeCancel;
    }
}