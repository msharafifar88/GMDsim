using GUI.GUIUtils;
using network;
using persistent.network.Transformers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.Transformer
{
    public partial class LoadTAPChanger : Form
    {
        Boolean AVR;
        Boolean RPC;
        Boolean PSC;
        List<Bus> buses;
        LoadTapChanger tapChanger;

       

        public LoadTAPChanger(Boolean AVR,Boolean RPC, Boolean PSC,MainTransformers mainTransformers)
        {
           
            InitializeComponent();

            MainTransformers transformer = mainTransformers;
            tapChanger = transformer.ltccontrol.tapChanger;

        /*    buses.Add(transformer.PrimaryBUS);
            buses.Add(transformer.SecondaryBUS);
            buses.Add(transformer.TertiaryBUS);*/
            ColorForm.ChangeCollorOFLabel(this);
            this.AVR = AVR;
            this.RPC = RPC;
            this.PSC = PSC;
            if (AVR)
            {
                groupLineDropCompensation.Visible = true;
                LineDropCompensation.Visible = true;
                this.groupBox1.Text = "Voltage Control";
                this.label_VoltageControl1.Text = "Voltage Setpoint";
                this.label_g2_l3.Text = "%";
                this.label_VoltageControl3.Text = "Upper Band";
                this.label_g2_l1.Text = "%";
                this.label_VoltageControl5.Text = "Lower Band";
                this.label_g2_l2.Text = "%";
                
            }
            if (RPC)
            {
                this.groupBox1.Text = "Reative Power Control";
                this.label_VoltageControl1.Text = "Q Setpoint";
                this.label_g2_l3.Text = "MVAR";
                this.label_VoltageControl3.Text = "Min";
                this.label_g2_l1.Text = "MVAR";
                this.label_VoltageControl5.Text = "Max";
                this.label_g2_l2.Text = "MVAR";
            }
            if (PSC)
            {
                this.groupBox1.Text = "Active Power Control";
                this.label_VoltageControl1.Text = "P Setpoint";
                this.label_g2_l3.Text = "MW";
                this.label_VoltageControl3.Text = "Min";
                this.label_g2_l1.Text = "MW";
                this.label_VoltageControl5.Text = "Max";
                this.label_g2_l2.Text = "MW";
                this.tap_kv_min.Visible = false;
                this.tap_kv_max.Visible = false;
                this.tap_kv_step.Visible = false;
                this.label10.Visible = false;

                this.olu.Visible = false;
                this.label4.Visible = true;


                this.label3.Visible = true;
            }
            comboBUS.DataSource = buses;
        }
        public void LoadData()
        {
            /* Tap */
            tap_min_txt.Text = tapChanger.Tap_Min.ToString();
            tap_max_txt.Text = tapChanger.Tap_Min.ToString();
            tap_step_txt.Text = tapChanger.Tap_Min.ToString();
            tap_kv_min.Text = "0";
            tap_kv_max.Text = "0";
            tap_kv_step.Text = "0";
            /* Time Delay */
            initial_txt.Text = tapChanger.Tap_Min.ToString();
            operatinig_txt.Text = tapChanger.Tap_Min.ToString();
           


            resistance_txt.Text = tapChanger.Resistance.ToString();
            reactance_txt.Text = tapChanger.Reactance.ToString();
            NumOfTab.Value = tapChanger.Of_Taps;

        }

        private void LineDropCompensation_CheckedChanged(object sender, EventArgs e)
        {
            if (LineDropCompensation.Checked == true)
            {
                groupLineDropCompensation.Visible = true;
                groupLineDropCompensation.Enabled = true;

            }else if (LineDropCompensation.Checked == false)
            {
                groupLineDropCompensation.Enabled = false;
            }
        }

        private void comboBUS_SelectionChangeCommitted(object sender, EventArgs e)
        {
            tapChanger.bus = (Bus)comboBUS.SelectedItem;
        }
    }
}
