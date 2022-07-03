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
        private string rootpath = @"C:\Users\student\Desktop\try\Signatural";
        private string username;

        public EmailVerificationPage(Client theClient, string verification_code,string username)
        {
            InitializeComponent();
            Form1.Instance.BackButton.Visible = false;
            client = theClient;
            this.verification_code = Int32.Parse(verification_code);
            this.username = username;
            Console.WriteLine(this.username);

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
                // Get the new user's signature
                string path = this.rootpath + @"\GUI\GUI\bin\Debug\";
                string filename = path + GetSignature();
                filename = filename.Substring(0, filename.Length - 2);
                StaticClass.GoogleDrive("upload",filename,filename);                
                MessageBoxIcon icon = MessageBoxIcon.Information;
                MessageBox.Show("You've successfully signed up!\r\nLog in with your new Account.", "Success!", MessageBoxButtons.OK, icon);
                Form1.Instance.PnlContainer.Controls["HomePage"].BringToFront();
                StaticClass.currentPage = "HomePage";
            }
        }

        private string GetSignature()
        {
            string script = this.rootpath + @"\enterSignatureWindow.py";
            var psi = new ProcessStartInfo();
            psi.FileName = @"C:\Users\student\AppData\Local\Programs\Python\Python38\python.exe";
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
            return result;
        }
    }
}
