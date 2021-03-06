
namespace GUI
{
    partial class UserProfilePage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserProfilePage));
            this.lblHelloUser = new System.Windows.Forms.Label();
            this.logint2 = new System.Windows.Forms.Label();
            this.btnSendFile = new System.Windows.Forms.Button();
            this.btnSignFile = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblHelloUser
            // 
            this.lblHelloUser.AutoSize = true;
            this.lblHelloUser.Font = new System.Drawing.Font("Century Gothic", 20F, System.Drawing.FontStyle.Bold);
            this.lblHelloUser.Location = new System.Drawing.Point(179, 130);
            this.lblHelloUser.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblHelloUser.Name = "lblHelloUser";
            this.lblHelloUser.Size = new System.Drawing.Size(191, 47);
            this.lblHelloUser.TabIndex = 4;
            this.lblHelloUser.Text = "Hi there, ";
            // 
            // logint2
            // 
            this.logint2.AutoSize = true;
            this.logint2.Font = new System.Drawing.Font("Century Gothic", 13F);
            this.logint2.Location = new System.Drawing.Point(181, 189);
            this.logint2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.logint2.Name = "logint2";
            this.logint2.Size = new System.Drawing.Size(432, 32);
            this.logint2.TabIndex = 7;
            this.logint2.Text = "Here is your activity up until now:";
            // 
            // btnSendFile
            // 
            this.btnSendFile.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnSendFile.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnSendFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSendFile.ForeColor = System.Drawing.Color.White;
            this.btnSendFile.Location = new System.Drawing.Point(792, 133);
            this.btnSendFile.Name = "btnSendFile";
            this.btnSendFile.Size = new System.Drawing.Size(143, 43);
            this.btnSendFile.TabIndex = 14;
            this.btnSendFile.Text = "Send file";
            this.btnSendFile.UseVisualStyleBackColor = false;
            this.btnSendFile.Click += new System.EventHandler(this.btnSendFile_Click);
            // 
            // btnSignFile
            // 
            this.btnSignFile.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnSignFile.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnSignFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSignFile.ForeColor = System.Drawing.Color.White;
            this.btnSignFile.Location = new System.Drawing.Point(792, 191);
            this.btnSignFile.Name = "btnSignFile";
            this.btnSignFile.Size = new System.Drawing.Size(143, 43);
            this.btnSignFile.TabIndex = 15;
            this.btnSignFile.Text = "Sign file";
            this.btnSignFile.UseVisualStyleBackColor = false;
            this.btnSignFile.Click += new System.EventHandler(this.btnSignFile_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(201, 224);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(320, 245);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            // 
            // UserProfilePage
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(248)))), ((int)(((byte)(249)))));
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnSignFile);
            this.Controls.Add(this.btnSendFile);
            this.Controls.Add(this.logint2);
            this.Controls.Add(this.lblHelloUser);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "UserProfilePage";
            this.Size = new System.Drawing.Size(1048, 469);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHelloUser;
        private System.Windows.Forms.Label logint2;
        private System.Windows.Forms.Button btnSendFile;
        private System.Windows.Forms.Button btnSignFile;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
