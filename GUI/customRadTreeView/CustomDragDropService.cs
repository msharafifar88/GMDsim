using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Diagrams;
using persistent;
using GUI.customDocumentWindow;
using GUI.New_concept;
using GUI.New_concept_WPF;

namespace GUI.customRadTreeView
{
    class CustomDragDropService : TreeViewDragDropService
    {
        Case cases = null;
        RadTreeViewElement owner;
        //Initialize the service
        public CustomDragDropService(RadTreeViewElement owner) : base(owner)
        {
            this.owner = owner;
        }

        //If tree element is hovered, allow drop
        protected override void OnPreviewDragStart(PreviewDragStartEventArgs e)
        {
            base.OnPreviewDragStart(e);
            TreeNodeElement targetTreeView = e.DragInstance as TreeNodeElement;

            if (!ToolDiagram_Form.getIsLockedCreation())
            {
                if (e.DragInstance is TreeNodeElement && !targetTreeView.IsRootNode)
                {
                    e.CanStart = true;
                    targetTreeView.TreeViewElement.AllowDragDrop = true;
                }
                else if (targetTreeView.IsRootNode)
                {
                    targetTreeView.TreeViewElement.AllowDragDrop = false;
                }
            }
        }

        //protected override
        protected override void OnPreviewDragOver(RadDragOverEventArgs e)
        {
            base.OnPreviewDragOver(e);
            if (e.DragInstance is TreeNodeElement)
            {
                cases = CustomContentControl.getCurrentCase();
                e.CanDrop = e.HitTarget is RadDiagramElement;
            }
        }
        //Create copies of the selected node(s) and add them to the hovered node/tree
        protected override void OnPreviewDragDrop(RadDropEventArgs e)
        {
            if (!ToolDiagram_Form.getIsLockedCreation())
            {

                RadDiagramShape shape = null;
                RadDiagramElement targetElement = e.HitTarget as RadDiagramElement;
                TreeNodeElement targetTreeView = e.DragInstance as TreeNodeElement;
                cases = CustomContentControl.getCurrentCase();
                //MessageBox.Show(cases.name);
                /*if (targetTreeView == this.owner)
                {
                    base.OnPreviewDragDrop(e);
                    return;
                } */
                if (targetTreeView == null)
                {
                    return;
                }
                else if (targetTreeView.Data != null)
                {
                    var selection = targetTreeView.Data.Text;
                    shape = UtilitiesShape.shapeTree_selector(selection, cases);
                    if (!targetTreeView.IsRootNode)
                    {
                        ToolDiagram_Form.setIsLockedCreation(true);
                    }
                }
                shape.Size = new System.Drawing.Size(70, 70);
                shape.DiagramShapeElement.TextImageRelation = TextImageRelation.ImageBeforeText;
                shape.Position = e.DropLocation;
                targetElement.AddShape(shape);
                ToolDiagram_Form.setIsLockedCreation(false);
            }

        }
    }

}
