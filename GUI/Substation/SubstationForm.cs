using BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using persistent.network;

namespace GUI.Substation
{
    public partial class SubstationForm : Form
    {
        SubstationBL substationBL = new SubstationBL();
        private Substations substation;
        public SubstationForm()
        {
            InitializeComponent();
            Substations sub =substationBL.findLastSubstation();
            substation = new Substations();
            substation.Substation_Number = sub.Substation_Number + 1;
            substation.Substation_Name = "Substation" + sub.Substation_Number;
            nametxt.Text= substation.Substation_Name;
            substationNumbox.Text = substation.Substation_Number.ToString();

        }
        
        private void saveBTN_Click(object sender, EventArgs e)
        {
            substation.Substation_Name = nametxt.Text;
            substation.Substation_Number =long.Parse( substationNumbox.Text);
            substation.Latitude =double.Parse( substationLatitudebox.Text);
            substation.Longitude = double.Parse(substationLongitudebox.Text);
            substation.GroundGridResistance = double.Parse(substationGrwndGridbox.Text);
            substationBL.createSubstation(substation);
            Close();
        }


        /*  public SubstationForm(Substation substation)
 {
     InitializeComponent();
 }*/
    }
}
