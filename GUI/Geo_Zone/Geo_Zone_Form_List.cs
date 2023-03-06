using BL.Geo_Zone_BL;
using GUI.New_concept_WPF;
using persistent.network.Geo_Zone;
using Syncfusion.WinForms.DataGrid;
using Syncfusion.WinForms.DataGrid.Enums;
using System;
using System.Windows.Forms;

namespace GUI.Geo_Zone
{
    public partial class Geo_Zone_Form_List : Form
    {
        GeoZone geozone;
        GeoZone_BL GeoZoneBL;
        public Geo_Zone_Form_List(GeoZone geozone_, bool b)
        {
            InitializeComponent();
            this.geozone = geozone_;
            //   this.GeoZoneDropDown.Enabled = b;
            GeoZoneBL = new GeoZone_BL();
            this.GeoZoneDropDown.DataSource = GeoZoneBL.loadAll(CustomContentControl.getCurrentCase());
            this.GeoZoneDropDown.SelectedItem = geozone_;
            creat_Geozone();

        }
        public Geo_Zone_Form_List(bool b)
        {
            InitializeComponent();

            GeoZoneBL = new GeoZone_BL();
            this.GeoZoneDropDown.Enabled = b;
            this.GeoZoneDropDown.DataSource = GeoZoneBL.loadAll(CustomContentControl.getCurrentCase());
            creat_Geozone();

        }

        public void creat_Geozone()
        {

            geoZoneGrid_thik_ro.AutoGenerateColumns = false;
            this.geoZoneGrid_thik_ro.AutoSizeColumnsMode = Syncfusion.WinForms.DataGrid.Enums.AutoSizeColumnsMode.Fill;
            geoZoneGrid_thik_ro.AddNewRowPosition = RowPosition.Top;

            geoZoneGrid_thik_ro.Columns.Add(new GridTextColumn() { MappingName = "Thikness", HeaderText = "Layer Thickness" });
            geoZoneGrid_thik_ro.Columns.Add(new GridTextColumn() { MappingName = "Ro", HeaderText = "ρ(Ω -m)" });

            geoZoneGrid_thik_ro.DataSource = geozone.geoZone_Properties;


            // this.ZoneDatagrid_Lat_kong.AutoSizeColumnsMode = AutoSizeColumnsMode.AllCellsWithLastColumnFill;
            // ZoneDatagrid_Lat_kong.QueryRowStyle += SfDataGrid_QueryRowStyle;
            ZoneDatagrid_Lat_kong.AutoGenerateColumns = false;
            this.ZoneDatagrid_Lat_kong.AutoSizeColumnsMode = Syncfusion.WinForms.DataGrid.Enums.AutoSizeColumnsMode.Fill;
            ZoneDatagrid_Lat_kong.AddNewRowPosition = RowPosition.Top;
            ZoneDatagrid_Lat_kong.Columns.Add(new GridTextColumn() { MappingName = "Latitude", HeaderText = "Latitude" });
            ZoneDatagrid_Lat_kong.Columns.Add(new GridTextColumn() { MappingName = "Longitude", HeaderText = "Latitude" });

            ZoneDatagrid_Lat_kong.DataSource = geozone.geoZone_Locations;

        }

        private void saveBTN_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
