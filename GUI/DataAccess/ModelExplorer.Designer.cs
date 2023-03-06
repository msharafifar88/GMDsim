namespace GUI.DataAccess
{
    partial class ModelExplorer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModelExplorer));
            this.modelExplorerTree = new System.Windows.Forms.TreeView();
            this.tabModelExplorer = new Syncfusion.Windows.Forms.Tools.TabControlAdv();
            this.panel1 = new System.Windows.Forms.Panel();
            this.MainTabModleexplore = new Syncfusion.Windows.Forms.Tools.ToolStripEx();
            this.Insert1 = new System.Windows.Forms.ToolStripButton();
            this.print = new System.Windows.Forms.ToolStripButton();
            this.DataCollector = new System.Windows.Forms.ToolStripButton();
            this.Runpf = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.tabModelExplorer)).BeginInit();
            this.panel1.SuspendLayout();
            this.MainTabModleexplore.SuspendLayout();
            this.SuspendLayout();
            // 
            // modelExplorerTree
            // 
            this.modelExplorerTree.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.modelExplorerTree.Location = new System.Drawing.Point(12, 44);
            this.modelExplorerTree.Name = "modelExplorerTree";
            this.modelExplorerTree.Size = new System.Drawing.Size(152, 593);
            this.modelExplorerTree.TabIndex = 0;
            this.modelExplorerTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.modelExplorerTree_AfterSelect);
            // 
            // tabModelExplorer
            // 
            this.tabModelExplorer.AllowDrop = true;
            this.tabModelExplorer.BeforeTouchSize = new System.Drawing.Size(925, 591);
            this.tabModelExplorer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabModelExplorer.Location = new System.Drawing.Point(0, 0);
            this.tabModelExplorer.Name = "tabModelExplorer";
            this.tabModelExplorer.Padding = new System.Drawing.Point(6, 6);
            this.tabModelExplorer.Size = new System.Drawing.Size(925, 591);
            this.tabModelExplorer.TabIndex = 1;
            this.tabModelExplorer.ThemeStyle.PrimitiveButtonStyle.DisabledNextPageImage = null;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tabModelExplorer);
            this.panel1.Location = new System.Drawing.Point(172, 45);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(925, 591);
            this.panel1.TabIndex = 2;
            // 
            // MainTabModleexplore
            // 
            this.MainTabModleexplore.ForeColor = System.Drawing.Color.MidnightBlue;
            this.MainTabModleexplore.Image = null;
            this.MainTabModleexplore.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Insert1,
            this.print,
            this.DataCollector,
            this.Runpf});
            this.MainTabModleexplore.Location = new System.Drawing.Point(0, 0);
            this.MainTabModleexplore.Name = "MainTabModleexplore";
            this.MainTabModleexplore.Size = new System.Drawing.Size(1099, 42);
            this.MainTabModleexplore.TabIndex = 3;
            this.MainTabModleexplore.Text = " ";
            // 
            // Insert1
            // 
            this.Insert1.Image = ((System.Drawing.Image)(resources.GetObject("Insert1.Image")));
            this.Insert1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Insert1.Name = "Insert1";
            this.Insert1.Size = new System.Drawing.Size(32, 22);
            this.Insert1.Text = " ";
            this.Insert1.Click += new System.EventHandler(this.Insert1_Click);
            // 
            // print
            // 
            this.print.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.print.Image = ((System.Drawing.Image)(resources.GetObject("print.Image")));
            this.print.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.print.Name = "print";
            this.print.Size = new System.Drawing.Size(23, 22);
            this.print.Text = "toolStripButton1";
            // 
            // DataCollector
            // 
            this.DataCollector.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.DataCollector.Image = ((System.Drawing.Image)(resources.GetObject("DataCollector.Image")));
            this.DataCollector.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DataCollector.Name = "DataCollector";
            this.DataCollector.Size = new System.Drawing.Size(23, 22);
            this.DataCollector.Text = "Data Collector";
            this.DataCollector.Click += new System.EventHandler(this.DataCollector_Click);
            // 
            // Runpf
            // 
            this.Runpf.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Runpf.Image = ((System.Drawing.Image)(resources.GetObject("Runpf.Image")));
            this.Runpf.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Runpf.Name = "Runpf";
            this.Runpf.Size = new System.Drawing.Size(23, 22);
            this.Runpf.Text = "Runpf";
            this.Runpf.ToolTipText = "Runpf";
            this.Runpf.Click += new System.EventHandler(this.Runpf_Click);
            // 
            // ModelExplorer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1099, 648);
            this.Controls.Add(this.MainTabModleexplore);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.modelExplorerTree);
            this.Name = "ModelExplorer";
            this.Text = "ModelEcplorer";
            ((System.ComponentModel.ISupportInitialize)(this.tabModelExplorer)).EndInit();
            this.panel1.ResumeLayout(false);
            this.MainTabModleexplore.ResumeLayout(false);
            this.MainTabModleexplore.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView modelExplorerTree;
        private Syncfusion.Windows.Forms.Tools.TabControlAdv tabModelExplorer;
        private System.Windows.Forms.Panel panel1;
        private Syncfusion.Windows.Forms.Tools.ToolStripEx MainTabModleexplore;
        private System.Windows.Forms.ToolStripButton Insert1;
        private System.Windows.Forms.ToolStripButton print;
        private System.Windows.Forms.ToolStripButton DataCollector;
        private System.Windows.Forms.ToolStripButton Runpf;
    }
}