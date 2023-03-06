using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BL;
using GUI.Substation;
using Syncfusion.WinForms.DataGrid;
namespace GUI.search
{
    public partial class ChangeForm : Form
    {

        bool substation = false;
        bool area = false;
        bool zone = false;
        public ChangeForm()
        {
            InitializeComponent();
            this.informationDataGrid.Columns.Add(new GridTextColumn() { MappingName = "ID", HeaderText = "ID" });
            this.informationDataGrid.Columns.Add(new GridTextColumn() { MappingName = "Number", HeaderText = "Number" });
            this.informationDataGrid.Columns.Add(new GridTextColumn() { MappingName = "Name", HeaderText = "Name" });

        }

        public void LoadSubstationData()
        {
            substation = true;
            SubstationBL substationBL = new SubstationBL();
            informationDataGrid.DataSource = substationBL.loadAll();
            


        }
        public void LoadAreaData()
        {
            area = true;
            AreaBL areaBL = new AreaBL();
            informationDataGrid.DataSource = areaBL.loadAll();
        }
        public void LoadZoneData()
        {
            zone = true;
            ZoneBL zoneBl = new ZoneBL();
            informationDataGrid.DataSource = zoneBl.loadAll();
        }

        private void Add_Click(object sender, EventArgs e)
        {
            if (substation== true)
            {
                SubstationForm substationForm = new SubstationForm();
                substationForm.ShowDialog();
            }
            LoadSubstationData();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            resetData();
            Close();
        }

        public void resetData()
        {

            substation = false;
            area = false;
            zone = false;
        }

        private void Save_Click(object sender, EventArgs e)
        {
            resetData();
            Close();
        }
    }
}
