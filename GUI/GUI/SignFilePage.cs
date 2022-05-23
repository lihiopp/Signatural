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
    public partial class SignFilePage : UserControl
    {
        private Client client;
        private string username;
        private string rootpath = @"C:\Users\idd\Desktop\Michals\cyber\Signatural\";
        private string filepath;
        public SignFilePage(Client theClient,string filepath,string username)
        {
            InitializeComponent();
            btnSendFileBack.Visible = false;
            webBrowser1.Navigate(filepath);
            webBrowser1.Invalidate();
            Form1.Instance.BackButton.Visible = false;
            client = theClient;
            this.username = username;
            this.filepath = filepath;
        }

        private void btnSignFile_Click(object sender, EventArgs e)
        {
            //open signature drawing window...
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
            // send signature, get response
            client.SendFile(this.rootpath + result);
            string response = client.Receive();
            if (response == "real")
            {
                AddSignatureToFile(this.filepath, this.rootpath + result);
                btnSendFileBack.Visible = true;
            }
            else
            {
                MessageBoxIcon icon = MessageBoxIcon.Stop;
                MessageBox.Show("This signature is a forgery!", "The Deal's Off!", MessageBoxButtons.OK, icon);
                Form1.Instance.PnlContainer.Controls["UserProfilePage"].BringToFront();
                StaticClass.currentPage = "UserProfilePage";
                Form1.Instance.PnlContainer.Controls.Remove(Controls["SignFilePage"]);
            }
        }

        private void AddSignatureToFile(string filepath, string signature)
        {
            string script = this.rootpath + "addSigtoPDF.py";
            var psi = new ProcessStartInfo();
            psi.FileName = @"C:\Users\idd\AppData\Local\Programs\Python\Python38-32\python.exe";
            psi.Arguments = string.Format(script + " " + filepath + " " + signature);
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

        private void btnSendFileBack_Click(object sender, EventArgs e)
        {
            //send signed file to server...
            client.SendFile(this.filepath);
            Form1.Instance.PnlContainer.Controls["UserProfilePage"].BringToFront();
            StaticClass.currentPage = "UserProfilePage";
            Form1.Instance.PnlContainer.Controls.Remove(Controls["SignFilePage"]);
        }
    }
}
