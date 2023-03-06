using BL.Geo_Zone_BL;
using persistent.network.Geo_Zone;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.Geo_Zone
{
    public partial class Creat_select_GeoZone : Form
    {
        GeoZone geo;
        GeoZone_BL geoBL;
        public Creat_select_GeoZone(GeoZone geoZone)
        {
            InitializeComponent();
            geo = geoZone;
     
        }

       

        private void saveBTN_Click(object sender, EventArgs e)
        {

            geo.Name = GeozoneName.Text;
            geo.Number = long.Parse(GeozoneNumbox.Text);
            
            Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            Close();
        }
    }
}
