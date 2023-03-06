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
    public partial class Calculation_Earth_Model : Form
    {
        GeoZone geo;
        GeoZone_BL geoBL;
        public Calculation_Earth_Model(GeoZone geoZone)
        {
            InitializeComponent();
            geo = geoZone;
            //LoadData();
            
       
        }
        public void LoadData()
        {
            Geozone_Start_Numbox.DoubleValue = geo.Geozone_Start_Num;
            Geozone_End_Num.DoubleValue = geo.Geozone_End_Num;
            Geozone_point.DefaultValue = geo.Geozone_point;
            Function_OrderBox.DefaultValue = geo.Function_Order_number;

        }
        private void saveBTN_Click(object sender, EventArgs e)
        {

            geo.Geozone_Start_Num = double.Parse( Geozone_Start_Numbox.Text);
            geo.Geozone_End_Num = double.Parse(Geozone_End_Num.Text);
            geo.Geozone_point = long.Parse(Geozone_point.Text);
            geo.Function_Order_number = int.Parse(Function_OrderBox.Text);
            Close();

        }

        
    }
}
