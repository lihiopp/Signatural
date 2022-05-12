using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
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
            //checks details...
            client.Send($"[{username},{password},{email}]");
            string response = client.Receive();
            if (response == "Valid")
            {
                //email verification here!!!!
                string verificationCode = EmailVerification(username, email);
                //get signature here!!!!
                if (!Form1.Instance.PnlContainer.Controls.ContainsKey("EmailVerificationPage"))
                {
                    EmailVerificationPage emailVerificationPage = new EmailVerificationPage(client,verificationCode);
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

        /// <summary>
        /// Runs python program that sends verification code to the user's email and gets the code generated in it.
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="args"></param>
        private string EmailVerification(string username, string email)
        {
            string script = @"C:\Users\student\Desktop\emailVerify.py";
            string func = "send_verify";
            var psi = new ProcessStartInfo();
            psi.FileName = @"C:\Users\student\AppData\Local\Programs\Python\Python38\python.exe"; //my/full/path/to/python.exe
            psi.Arguments = string.Format("C:\\Users\\student\\Desktop\\emailVerify.py" + " " + "send_email" + " " + username + " " + email); //cmd, args
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
                Console.WriteLine(result);
            }
            return result;
        }
    }
}
