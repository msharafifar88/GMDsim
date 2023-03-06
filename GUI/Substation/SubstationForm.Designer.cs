namespace GUI.Substation
{
    partial class SubstationForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.substationLatitudebox = new Syncfusion.Windows.Forms.Tools.DoubleTextBox();
            this.substationLongitudebox = new Syncfusion.Windows.Forms.Tools.DoubleTextBox();
            this.substationGrwndGridbox = new Syncfusion.Windows.Forms.Tools.DoubleTextBox();
            this.substationNumbox = new Syncfusion.Windows.Forms.Tools.DoubleTextBox();
            this.nametxt = new System.Windows.Forms.TextBox();
            this.Growndgridlable = new System.Windows.Forms.Label();
            this.longitudelable = new System.Windows.Forms.Label();
            this.laitiudelable = new System.Windows.Forms.Label();
            this.NumberLablel = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.saveBTN = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.substationLatitudebox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.substationLongitudebox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.substationGrwndGridbox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.substationNumbox)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.substationLatitudebox);
            this.panel1.Controls.Add(this.substationLongitudebox);
            this.panel1.Controls.Add(this.substationGrwndGridbox);
            this.panel1.Controls.Add(this.substationNumbox);
            this.panel1.Controls.Add(this.nametxt);
            this.panel1.Controls.Add(this.Growndgridlable);
            this.panel1.Controls.Add(this.longitudelable);
            this.panel1.Controls.Add(this.laitiudelable);
            this.panel1.Controls.Add(this.NumberLablel);
            this.panel1.Controls.Add(this.nameLabel);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(297, 172);
            this.panel1.TabIndex = 0;
            // 
            // substationLatitudebox
            // 
            this.substationLatitudebox.DoubleValue = 1D;
            this.substationLatitudebox.Location = new System.Drawing.Point(194, 63);
            this.substationLatitudebox.Name = "substationLatitudebox";
            this.substationLatitudebox.Size = new System.Drawing.Size(100, 20);
            this.substationLatitudebox.TabIndex = 9;
            this.substationLatitudebox.Text = "1.00";
            // 
            // substationLongitudebox
            // 
            this.substationLongitudebox.DoubleValue = 1D;
            this.substationLongitudebox.Location = new System.Drawing.Point(194, 89);
            this.substationLongitudebox.Name = "substationLongitudebox";
            this.substationLongitudebox.Size = new System.Drawing.Size(100, 20);
            this.substationLongitudebox.TabIndex = 8;
            this.substationLongitudebox.Text = "1.00";
            // 
            // substationGrwndGridbox
            // 
            this.substationGrwndGridbox.DoubleValue = 1D;
            this.substationGrwndGridbox.Location = new System.Drawing.Point(194, 115);
            this.substationGrwndGridbox.Name = "substationGrwndGridbox";
            this.substationGrwndGridbox.Size = new System.Drawing.Size(100, 20);
            this.substationGrwndGridbox.TabIndex = 7;
            this.substationGrwndGridbox.Text = "1.00";
            // 
            // substationNumbox
            // 
            this.substationNumbox.DoubleValue = 1D;
            this.substationNumbox.Location = new System.Drawing.Point(194, 35);
            this.substationNumbox.Name = "substationNumbox";
            this.substationNumbox.NumberDecimalDigits = 0;
            this.substationNumbox.Size = new System.Drawing.Size(100, 20);
            this.substationNumbox.TabIndex = 6;
            this.substationNumbox.Text = "1";
            // 
            // nametxt
            // 
            this.nametxt.Location = new System.Drawing.Point(194, 9);
            this.nametxt.Name = "nametxt";
            this.nametxt.Size = new System.Drawing.Size(100, 20);
            this.nametxt.TabIndex = 5;
            // 
            // Growndgridlable
            // 
            this.Growndgridlable.AutoSize = true;
            this.Growndgridlable.Location = new System.Drawing.Point(6, 122);
            this.Growndgridlable.Name = "Growndgridlable";
            this.Growndgridlable.Size = new System.Drawing.Size(144, 13);
            this.Growndgridlable.TabIndex = 4;
            this.Growndgridlable.Text = "Ground Grid Resistance (Ω) :";
            // 
            // longitudelable
            // 
            this.longitudelable.AutoSize = true;
            this.longitudelable.Location = new System.Drawing.Point(6, 96);
            this.longitudelable.Name = "longitudelable";
            this.longitudelable.Size = new System.Drawing.Size(60, 13);
            this.longitudelable.TabIndex = 3;
            this.longitudelable.Text = "Longitude :";
            // 
            // laitiudelable
            // 
            this.laitiudelable.AutoSize = true;
            this.laitiudelable.Location = new System.Drawing.Point(6, 70);
            this.laitiudelable.Name = "laitiudelable";
            this.laitiudelable.Size = new System.Drawing.Size(50, 13);
            this.laitiudelable.TabIndex = 2;
            this.laitiudelable.Text = "Laitiude :";
            // 
            // NumberLablel
            // 
            this.NumberLablel.AutoSize = true;
            this.NumberLablel.Location = new System.Drawing.Point(6, 42);
            this.NumberLablel.Name = "NumberLablel";
            this.NumberLablel.Size = new System.Drawing.Size(44, 13);
            this.NumberLablel.TabIndex = 1;
            this.NumberLablel.Text = "Number";
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(6, 16);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(44, 13);
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "Name : ";
            // 
            // saveBTN
            // 
            this.saveBTN.Location = new System.Drawing.Point(12, 214);
            this.saveBTN.Name = "saveBTN";
            this.saveBTN.Size = new System.Drawing.Size(75, 23);
            this.saveBTN.TabIndex = 1;
            this.saveBTN.Text = "Save";
            this.saveBTN.UseVisualStyleBackColor = true;
            this.saveBTN.Click += new System.EventHandler(this.saveBTN_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(231, 214);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // SubstationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(321, 262);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.saveBTN);
            this.Controls.Add(this.panel1);
            this.Name = "SubstationForm";
            this.Text = "SubstationForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.substationLatitudebox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.substationLongitudebox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.substationGrwndGridbox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.substationNumbox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Syncfusion.Windows.Forms.Tools.DoubleTextBox substationNumbox;
        private System.Windows.Forms.TextBox nametxt;
        private System.Windows.Forms.Label Growndgridlable;
        private System.Windows.Forms.Label longitudelable;
        private System.Windows.Forms.Label laitiudelable;
        private System.Windows.Forms.Label NumberLablel;
        private System.Windows.Forms.Label nameLabel;
        private Syncfusion.Windows.Forms.Tools.DoubleTextBox substationLatitudebox;
        private Syncfusion.Windows.Forms.Tools.DoubleTextBox substationLongitudebox;
        private Syncfusion.Windows.Forms.Tools.DoubleTextBox substationGrwndGridbox;
        private System.Windows.Forms.Button saveBTN;
        private System.Windows.Forms.Button button2;
    }
}