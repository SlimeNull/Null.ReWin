using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Null.ReWin.UI.View
{
    public partial class CommandPromptForm : Form
    {
        public CommandPromptForm()
        {
            InitializeComponent();
        }

        private void CommandPromptForm_Load(object sender, EventArgs e)
        {

        }

        private void execute_Click(object sender, EventArgs e)
        {
            ConnectionOptions options = new ConnectionOptions()
            {
                Username = "Administrator",
                Password = "_q7HN-U?1b3X[{$y",
            };
            ObjectQuery oq = new ObjectQuery();
            ManagementScope scope = new ManagementScope(new ManagementPath("202.182.123.215"), options);
            scope.Connect();
            ObjectGetOptions objectGetOptions = new ObjectGetOptions();
            new ManagementObject(scope, scope.Path, objectGetOptions).InvokeMethod("reboot", null);
        }
    }
}
