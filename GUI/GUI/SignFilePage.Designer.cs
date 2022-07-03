
namespace GUI
{
    partial class SignFilePage
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnSignFile = new System.Windows.Forms.Button();
            this.btnSendFileBack = new System.Windows.Forms.Button();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.boxPageNumber = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblHelloUser
            // 
            this.lblHelloUser.AutoSize = true;
            this.lblHelloUser.Font = new System.Drawing.Font("Century Gothic", 20F, System.Drawing.FontStyle.Bold);
            this.lblHelloUser.Location = new System.Drawing.Point(141, 130);
            this.lblHelloUser.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblHelloUser.Name = "lblHelloUser";
            this.lblHelloUser.Size = new System.Drawing.Size(243, 47);
            this.lblHelloUser.TabIndex = 6;
            this.lblHelloUser.Text = "Sign Papers";
            // 
            // logint2
            // 
            this.logint2.AutoSize = true;
            this.logint2.Font = new System.Drawing.Font("Century Gothic", 13F);
            this.logint2.Location = new System.Drawing.Point(143, 232);
            this.logint2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.logint2.Name = "logint2";
            this.logint2.Size = new System.Drawing.Size(463, 32);
            this.logint2.TabIndex = 9;
            this.logint2.Text = "This is the file you are meant to sign:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 13F);
            this.label1.Location = new System.Drawing.Point(143, 304);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(569, 32);
            this.label1.TabIndex = 10;
            this.label1.Text = "Please add your signature by clicking \"sign\".";
            // 
            // btnSignFile
            // 
            this.btnSignFile.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnSignFile.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnSignFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSignFile.ForeColor = System.Drawing.Color.White;
            this.btnSignFile.Location = new System.Drawing.Point(149, 376);
            this.btnSignFile.Name = "btnSignFile";
            this.btnSignFile.Size = new System.Drawing.Size(91, 37);
            this.btnSignFile.TabIndex = 54;
            this.btnSignFile.Text = "Sign";
            this.btnSignFile.UseVisualStyleBackColor = false;
            this.btnSignFile.Click += new System.EventHandler(this.btnSignFile_Click);
            // 
            // btnSendFileBack
            // 
            this.btnSendFileBack.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnSendFileBack.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnSendFileBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSendFileBack.ForeColor = System.Drawing.Color.White;
            this.btnSendFileBack.Location = new System.Drawing.Point(279, 376);
            this.btnSendFileBack.Name = "btnSendFileBack";
            this.btnSendFileBack.Size = new System.Drawing.Size(91, 37);
            this.btnSendFileBack.TabIndex = 55;
            this.btnSendFileBack.Text = "Send";
            this.btnSendFileBack.UseVisualStyleBackColor = false;
            this.btnSendFileBack.Click += new System.EventHandler(this.btnSendFileBack_Click);
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(720, 130);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(315, 319);
            this.webBrowser1.TabIndex = 56;
            // 
            // boxPageNumber
            // 
            this.boxPageNumber.Location = new System.Drawing.Point(557, 376);
            this.boxPageNumber.Name = "boxPageNumber";
            this.boxPageNumber.Size = new System.Drawing.Size(71, 37);
            this.boxPageNumber.TabIndex = 57;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.label2.Location = new System.Drawing.Point(399, 385);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 23);
            this.label2.TabIndex = 58;
            this.label2.Text = "Page Number:";
            // 
            // SignFilePage
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(248)))), ((int)(((byte)(249)))));
            this.Controls.Add(this.label2);
            this.Controls.Add(this.boxPageNumber);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.btnSendFileBack);
            this.Controls.Add(this.btnSignFile);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.logint2);
            this.Controls.Add(this.lblHelloUser);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "SignFilePage";
            this.Size = new System.Drawing.Size(1048, 469);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHelloUser;
        private System.Windows.Forms.Label logint2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSignFile;
        private System.Windows.Forms.Button btnSendFileBack;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.TextBox boxPageNumber;
        private System.Windows.Forms.Label label2;
    }
}
