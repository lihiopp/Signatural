
namespace GUI
{
    partial class SendFilePage
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblHelloUser = new System.Windows.Forms.Label();
            this.logint2 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.boxUsernameOfSigner = new System.Windows.Forms.TextBox();
            this.lblSignerUserStatus = new System.Windows.Forms.Label();
            this.browseFilesPanel = new System.Windows.Forms.Panel();
            this.btnSendFile = new System.Windows.Forms.Button();
            this.btnBrowseFiles = new System.Windows.Forms.Button();
            this.filenamebox = new System.Windows.Forms.TextBox();
            this.filenamet = new System.Windows.Forms.Label();
            this.btnOkSignerUsername = new System.Windows.Forms.Button();
            this.browseFilesPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblHelloUser
            // 
            this.lblHelloUser.AutoSize = true;
            this.lblHelloUser.Font = new System.Drawing.Font("Century Gothic", 20F, System.Drawing.FontStyle.Bold);
            this.lblHelloUser.Location = new System.Drawing.Point(454, 139);
            this.lblHelloUser.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblHelloUser.Name = "lblHelloUser";
            this.lblHelloUser.Size = new System.Drawing.Size(185, 47);
            this.lblHelloUser.TabIndex = 5;
            this.lblHelloUser.Text = "Send file";
            // 
            // logint2
            // 
            this.logint2.AutoSize = true;
            this.logint2.Font = new System.Drawing.Font("Century Gothic", 13F);
            this.logint2.Location = new System.Drawing.Point(215, 216);
            this.logint2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.logint2.Name = "logint2";
            this.logint2.Size = new System.Drawing.Size(939, 32);
            this.logint2.TabIndex = 8;
            this.logint2.Text = "Who do you want to sign your document? Please specify their username:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.label2.Location = new System.Drawing.Point(269, 291);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 25);
            this.label2.TabIndex = 10;
            this.label2.Text = "Username:";
            // 
            // boxUsernameOfSigner
            // 
            this.boxUsernameOfSigner.Location = new System.Drawing.Point(388, 284);
            this.boxUsernameOfSigner.Name = "boxUsernameOfSigner";
            this.boxUsernameOfSigner.Size = new System.Drawing.Size(155, 37);
            this.boxUsernameOfSigner.TabIndex = 13;
            // 
            // lblSignerUserStatus
            // 
            this.lblSignerUserStatus.AutoSize = true;
            this.lblSignerUserStatus.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.lblSignerUserStatus.Location = new System.Drawing.Point(660, 287);
            this.lblSignerUserStatus.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblSignerUserStatus.Name = "lblSignerUserStatus";
            this.lblSignerUserStatus.Size = new System.Drawing.Size(311, 25);
            this.lblSignerUserStatus.TabIndex = 14;
            this.lblSignerUserStatus.Text = "User accepted your request";
            // 
            // browseFilesPanel
            // 
            this.browseFilesPanel.Controls.Add(this.btnSendFile);
            this.browseFilesPanel.Controls.Add(this.btnBrowseFiles);
            this.browseFilesPanel.Controls.Add(this.filenamebox);
            this.browseFilesPanel.Controls.Add(this.filenamet);
            this.browseFilesPanel.Location = new System.Drawing.Point(228, 344);
            this.browseFilesPanel.Name = "browseFilesPanel";
            this.browseFilesPanel.Size = new System.Drawing.Size(688, 71);
            this.browseFilesPanel.TabIndex = 54;
            // 
            // btnSendFile
            // 
            this.btnSendFile.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnSendFile.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnSendFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSendFile.ForeColor = System.Drawing.Color.White;
            this.btnSendFile.Location = new System.Drawing.Point(499, 8);
            this.btnSendFile.Name = "btnSendFile";
            this.btnSendFile.Size = new System.Drawing.Size(91, 37);
            this.btnSendFile.TabIndex = 52;
            this.btnSendFile.Text = "Send";
            this.btnSendFile.UseVisualStyleBackColor = false;
            this.btnSendFile.Click += new System.EventHandler(this.btnSendFile_Click);
            // 
            // btnBrowseFiles
            // 
            this.btnBrowseFiles.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnBrowseFiles.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnBrowseFiles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowseFiles.ForeColor = System.Drawing.Color.White;
            this.btnBrowseFiles.Location = new System.Drawing.Point(376, 8);
            this.btnBrowseFiles.Name = "btnBrowseFiles";
            this.btnBrowseFiles.Size = new System.Drawing.Size(107, 37);
            this.btnBrowseFiles.TabIndex = 51;
            this.btnBrowseFiles.Text = "Browse";
            this.btnBrowseFiles.UseVisualStyleBackColor = false;
            this.btnBrowseFiles.Click += new System.EventHandler(this.btnBrowseFiles_Click);
            // 
            // filenamebox
            // 
            this.filenamebox.Location = new System.Drawing.Point(112, 14);
            this.filenamebox.Name = "filenamebox";
            this.filenamebox.Size = new System.Drawing.Size(249, 37);
            this.filenamebox.TabIndex = 50;
            // 
            // filenamet
            // 
            this.filenamet.AutoSize = true;
            this.filenamet.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.filenamet.Location = new System.Drawing.Point(46, 17);
            this.filenamet.Name = "filenamet";
            this.filenamet.Size = new System.Drawing.Size(46, 23);
            this.filenamet.TabIndex = 49;
            this.filenamet.Text = "File:";
            // 
            // btnOkSignerUsername
            // 
            this.btnOkSignerUsername.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnOkSignerUsername.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnOkSignerUsername.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOkSignerUsername.ForeColor = System.Drawing.Color.White;
            this.btnOkSignerUsername.Location = new System.Drawing.Point(560, 284);
            this.btnOkSignerUsername.Name = "btnOkSignerUsername";
            this.btnOkSignerUsername.Size = new System.Drawing.Size(83, 32);
            this.btnOkSignerUsername.TabIndex = 53;
            this.btnOkSignerUsername.Text = "OK";
            this.btnOkSignerUsername.UseVisualStyleBackColor = false;
            this.btnOkSignerUsername.Click += new System.EventHandler(this.btnOkSignerUsername_Click);
            // 
            // SendFilePage
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(248)))), ((int)(((byte)(249)))));
            this.Controls.Add(this.btnOkSignerUsername);
            this.Controls.Add(this.browseFilesPanel);
            this.Controls.Add(this.lblSignerUserStatus);
            this.Controls.Add(this.boxUsernameOfSigner);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.logint2);
            this.Controls.Add(this.lblHelloUser);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "SendFilePage";
            this.Size = new System.Drawing.Size(1048, 469);
            this.browseFilesPanel.ResumeLayout(false);
            this.browseFilesPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHelloUser;
        private System.Windows.Forms.Label logint2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox boxUsernameOfSigner;
        private System.Windows.Forms.Label lblSignerUserStatus;
        private System.Windows.Forms.Panel browseFilesPanel;
        private System.Windows.Forms.TextBox filenamebox;
        private System.Windows.Forms.Label filenamet;
        private System.Windows.Forms.Button btnSendFile;
        private System.Windows.Forms.Button btnBrowseFiles;
        private System.Windows.Forms.Button btnOkSignerUsername;
    }
}
