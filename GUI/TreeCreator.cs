using BL;
using GUI.New_concept_WPF;
using persistent.common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace GUI
{
    public class TreeCreator
    {
        /*public List<RadTreeNode> treeCreator()
        {
            List<RadTreeNode> radTreeNodes = new List<RadTreeNode>();
            TreeNodeCreator treeNodeCreator = new TreeNodeCreator();
            foreach (TreeNode treeNode in treeNodeCreator.findRootNode())
            {
                RadTreeNode radTreeNode = new RadTreeNode();
                radTreeNode.Text = treeNode.name;
                radTreeNode.ImageKey = treeNodeCreator.findImageNode(treeNode);
                radTreeNode.Value = treeNode;
                List<RadTreeNode> childList = findChild(treeNode);
                if (childList != null && childList.Count > 0)
                {
                    radTreeNode.Nodes.AddRange(childList);
                }
                radTreeNodes.Add(radTreeNode);
            }
            return radTreeNodes;
        }*/

        ///////
        public List<TreeNode> treeCreator()
        {
            List<TreeNode> treeNodes = new List<TreeNode>();
            TreeNodeCreator treeNodeCreator = new TreeNodeCreator();
            foreach (GMDSimTreeNode treeNode in treeNodeCreator.findRootNode())
            {
                TreeNode tree = new TreeNode();
                tree.Text = treeNode.name;
                tree.ImageKey = treeNodeCreator.findImageNode(treeNode);
                tree.Tag = treeNode;
                List<TreeNode> childList = findChild(treeNode);
                if (childList != null && childList.Count > 0)
                {
                    tree.Nodes.AddRange(childList.ToArray());
                }
                treeNodes.Add(tree);
            }
            return treeNodes;
        }

        private List<TreeNode> findChild(GMDSimTreeNode gMDSimTree)
        {
            TreeNodeCreator treeNodeCreator = new TreeNodeCreator();
            List<TreeNode> treeNodeList = new List<TreeNode>();
            foreach (var child in treeNodeCreator.findChildNode(gMDSimTree))
            {
                TreeNode node = new TreeNode();
                node.Text = child.name;
                node.Tag = child;
                node.ImageKey = treeNodeCreator.findImageNode(child);
                treeNodeList.Add(node);
            }
            return treeNodeList;
        }

        public ObservableCollection<TreeNodeWPF> CreateWpfTree()
        {
            ObservableCollection<TreeNodeWPF> treenodemain = new ObservableCollection<TreeNodeWPF>();
            TreeNodeCreator treeNodeCreator = new TreeNodeCreator();
            foreach (GMDSimTreeNode treeNode in treeNodeCreator.findRootNode())
            {
                TreeNodeWPF wpfTreeNode = new TreeNodeWPF();
                wpfTreeNode.ElementName = treeNode.name;
                /*   Uri uri = new Uri(treeNodeCreator.findImageNode(treeNode));
                   wpfTreeNode.ElementIcon = new BitmapImage(uri);*/
                wpfTreeNode.EnumItem = treeNode.item;
                ObservableCollection<TreeNodeWPF> childList = findWpfTreeChild(treeNode);
                // findWpfTreeChild(treeNode);
                if (childList != null && childList.Count > 0)
                {
                    wpfTreeNode.SubFiles = childList;
                }
                treenodemain.Add(wpfTreeNode);
            }
            return treenodemain;
        }

        private ObservableCollection<TreeNodeWPF> findWpfTreeChild(GMDSimTreeNode gMDSimTree)
        {
            TreeNodeCreator treeNodeCreator = new TreeNodeCreator();
            ObservableCollection<TreeNodeWPF> treeNodeWPFs = new ObservableCollection<TreeNodeWPF>();
            foreach (var child in treeNodeCreator.findChildNode(gMDSimTree))
            {
                TreeNodeWPF node = new TreeNodeWPF();
                node.ElementName = child.name;
                node.EnumItem = child.item;
                // node.ImageKey = treeNodeCreator.findImageNode(child);
                treeNodeWPFs.Add(node);
            }
            return treeNodeWPFs;
        }

        public static BitmapSource ImageSourceFromBitmap(Bitmap bitmap)
        {
            if (bitmap == null)
                throw new ArgumentNullException("bitmap");

            var rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);

            var bitmapData = bitmap.LockBits(
                rect,
                ImageLockMode.ReadWrite,
                System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            try
            {
                var size = (rect.Width * rect.Height) * 4;

                return BitmapSource.Create(
                    bitmap.Width,
                    bitmap.Height,
                    bitmap.HorizontalResolution,
                    bitmap.VerticalResolution,
                    PixelFormats.Bgra32,
                    null,
                    bitmapData.Scan0,
                    size,
                    bitmapData.Stride);
            }
            finally
            {
                bitmap.UnlockBits(bitmapData);
            }
        }
    }
}
