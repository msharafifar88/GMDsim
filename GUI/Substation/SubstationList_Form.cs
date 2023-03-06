using BL;
using GUI.bus;
using network;
using persistent.network;
using Syncfusion.WinForms.DataGrid;
using Syncfusion.WinForms.DataGrid.Enums;
using Syncfusion.WinForms.DataGrid.Events;
using Syncfusion.WinForms.DataGrid.Styles;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace GUI.Substation
{
    public partial class SubstationList_Form : Form
    {
        private SubstationBL substationBL;
        private List<Substations> substationsList;
        private Substations selectedSubstation;
        private Bus bus;
        private Bus_Main bus_Main;
        public SubstationList_Form(Bus bus, Bus_Main form)
        {
            InitializeComponent();
            DataGridSetup();


            this.bus = bus;
            this.bus_Main = form;
        }

        /*SFDataGrid setup*/
        public void DataGridSetup()
        {
            //sfDataGrid1.AllowEditing = false;
            sfDataGrid1.SelectionMode = GridSelectionMode.Single;
            this.sfDataGrid1.Style.HeaderStyle.BackColor = Color.LightGray;
            this.sfDataGrid1.Style.HeaderStyle.Borders.All = new GridBorder(Syncfusion.WinForms.DataGrid.Styles.GridBorderStyle.Solid, Color.Black);
            sfDataGrid1.Style.BorderColor = Color.Black;

            sfDataGrid1.Style.CellStyle.Borders.All = new GridBorder(Syncfusion.WinForms.DataGrid.Styles.GridBorderStyle.Solid, Color.Black);
            this.sfDataGrid1.Style.HeaderStyle.Font.Bold = true;
            this.sfDataGrid1.SelectionMode = GridSelectionMode.Extended;
            this.sfDataGrid1.AllowResizingColumns = true;
            this.sfDataGrid1.AutoSizeColumnsMode = AutoSizeColumnsMode.AllCellsWithLastColumnFill;
            sfDataGrid1.QueryRowStyle += SfDataGrid_QueryRowStyle;
            sfDataGrid1.AutoGenerateColumns = false;
            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "Substation_Number", HeaderText = "Number" });
            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "Substation_Name", HeaderText = "Name" });
            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "Latitude", HeaderText = "Latitude" });
            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "Longitude", HeaderText = "Longitude" });
            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "GroundGridResistance", HeaderText = "Ground Grid Resistance (Ω)" });

            substationBL = new SubstationBL();
            substationsList = substationBL.loadAll();
            sfDataGrid1.DataSource = substationsList;
        }
        private void SfDataGrid_QueryRowStyle(object sender, QueryRowStyleEventArgs e)
        {
            if (e.RowType == RowType.DefaultRow)
            {
                if (e.RowIndex % 2 == 0)
                    e.Style.BackColor = Color.LightGray;
                else
                    e.Style.BackColor = Color.White;
            }
        }
        private void sfDataGrid1_SelectionChanged(object sender, Syncfusion.WinForms.DataGrid.Events.SelectionChangedEventArgs e)
        {
            selectedSubstation = (Substations)sfDataGrid1.SelectedItem;
        }

        /*private void SubstationList_Form_FormClosed(object sender, FormClosedEventArgs e)
        {
           //Print
           Console.Out.WriteLine("Selected substation: " + selectedSubstation.Substation_Number);
           
        }*/

        private void Save_Click(object sender, EventArgs e)
        {
            selectedSubstation = (Substations)sfDataGrid1.SelectedItem;
            bus.substation = selectedSubstation;
            ;
            this.Close();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            cancel();
        }

        public void cancel()
        {
            this.Close();

        }
    }
}
