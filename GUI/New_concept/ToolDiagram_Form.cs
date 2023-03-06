
using GUI.bus;
using GUI.generator;
using GUI.Load;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.Svg;
using Telerik.WinControls.UI;
using Telerik.Windows.Diagrams.Core;
using Point = System.Drawing.Point;
using GUI.customRadTreeView;
using network;
using BL;
using GUI.customDocumentWindow;
using persistent;
using System.Configuration;
using GUI.New_concept_WPF;

namespace GUI.New_concept
{
    public partial class ToolDiagram_Form : RadForm
    {
        private CaseBL caseBL = null;

        private static string clickedShaped = null;

        private static bool isLockedCreation = false;
        public ToolDiagram_Form()
        {
            caseBL = new CaseBL();
            InitializeComponent();
            add_CustomTreeView();
            this.toolPropWindow.DockState = Telerik.WinControls.UI.Docking.DockState.AutoHide;
            this.radGridColorBox.ColorDialog.ColorDialogForm.ShowProfessionalColors = false;
            this.radBackColorBox.ColorDialog.ColorDialogForm.ShowProfessionalColors = false;
            this.toolSettingsWindow.DockState = Telerik.WinControls.UI.Docking.DockState.AutoHide;
            //this.toolSettingsWindow.ClientSize = new System.Drawing.Size(500, 466);
            this.Update();
        }


        //add_customTreeView() inserts a customTreeView that allows dragging and dropping shapes
        //and creates and set all the nodes and subnodes of this control
        private void add_CustomTreeView()
        {

            CustomTreeView customNetworkTreeView = new CustomTreeView();
            customNetworkTreeView.TreeViewElement.Scroller.ScrollMode = ItemScrollerScrollModes.Smooth;
            customNetworkTreeView.TreeViewElement.BackColor = Color.FromArgb(233, 240, 249);
            //customNetworkTreeView.TreeViewElement.ItemHeight = 200;
            customNetworkTreeView.TreeViewElement.AutoSize = true;
            customNetworkTreeView.TreeViewElement.AutoSizeMode = RadAutoSizeMode.FitToAvailableSize;
            customNetworkTreeView.AllowDragDrop = true;
            customNetworkTreeView.Enabled = true;
            customNetworkTreeView.EnableTheming = true;
            customNetworkTreeView.BackColor = Color.FromArgb(233, 240, 249);
            customNetworkTreeView.Cursor = Cursors.Default;
            customNetworkTreeView.Dock = DockStyle.Fill;
            //customNetworkTreeView.Dock = DockStyle.Top;
            customNetworkTreeView.Font = new Font("Segoe UI", 8.25F);
            customNetworkTreeView.ForeColor = Color.Black;
            customNetworkTreeView.ImageList = this.imageNetToolList;
            customNetworkTreeView.ItemHeight = 21;
            customNetworkTreeView.LineWidth = 129.7464F;
            customNetworkTreeView.Location = new Point(0, 0);
            customNetworkTreeView.Name = "radNetTreeView";
            TreeCreator tree = new TreeCreator();
           // customNetworkTreeView.Nodes.AddRange(tree.treeCreator());
            customNetworkTreeView.RightToLeft = RightToLeft.No;
            //customNetworkTreeView.Size = new System.Drawing.Size(153, 338);
            customNetworkTreeView.SpacingBetweenNodes = -1;
            customNetworkTreeView.TabIndex = 3;
            customNetworkTreeView.TreeIndent = 15;
            customNetworkTreeView.NodeMouseClick += CustomNetworkTreeView_NodeMouseClick;
            customNetworkTreeView.NodeMouseHover += CustomNetworkTreeView_NodeMouseHover;
            customNetworkTreeView.NodeMouseLeave += CustomNetworkTreeView_NodeMouseLeave;
            customNetworkTreeView.NodeMouseDoubleClick += CustomNetworkTreeView_NodeMouseDoubleClick;
            this.toolNetworkWindow.Controls.Add(customNetworkTreeView);
            this.toolNetworkWindow.Controls[1].BringToFront();
        }

