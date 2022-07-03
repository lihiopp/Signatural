using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class SignupPage : UserControl
    {
        private Client client;
        public SignupPage(Client theClient)
        {
            InitializeComponent();
            Form1.Instance.BackButton.Visible = true;
            client = theClient;
        }

        private void btnDoneSignup_Click(object sender, EventArgs e)
        {
            string username = boxUsernameSignup.Text;
            string password = boxPasswordSignup.Text;
            string email = boxEmailSignup.Text;
            if(password.Length<6)
            {
                MessageBoxIcon error = MessageBoxIcon.Error;
                MessageBox.Show("Password must be at least 6 characters.", "Oops...", MessageBoxButtons.OK, error);
                return;
            }
            var md5Hash = MD5.Create(); //Creates an instance of the MD5 hash algorithm.
            var sourceBytes = Encoding.ASCII.GetBytes(password); // Byte array representation of the password
            var hashBytes = md5Hash.ComputeHash(sourceBytes); // Generate hash value (in Byte Array) of the input
            var hash = BitConverter.ToString(hashBytes).Replace("-", string.Empty); // Convert hash byte array to string

            //checks details...
            client.Send($"[{username},{hash},{email}]");
            string response = client.Receive();
            if (response == "Valid")
            {
                //email verification
                string verificationCode = StaticClass.EmailVerification(email);

                if (!Form1.Instance.PnlContainer.Controls.ContainsKey("EmailVerificationPage"))
                {
                    EmailVerificationPage emailVerificationPage = new EmailVerificationPage(client,verificationCode, username);
                    Form1.Instance.PnlContainer.Controls.Add(emailVerificationPage);
                }
                Form1.Instance.PnlContainer.Controls["emailVerificationPage"].BringToFront();
            }
            else
            {
                MessageBoxIcon error = MessageBoxIcon.Error;
                MessageBox.Show(response, "Oops...", MessageBoxButtons.OK, error);
            }
        }
        
    }
}
