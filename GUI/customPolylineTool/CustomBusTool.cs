using GUI.customRadDiagramConnection;
using System;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Docking;
using Telerik.Windows.Diagrams.Core;

namespace GUI.customPolylineTool
{
    public class CustomBusTool : ToolBase, IMouseListener,Telerik.Windows.Diagrams.Core.IKeyboardListener
    {
        public CustomBusTool(string name) : base(name)
        {
            this.Name = name;
            
        }

        IConnection currentConnection = null;
        Point lastPoint;


        public bool KeyDown(KeyArgs key)
        {
            MessageBox.Show(key.Key.ToString());
            if (IsActive && MainMenu.getKey().KeyCode.ToString().Equals("Return"))
            {
                this.currentConnection.EndPoint = this.lastPoint;
                this.currentConnection.Update();
                this.DeactivateTool();
                return true;
            }
            return false;
        }

        /*
         this wont work
        private void DragDropService_PreviewDragDrop(object sender, RadDropEventArgs e)
        {
            var diagramElement = e.HitTarget as RadDiagramElement;

            //  MessageBox.Show("1233");

            var result = CheckOverlap(diagramElement.Items.ToList());
            if (result.Item1)
            {
                RadDiagramConnection connection1 = new RadDiagramConnection() { Name = "connection1" };

                connection1.Source = (IShape)result.Item2;
                connection1.Target = (IShape)result.Item3;

                radDiagram1.Items.Add(connection1);
            }
        }

        private (bool, RadElement, RadElement) CheckOverlap(List<RadElement> oldItems)
        {
            if (oldItems.Count < 2)
                return (false, null, null);

            RadElement newItem = oldItems.Last();
            oldItems.RemoveLast();


            // newItem.LocationToControl().X>  old.LocationToControl().X-10
            var sameX = oldItems.Where(old => newItem.LocationToControl().X > old.LocationToControl().X - 20
                && newItem.LocationToControl().X < old.LocationToControl().X + 20).ToList();

            var sameY = sameX.Where(old => newItem.LocationToControl().Y > old.LocationToControl().Y - 20
                && newItem.LocationToControl().Y < old.LocationToControl().Y + 20).ToList();

            if (sameY.Any())
            {
                return (true, newItem, sameY.First());
            }
            else
                return (false, null, null);
        }
    }
        */

    
    public bool KeyUp(KeyArgs key)
        {
            return false;
        }

        HitTestService hitTestService = null;
        public virtual bool MouseDown(PointerArgs e)
        {
            try
            { 
                if (this.ToolService.ActiveTool != null && this.ToolService.ActiveTool.Name.Equals(this.Name))
                {
                    //var selectionService = Graph.ServiceLocator.GetService<ISelectionService<IDiagramItem>>() as SelectionService;
                    hitTestService = MainMenu.getDiagram().ServiceLocator.GetService<IHitTestService>() as HitTestService;
                    // MessageBox.Show(hitTestService.ItemUnderMouse.GetType().ToString());
                    if (this.currentConnection == null)
                    {

                        this.currentConnection = new CustomRadDiagramConnection(System.Drawing.Color.FromArgb(150, 45, 90), "test");
                        //this.currentConnection = new RadDiagramConnection();
                        //this.currentConnection.ConnectionType = ConnectionType.Polyline;
                        this.currentConnection.StartPoint = e.TransformedPoint;
                        if (hitTestService.ShapeUnderMouse != null)
                        {

                            this.currentConnection.Source = hitTestService.ShapeUnderMouse;
                        }
                        this.currentConnection.EndPoint = this.lastPoint = e.TransformedPoint;
                        this.Graph.Items.Add((RadElement)this.currentConnection);
                        return true;
                    }
                    else
                    {
                        this.currentConnection.ConnectionPoints.Add(lastPoint);
                        this.currentConnection.EndPoint = this.lastPoint = e.TransformedPoint;
                        this.currentConnection.Update();
                        return true;
                    }
                }
            }
            catch (NullReferenceException)
            {

                MessageBox.Show("Not working");
            }
            return true;
        }

        protected override void OnActivated()
        {
            base.OnActivated();

            this.lastPoint = new Point(0, 0);
            this.currentConnection = null;
        }

        protected override void OnDeactivated()
        {
            base.OnDeactivated();

            this.ToolService.ActivateTool("Pointer Tool");

            //this.Graph.Items.Remove((RadElement)this.currentConnection);

            //var size = this.currentConnection.Geometry.Bounds.ToSize();
            /*var size = this.currentConnection.Bounds.ToSize();
            var shapeToAdd = new RadDiagramShape()
            {
                Width = size.Width + 1,
                Height = size.Height + 1,
                Geometry = this.currentConnection.Geometry,
                Position = new Point(this.currentConnection.Position.X - 0.5, this.currentConnection.Position.Y - 0.5)
            };*/
            //this.Graph.Items.Add(shapeToAdd);
            this.Graph.AddConnection(currentConnection);
            //MainMenu.getDiagram().AddConnection(currentConnection);
        }

        public virtual bool MouseMove(PointerArgs e)
        {
            if (this.currentConnection != null && this.IsActive)
            {
                this.currentConnection.EndPoint = this.lastPoint = e.TransformedPoint;
                this.currentConnection.Update();
                return true;
            }
            return false;
        }

        public virtual bool MouseUp(PointerArgs e)
        {
            if (IsActive)
            {
                if (hitTestService.ShapeUnderMouse != null)
                {
                    this.currentConnection.Target = hitTestService.ShapeUnderMouse;
                }
                this.currentConnection.EndPoint = this.lastPoint;
                this.currentConnection.Update();
                this.DeactivateTool();
                return true;
            }
            return false;
        }

        public bool MouseDoubleClick(PointerArgs e)
        {
            /*if (IsActive)
            {
                this.currentConnection.EndPoint = this.lastPoint;
                this.currentConnection.Update();
                this.DeactivateTool();
                return true;
            }*/
            return false;
        }

        
    }

}

