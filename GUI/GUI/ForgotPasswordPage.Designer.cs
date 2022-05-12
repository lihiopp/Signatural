
namespace GUI
{
    partial class ForgotPasswordPage
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
            this.boxEmailForgotPassword = new System.Windows.Forms.TextBox();
            this.btnEmailForgotPassword = new System.Windows.Forms.Button();
            this.linkSendEmailAgain = new System.Windows.Forms.LinkLabel();
            this.lblVerifyCode = new System.Windows.Forms.Label();
            this.boxVerifyCode = new System.Windows.Forms.TextBox();
            this.btnOkVerifyCode = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 20F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(432, 129);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(334, 47);
            this.label1.TabIndex = 2;
            this.label1.Text = "Frogot Password";
            // 
            // logint2
            // 
            this.logint2.AutoSize = true;
            this.logint2.Font = new System.Drawing.Font("Century Gothic", 13F);
            this.logint2.Location = new System.Drawing.Point(324, 206);
            this.logint2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.logint2.Name = "logint2";
            this.logint2.Size = new System.Drawing.Size(682, 32);
            this.logint2.TabIndex = 7;
            this.logint2.Text = "Reset your password by entering your email address.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.label2.Location = new System.Drawing.Point(369, 271);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 25);
            this.label2.TabIndex = 8;
            this.label2.Text = "Email:";
            // 
            // boxEmailForgotPassword
            // 
            this.boxEmailForgotPassword.Location = new System.Drawing.Point(460, 264);
            this.boxEmailForgotPassword.Name = "boxEmailForgotPassword";
            this.boxEmailForgotPassword.Size = new System.Drawing.Size(155, 37);
            this.boxEmailForgotPassword.TabIndex = 10;
            // 
            // btnEmailForgotPassword
            // 
            this.btnEmailForgotPassword.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnEmailForgotPassword.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnEmailForgotPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEmailForgotPassword.ForeColor = System.Drawing.Color.White;
            this.btnEmailForgotPassword.Location = new System.Drawing.Point(633, 260);
            this.btnEmailForgotPassword.Name = "btnEmailForgotPassword";
            this.btnEmailForgotPassword.Size = new System.Drawing.Size(143, 37);
            this.btnEmailForgotPassword.TabIndex = 11;
            this.btnEmailForgotPassword.Text = "Send";
            this.btnEmailForgotPassword.UseVisualStyleBackColor = false;
            this.btnEmailForgotPassword.Click += new System.EventHandler(this.btnEmailForgotPassword_Click);
            // 
            // linkSendEmailAgain
            // 
            this.linkSendEmailAgain.AutoSize = true;
            this.linkSendEmailAgain.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.linkSendEmailAgain.Location = new System.Drawing.Point(365, 328);
            this.linkSendEmailAgain.Name = "linkSendEmailAgain";
            this.linkSendEmailAgain.Size = new System.Drawing.Size(453, 23);
            this.linkSendEmailAgain.TabIndex = 12;
            this.linkSendEmailAgain.TabStop = true;
            this.linkSendEmailAgain.Text = "Didn\'t get any email... please send me again.";
            this.linkSendEmailAgain.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // lblVerifyCode
            // 
            this.lblVerifyCode.AutoSize = true;
            this.lblVerifyCode.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.lblVerifyCode.Location = new System.Drawing.Point(354, 391);
            this.lblVerifyCode.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblVerifyCode.Name = "lblVerifyCode";
            this.lblVerifyCode.Size = new System.Drawing.Size(143, 25);
            this.lblVerifyCode.TabIndex = 13;
            this.lblVerifyCode.Text = "Verify code:";
            // 
            // boxVerifyCode
            // 
            this.boxVerifyCode.Location = new System.Drawing.Point(506, 384);
            this.boxVerifyCode.Name = "boxVerifyCode";
            this.boxVerifyCode.Size = new System.Drawing.Size(155, 37);
            this.boxVerifyCode.TabIndex = 14;
            // 
            // btnOkVerifyCode
            // 
            this.btnOkVerifyCode.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnOkVerifyCode.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnOkVerifyCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOkVerifyCode.ForeColor = System.Drawing.Color.White;
            this.btnOkVerifyCode.Location = new System.Drawing.Point(680, 379);
            this.btnOkVerifyCode.Name = "btnOkVerifyCode";
            this.btnOkVerifyCode.Size = new System.Drawing.Size(91, 37);
            this.btnOkVerifyCode.TabIndex = 15;
            this.btnOkVerifyCode.Text = "OK";
            this.btnOkVerifyCode.UseVisualStyleBackColor = false;
            this.btnOkVerifyCode.Click += new System.EventHandler(this.btnOkVerifyCode_Click);
            // 
            // ForgotPasswordPage
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(248)))), ((int)(((byte)(249)))));
            this.Controls.Add(this.btnOkVerifyCode);
            this.Controls.Add(this.boxVerifyCode);
            this.Controls.Add(this.lblVerifyCode);
            this.Controls.Add(this.linkSendEmailAgain);
            this.Controls.Add(this.btnEmailForgotPassword);
            this.Controls.Add(this.boxEmailForgotPassword);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.logint2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "ForgotPasswordPage";
            this.Size = new System.Drawing.Size(1048, 469);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label logint2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox boxEmailForgotPassword;
        private System.Windows.Forms.Button btnEmailForgotPassword;
        private System.Windows.Forms.LinkLabel linkSendEmailAgain;
        private System.Windows.Forms.Label lblVerifyCode;
        private System.Windows.Forms.TextBox boxVerifyCode;
        private System.Windows.Forms.Button btnOkVerifyCode;
    }
}
