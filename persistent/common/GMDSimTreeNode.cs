using System.Collections.Generic;

namespace persistent.common
{
    public class GMDSimTreeNode
    {

        static List<GMDSimTreeNode> treeNodes = new List<GMDSimTreeNode>();
        public ItemEnum item { get; }
        public string name { get; }
        public GMDSimTreeNode parent { get; }

        public GMDSimTreeNode(ItemEnum item, string name, GMDSimTreeNode parent)
        {
            this.item = item;
            this.name = name;
            this.parent = parent;
        }

        public override bool Equals(object obj)
        {
            return obj is GMDSimTreeNode node &&
                   item.Equals(node.item) &&
                   name.Equals(node.name) &&
                   EqualityComparer<GMDSimTreeNode>.Default.Equals(parent, node.parent);
        }

        public override int GetHashCode()
        {
            int hashCode = -1210340839;
            hashCode = hashCode * -1521134295 + item.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(name);
            hashCode = hashCode * -1521134295 + EqualityComparer<GMDSimTreeNode>.Default.GetHashCode(parent);
            return hashCode;
        }
    }
}
