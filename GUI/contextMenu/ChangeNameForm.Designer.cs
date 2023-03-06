
namespace GUI.contextMenu
{
    partial class ChangeNameForm
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
            this.Namelabel = new System.Windows.Forms.Label();
            this.Savebutton = new System.Windows.Forms.Button();
            this.Cancelbutton = new System.Windows.Forms.Button();
            this.textNameBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Namelabel
            // 
            this.Namelabel.AutoSize = true;
            this.Namelabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Namelabel.Location = new System.Drawing.Point(25, 36);
            this.Namelabel.Name = "Namelabel";
            this.Namelabel.Size = new System.Drawing.Size(55, 20);
            this.Namelabel.TabIndex = 0;
            this.Namelabel.Text = "Name:";
            // 
            // Savebutton
            // 
            this.Savebutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Savebutton.Location = new System.Drawing.Point(228, 89);
            this.Savebutton.Name = "Savebutton";
            this.Savebutton.Size = new System.Drawing.Size(161, 36);
            this.Savebutton.TabIndex = 1;
            this.Savebutton.Text = "Save";
            this.Savebutton.UseVisualStyleBackColor = true;
            this.Savebutton.Click += new System.EventHandler(this.Savebutton_Click);
            // 
            // Cancelbutton
            // 
            this.Cancelbutton.Location = new System.Drawing.Point(228, 131);
            this.Cancelbutton.Name = "Cancelbutton";
            this.Cancelbutton.Size = new System.Drawing.Size(161, 35);
            this.Cancelbutton.TabIndex = 2;
            this.Cancelbutton.Text = "Cancel";
            this.Cancelbutton.UseVisualStyleBackColor = true;
            this.Cancelbutton.Click += new System.EventHandler(this.Cancelbutton_Click);
            // 
            // textNameBox
            // 
            this.textNameBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textNameBox.Location = new System.Drawing.Point(107, 32);
            this.textNameBox.Name = "textNameBox";
            this.textNameBox.Size = new System.Drawing.Size(282, 28);
            this.textNameBox.TabIndex = 3;
        
            // 
            // ChangeNameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 189);
            this.Controls.Add(this.textNameBox);
            this.Controls.Add(this.Cancelbutton);
            this.Controls.Add(this.Savebutton);
            this.Controls.Add(this.Namelabel);
            this.Name = "ChangeNameForm";
            this.Text = "Name Menu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Namelabel;
        private System.Windows.Forms.Button Savebutton;
        private System.Windows.Forms.Button Cancelbutton;
        private System.Windows.Forms.TextBox textNameBox;
    }
}