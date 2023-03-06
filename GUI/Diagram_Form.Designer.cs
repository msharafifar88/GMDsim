namespace GUI
{
    partial class Diagram_Form
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
            this.BackDiagram = new Telerik.WinControls.UI.RadDiagram();
            ((System.ComponentModel.ISupportInitialize)(this.BackDiagram)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // BackDiagram
            // 
            this.BackDiagram.BackColor = System.Drawing.Color.White;
            this.BackDiagram.CausesValidation = false;
            this.BackDiagram.ForeColor = System.Drawing.Color.Black;
            this.BackDiagram.IsBackgroundSurfaceVisible = false;
            this.BackDiagram.Location = new System.Drawing.Point(0, 0);
            this.BackDiagram.Name = "BackDiagram";
            this.BackDiagram.Size = new System.Drawing.Size(1500, 1500);
            this.BackDiagram.TabIndex = 0;
            this.BackDiagram.Text = "radDiagram1";
            this.BackDiagram.Click += new System.EventHandler(this.BackDiagram_Click);
            this.BackDiagram.MouseClick += new System.Windows.Forms.MouseEventHandler(this.BackDiagram_MouseClick);
            ((Telerik.WinControls.UI.RadDiagramElement)(this.BackDiagram.GetChildAt(0))).IsBackgroundSurfaceVisible = false;
            // 
            // Diagram_Form
            // 
            this.AccessibleName = "";
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(795, 431);
            this.Controls.Add(this.BackDiagram);
            this.Cursor = System.Windows.Forms.Cursors.Cross;
            this.Name = "Diagram_Form";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "CaseWindow";
            ((System.ComponentModel.ISupportInitialize)(this.BackDiagram)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Telerik.WinControls.UI.RadDiagramContainerShape container;
        private Telerik.WinControls.UI.RadDiagram BackDiagram;
    }
}
