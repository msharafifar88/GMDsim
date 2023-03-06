/*using Telerik.WinControls.UI;

namespace GUI
{
    partial class MainMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenu));
            this.radContextMenuManager1 = new Telerik.WinControls.UI.RadContextMenuManager();
            this.radTextBoxElement1 = new Telerik.WinControls.UI.RadTextBoxElement();
            this.radRibbonBarGroup1 = new Telerik.WinControls.UI.RadRibbonBarGroup();
            this.ribbonTab1 = new Telerik.WinControls.UI.RibbonTab();
            this.radRibbonBarGroup2 = new Telerik.WinControls.UI.RadRibbonBarGroup();
            this.radNewButton = new Telerik.WinControls.UI.RadButtonElement();
            this.radOpenButton = new Telerik.WinControls.UI.RadButtonElement();
            this.radSaveButton = new Telerik.WinControls.UI.RadButtonElement();
            this.radRibbonBarGroup7 = new Telerik.WinControls.UI.RadRibbonBarGroup();
            this.radUndoRedoRibbonBarButtonGroup = new Telerik.WinControls.UI.RadRibbonBarButtonGroup();
            this.radUndoButton = new Telerik.WinControls.UI.RadButtonElement();
            this.radRedoButton = new Telerik.WinControls.UI.RadButtonElement();
            this.radSelectAllButton = new Telerik.WinControls.UI.RadButtonElement();
            this.radRibbonBar1 = new Telerik.WinControls.UI.RadRibbonBar();
            this.ribbonTab2 = new Telerik.WinControls.UI.RibbonTab();
            this.radRibbonBarGroup3 = new Telerik.WinControls.UI.RadRibbonBarGroup();
            this.radDBButton = new Telerik.WinControls.UI.RadButtonElement();
            this.radButtonElement1 = new Telerik.WinControls.UI.RadButtonElement();
            this.radButtonElement6 = new Telerik.WinControls.UI.RadButtonElement();
            this.radRibbonBarButtonGroup1 = new Telerik.WinControls.UI.RadRibbonBarButtonGroup();
            this.radButtonElement7 = new Telerik.WinControls.UI.RadButtonElement();
            this.ribbonTab3 = new Telerik.WinControls.UI.RibbonTab();
            this.radRibbonBarGroupTools = new Telerik.WinControls.UI.RadRibbonBarGroup();
            this.radBusesButton = new Telerik.WinControls.UI.RadButtonElement();
            this.radToolsRibbonBarButtonGroup = new Telerik.WinControls.UI.RadRibbonBarButtonGroup();
            this.radPointerButton = new Telerik.WinControls.UI.RadButtonElement();
            this.radPanButton = new Telerik.WinControls.UI.RadButtonElement();
            this.radConnectorButton = new Telerik.WinControls.UI.RadButtonElement();
            this.radTextDrawRibbonBarButtonGroup = new Telerik.WinControls.UI.RadRibbonBarButtonGroup();
            this.radTextButton = new Telerik.WinControls.UI.RadButtonElement();
            this.radPolygonButton = new Telerik.WinControls.UI.RadButtonElement();
            this.radRibbonBarGroup4 = new Telerik.WinControls.UI.RadRibbonBarGroup();
            this.radSelectionRibbonBarButtonGroup = new Telerik.WinControls.UI.RadRibbonBarButtonGroup();
            this.radSingleButton = new Telerik.WinControls.UI.RadButtonElement();
            this.radMultipleButton = new Telerik.WinControls.UI.RadButtonElement();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.radButtonElement2 = new Telerik.WinControls.UI.RadButtonElement();
            this.radButtonElement3 = new Telerik.WinControls.UI.RadButtonElement();
            this.radButtonElement4 = new Telerik.WinControls.UI.RadButtonElement();
            this.radButtonElement5 = new Telerik.WinControls.UI.RadButtonElement();
            this.radRibbonBarButtonGroup2 = new Telerik.WinControls.UI.RadRibbonBarButtonGroup();
            this.radRibbonBarButtonGroup3 = new Telerik.WinControls.UI.RadRibbonBarButtonGroup();
            this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
            this.radThreePhaseBusButton = new Telerik.WinControls.UI.RadButton();
            this.radPhaseAButton = new Telerik.WinControls.UI.RadButton();
            this.radPhaseBButton = new Telerik.WinControls.UI.RadButton();
            this.radPhaseCButton = new Telerik.WinControls.UI.RadButton();
            this.radGeneralSignalButton = new Telerik.WinControls.UI.RadButton();
            this.radDiagonalSignalButton = new Telerik.WinControls.UI.RadButton();
            this.radBundleButton = new Telerik.WinControls.UI.RadButton();
            this.NetworkOptions = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.radRibbonBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radThreePhaseBusButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPhaseAButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPhaseBButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPhaseCButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGeneralSignalButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radDiagonalSignalButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radBundleButton)).BeginInit();
            this.NetworkOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radTextBoxElement1
            // 
            this.radTextBoxElement1.MinSize = new System.Drawing.Size(140, 0);
            this.radTextBoxElement1.Name = "radTextBoxElement1";
            this.radTextBoxElement1.Padding = new System.Windows.Forms.Padding(0, 2, 0, 1);
            this.radTextBoxElement1.Text = "New";
            this.radTextBoxElement1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.radTextBoxElement1.UseCompatibleTextRendering = false;
            // 
            // radRibbonBarGroup1
            // 
            this.radRibbonBarGroup1.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.radTextBoxElement1});
            this.radRibbonBarGroup1.Margin = new System.Windows.Forms.Padding(0);
            this.radRibbonBarGroup1.MaxSize = new System.Drawing.Size(0, 0);
            this.radRibbonBarGroup1.MinSize = new System.Drawing.Size(0, 0);
            this.radRibbonBarGroup1.Name = "radRibbonBarGroup1";
            this.radRibbonBarGroup1.Text = "General";
            this.radRibbonBarGroup1.UseCompatibleTextRendering = false;
            // 
            // ribbonTab1
            // 
            this.ribbonTab1.AutoEllipsis = false;
            this.ribbonTab1.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.ribbonTab1.IsSelected = true;
            this.ribbonTab1.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.radRibbonBarGroup2,
            this.radRibbonBarGroup7});
            this.ribbonTab1.Name = "ribbonTab1";
            this.ribbonTab1.Text = "Home";
            this.ribbonTab1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.ribbonTab1.UseCompatibleTextRendering = false;
            this.ribbonTab1.UseMnemonic = false;
            // 
            // radRibbonBarGroup2
            // 
            this.radRibbonBarGroup2.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.radNewButton,
            this.radOpenButton,
            this.radSaveButton});
            this.radRibbonBarGroup2.Name = "radRibbonBarGroup2";
            this.radRibbonBarGroup2.Text = "General";
            // 
            // radNewButton
            // 
            this.radNewButton.AccessibleDescription = "radNewButton";
            this.radNewButton.AccessibleName = "radNewButton";
            this.radNewButton.Image = ((System.Drawing.Image)(resources.GetObject("radNewButton.Image")));
            this.radNewButton.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.radNewButton.Name = "radNewButton";
            this.radNewButton.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.radNewButton.Text = "New";
            this.radNewButton.TextAlignment = System.Drawing.ContentAlignment.BottomCenter;
            this.radNewButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.radNewButton.Click += new System.EventHandler(this.radNewButton_Click);
            // 
            // radOpenButton
            // 
            this.radOpenButton.AccessibleDescription = "radOpenButton";
            this.radOpenButton.AccessibleName = "radOpenButton";
            this.radOpenButton.Image = ((System.Drawing.Image)(resources.GetObject("radOpenButton.Image")));
            this.radOpenButton.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.radOpenButton.Name = "radOpenButton";
            this.radOpenButton.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.radOpenButton.Text = "Open";
            this.radOpenButton.TextAlignment = System.Drawing.ContentAlignment.BottomCenter;
            this.radOpenButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.radOpenButton.Click += new System.EventHandler(this.radOpenButton_Click_1);
            // 
            // radSaveButton
            // 
            this.radSaveButton.AccessibleDescription = "radSaveButton";
            this.radSaveButton.AccessibleName = "radSaveButton";
            this.radSaveButton.Image = ((System.Drawing.Image)(resources.GetObject("radSaveButton.Image")));
            this.radSaveButton.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.radSaveButton.Name = "radSaveButton";
            this.radSaveButton.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.radSaveButton.Text = "Save";
            this.radSaveButton.TextAlignment = System.Drawing.ContentAlignment.BottomCenter;
            this.radSaveButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.radSaveButton.Click += new System.EventHandler(this.radSaveButton_Click);
            // 
            // radRibbonBarGroup7
            // 
            this.radRibbonBarGroup7.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.radUndoRedoRibbonBarButtonGroup,
            this.radSelectAllButton});
            this.radRibbonBarGroup7.Name = "radRibbonBarGroup7";
            this.radRibbonBarGroup7.Text = "Edit";
            // 
            // radUndoRedoRibbonBarButtonGroup
            // 
            this.radUndoRedoRibbonBarButtonGroup.AccessibleDescription = "radUndoRedoRibbonBarButtonGroup";
            this.radUndoRedoRibbonBarButtonGroup.AccessibleName = "radUndoRedoRibbonBarButtonGroup";
            this.radUndoRedoRibbonBarButtonGroup.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.radUndoButton,
            this.radRedoButton});
            this.radUndoRedoRibbonBarButtonGroup.Name = "radUndoRedoRibbonBarButtonGroup";
            this.radUndoRedoRibbonBarButtonGroup.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.radUndoRedoRibbonBarButtonGroup.Padding = new System.Windows.Forms.Padding(1, 5, 1, 1);
            this.radUndoRedoRibbonBarButtonGroup.ShowBorder = false;
            // 
            // radUndoButton
            // 
            this.radUndoButton.AccessibleDescription = "radUndoButton";
            this.radUndoButton.AccessibleName = "radUndoButton";
            this.radUndoButton.BackColor = System.Drawing.Color.Transparent;
            this.radUndoButton.Image = ((System.Drawing.Image)(resources.GetObject("radUndoButton.Image")));
            this.radUndoButton.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.radUndoButton.Name = "radUndoButton";
            this.radUndoButton.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.radUndoButton.ShowBorder = false;
            this.radUndoButton.Text = "Undo";
            this.radUndoButton.TextAlignment = System.Drawing.ContentAlignment.BottomCenter;
            this.radUndoButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            
            // 
            // radRedoButton
            // 
            this.radRedoButton.AccessibleDescription = "radRedoButton";
            this.radRedoButton.AccessibleName = "radRedoButton";
            this.radRedoButton.Image = ((System.Drawing.Image)(resources.GetObject("radRedoButton.Image")));
            this.radRedoButton.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.radRedoButton.Name = "radRedoButton";
            this.radRedoButton.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.radRedoButton.ShowBorder = false;
            this.radRedoButton.Text = "Redo";
            this.radRedoButton.TextAlignment = System.Drawing.ContentAlignment.BottomCenter;
            this.radRedoButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            
            // 
            // radSelectAllButton
            // 
            this.radSelectAllButton.AccessibleDescription = "radSelectAllButton";
            this.radSelectAllButton.AccessibleName = "radSelectAllButton";
            this.radSelectAllButton.Image = ((System.Drawing.Image)(resources.GetObject("radSelectAllButton.Image")));
            this.radSelectAllButton.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.radSelectAllButton.Name = "radSelectAllButton";
            this.radSelectAllButton.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.radSelectAllButton.Text = "Select all";
            this.radSelectAllButton.TextAlignment = System.Drawing.ContentAlignment.BottomCenter;
            this.radSelectAllButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
          
            // 
            // radRibbonBar1
            // 
            this.radRibbonBar1.CommandTabs.AddRange(new Telerik.WinControls.RadItem[] {
            this.ribbonTab1,
            this.ribbonTab2,
            this.ribbonTab3});
            // 
            // 
            // 
            this.radRibbonBar1.ExitButton.Text = "Exit";
            this.radRibbonBar1.LocalizationSettings.LayoutModeText = "Simplified Layout";
            this.radRibbonBar1.Location = new System.Drawing.Point(0, 0);
            this.radRibbonBar1.Name = "radRibbonBar1";
            // 
            // 
            // 
            this.radRibbonBar1.OptionsButton.Text = "Options";
            this.radRibbonBar1.Size = new System.Drawing.Size(1315, 173);
            this.radRibbonBar1.TabIndex = 0;
            this.radRibbonBar1.Text = "GSIM";
            // 
            // ribbonTab2
            // 
            this.ribbonTab2.IsSelected = false;
            this.ribbonTab2.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.radRibbonBarGroup3});
            this.ribbonTab2.Name = "ribbonTab2";
            this.ribbonTab2.Text = "Case Information";
            this.ribbonTab2.UseMnemonic = false;
            // 
            // radRibbonBarGroup3
            // 
            this.radRibbonBarGroup3.AutoSize = false;
            this.radRibbonBarGroup3.Bounds = new System.Drawing.Rectangle(0, 0, 448, 98);
            this.radRibbonBarGroup3.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.radDBButton,
            this.radButtonElement1,
            this.radButtonElement6,
            this.radRibbonBarButtonGroup1,
            this.radButtonElement7});
            this.radRibbonBarGroup3.Name = "radRibbonBarGroup3";
            this.radRibbonBarGroup3.Text = "Case Information";
            // 
            // radDBButton
            // 
            this.radDBButton.AccessibleDescription = "radDBButton";
            this.radDBButton.AccessibleName = "radDBButton";
            this.radDBButton.Image = global::GUI.Properties.Resources.dbMenu_button;
            this.radDBButton.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.radDBButton.Name = "radDBButton";
            this.radDBButton.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.radDBButton.Text = "Model";
            this.radDBButton.TextAlignment = System.Drawing.ContentAlignment.BottomCenter;
            this.radDBButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.radDBButton.Click += new System.EventHandler(this.radDBButton_Click);
            // 
            // radButtonElement1
            // 
            this.radButtonElement1.Name = "radButtonElement1";
            this.radButtonElement1.Text = "radButtonElement1";
            this.radButtonElement1.Click += new System.EventHandler(this.radButtonElement1_Click);
            // 
            // radButtonElement6
            // 
            this.radButtonElement6.Name = "radButtonElement6";
            this.radButtonElement6.Text = "radButtonElement6";
            this.radButtonElement6.UseCompatibleTextRendering = false;
            // 
            // radRibbonBarButtonGroup1
            // 
            this.radRibbonBarButtonGroup1.Name = "radRibbonBarButtonGroup1";
            this.radRibbonBarButtonGroup1.Text = "radRibbonBarButtonGroup1";
            this.radRibbonBarButtonGroup1.UseCompatibleTextRendering = false;
            // 
            // radButtonElement7
            // 
            this.radButtonElement7.Name = "radButtonElement7";
            this.radButtonElement7.Text = "radButtonElement7";
            this.radButtonElement7.Click += new System.EventHandler(this.radButtonElement7_Click);
            // 
            // ribbonTab3
            // 
            this.ribbonTab3.Description = "Draw Network";
            this.ribbonTab3.IsSelected = false;
            this.ribbonTab3.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.radRibbonBarGroupTools,
            this.radRibbonBarGroup4});
            this.ribbonTab3.Name = "ribbonTab3";
            this.ribbonTab3.Text = "Draw Network";
            this.ribbonTab3.TextWrap = false;
            this.ribbonTab3.Title = "Draw Network";
            this.ribbonTab3.UseMnemonic = false;
            // 
            // radRibbonBarGroupTools
            // 
            this.radRibbonBarGroupTools.AccessibleDescription = "radRibbonBarGroupTools";
            this.radRibbonBarGroupTools.AccessibleName = "radRibbonBarGroupTools";
            this.radRibbonBarGroupTools.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.radBusesButton,
            this.radToolsRibbonBarButtonGroup,
            this.radTextDrawRibbonBarButtonGroup});
            this.radRibbonBarGroupTools.Name = "radRibbonBarGroupTools";
            this.radRibbonBarGroupTools.Text = "Tools";
            // 
            // radBusesButton
            // 
            this.radBusesButton.AccessibleDescription = "radBusesButton";
            this.radBusesButton.AccessibleName = "radBusesButton";
            this.radBusesButton.Image = global::GUI.Properties.Resources.busesMenu_button;
            this.radBusesButton.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.radBusesButton.Name = "radBusesButton";
            this.radBusesButton.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.radBusesButton.Text = "Buses";
            this.radBusesButton.TextAlignment = System.Drawing.ContentAlignment.BottomCenter;
            this.radBusesButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.radBusesButton.Click += new System.EventHandler(this.radBusesButton_Click);
            // 
            // radToolsRibbonBarButtonGroup
            // 
            this.radToolsRibbonBarButtonGroup.AccessibleDescription = "radToolsRibbonBarButtonGroup";
            this.radToolsRibbonBarButtonGroup.AccessibleName = "radToolsRibbonBarButtonGroup";
            this.radToolsRibbonBarButtonGroup.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.radPointerButton,
            this.radPanButton,
            this.radConnectorButton});
            this.radToolsRibbonBarButtonGroup.Name = "radToolsRibbonBarButtonGroup";
            this.radToolsRibbonBarButtonGroup.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.radToolsRibbonBarButtonGroup.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.radToolsRibbonBarButtonGroup.ShowBorder = false;
            // 
            // radPointerButton
            // 
            this.radPointerButton.AccessibleDescription = "radPointerButton";
            this.radPointerButton.AccessibleName = "radPointerButton";
            this.radPointerButton.Image = global::GUI.Properties.Resources.pointer_button1;
            this.radPointerButton.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.radPointerButton.Name = "radPointerButton";
            this.radPointerButton.ShowBorder = false;
            this.radPointerButton.Tag = "Pointer";
            this.radPointerButton.Text = "Pointer";
            this.radPointerButton.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.radPointerButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            // 
            // radPanButton
            // 
            this.radPanButton.AccessibleDescription = "radPanButton";
            this.radPanButton.AccessibleName = "radPanButton";
            this.radPanButton.Image = global::GUI.Properties.Resources.pan_button;
            this.radPanButton.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.radPanButton.Name = "radPanButton";
            this.radPanButton.ShowBorder = false;
            this.radPanButton.Tag = "Pan";
            this.radPanButton.Text = "Pan";
            this.radPanButton.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.radPanButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            // 
            // radConnectorButton
            // 
            this.radConnectorButton.AccessibleDescription = "radConnectorButton";
            this.radConnectorButton.AccessibleName = "radConnectorButton";
            this.radConnectorButton.Image = global::GUI.Properties.Resources.connector_button1;
            this.radConnectorButton.Name = "radConnectorButton";
            this.radConnectorButton.ShowBorder = false;
            this.radConnectorButton.Tag = "Connector";
            this.radConnectorButton.Text = "Connector";
            this.radConnectorButton.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.radConnectorButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            // 
            // radTextDrawRibbonBarButtonGroup
            // 
            this.radTextDrawRibbonBarButtonGroup.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.radTextButton,
            this.radPolygonButton});
            this.radTextDrawRibbonBarButtonGroup.Name = "radTextDrawRibbonBarButtonGroup";
            this.radTextDrawRibbonBarButtonGroup.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.radTextDrawRibbonBarButtonGroup.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.radTextDrawRibbonBarButtonGroup.ShowBorder = false;
            this.radTextDrawRibbonBarButtonGroup.Text = "radTextDrawRibbonBarButtonGroup";
            // 
            // radTextButton
            // 
            this.radTextButton.AccessibleDescription = "radTextButton";
            this.radTextButton.AccessibleName = "radTextButton";
            this.radTextButton.Image = global::GUI.Properties.Resources.text_button;
            this.radTextButton.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.radTextButton.Name = "radTextButton";
            this.radTextButton.ShowBorder = false;
            this.radTextButton.Tag = "Text";
            this.radTextButton.Text = "Text";
            this.radTextButton.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.radTextButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            // 
            // radPolygonButton
            // 
            this.radPolygonButton.AccessibleDescription = "radPolygonButton";
            this.radPolygonButton.AccessibleName = "radPolygonButton";
            this.radPolygonButton.BackColor = System.Drawing.Color.Transparent;
            this.radPolygonButton.Image = global::GUI.Properties.Resources.poliTool;
            this.radPolygonButton.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.radPolygonButton.Name = "radPolygonButton";
            this.radPolygonButton.ShowBorder = false;
            this.radPolygonButton.Text = "Polygon";
            this.radPolygonButton.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.radPolygonButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.radPolygonButton.Click += new System.EventHandler(this.radPolygonButton_Click);
            // 
            // radRibbonBarGroup4
            // 
            this.radRibbonBarGroup4.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.radSelectionRibbonBarButtonGroup});
            this.radRibbonBarGroup4.Name = "radRibbonBarGroup4";
            this.radRibbonBarGroup4.Text = "Selection";
            // 
            // radSelectionRibbonBarButtonGroup
            // 
            this.radSelectionRibbonBarButtonGroup.AccessibleDescription = "radSelectionRibbonBarButtonGroup";
            this.radSelectionRibbonBarButtonGroup.AccessibleName = "radSelectionRibbonBarButtonGroup";
            this.radSelectionRibbonBarButtonGroup.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.radSingleButton,
            this.radMultipleButton});
            this.radSelectionRibbonBarButtonGroup.Name = "radSelectionRibbonBarButtonGroup";
            this.radSelectionRibbonBarButtonGroup.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.radSelectionRibbonBarButtonGroup.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.radSelectionRibbonBarButtonGroup.ShowBorder = false;
            // 
            // radSingleButton
            // 
            this.radSingleButton.AccessibleDescription = "radSingleButton";
            this.radSingleButton.AccessibleName = "radSingleButton";
            this.radSingleButton.Image = global::GUI.Properties.Resources.single_selection;
            this.radSingleButton.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.radSingleButton.Name = "radSingleButton";
            this.radSingleButton.ShowBorder = false;
            this.radSingleButton.Tag = "Single";
            this.radSingleButton.Text = "Single";
            this.radSingleButton.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.radSingleButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            // 
            // radMultipleButton
            // 
            this.radMultipleButton.AccessibleDescription = "radMultipleButton";
            this.radMultipleButton.AccessibleName = "radMultipleButton";
            this.radMultipleButton.Image = global::GUI.Properties.Resources.multiple_button1;
            this.radMultipleButton.Name = "radMultipleButton";
            this.radMultipleButton.ShowBorder = false;
            this.radMultipleButton.Tag = "Multiple";
            this.radMultipleButton.Text = "Multiple";
            this.radMultipleButton.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.radMultipleButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            // 
            // timer1
            // 
            this.timer1.Interval = 17;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // radButtonElement2
            // 
            this.radButtonElement2.Name = "radButtonElement2";
            this.radButtonElement2.Text = "radButtonElement1";
            this.radButtonElement2.UseCompatibleTextRendering = false;
            // 
            // radButtonElement3
            // 
            this.radButtonElement3.Name = "radButtonElement3";
            this.radButtonElement3.Text = "radButtonElement1";
            this.radButtonElement3.UseCompatibleTextRendering = false;
            // 
            // radButtonElement4
            // 
            this.radButtonElement4.Name = "radButtonElement4";
            this.radButtonElement4.Text = "radButtonElement1";
            this.radButtonElement4.UseCompatibleTextRendering = false;
            // 
            // radButtonElement5
            // 
            this.radButtonElement5.Name = "radButtonElement5";
            this.radButtonElement5.Text = "radButtonElement1";
            this.radButtonElement5.UseCompatibleTextRendering = false;
            // 
            // radRibbonBarButtonGroup2
            // 
            this.radRibbonBarButtonGroup2.Name = "radRibbonBarButtonGroup2";
            this.radRibbonBarButtonGroup2.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.radRibbonBarButtonGroup2.UseCompatibleTextRendering = false;
            // 
            // radRibbonBarButtonGroup3
            // 
            this.radRibbonBarButtonGroup3.Name = "radRibbonBarButtonGroup3";
            this.radRibbonBarButtonGroup3.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.radRibbonBarButtonGroup3.UseCompatibleTextRendering = false;
            // 
            // elementHost1
            // 
            this.elementHost1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.elementHost1.Location = new System.Drawing.Point(0, 173);
            this.elementHost1.Name = "elementHost1";
            this.elementHost1.Size = new System.Drawing.Size(1315, 610);
            this.elementHost1.TabIndex = 4;
            this.elementHost1.Text = "elementHost1";
            this.elementHost1.Child = null;
            // 
            // radThreePhaseBusButton
            // 
            this.radThreePhaseBusButton.AccessibleDescription = "radThreePhaseBusButton";
            this.radThreePhaseBusButton.AccessibleName = "radThreePhaseBusButton";
            this.radThreePhaseBusButton.Image = global::GUI.Properties.Resources.triphase;
            this.radThreePhaseBusButton.Location = new System.Drawing.Point(2, 48);
            this.radThreePhaseBusButton.Name = "radThreePhaseBusButton";
            this.radThreePhaseBusButton.Size = new System.Drawing.Size(105, 22);
            this.radThreePhaseBusButton.TabIndex = 0;
            this.radThreePhaseBusButton.Text = "3-Phase Bus";
            this.radThreePhaseBusButton.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.radThreePhaseBusButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.radThreePhaseBusButton.Click += new System.EventHandler(this.radThreePhaseBusButton_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.radThreePhaseBusButton.GetChildAt(0))).Image = global::GUI.Properties.Resources.triphase;
            ((Telerik.WinControls.UI.RadButtonElement)(this.radThreePhaseBusButton.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.radThreePhaseBusButton.GetChildAt(0))).TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            ((Telerik.WinControls.UI.RadButtonElement)(this.radThreePhaseBusButton.GetChildAt(0))).Text = "3-Phase Bus";
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.radThreePhaseBusButton.GetChildAt(0).GetChildAt(0))).BackColor2 = System.Drawing.Color.Transparent;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.radThreePhaseBusButton.GetChildAt(0).GetChildAt(0))).BackColor3 = System.Drawing.Color.Transparent;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.radThreePhaseBusButton.GetChildAt(0).GetChildAt(0))).BackColor4 = System.Drawing.Color.Transparent;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.radThreePhaseBusButton.GetChildAt(0).GetChildAt(0))).BackColor = System.Drawing.Color.Transparent;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.radThreePhaseBusButton.GetChildAt(0).GetChildAt(2))).BackColor = System.Drawing.Color.Transparent;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.radThreePhaseBusButton.GetChildAt(0).GetChildAt(2))).Visibility = Telerik.WinControls.ElementVisibility.Hidden;
            ((Telerik.WinControls.Primitives.FocusPrimitive)(this.radThreePhaseBusButton.GetChildAt(0).GetChildAt(3))).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(241)))), ((int)(((byte)(252)))));
            // 
            // radPhaseAButton
            // 
            this.radPhaseAButton.AccessibleDescription = "radPhaseAButton";
            this.radPhaseAButton.AccessibleName = "radPhaseAButton";
            this.radPhaseAButton.Image = global::GUI.Properties.Resources.phaseA;
            this.radPhaseAButton.Location = new System.Drawing.Point(2, 96);
            this.radPhaseAButton.Name = "radPhaseAButton";
            this.radPhaseAButton.Size = new System.Drawing.Size(105, 22);
            this.radPhaseAButton.TabIndex = 1;
            this.radPhaseAButton.Text = "Phase A";
            this.radPhaseAButton.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.radPhaseAButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.radPhaseAButton.Click += new System.EventHandler(this.radPhaseAButton_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.radPhaseAButton.GetChildAt(0))).Image = global::GUI.Properties.Resources.phaseA;
            ((Telerik.WinControls.UI.RadButtonElement)(this.radPhaseAButton.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.radPhaseAButton.GetChildAt(0))).TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            ((Telerik.WinControls.UI.RadButtonElement)(this.radPhaseAButton.GetChildAt(0))).Text = "Phase A";
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.radPhaseAButton.GetChildAt(0).GetChildAt(0))).BackColor2 = System.Drawing.Color.Transparent;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.radPhaseAButton.GetChildAt(0).GetChildAt(0))).BackColor3 = System.Drawing.Color.Transparent;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.radPhaseAButton.GetChildAt(0).GetChildAt(0))).BackColor4 = System.Drawing.Color.Transparent;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.radPhaseAButton.GetChildAt(0).GetChildAt(0))).BackColor = System.Drawing.Color.Transparent;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.radPhaseAButton.GetChildAt(0).GetChildAt(2))).BackColor = System.Drawing.Color.Transparent;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.radPhaseAButton.GetChildAt(0).GetChildAt(2))).Visibility = Telerik.WinControls.ElementVisibility.Hidden;
            // 
            // radPhaseBButton
            // 
            this.radPhaseBButton.AccessibleDescription = "radPhaseBButton";
            this.radPhaseBButton.AccessibleName = "radPhaseBButton";
            this.radPhaseBButton.Image = global::GUI.Properties.Resources.phaseB;
            this.radPhaseBButton.Location = new System.Drawing.Point(2, 119);
            this.radPhaseBButton.Name = "radPhaseBButton";
            this.radPhaseBButton.Size = new System.Drawing.Size(105, 22);
            this.radPhaseBButton.TabIndex = 2;
            this.radPhaseBButton.Text = "Phase B";
            this.radPhaseBButton.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.radPhaseBButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.radPhaseBButton.Click += new System.EventHandler(this.radPhaseBButton_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.radPhaseBButton.GetChildAt(0))).Image = global::GUI.Properties.Resources.phaseB;
            ((Telerik.WinControls.UI.RadButtonElement)(this.radPhaseBButton.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.radPhaseBButton.GetChildAt(0))).TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            ((Telerik.WinControls.UI.RadButtonElement)(this.radPhaseBButton.GetChildAt(0))).Text = "Phase B";
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.radPhaseBButton.GetChildAt(0).GetChildAt(0))).BackColor2 = System.Drawing.Color.Transparent;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.radPhaseBButton.GetChildAt(0).GetChildAt(0))).BackColor3 = System.Drawing.Color.Transparent;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.radPhaseBButton.GetChildAt(0).GetChildAt(0))).BackColor4 = System.Drawing.Color.Transparent;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.radPhaseBButton.GetChildAt(0).GetChildAt(0))).BackColor = System.Drawing.Color.Transparent;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.radPhaseBButton.GetChildAt(0).GetChildAt(2))).BackColor = System.Drawing.Color.Transparent;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.radPhaseBButton.GetChildAt(0).GetChildAt(2))).Visibility = Telerik.WinControls.ElementVisibility.Hidden;
            // 
            // radPhaseCButton
            // 
            this.radPhaseCButton.AccessibleDescription = "radPhaseCButton";
            this.radPhaseCButton.AccessibleName = "radPhaseCButton";
            this.radPhaseCButton.Image = global::GUI.Properties.Resources.phaseC;
            this.radPhaseCButton.Location = new System.Drawing.Point(2, 143);
            this.radPhaseCButton.Name = "radPhaseCButton";
            this.radPhaseCButton.Size = new System.Drawing.Size(105, 22);
            this.radPhaseCButton.TabIndex = 3;
            this.radPhaseCButton.Text = "Phase C";
            this.radPhaseCButton.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.radPhaseCButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.radPhaseCButton.Click += new System.EventHandler(this.radPhaseCButton_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.radPhaseCButton.GetChildAt(0))).Image = global::GUI.Properties.Resources.phaseC;
            ((Telerik.WinControls.UI.RadButtonElement)(this.radPhaseCButton.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.radPhaseCButton.GetChildAt(0))).TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            ((Telerik.WinControls.UI.RadButtonElement)(this.radPhaseCButton.GetChildAt(0))).Text = "Phase C";
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.radPhaseCButton.GetChildAt(0).GetChildAt(0))).BackColor2 = System.Drawing.Color.Transparent;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.radPhaseCButton.GetChildAt(0).GetChildAt(0))).BackColor3 = System.Drawing.Color.Transparent;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.radPhaseCButton.GetChildAt(0).GetChildAt(0))).BackColor4 = System.Drawing.Color.Transparent;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.radPhaseCButton.GetChildAt(0).GetChildAt(0))).BackColor = System.Drawing.Color.Transparent;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.radPhaseCButton.GetChildAt(0).GetChildAt(2))).BackColor = System.Drawing.Color.Transparent;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.radPhaseCButton.GetChildAt(0).GetChildAt(2))).Visibility = Telerik.WinControls.ElementVisibility.Hidden;
            // 
            // radGeneralSignalButton
            // 
            this.radGeneralSignalButton.AccessibleDescription = "radGeneralSignalButton";
            this.radGeneralSignalButton.AccessibleName = "radGeneralSignalButton";
            this.radGeneralSignalButton.Image = global::GUI.Properties.Resources.general;
            this.radGeneralSignalButton.Location = new System.Drawing.Point(2, 2);
            this.radGeneralSignalButton.Name = "radGeneralSignalButton";
            this.radGeneralSignalButton.Size = new System.Drawing.Size(105, 22);
            this.radGeneralSignalButton.TabIndex = 4;
            this.radGeneralSignalButton.Text = "General Signal";
            this.radGeneralSignalButton.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.radGeneralSignalButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.radGeneralSignalButton.Click += new System.EventHandler(this.radGeneralSignalButton_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.radGeneralSignalButton.GetChildAt(0))).Image = global::GUI.Properties.Resources.general;
            ((Telerik.WinControls.UI.RadButtonElement)(this.radGeneralSignalButton.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.radGeneralSignalButton.GetChildAt(0))).TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            ((Telerik.WinControls.UI.RadButtonElement)(this.radGeneralSignalButton.GetChildAt(0))).Text = "General Signal";
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.radGeneralSignalButton.GetChildAt(0).GetChildAt(0))).BackColor2 = System.Drawing.Color.Transparent;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.radGeneralSignalButton.GetChildAt(0).GetChildAt(0))).BackColor3 = System.Drawing.Color.Transparent;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.radGeneralSignalButton.GetChildAt(0).GetChildAt(0))).BackColor4 = System.Drawing.Color.Transparent;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.radGeneralSignalButton.GetChildAt(0).GetChildAt(0))).BackColor = System.Drawing.Color.Transparent;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.radGeneralSignalButton.GetChildAt(0).GetChildAt(2))).BackColor = System.Drawing.Color.Transparent;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.radGeneralSignalButton.GetChildAt(0).GetChildAt(2))).Visibility = Telerik.WinControls.ElementVisibility.Hidden;
            // 
            // radDiagonalSignalButton
            // 
            this.radDiagonalSignalButton.AccessibleDescription = "radDiagonalSignalButton";
            this.radDiagonalSignalButton.AccessibleName = "radDiagonalSignalButton";
            this.radDiagonalSignalButton.Image = global::GUI.Properties.Resources.diagonal;
            this.radDiagonalSignalButton.Location = new System.Drawing.Point(3, 25);
            this.radDiagonalSignalButton.Name = "radDiagonalSignalButton";
            this.radDiagonalSignalButton.Size = new System.Drawing.Size(105, 22);
            this.radDiagonalSignalButton.TabIndex = 5;
            this.radDiagonalSignalButton.Text = "Diagonal Signal";
            this.radDiagonalSignalButton.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.radDiagonalSignalButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.radDiagonalSignalButton.Click += new System.EventHandler(this.radDiagonalSignalButton_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.radDiagonalSignalButton.GetChildAt(0))).Image = global::GUI.Properties.Resources.diagonal;
            ((Telerik.WinControls.UI.RadButtonElement)(this.radDiagonalSignalButton.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.radDiagonalSignalButton.GetChildAt(0))).TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            ((Telerik.WinControls.UI.RadButtonElement)(this.radDiagonalSignalButton.GetChildAt(0))).Text = "Diagonal Signal";
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.radDiagonalSignalButton.GetChildAt(0).GetChildAt(0))).BackColor2 = System.Drawing.Color.Transparent;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.radDiagonalSignalButton.GetChildAt(0).GetChildAt(0))).BackColor3 = System.Drawing.Color.Transparent;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.radDiagonalSignalButton.GetChildAt(0).GetChildAt(0))).BackColor4 = System.Drawing.Color.Transparent;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.radDiagonalSignalButton.GetChildAt(0).GetChildAt(0))).BackColor = System.Drawing.Color.Transparent;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.radDiagonalSignalButton.GetChildAt(0).GetChildAt(2))).BackColor = System.Drawing.Color.Transparent;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.radDiagonalSignalButton.GetChildAt(0).GetChildAt(2))).Visibility = Telerik.WinControls.ElementVisibility.Hidden;
            // 
            // radBundleButton
            // 
            this.radBundleButton.AccessibleDescription = "radBundleButton";
            this.radBundleButton.AccessibleName = "radBundleButton";
            this.radBundleButton.Image = global::GUI.Properties.Resources.bundle;
            this.radBundleButton.Location = new System.Drawing.Point(2, 72);
            this.radBundleButton.Name = "radBundleButton";
            this.radBundleButton.Size = new System.Drawing.Size(105, 22);
            this.radBundleButton.TabIndex = 6;
            this.radBundleButton.Text = "Bundle";
            this.radBundleButton.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.radBundleButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.radBundleButton.Click += new System.EventHandler(this.radBundleButton_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.radBundleButton.GetChildAt(0))).Image = global::GUI.Properties.Resources.bundle;
            ((Telerik.WinControls.UI.RadButtonElement)(this.radBundleButton.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.radBundleButton.GetChildAt(0))).TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            ((Telerik.WinControls.UI.RadButtonElement)(this.radBundleButton.GetChildAt(0))).Text = "Bundle";
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.radBundleButton.GetChildAt(0).GetChildAt(0))).BackColor2 = System.Drawing.Color.Transparent;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.radBundleButton.GetChildAt(0).GetChildAt(0))).BackColor3 = System.Drawing.Color.Transparent;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.radBundleButton.GetChildAt(0).GetChildAt(0))).BackColor4 = System.Drawing.Color.Transparent;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.radBundleButton.GetChildAt(0).GetChildAt(0))).BackColor = System.Drawing.Color.Transparent;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.radBundleButton.GetChildAt(0).GetChildAt(2))).BackColor = System.Drawing.Color.Transparent;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.radBundleButton.GetChildAt(0).GetChildAt(2))).Visibility = Telerik.WinControls.ElementVisibility.Hidden;
            // 
            // NetworkOptions
            // 
            this.NetworkOptions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(241)))), ((int)(((byte)(252)))));
            this.NetworkOptions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NetworkOptions.Controls.Add(this.radBundleButton);
            this.NetworkOptions.Controls.Add(this.radDiagonalSignalButton);
            this.NetworkOptions.Controls.Add(this.radGeneralSignalButton);
            this.NetworkOptions.Controls.Add(this.radPhaseCButton);
            this.NetworkOptions.Controls.Add(this.radPhaseBButton);
            this.NetworkOptions.Controls.Add(this.radPhaseAButton);
            this.NetworkOptions.Controls.Add(this.radThreePhaseBusButton);
            this.NetworkOptions.Location = new System.Drawing.Point(10, 141);
            this.NetworkOptions.Name = "NetworkOptions";
            this.NetworkOptions.Size = new System.Drawing.Size(114, 0);
            this.NetworkOptions.TabIndex = 2;
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1315, 783);
            this.Controls.Add(this.NetworkOptions);
            this.Controls.Add(this.elementHost1);
            this.Controls.Add(this.radRibbonBar1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = null;
            this.Name = "MainMenu";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "GSIM";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.radRibbonBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radThreePhaseBusButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPhaseAButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPhaseBButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPhaseCButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGeneralSignalButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radDiagonalSignalButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radBundleButton)).EndInit();
            this.NetworkOptions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadContextMenuManager radContextMenuManager1;
        private Telerik.WinControls.UI.RadTextBoxElement radTextBoxElement1;
        private Telerik.WinControls.UI.RadRibbonBarGroup radRibbonBarGroup1;
        private Telerik.WinControls.UI.RibbonTab ribbonTab1;
        private Telerik.WinControls.UI.RadRibbonBar radRibbonBar1;
        private Telerik.WinControls.UI.RibbonTab ribbonTab2;
        private Telerik.WinControls.UI.RadRibbonBarGroup radRibbonBarGroup3;
        private Telerik.WinControls.UI.RibbonTab ribbonTab3;
        private System.Windows.Forms.Timer timer1;
        private Telerik.WinControls.UI.RadButtonElement radButtonElement2;
        private Telerik.WinControls.UI.RadButtonElement radButtonElement3;
        private Telerik.WinControls.UI.RadButtonElement radButtonElement4;
        private Telerik.WinControls.UI.RadButtonElement radButtonElement5;
        private Telerik.WinControls.UI.RadRibbonBarButtonGroup radRibbonBarButtonGroup2;
        private Telerik.WinControls.UI.RadRibbonBarButtonGroup radRibbonBarButtonGroup3;
        private Telerik.WinControls.UI.RadRibbonBarGroup radRibbonBarGroup2;
        private Telerik.WinControls.UI.RadButtonElement radNewButton;
        private Telerik.WinControls.UI.RadButtonElement radOpenButton;
        private Telerik.WinControls.UI.RadButtonElement radSaveButton;
        private Telerik.WinControls.UI.RadRibbonBarGroup radRibbonBarGroup7;
        private RadRibbonBarButtonGroup radUndoRedoRibbonBarButtonGroup;
        private RadButtonElement radUndoButton;
        private RadButtonElement radRedoButton;
        private RadButtonElement radSelectAllButton;
        private RadRibbonBarGroup radRibbonBarGroupTools;
        private RadButtonElement radBusesButton;
        private RadRibbonBarButtonGroup radToolsRibbonBarButtonGroup;
        private RadButtonElement radPointerButton;
        private RadButtonElement radPanButton;
        private RadButtonElement radConnectorButton;
        private RadButtonElement radDBButton;
        private RadRibbonBarGroup radRibbonBarGroup4;
        private RadRibbonBarButtonGroup radSelectionRibbonBarButtonGroup;
        private RadButtonElement radSingleButton;
        private RadButtonElement radMultipleButton;
        private RadRibbonBarButtonGroup radTextDrawRibbonBarButtonGroup;
        private RadButtonElement radTextButton;
        private RadButtonElement radPolygonButton;
        private System.Windows.Forms.Integration.ElementHost elementHost1;
        private RadButtonElement radButtonElement1;
        private RadButtonElement radButtonElement6;
        private RadRibbonBarButtonGroup radRibbonBarButtonGroup1;
        private RadButton radThreePhaseBusButton;
        private RadButton radPhaseAButton;
        private RadButton radPhaseBButton;
        private RadButton radPhaseCButton;
        private RadButton radGeneralSignalButton;
        private RadButton radDiagonalSignalButton;
        private RadButton radBundleButton;
        private System.Windows.Forms.Panel NetworkOptions;
        private RadButtonElement radButtonElement7;
    }
}

*/