
namespace GUI
{
    partial class SignupPage
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
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.boxUsernameSignup = new System.Windows.Forms.TextBox();
            this.boxPasswordSignup = new System.Windows.Forms.TextBox();
            this.btnDoneSignup = new System.Windows.Forms.Button();
            this.boxEmailSignup = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 20F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(509, 133);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 47);
            this.label1.TabIndex = 2;
            this.label1.Text = "Signup";
            // 
            // logint2
            // 
            this.logint2.AutoSize = true;
            this.logint2.Font = new System.Drawing.Font("Century Gothic", 13F);
            this.logint2.Location = new System.Drawing.Point(226, 209);
            this.logint2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.logint2.Name = "logint2";
            this.logint2.Size = new System.Drawing.Size(1049, 32);
            this.logint2.TabIndex = 7;
            this.logint2.Text = "Please enter your details. Make sure the password contains at least 6 charachters" +
    ".";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(368, 260);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 30);
            this.label2.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.label3.Location = new System.Drawing.Point(191, 313);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 25);
            this.label3.TabIndex = 9;
            this.label3.Text = "Username:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.label4.Location = new System.Drawing.Point(479, 313);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 25);
            this.label4.TabIndex = 10;
            this.label4.Text = "Password:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.label6.Location = new System.Drawing.Point(769, 314);
            this.label6.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 25);
            this.label6.TabIndex = 12;
            this.label6.Text = "Email:";
            // 
            // boxUsernameSignup
            // 
            this.boxUsernameSignup.Location = new System.Drawing.Point(306, 309);
            this.boxUsernameSignup.Name = "boxUsernameSignup";
            this.boxUsernameSignup.Size = new System.Drawing.Size(155, 37);
            this.boxUsernameSignup.TabIndex = 13;
            // 
            // boxPasswordSignup
            // 
            this.boxPasswordSignup.Location = new System.Drawing.Point(587, 309);
            this.boxPasswordSignup.Name = "boxPasswordSignup";
            this.boxPasswordSignup.PasswordChar = '*';
            this.boxPasswordSignup.Size = new System.Drawing.Size(155, 37);
            this.boxPasswordSignup.TabIndex = 14;
            // 
            // btnDoneSignup
            // 
            this.btnDoneSignup.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnDoneSignup.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnDoneSignup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDoneSignup.ForeColor = System.Drawing.Color.White;
            this.btnDoneSignup.Location = new System.Drawing.Point(488, 373);
            this.btnDoneSignup.Name = "btnDoneSignup";
            this.btnDoneSignup.Size = new System.Drawing.Size(143, 43);
            this.btnDoneSignup.TabIndex = 16;
            this.btnDoneSignup.Text = "Signup";
            this.btnDoneSignup.UseVisualStyleBackColor = false;
            this.btnDoneSignup.Click += new System.EventHandler(this.btnDoneSignup_Click);
            // 
            // boxEmailSignup
            // 
            this.boxEmailSignup.Location = new System.Drawing.Point(825, 309);
            this.boxEmailSignup.Name = "boxEmailSignup";
            this.boxEmailSignup.Size = new System.Drawing.Size(155, 37);
            this.boxEmailSignup.TabIndex = 17;
            // 
            // SignupPage
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(248)))), ((int)(((byte)(249)))));
            this.Controls.Add(this.boxEmailSignup);
            this.Controls.Add(this.btnDoneSignup);
            this.Controls.Add(this.boxPasswordSignup);
            this.Controls.Add(this.boxUsernameSignup);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.logint2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "SignupPage";
            this.Size = new System.Drawing.Size(1048, 469);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label logint2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox boxUsernameSignup;
        private System.Windows.Forms.TextBox boxPasswordSignup;
        private System.Windows.Forms.Button btnDoneSignup;
        private System.Windows.Forms.TextBox boxEmailSignup;
    }
}
