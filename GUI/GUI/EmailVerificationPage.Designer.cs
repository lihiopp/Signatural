
namespace GUI
{
    partial class EmailVerificationPage
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
            this.boxActivateAccCode = new System.Windows.Forms.TextBox();
            this.btnOkEmailVerification = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 20F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(391, 184);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(456, 47);
            this.label1.TabIndex = 1;
            this.label1.Text = "Activate your account";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(348, 260);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(589, 30);
            this.label2.TabIndex = 2;
            this.label2.Text = "Please enter the code we\'ve sent you via email:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.label3.Location = new System.Drawing.Point(356, 345);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(143, 25);
            this.label3.TabIndex = 8;
            this.label3.Text = "Verify code:";
            // 
            // boxActivateAccCode
            // 
            this.boxActivateAccCode.Location = new System.Drawing.Point(477, 343);
            this.boxActivateAccCode.Name = "boxActivateAccCode";
            this.boxActivateAccCode.Size = new System.Drawing.Size(155, 37);
            this.boxActivateAccCode.TabIndex = 10;
            // 
            // btnOkEmailVerification
            // 
            this.btnOkEmailVerification.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnOkEmailVerification.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnOkEmailVerification.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOkEmailVerification.ForeColor = System.Drawing.Color.White;
            this.btnOkEmailVerification.Location = new System.Drawing.Point(665, 337);
            this.btnOkEmailVerification.Name = "btnOkEmailVerification";
            this.btnOkEmailVerification.Size = new System.Drawing.Size(78, 43);
            this.btnOkEmailVerification.TabIndex = 17;
            this.btnOkEmailVerification.Text = "OK";
            this.btnOkEmailVerification.UseVisualStyleBackColor = false;
            this.btnOkEmailVerification.Click += new System.EventHandler(this.btnOkEmailVerification_Click);
            // 
            // EmailVerificationPage
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(248)))), ((int)(((byte)(249)))));
            this.Controls.Add(this.btnOkEmailVerification);
            this.Controls.Add(this.boxActivateAccCode);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "EmailVerificationPage";
            this.Size = new System.Drawing.Size(1048, 469);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox boxActivateAccCode;
        private System.Windows.Forms.Button btnOkEmailVerification;
    }
}
