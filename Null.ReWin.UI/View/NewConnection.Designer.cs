
namespace Null.ReWin.UI.View
{
    partial class NewConnection
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewConnection));
            this.addressLabel = new System.Windows.Forms.Label();
            this.address = new System.Windows.Forms.TextBox();
            this.portLabel = new System.Windows.Forms.Label();
            this.port = new System.Windows.Forms.TextBox();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.username = new System.Windows.Forms.TextBox();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.password = new System.Windows.Forms.TextBox();
            this.submit = new System.Windows.Forms.Button();
            this.showpassword = new System.Windows.Forms.CheckBox();
            this.descLabel = new System.Windows.Forms.Label();
            this.desc = new System.Windows.Forms.TextBox();
            this.cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // addressLabel
            // 
            resources.ApplyResources(this.addressLabel, "addressLabel");
            this.addressLabel.Name = "addressLabel";
            // 
            // address
            // 
            resources.ApplyResources(this.address, "address");
            this.address.Name = "address";
            // 
            // portLabel
            // 
            resources.ApplyResources(this.portLabel, "portLabel");
            this.portLabel.Name = "portLabel";
            // 
            // port
            // 
            resources.ApplyResources(this.port, "port");
            this.port.Name = "port";
            this.port.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.port_KeyPress);
            // 
            // usernameLabel
            // 
            resources.ApplyResources(this.usernameLabel, "usernameLabel");
            this.usernameLabel.Name = "usernameLabel";
            // 
            // username
            // 
            resources.ApplyResources(this.username, "username");
            this.username.Name = "username";
            // 
            // passwordLabel
            // 
            resources.ApplyResources(this.passwordLabel, "passwordLabel");
            this.passwordLabel.Name = "passwordLabel";
            // 
            // password
            // 
            resources.ApplyResources(this.password, "password");
            this.password.Name = "password";
            // 
            // submit
            // 
            resources.ApplyResources(this.submit, "submit");
            this.submit.Name = "submit";
            this.submit.UseVisualStyleBackColor = true;
            this.submit.Click += new System.EventHandler(this.submit_Click);
            // 
            // showpassword
            // 
            resources.ApplyResources(this.showpassword, "showpassword");
            this.showpassword.Name = "showpassword";
            this.showpassword.UseVisualStyleBackColor = true;
            this.showpassword.CheckedChanged += new System.EventHandler(this.showpassword_CheckedChanged);
            // 
            // descLabel
            // 
            resources.ApplyResources(this.descLabel, "descLabel");
            this.descLabel.Name = "descLabel";
            // 
            // desc
            // 
            resources.ApplyResources(this.desc, "desc");
            this.desc.Name = "desc";
            // 
            // cancel
            // 
            this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.cancel, "cancel");
            this.cancel.Name = "cancel";
            this.cancel.UseVisualStyleBackColor = true;
            // 
            // NewConnection
            // 
            this.AcceptButton = this.submit;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancel;
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.desc);
            this.Controls.Add(this.descLabel);
            this.Controls.Add(this.showpassword);
            this.Controls.Add(this.submit);
            this.Controls.Add(this.password);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.username);
            this.Controls.Add(this.usernameLabel);
            this.Controls.Add(this.port);
            this.Controls.Add(this.portLabel);
            this.Controls.Add(this.address);
            this.Controls.Add(this.addressLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "NewConnection";
            this.Load += new System.EventHandler(this.NewConnection_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label addressLabel;
        private System.Windows.Forms.TextBox address;
        private System.Windows.Forms.Label portLabel;
        private System.Windows.Forms.TextBox port;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.TextBox username;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.Button submit;
        private System.Windows.Forms.CheckBox showpassword;
        private System.Windows.Forms.Label descLabel;
        private System.Windows.Forms.TextBox desc;
        private System.Windows.Forms.Button cancel;
    }
}