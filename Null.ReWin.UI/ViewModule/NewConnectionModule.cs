using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Null.ReWin.UI.Module;

namespace Null.ReWin.UI.ViewModule
{
    public class NewConnectionModule : ConnectionInfo, INotifyPropertyChanged
    {
        public NewConnectionModule() { }
        public NewConnectionModule(ConnectionInfo info)
        {
            this.Address = info.Address;
            this.Port = info.Port;
            this.Username = info.Username;
            this.Password = info.Password;
            this.Description = info.Description;
        }

        public override string Address { get; set; }
        public override int Port { get; set; }
        public override string Username { get; set; }
        public override string Password { get; set; }
        public override string Description { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
