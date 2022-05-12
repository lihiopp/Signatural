
namespace GUI
{
    partial class ResetPasswordPage
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.boxNewPassword2 = new System.Windows.Forms.TextBox();
            this.boxNewPassword = new System.Windows.Forms.TextBox();
            this.btnDoneResetPassword = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 20F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(432, 132);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(317, 47);
            this.label1.TabIndex = 3;
            this.label1.Text = "Reset Password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.label2.Location = new System.Drawing.Point(337, 254);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(178, 25);
            this.label2.TabIndex = 9;
            this.label2.Text = "New password:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.label3.Location = new System.Drawing.Point(337, 329);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(246, 25);
            this.label3.TabIndex = 10;
            this.label3.Text = "New password again:";
            // 
            // boxNewPassword2
            // 
            this.boxNewPassword2.Location = new System.Drawing.Point(603, 324);
            this.boxNewPassword2.Name = "boxNewPassword2";
            this.boxNewPassword2.Size = new System.Drawing.Size(155, 37);
            this.boxNewPassword2.TabIndex = 11;
            // 
            // boxNewPassword
            // 
            this.boxNewPassword.Location = new System.Drawing.Point(533, 249);
            this.boxNewPassword.Name = "boxNewPassword";
            this.boxNewPassword.Size = new System.Drawing.Size(155, 37);
            this.boxNewPassword.TabIndex = 12;
            // 
            // btnDoneResetPassword
            // 
            this.btnDoneResetPassword.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnDoneResetPassword.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnDoneResetPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDoneResetPassword.ForeColor = System.Drawing.Color.White;
            this.btnDoneResetPassword.Location = new System.Drawing.Point(506, 396);
            this.btnDoneResetPassword.Name = "btnDoneResetPassword";
            this.btnDoneResetPassword.Size = new System.Drawing.Size(91, 37);
            this.btnDoneResetPassword.TabIndex = 16;
            this.btnDoneResetPassword.Text = "Done";
            this.btnDoneResetPassword.UseVisualStyleBackColor = false;
            this.btnDoneResetPassword.Click += new System.EventHandler(this.btnDoneResetPassword_Click);
            // 
            // ResetPasswordPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(248)))), ((int)(((byte)(249)))));
            this.Controls.Add(this.btnDoneResetPassword);
            this.Controls.Add(this.boxNewPassword);
            this.Controls.Add(this.boxNewPassword2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "ResetPasswordPage";
            this.Size = new System.Drawing.Size(1048, 469);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox boxNewPassword2;
        private System.Windows.Forms.TextBox boxNewPassword;
        private System.Windows.Forms.Button btnDoneResetPassword;
    }
}
