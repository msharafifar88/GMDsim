namespace GUI.FileController
{
    partial class FileBrowser
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
            this.SelectorBTN = new System.Windows.Forms.Button();
            this.fileUploaderDialog = new System.Windows.Forms.OpenFileDialog();
            this.contentTab = new System.Windows.Forms.TabControl();
            this.busTab = new System.Windows.Forms.TabPage();
            this.busDataGrid = new Syncfusion.WinForms.DataGrid.SfDataGrid();
            this.generatorTab = new System.Windows.Forms.TabPage();
            this.generatorDataGrid = new Syncfusion.WinForms.DataGrid.SfDataGrid();
            this.loadTab = new System.Windows.Forms.TabPage();
            this.loadDataGrid = new Syncfusion.WinForms.DataGrid.SfDataGrid();
            this.zoneTab = new System.Windows.Forms.TabPage();
            this.zoneDataGrid = new Syncfusion.WinForms.DataGrid.SfDataGrid();
            this.areaTab = new System.Windows.Forms.TabPage();
            this.areaDataGrid = new Syncfusion.WinForms.DataGrid.SfDataGrid();
            this.lineTab = new System.Windows.Forms.TabPage();
            this.lineDataGrid = new Syncfusion.WinForms.DataGrid.SfDataGrid();
            this.ownerTab = new System.Windows.Forms.TabPage();
            this.ownerDataGrid = new Syncfusion.WinForms.DataGrid.SfDataGrid();
            this.Transformer = new System.Windows.Forms.TabPage();
            this.transformerDataGrid = new Syncfusion.WinForms.DataGrid.SfDataGrid();
            this.ProgramSetings = new System.Windows.Forms.TabPage();
            this.ProgramSettingDataGrid = new Syncfusion.WinForms.DataGrid.SfDataGrid();
            this.headerPanel = new System.Windows.Forms.Panel();
            this.Save = new System.Windows.Forms.Button();
            this.ProgramSettingGP = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.Sbase = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.BASEFRQ = new System.Windows.Forms.Label();
            this.REV = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.IC = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.XFRRAT = new System.Windows.Forms.Label();
            this.NXFRAT = new System.Windows.Forms.Label();
            this.contentTab.SuspendLayout();
            this.busTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.busDataGrid)).BeginInit();
            this.generatorTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.generatorDataGrid)).BeginInit();
            this.loadTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.loadDataGrid)).BeginInit();
            this.zoneTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.zoneDataGrid)).BeginInit();
            this.areaTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.areaDataGrid)).BeginInit();
            this.lineTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lineDataGrid)).BeginInit();
            this.ownerTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ownerDataGrid)).BeginInit();
            this.Transformer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.transformerDataGrid)).BeginInit();
            this.ProgramSetings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProgramSettingDataGrid)).BeginInit();
            this.headerPanel.SuspendLayout();
            this.ProgramSettingGP.SuspendLayout();
            this.SuspendLayout();
            // 
            // SelectorBTN
            // 
            this.SelectorBTN.Location = new System.Drawing.Point(12, 25);
            this.SelectorBTN.Name = "SelectorBTN";
            this.SelectorBTN.Size = new System.Drawing.Size(75, 23);
            this.SelectorBTN.TabIndex = 0;
            this.SelectorBTN.Text = "Select";
            this.SelectorBTN.UseVisualStyleBackColor = true;
            this.SelectorBTN.Click += new System.EventHandler(this.SelectorBTN_Click);
            // 
            // fileUploaderDialog
            // 
            this.fileUploaderDialog.FileName = "fileUploaderDialog";
            // 
            // contentTab
            // 
            this.contentTab.Controls.Add(this.busTab);
            this.contentTab.Controls.Add(this.generatorTab);
            this.contentTab.Controls.Add(this.loadTab);
            this.contentTab.Controls.Add(this.zoneTab);
            this.contentTab.Controls.Add(this.areaTab);
            this.contentTab.Controls.Add(this.lineTab);
            this.contentTab.Controls.Add(this.ownerTab);
            this.contentTab.Controls.Add(this.Transformer);
            this.contentTab.Controls.Add(this.ProgramSetings);
            this.contentTab.Dock = System.Windows.Forms.DockStyle.Top;
            this.contentTab.Location = new System.Drawing.Point(0, 0);
            this.contentTab.Name = "contentTab";
            this.contentTab.SelectedIndex = 0;
            this.contentTab.Size = new System.Drawing.Size(1213, 688);
            this.contentTab.TabIndex = 1;
            // 
            // busTab
            // 
            this.busTab.Controls.Add(this.busDataGrid);
            this.busTab.Location = new System.Drawing.Point(4, 22);
            this.busTab.Name = "busTab";
            this.busTab.Padding = new System.Windows.Forms.Padding(3);
            this.busTab.Size = new System.Drawing.Size(1205, 662);
            this.busTab.TabIndex = 0;
            this.busTab.Text = "Bus";
            this.busTab.UseVisualStyleBackColor = true;
            // 
            // busDataGrid
            // 
            this.busDataGrid.AccessibleName = "Table";
            this.busDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.busDataGrid.Location = new System.Drawing.Point(3, 3);
            this.busDataGrid.Name = "busDataGrid";
            this.busDataGrid.PreviewRowHeight = 42;
            this.busDataGrid.Size = new System.Drawing.Size(1199, 656);
            this.busDataGrid.TabIndex = 0;
            this.busDataGrid.Text = "busGrid";
            // 
            // generatorTab
            // 
            this.generatorTab.Controls.Add(this.generatorDataGrid);
            this.generatorTab.Location = new System.Drawing.Point(4, 22);
            this.generatorTab.Name = "generatorTab";
            this.generatorTab.Padding = new System.Windows.Forms.Padding(3);
            this.generatorTab.Size = new System.Drawing.Size(1205, 662);
            this.generatorTab.TabIndex = 1;
            this.generatorTab.Text = "Generator";
            this.generatorTab.UseVisualStyleBackColor = true;
            // 
            // generatorDataGrid
            // 
            this.generatorDataGrid.AccessibleName = "Table";
            this.generatorDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.generatorDataGrid.Location = new System.Drawing.Point(3, 3);
            this.generatorDataGrid.Name = "generatorDataGrid";
            this.generatorDataGrid.PreviewRowHeight = 42;
            this.generatorDataGrid.Size = new System.Drawing.Size(1199, 656);
            this.generatorDataGrid.TabIndex = 0;
            this.generatorDataGrid.Text = "generatorGrid";
            this.generatorDataGrid.SelectionChanged += new Syncfusion.WinForms.DataGrid.Events.SelectionChangedEventHandler(this.generatorDataGrid_SelectionChanged);
            // 
            // loadTab
            // 
            this.loadTab.Controls.Add(this.loadDataGrid);
            this.loadTab.Location = new System.Drawing.Point(4, 22);
            this.loadTab.Name = "loadTab";
            this.loadTab.Size = new System.Drawing.Size(1205, 662);
            this.loadTab.TabIndex = 2;
            this.loadTab.Text = "Load";
            this.loadTab.UseVisualStyleBackColor = true;
            // 
            // loadDataGrid
            // 
            this.loadDataGrid.AccessibleName = "Table";
            this.loadDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.loadDataGrid.Location = new System.Drawing.Point(0, 0);
            this.loadDataGrid.Name = "loadDataGrid";
            this.loadDataGrid.PreviewRowHeight = 42;
            this.loadDataGrid.Size = new System.Drawing.Size(1205, 662);
            this.loadDataGrid.TabIndex = 0;
            this.loadDataGrid.Text = "loadDataGrid";
            // 
            // zoneTab
            // 
            this.zoneTab.Controls.Add(this.zoneDataGrid);
            this.zoneTab.Location = new System.Drawing.Point(4, 22);
            this.zoneTab.Name = "zoneTab";
            this.zoneTab.Size = new System.Drawing.Size(1205, 662);
            this.zoneTab.TabIndex = 3;
            this.zoneTab.Text = "Zone";
            this.zoneTab.UseVisualStyleBackColor = true;
            // 
            // zoneDataGrid
            // 
            this.zoneDataGrid.AccessibleName = "Table";
            this.zoneDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zoneDataGrid.Location = new System.Drawing.Point(0, 0);
            this.zoneDataGrid.Name = "zoneDataGrid";
            this.zoneDataGrid.PreviewRowHeight = 42;
            this.zoneDataGrid.Size = new System.Drawing.Size(1205, 662);
            this.zoneDataGrid.TabIndex = 0;
            this.zoneDataGrid.Text = "zoneDataGrid";
            // 
            // areaTab
            // 
            this.areaTab.Controls.Add(this.areaDataGrid);
            this.areaTab.Location = new System.Drawing.Point(4, 22);
            this.areaTab.Name = "areaTab";
            this.areaTab.Size = new System.Drawing.Size(1205, 662);
            this.areaTab.TabIndex = 4;
            this.areaTab.Text = "Area";
            this.areaTab.UseVisualStyleBackColor = true;
            // 
            // areaDataGrid
            // 
            this.areaDataGrid.AccessibleName = "Table";
            this.areaDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.areaDataGrid.Location = new System.Drawing.Point(0, 0);
            this.areaDataGrid.Name = "areaDataGrid";
            this.areaDataGrid.PreviewRowHeight = 42;
            this.areaDataGrid.Size = new System.Drawing.Size(1205, 662);
            this.areaDataGrid.TabIndex = 0;
            this.areaDataGrid.Text = "areaDataGrid";
            // 
            // lineTab
            // 
            this.lineTab.Controls.Add(this.lineDataGrid);
            this.lineTab.Location = new System.Drawing.Point(4, 22);
            this.lineTab.Name = "lineTab";
            this.lineTab.Size = new System.Drawing.Size(1205, 662);
            this.lineTab.TabIndex = 5;
            this.lineTab.Text = "Line";
            this.lineTab.UseVisualStyleBackColor = true;
            // 
            // lineDataGrid
            // 
            this.lineDataGrid.AccessibleName = "Table";
            this.lineDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lineDataGrid.Location = new System.Drawing.Point(0, 0);
            this.lineDataGrid.Name = "lineDataGrid";
            this.lineDataGrid.PreviewRowHeight = 42;
            this.lineDataGrid.Size = new System.Drawing.Size(1205, 662);
            this.lineDataGrid.TabIndex = 0;
            this.lineDataGrid.Text = "lineDataGrid";
            // 
            // ownerTab
            // 
            this.ownerTab.Controls.Add(this.ownerDataGrid);
            this.ownerTab.Location = new System.Drawing.Point(4, 22);
            this.ownerTab.Name = "ownerTab";
            this.ownerTab.Size = new System.Drawing.Size(1205, 662);
            this.ownerTab.TabIndex = 6;
            this.ownerTab.Text = "Owner";
            this.ownerTab.UseVisualStyleBackColor = true;
            // 
            // ownerDataGrid
            // 
            this.ownerDataGrid.AccessibleName = "Table";
            this.ownerDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ownerDataGrid.Location = new System.Drawing.Point(0, 0);
            this.ownerDataGrid.Name = "ownerDataGrid";
            this.ownerDataGrid.PreviewRowHeight = 42;
            this.ownerDataGrid.Size = new System.Drawing.Size(1205, 662);
            this.ownerDataGrid.TabIndex = 0;
            this.ownerDataGrid.Text = "OwnerDataGrid";
            // 
            // Transformer
            // 
            this.Transformer.Controls.Add(this.transformerDataGrid);
            this.Transformer.Location = new System.Drawing.Point(4, 22);
            this.Transformer.Name = "Transformer";
            this.Transformer.Size = new System.Drawing.Size(1205, 662);
            this.Transformer.TabIndex = 7;
            this.Transformer.Text = "Transformer";
            this.Transformer.UseVisualStyleBackColor = true;
            // 
            // transformerDataGrid
            // 
            this.transformerDataGrid.AccessibleName = "Table";
            this.transformerDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.transformerDataGrid.Location = new System.Drawing.Point(0, 0);
            this.transformerDataGrid.Name = "transformerDataGrid";
            this.transformerDataGrid.PreviewRowHeight = 42;
            this.transformerDataGrid.Size = new System.Drawing.Size(1205, 662);
            this.transformerDataGrid.TabIndex = 0;
            this.transformerDataGrid.Text = "sfDataGrid1";
            // 
            // ProgramSetings
            // 
            this.ProgramSetings.Controls.Add(this.ProgramSettingDataGrid);
            this.ProgramSetings.Location = new System.Drawing.Point(4, 22);
            this.ProgramSetings.Name = "ProgramSetings";
            this.ProgramSetings.Size = new System.Drawing.Size(1205, 662);
            this.ProgramSetings.TabIndex = 8;
            this.ProgramSetings.Text = "Program Setting";
            this.ProgramSetings.UseVisualStyleBackColor = true;
            // 
            // ProgramSettingDataGrid
            // 
            this.ProgramSettingDataGrid.AccessibleName = "Table";
            this.ProgramSettingDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProgramSettingDataGrid.Location = new System.Drawing.Point(0, 0);
            this.ProgramSettingDataGrid.Name = "ProgramSettingDataGrid";
            this.ProgramSettingDataGrid.PreviewRowHeight = 42;
            this.ProgramSettingDataGrid.Size = new System.Drawing.Size(1205, 662);
            this.ProgramSettingDataGrid.TabIndex = 1;
            this.ProgramSettingDataGrid.Text = "sfDataGrid1";
            // 
            // headerPanel
            // 
            this.headerPanel.Controls.Add(this.Save);
            this.headerPanel.Controls.Add(this.ProgramSettingGP);
            this.headerPanel.Controls.Add(this.SelectorBTN);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.headerPanel.Location = new System.Drawing.Point(0, 617);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(1213, 73);
            this.headerPanel.TabIndex = 2;
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(103, 24);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(75, 23);
            this.Save.TabIndex = 14;
            this.Save.Text = "Save";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // ProgramSettingGP
            // 
            this.ProgramSettingGP.Controls.Add(this.label1);
            this.ProgramSettingGP.Controls.Add(this.label10);
            this.ProgramSettingGP.Controls.Add(this.Sbase);
            this.ProgramSettingGP.Controls.Add(this.label9);
            this.ProgramSettingGP.Controls.Add(this.BASEFRQ);
            this.ProgramSettingGP.Controls.Add(this.REV);
            this.ProgramSettingGP.Controls.Add(this.label2);
            this.ProgramSettingGP.Controls.Add(this.IC);
            this.ProgramSettingGP.Controls.Add(this.label3);
            this.ProgramSettingGP.Controls.Add(this.label6);
            this.ProgramSettingGP.Controls.Add(this.XFRRAT);
            this.ProgramSettingGP.Controls.Add(this.NXFRAT);
            this.ProgramSettingGP.Location = new System.Drawing.Point(850, 3);
            this.ProgramSettingGP.Name = "ProgramSettingGP";
            this.ProgramSettingGP.Size = new System.Drawing.Size(360, 64);
            this.ProgramSettingGP.TabIndex = 13;
            this.ProgramSettingGP.TabStop = false;
            this.ProgramSettingGP.Text = "Program Setting";
            this.ProgramSettingGP.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "IC";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(228, 22);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(50, 13);
            this.label10.TabIndex = 12;
            this.label10.Text = "NXFRAT";
            // 
            // Sbase
            // 
            this.Sbase.AutoSize = true;
            this.Sbase.Location = new System.Drawing.Point(71, 40);
            this.Sbase.Name = "Sbase";
            this.Sbase.Size = new System.Drawing.Size(38, 13);
            this.Sbase.TabIndex = 1;
            this.Sbase.Text = "SBase";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(172, 22);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(50, 13);
            this.label9.TabIndex = 11;
            this.label9.Text = "XFRRAT";
            // 
            // BASEFRQ
            // 
            this.BASEFRQ.AutoSize = true;
            this.BASEFRQ.Location = new System.Drawing.Point(285, 40);
            this.BASEFRQ.Name = "BASEFRQ";
            this.BASEFRQ.Size = new System.Drawing.Size(56, 13);
            this.BASEFRQ.TabIndex = 2;
            this.BASEFRQ.Text = "Base FRQ";
            // 
            // REV
            // 
            this.REV.AutoSize = true;
            this.REV.Location = new System.Drawing.Point(128, 40);
            this.REV.Name = "REV";
            this.REV.Size = new System.Drawing.Size(29, 13);
            this.REV.TabIndex = 10;
            this.REV.Text = "REV";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(67, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "SBASE";
            // 
            // IC
            // 
            this.IC.AutoSize = true;
            this.IC.Location = new System.Drawing.Point(30, 40);
            this.IC.Name = "IC";
            this.IC.Size = new System.Drawing.Size(17, 13);
            this.IC.TabIndex = 9;
            this.IC.Text = "IC";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(128, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "REV";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(284, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Base FRQ";
            // 
            // XFRRAT
            // 
            this.XFRRAT.AutoSize = true;
            this.XFRRAT.Location = new System.Drawing.Point(174, 40);
            this.XFRRAT.Name = "XFRRAT";
            this.XFRRAT.Size = new System.Drawing.Size(50, 13);
            this.XFRRAT.TabIndex = 6;
            this.XFRRAT.Text = "XFRRAT";
            // 
            // NXFRAT
            // 
            this.NXFRAT.AutoSize = true;
            this.NXFRAT.Location = new System.Drawing.Point(229, 40);
            this.NXFRAT.Name = "NXFRAT";
            this.NXFRAT.Size = new System.Drawing.Size(50, 13);
            this.NXFRAT.TabIndex = 7;
            this.NXFRAT.Text = "NXFRAT";
            // 
            // FileBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1213, 690);
            this.Controls.Add(this.headerPanel);
            this.Controls.Add(this.contentTab);
            this.Name = "FileBrowser";
            this.Text = "FolderBrowser";
            this.contentTab.ResumeLayout(false);
            this.busTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.busDataGrid)).EndInit();
            this.generatorTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.generatorDataGrid)).EndInit();
            this.loadTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.loadDataGrid)).EndInit();
            this.zoneTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.zoneDataGrid)).EndInit();
            this.areaTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.areaDataGrid)).EndInit();
            this.lineTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lineDataGrid)).EndInit();
            this.ownerTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ownerDataGrid)).EndInit();
            this.Transformer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.transformerDataGrid)).EndInit();
            this.ProgramSetings.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ProgramSettingDataGrid)).EndInit();
            this.headerPanel.ResumeLayout(false);
            this.ProgramSettingGP.ResumeLayout(false);
            this.ProgramSettingGP.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button SelectorBTN;
        private System.Windows.Forms.OpenFileDialog fileUploaderDialog;
        private System.Windows.Forms.TabControl contentTab;
        private System.Windows.Forms.TabPage busTab;
        private Syncfusion.WinForms.DataGrid.SfDataGrid busDataGrid;
        private System.Windows.Forms.TabPage generatorTab;
        private Syncfusion.WinForms.DataGrid.SfDataGrid generatorDataGrid;
        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.TabPage loadTab;
        private System.Windows.Forms.TabPage zoneTab;
        private System.Windows.Forms.TabPage areaTab;
        private System.Windows.Forms.TabPage lineTab;
        private Syncfusion.WinForms.DataGrid.SfDataGrid loadDataGrid;
        private Syncfusion.WinForms.DataGrid.SfDataGrid zoneDataGrid;
        private Syncfusion.WinForms.DataGrid.SfDataGrid areaDataGrid;
        private Syncfusion.WinForms.DataGrid.SfDataGrid lineDataGrid;
        private System.Windows.Forms.TabPage ownerTab;
        private Syncfusion.WinForms.DataGrid.SfDataGrid ownerDataGrid;
        private System.Windows.Forms.TabPage Transformer;
        private Syncfusion.WinForms.DataGrid.SfDataGrid transformerDataGrid;
        private System.Windows.Forms.Label BASEFRQ;
        private System.Windows.Forms.Label Sbase;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label REV;
        private System.Windows.Forms.Label IC;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label NXFRAT;
        private System.Windows.Forms.Label XFRRAT;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox ProgramSettingGP;
        private System.Windows.Forms.TabPage ProgramSetings;
        private Syncfusion.WinForms.DataGrid.SfDataGrid ProgramSettingDataGrid;
        private System.Windows.Forms.Button Save;
    }
}