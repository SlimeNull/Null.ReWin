﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Null.ReWin.UI.ViewModule;

namespace Null.ReWin.UI.View
{
    public class AutoPlaceForm : Form
    {
        public bool AutoPlace { get; set; } = true;
        public Rectangle ActiveArea = default;
        public int LeftPadding { get; set; } = 10;
        public int TopPadding { get; set; } = 10;
        public int BottomPadding { get; set; } = 10;
        public int RightPadding { get; set; } = 10;
        public AutoPlaceForm() : base()
        {
            this.Load += AutoPlaceForm_Load;
        }

        private void AutoPlaceForm_Load(object sender, EventArgs e)
        {
            if (AutoPlace)
            {
                Point mousepos = MousePosition;
                Rectangle activeArea = this.ActiveArea == default ? Screen.PrimaryScreen.WorkingArea : this.ActiveArea;

                mousepos.Offset(-65, -65);
                if (mousepos.X < activeArea.X + LeftPadding)
                    mousepos.X = activeArea.X + LeftPadding;
                if (mousepos.Y < activeArea.Y + TopPadding)
                    mousepos.Y = activeArea.Y + TopPadding;
                if (mousepos.X + this.Width > activeArea.X + activeArea.Width - RightPadding)
                    mousepos.X = activeArea.Width - this.Width + activeArea.X - RightPadding;
                if (mousepos.Y + this.Height > activeArea.Y + activeArea.Height - BottomPadding)
                    mousepos.Y = activeArea.Height - this.Height + activeArea.Y - BottomPadding;

                this.Location = mousepos;
            }
        }
    }
}
