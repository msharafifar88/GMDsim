namespace GUI.Geo_Zone
{
    partial class Geo_Zone_Form_Create
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
            this.saveBTN = new System.Windows.Forms.Button();
            this.Add_geozone = new System.Windows.Forms.Button();
            this.LocationDataGrid = new Syncfusion.WinForms.DataGrid.SfDataGrid();
            this.Cancel = new System.Windows.Forms.Button();
            this.PropertyDataGrid = new Syncfusion.WinForms.DataGrid.SfDataGrid();
            this.OK = new System.Windows.Forms.Button();
            this.GeoZoneDataGrid = new Syncfusion.WinForms.DataGrid.SfDataGrid();
            this.Geo_Zone_panel = new System.Windows.Forms.Panel();
            this.GeozoneNumbox = new Syncfusion.Windows.Forms.Tools.DoubleTextBox();
            this.GeozoneName = new System.Windows.Forms.TextBox();
            this.NumberLablel = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.Calculation_Geo_zone = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.LocationDataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PropertyDataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GeoZoneDataGrid)).BeginInit();
            this.Geo_Zone_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GeozoneNumbox)).BeginInit();
            this.SuspendLayout();
            // 
            // saveBTN
            // 
            this.saveBTN.Location = new System.Drawing.Point(21, 430);
            this.saveBTN.Name = "saveBTN";
            this.saveBTN.Size = new System.Drawing.Size(75, 23);
            this.saveBTN.TabIndex = 6;
            this.saveBTN.Text = "Save";
            this.saveBTN.UseVisualStyleBackColor = true;
            this.saveBTN.Click += new System.EventHandler(this.saveBTN_Click);
            // 
            // Add_geozone
            // 
            this.Add_geozone.Location = new System.Drawing.Point(12, 7);
            this.Add_geozone.Name = "Add_geozone";
            this.Add_geozone.Size = new System.Drawing.Size(155, 23);
            this.Add_geozone.TabIndex = 9;
            this.Add_geozone.Text = "Add New Geological Zone";
            this.Add_geozone.UseVisualStyleBackColor = true;
            this.Add_geozone.Click += new System.EventHandler(this.Add_geozone_Click);
            // 
            // LocationDataGrid
            // 
            this.LocationDataGrid.AccessibleName = "Table";
            this.LocationDataGrid.AddNewRowPosition = Syncfusion.WinForms.DataGrid.Enums.RowPosition.Bottom;
            this.LocationDataGrid.AutoSizeColumnsMode = Syncfusion.WinForms.DataGrid.Enums.AutoSizeColumnsMode.Fill;
            this.LocationDataGrid.Enabled = false;
            this.LocationDataGrid.Location = new System.Drawing.Point(520, 36);
            this.LocationDataGrid.Name = "LocationDataGrid";
            this.LocationDataGrid.Size = new System.Drawing.Size(227, 382);
            this.LocationDataGrid.Style.HeaderStyle.FilterIconColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.LocationDataGrid.TabIndex = 16;
            this.LocationDataGrid.Text = "Geo Zone LIst";
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(672, 430);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(75, 23);
            this.Cancel.TabIndex = 15;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // PropertyDataGrid
            // 
            this.PropertyDataGrid.AccessibleName = "Table";
            this.PropertyDataGrid.AddNewRowPosition = Syncfusion.WinForms.DataGrid.Enums.RowPosition.Bottom;
            this.PropertyDataGrid.AutoSizeColumnsMode = Syncfusion.WinForms.DataGrid.Enums.AutoSizeColumnsMode.Fill;
            this.PropertyDataGrid.Enabled = false;
            this.PropertyDataGrid.Location = new System.Drawing.Point(265, 36);
            this.PropertyDataGrid.Name = "PropertyDataGrid";
            this.PropertyDataGrid.Size = new System.Drawing.Size(236, 382);
            this.PropertyDataGrid.Style.HeaderStyle.FilterIconColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.PropertyDataGrid.TabIndex = 13;
            this.PropertyDataGrid.Text = "Geo Zone LIst";
            // 
            // OK
            // 
            this.OK.Location = new System.Drawing.Point(102, 430);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(75, 23);
            this.OK.TabIndex = 17;
            this.OK.Text = "OK";
            this.OK.UseVisualStyleBackColor = true;
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // GeoZoneDataGrid
            // 
            this.GeoZoneDataGrid.AccessibleName = "Table";
            this.GeoZoneDataGrid.AllowDeleting = true;
            this.GeoZoneDataGrid.AllowEditing = false;
            this.GeoZoneDataGrid.AutoGenerateColumns = false;
            this.GeoZoneDataGrid.AutoSizeColumnsMode = Syncfusion.WinForms.DataGrid.Enums.AutoSizeColumnsMode.Fill;
            this.GeoZoneDataGrid.ExpanderColumnWidth = 20D;
            this.GeoZoneDataGrid.Location = new System.Drawing.Point(12, 115);
            this.GeoZoneDataGrid.Name = "GeoZoneDataGrid";
            this.GeoZoneDataGrid.Size = new System.Drawing.Size(231, 303);
            this.GeoZoneDataGrid.Style.HeaderStyle.FilterIconColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.GeoZoneDataGrid.TabIndex = 18;
            this.GeoZoneDataGrid.Text = "Geo Zone LIst";
            this.GeoZoneDataGrid.CellClick += new Syncfusion.WinForms.DataGrid.Events.CellClickEventHandler(this.GeoZoneDataGrid_CellClick);
            // 
            // Geo_Zone_panel
            // 
            this.Geo_Zone_panel.Controls.Add(this.GeozoneNumbox);
            this.Geo_Zone_panel.Controls.Add(this.GeozoneName);
            this.Geo_Zone_panel.Controls.Add(this.NumberLablel);
            this.Geo_Zone_panel.Controls.Add(this.nameLabel);
            this.Geo_Zone_panel.Enabled = false;
            this.Geo_Zone_panel.Location = new System.Drawing.Point(12, 36);
            this.Geo_Zone_panel.Name = "Geo_Zone_panel";
            this.Geo_Zone_panel.Size = new System.Drawing.Size(231, 73);
            this.Geo_Zone_panel.TabIndex = 19;
            // 
            // GeozoneNumbox
            // 
            this.GeozoneNumbox.BeforeTouchSize = new System.Drawing.Size(104, 20);
            this.GeozoneNumbox.DoubleValue = 1D;
            this.GeozoneNumbox.Location = new System.Drawing.Point(107, 12);
            this.GeozoneNumbox.Name = "GeozoneNumbox";
            this.GeozoneNumbox.NumberDecimalDigits = 0;
            this.GeozoneNumbox.NumberGroupSeparator = "";
            this.GeozoneNumbox.Size = new System.Drawing.Size(104, 20);
            this.GeozoneNumbox.TabIndex = 6;
            this.GeozoneNumbox.Text = "1";
            // 
            // GeozoneName
            // 
            this.GeozoneName.Location = new System.Drawing.Point(107, 38);
            this.GeozoneName.Name = "GeozoneName";
            this.GeozoneName.Size = new System.Drawing.Size(104, 20);
            this.GeozoneName.TabIndex = 5;
            // 
            // NumberLablel
            // 
            this.NumberLablel.AutoSize = true;
            this.NumberLablel.Location = new System.Drawing.Point(6, 17);
            this.NumberLablel.Name = "NumberLablel";
            this.NumberLablel.Size = new System.Drawing.Size(72, 13);
            this.NumberLablel.TabIndex = 1;
            this.NumberLablel.Text = "Zone Number";
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(6, 41);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(72, 13);
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "Zone Name : ";
            // 
            // Calculation_Geo_zone
            // 
            this.Calculation_Geo_zone.Location = new System.Drawing.Point(314, 430);
            this.Calculation_Geo_zone.Name = "Calculation_Geo_zone";
            this.Calculation_Geo_zone.Size = new System.Drawing.Size(146, 23);
            this.Calculation_Geo_zone.TabIndex = 20;
            this.Calculation_Geo_zone.Text = "Calculation Earth Model";
            this.Calculation_Geo_zone.UseVisualStyleBackColor = true;
            this.Calculation_Geo_zone.Click += new System.EventHandler(this.Calculation_Geo_zone_Click);
            // 
            // Geo_Zone_Form_Create
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(763, 468);
            this.Controls.Add(this.Calculation_Geo_zone);
            this.Controls.Add(this.Geo_Zone_panel);
            this.Controls.Add(this.GeoZoneDataGrid);
            this.Controls.Add(this.OK);
            this.Controls.Add(this.LocationDataGrid);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.PropertyDataGrid);
            this.Controls.Add(this.Add_geozone);
            this.Controls.Add(this.saveBTN);
            this.Name = "Geo_Zone_Form_Create";
            this.Text = "Geological Zone";
            ((System.ComponentModel.ISupportInitialize)(this.LocationDataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PropertyDataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GeoZoneDataGrid)).EndInit();
            this.Geo_Zone_panel.ResumeLayout(false);
            this.Geo_Zone_panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GeozoneNumbox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button saveBTN;
        private System.Windows.Forms.Button Add_geozone;
        private Syncfusion.WinForms.DataGrid.SfDataGrid LocationDataGrid;
        private System.Windows.Forms.Button Cancel;
        private Syncfusion.WinForms.DataGrid.SfDataGrid PropertyDataGrid;
        private System.Windows.Forms.Button OK;
        private Syncfusion.WinForms.DataGrid.SfDataGrid GeoZoneDataGrid;
        private System.Windows.Forms.Panel Geo_Zone_panel;
        private Syncfusion.Windows.Forms.Tools.DoubleTextBox GeozoneNumbox;
        private System.Windows.Forms.TextBox GeozoneName;
        private System.Windows.Forms.Label NumberLablel;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Button Calculation_Geo_zone;
    }
}