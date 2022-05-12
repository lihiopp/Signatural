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


namespace GUI
{
    public partial class LoginPage : UserControl
    {
        private Client client;
        public LoginPage(Client theClient)
        {
            InitializeComponent();
            Form1.Instance.BackButton.Visible = true;
            client = theClient;
        }

        private void linkForgotPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!Form1.Instance.PnlContainer.Controls.ContainsKey("ForgotPasswordPage"))
            {
                ForgotPasswordPage forgotPasswordPage = new ForgotPasswordPage(client);
                Form1.Instance.PnlContainer.Controls.Add(forgotPasswordPage);
            }
            Form1.Instance.PnlContainer.Controls["ForgotPasswordPage"].BringToFront();
            Position.currentPage = "ForgotPasswordPage";

        }

        private void btnDoneLogin_Click(object sender, EventArgs e)
        {
            //check login details...
            string username = boxUsernameLogin.Text;
            string password = boxPasswordLogin.Text;

            // Convert password to MD5
            var md5Hash = MD5.Create(); //Creates an instance of the MD5 hash algorithm.
            var sourceBytes = Encoding.ASCII.GetBytes(password); // Byte array representation of the password
            var hashBytes = md5Hash.ComputeHash(sourceBytes); // Generate hash value (in Byte Array) of the input
            var hash = BitConverter.ToString(hashBytes).Replace("-", string.Empty); // Convert hash byte array to string

            client.Send($"[{username},{hash}]");
            string response = client.Receive();
            if (response != "Logged in")
            {
                MessageBoxIcon error = MessageBoxIcon.Error;
                MessageBox.Show(response, "Oops...", MessageBoxButtons.OK, error);
            }
            else
            {
                if (!Form1.Instance.PnlContainer.Controls.ContainsKey("UserProfilePage"))
                {
                    UserProfilePage userProfilePage = new UserProfilePage(client);
                    Form1.Instance.PnlContainer.Controls.Add(userProfilePage);
                }
                Form1.Instance.PnlContainer.Controls["UserProfilePage"].BringToFront();
                Position.currentPage = "UserProfilePage";
                Form1.Instance.BackButton.Visible = false;

            }
        }
    }
}
