using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class EmailVerificationPage : UserControl
    {
        private Client client;
        private int verification_code;
        private string rootpath = @"C:\Users\idd\Desktop\Michals\cyber\Signatural\";
        private string username;

        public EmailVerificationPage(Client theClient, string verification_code,string username)
        {
            InitializeComponent();
            Form1.Instance.BackButton.Visible = false;
            client = theClient;
            this.verification_code = Int32.Parse(verification_code);
            this.username = username;

        }

        private void btnOkEmailVerification_Click(object sender, EventArgs e)
        {
            //check verification code
            int input_code = Int32.Parse(boxActivateAccCode.Text);
            if (verification_code != input_code)
            {
                MessageBoxIcon icon = MessageBoxIcon.Error;
                MessageBox.Show("Wrong code.", "Oops...!", MessageBoxButtons.OK, icon);
            }
            else
            {
                client.Send("Valid");
                // Get the new user's signature
                GetSignature();
                client.SendFile(this.rootpath + username);
                MessageBoxIcon icon = MessageBoxIcon.Information;
                MessageBox.Show("You've successfully signed up!\r\nLog in with your new Account.", "Success!", MessageBoxButtons.OK, icon);
                Form1.Instance.PnlContainer.Controls["HomePage"].BringToFront();
                StaticClass.currentPage = "HomePage";
            }
        }

        private void GetSignature()
        {
            string script = this.rootpath + "enterSignatureWindow.py";
            var psi = new ProcessStartInfo();
            psi.FileName = @"C:\Users\idd\AppData\Local\Programs\Python\Python38-32\python.exe";
            psi.Arguments = string.Format(script + " " + this.username);
            psi.UseShellExecute = false;
            psi.CreateNoWindow = true;
            psi.RedirectStandardOutput = true;
            psi.RedirectStandardError = true;
            var errors = "";
            var result = "";
            using (var process = Process.Start(psi))
            {
                errors = process.StandardError.ReadToEnd();
                result = process.StandardOutput.ReadToEnd();
                process.WaitForExit();
            }
        }
    }
}
