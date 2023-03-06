using GUI.Stability.Generator_Stability;
using persistent.enumeration;
using persistent.stability;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace GUI.Stability
{
    public partial class ModelTypeMenu : Form
    {

        private object selectedModel;
        private StabilityType type;
        private StabilityGeneratorTabEnum generatorTabEnum;

        public ModelTypeMenu( StabilityType stabilityType)
        {
            InitializeComponent();
            List<TreeNode> treeNodes = new List<TreeNode>();
            type = stabilityType;
            createTreeModelType(stabilityType, treeNodes);
           // ModelTypeTree.Nodes.AddRange(treeNodes);
        }
        public ModelTypeMenu(StabilityType stabilityType, StabilityGeneratorTabEnum generatorEnum)
        {
            InitializeComponent();
            List<TreeNode> treeNodes = new List<TreeNode>();
            type = stabilityType;
            generatorTabEnum = generatorEnum;
            createTreeModelType(generatorEnum, treeNodes);
         //   ModelTypeTree.Nodes.AddRange(treeNodes);
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
           // setSelectedModel();
        }

        private void PWOnly_CheckedChanged(object sender, EventArgs e)
        {
            PWOnly.Checked = true;

        }

        public void createTreeModelType(StabilityType stabilityType, List<TreeNode> treeNodes)
        {
            if (stabilityType.Equals(StabilityType.Line))
            {
                List<LineModelType> modelTypes = Enum.GetValues(typeof(LineModelType)).Cast<LineModelType>().ToList();
                foreach (LineModelType modelType in modelTypes)
                {
                    TreeNode node = new TreeNode();
                    node.Tag = modelType;
                    node.Text = modelType.ToString();
                    treeNodes.Add(node);
                }
            }
           
        }
        public void createTreeModelType(StabilityGeneratorTabEnum generatorTabEnum, List<TreeNode> treeNodes)
        {
            if (generatorTabEnum.Equals(StabilityGeneratorTabEnum.MachineModels))
            {
                List<GeneratorModelType> modelTypes = Enum.GetValues(typeof(GeneratorModelType)).Cast<GeneratorModelType>().ToList();
                foreach (GeneratorModelType modelType in modelTypes)
                {
                    TreeNode node = new TreeNode();
                    node.Tag = modelType;
                    node.Text = modelType.ToString();
                    treeNodes.Add(node);
                }
            }
            else if (generatorTabEnum.Equals(StabilityGeneratorTabEnum.Exciters))
            {
                List<GeneratorExcitersModelType> modelTypes = Enum.GetValues(typeof(GeneratorExcitersModelType)).Cast<GeneratorExcitersModelType>().ToList();

                foreach (GeneratorExcitersModelType modelType in modelTypes)
                {
                    TreeNode node = new TreeNode();
                    node.Tag = modelType;
                    node.Text = modelType.ToString();
                    treeNodes.Add(node);
                }

            }
            else if (generatorTabEnum.Equals(StabilityGeneratorTabEnum.Governors))
            {
                List<GeneratorGovernorsModelType> modelTypes = Enum.GetValues(typeof(GeneratorGovernorsModelType)).Cast<GeneratorGovernorsModelType>().ToList();

                foreach (GeneratorGovernorsModelType modelType in modelTypes)
                {
                    TreeNode node = new TreeNode();
                    node.Tag = modelType;
                    node.Text = modelType.ToString();
                    treeNodes.Add(node);
                }

            }
        }

        private object selection ; 
        private void Select_Click(object sender, EventArgs e)
        {
            if (selection != null)
            {
                setSelectedModel(selection);

               // selection = null;
            }
            this.Close();
        }

       
        public object getSelectedModel()
        {
            return selectedModel;
        }
        public void setSelectedModel(Object selection)
        {
            selectedModel = selection;
        }

       
    }
}
