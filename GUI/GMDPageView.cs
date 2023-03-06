using persistent.common;
using Syncfusion.Windows.Forms.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI
{
    public class GMDPageView : TabPageAdv
    {
        public ItemEnum GMDItem { get; set; }
        
        public GMDPageView (string s,ItemEnum item):base(s)
        {
            this.GMDItem = item;
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ResumeLayout(false);

        }

        public override bool Equals(object obj)
        {
            return obj is GMDPageView view &&
                   GMDItem == view.GMDItem;
        }

        public override int GetHashCode()
        {
            return -1872577240 + GMDItem.GetHashCode();
        }
    }
}
