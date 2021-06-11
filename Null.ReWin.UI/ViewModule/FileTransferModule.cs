using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Null.ReWin.UI.ViewModule
{
    class FileTransferModule : INotifyPropertyChanged
    {
        public string FilePath { get; set; }
        public string RemotePath { get; set; }
        public bool UseTempFolder { get; set; }
        public bool Execute { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
