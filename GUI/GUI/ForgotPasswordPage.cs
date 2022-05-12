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
            lblVerifyCode.Visible = true;
            boxVerifyCode.Visible = true;
            btnOkVerifyCode.Visible = true;
            linkSendEmailAgain.Visible = true;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //send email again, check if email textbox is not nul!!.

        }

        private void btnOkVerifyCode_Click(object sender, EventArgs e)
        {
            //check if code is good
            if (!Form1.Instance.PnlContainer.Controls.ContainsKey("ResetPasswordPage"))
            {
                ResetPasswordPage resetPasswordPage = new ResetPasswordPage(client);
                Form1.Instance.PnlContainer.Controls.Add(resetPasswordPage);
            }
            Form1.Instance.PnlContainer.Controls["ResetPasswordPage"].BringToFront();
            Position.currentPage = "ResetPasswordPage";
        }
    }
}