        private int clicks = 0;
        private void CustomNetworkTreeView_NodeMouseDoubleClick(object sender, RadTreeViewEventArgs e)
        {
            if (e.Node.Level > 0)
            {
                clicks += 1;
                ToolDiagram_Form.setIsLockedCreation(clicks == 1 ? false : true);
                if (!ToolDiagram_Form.getIsLockedCreation())
                {
                    clicks = 0;
                    MainMenu.setIsTreeDoubleClicked(true);
                    var selection = e.Node.Text;
                    ToolDiagram_Form.setIsLockedCreation(true);
                    setClickedShape(UtilitiesShape.shapeToolDiagram_selector(selection));
                }
            }
        }

        //CustomNetworkTreeView_NodeMouseLeave() removes the background color of the node when the mouse leave it.
        private void CustomNetworkTreeView_NodeMouseLeave(object sender, RadTreeViewEventArgs e)
        {
            e.Node.BackColor = Color.Transparent;
            e.Node.GradientStyle = GradientStyles.Solid;
            picturePreviewBox.Image = imagePreviewList.Images[0];
        }

        //CustomNetworkTreeView_NodeMouseHover() colors the background of the node when hovering on it, an shows its
        //graphical representation on the preview area.
        private void CustomNetworkTreeView_NodeMouseHover(object sender, RadTreeViewEventArgs e)
        {
            var selection = e.Node.Text;
            if (selection != null)
            {
                e.Node.BackColor = Color.FromArgb(255, 212, 120);
                e.Node.GradientStyle = GradientStyles.Linear;
            }
            switch (selection)
            {
                case "Bus":
                    picturePreviewBox.Image = imagePreviewList.Images[1];
                    break;
                case "Generator":
                    picturePreviewBox.Image = imagePreviewList.Images[2];
                    break;
                case "Load":
                    picturePreviewBox.Image = imagePreviewList.Images[3];
                    break;
                case "Switch":
                    picturePreviewBox.Image = imagePreviewList.Images[4];
                    break;
                case "Triphasic":
                    picturePreviewBox.Image = imagePreviewList.Images[5];
                    break;
                case "YgDD":
                    picturePreviewBox.Image = imagePreviewList.Images[6];
                    break;
                case "YgYgD":
                    picturePreviewBox.Image = imagePreviewList.Images[7];
                    break;
                case "Custom":
                    picturePreviewBox.Image = imagePreviewList.Images[8];
                    break;
                case "Three-Phase":
                    picturePreviewBox.Image = imagePreviewList.Images[9];
                    break;
                case "Double circuit":
                    picturePreviewBox.Image = imagePreviewList.Images[10];
                    break;
                case "M-Phase":
                    picturePreviewBox.Image = imagePreviewList.Images[11];
                    break;
                case "C":
                    picturePreviewBox.Image = imagePreviewList.Images[12];
                    break;
                case "L":
                    picturePreviewBox.Image = imagePreviewList.Images[13];
                    break;
                case "R":
                    picturePreviewBox.Image = imagePreviewList.Images[14];
                    break;
                case "LC":
                    picturePreviewBox.Image = imagePreviewList.Images[15];
                    break;
                case "RL":
                    picturePreviewBox.Image = imagePreviewList.Images[16];
                    break;
                case "RLC":
                    picturePreviewBox.Image = imagePreviewList.Images[17];
                    break;
                default:
                    picturePreviewBox.Image = imagePreviewList.Images[0];
                    break;
            }
        }

        //CustomNetworkTreeView_NodeMouseClick() creates a instance of a shape once a node is clicked
        private void CustomNetworkTreeView_NodeMouseClick(object sender, RadTreeViewEventArgs e)
        {
            if (!ToolDiagram_Form.getIsLockedCreation())
            {
                if (e.Node.Selected)
                {
                    e.Node.BackColor = Color.FromArgb(255, 183, 92);
                    e.Node.GradientStyle = GradientStyles.Linear;
                    if (e.Node.Level > 0)
                    {
                        ToolDiagram_Form.setIsLockedCreation(true);
                    }
                }
                var selection = e.Node.Text;
                setClickedShape(UtilitiesShape.shapeToolDiagram_selector(selection));
            }
        }

