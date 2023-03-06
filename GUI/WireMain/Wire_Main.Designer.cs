namespace GUI.WireMain
{
    partial class Wire_Main
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
            this.towire = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.Fromwire = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.To = new System.Windows.Forms.Label();
            this.From = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.towire)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Fromwire)).BeginInit();
            this.SuspendLayout();
            // 
            // towire
            // 
            this.towire.BeforeTouchSize = new System.Drawing.Size(134, 20);
            this.towire.Location = new System.Drawing.Point(70, 87);
            this.towire.Name = "towire";
            this.towire.Size = new System.Drawing.Size(134, 20);
            this.towire.TabIndex = 7;
            this.towire.Text = "textBoxExt2";
            // 
            // Fromwire
            // 
            this.Fromwire.BeforeTouchSize = new System.Drawing.Size(134, 20);
            this.Fromwire.Location = new System.Drawing.Point(70, 48);
            this.Fromwire.Name = "Fromwire";
            this.Fromwire.Size = new System.Drawing.Size(134, 20);
            this.Fromwire.TabIndex = 6;
            this.Fromwire.Text = "textBoxExt1";
            // 
            // To
            // 
            this.To.AutoSize = true;
            this.To.Location = new System.Drawing.Point(25, 94);
            this.To.Name = "To";
            this.To.Size = new System.Drawing.Size(20, 13);
            this.To.TabIndex = 5;
            this.To.Text = "To";
            // 
            // From
            // 
            this.From.AutoSize = true;
            this.From.Location = new System.Drawing.Point(25, 48);
            this.From.Name = "From";
            this.From.Size = new System.Drawing.Size(30, 13);
            this.From.TabIndex = 4;
            this.From.Text = "From";
            // 
            // Wire_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(289, 169);
            this.Controls.Add(this.towire);
            this.Controls.Add(this.Fromwire);
            this.Controls.Add(this.To);
            this.Controls.Add(this.From);
            this.Name = "Wire_Main";
            this.Text = "Wire_Main";
            ((System.ComponentModel.ISupportInitialize)(this.towire)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Fromwire)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Syncfusion.Windows.Forms.Tools.TextBoxExt towire;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt Fromwire;
        private System.Windows.Forms.Label To;
        private System.Windows.Forms.Label From;
    }
}