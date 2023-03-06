namespace GUI.contextMenu
{
    partial class ChangeName_Form
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
            this.radNameTextBox = new Telerik.WinControls.UI.RadTextBox();
            this.NameLabel = new System.Windows.Forms.Label();
            this.radCancelButton = new Telerik.WinControls.UI.RadButton();
            this.radSaveButton = new Telerik.WinControls.UI.RadButton();
            this.office2013LightTheme1 = new Telerik.WinControls.Themes.Office2013LightTheme();
            ((System.ComponentModel.ISupportInitialize)(this.radNameTextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radCancelButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radSaveButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radNameTextBox
            // 
            this.radNameTextBox.Location = new System.Drawing.Point(54, 11);
            this.radNameTextBox.Name = "radNameTextBox";
            this.radNameTextBox.Size = new System.Drawing.Size(154, 27);
            this.radNameTextBox.TabIndex = 0;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.radNameTextBox.GetChildAt(0).GetChildAt(2))).ForeColor = System.Drawing.Color.Black;
            // 
            // NameLabel
            // 
            this.NameLabel.AccessibleDescription = "NameLabel";
            this.NameLabel.AccessibleName = "NameLabel";
            this.NameLabel.AutoSize = true;
            this.NameLabel.Location = new System.Drawing.Point(14, 13);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(59, 25);
            this.NameLabel.TabIndex = 1;
            this.NameLabel.Text = "Name";
            this.NameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // radCancelButton
            // 
            this.radCancelButton.AccessibleDescription = "radCancelButton";
            this.radCancelButton.AccessibleName = "radCancelButton";
            this.radCancelButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.radCancelButton.DisplayStyle = Telerik.WinControls.DisplayStyle.Text;
            this.radCancelButton.ForeColor = System.Drawing.Color.Black;
            this.radCancelButton.Location = new System.Drawing.Point(76, 48);
            this.radCancelButton.Name = "radCancelButton";
            this.radCancelButton.Size = new System.Drawing.Size(132, 20);
            this.radCancelButton.TabIndex = 2;
            this.radCancelButton.Text = "Cancel";
            this.radCancelButton.ThemeName = "Office2013Light";
            this.radCancelButton.Click += new System.EventHandler(this.radCancelButton_Click);
            // 
            // radSaveButton
            // 
            this.radSaveButton.AccessibleDescription = "radSaveButton";
            this.radSaveButton.AccessibleName = "radSaveButton";
            this.radSaveButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.radSaveButton.DisplayStyle = Telerik.WinControls.DisplayStyle.Text;
            this.radSaveButton.ForeColor = System.Drawing.Color.Black;
            this.radSaveButton.Location = new System.Drawing.Point(76, 74);
            this.radSaveButton.Name = "radSaveButton";
            this.radSaveButton.Size = new System.Drawing.Size(132, 20);
            this.radSaveButton.TabIndex = 3;
            this.radSaveButton.Text = "Save";
            this.radSaveButton.ThemeName = "Office2013Light";
            this.radSaveButton.Click += new System.EventHandler(this.radSaveButton_Click);
            // 
            // ChangeName_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(282, 122);
            this.Controls.Add(this.radSaveButton);
            this.Controls.Add(this.radCancelButton);
            this.Controls.Add(this.radNameTextBox);
            this.Controls.Add(this.NameLabel);
            this.Name = "ChangeName_Form";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Name";
            this.ThemeName = "Office2013Light";
            ((System.ComponentModel.ISupportInitialize)(this.radNameTextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radCancelButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radSaveButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadTextBox radNameTextBox;
        private System.Windows.Forms.Label NameLabel;
        private Telerik.WinControls.UI.RadButton radCancelButton;
        private Telerik.WinControls.UI.RadButton radSaveButton;
        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme1;
    }
}
