using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Threading;

namespace GUI
{
    public partial class LoginPage : UserControl
    {
        private Client client;
        private int verification_code;
        public LoginPage(Client theClient)
        {
            InitializeComponent();
            Form1.Instance.BackButton.Visible = true;
            client = theClient;
            boxVerifyCode.Visible = false;
            lblVerifyCode.Visible = false;
        }

        private void linkForgotPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            client.Send("Forgot Password");
            if (!Form1.Instance.PnlContainer.Controls.ContainsKey("ForgotPasswordPage"))
            {
                ForgotPasswordPage forgotPasswordPage = new ForgotPasswordPage(client);
                Form1.Instance.PnlContainer.Controls.Add(forgotPasswordPage);
            }
            Form1.Instance.PnlContainer.Controls["ForgotPasswordPage"].BringToFront();
            StaticClass.currentPage = "ForgotPasswordPage";
        }
        private void btnDoneLogin_Click(object sender, EventArgs e)
        {
            int input_code = Int32.Parse(boxVerifyCode.Text);
            if (input_code == verification_code)
            {
                client.Send("Valid");
                // Get the user's activity graph's data
                string data = client.Receive();
                string attempts = data.Split(',')[0];
                string forgeries = data.Split(',')[1];
                StaticClass.CreateActivityGraph(boxUsernameLogin.Text, attempts, forgeries);
                if (!Form1.Instance.PnlContainer.Controls.ContainsKey("UserProfilePage"))
                {
                    UserProfilePage userProfilePage = new UserProfilePage(client, boxUsernameLogin.Text);
                    Form1.Instance.PnlContainer.Controls.Add(userProfilePage);
                }
                Form1.Instance.PnlContainer.Controls["UserProfilePage"].BringToFront();
                StaticClass.currentPage = "UserProfilePage";
                Form1.Instance.BackButton.Visible = false;
            }
            else
            {
                MessageBoxIcon error = MessageBoxIcon.Error;
                MessageBox.Show("Incorrect code.", "Oops...", MessageBoxButtons.OK, error);
            }
        }

        private void btnSendVerifyMail_Click(object sender, EventArgs e)
        {
            string username = boxUsernameLogin.Text;
            string password = boxPasswordLogin.Text;

            // Convert password to MD5
            var md5Hash = MD5.Create(); //Creates an instance of the MD5 hash algorithm.
            var sourceBytes = Encoding.ASCII.GetBytes(password); // Byte array representation of the password
            var hashBytes = md5Hash.ComputeHash(sourceBytes); // Generate hash value (in Byte Array) of the input
            var hash = BitConverter.ToString(hashBytes).Replace("-", string.Empty); // Convert hash byte array to string

            client.Send($"{username},{hash}");
            string response = client.Receive();
            if (response.Split(',')[0] != "Logged in")
            {
                MessageBoxIcon error = MessageBoxIcon.Error;
                MessageBox.Show(response, "Oops...", MessageBoxButtons.OK, error);
            }
            else
            {
                string email = response.Split(',')[1];
                this.verification_code = Int32.Parse(StaticClass.EmailVerification(email));
                lblVerifyCode.Visible = true;
                boxVerifyCode.Visible = true;
                btnSendVerifyMail.Visible = false;
            }
        }
    }
}
