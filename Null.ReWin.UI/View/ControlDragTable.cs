using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Null.ReWin.UI.View
{
    public class ControlDragTable : TableLayoutPanel
    {
        private bool acceptPlaceControl;

        class ControlPlaceData : DataObject
        {
            public ControlPlaceData(Control control)
            {
                SourceControl = control;
            }
            public Control SourceControl { get; private set; }
        }

        public override bool AllowDrop
        {
            get => base.AllowDrop; set
            {
                base.AllowDrop = value;
                if (!value)
                    AcceptPlaceControl = false;
            }
        }
        public bool AcceptPlaceControl
        {
            get => acceptPlaceControl; set
            {
                acceptPlaceControl = value;
                if (value)
                    AllowDrop = true;
            }
        }

        private void Control_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button.HasFlag(MouseButtons.Left))
                (sender as Control).DoDragDrop(new ControlPlaceData(sender as Control), DragDropEffects.All);
        }
        private void UpdateLayout()
        {
            int
                rowCount = RowCount,
                colCount = ColumnCount;

            foreach (Control control in Controls)
            {
                TableLayoutPanelCellPosition pos = GetPositionFromControl(control);
                if (pos.Row >= rowCount)
                    rowCount = pos.Row + 1;
                if (pos.Column >= ColumnCount)
                    colCount = pos.Column + 1;
            }

            SuspendLayout();
            RowCount = rowCount;
            ColumnCount = colCount;
            for (int i = RowStyles.Count; i < rowCount; i++)
                RowStyles.Add(new RowStyle());
            for (int i = ColumnStyles.Count; i < colCount; i++)
                ColumnStyles.Add(new ColumnStyle());

            foreach (RowStyle style in RowStyles)
            {
                style.SizeType = SizeType.Percent;
                style.Height = 1f / rowCount;
            }
            foreach (ColumnStyle style in ColumnStyles)
            {
                style.SizeType = SizeType.Percent;
                style.Width = 1f / colCount;
            }
            ResumeLayout();
        }
        protected override void OnControlAdded(ControlEventArgs e)
        {
            UpdateLayout();
            e.Control.MouseMove += Control_MouseMove;

            base.OnControlAdded(e);
        }
        protected override void OnDragDrop(DragEventArgs drgevent)
        {
            if (AcceptPlaceControl && drgevent.Data is ControlPlaceData data)
            {
                Point clientPoint = this.PointToClient(new Point(drgevent.X, drgevent.Y));

                TableLayoutPanelCellPosition sourcePos = this.GetPositionFromControl(data.SourceControl);
                TableLayoutPanelCellPosition targetPos = new((int)(clientPoint.X / ((double)this.Width / this.ColumnCount)), (int)(clientPoint.Y / ((double)this.Height / this.RowCount)));

                Control sourceControl = data.SourceControl;
                Control targetControl = GetControlFromPosition(targetPos.Column, targetPos.Row);
                this.SuspendLayout();
                this.SetCellPosition(sourceControl, targetPos);
                if (targetControl != null)
                    this.SetCellPosition(targetControl, sourcePos);
                this.ResumeLayout();
            }

            base.OnDragDrop(drgevent);
        }
        protected override void OnDragOver(DragEventArgs drgevent)
        {
            if (AcceptPlaceControl && drgevent.Data is ControlPlaceData)
                drgevent.Effect = DragDropEffects.Move;

            base.OnDragOver(drgevent);
        }
        protected override void OnDragEnter(DragEventArgs drgevent)
        {
            if (AcceptPlaceControl && drgevent.Data is ControlPlaceData)
                drgevent.Effect = DragDropEffects.Move;

            base.OnDragEnter(drgevent);
        }

        public void UpdateSize(int rows, int cols)
        {
            RowCount = rows;
            ColumnCount = cols;
            UpdateLayout();
        }
        public void AppendRow()
        {
            UpdateSize(RowCount + 1, ColumnCount);
        }
        public void RemoveRow()
        {
            UpdateSize(RowCount - 1, ColumnCount);
        }
        public void AppendColumn()
        {
            UpdateSize(RowCount, ColumnCount + 1);
        }
        public void RemoveColumn()
        {
            UpdateSize(RowCount, ColumnCount - 1);
        }
        public bool IsFull
        {
            get
            {
                bool notFull = false;
                for (int i = 0, end1 = RowCount; (!notFull) && i < end1; i++)
                    for (int j = 0, end2 = ColumnCount; j < end2; j++)
                        if (notFull |= (GetControlFromPosition(j, i) == null))
                            break;
                return !notFull;
            }
        }
        public bool IsEmpty => Controls.Count == 0;
    }
}
