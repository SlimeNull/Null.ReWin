using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Null.ReWin.UI.View
{
    public partial class FileTransfer : AutoPlaceForm
    {
        public FileTransfer()
        {
            InitializeComponent();
        }

        public class FileDataObject : DataObject
        {
            public string FilePath { get; private set; }
            public FileDataObject(string filepath)
            {
                this.FilePath = filepath;
            }
            public override bool ContainsFileDropList() => true;
            public override StringCollection GetFileDropList()
            {
                return new StringCollection { FilePath };
            }
            public override void SetFileDropList(StringCollection filePaths)
            {
                throw new NotSupportedException();
            }
        }

        private void FileTransfer_Load(object sender, EventArgs e)
        {
            
        }
    }
}
