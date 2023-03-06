using BL;
using BL.Calculation_Core;
using BL.Calculation_Core.Calculation_Data;
using BL.Calculation_Core.ItemWraper;
using BL.Load_BL;
using GUI.FileController;
using GUI.New_concept_WPF;
using GUI.PF_Results;
using MathNet.Numerics.LinearAlgebra;
using persistent;
using persistent.common;
using Syncfusion.Windows.Forms.Tools;
using Syncfusion.Windows.Forms.Tools.XPMenus;
using Syncfusion.WinForms.DataGrid;
using Syncfusion.WinForms.DataGrid.Enums;
using Syncfusion.WinForms.DataGrid.Events;
using Syncfusion.WinForms.DataGrid.Interactivity;
using Syncfusion.WinForms.DataGrid.Styles;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace GUI.DataAccess
{

    public partial class ModelExplorer : Form
    {
        Case caases;

        public ModelExplorer()
        {
            try
            {
                InitializeComponent();
                loadData();

                //initColumns();
                this.Text = this.Text + " " + CustomContentControl.getCurrentCase() != null ? CustomContentControl.getCurrentCase().name : throw new NullReferenceException();
                caases = CustomContentControl.getCurrentCase();
            }
            catch (Exception e)
            {
                Console.Write(e.Message);

            }
        }

        public void loadData()
        {
            TreeCreator tree = new TreeCreator();
            modelExplorerTree.Nodes.AddRange(tree.treeCreator().ToArray());
        }

        /// <summary>
        /// coler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
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
        private void SfDataGrid1_QueryCellStyle(object sender, QueryCellStyleEventArgs e)
        {

            if (e.Column.MappingName == "enable3phase")
            {

                if (e.DisplayText == "False")
                {
                    e.Style.BackColor = Color.Coral;
                    e.Style.TextColor = Color.White;
                }
                else if (e.DisplayText == "True")
                {
                    e.Style.BackColor = Color.LightSkyBlue;
                    e.Style.TextColor = Color.DarkSlateBlue;
                }
            }
        }
        private void modelExplorerTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode node = modelExplorerTree.SelectedNode;
            GMDSimTreeNode simTreeNode = (GMDSimTreeNode)modelExplorerTree.SelectedNode.Tag;
            GMDPageView tabPage = new GMDPageView(modelExplorerTree.SelectedNode.Text, simTreeNode.item);
            tabModelExplorer.ShowTabCloseButton = true;

            //MainFrameBarManager mainFrameBarManager1 = new MainFrameBarManager();
            // mainFrameBarManager1.Style = Syncfusion.Windows.Forms.VisualStyle.Office2016Colorful;

            /*//mainFrameBarManager1
            ParentBarItem parentBarItem1 = new ParentBarItem();

            BarItem barItem1 = new BarItem();
            BarItem barItem2 = new BarItem();
            BarItem barItem3 = new BarItem();
            BarItem barItem4 = new BarItem();

            barItem1.Text = "New";
            barItem2.Text = "Open";
            barItem3.Text = "Save";
            barItem4.Text = "Save As";

            parentBarItem1.Text = "Menu";
            parentBarItem1.Items.AddRange(new Syncfusion.Windows.Forms.Tools.XPMenus.BarItem[]
                    {
                barItem1,
                barItem2,
                barItem3,
                barItem4
            });*/



            ToolStripEx tooltab1ModleExplorer = new ToolStripEx();
            /*  tabDataform.Show();
              tabPage.Controls.Add(tabDataform);*/


            if (node.Parent != null && !tabModelExplorer.TabPages.Contains(tabPage))
            {
                SfDataGrid sfData = new SfDataGrid();
                sfData.SelectionMode = Syncfusion.WinForms.DataGrid.Enums.GridSelectionMode.Single;
                sfData.QueryRowStyle += SfDataGrid_QueryRowStyle;
                sfData.QueryCellStyle += SfDataGrid1_QueryCellStyle;
                sfData.AllowFiltering = true;

                ///
                /// 
                sfData.SelectionMode = GridSelectionMode.Single;
                sfData.Style.HeaderStyle.BackColor = Color.LightGray;
                sfData.Style.HeaderStyle.Borders.All = new GridBorder(Syncfusion.WinForms.DataGrid.Styles.GridBorderStyle.Solid, Color.Black);
                sfData.Style.BorderColor = Color.Black;

                sfData.Style.CellStyle.Borders.All = new GridBorder(Syncfusion.WinForms.DataGrid.Styles.GridBorderStyle.Solid, Color.Black);
                sfData.Style.HeaderStyle.Font.Bold = true;
                sfData.SelectionMode = GridSelectionMode.Extended;
                sfData.AllowResizingColumns = true;
                sfData.AutoSizeColumnsMode = AutoSizeColumnsMode.AllCellsWithLastColumnFill;
                sfData.QueryRowStyle += SfDataGrid_QueryRowStyle;
                sfData.AutoGenerateColumns = false;
                /// 
                ///
                createHeader(sfData, simTreeNode);
                loadData(sfData, simTreeNode);
                //  sfData.Columns[0].FilterPopupMode = Syncfusion.WinForms.GridCommon.FilterPopupMode.Both;
                tabPage.Controls.Add(sfData);

                tabModelExplorer.TabPages.Add(tabPage);
                tabModelExplorer.SelectedTab = tabPage;
                sfData.Dock = DockStyle.Fill;

                var record = SelectionHelper.GetRecordAtRowIndex(sfData, 3);
                sfData.SelectedItem = record;

                /*  TabDataForm tabDataform = new TabDataForm();
                  Button btn = new Button();
                  tabPage.Controls.Add(tabDataform);*/

                tabModelExplorer.Dock = DockStyle.Bottom;
                tabModelExplorer.Dock = DockStyle.Top;
                tabModelExplorer.Dock = DockStyle.Right;
                //tabModelExplorer.Dock = 
                //  tabModelExplorer.Margin = new Padding(0, 0, 0, 0);

            }
            else if (node.Parent != null && tabModelExplorer.TabPages.Contains(tabPage))
            {
                foreach (GMDPageView tb in tabModelExplorer.TabPages)
                {
                    if (tb.Text.Equals(modelExplorerTree.SelectedNode.Text))
                    {
                        tabModelExplorer.SelectedTab = tb;
                    }
                }
            }
            //tabDataform.Show();
            tabPage.Controls.Add(tooltab1ModleExplorer);
            ToolStripButton Insert = new ToolStripButton();
            tooltab1ModleExplorer.Items.Add(Insert);
            tooltab1ModleExplorer.Items.Add(new ToolStripDropDownButton("Open"));
            Insert.Image = Image.FromFile("..//..//Resources/insert.png");
            Insert.Text = "Insert";
            modelExplorerTree.SelectedNode = null;
        }

        private SfDataGrid createHeader(SfDataGrid dataGrid, GMDSimTreeNode simTreeNode)
        {

            if (simTreeNode.item.Equals(ItemEnum.Bus))
            {
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "BusNumber", HeaderText = "Bus Number" });
                dataGrid.Columns["BusNumber"].FilterPopupMode = Syncfusion.WinForms.GridCommon.FilterPopupMode.Both;
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "BusName", HeaderText = "Bus Name" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "Bus_Type", HeaderText = "Bus Type" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "voltage", HeaderText = "Voltage" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "angle", HeaderText = "Angle" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "slack", HeaderText = "Slack" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "Status", HeaderText = "Status" });


                dataGrid.Columns.Add(new GridCheckBoxColumn() { MappingName = "enable3phase", HeaderText = "enable 3phase" });

                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "Va_mag", HeaderText = "Voltage A" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "Va_angle", HeaderText = "Angle A" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "Vb_mag", HeaderText = "Voltage B" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "Vb_angle", HeaderText = "Angle B" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "Vc_mag", HeaderText = "Voltage C" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "Vc_angle", HeaderText = "Angle C" });


                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "NominalVmax", HeaderText = "Normal Vmax" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "NominalVmin", HeaderText = "Normal Vmin" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "EmerVmax", HeaderText = "Emergency Vmax" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "EmerVmin", HeaderText = "Emergency Vmin" });

                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "OwnerNumber", HeaderText = "Owner Number" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "area.Name", HeaderText = "Area Number" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "area.Number", HeaderText = "Area Name" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "zone.Number", HeaderText = "Zone Number" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "zone.Name", HeaderText = "Zone Name" });
            }
            if (simTreeNode.item.Equals(ItemEnum.Generator))
            {

                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "Bus.BusNumber", HeaderText = "Bus Number" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "Bus.BusName", HeaderText = "Bus Name" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "Name", HeaderText = "Name" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "Code", HeaderText = "ID" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "powerControl.setpoint", HeaderText = "Setpoint(MW)" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "powerControl.outPut", HeaderText = "OutPut (MW)" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "powerControl.maxOut", HeaderText = "MAX OutPut (MW)" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "powerControl.minOut", HeaderText = "MIN OutPut (MW)" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "powerControl.availableAVR", HeaderText = "Available AVR" });

                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "Generator_MVA_BASE", HeaderText = "Generator Base (MVA)" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "voltageControl.MvarOutput", HeaderText = "Voltage Output (Mvar)" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "voltageControl.MaxMvars", HeaderText = "MAX Voltage Output  (Mvar)" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "voltageControl.MinMvars", HeaderText = "MIN Voltage Output (Mvar)" });


                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "faultParameters.ISI_Zero_R", HeaderText = "Internal Squence Impedances Zero R" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "faultParameters.ISI_Zero_X", HeaderText = "Internal Squence Impedances Zero X" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "faultParameters.Generatoe_Step_Transformer_R", HeaderText = "Generatoe Step Transformer R" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "faultParameters.Generatoe_Step_Transformer_X", HeaderText = "Generatoe Step Transformer X" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "faultParameters.Generatoe_Step_Transformer_Tap", HeaderText = "Generatoe Step Transformer Tap" });

                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "F1", HeaderText = "F1" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "F2", HeaderText = "F2" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "O3", HeaderText = "O3" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "F3", HeaderText = "F3" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "O4", HeaderText = "O4" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "F4", HeaderText = "F4" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "WMOD", HeaderText = "WMOD" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "WPF", HeaderText = "WPF" });

                // dataGrid.TableDescriptor.Columns.FindByMappingName("Code").ReadOnly = true;
            }
            if (simTreeNode.item.Equals(ItemEnum.SyncGen))
            {
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "Bus.BusNumber", HeaderText = "Bus Number" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "Bus.BusName", HeaderText = "Bus Name" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "Name", HeaderText = "Name" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "Code", HeaderText = "ID" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "powerControl.setpoint", HeaderText = "Setpoint(MW)" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "powerControl.outPut", HeaderText = "OutPut (MW)" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "powerControl.maxOut", HeaderText = "MAX OutPut (MW)" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "powerControl.minOut", HeaderText = "MIN OutPut (MW)" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "Generator_MVA_BASE", HeaderText = "Generator Base (MVA)" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "voltageControl.MvarOutput", HeaderText = "Voltage Output (Mvar)" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "voltageControl.MaxMvars", HeaderText = "MAX Voltage Output  (Mvar)" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "voltageControl.MinMvars", HeaderText = "MIN Voltage Output (Mvar)" });


                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "faultParameters.ISI_Zero_R", HeaderText = "Internal Squence Impedances Zero R" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "faultParameters.ISI_Zero_X", HeaderText = "Internal Squence Impedances Zero X" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "faultParameters.Generatoe_Step_Transformer_R", HeaderText = "Generatoe Step Transformer R" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "faultParameters.Generatoe_Step_Transformer_X", HeaderText = "Generatoe Step Transformer X" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "faultParameters.Generatoe_Step_Transformer_Tap", HeaderText = "Generatoe Step Transformer Tap" });

                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "F1", HeaderText = "F1" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "F2", HeaderText = "F2" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "O3", HeaderText = "O3" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "F3", HeaderText = "F3" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "O4", HeaderText = "O4" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "F4", HeaderText = "F4" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "WMOD", HeaderText = "WMOD" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "WPF", HeaderText = "WPF" });
            }
            if (simTreeNode.item.Equals(ItemEnum.Wind))
            {
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "Bus.BusNumber", HeaderText = "Bus Number" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "Bus.BusName", HeaderText = "Bus Name" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "Name", HeaderText = "Name" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "Code", HeaderText = "ID" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "powerControl.setpoint", HeaderText = "Setpoint(MW)" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "powerControl.outPut", HeaderText = "OutPut (MW)" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "powerControl.maxOut", HeaderText = "MAX OutPut (MW)" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "powerControl.minOut", HeaderText = "MIN OutPut (MW)" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "Generator_MVA_BASE", HeaderText = "Generator Base (MVA)" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "voltageControl.MvarOutput", HeaderText = "Voltage Output (Mvar)" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "voltageControl.MaxMvars", HeaderText = "MAX Voltage Output  (Mvar)" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "voltageControl.MinMvars", HeaderText = "MIN Voltage Output (Mvar)" });


                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "faultParameters.ISI_Zero_R", HeaderText = "Internal Squence Impedances Zero R" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "faultParameters.ISI_Zero_X", HeaderText = "Internal Squence Impedances Zero X" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "faultParameters.Generatoe_Step_Transformer_R", HeaderText = "Generatoe Step Transformer R" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "faultParameters.Generatoe_Step_Transformer_X", HeaderText = "Generatoe Step Transformer X" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "faultParameters.Generatoe_Step_Transformer_Tap", HeaderText = "Generatoe Step Transformer Tap" });

                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "F1", HeaderText = "F1" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "F2", HeaderText = "F2" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "O3", HeaderText = "O3" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "F3", HeaderText = "F3" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "O4", HeaderText = "O4" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "F4", HeaderText = "F4" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "WMOD", HeaderText = "WMOD" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "WPF", HeaderText = "WPF" });
            }
            if (simTreeNode.item.Equals(ItemEnum.PVPnels))
            {
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "Bus.BusNumber", HeaderText = "Bus Number" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "Bus.BusName", HeaderText = "Bus Name" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "Name", HeaderText = "Name" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "Code", HeaderText = "ID" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "powerControl.setpoint", HeaderText = "Setpoint(MW)" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "powerControl.outPut", HeaderText = "OutPut (MW)" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "powerControl.maxOut", HeaderText = "MAX OutPut (MW)" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "powerControl.minOut", HeaderText = "MIN OutPut (MW)" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "Generator_MVA_BASE", HeaderText = "Generator Base (MVA)" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "voltageControl.MvarOutput", HeaderText = "Voltage Output (Mvar)" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "voltageControl.MaxMvars", HeaderText = "MAX Voltage Output  (Mvar)" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "voltageControl.MinMvars", HeaderText = "MIN Voltage Output (Mvar)" });


                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "faultParameters.ISI_Zero_R", HeaderText = "Internal Squence Impedances Zero R" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "faultParameters.ISI_Zero_X", HeaderText = "Internal Squence Impedances Zero X" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "faultParameters.Generatoe_Step_Transformer_R", HeaderText = "Generatoe Step Transformer R" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "faultParameters.Generatoe_Step_Transformer_X", HeaderText = "Generatoe Step Transformer X" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "faultParameters.Generatoe_Step_Transformer_Tap", HeaderText = "Generatoe Step Transformer Tap" });

                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "F1", HeaderText = "F1" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "F2", HeaderText = "F2" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "O3", HeaderText = "O3" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "F3", HeaderText = "F3" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "O4", HeaderText = "O4" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "F4", HeaderText = "F4" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "WMOD", HeaderText = "WMOD" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "WPF", HeaderText = "WPF" });
            }
            if (simTreeNode.item.Equals(ItemEnum.Load))
            {
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "Bus.BusNumber", HeaderText = "Bus Number" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "Bus.BusName", HeaderText = "From Bus Name" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "linebranches.Identity", HeaderText = "ID" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "Bus.area.Number", HeaderText = "Area Number" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "Bus.area.Name", HeaderText = "Area Name" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "Bus.zone.Number", HeaderText = "Zone Number" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "Bus.zone.Name", HeaderText = "Zone Name" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "Bus.Owners[0].Number", HeaderText = "Zone Number" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "Bus.Owners[0].Name", HeaderText = "Zone Name" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "loadinformation.P_Power", HeaderText = "Constant Power(MV)" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "loadinformation.P_Current", HeaderText = "Constant Current(MV)" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "loadinformation.P_Impedance", HeaderText = "Constant Impedance (MV)" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "loadinformation.Q_Power", HeaderText = "Constant Power(MVar)" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "loadinformation.Q_Current", HeaderText = "Constant Current(MVar)" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "loadinformation.Q_Impedance", HeaderText = "Constant Impedance (MVar)" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "distributedGeneration.P_GEN", HeaderText = "Distribut Generation (MV)" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "distributedGeneration.Q_GEN", HeaderText = " Distribut Generation (MVar)" });
                dataGrid.Columns.Add(new GridCheckBoxColumn() { MappingName = "Inservice", HeaderText = "Inservice" });
                dataGrid.Columns.Add(new GridCheckBoxColumn() { MappingName = "Interruptible", HeaderText = "Interruptible" });
                dataGrid.Columns.Add(new GridCheckBoxColumn() { MappingName = "Scalable", HeaderText = "Scalable" });
                dataGrid.Columns.Add(new GridCheckBoxColumn() { MappingName = "distributedGeneration.DGinservice", HeaderText = "Distributed Generationinservice" });

            }
            if (simTreeNode.item.Equals(ItemEnum.EvMachine))
            {
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "Bus.BusNumber", HeaderText = "Bus Number" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "Bus.BusName", HeaderText = "From Bus Name" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "linebranches.Identity", HeaderText = "ID" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "Bus.area.Number", HeaderText = "Area Number" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "Bus.area.Name", HeaderText = "Area Name" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "Bus.zone.Number", HeaderText = "Zone Number" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "Bus.zone.Name", HeaderText = "Zone Name" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "Bus.Owners[0].Number", HeaderText = "Zone Number" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "Bus.Owners[0].Name", HeaderText = "Zone Name" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "loadinformation.P_Power", HeaderText = "Constant Power(MV)" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "loadinformation.P_Current", HeaderText = "Constant Current(MV)" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "loadinformation.P_Impedance", HeaderText = "Constant Impedance (MV)" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "loadinformation.Q_Power", HeaderText = "Constant Power(MVar)" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "loadinformation.Q_Current", HeaderText = "Constant Current(MVar)" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "loadinformation.Q_Impedance", HeaderText = "Constant Impedance (MVar)" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "distributedGeneration.P_GEN", HeaderText = "Distribut Generation (MV)" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "distributedGeneration.Q_GEN", HeaderText = " Distribut Generation (MVar)" });
                dataGrid.Columns.Add(new GridCheckBoxColumn() { MappingName = "Inservice", HeaderText = "Inservice" });
                dataGrid.Columns.Add(new GridCheckBoxColumn() { MappingName = "Interruptible", HeaderText = "Interruptible" });
                dataGrid.Columns.Add(new GridCheckBoxColumn() { MappingName = "Scalable", HeaderText = "Scalable" });
                dataGrid.Columns.Add(new GridCheckBoxColumn() { MappingName = "distributedGeneration.DGinservice", HeaderText = "Distributed Generationinservice" });

            }
            if (simTreeNode.item.Equals(ItemEnum.C2WindingThransformer))
            {

                //info
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "PrimaryBUS.BusNumber", HeaderText = "Primary (HV) Bus" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "PrimaryBUS.BusName", HeaderText = "First Bus Name" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "SecondaryBUS.BusNumber", HeaderText = "Secondary (LV) Bus" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "SecondaryBUS.BusName", HeaderText = "Second Bus Name" });

                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "Identity", HeaderText = "ID" });

                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "nominalData.PrimaryNominalRating", HeaderText = "Nominal rating HV" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "nominalData.SecondaryNominalRating", HeaderText = "Nominal rating LV" });
                //dataGrid.Columns.Add(new GridTextColumn() { MappingName = "nominalData.TertiaryNominalRating", HeaderText = "Nominal rating TV" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "nominalData.PrimaryRatedVoltage", HeaderText = "Rated Voltage HV" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "nominalData.SecondaryRatedVoltage", HeaderText = "Rated Voltage LV" });
                //dataGrid.Columns.Add(new GridTextColumn() { MappingName = "nominalData.TertiaryRatedVoltage", HeaderText = "Rated Voltage TV" });
                dataGrid.Columns.Add(new GridCheckBoxColumn() { MappingName = "Inservice", HeaderText = "Inservice" });

                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "PrimaryBUS.area.Number", HeaderText = "Area Number" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "PrimaryBUS.area.Name", HeaderText = "Area Name" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "PrimaryBUS.zone.Number", HeaderText = "Zone Number" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "PrimaryBUS.zone.Name", HeaderText = "Zone Name" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "PrimaryBUS.Owners[0].Number", HeaderText = "Owners Number" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "PrimaryBUS.Owners[0].Name", HeaderText = "Owners Name" });




                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "impedances.Z1_HVLV", HeaderText = "Z1 HVLV" });
                //dataGrid.Columns.Add(new GridTextColumn() { MappingName = "impedances.Z1_HVTV", HeaderText = "Z1 HVTV" });
                //dataGrid.Columns.Add(new GridTextColumn() { MappingName = "impedances.Z1_LVTV", HeaderText = "Z1 LVTV" });

                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "impedances.Psc_HVLV", HeaderText = "Psc HVLV" });
                //dataGrid.Columns.Add(new GridTextColumn() { MappingName = "impedances.Psc_HVTV", HeaderText = "Psc HVTV" });
                //dataGrid.Columns.Add(new GridTextColumn() { MappingName = "impedances.Psc_LVTV", HeaderText = "Psc LVTV" });

                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "impedances.X1_HVLV", HeaderText = "X1 HVLV" });
                //dataGrid.Columns.Add(new GridTextColumn() { MappingName = "impedances.X1_HVTV", HeaderText = "X1 HVTV" });
                //dataGrid.Columns.Add(new GridTextColumn() { MappingName = "impedances.X1_LVTV", HeaderText = "X1 LVTV" });

                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "impedances.R1_HVLV", HeaderText = "R1 HVLV" });
                //dataGrid.Columns.Add(new GridTextColumn() { MappingName = "impedances.R1_HVLV", HeaderText = "R1 HVTV" });
                //dataGrid.Columns.Add(new GridTextColumn() { MappingName = "impedances.R1_HVLV", HeaderText = "R1 LVTV" });

                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "impedances.Z0_HVLV", HeaderText = "Z0 HVLV" });
                //dataGrid.Columns.Add(new GridTextColumn() { MappingName = "impedances.Z0_HVLV", HeaderText = "Z0 HVTV" });
                //dataGrid.Columns.Add(new GridTextColumn() { MappingName = "impedances.Z0_LVTV", HeaderText = "Z0 LVTV" });

                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "impedances.X0_HVLV", HeaderText = "Z0 HVLV" });
                // dataGrid.Columns.Add(new GridTextColumn() { MappingName = "impedances.X0_HVTV", HeaderText = "Z0 HVTV" });
                //dataGrid.Columns.Add(new GridTextColumn() { MappingName = "impedances.X0_LVTV", HeaderText = "Z0 LVTV" });

                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "impedances.R0_HVLV", HeaderText = "R0 HVLV" });
                //dataGrid.Columns.Add(new GridTextColumn() { MappingName = "impedances.R0_HVLV", HeaderText = "R0 HVTV" });
                //dataGrid.Columns.Add(new GridTextColumn() { MappingName = "impedances.R0_HVLV", HeaderText = "R0 LVTV" });

                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "impedances.Magnetization_Conductance", HeaderText = "Magnetiz Conductace" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "impedances.NoLosses", HeaderText = "NoLosses " });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "impedances.MagnetizConductace_Current", HeaderText = "Magnetiz Conductace" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "impedances.RG_HVLV", HeaderText = "RG HVLV" });
                //dataGrid.Columns.Add(new GridTextColumn() { MappingName = "impedances.RG_HVTV", HeaderText = "RG HVTV" });
                //dataGrid.Columns.Add(new GridTextColumn() { MappingName = "impedances.RG_LVTV", HeaderText = "RG HVTV" });

                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "impedances.XG_HVLV", HeaderText = "XG HVLV" });
                // dataGrid.Columns.Add(new GridTextColumn() { MappingName = "impedances.XG_HVTV", HeaderText = "XG HVTV " });
                // dataGrid.Columns.Add(new GridTextColumn() { MappingName = "impedances.XG_LVTV", HeaderText = "XG LVTV " });

                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "impedances.RG_HVLV", HeaderText = "RG HVLV" });
                // dataGrid.Columns.Add(new GridTextColumn() { MappingName = "impedances.RG_HVTV", HeaderText = "RG HVTV" });
                // dataGrid.Columns.Add(new GridTextColumn() { MappingName = "impedances.RG_LVTV", HeaderText = "RG LVTV" });
                ///
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "ltccontrol.FIXPrimNominalTurnRateHV", HeaderText = "HV Nominal" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "ltccontrol.FIXPrimNominalTurnRateLV", HeaderText = "LV Nominal" });
                //  dataGrid.Columns.Add(new GridTextColumn() { MappingName = "ltccontrol.FIXPrimNominalTurnRateTV", HeaderText = "TV Nominal" });

                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "ltccontrol.FIXPrimPhaseHV", HeaderText = "HV PhaseShift" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "ltccontrol.FIXSecPhaseLV", HeaderText = "LV PhaseShift" });
                //  dataGrid.Columns.Add(new GridTextColumn() { MappingName = "ltccontrol.FIXTerPhaseTV", HeaderText = "TV PhaseShift" });

                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "mvalimits.PrimaryNominal", HeaderText = "Primary Nominal" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "mvalimits.SecendrayNominal", HeaderText = "Secendray Nominal" });
                //  dataGrid.Columns.Add(new GridTextColumn() { MappingName = "mvalimits.TertiaryNominal", HeaderText = "Tertiary Nominal" });

                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "mvalimits.PrimarySummer", HeaderText = "Primary Summer" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "mvalimits.SecendraySummer", HeaderText = "Secendray Summer" });
                // dataGrid.Columns.Add(new GridTextColumn() { MappingName = "mvalimits.TertiarySummer", HeaderText = "Tertiary Summer" });

                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "mvalimits.PrimaryWinter", HeaderText = "Primary Winter" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "mvalimits.SecendrayWinter", HeaderText = "Secendray Winter" });
                // dataGrid.Columns.Add(new GridTextColumn() { MappingName = "mvalimits.TertiaryWinter", HeaderText = " Tertiary Winter" });

                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "mvalimits.PrimarySummerEmergancy", HeaderText = "Primary Summer Emergancy" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "mvalimits.SecendraySummerEmergancy", HeaderText = "Secendray Summer Emergancy" });
                // dataGrid.Columns.Add(new GridTextColumn() { MappingName = "mvalimits.TertiarySummerEmergancy", HeaderText = "Tertiary Summer Emergancy" });

                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "mvalimits.PrimaryWinterEmergancy", HeaderText = "Primary Winter Emergancy" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "mvalimits.SecendrayWinterEmergancy", HeaderText = "Secendray Winter Emergancy" });
                // dataGrid.Columns.Add(new GridTextColumn() { MappingName = "mvalimits.TertiaryWinterEmergancy", HeaderText = "Tertiary Winter Emergancy" });

                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "topology.YMArea", HeaderText = "YMA rea" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "topology.YMAlength", HeaderText = "YMA length" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "topology.RMArea", HeaderText = "RM Area" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "topology.RMAlength", HeaderText = "RMA length" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "topology.CtoTAirgap", HeaderText = "Core to Tank" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "topology.TSL", HeaderText = "TSL" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "topology.AirHV", HeaderText = "Air HV" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "topology.AirLV", HeaderText = "Air LV" });
                // dataGrid.Columns.Add(new GridTextColumn() { MappingName = "topology.AirTV", HeaderText = "Air TV" });

                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "testData.windingDCResistances.HV", HeaderText = "YMArea" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "testData.windingDCResistances.HV", HeaderText = "YMArea" });
                // dataGrid.Columns.Add(new GridTextColumn() { MappingName = "testData.windingDCResistances.HV", HeaderText = "YMArea" });

                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "testData.windingCapacitances.HV_Ground", HeaderText = "HV Ground" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "testData.windingCapacitances.HV_Ground", HeaderText = "LV Ground" });
                // dataGrid.Columns.Add(new GridTextColumn() { MappingName = "testData.windingCapacitances.TV_Ground", HeaderText = "TV Ground" });

                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "testData.windingCapacitances.HV_LV", HeaderText = "wind Cap HV LV" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "testData.windingCapacitances.HV_TV", HeaderText = "wind Cap HV TV" });
                // dataGrid.Columns.Add(new GridTextColumn() { MappingName = "testData.windingCapacitances.LV_TV", HeaderText = "wind Cap TV LV" });
            }
            if (simTreeNode.item.Equals(ItemEnum.Custom3wT))
            {
                //info
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "PrimaryBUS.BusNumber", HeaderText = "Primary (HV) Bus" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "PrimaryBUS.BusName", HeaderText = "First Bus Name" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "SecondaryBUS.BusNumber", HeaderText = "Secondary (LV) Bus" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "SecondaryBUS.BusName", HeaderText = "Second Bus Name" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "TertiaryBUS.BusNumber", HeaderText = "Tertiary (TV) Bus" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "TertiaryBUS.BusName", HeaderText = "Third Bus Name" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "Identity", HeaderText = "ID" });

                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "nominalData.PrimaryNominalRating", HeaderText = "Nominal rating HV" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "nominalData.SecondaryNominalRating", HeaderText = "Nominal rating LV" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "nominalData.TertiaryNominalRating", HeaderText = "Nominal rating TV" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "nominalData.PrimaryRatedVoltage", HeaderText = "Rated Voltage HV" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "nominalData.SecondaryRatedVoltage", HeaderText = "Rated Voltage LV" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "nominalData.TertiaryRatedVoltage", HeaderText = "Rated Voltage TV" });
                dataGrid.Columns.Add(new GridCheckBoxColumn() { MappingName = "Inservice", HeaderText = "Inservice" });

                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "PrimaryBUS.area.Number", HeaderText = "Area Number" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "PrimaryBUS.area.Name", HeaderText = "Area Name" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "PrimaryBUS.zone.Number", HeaderText = "Zone Number" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "PrimaryBUS.zone.Name", HeaderText = "Zone Name" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "PrimaryBUS.Owners[0].Number", HeaderText = "Owners Number" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "PrimaryBUS.Owners[0].Name", HeaderText = "Owners Name" });

                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "impedances.Z1_HVLV", HeaderText = "Z1 HVLV" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "impedances.Z1_HVTV", HeaderText = "Z1 HVTV" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "impedances.Z1_LVTV", HeaderText = "Z1 LVTV" });

                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "impedances.Psc_HVLV", HeaderText = "Psc HVLV" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "impedances.Psc_HVTV", HeaderText = "Psc HVTV" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "impedances.Psc_LVTV", HeaderText = "Psc LVTV" });

                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "impedances.X1_HVLV", HeaderText = "X1 HVLV" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "impedances.X1_HVTV", HeaderText = "X1 HVTV" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "impedances.X1_LVTV", HeaderText = "X1 LVTV" });

                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "impedances.R1_HVLV", HeaderText = "R1 HVLV" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "impedances.R1_HVLV", HeaderText = "R1 HVTV" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "impedances.R1_HVLV", HeaderText = "R1 LVTV" });

                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "impedances.Z0_HVLV", HeaderText = "Z0 HVLV" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "impedances.Z0_HVLV", HeaderText = "Z0 HVTV" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "impedances.Z0_LVTV", HeaderText = "Z0 LVTV" });

                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "impedances.X0_HVLV", HeaderText = "Z0 HVLV" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "impedances.X0_HVTV", HeaderText = "Z0 HVTV" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "impedances.X0_LVTV", HeaderText = "Z0 LVTV" });

                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "impedances.R0_HVLV", HeaderText = "R0 HVLV" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "impedances.R0_HVLV", HeaderText = "R0 HVTV" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "impedances.R0_HVLV", HeaderText = "R0 LVTV" });

                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "impedances.Magnetization_Conductance", HeaderText = "Magnetiz Conductace" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "impedances.NoLosses", HeaderText = "NoLosses " });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "impedances.MagnetizConductace_Current", HeaderText = "Magnetiz Conductace" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "impedances.RG_HVLV", HeaderText = "RG HVLV" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "impedances.RG_HVTV", HeaderText = "RG HVTV" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "impedances.RG_LVTV", HeaderText = "RG HVTV" });

                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "impedances.XG_HVLV", HeaderText = "XG HVLV" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "impedances.XG_HVTV", HeaderText = "XG HVTV " });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "impedances.XG_LVTV", HeaderText = "XG LVTV " });

                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "impedances.RG_HVLV", HeaderText = "RG HVLV" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "impedances.RG_HVTV", HeaderText = "RG HVTV" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "impedances.RG_LVTV", HeaderText = "RG LVTV" });
                ///
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "ltccontrol.FIXPrimNominalTurnRateHV", HeaderText = "HV Nominal" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "ltccontrol.FIXPrimNominalTurnRateLV", HeaderText = "LV Nominal" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "ltccontrol.FIXPrimNominalTurnRateTV", HeaderText = "TV Nominal" });

                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "ltccontrol.FIXPrimPhaseHV", HeaderText = "HV PhaseShift" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "ltccontrol.FIXSecPhaseLV", HeaderText = "LV PhaseShift" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "ltccontrol.FIXTerPhaseTV", HeaderText = "TV PhaseShift" });

                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "mvalimits.PrimaryNominal", HeaderText = "Primary Nominal" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "mvalimits.SecendrayNominal", HeaderText = "Secendray Nominal" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "mvalimits.TertiaryNominal", HeaderText = "Tertiary Nominal" });

                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "mvalimits.PrimarySummer", HeaderText = "Primary Summer" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "mvalimits.SecendraySummer", HeaderText = "Secendray Summer" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "mvalimits.TertiarySummer", HeaderText = "Tertiary Summer" });

                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "mvalimits.PrimaryWinter", HeaderText = "Primary Winter" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "mvalimits.SecendrayWinter", HeaderText = "Secendray Winter" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "mvalimits.TertiaryWinter", HeaderText = " Tertiary Winter" });

                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "mvalimits.PrimarySummerEmergancy", HeaderText = "Primary Summer Emergancy" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "mvalimits.SecendraySummerEmergancy", HeaderText = "Secendray Summer Emergancy" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "mvalimits.TertiarySummerEmergancy", HeaderText = "Tertiary Summer Emergancy" });

                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "mvalimits.PrimaryWinterEmergancy", HeaderText = "Primary Winter Emergancy" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "mvalimits.SecendrayWinterEmergancy", HeaderText = "Secendray Winter Emergancy" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "mvalimits.TertiaryWinterEmergancy", HeaderText = "Tertiary Winter Emergancy" });

                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "topology.YMArea", HeaderText = "YMA rea" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "topology.YMAlength", HeaderText = "YMA length" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "topology.RMArea", HeaderText = "RM Area" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "topology.RMAlength", HeaderText = "RMA length" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "topology.CtoTAirgap", HeaderText = "Core to Tank" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "topology.TSL", HeaderText = "TSL" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "topology.AirHV", HeaderText = "Air HV" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "topology.AirLV", HeaderText = "Air LV" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "topology.AirTV", HeaderText = "Air TV" });

                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "testData.windingDCResistances.HV", HeaderText = "YMArea" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "testData.windingDCResistances.HV", HeaderText = "YMArea" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "testData.windingDCResistances.HV", HeaderText = "YMArea" });

                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "testData.windingCapacitances.HV_Ground", HeaderText = "HV Ground" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "testData.windingCapacitances.HV_Ground", HeaderText = "LV Ground" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "testData.windingCapacitances.TV_Ground", HeaderText = "TV Ground" });

                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "testData.windingCapacitances.HV_LV", HeaderText = "wind Cap HV LV" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "testData.windingCapacitances.HV_TV", HeaderText = "wind Cap HV TV" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "testData.windingCapacitances.LV_TV", HeaderText = "wind Cap TV LV" });

                //

            }

            if (simTreeNode.item.Equals(ItemEnum.Singleline3phase))
            {
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "FromBus.BusNumber", HeaderText = "From Bus Number" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "FromBus.BusName", HeaderText = "From Bus Name" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "ToBus.BusNumber", HeaderText = "To Bus Number" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "ToBus.BusName", HeaderText = "To Bus Name" });

                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "Resistance", HeaderText = "Serise Resistance (R)" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "Reactance", HeaderText = "Serise Reactance (X)" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "Charging", HeaderText = "Shunt Charging (B)" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "Conductance", HeaderText = "Shunt Conductance (G)" });

                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "RzeroSequence", HeaderText = "Zero Sequence (R)" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "XzeroSequence", HeaderText = "Zero Sequence (X)" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "BzeroSequence", HeaderText = "Zero Sequence (B)" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "GzeroSequence", HeaderText = "Zero Sequence (G)" });


            }
            if (simTreeNode.item.Equals(ItemEnum.DoubleCircuit))
            {

                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "FromBus.BusNumber", HeaderText = "From Bus Number" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "FromBus.BusName", HeaderText = "From Bus Name" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "ToBus.BusNumber", HeaderText = "To Bus Number" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "ToBus.BusName", HeaderText = "To Bus Name" });

                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "Resistance", HeaderText = "Serise Resistance (R)" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "Reactance", HeaderText = "Serise Reactance (X)" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "Charging", HeaderText = "Shunt Charging (B)" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "Conductance", HeaderText = "Shunt Conductance (G)" });

                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "RzeroSequence", HeaderText = "Zero Sequence (R)" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "XzeroSequence", HeaderText = "Zero Sequence (X)" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "BzeroSequence", HeaderText = "Zero Sequence (B)" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "GzeroSequence", HeaderText = "Zero Sequence (G)" });

            }
            if (simTreeNode.item.Equals(ItemEnum.MPhase))
            {

                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "FromBus.BusNumber", HeaderText = "From Bus Number" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "FromBus.BusName", HeaderText = "From Bus Name" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "ToBus.BusNumber", HeaderText = "To Bus Number" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "ToBus.BusName", HeaderText = "To Bus Name" });

                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "Resistance", HeaderText = "Serise Resistance (R)" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "Reactance", HeaderText = "Serise Reactance (X)" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "Charging", HeaderText = "Shunt Charging (B)" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "Conductance", HeaderText = "Shunt Conductance (G)" });

                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "RzeroSequence", HeaderText = "Zero Sequence (R)" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "XzeroSequence", HeaderText = "Zero Sequence (X)" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "BzeroSequence", HeaderText = "Zero Sequence (B)" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "GzeroSequence", HeaderText = "Zero Sequence (G)" });
            }

            if (simTreeNode.item.Equals(ItemEnum.R) || simTreeNode.item.Equals(ItemEnum.C) || simTreeNode.item.Equals(ItemEnum.L) ||
                simTreeNode.item.Equals(ItemEnum.RL) || simTreeNode.item.Equals(ItemEnum.LC) || simTreeNode.item.Equals(ItemEnum.RLC))
            {
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "number", HeaderText = "Number" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "name", HeaderText = "Name" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "branch", HeaderText = "Branch" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "nominalFrequency", HeaderText = "Nominal Frequency" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "Bus.BusNumber", HeaderText = "Bus Number" });
                dataGrid.Columns.Add(new GridTextColumn() { MappingName = "Bus.BusName", HeaderText = "Bus Name" });
            }
            return dataGrid;

        }

        private void loadData(SfDataGrid dataGrid, GMDSimTreeNode simTreeNode)
        {
            if (simTreeNode.item.Equals(ItemEnum.Bus))
            {
                BusBL busBL = new BusBL();
                dataGrid.DataSource = busBL.loadAll(caases);
            }
            if (simTreeNode.item.Equals(ItemEnum.Generator))
            {
                GeneratorBL generatorBL = new GeneratorBL();
                dataGrid.DataSource = generatorBL.LoadAll(caases);
            }
            if (simTreeNode.item.Equals(ItemEnum.SyncGen))
            {
                SyncGenBL syncGenBL = new SyncGenBL();
                dataGrid.DataSource = syncGenBL.LoadAll(caases);
            }
            if (simTreeNode.item.Equals(ItemEnum.Wind))
            {
                WindGenBL windGenBL = new WindGenBL();
                dataGrid.DataSource = windGenBL.LoadAll(caases);
            }
            if (simTreeNode.item.Equals(ItemEnum.PVPnels))
            {
                PVGenBL pvGenBL = new PVGenBL();
                dataGrid.DataSource = pvGenBL.LoadAll(caases);
            }
            if (simTreeNode.item.Equals(ItemEnum.Load))
            {
                LoadBL loadBL = new LoadBL();
                dataGrid.DataSource = loadBL.loadAll(caases);
            }
            if (simTreeNode.item.Equals(ItemEnum.EvMachine))
            {
                EVBL evbl = new EVBL();
                dataGrid.DataSource = evbl.loadAll(caases);
            }
            if (simTreeNode.item.Equals(ItemEnum.Area))
            {
                AreaBL areaBL = new AreaBL();
                dataGrid.DataSource = areaBL.loadAll();
            }
            if (simTreeNode.item.Equals(ItemEnum.Zone))
            {
                ZoneBL zoneBL = new ZoneBL();
                dataGrid.DataSource = zoneBL.loadAll();
            }
            if (simTreeNode.item.Equals(ItemEnum.Owner))
            {
                OwnerBL ownerBL = new OwnerBL();
                dataGrid.DataSource = ownerBL.loadAll();
            }
            if (simTreeNode.item.Equals(ItemEnum.Custom3wT))
            {
                C3WTransformerBL transformerBL = new C3WTransformerBL();
                dataGrid.DataSource = transformerBL.loadAll(caases);
            }
            if (simTreeNode.item.Equals(ItemEnum.C2WindingThransformer))
            {
                C2WTransformerBL c2wtransformerBL = new C2WTransformerBL();
                dataGrid.DataSource = c2wtransformerBL.loadAll(caases);
            }
            if (simTreeNode.item.Equals(ItemEnum.DoubleCircuit))
            {
                DoubleCircuitLineBL doubleCircuitLineBL = new DoubleCircuitLineBL();
                dataGrid.DataSource = doubleCircuitLineBL.loadAll(caases);
            }
            if (simTreeNode.item.Equals(ItemEnum.Singleline3phase))
            {
                Single3phaseLineBL single3p = new Single3phaseLineBL();
                dataGrid.DataSource = single3p.loadAll(caases);
            }
            if (simTreeNode.item.Equals(ItemEnum.DualPhase))
            {
                DoubleCircuitLineBL doubleCircuit = new DoubleCircuitLineBL();
                dataGrid.DataSource = doubleCircuit.loadAll(caases);
            }
            if (simTreeNode.item.Equals(ItemEnum.MPhase))
            {
                MultiPhaseLineBL multiPhaseLine = new MultiPhaseLineBL();
                dataGrid.DataSource = multiPhaseLine.loadAll(caases);
            }
            if (simTreeNode.item.Equals(ItemEnum.R))
            {
                RBL rlcBl = new RBL();
                dataGrid.DataSource = rlcBl.loadAll(caases);
            }
            if (simTreeNode.item.Equals(ItemEnum.L))
            {
                LBL rlcBl = new LBL();
                dataGrid.DataSource = rlcBl.loadAll(caases);
            }
            if (simTreeNode.item.Equals(ItemEnum.C))
            {
                CBL rlcBl = new CBL();
                dataGrid.DataSource = rlcBl.loadAll(caases);
            }
            if (simTreeNode.item.Equals(ItemEnum.RL))
            {
                RlBL rlcBl = new RlBL();
                dataGrid.DataSource = rlcBl.loadAll(caases);
            }
            if (simTreeNode.item.Equals(ItemEnum.LC))
            {
                LcBL rlcBl = new LcBL();
                dataGrid.DataSource = rlcBl.loadAll(caases);
            }
            if (simTreeNode.item.Equals(ItemEnum.RLC))
            {
                RlcBL rlcBl = new RlcBL();
                dataGrid.DataSource = rlcBl.loadAll(caases);
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ParentBarItem parentBarItem1 = new ParentBarItem();

            BarItem barItem1 = new BarItem();
            BarItem barItem2 = new BarItem();
            BarItem barItem3 = new BarItem();
            BarItem barItem4 = new BarItem();

            barItem1.Text = "New";
            barItem2.Text = "Open";
            barItem3.Text = "Save";
            barItem4.Text = "Save As";

            parentBarItem1.Text = "Menu";
            parentBarItem1.Items.AddRange(new Syncfusion.Windows.Forms.Tools.XPMenus.BarItem[]
                    {
                barItem1,
                barItem2,
                barItem3,
                barItem4
            });

        }

        private void Insert1_Click(object sender, EventArgs e)
        {
            FileBrowser filebrowser = new FileBrowser(FileType.MatPower);
            filebrowser.ShowDialog();
            //this.Refresh();
        }

        private void DataCollector_Click(object sender, EventArgs e)
        {
            Data_Collector datacollector = new Data_Collector(caases, CustomContentControl.GetTypeOfInput());
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory + @"\testfile.txt";
            sfd.RestoreDirectory = true;
            sfd.FileName = " *.txt";
            sfd.Title = "Save text Files";
            // sfd.CheckFileExists = true;
            //sfd.CheckPathExists = true;
            sfd.DefaultExt = "txt";
            sfd.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            sfd.FilterIndex = 2;
            sfd.RestoreDirectory = true;

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                datacollector.printData(sfd.OpenFile());
            }
            //datacollector.printData();

        }

        private void Runpf_Click(object sender, EventArgs e)
        {
            // try
            {
                Runpf runpf = new Runpf(caases, CustomContentControl.GetTypeOfInput());
                List<BusDataWrapper> _Bus = new List<BusDataWrapper>();
                List<GeneratorDataWrapper> _Generator = new List<GeneratorDataWrapper>();
                List<BranchDataWrapper> _Branch = new List<BranchDataWrapper>();
                bool success = false;
                Vector<System.Numerics.Complex> V = Vector<System.Numerics.Complex>.Build.Dense(_Branch.Count);
                int index_of_iterator = 0;
                (_Bus, _Generator, _Branch, V, success, index_of_iterator) = runpf.init(caases, CustomContentControl.GetTypeOfInput());

                if (success == true)
                {
                    PF_result pfResult = new PF_result(_Bus, _Generator, _Branch, V, success, index_of_iterator);
                    pfResult.ShowDialog();
                }
            }

            /*catch(Exception ex) {
                MessageBox.Show("An Error occurred during the loading process (RUNPF)  inja " + ex.Message);

            }*/
        }
    }
}
