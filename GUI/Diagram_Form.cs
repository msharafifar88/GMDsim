using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using Telerik.Windows.Diagrams.Core;
using Point = System.Drawing.Point;

namespace GUI
{

    public partial class Diagram_Form : Telerik.WinControls.UI.RadForm
    {

        static private int counterForms;
        private RadDiagramShape generalShape { get; set; }
        private Point position { get; set; }
        private RoutedEvent doubleClickOnShape { get; set; }
        public Diagram_Form()
        {
            InitializeComponent();
            Diagram_Form.setCounter(Diagram_Form.getCounter() + 1);
            this.doubleClickOnShape = null;
            this.generalShape = null;
            this.Text = ("Case " + Diagram_Form.getCounter());
            this.BackDiagram.ShapeDoubleClicked += BackDiagram_ShapeDoubleClicked;
            this.Update();
        }

        //getCounter() returns the value of the number of diagrams that were created on the current session
        private static int getCounter()
        {
            return counterForms;
        }

        //serCounter() sets the number of created diagrams if the parameter is higher than 0.
        private static void setCounter(int newVal)
        {
            if (newVal > 0)
            {
                Diagram_Form.counterForms = newVal;
            }
            else
            {
                MessageBox.Show("Invalid Value");
            }

        }

        //BackDiagram_MouseClick is an event that create an instance of a shape at the position where the mouse is clicked
        private void BackDiagram_MouseClick(object sender, MouseEventArgs e)
        {
            this.generalShape = MainMenu.getShape();
            if (this.generalShape != null)
            {
                Telerik.WinControls.Layouts.RadMatrix transform = this.BackDiagram.DiagramElement.MainPanel.TotalTransform;
                transform.Invert();
                var transformedPosition = transform.TransformPoint(e.Location);
                this.position = Point.Round(transformedPosition);
                shapeCreation();
            }
            BackDiagram.Refresh();
        }

        //shapeCreation() deals with the instantiation of a particular shape, 
        //and added to a RadShapeContainer. It feeds information to Main_Menu through setShape. 
        private void shapeCreation()
        {
            generalShape.Size = new System.Drawing.Size(70, 70);
            generalShape.DiagramShapeElement.TextImageRelation = TextImageRelation.ImageBeforeText;
            generalShape.Position = this.position;
            container.Items.Add(generalShape);
            MainMenu.setShape(null);
        }

        //BackDiagram_ShapeDoubleClicked trigger a form when the user double click in a shape within the diagram.
        private void BackDiagram_ShapeDoubleClicked(object sender, Telerik.WinControls.UI.Diagrams.ShapeRoutedEventArgs e)
        {
            doubleClickOnShape = e.RoutedEvent;
            if (doubleClickOnShape != null)
            {
                if (e.Shape.IsEditable)
                {
                    //Allows to retrieve the information contained on a instance of RadDiagramShape
                    RadDiagramShape shape = (RadDiagramShape)this.BackDiagram.Shapes.Where(keyParam => keyParam.Id == e.Shape.Id).FirstOrDefault();
                    MessageBox.Show("Placeholder for form" + shape.Id);
                    //TODO: Trigger forms for update component's content using its id.
                }
            }
        }

        private void BackDiagram_Click(object sender, EventArgs e)
        {

        }
    }
}

