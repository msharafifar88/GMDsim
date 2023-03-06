namespace GUI.Geo_Zone
{
    partial class Creat_select_GeoZone
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
            this.Geo_Zone_panel = new System.Windows.Forms.Panel();
            this.GeozoneNumbox = new Syncfusion.Windows.Forms.Tools.DoubleTextBox();
            this.NumberLablel = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.saveBTN = new System.Windows.Forms.Button();
            this.GeozoneName = new System.Windows.Forms.TextBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.Geo_Zone_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GeozoneNumbox)).BeginInit();
            this.SuspendLayout();
            // 
            // Geo_Zone_panel
            // 
            this.Geo_Zone_panel.Controls.Add(this.GeozoneName);
            this.Geo_Zone_panel.Controls.Add(this.nameLabel);
            this.Geo_Zone_panel.Controls.Add(this.GeozoneNumbox);
            this.Geo_Zone_panel.Controls.Add(this.NumberLablel);
            this.Geo_Zone_panel.Location = new System.Drawing.Point(12, 12);
            this.Geo_Zone_panel.Name = "Geo_Zone_panel";
            this.Geo_Zone_panel.Size = new System.Drawing.Size(281, 73);
            this.Geo_Zone_panel.TabIndex = 5;
            // 
            // GeozoneNumbox
            // 
            this.GeozoneNumbox.BeforeTouchSize = new System.Drawing.Size(157, 20);
            this.GeozoneNumbox.DoubleValue = 1D;
            this.GeozoneNumbox.Location = new System.Drawing.Point(107, 11);
            this.GeozoneNumbox.Name = "GeozoneNumbox";
            this.GeozoneNumbox.NumberDecimalDigits = 0;
            this.GeozoneNumbox.Size = new System.Drawing.Size(157, 20);
            this.GeozoneNumbox.TabIndex = 6;
            this.GeozoneNumbox.Text = "1";
            // 
            // NumberLablel
            // 
            this.NumberLablel.AutoSize = true;
            this.NumberLablel.Location = new System.Drawing.Point(6, 16);
            this.NumberLablel.Name = "NumberLablel";
            this.NumberLablel.Size = new System.Drawing.Size(72, 13);
            this.NumberLablel.TabIndex = 1;
            this.NumberLablel.Text = "Zone Number";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(213, 100);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(80, 23);
            this.button2.TabIndex = 11;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // saveBTN
            // 
            this.saveBTN.Location = new System.Drawing.Point(12, 100);
            this.saveBTN.Name = "saveBTN";
            this.saveBTN.Size = new System.Drawing.Size(78, 23);
            this.saveBTN.TabIndex = 10;
            this.saveBTN.Text = "Save";
            this.saveBTN.UseVisualStyleBackColor = true;
            this.saveBTN.Click += new System.EventHandler(this.saveBTN_Click);
            // 
            // GeozoneName
            // 
            this.GeozoneName.Location = new System.Drawing.Point(107, 37);
            this.GeozoneName.Name = "GeozoneName";
            this.GeozoneName.Size = new System.Drawing.Size(157, 20);
            this.GeozoneName.TabIndex = 8;
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(6, 42);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(72, 13);
            this.nameLabel.TabIndex = 7;
            this.nameLabel.Text = "Zone Name : ";
            // 
            // Creat_select_GeoZone
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(301, 135);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.saveBTN);
            this.Controls.Add(this.Geo_Zone_panel);
            this.Name = "Creat_select_GeoZone";
            this.Text = "Creat_select_GeoZone";
            this.Geo_Zone_panel.ResumeLayout(false);
            this.Geo_Zone_panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GeozoneNumbox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Geo_Zone_panel;
        private Syncfusion.Windows.Forms.Tools.DoubleTextBox GeozoneNumbox;
        private System.Windows.Forms.Label NumberLablel;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button saveBTN;
        private System.Windows.Forms.TextBox GeozoneName;
        private System.Windows.Forms.Label nameLabel;
    }
}