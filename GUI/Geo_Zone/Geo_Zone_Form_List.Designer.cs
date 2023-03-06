namespace GUI.Geo_Zone
{
    partial class Geo_Zone_Form_List
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
            this.geoZoneGrid_thik_ro = new Syncfusion.WinForms.DataGrid.SfDataGrid();
            this.button2 = new System.Windows.Forms.Button();
            this.saveBTN = new System.Windows.Forms.Button();
            this.ZoneDatagrid_Lat_kong = new Syncfusion.WinForms.DataGrid.SfDataGrid();
            this.label1 = new System.Windows.Forms.Label();
            this.GeoZoneDropDown = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.geoZoneGrid_thik_ro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ZoneDatagrid_Lat_kong)).BeginInit();
            this.SuspendLayout();
            // 
            // geoZoneGrid_thik_ro
            // 
            this.geoZoneGrid_thik_ro.AccessibleName = "Table";
            this.geoZoneGrid_thik_ro.Location = new System.Drawing.Point(12, 56);
            this.geoZoneGrid_thik_ro.Name = "geoZoneGrid_thik_ro";
            this.geoZoneGrid_thik_ro.Size = new System.Drawing.Size(238, 345);
            this.geoZoneGrid_thik_ro.Style.HeaderStyle.FilterIconColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.geoZoneGrid_thik_ro.TabIndex = 0;
            this.geoZoneGrid_thik_ro.Text = "Geo Zone LIst";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(440, 407);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // saveBTN
            // 
            this.saveBTN.Location = new System.Drawing.Point(12, 407);
            this.saveBTN.Name = "saveBTN";
            this.saveBTN.Size = new System.Drawing.Size(75, 23);
            this.saveBTN.TabIndex = 8;
            this.saveBTN.Text = "Save";
            this.saveBTN.UseVisualStyleBackColor = true;
            this.saveBTN.Click += new System.EventHandler(this.saveBTN_Click);
            // 
            // ZoneDatagrid_Lat_kong
            // 
            this.ZoneDatagrid_Lat_kong.AccessibleName = "Table";
            this.ZoneDatagrid_Lat_kong.Location = new System.Drawing.Point(276, 56);
            this.ZoneDatagrid_Lat_kong.Name = "ZoneDatagrid_Lat_kong";
            this.ZoneDatagrid_Lat_kong.Size = new System.Drawing.Size(239, 345);
            this.ZoneDatagrid_Lat_kong.Style.HeaderStyle.FilterIconColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.ZoneDatagrid_Lat_kong.TabIndex = 10;
            this.ZoneDatagrid_Lat_kong.Text = "Geo Zone LIst";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(150, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Selected Geo Zone";
            // 
            // GeoZoneDropDown
            // 
            this.GeoZoneDropDown.FormattingEnabled = true;
            this.GeoZoneDropDown.Location = new System.Drawing.Point(276, 17);
            this.GeoZoneDropDown.Name = "GeoZoneDropDown";
            this.GeoZoneDropDown.Size = new System.Drawing.Size(121, 21);
            this.GeoZoneDropDown.TabIndex = 12;
            // 
            // Geo_Zone_Form_List
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 450);
            this.Controls.Add(this.GeoZoneDropDown);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ZoneDatagrid_Lat_kong);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.saveBTN);
            this.Controls.Add(this.geoZoneGrid_thik_ro);
            this.Name = "Geo_Zone_Form_List";
            this.Text = "Zone_Form_List";
            ((System.ComponentModel.ISupportInitialize)(this.geoZoneGrid_thik_ro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ZoneDatagrid_Lat_kong)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Syncfusion.WinForms.DataGrid.SfDataGrid geoZoneGrid_thik_ro;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button saveBTN;
        private Syncfusion.WinForms.DataGrid.SfDataGrid ZoneDatagrid_Lat_kong;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox GeoZoneDropDown;
    }
}