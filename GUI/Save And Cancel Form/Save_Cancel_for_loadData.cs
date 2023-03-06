using BL;
using GUI.FileController;
using GUI.New_concept_WPF;
using System;
using System.Windows.Forms;

namespace GUI.Save_And_Cancel_Form
{
    public partial class Save_Cancel_for_loadData : Form
    {
        private FileBrowser fileBrowser;
        public Save_Cancel_for_loadData(FileBrowser fileBrowser)
        {
            InitializeComponent();
            this.fileBrowser = fileBrowser;
        }



        private void Save_Click(object sender, EventArgs e)
        {
            try

            {
                DataStore_Util datautil = new DataStore_Util();
                datautil.remove_Data(CustomContentControl.getCurrentCase());
                fileBrowser.SaveData(CustomContentControl.getCurrentCase());
                Close();
                fileBrowser.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show("An Error occurred during the loading process(Load File)" + ex.Message);
            }
        }
        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
