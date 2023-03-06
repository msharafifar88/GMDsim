
using DAO;
using persistent.common;
using System.Collections.Generic;

namespace BL
{
    public class TreeNodeCreator
    {

        public void init()
        {
            DataStored.addRootNode();
        }
        public List<GMDSimTreeNode> findRootNode()
        {
            return DataStored.fetchRootTree();
        }
        public List<GMDSimTreeNode> findChildNode(GMDSimTreeNode s)
        {
            return DataStored.fetchChildTreeNode(s);
        }
        public string findImageNode(GMDSimTreeNode s)
        {
            return DataStored.fetchRootTree(s);
        }
    }
}
