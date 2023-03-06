using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace GUI.contextMenu
{
    public partial class ContextMenu : Telerik.WinControls.UI.RadForm
    {
        public ContextMenu()
        {
            InitializeComponent();
            this.AllowTheming = true;
            this.FormElement.TitleBar.Visibility = ElementVisibility.Collapsed;
            this.FormElement.TitleBar.CloseButton.Visibility = ElementVisibility.Hidden;
        }

        private void radButton1_Click(object sender, EventArgs e)
        {

        }

        private void radDeleteButton_Click(object sender, EventArgs e)
        {

        }

        private void radDuplicateButton_Click(object sender, EventArgs e)
        {

        }

        private void radCopyButton_Click(object sender, EventArgs e)
        {

        }

        private void radCutButton_Click(object sender, EventArgs e)
        {

        }

        private void radRotateMinusQuarterButton_Click(object sender, EventArgs e)
        {

        }

        private void radRotateHalfButton_Click(object sender, EventArgs e)
        {

        }

        private void radRotateQuarterButton_Click(object sender, EventArgs e)
        {

        }

        private void radRotateZeroButton_Click(object sender, EventArgs e)
        {

        }

        private void radNameButton_Click(object sender, EventArgs e)
        {

        }

        private void panelProperties_MouseLeave(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ContextMenu_Leave(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
