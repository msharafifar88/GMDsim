using network;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using BL;
using GUI.New_concept_WPF;
using Syncfusion.UI.Xaml.Diagram;

namespace GUI.contextMenu
{
    public partial class ChangeName_Form : Telerik.WinControls.UI.RadForm
    {
        RadDiagramShape shape;
        NodeViewModel node;
        string name;
        public ChangeName_Form(ref RadDiagramShape shape)
        {
            InitializeComponent();
            this.shape = shape;
            this.name = shape.Name;
            this.StartPosition = FormStartPosition.Manual;
            this.Location = Cursor.Position;
            this.Load += ChangeName_Form_Load;
            
        }

        public ChangeName_Form(ref NodeViewModel node)
        {
            InitializeComponent();
            this.node = node;
            this.name = node.Name;
            this.StartPosition = FormStartPosition.Manual;
            this.Location = Cursor.Position;
            this.Load += ChangeName_Form_Load;

        }

        private void ChangeName_Form_Load(object sender, EventArgs e)
        {
            this.FormElement.TitleBar.CloseButton.Visibility = ElementVisibility.Collapsed;
            this.FormElement.TitleBar.MinimizeButton.Visibility = ElementVisibility.Collapsed;
            this.FormElement.TitleBar.MaximizeButton.Visibility = ElementVisibility.Collapsed;
            string shapeName = null;
            if (this.shape is bus.BusShape)
            {
                Bus bus = ((GUI.bus.BusShape)shape).getBus();
                shapeName = bus.BusName;

            }
            else if (this.node is Shapes.generator.GenShape)
            {
                Generator gen = ((Shapes.generator.GenShape)node).getGenerator();
                shapeName = gen.Name;

            }
            else if (shape is Load.LoadShape)
            {
                Loads loads = ((GUI.Load.LoadShape)shape).getLoad();
                shapeName = loads.Name;
            }
            else if (shape is Rlc.RLCShape) 
            {
                //TODO MODIFY
                RLCbranches rlc = ((GUI.Rlc.RLCShape)shape).getRlcBranch();
                shapeName = rlc.name;
            
            }
            this.radNameTextBox.Text = shapeName;

        }

        private void radSaveButton_Click(object sender, EventArgs e)
        {
            if(this.shape is bus.BusShape)
            {
                Bus bus = ((GUI.bus.BusShape)shape).getBus();
                bus.BusName = this.radNameTextBox.Text;
                BusBL busBL = new BusBL();
                busBL.editBus(bus, CustomContentControl.getCurrentCase());
                ((GUI.bus.BusShape)shape).setlabel(this.radNameTextBox.Text);

            }
            else if (this.node is Shapes.generator.GenShape)
            {
                Generator generator = ((Shapes.generator.GenShape)node).getGenerator();
                generator.Name = this.radNameTextBox.Text;
                GeneratorBL genBl = new GeneratorBL();
                genBl.edit(generator, CustomContentControl.getCurrentCase());

            }
            else if (shape is Load.LoadShape)
            {
                Loads loads = ((GUI.Load.LoadShape)shape).getLoad();
                loads.Name = this.radNameTextBox.Text;
                LoadBL loadBl = new LoadBL();
                loadBl.editLoad(loads, CustomContentControl.getCurrentCase());   
            } 
            else if (shape is Rlc.RLCShape)
            {
                //RLCbranches rlc = ((GUI.Rlc.RLCShape)shape).getRlc();
                RLCbranches rlc = ((GUI.Rlc.AbstractRLCShape)shape).getRlcBranch();
                rlc.name = this.radNameTextBox.Text;
                IRlcBL rlcBl = new RlcBL();
                rlcBl.edit(rlc, CustomContentControl.getCurrentCase());
                ((GUI.Rlc.RLCShape)shape).setLabel(this.radNameTextBox.Text);

            }
            this.Close();
        }

        private void radCancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

  
    }
}
