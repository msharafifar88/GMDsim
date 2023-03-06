using BL.Geo_Zone_BL;
using GUI.New_concept_WPF;
using persistent.network.Geo_Zone;
using Syncfusion.WinForms.DataGrid;
using Syncfusion.WinForms.DataGrid.Enums;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace GUI.Geo_Zone
{
    public partial class Geo_Zone_Form_Create : Form
    {
        GeoZone_BL GeoZonebl;
        GeoZone selectedGeoZone;

        public Geo_Zone_Form_Create()
        {


            InitializeComponent();
            //


            GridData();
            GeoZonebl = new GeoZone_BL();
            LoadGeoZone();



        }
        public void GridData()
        {
            //
            //   this.GeoZoneDataGrid.Columns.Add(new GridCheckBoxSelectorColumn() { MappingName = "SelectorColumn", HeaderText = string.Empty, AllowCheckBoxOnHeader = true, Width = 34, CheckBoxSize = new Size(14, 14) });


            GeoZoneDataGrid.Columns.Add(new GridTextColumn() { MappingName = "Number", HeaderText = "GeoZone Number", AutoSizeColumnsMode = AutoSizeColumnsMode.Fill }); ;
            GeoZoneDataGrid.Columns.Add(new GridTextColumn() { MappingName = "Name", HeaderText = "GeoZone Name", AutoSizeColumnsMode = AutoSizeColumnsMode.Fill });
            GeoZoneDataGrid.Columns["Number"].AllowHeaderTextWrapping = true;
            GeoZoneDataGrid.Columns["Name"].AllowHeaderTextWrapping = true;
            //GeoZoneDataGrid.AutoSizeController.AutoSizeCalculationMode = AutoSizeCalculationMode.SmartFit;
            ///
            StackedHeaderRow stackedHeaderRow1 = new StackedHeaderRow();
            stackedHeaderRow1.StackedColumns.Add(new StackedColumn() { ChildColumns = "Thikness,Ro,", HeaderText = "Earth Layers" });

            PropertyDataGrid.Columns.Add(new GridTextColumn() { MappingName = "Thikness", HeaderText = "Layer Thickness (Km)" });
            PropertyDataGrid.Columns.Add(new GridTextColumn() { MappingName = "Ro", HeaderText = "ρ(Ω -m)" });
            PropertyDataGrid.Enabled = false;
            this.PropertyDataGrid.StackedHeaderRows.Add(stackedHeaderRow1);
            ///
            StackedHeaderRow stackedHeaderRow2 = new StackedHeaderRow();
            stackedHeaderRow2.StackedColumns.Add(new StackedColumn() { ChildColumns = "Latitude,Longitude,", HeaderText = "Location of earth resistivity zones" });

            LocationDataGrid.Columns.Add(new GridTextColumn() { MappingName = "Latitude", HeaderText = "Latitude" });
            LocationDataGrid.Columns.Add(new GridTextColumn() { MappingName = "Longitude", HeaderText = "Longitude" });

            LocationDataGrid.Enabled = false;
            this.LocationDataGrid.StackedHeaderRows.Add(stackedHeaderRow2);
            //

        }
        public void LoadGeoZone()
        {


            GeoZoneDataGrid.AutoGenerateColumns = false;
            PropertyDataGrid.AutoGenerateColumns = false;
            LocationDataGrid.AutoGenerateColumns = false;
            GeoZoneDataGrid.DataSource = GeoZonebl.loadAll(CustomContentControl.getCurrentCase());
            LocationDataGrid.DataSource = GeoZonebl.loadAll(CustomContentControl.getCurrentCase());
            GeoZoneDataGrid.DataSource = GeoZonebl.loadAll(CustomContentControl.getCurrentCase());
            this.GeoZoneDataGrid.Style.CheckBoxStyle.CheckedBorderColor = Color.DarkViolet;
            GeoZoneDataGrid.EditMode = EditMode.DoubleClick;
            GeoZoneDataGrid.SelectionMode = GridSelectionMode.Single;

        }

        private void Add_geozone_Click(object sender, EventArgs e)
        {
            GeoZone geoZone = new GeoZone();
            Creat_select_GeoZone creat_Select_GeoZone = new Creat_select_GeoZone(geoZone);
            this.PropertyDataGrid.AutoSizeColumnsMode = Syncfusion.WinForms.DataGrid.Enums.AutoSizeColumnsMode.Fill;
            creat_Select_GeoZone.StartPosition = FormStartPosition.CenterParent;
            creat_Select_GeoZone.ShowDialog();
            if (geoZone.Name != null && geoZone.Name.Length != 0 && geoZone.Number != null)
            {
                GeoZonebl.createGeozone(geoZone, CustomContentControl.getCurrentCase());
            }
            LoadGeoZone();

        }



        private void GeoZoneDataGrid_CellClick(object sender, Syncfusion.WinForms.DataGrid.Events.CellClickEventArgs e)
        {

            selectedGeoZone = (GeoZone)e.DataRow.RowData;
            Geo_Zone_panel.Enabled = true;
            //    try
            {
                selectedGeoZone = (GeoZone)e.DataRow.RowData;
                Geo_Zone_panel.Enabled = true;
                GeozoneName.Text = selectedGeoZone.Name;
                GeozoneNumbox.Text = selectedGeoZone.Number.ToString();
                PropertyDataGrid.Enabled = true;
                this.PropertyDataGrid.AllowDeleting = true;
                PropertyDataGrid.DeleteSelectedRecords();
                PropertyDataGrid.DataSource = selectedGeoZone.geoZone_Properties;
                PropertyDataGrid.AddNewRowPosition = RowPosition.Bottom;

                LocationDataGrid.Enabled = true;
                this.LocationDataGrid.AllowDeleting = true;
                LocationDataGrid.DeleteSelectedRecords();
                LocationDataGrid.DataSource = selectedGeoZone.geoZone_Locations;
                LocationDataGrid.AddNewRowPosition = RowPosition.Bottom;

            }

            // catch (Exception e)


            GeozoneName.Text = selectedGeoZone.Name;
            GeozoneNumbox.Text = selectedGeoZone.Number.ToString();
            PropertyDataGrid.Enabled = true;
            this.PropertyDataGrid.AllowDeleting = true;
            PropertyDataGrid.DeleteSelectedRecords();
            PropertyDataGrid.DataSource = selectedGeoZone.geoZone_Properties;
            PropertyDataGrid.AddNewRowPosition = RowPosition.Bottom;

            LocationDataGrid.Enabled = true;
            this.LocationDataGrid.AllowDeleting = true;
            LocationDataGrid.DeleteSelectedRecords();
            LocationDataGrid.DataSource = selectedGeoZone.geoZone_Locations;
            LocationDataGrid.AddNewRowPosition = RowPosition.Bottom;



        }

        private void OK_Click(object sender, EventArgs e)
        {
            selectedGeoZone.Name = GeozoneName.Text;
            selectedGeoZone.Number = long.Parse(GeozoneNumbox.Text);
            //selectedGeoZone.geoZone_Properties = 
            GeozoneNumbox.Text = selectedGeoZone.Number.ToString();
            Close();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void saveBTN_Click(object sender, EventArgs e)
        {
            selectedGeoZone.Name = GeozoneName.Text;
            selectedGeoZone.Number = long.Parse(GeozoneNumbox.Text);
            //selectedGeoZone.geoZone_Properties = 
            GeozoneNumbox.Text = selectedGeoZone.Number.ToString();

        }

        private void Calculation_Geo_zone_Click(object sender, EventArgs e)
        {
            GeoZone geoZone = new GeoZone();
            Calculation_Earth_Model CEM = new Calculation_Earth_Model(geoZone);
            CEM.StartPosition = FormStartPosition.CenterParent;
            CEM.ShowDialog();


        }
    }
}
