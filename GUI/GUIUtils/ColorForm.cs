using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.GUIUtils
{
/*    private Color labelForm = Color.DarkGreen;
    private Color headerInputData;
    private Color labelInputData;*/
    
    public class ColorForm
    {
        public static Color HeaderInputData()
        {
            return Color.DarkBlue;
        }
        public static Color LabelInputDataColor()
        {
            return Color.DarkGreen;
        }
        public static Color LabelFormColor()
        {
            return Color.DarkRed;
        }
        public static Color UnitLabelColor()
        {
            return Color.DarkOrange;
        }

        public static void ChangeCollorOFLabel(Control control)
        {
           
            if (control is TabPage)
            {
                TabPage tab = (TabPage)control;
                if (tab.Name.Contains("tab"))
                {
                  //  tab.ForeColor = UnitLabelColor();
                    tab.Font = new Font(Label.DefaultFont, FontStyle.Bold);
                }
            }
            if (control is GroupBox)
            {
                GroupBox group = (GroupBox)control;
                if (group.Name.Contains("group"))
                {
                    group.ForeColor = HeaderInputData();
                    group.Font = new Font(Label.DefaultFont, FontStyle.Bold);
                }
            }
            if (control is Label)
            {
                Label lbl = (Label)control;
                if (lbl.Name.StartsWith("label"))
                {
                    lbl.ForeColor = LabelInputDataColor();
                    lbl.Font = new Font(Label.DefaultFont, FontStyle.Bold);
                }
            }
            foreach (Control child in control.Controls)
                {
                    ChangeCollorOFLabel(child);
                }

        }
    }
}
