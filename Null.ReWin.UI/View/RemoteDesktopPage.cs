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

            ControlDragTable.ControlRemoved += ControlDragTable_ControlRemoved;
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
