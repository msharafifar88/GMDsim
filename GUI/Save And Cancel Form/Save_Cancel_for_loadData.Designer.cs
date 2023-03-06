
namespace GUI.Save_And_Cancel_Form
{
    partial class Save_Cancel_for_loadData
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
            this.Save = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(92, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "New data has been loaded";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label2.Location = new System.Drawing.Point(43, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(244, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Are you sure you want to delete old data?";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Image = global::GUI.Properties.Resources.hazard;
            this.label3.Location = new System.Drawing.Point(58, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 2;
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(46, 105);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(75, 23);
            this.Save.TabIndex = 3;
            this.Save.Text = "Save";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(211, 105);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(75, 23);
            this.Cancel.TabIndex = 4;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::GUI.Properties.Resources.hazard;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Location = new System.Drawing.Point(13, 47);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(25, 24);
            this.panel1.TabIndex = 5;
            // 
            // Save_Cancel_for_loadData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 143);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Save_Cancel_for_loadData";
            this.Text = "Save Change";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.Panel panel1;
    }
}