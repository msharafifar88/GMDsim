using System;
using Telerik.WinControls.UI;

namespace GUI.customRadTreeView
{
    class CustomTreeView : RadTreeView
    {
        //Replace the default element with the custom one
        protected override RadTreeViewElement CreateTreeViewElement()
        {
            return new CustomTreeViewElement();
        }

       
    }
}
