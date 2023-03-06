using System;
using Telerik.WinControls.UI;

namespace GUI.customRadTreeView
{
    class CustomTreeViewElement : RadTreeViewElement
    {
        //Enable themeing for the element
        protected override Type ThemeEffectiveType
        {
            get
            {
                return typeof(RadTreeViewElement);
            }
        }
        //Replace the default drag drop service with the custom one
        protected override TreeViewDragDropService CreateDragDropService()
        {
            return new CustomDragDropService(this);
        }
    }
}
