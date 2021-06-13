using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Null.ReWin.UI.Module;
using Null.ReWin.UI.View;
using Null.ReWin.UI.ViewModule;
using static Null.ReWin.UI.View.FileTransfer;

namespace Null.ReWin.UI
{
    public partial class MainWindow : Form
    {
        public MainWindowModule ViewModule { get; private set; }
        public RemoteDesktopControl CurrentRdpClient { get; private set; }
        public MainWindow()
        {
            InitializeComponent();
        }

        private void InitializeViewModule()
        {
            ViewModule ??= new MainWindowModule();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //axMsRdpClient9NotSafeForScripting1.Server = "202.182.123.215";
            //axMsRdpClient9NotSafeForScripting1.UserName = "Administrator";
            //axMsRdpClient9NotSafeForScripting1.AdvancedSettings9.EnableCredSspSupport = true;
            //axMsRdpClient9NotSafeForScripting1.AdvancedSettings9.ClearTextPassword = "_q7HN-U?1b3X[{$y";
            //axMsRdpClient9NotSafeForScripting1.Connect();
            InitializeViewModule();
            loadConnectionList();
            UpdateConnectionList();

            Open.WinKeyboardHook.KeyboardInterceptor kbdcapture = new Open.WinKeyboardHook.KeyboardInterceptor();
            kbdcapture.StartCapturing();
        }

        protected override bool ProcessKeyPreview(ref Message m)
        {
            foreach (var rdp in GetRemoteDesktopControls())
                rdp.PreProcessMessage(ref m);
            return base.ProcessKeyPreview(ref m);
        }

        private void UpdateConnectionList()
        {
            connectionList.Items.Clear();
            connectionList.Items.AddRange(
                ViewModule.ConnectionInfos.Select(v => new ListViewItem(new string[]
                {
                    v.Address,
                    v.Port.ToString(),
                    v.Username,
                    v.Description
                })).ToArray());
        }

        private void AddNewConnection()
        {
            NewConnection newConnection = new()
            {
                ActiveArea = new Rectangle(this.Location, this.Size)
            };
            if (newConnection.ShowDialog() == DialogResult.OK)
                ViewModule.ConnectionInfos.Add(newConnection.ViewModule);
            UpdateConnectionList();
            saveConnectionList();
        }

        private void RemoveSelectConnection()
        {
            ListViewItem item;
            if ((item = connectionList.FocusedItem) != null)
            {
                int index = item.Index;
                ViewModule.ConnectionInfos.RemoveAt(index);
                UpdateConnectionList();
                saveConnectionList();
            }
        }

        private void ModifySelectConnection()
        {
            ListViewItem item;
            if ((item = connectionList.FocusedItem) != null)
            {
                int index = item.Index;
                ConnectionInfo old = ViewModule.ConnectionInfos[index];
                NewConnection newConnection = new(old);
                if (newConnection.ShowDialog() == DialogResult.OK)
                    ViewModule.ConnectionInfos[index] = newConnection.ViewModule;
                UpdateConnectionList();
                saveConnectionList();
            }
        }

        private void RunSelectConnection()
        {
            foreach (ListViewItem item in connectionList.SelectedItems)
            {
                int index = item.Index;
                ConnectionInfo connection = ViewModule.ConnectionInfos[index];

                RemoteDesktopControl control = new();
                control.GotFocus += Control_GotFocus;
                CurrentRdpClient = control;

                do
                {
                    if (connectionPages.SelectedTab is RemoteDesktopPage curPage)
                        if (curPage.TryAddConnection(control))
                            break;
                    foreach (var rdpage in connectionPages.TabPages.OfType<RemoteDesktopPage>())
                        if (rdpage.TryAddConnection(control))
                            break;

                    RemoteDesktopPage page = new();
                    if (page.TryAddConnection(control))
                    {
                        connectionPages.TabPages.Add(page);
                        connectionPages.SelectedTab = page;
                    }
                    else
                    {
                        MessageBox.Show("Cannot create connection panel", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                while (false);

                if (!control.ConnectFromInfo(connection))
                    MessageBox.Show("Connect failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private IEnumerable<RemoteDesktopControl> GetRemoteDesktopControls()
        {
            foreach (var controls in connectionPages.TabPages.OfType<RemoteDesktopPage>().Select(v => v.GetRemoteDesktopControls()))
                foreach (var control in controls)
                    yield return control;
        }

        private void Control_GotFocus(object sender, EventArgs e)
        {
            CurrentRdpClient = sender as RemoteDesktopControl;
        }

        const string configPath = "./connection.json";
        private void saveConnectionList(string path = configPath)
        {
            File.WriteAllText(path, JsonConvert.SerializeObject(ViewModule.ConnectionInfos));
        }

        private void loadConnectionList(string path = configPath)
        {
            if (File.Exists(path))
            {
                try
                {
                    ViewModule.LoadConnections(
                        JsonConvert.DeserializeObject<ConnectionInfo[]>(File.ReadAllText(configPath)));
                }
                catch { }
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            AddNewConnection();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            RunSelectConnection();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            ModifySelectConnection();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            RemoveSelectConnection();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddNewConnection();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveConnectionList();
        }

        SaveFileDialog sfd;
        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sfd ??= new SaveFileDialog()
            {
                Title = "Save connection config",
                Filter = "JSON file|*.json|All|*.*",
                CheckFileExists = true,
            };

            if (sfd.ShowDialog() == DialogResult.OK)
                saveConnectionList(sfd.FileName);
        }

        private void ReloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadConnectionList();
        }

        private void ToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            UpdateConnectionList();
        }

        private void AddRowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (connectionPages.SelectedTab is RemoteDesktopPage page)
                page.ControlDragTable.AppendRow();
        }

        private void AddColumnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (connectionPages.SelectedTab is RemoteDesktopPage page)
                page.ControlDragTable.AppendColumn();
        }

        private void RemoteRowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (connectionPages.SelectedTab is RemoteDesktopPage page)
                page.ControlDragTable.RemoveRow();
        }

        private void RemoteColumnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (connectionPages.SelectedTab is RemoteDesktopPage page)
                page.ControlDragTable.RemoveColumn();
        }

        private void AddPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoteDesktopPage page = new RemoteDesktopPage() { AutoClose = false };
            connectionPages.TabPages.Add(page);
            connectionPages.SelectedTab = page;
        }

        private void RemotePageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (connectionPages.SelectedTab is RemoteDesktopPage page)
            {
                if (page.ControlDragTable.IsEmpty)
                    page.Dispose();
            }
        }

        private void DisconnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CurrentRdpClient != null)
            {
                CurrentRdpClient.Disconnect();
                CurrentRdpClient = null;
            }
            else
            {
                MessageBox.Show("Select a remote desktop panel before you click this button!");
            }
        }

        private void CommandPromptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }


        OpenFileDialog ofd;
        private void button1_Click(object sender, EventArgs e)
        {
            ofd ??= new OpenFileDialog()
            {
                Title = "Open a json config file",
                Filter = "JSON file|*.json|All|*.*",
                CheckFileExists = true,
                Multiselect = false,
            };

            if (ofd.ShowDialog() == DialogResult.OK)
                loadConnectionList(ofd.FileName);
        }

        private void newConnection_Click(object sender, EventArgs e)
        {
            AddNewConnection();
        }
    }
}
