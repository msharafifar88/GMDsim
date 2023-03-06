using System.Drawing;
using System.Linq;

namespace GUI.New_concept
{
    partial class ToolDiagram_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ToolDiagram_Form));
            Telerik.WinControls.UI.Docking.AutoHideGroup autoHideGroup1 = new Telerik.WinControls.UI.Docking.AutoHideGroup();
            Telerik.WinControls.UI.Docking.AutoHideGroup autoHideGroup2 = new Telerik.WinControls.UI.Docking.AutoHideGroup();
            Telerik.WinControls.UI.RadListDataItem radListDataItem1 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem2 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem3 = new Telerik.WinControls.UI.RadListDataItem();
            this.imageNetToolList = new System.Windows.Forms.ImageList(this.components);
            this.radToolDiagramDock = new Telerik.WinControls.UI.Docking.RadDock();
            this.toolSettingsWindow = new Telerik.WinControls.UI.Docking.ToolWindow();
            this.radConnectionTypeLabel = new Telerik.WinControls.UI.RadLabel();
            this.radConnectionLabel = new Telerik.WinControls.UI.RadLabel();
            this.radDiagramColorLabel = new Telerik.WinControls.UI.RadLabel();
            this.radGridColorLabel = new Telerik.WinControls.UI.RadLabel();
            this.radSettingsDiagramLabel = new Telerik.WinControls.UI.RadLabel();
            this.radConnectionypeDropDownList = new Telerik.WinControls.UI.RadDropDownList();
            this.radBackColorBox = new Telerik.WinControls.UI.RadColorBox();
            this.radGridColorBox = new Telerik.WinControls.UI.RadColorBox();
            this.radGridButton = new Telerik.WinControls.UI.RadButton();
            this.toolTabSettingStrip = new Telerik.WinControls.UI.Docking.ToolTabStrip();
            this.toolTabNetworkStrip = new Telerik.WinControls.UI.Docking.ToolTabStrip();
            this.toolNetworkWindow = new Telerik.WinControls.UI.Docking.ToolWindow();
            this.panelPreview = new System.Windows.Forms.Panel();
            this.picturePreviewBox = new System.Windows.Forms.PictureBox();
            this.DiagramContainer = new Telerik.WinControls.UI.Docking.DocumentContainer();
            this.toolPropTabStrip = new Telerik.WinControls.UI.Docking.ToolTabStrip();
            this.toolPropWindow = new Telerik.WinControls.UI.Docking.ToolWindow();
            this.imagePreviewList = new System.Windows.Forms.ImageList(this.components);
            this.documentTabStrip1 = new Telerik.WinControls.UI.Docking.DocumentTabStrip();
            ((System.ComponentModel.ISupportInitialize)(this.radToolDiagramDock)).BeginInit();
            this.radToolDiagramDock.SuspendLayout();
            this.toolSettingsWindow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radConnectionTypeLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radConnectionLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radDiagramColorLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridColorLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radSettingsDiagramLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radConnectionypeDropDownList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radBackColorBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridColorBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toolTabSettingStrip)).BeginInit();
            this.toolTabSettingStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.toolTabNetworkStrip)).BeginInit();
            this.toolTabNetworkStrip.SuspendLayout();
            this.toolNetworkWindow.SuspendLayout();
            this.panelPreview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picturePreviewBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DiagramContainer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toolPropTabStrip)).BeginInit();
            this.toolPropTabStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.documentTabStrip1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // imageNetToolList
            // 
            this.imageNetToolList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageNetToolList.ImageStream")));
            this.imageNetToolList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageNetToolList.Images.SetKeyName(0, "net_tree.png");
            this.imageNetToolList.Images.SetKeyName(1, "bus_tree.png");
            this.imageNetToolList.Images.SetKeyName(2, "generator_tree.png");
            this.imageNetToolList.Images.SetKeyName(3, "load2_tree.png");
            this.imageNetToolList.Images.SetKeyName(4, "schunt_tree.png");
            this.imageNetToolList.Images.SetKeyName(5, "lines_tree.png");
            this.imageNetToolList.Images.SetKeyName(6, "empty_tree.png");
            this.imageNetToolList.Images.SetKeyName(7, "transformer_tree.png");
            this.imageNetToolList.Images.SetKeyName(8, "rlc_tree.png");
            // 
            // radToolDiagramDock
            // 
            this.radToolDiagramDock.AccessibleDescription = "radToolDiagramDock";
            this.radToolDiagramDock.AccessibleName = "radToolDiagramDock";
            this.radToolDiagramDock.ActiveWindow = this.toolSettingsWindow;
            this.radToolDiagramDock.CausesValidation = false;
            this.radToolDiagramDock.Controls.Add(this.toolTabSettingStrip);
            this.radToolDiagramDock.Controls.Add(this.toolTabNetworkStrip);
            this.radToolDiagramDock.Controls.Add(this.DiagramContainer);
            this.radToolDiagramDock.Controls.Add(this.toolPropTabStrip);
            this.radToolDiagramDock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radToolDiagramDock.IsCleanUpTarget = true;
            this.radToolDiagramDock.Location = new System.Drawing.Point(0, 0);
            this.radToolDiagramDock.MainDocumentContainer = this.DiagramContainer;
            this.radToolDiagramDock.Name = "radToolDiagramDock";
            this.radToolDiagramDock.Padding = new System.Windows.Forms.Padding(8);
            // 
            // 
            // 
            this.radToolDiagramDock.RootElement.MinSize = new System.Drawing.Size(25, 25);
            this.radToolDiagramDock.SerializableAutoHideContainer.LeftAutoHideGroups.Add(autoHideGroup1);
            this.radToolDiagramDock.SerializableAutoHideContainer.LeftAutoHideGroups.Add(autoHideGroup2);
            this.radToolDiagramDock.Size = new System.Drawing.Size(870, 506);
            this.radToolDiagramDock.TabIndex = 0;
            this.radToolDiagramDock.TabStop = false;
            // 
            // toolSettingsWindow
            // 
            this.toolSettingsWindow.AccessibleDescription = "toolSettingsWindow";
            this.toolSettingsWindow.AccessibleName = "toolSettingsWindow";
            this.toolSettingsWindow.Caption = null;
            this.toolSettingsWindow.Controls.Add(this.radConnectionTypeLabel);
            this.toolSettingsWindow.Controls.Add(this.radConnectionLabel);
            this.toolSettingsWindow.Controls.Add(this.radDiagramColorLabel);
            this.toolSettingsWindow.Controls.Add(this.radGridColorLabel);
            this.toolSettingsWindow.Controls.Add(this.radSettingsDiagramLabel);
            this.toolSettingsWindow.Controls.Add(this.radConnectionypeDropDownList);
            this.toolSettingsWindow.Controls.Add(this.radBackColorBox);
            this.toolSettingsWindow.Controls.Add(this.radGridColorBox);
            this.toolSettingsWindow.Controls.Add(this.radGridButton);
            this.toolSettingsWindow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolSettingsWindow.Image = ((System.Drawing.Image)(resources.GetObject("toolSettingsWindow.Image")));
            this.toolSettingsWindow.Location = new System.Drawing.Point(1, 22);
            this.toolSettingsWindow.Name = "toolSettingsWindow";
            this.toolSettingsWindow.PreviousDockState = Telerik.WinControls.UI.Docking.DockState.Docked;
            this.toolSettingsWindow.Size = new System.Drawing.Size(141, 466);
            this.toolSettingsWindow.Text = "Settings";
            this.toolSettingsWindow.ToolCaptionButtons = Telerik.WinControls.UI.Docking.ToolStripCaptionButtons.AutoHide;
            // 
            // radConnectionTypeLabel
            // 
            this.radConnectionTypeLabel.AccessibleDescription = "radConnectionTypeLabel";
            this.radConnectionTypeLabel.AccessibleName = "radConnectionTypeLabel";
            this.radConnectionTypeLabel.Location = new System.Drawing.Point(7, 174);
            this.radConnectionTypeLabel.Name = "radConnectionTypeLabel";
            this.radConnectionTypeLabel.Size = new System.Drawing.Size(93, 18);
            this.radConnectionTypeLabel.TabIndex = 10;
            this.radConnectionTypeLabel.Text = "Connections type";
            // 
            // radConnectionLabel
            // 
            this.radConnectionLabel.AccessibleDescription = "radConnectionLabel";
            this.radConnectionLabel.AccessibleName = "radConnectionLabel";
            this.radConnectionLabel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.radConnectionLabel.Location = new System.Drawing.Point(0, 152);
            this.radConnectionLabel.Name = "radConnectionLabel";
            this.radConnectionLabel.Size = new System.Drawing.Size(130, 18);
            this.radConnectionLabel.TabIndex = 9;
            this.radConnectionLabel.Text = "Connections properties";
            // 
            // radDiagramColorLabel
            // 
            this.radDiagramColorLabel.AccessibleDescription = "radDiagramColorLabel";
            this.radDiagramColorLabel.AccessibleName = "radDiagramColorLabel";
            this.radDiagramColorLabel.Location = new System.Drawing.Point(7, 102);
            this.radDiagramColorLabel.Name = "radDiagramColorLabel";
            this.radDiagramColorLabel.Size = new System.Drawing.Size(79, 18);
            this.radDiagramColorLabel.TabIndex = 8;
            this.radDiagramColorLabel.Text = "Diagram Color";
            // 
            // radGridColorLabel
            // 
            this.radGridColorLabel.AccessibleDescription = "radGridColorLabel";
            this.radGridColorLabel.AccessibleName = "radGridColorLabel";
            this.radGridColorLabel.Location = new System.Drawing.Point(7, 53);
            this.radGridColorLabel.Name = "radGridColorLabel";
            this.radGridColorLabel.Size = new System.Drawing.Size(57, 18);
            this.radGridColorLabel.TabIndex = 7;
            this.radGridColorLabel.Text = "Grid Color";
            // 
            // radSettingsDiagramLabel
            // 
            this.radSettingsDiagramLabel.AccessibleDescription = "radSettingsDiagramLabel";
            this.radSettingsDiagramLabel.AccessibleName = "radSettingsDiagramLabel";
            this.radSettingsDiagramLabel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.radSettingsDiagramLabel.Location = new System.Drawing.Point(0, 2);
            this.radSettingsDiagramLabel.Name = "radSettingsDiagramLabel";
            this.radSettingsDiagramLabel.Size = new System.Drawing.Size(110, 18);
            this.radSettingsDiagramLabel.TabIndex = 6;
            this.radSettingsDiagramLabel.Text = "Diagram properties";
            // 
            // radConnectionypeDropDownList
            // 
            this.radConnectionypeDropDownList.AccessibleDescription = "radConnectionypeDropDownList";
            this.radConnectionypeDropDownList.AccessibleName = "radConnectionypeDropDownList";
            this.radConnectionypeDropDownList.AutoSize = false;
            radListDataItem1.Text = "None";
            radListDataItem2.Text = "Bow";
            radListDataItem3.Text = "Gap";
            this.radConnectionypeDropDownList.Items.Add(radListDataItem1);
            this.radConnectionypeDropDownList.Items.Add(radListDataItem2);
            this.radConnectionypeDropDownList.Items.Add(radListDataItem3);
            this.radConnectionypeDropDownList.Location = new System.Drawing.Point(7, 196);
            this.radConnectionypeDropDownList.Name = "radConnectionypeDropDownList";
            this.radConnectionypeDropDownList.Size = new System.Drawing.Size(120, 24);
            this.radConnectionypeDropDownList.TabIndex = 4;
            this.radConnectionypeDropDownList.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.radConnectionypeDropDownList_SelectedIndexChanged);
            // 
            // radBackColorBox
            // 
            this.radBackColorBox.AccessibleDescription = "radBackColorBox";
            this.radBackColorBox.AccessibleName = "radBackColorBox";
            this.radBackColorBox.Location = new System.Drawing.Point(7, 124);
            this.radBackColorBox.Name = "radBackColorBox";
            this.radBackColorBox.Size = new System.Drawing.Size(120, 24);
            this.radBackColorBox.TabIndex = 3;
            this.radBackColorBox.ValueChanged += new System.EventHandler(this.radBackColorBox_ValueChanged);
            // 
            // radGridColorBox
            // 
            this.radGridColorBox.AccessibleDescription = "radGridColorBox";
            this.radGridColorBox.AccessibleName = "radGridColorBox";
            this.radGridColorBox.Location = new System.Drawing.Point(7, 75);
            this.radGridColorBox.Name = "radGridColorBox";
            this.radGridColorBox.Size = new System.Drawing.Size(120, 24);
            this.radGridColorBox.TabIndex = 2;
            this.radGridColorBox.ValueChanged += new System.EventHandler(this.radGridColorBox_ValueChanged);
            // 
            // radGridButton
            // 
            this.radGridButton.AccessibleDescription = "radGridButton";
            this.radGridButton.AccessibleName = "radGridButton";
            this.radGridButton.Image = global::GUI.Properties.Resources.viGrid;
            this.radGridButton.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.radGridButton.Location = new System.Drawing.Point(7, 25);
            this.radGridButton.Name = "radGridButton";
            this.radGridButton.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.radGridButton.ShowItemToolTips = false;
            this.radGridButton.Size = new System.Drawing.Size(120, 24);
            this.radGridButton.TabIndex = 0;
            this.radGridButton.Text = " Show Grid";
            this.radGridButton.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.radGridButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.radGridButton.Click += new System.EventHandler(this.radGridButton_Click);
            // 
            // toolTabSettingStrip
            // 
            this.toolTabSettingStrip.AccessibleDescription = "toolTabSettingStrip";
            this.toolTabSettingStrip.AccessibleName = "toolTabSettingStrip";
            this.toolTabSettingStrip.CanUpdateChildIndex = true;
            this.toolTabSettingStrip.Controls.Add(this.toolSettingsWindow);
            this.toolTabSettingStrip.Location = new System.Drawing.Point(8, 8);
            this.toolTabSettingStrip.Name = "toolTabSettingStrip";
            // 
            // 
            // 
            this.toolTabSettingStrip.RootElement.MinSize = new System.Drawing.Size(25, 25);
            this.toolTabSettingStrip.SelectedIndex = 0;
            this.toolTabSettingStrip.Size = new System.Drawing.Size(143, 490);
            this.toolTabSettingStrip.SizeInfo.AbsoluteSize = new System.Drawing.Size(143, 200);
            this.toolTabSettingStrip.SizeInfo.SplitterCorrection = new System.Drawing.Size(-57, 0);
            this.toolTabSettingStrip.TabIndex = 3;
            this.toolTabSettingStrip.TabStop = false;
            // 
            // toolTabNetworkStrip
            // 
            this.toolTabNetworkStrip.AccessibleDescription = "toolTabNetworkStrip";
            this.toolTabNetworkStrip.AccessibleName = "toolTabNetworkStrip";
            this.toolTabNetworkStrip.CanUpdateChildIndex = true;
            this.toolTabNetworkStrip.Controls.Add(this.toolNetworkWindow);
            this.toolTabNetworkStrip.Location = new System.Drawing.Point(155, 8);
            this.toolTabNetworkStrip.Name = "toolTabNetworkStrip";
            // 
            // 
            // 
            this.toolTabNetworkStrip.RootElement.MinSize = new System.Drawing.Size(25, 25);
            this.toolTabNetworkStrip.SelectedIndex = 0;
            this.toolTabNetworkStrip.Size = new System.Drawing.Size(131, 490);
            this.toolTabNetworkStrip.SizeInfo.AbsoluteSize = new System.Drawing.Size(131, 300);
            this.toolTabNetworkStrip.SizeInfo.SplitterCorrection = new System.Drawing.Size(-170, 0);
            this.toolTabNetworkStrip.TabIndex = 1;
            this.toolTabNetworkStrip.TabStop = false;
            // 
            // toolNetworkWindow
            // 
            this.toolNetworkWindow.Caption = null;
            this.toolNetworkWindow.Controls.Add(this.panelPreview);
            this.toolNetworkWindow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.toolNetworkWindow.Location = new System.Drawing.Point(1, 22);
            this.toolNetworkWindow.Margin = new System.Windows.Forms.Padding(6);
            this.toolNetworkWindow.Name = "toolNetworkWindow";
            this.toolNetworkWindow.PreviousDockState = Telerik.WinControls.UI.Docking.DockState.Hidden;
            this.toolNetworkWindow.Size = new System.Drawing.Size(129, 466);
            this.toolNetworkWindow.Text = "Network";
            this.toolNetworkWindow.ToolCaptionButtons = Telerik.WinControls.UI.Docking.ToolStripCaptionButtons.AutoHide;
            // 
            // panelPreview
            // 
            this.panelPreview.Controls.Add(this.picturePreviewBox);
            this.panelPreview.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelPreview.Location = new System.Drawing.Point(0, 371);
            this.panelPreview.Name = "panelPreview";
            this.panelPreview.Size = new System.Drawing.Size(129, 95);
            this.panelPreview.TabIndex = 4;
            // 
            // picturePreviewBox
            // 
            this.picturePreviewBox.AccessibleDescription = "picturePreviewBox";
            this.picturePreviewBox.AccessibleName = "picturePreviewBox";
            this.picturePreviewBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picturePreviewBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picturePreviewBox.Location = new System.Drawing.Point(0, 0);
            this.picturePreviewBox.Name = "picturePreviewBox";
            this.picturePreviewBox.Size = new System.Drawing.Size(129, 95);
            this.picturePreviewBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picturePreviewBox.TabIndex = 0;
            this.picturePreviewBox.TabStop = false;
            // 
            // DiagramContainer
            // 
            this.DiagramContainer.AccessibleDescription = "DiagramContainer";
            this.DiagramContainer.AccessibleName = "DiagramContainer";
            this.DiagramContainer.CausesValidation = false;
            this.DiagramContainer.Name = "DiagramContainer";
            this.DiagramContainer.Padding = new System.Windows.Forms.Padding(8);
            // 
            // 
            // 
            this.DiagramContainer.RootElement.MinSize = new System.Drawing.Size(25, 25);
            this.DiagramContainer.SizeInfo.AbsoluteSize = new System.Drawing.Size(418, 300);
            this.DiagramContainer.SizeInfo.SizeMode = Telerik.WinControls.UI.Docking.SplitPanelSizeMode.Fill;
            this.DiagramContainer.SizeInfo.SplitterCorrection = new System.Drawing.Size(377, 0);
            this.DiagramContainer.TabIndex = 2;
            // 
            // toolPropTabStrip
            // 
            this.toolPropTabStrip.AccessibleDescription = "toolPropTabStrip";
            this.toolPropTabStrip.AccessibleName = "toolPropTabStrip";
            this.toolPropTabStrip.CanUpdateChildIndex = true;
            this.toolPropTabStrip.Controls.Add(this.toolPropWindow);
            this.toolPropTabStrip.Location = new System.Drawing.Point(712, 8);
            this.toolPropTabStrip.Name = "toolPropTabStrip";
            // 
            // 
            // 
            this.toolPropTabStrip.RootElement.FitToSizeMode = Telerik.WinControls.RadFitToSizeMode.FitToParentContent;
            this.toolPropTabStrip.RootElement.MinSize = new System.Drawing.Size(25, 25);
            this.toolPropTabStrip.RootElement.ZIndex = 0;
            this.toolPropTabStrip.SelectedIndex = 0;
            this.toolPropTabStrip.Size = new System.Drawing.Size(150, 490);
            this.toolPropTabStrip.SizeInfo.AbsoluteSize = new System.Drawing.Size(150, 300);
            this.toolPropTabStrip.SizeInfo.SplitterCorrection = new System.Drawing.Size(-150, 0);
            this.toolPropTabStrip.TabIndex = 2;
            this.toolPropTabStrip.TabStop = false;
            // 
            // toolPropWindow
            // 
            this.toolPropWindow.AccessibleDescription = "toolPropWindow";
            this.toolPropWindow.AccessibleName = "toolPropWindow";
            this.toolPropWindow.Caption = null;
            this.toolPropWindow.DocumentButtons = Telerik.WinControls.UI.Docking.DocumentStripButtons.None;
            this.toolPropWindow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.toolPropWindow.Location = new System.Drawing.Point(1, 22);
            this.toolPropWindow.Margin = new System.Windows.Forms.Padding(4);
            this.toolPropWindow.Name = "toolPropWindow";
            this.toolPropWindow.PreviousDockState = Telerik.WinControls.UI.Docking.DockState.Hidden;
            this.toolPropWindow.Size = new System.Drawing.Size(148, 466);
            this.toolPropWindow.Text = "Property";
            this.toolPropWindow.ToolCaptionButtons = Telerik.WinControls.UI.Docking.ToolStripCaptionButtons.AutoHide;
            // 
            // imagePreviewList
            // 
            this.imagePreviewList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imagePreviewList.ImageStream")));
            this.imagePreviewList.TransparentColor = System.Drawing.Color.Transparent;
            this.imagePreviewList.Images.SetKeyName(0, "BasePreview.png");
            this.imagePreviewList.Images.SetKeyName(1, "BusPreview.png");
            this.imagePreviewList.Images.SetKeyName(2, "GenPreview.png");
            this.imagePreviewList.Images.SetKeyName(3, "LoadPreview.png");
            this.imagePreviewList.Images.SetKeyName(4, "SchuntPreview.png");
            this.imagePreviewList.Images.SetKeyName(5, "triTraPreview.png");
            this.imagePreviewList.Images.SetKeyName(6, "ygDDTraPreview.png");
            this.imagePreviewList.Images.SetKeyName(7, "ygYgDTraPreview.png");
            this.imagePreviewList.Images.SetKeyName(8, "customTransformerPreview.png");
            this.imagePreviewList.Images.SetKeyName(9, "monoLinePreview.png");
            this.imagePreviewList.Images.SetKeyName(10, "biLinePreview.png");
            this.imagePreviewList.Images.SetKeyName(11, "triLinePreview.png");
            this.imagePreviewList.Images.SetKeyName(12, "cPreview.png");
            this.imagePreviewList.Images.SetKeyName(13, "lPreview.png");
            this.imagePreviewList.Images.SetKeyName(14, "rPreview.png");
            this.imagePreviewList.Images.SetKeyName(15, "lcPreview.png");
            this.imagePreviewList.Images.SetKeyName(16, "rLPreview.png");
            this.imagePreviewList.Images.SetKeyName(17, "rLCPreview.png");
            // 
            // documentTabStrip1
            // 
            this.documentTabStrip1.CanUpdateChildIndex = true;
            this.documentTabStrip1.CausesValidation = false;
            this.documentTabStrip1.Location = new System.Drawing.Point(0, 0);
            this.documentTabStrip1.Name = "documentTabStrip1";
            // 
            // 
            // 
            this.documentTabStrip1.RootElement.MinSize = new System.Drawing.Size(25, 25);
            this.documentTabStrip1.Size = new System.Drawing.Size(383, 490);
            this.documentTabStrip1.TabIndex = 0;
            this.documentTabStrip1.TabStop = false;
            this.documentTabStrip1.SelectedIndexChanged += new System.EventHandler(this.documentTabStrip1_SelectedIndexChanged);
            // 
            // ToolDiagram_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(870, 506);
            this.Controls.Add(this.radToolDiagramDock);
            this.Name = "ToolDiagram_Form";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "CaseWindow";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ToolDiagram_Form_FormClosing);
            this.Load += new System.EventHandler(this.ToolDiagram_Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radToolDiagramDock)).EndInit();
            this.radToolDiagramDock.ResumeLayout(false);
            this.toolSettingsWindow.ResumeLayout(false);
            this.toolSettingsWindow.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radConnectionTypeLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radConnectionLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radDiagramColorLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridColorLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radSettingsDiagramLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radConnectionypeDropDownList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radBackColorBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridColorBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toolTabSettingStrip)).EndInit();
            this.toolTabSettingStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.toolTabNetworkStrip)).EndInit();
            this.toolTabNetworkStrip.ResumeLayout(false);
            this.toolNetworkWindow.ResumeLayout(false);
            this.panelPreview.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picturePreviewBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DiagramContainer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toolPropTabStrip)).EndInit();
            this.toolPropTabStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.documentTabStrip1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.Docking.RadDock radToolDiagramDock;
        private Telerik.WinControls.UI.Docking.ToolWindow toolNetworkWindow;
        private Telerik.WinControls.UI.Docking.ToolTabStrip toolTabNetworkStrip;
        private Telerik.WinControls.UI.Docking.DocumentContainer DiagramContainer;
        private Telerik.WinControls.UI.Docking.ToolTabStrip toolPropTabStrip;
        private Telerik.WinControls.UI.Docking.ToolWindow toolPropWindow;
        private Telerik.WinControls.UI.Docking.ToolWindow toolSettingsWindow;
        private Telerik.WinControls.UI.RadButton radGridButton;
        private Telerik.WinControls.UI.Docking.ToolTabStrip toolTabSettingStrip;
        private System.Windows.Forms.ImageList imageNetToolList;
        private System.Windows.Forms.ImageList imagePreviewList;
        private System.Windows.Forms.Panel panelPreview;
        private System.Windows.Forms.PictureBox picturePreviewBox;
        private Telerik.WinControls.UI.RadDropDownList radConnectionypeDropDownList;
        private Telerik.WinControls.UI.RadColorBox radBackColorBox;
        private Telerik.WinControls.UI.RadColorBox radGridColorBox;
        private Telerik.WinControls.UI.RadLabel radSettingsDiagramLabel;
        private Telerik.WinControls.UI.RadLabel radConnectionTypeLabel;
        private Telerik.WinControls.UI.RadLabel radConnectionLabel;
        private Telerik.WinControls.UI.RadLabel radDiagramColorLabel;
        private Telerik.WinControls.UI.RadLabel radGridColorLabel;
        private Telerik.WinControls.UI.Docking.DocumentTabStrip documentTabStrip1;
    }
}
