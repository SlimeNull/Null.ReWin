using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AxMSTSCLib;
using MSTSCLib;
using Null.ReWin.UI.Module;

namespace Null.ReWin.UI.View
{
    public class RemoteDesktopControl : AxMsRdpClient9NotSafeForScripting
    {
        public RemoteDesktopControl() : base()
        {
            this.Dock = DockStyle.Fill;

            this.OnDisconnected += RemoteDesktopControl_OnDisconnected;
            this.SizeChanged += RemoteDesktopControl_SizeChanged;
        }

        private void RemoteDesktopControl_OnDisconnected(object sender, IMsTscAxEvents_OnDisconnectedEvent e)
        {
            this.Dispose();
        }


        public bool LayoutChanging { get; set; } = true;
        public bool ConnectFromInfo(ConnectionInfo info)
        {
            try
            {
                this.Text = string.IsNullOrWhiteSpace(info.Description) ? info.Address : info.Description;
                this.Server = info.Address;
                if (!string.IsNullOrEmpty(info.Username))
                    this.UserName = info.Username;
                if (!string.IsNullOrEmpty(info.Password))
                    this.AdvancedSettings9.ClearTextPassword = info.Password;
                if (info.Port != 0)
                    this.AdvancedSettings9.RDPPort = info.Port;

                this.Connect();
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void RemoteDesktopControl_SizeChanged(object sender, EventArgs e)
        {
            try
            {
                if (Connected == 1)
                    this.UpdateSessionDisplaySettings((uint)Width, (uint)Height, 0, 0, 0, 1, 1);
            }
            catch { }
        }
    }
}
