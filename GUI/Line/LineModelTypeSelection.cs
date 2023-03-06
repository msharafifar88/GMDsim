using bases;
using persistent.enumeration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.Line
{
    public partial class LineModelTypeSelection : Form
    {
        public LineModelTypeSelection()
        {
            InitializeComponent();
            init();
        }
        private void init()
        {
            List<TreeNode> treeNodes = new List<TreeNode>();
            List<LineModelType> modelTypes = Enum.GetValues(typeof(LineModelType)).Cast<LineModelType>().ToList();
            foreach(LineModelType modelType in modelTypes)
            {
                TreeNode node = new TreeNode();
                node.Tag = modelType;
                node.Text = modelType.ToString();
                treeNodes.Add(node);
            }
            ModelTypeTree.Nodes.AddRange(treeNodes.ToArray());
        }
    }
}
