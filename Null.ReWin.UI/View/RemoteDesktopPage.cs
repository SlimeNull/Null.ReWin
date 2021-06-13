using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Null.ReWin.UI.Module;

namespace Null.ReWin.UI.View
{
    public class RemoteDesktopPage : TabPage
    {
        public bool AutoClose { get; set; } = true;
        public ControlDragTable ControlDragTable { get; private set; }

        public RemoteDesktopPage() : base()
        {
            this.Controls.Add(ControlDragTable = new ControlDragTable()
            {
                Dock = DockStyle.Fill,
                CellBorderStyle = TableLayoutPanelCellBorderStyle.Single,
                RowCount = 1,
                ColumnCount = 1
            });

            ControlDragTable.ControlAdded += ControlDragTable_ControlAdded;
            ControlDragTable.ControlRemoved += ControlDragTable_ControlRemoved;

            ControlDragTable.ControlAdded += ControlDragTable_ControlChanged;
            ControlDragTable.ControlRemoved += ControlDragTable_ControlChanged;

            this.Text = "Empty blank";
        }

        private void ControlDragTable_ControlAdded(object sender, ControlEventArgs e)
        {
            (e.Control as RemoteDesktopControl).OnConnected += ControlDragTable_ControlChanged;
        }

        private void ControlDragTable_ControlChanged(object sender, EventArgs e)
        {
            if (ControlDragTable.Controls.Count == 0)
                this.Text = "Empty blank";
            else if (ControlDragTable.Controls.Count == 1)
                this.Text = (ControlDragTable.Controls[0] as RemoteDesktopControl).Text;
            else
                this.Text = (ControlDragTable.Controls[0] as RemoteDesktopControl).Text + " ... " + ControlDragTable.Controls.Count;
        }

        private void ControlDragTable_ControlRemoved(object sender, ControlEventArgs e)
        {
            if (ControlDragTable.IsEmpty && AutoClose)
                this.Dispose();
        }

        public bool TryAddConnection(RemoteDesktopControl control)
        {
            if (ControlDragTable.IsFull)
                return false;
            ControlDragTable.Controls.Add(control);
            return true;
        }

        public IEnumerable<RemoteDesktopControl> GetRemoteDesktopControls()
        {
            return ControlDragTable.Controls.OfType<RemoteDesktopControl>();
        }
    }
}
