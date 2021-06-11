
namespace Null.ReWin.UI.View
{
    partial class FileTransfer
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
            this.filePathLabel = new System.Windows.Forms.Label();
            this.filePath = new System.Windows.Forms.TextBox();
            this.remotePathLabel = new System.Windows.Forms.Label();
            this.remotePath = new System.Windows.Forms.TextBox();
            this.useTempFolder = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // filePathLabel
            // 
            this.filePathLabel.AutoSize = true;
            this.filePathLabel.Location = new System.Drawing.Point(12, 9);
            this.filePathLabel.Name = "filePathLabel";
            this.filePathLabel.Size = new System.Drawing.Size(59, 12);
            this.filePathLabel.TabIndex = 0;
            this.filePathLabel.Text = "File path";
            // 
            // filePath
            // 
            this.filePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.filePath.Location = new System.Drawing.Point(12, 24);
            this.filePath.Name = "filePath";
            this.filePath.Size = new System.Drawing.Size(406, 21);
            this.filePath.TabIndex = 1;
            // 
            // remotePathLabel
            // 
            this.remotePathLabel.AutoSize = true;
            this.remotePathLabel.Location = new System.Drawing.Point(12, 58);
            this.remotePathLabel.Name = "remotePathLabel";
            this.remotePathLabel.Size = new System.Drawing.Size(71, 12);
            this.remotePathLabel.TabIndex = 2;
            this.remotePathLabel.Text = "Remote path";
            // 
            // remotePath
            // 
            this.remotePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.remotePath.Location = new System.Drawing.Point(12, 73);
            this.remotePath.Name = "remotePath";
            this.remotePath.Size = new System.Drawing.Size(406, 21);
            this.remotePath.TabIndex = 3;
            // 
            // useTempFolder
            // 
            this.useTempFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.useTempFolder.AutoSize = true;
            this.useTempFolder.Location = new System.Drawing.Point(304, 57);
            this.useTempFolder.Name = "useTempFolder";
            this.useTempFolder.Size = new System.Drawing.Size(114, 16);
            this.useTempFolder.TabIndex = 4;
            this.useTempFolder.Text = "Use temp folder";
            this.useTempFolder.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(343, 308);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Submit";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(262, 308);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 313);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(233, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "Tips: You can drag file to this window";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.BackColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(114, 290);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(304, 1);
            this.label4.TabIndex = 8;
            // 
            // FileTransfer
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button2;
            this.ClientSize = new System.Drawing.Size(430, 343);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.useTempFolder);
            this.Controls.Add(this.remotePath);
            this.Controls.Add(this.remotePathLabel);
            this.Controls.Add(this.filePath);
            this.Controls.Add(this.filePathLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FileTransfer";
            this.Text = "FileTransfer";
            this.Load += new System.EventHandler(this.FileTransfer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label filePathLabel;
        private System.Windows.Forms.TextBox filePath;
        private System.Windows.Forms.Label remotePathLabel;
        private System.Windows.Forms.TextBox remotePath;
        private System.Windows.Forms.CheckBox useTempFolder;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}