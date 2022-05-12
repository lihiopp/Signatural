
namespace GUI
{
    partial class LoginPage
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
            this.label1 = new System.Windows.Forms.Label();
            this.logint2 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.boxUsernameLogin = new System.Windows.Forms.TextBox();
            this.boxPasswordLogin = new System.Windows.Forms.TextBox();
            this.linkForgotPassword = new System.Windows.Forms.LinkLabel();
            this.btnDoneLogin = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 20F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(520, 129);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 47);
            this.label1.TabIndex = 1;
            this.label1.Text = "Login";
            // 
            // logint2
            // 
            this.logint2.AutoSize = true;
            this.logint2.Font = new System.Drawing.Font("Century Gothic", 13F);
            this.logint2.Location = new System.Drawing.Point(379, 199);
            this.logint2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.logint2.Name = "logint2";
            this.logint2.Size = new System.Drawing.Size(556, 32);
            this.logint2.TabIndex = 6;
            this.logint2.Text = "Please enter your username and password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.label2.Location = new System.Drawing.Point(269, 287);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 25);
            this.label2.TabIndex = 7;
            this.label2.Text = "Username:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.label3.Location = new System.Drawing.Point(612, 287);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 25);
            this.label3.TabIndex = 8;
            this.label3.Text = "Password:";
            // 
            // boxUsernameLogin
            // 
            this.boxUsernameLogin.Location = new System.Drawing.Point(411, 280);
            this.boxUsernameLogin.Name = "boxUsernameLogin";
            this.boxUsernameLogin.Size = new System.Drawing.Size(155, 37);
            this.boxUsernameLogin.TabIndex = 9;
            // 
            // boxPasswordLogin
            // 
            this.boxPasswordLogin.Location = new System.Drawing.Point(742, 281);
            this.boxPasswordLogin.Name = "boxPasswordLogin";
            this.boxPasswordLogin.Size = new System.Drawing.Size(155, 37);
            this.boxPasswordLogin.TabIndex = 10;
            // 
            // linkForgotPassword
            // 
            this.linkForgotPassword.AutoSize = true;
            this.linkForgotPassword.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.linkForgotPassword.Location = new System.Drawing.Point(459, 341);
            this.linkForgotPassword.Name = "linkForgotPassword";
            this.linkForgotPassword.Size = new System.Drawing.Size(294, 23);
            this.linkForgotPassword.TabIndex = 11;
            this.linkForgotPassword.TabStop = true;
            this.linkForgotPassword.Text = "Oops... I forgot my password.";
            this.linkForgotPassword.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkForgotPassword_LinkClicked);
            // 
            // btnDoneLogin
            // 
            this.btnDoneLogin.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnDoneLogin.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnDoneLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDoneLogin.ForeColor = System.Drawing.Color.White;
            this.btnDoneLogin.Location = new System.Drawing.Point(474, 395);
            this.btnDoneLogin.Name = "btnDoneLogin";
            this.btnDoneLogin.Size = new System.Drawing.Size(166, 43);
            this.btnDoneLogin.TabIndex = 12;
            this.btnDoneLogin.Text = "Log me in!";
            this.btnDoneLogin.UseVisualStyleBackColor = false;
            this.btnDoneLogin.Click += new System.EventHandler(this.btnDoneLogin_Click);
            // 
            // LoginPage
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(248)))), ((int)(((byte)(249)))));
            this.Controls.Add(this.btnDoneLogin);
            this.Controls.Add(this.linkForgotPassword);
            this.Controls.Add(this.boxPasswordLogin);
            this.Controls.Add(this.boxUsernameLogin);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.logint2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "LoginPage";
            this.Size = new System.Drawing.Size(1048, 469);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label logint2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox boxUsernameLogin;
        private System.Windows.Forms.TextBox boxPasswordLogin;
        private System.Windows.Forms.LinkLabel linkForgotPassword;
        private System.Windows.Forms.Button btnDoneLogin;
    }
}
