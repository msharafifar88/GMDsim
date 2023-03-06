using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using network;
using BL;

namespace GUI.line
{
    public partial class Line_Main : Form
    {
        public Line_Main()
        {
            InitializeComponent();
        }

       

        public Boolean save()
        {
            try
            {
               /* Loads load = new Loads();
                Bus bus = new Bus();
                bus.BusName = busNametxt.Text;
                bus.BusNumber = (long) busNumbertxt.Value;
                load.Code = long.Parse(nominalVoltagetxt.Text);
                load.Bus = bus;
                LoadBL loadBL = new LoadBL();
                loadBL.create(load);*/
                return true;
            }
            catch
            {
                MessageBox.Show("Save Record Exception");
                return false;
            }

        }
       

        private void LoadDisplayWidth_ValueChanged(object sender, EventArgs e)
        {
            ResizeRedraw = true;
            
        }

        private void OK_load_Click(object sender, EventArgs e)
        {
            Close();

        }

        private void Save_load_Click(object sender, EventArgs e)
        {

            
            Close();
        }

        private void Cancel_Load_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Load_Main_Load(object sender, EventArgs e)
        {

        }

        private void LoadDisplayInfo_Enter(object sender, EventArgs e)
        {

        }
    }
}
