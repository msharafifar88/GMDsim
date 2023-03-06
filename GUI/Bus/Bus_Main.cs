using BL;
using network;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using areaandzone;
using GUI.search;
using GUI.New_concept_WPF;
using GUI.Substation;
using persistent.network;

namespace GUI.bus
{
    public partial class Bus_Main : Form                                                                                                    
    {
        BusBL busBL;
        Bus bus; 

       
      
        public Bus_Main()
        {
            InitializeComponent();
            busBL = new BusBL();

        }
        public Bus_Main(Bus bus )
        {
            InitializeComponent();
            busBL = new BusBL();
            
            loadData(bus);
            this.bus = bus;
        }

        
        public void loadData(Bus bus )
        {
            if (bus != null)
            {
                busInformationVoltageTXT.Text = bus.Voltagemagnitude.ToString();
                BusInService.Checked = bus.Status;
                Slackbus.Checked = bus.slack;
                busNumbertxt.Value = bus.BusNumber;
                busNametxt.Text = bus.BusName;
                nominalVoltagetxt.Text = Convert.ToString(bus.nominalVoltage);
                areaNumberTXT.Text = Convert.ToString(bus.area.Number);
                areaNameTXT.Text = bus.area.Name;
                zoneNumberTXT.Text = Convert.ToString(bus.zone.Number);
                zoneNameTXT.Text = Convert.ToString(bus.zone.Name);
                ownerNumberTXT.Text = Convert.ToString(bus.owners[0].Number);
                ownerNameTXT.Text = Convert.ToString(bus.owners[0].Name);
                busInformationAngelTXT.Text = Convert.ToString(bus.voltage);
                busInformationAngelTXT.Text = Convert.ToString(bus.angle);
                busLatitude.Text = bus.substation.Latitude.ToString();
                busLongitude.Text = bus.substation.Longitude.ToString();
                Sub_name.Text = bus.substation.Substation_Name.ToString();
                sub_num.Text = bus.substation.Substation_Number.ToString();
                NominalVmax.Text = bus.NominalVmax.ToString();
                NominalVmin.Text = bus.NominalVmin.ToString();
                EmerVmin.Text = bus.EmerVmin.ToString();
                EmerVmax.Text = bus.EmerVmax.ToString();
                ShuntB.Text = bus.ShuntB.ToString();
                ShuntG.Text = bus.ShuntG.ToString();
                QD.Text = bus.QD.ToString();
                PD.Text = bus.PD.ToString();
                // 3phase enable  
                BusA_V.Text = bus.Va_mag.ToString();
                BusB_V.Text = bus.Vb_mag.ToString();
                BusC_V.Text = bus.Vc_mag.ToString();
                BusA_ang.Text = bus.Va_angle.ToString();
                BusB_ang.Text = bus.Vb_angle.ToString();
                BusC_ang.Text = bus.Vc_angle.ToString();

                Bus3phase.Checked = bus.enable3phase;
            }
        }
        public Boolean save()
        {
            try
            {
                bus.Voltagemagnitude = float.Parse(busInformationVoltageTXT.Text);
                bus.BusNumber = (long)busNumbertxt.Value;
                bus.BusName = busNametxt.Text;
                bus.nominalVoltage = float.Parse(nominalVoltagetxt.Text);
                bus.Status = BusInService.Checked;
                bus.slack=Slackbus.Checked ;
                bus.nominalVoltage = float.Parse( nominalVoltagetxt.Text);
                bus.area.Number = long.Parse(areaNumberTXT.Text);
                bus.area.Name = areaNameTXT.Text;
                bus.zone.Number = long.Parse(zoneNumberTXT.Text);
                bus.zone.Name = zoneNameTXT.Text;
                bus.owners[0].Number = long.Parse(ownerNumberTXT.Text);
                bus.owners[0].Name = ownerNameTXT.Text;

                bus.voltage = float.Parse(busInformationAngelTXT.Text);
                bus.angle = float.Parse(busInformationAngelTXT.Text);
                //bus.substation.Latitude = float.Parse(busLatitude.Text);
                //bus.substation.Longitude = float.Parse(busLongitude.Text);
                //bus.substation.Substation_Name = Sub_name.Text;
                //bus.substation.Substation_Number = long.Parse(sub_num.Text);
                bus.NominalVmax = float.Parse(NominalVmax.Text);
                bus.NominalVmin = float.Parse(NominalVmin.Text);
                bus.EmerVmin = float.Parse(EmerVmin.Text);
                bus.EmerVmax =float.Parse(EmerVmax.Text);
                bus.ShuntB = float.Parse(ShuntB.Text);
                bus.ShuntG = float.Parse(ShuntG.Text );
                bus.QD = float.Parse(QD.Text) ;
                bus.PD = float.Parse(PD.Text) ;
                bus.Va_mag = float.Parse(BusA_V.Text);
                bus.Vb_mag = float.Parse(BusB_V.Text);
                bus.Vc_mag = float.Parse(BusC_V.Text);
            
                bus.Va_angle = float.Parse(BusA_ang.Text);
                bus.Vb_angle = float.Parse(BusB_ang.Text);
                bus.Vc_angle = float.Parse(BusC_ang.Text);

                bus.enable3phase = Bus3phase.Checked;

                // bus.voltage = float.Parse(aaaaa.Text);
                //bus.angle = float.Parse(aaaa.Text);
                busBL.editBus(bus, CustomContentControl.getCurrentCase());


                bus.ShuntG_pu = (bus.ShuntG / 100); // bus.baseloadMW;
                bus.ShuntB_pu = (bus.ShuntB / 100); // (bus.baseloadMvar/100);
                bus.QD_pu = (bus.QD/100);                      
                bus.PD_pu = bus.PD / 100 ;

               
               

                return true;

            }
            catch
            {
                MessageBox.Show("Save Record Exception");
            }
            return false;
        }

