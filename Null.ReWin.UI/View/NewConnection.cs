using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Null.ReWin.UI.Module;
using Null.ReWin.UI.ViewModule;

namespace Null.ReWin.UI.View
{
    public partial class NewConnection : AutoPlaceForm
    {
        public NewConnectionModule ViewModule { get; private set; }
        public NewConnection()
        {
            InitializeComponent();
        }
        public NewConnection(ConnectionInfo info) : this()
        {
            ViewModule = new NewConnectionModule(info);
        }
        
        private void InitializeViewModule()
        {
            if (ViewModule == null)
                ViewModule = new NewConnectionModule(); this.address.DataBindings.Add(new Binding(nameof(TextBox.Text), ViewModule, nameof(NewConnectionModule.Address)));
            this.port.DataBindings.Add(new Binding(nameof(TextBox.Text), ViewModule, nameof(NewConnectionModule.Port)));
            this.username.DataBindings.Add(new Binding(nameof(TextBox.Text), ViewModule, nameof(NewConnectionModule.Username)));
            this.password.DataBindings.Add(new Binding(nameof(TextBox.Text), ViewModule, nameof(NewConnectionModule.Password)));
            this.desc.DataBindings.Add(new Binding(nameof(TextBox.Text), ViewModule, nameof(NewConnectionModule.Description)));
        }

        private void NewConnection_Load(object sender, EventArgs e)
        {
            InitializeViewModule();
        }

        private void port_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (!char.IsControl(e.KeyChar)) && !char.IsDigit(e.KeyChar);   // 限制输入字符
        }

        private void showpassword_CheckedChanged(object sender, EventArgs e)
        {
            password.PasswordChar = showpassword.Checked ? '\0' : '*';
        }

        private void submit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
