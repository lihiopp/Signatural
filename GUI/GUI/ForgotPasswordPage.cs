using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class ForgotPasswordPage : UserControl
    {
        private Client client;
        private int verification_code;
        private string email;
        public ForgotPasswordPage(Client theClient)
        {
            InitializeComponent();
            lblVerifyCode.Visible = false;
            boxVerifyCode.Visible = false;
            btnOkVerifyCode.Visible = false;
            linkSendEmailAgain.Visible = false;
            Form1.Instance.BackButton.Visible = true;
            client = theClient;
        }

        private void btnEmailForgotPassword_Click(object sender, EventArgs e)
        {
            //check email
            client.Send($"{boxEmailForgotPassword.Text}");
            string response = client.Receive();
            if (response != "Exists")
            {
                MessageBoxIcon error = MessageBoxIcon.Error;
                MessageBox.Show(response, "Oops...", MessageBoxButtons.OK, error);
            }
            else
            {
                this.email = boxEmailForgotPassword.Text;
                verification_code = Int32.Parse(StaticClass.EmailVerification(email));
                lblVerifyCode.Visible = true;
                boxVerifyCode.Visible = true;
                btnOkVerifyCode.Visible = true;
                linkSendEmailAgain.Visible = true;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //send email again, check if email textbox is not nul!!.
            if(boxEmailForgotPassword.Text == "")
            {
                MessageBoxIcon icon = MessageBoxIcon.Error;
                MessageBox.Show("No email stated.", "Oops...", MessageBoxButtons.OK, icon);
            }
            else
            {
                verification_code = Int32.Parse(StaticClass.EmailVerification(this.email));
            }

        }

        private void btnOkVerifyCode_Click(object sender, EventArgs e)
        {
            //check if code is good
            int input_code = Int32.Parse(boxVerifyCode.Text);
            if (input_code == this.verification_code)
            {
                if (!Form1.Instance.PnlContainer.Controls.ContainsKey("ResetPasswordPage"))
                {
                    ResetPasswordPage resetPasswordPage = new ResetPasswordPage(client);
                    Form1.Instance.PnlContainer.Controls.Add(resetPasswordPage);
                }
                Form1.Instance.PnlContainer.Controls["ResetPasswordPage"].BringToFront();
                StaticClass.currentPage = "ResetPasswordPage";
            }
            else
            {
                MessageBoxIcon icon = MessageBoxIcon.Error;
                MessageBox.Show("Wrong code.", "Oops...", MessageBoxButtons.OK, icon);
            }
        }
    }
}
