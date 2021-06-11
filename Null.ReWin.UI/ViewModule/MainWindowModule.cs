using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Null.ReWin.UI.Module;

namespace Null.ReWin.UI.ViewModule
{
    public class MainWindowModule : INotifyPropertyChanged
    {
        public List<ConnectionInfo> ConnectionInfos { get; private set; } = new List<ConnectionInfo>();
        public void LoadConnections(IEnumerable<ConnectionInfo> infos)
        {
            foreach (var info in infos)
                if (!ConnectionInfos.Contains(info))
                    ConnectionInfos.Add(info);
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
