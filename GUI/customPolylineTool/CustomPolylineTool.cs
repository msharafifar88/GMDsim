using Telerik.WinControls;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Diagrams;
using Telerik.Windows.Diagrams.Core;

namespace GUI.customPolylineTool
{
    public class CustomPolylineTool : ToolBase, IMouseListener, Telerik.Windows.Diagrams.Core.IKeyboardListener
    {
        public bool isToolActive { get; set; }
        public CustomPolylineTool(string name) : base(name)
        {
            this.Name = name;
            this.isToolActive = true;
            
        }

        IConnection currentConnection = null;
        Point lastPoint;

        public bool KeyDown(KeyArgs key)
        {
            /*if (IsActive && key.Key == System.Windows.Input.Key.Enter)
            {
                this.currentConnection.EndPoint = this.lastPoint;
                this.currentConnection.Update();
                this.DeactivateTool();
                return true;
            }*/
            return false;
        }

        public bool KeyUp(KeyArgs key)
        {
            return false;
        }

        public virtual bool MouseDown(PointerArgs e)
        {
            if (this.ToolService.ActiveTool != null && this.ToolService.ActiveTool.Name.Equals(this.Name))
            {
                if (this.currentConnection == null)
                {
                    this.currentConnection = new RadDiagramConnection();
                    this.currentConnection.StartPoint = e.TransformedPoint;
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
            return false;
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

            

            /*var size = this.currentConnection.Bounds.ToSize();
            var shapeToAdd = new RadDiagramShape()
            {
                Width = size.Width + 1,
                Height = size.Height + 1,
                BackColor = Color.FromRgb(100,100,100),
                Geometry = this.currentConnection.Geometry,
                Position = new Point(this.currentConnection.Position.X - 0.5, this.currentConnection.Position.Y - 0.5)
            };
            this.Graph.Items.Remove((RadElement)this.currentConnection);
            this.Graph.Items.Add(shapeToAdd);*/
            this.isToolActive = false;
            this.Graph.AddConnection(this.currentConnection);
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
            
            return false;
        }

        public bool MouseDoubleClick(PointerArgs e)
        {
            if (IsActive)
            {
                this.currentConnection.EndPoint = this.lastPoint;
                this.currentConnection.Update();
                this.DeactivateTool();
                return true;
            }
            return false;
        }

        public void stopCustomPolylineTool() {
            if (IsActive)
            {
                this.currentConnection.EndPoint = this.lastPoint;
                this.currentConnection.Update();
                this.DeactivateTool();
            }

        }
    }
}
