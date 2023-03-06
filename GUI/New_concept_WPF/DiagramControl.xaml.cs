using persistent.common;
using Syncfusion.UI.Xaml.Diagram.Utility;
using Syncfusion.UI.Xaml.TreeView;
using Syncfusion.UI.Xaml.TreeView.Engine;
using Syncfusion.Windows.Tools.Controls;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace GUI.New_concept_WPF
{
    /// <summary>
    /// Interaction logic for DiagramControl.xaml
    /// </summary>
    public partial class DiagramControl : UserControl
    {
        private static bool isLockedNode = false;
        private static ItemEnum clickedNode;
        private static bool isDragAndDrop = false;

        public DiagramControl()
        {
            InitializeComponent();
            this.sfTreeComponent.ItemDragStarting += Sftreeview_ItemDragStarting;
            this.sfTreeComponent.ItemTapped += SfTreeComponent_ItemTapped;
            this.sfTreeComponent.ItemDoubleTapped += SfTreeComponent_ItemDoubleTapped;
            this.dockingManager.ActiveWindowChanged += DockingManager_ActiveWindowChanged;
        }

        private int clicks = 0;
        private void SfTreeComponent_ItemDoubleTapped(object sender, Syncfusion.UI.Xaml.TreeView.ItemDoubleTappedEventArgs e)
        {
            if (e.Node.Content != null)
            {
                if (e.Node.Level > 0)
                {
                    clicks += 1;
                    DiagramControl.setIslockedNode(clicks == 1 ? false : true);
                    if (!DiagramControl.getIslockedNode())
                    {
                        clicks = 0;
                        Main_Menu.setIsTreeDoubleClicked(true);
                        DiagramControl.setIslockedNode(true);
                        DiagramControl.setClickedNode((e.Node.Content as TreeNodeWPF).EnumItem);
                    }
                }
            }
        }

        internal static bool getIslockedNode()
        {
            return DiagramControl.isLockedNode;
        }

        internal static void setIslockedNode(bool islocked)
        {
            DiagramControl.isLockedNode = islocked;
        }

        internal static ItemEnum getClickedNode()
        {
            return DiagramControl.clickedNode;
        }

        internal static void setClickedNode(ItemEnum node)
        {
            DiagramControl.clickedNode = node;
        }

        public static void SetIsDragAndDrop(bool isDragAndDrop_)
        {
            isDragAndDrop = isDragAndDrop_;
        }

        public static bool GetIsDragAndDrop()
        {
            return isDragAndDrop;
        }

        private void DockingManager_ActiveWindowChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue is CustomContentControl)
            {
                CustomContentControl.setCurrentCase((e.NewValue as CustomContentControl).getCase());
                if ((e.NewValue as CustomContentControl).Content is CustomDiagram)
                {
                    Main_Menu.SetCurrentDiagram((e.NewValue as CustomContentControl).Content as CustomDiagram);
                }
            }
        }

        private void SfTreeComponent_ItemTapped(object sender, Syncfusion.UI.Xaml.TreeView.ItemTappedEventArgs e)
        {
            if (!DiagramControl.getIslockedNode())
            {

                if ((e.Node.Content as TreeNodeWPF).ElementName != null)
                {
                    if (e.Node.Level > 0)
                    {
                        DiagramControl.setIslockedNode(true);
                    }
                    DiagramControl.setClickedNode((e.Node.Content as TreeNodeWPF).EnumItem);
                }
            }
        }

        private void Sftreeview_ItemDragStarting(object sender, TreeViewItemDragStartingEventArgs e)
        {
            //SetIsDragAndDrop(true);
            DragObject<TreeViewNode> dataObject = new DragObject<TreeViewNode>(e.DraggingNodes.First() as TreeViewNode);
            System.Windows.DragDrop.DoDragDrop(sender as DependencyObject, dataObject, DragDropEffects.Copy);

            //This e.Cancel is used to stop the position changes in treeview
            e.Cancel = true;
        }

        private void Docking_DockStateChanged(FrameworkElement sender, DockStateEventArgs e)
        {
            if (e.NewState == DockState.Hidden)
            {
                dockingManager.Children.Remove(sender);
            }
        }

        //    protected override AutomationPeer OnCreateAutomationPeer()
        //    {

        //        return new FakeUserControlPeer(this);

        //    }
        //}

        //public class FakeUserControlPeer : UserControlAutomationPeer 

        //{

        //    public FakeUserControlPeer(DiagramControl userControl) : base(userControl)
        //    { }

        //    protected override List<AutomationPeer> GetChildrenCore()
        //    {

        //        return null;

        //    }
        //}

    }

}