        //radGridBitton_Click() is a event that set the background grid to visible or white 
        private void radGridButton_Click(object sender, EventArgs e)
        {
            bool isGridActive = MainMenu.getDiagram().IsBackgroundSurfaceVisible;
            if (isGridActive)
            {
                MainMenu.getDiagram().IsBackgroundSurfaceVisible = false;
                this.radGridButton.Image = Properties.Resources.inGrid;
            }
            else
            {
                MainMenu.getDiagram().IsBackgroundSurfaceVisible = true;
                this.radGridButton.Image = Properties.Resources.viGrid;
            }

        }

        //ToolDiagram_Form_Load() set properties of some controls when the form is loaded
        private void ToolDiagram_Form_Load(object sender, EventArgs e)
        {
            this.picturePreviewBox.Image = imagePreviewList.Images[0];
        }

        //radGridColorBox_ValueChanged() and radBackColorBox_ValueChanged() triggers a dialogbox to customize grid 
        //and diagram's background color.
        private void radGridColorBox_ValueChanged(object sender, EventArgs e)
        {
            MainMenu.getDiagram().DiagramElement.BackgroundGrid.LineStroke = new SolidBrush(this.radGridColorBox.Value);
        }

        private void radBackColorBox_ValueChanged(object sender, EventArgs e)
        {

            MainMenu.getDiagram().BackColor = this.radBackColorBox.Value;
        }

        //radConnectionypeDropDownList_SelectedIndexChanged() defines how connections will interact among them.
        private void radConnectionypeDropDownList_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            var selection = e.Position;
            switch (selection)
            {
                case 0:
                    MainMenu.getDiagram().ConnectionBridge = BridgeType.None;
                    break;
                case 1:
                    MainMenu.getDiagram().ConnectionBridge = BridgeType.Bow;
                    break;
                case 2:
                    MainMenu.getDiagram().ConnectionBridge = BridgeType.Gap;
                    break;
                default:
                    MainMenu.getDiagram().ConnectionBridge = BridgeType.None;
                    break;
            }
        }

        internal static void setClickedShape(string shape)
        {
            clickedShaped = shape;
        }

        internal static string getClickedShape()
        {
            return clickedShaped;
        }

        private void documentTabStrip1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //When it change, we can set the static currentCase using this event
            //CustomDocumentWindow.setCurrentCase(caseBL.loadAll()[this.documentTabStrip1.TabStripElement.Items.IndexOf(this.documentTabStrip1.ActiveWindow.TabStripItem)]);
            //MessageBox.Show("" + CustomDocumentWindow.getCurrentCase().code);
            // MessageBox.Show(this.documentTabStrip1.TabStripElement.Items.IndexOf(this.documentTabStrip1.ActiveWindow.TabStripItem).ToString());
        }

        //ToolDiagram_Form_FormClosing()is trigger when the caseWindows is closed or the program is closed,
        //and the caseWindow is still active.
        private void ToolDiagram_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            List<string> message = new List<string> { "Are you sure that you would like to close the project?",
                                                      "Do you want to save the current case?" };
            List<string> caption = new List<string> { "Cases Closing", "Case Saving" };

            var resultClose = MessageBox.Show(message[0], caption[0],
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);

            if (resultClose == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                MainMenu.setIsNew(false);
                var resultSave = MessageBox.Show(message[1], caption[1],
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);
                if (resultSave == DialogResult.Yes)
                {
                    MessageBox.Show("the case was saved");
                    //add code to save case
                }
                CustomContentControl.setCurrentCase(null);

                caseBL.removeAllCase();
            }

        }

        internal static void setIsLockedCreation(bool isLocked)
        {
            ToolDiagram_Form.isLockedCreation = isLocked;
        }

        internal static bool getIsLockedCreation()
        {
            return ToolDiagram_Form.isLockedCreation;
        }

    }
}