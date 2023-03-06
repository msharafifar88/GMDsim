using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.Transformer
{
    public class TransformersItem
    {
        public string Value
        {
            get { return value; }
            set { this.value = value; }
        }
        private string value;

        public Image Image
        {
            get { return img; }
            set { img = value; }
        }
        private Image img;

        public TransformersItem() : this("")
        { }

        public TransformersItem(string val)
        {
            value = val;
            this.img = new Bitmap(16, 16);
            Graphics g = Graphics.FromImage(img);
            Brush b = new SolidBrush(Color.FromName(val));
            g.DrawRectangle(Pens.White, 0, 0, img.Width, img.Height);
            g.FillRectangle(b, 1, 1, img.Width - 1, img.Height - 1);
        }

        public override string ToString()
        {
            return value;
        }
    }
}