        public void cancel()
        {
            this.Close();

        }

        private void busSave_Click(object sender, EventArgs e)
        {


            save();
        
        }

        private void busCancel_Click(object sender, EventArgs e)
        {
            cancel();
          
        }

        private void busOk_Click(object sender, EventArgs e)
        {
            save();
            Close();
        }

        private void busInformation_Click(object sender, EventArgs e)
        {

        }

        private void Bus_Main_Load(object sender, EventArgs e)
        {

        }

        private Boolean validation(Bus bus)
        {
            return true;
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void changeArea_Click(object sender, EventArgs e)
        {
      /*      SearchForm searchForm = new SearchForm();
            searchForm.findAllArea();
            searchForm.ShowDialog();*/
      
      
      
      
        }

        private void BusInService_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (BusInService.Checked == true)
                {
                    BusInService.Checked = true;

                    (Main_Menu.GetClickedDiagramBus() as CoreConnector).setInserviceBus(false);
                }
                else if (BusInService.Checked == false)
                {

                    (Main_Menu.GetClickedDiagramBus() as CoreConnector).setInserviceBus(true);
                    BusInService.Checked = false;

                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        private void Slackbus_CheckedChanged(object sender, EventArgs e)
        {
            if (Slackbus.Checked == true)
            {
                Slackbus.Checked = true;
            }
            else
            {
                Slackbus.Checked = false;
            }

        }


        private void Bus3phase_CheckStateChanged(object sender, EventArgs e)
        {
            if (Bus3phase.Checked == true)
            {

                BusPhase.Enabled = true;
                busInformationVoltageTXT.Enabled = false;
                busInformationAngelTXT.Enabled = false;



            }

            else if (Bus3phase.Checked == false)
            {

                BusPhase.Enabled = false;
                busInformationVoltageTXT.Enabled = true;
                busInformationAngelTXT.Enabled = true;

            }
        }

        /*   private void Slackbus_CheckedChanged(object sender, EventArgs e)
           {
               if (Slackbus.Checked ==  true)
               Slackbus.Checked = true;

           }*/

        /*     private void BusInService_CheckedChanged(object sender, EventArgs e)
             {
                 if (!(sender as CheckBox).Checked)
                 {
                    // this.Slackbus.Checked = true;
                     (Main_Menu.GetClickedDiagramBus() as CoreConnector).setInserviceBus(true);
                       bus.Status = true;
                 }
                 else
                 {
                  //   this.Slackbus.Checked = false;
                     (Main_Menu.GetClickedDiagramBus() as CoreConnector).setInserviceBus(false);
                     bus.Status = false;
                 }



             }*/


        private void selectSubstation_Click(object sender, EventArgs e)
        {
           
            SubstationList_Form substationListForm = new SubstationList_Form(bus,this);
            substationListForm.ShowDialog();

            loadData(bus);
        }
    }
}
