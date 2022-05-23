using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class ResetPasswordPage : UserControl
    {
        private Client client;
        public ResetPasswordPage(Client theClient)
        {
            InitializeComponent();
            Form1.Instance.BackButton.Visible = false;
            client = theClient;
        }

        private void btnDoneResetPassword_Click(object sender, EventArgs e)
        {
            string newPass = boxNewPassword.Text;
            string newPass2 = boxNewPassword2.Text;
            if (newPass.Length < 6)
            {
                MessageBoxIcon icon1 = MessageBoxIcon.Error;
                MessageBox.Show("Password must be a least 6 charachters.", "Oops...", MessageBoxButtons.OK, icon1);
            }
            else if (newPass == newPass2)
            {
                var md5Hash = MD5.Create(); //Creates an instance of the MD5 hash algorithm.
                var sourceBytes = Encoding.ASCII.GetBytes(newPass); // Byte array representation of the password
                var hashBytes = md5Hash.ComputeHash(sourceBytes); // Generate hash value (in Byte Array) of the input
                var hash = BitConverter.ToString(hashBytes).Replace("-", string.Empty);

                client.Send(hash); // not sending the new password for some reason!!
                MessageBoxIcon icon2 = MessageBoxIcon.Information;
                MessageBox.Show("Your password has been reset.\r\nReturning to home page.", "Success!", MessageBoxButtons.OK, icon2);
                Form1.Instance.PnlContainer.Controls["HomePage"].BringToFront();
                StaticClass.currentPage = "HomePage";
            }
            else
            {
                MessageBoxIcon icon3 = MessageBoxIcon.Error;
                MessageBox.Show("The passwords you've entered are not the same.", "Oops...", MessageBoxButtons.OK, icon3);
            }
        }
    }
}
