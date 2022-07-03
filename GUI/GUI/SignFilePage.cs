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
using System.Threading;

namespace GUI
{
    public partial class SignFilePage : UserControl
    {
        private Client client;
        private string username;
        private string rootpath = @"C:\Users\student\Desktop\try\Signatural\";
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
            if (boxPageNumber.Text == "")
            {
                MessageBoxIcon icon = MessageBoxIcon.Error;
                MessageBox.Show("You have to specify the page you are signing.", "Oops...", MessageBoxButtons.OK, icon);
            }
            else
            {
                string pictureName = this.username + "_sig";
                //open signature drawing window...
                string script = this.rootpath + "enterSignatureWindow.py";
                var psi = new ProcessStartInfo();
                psi.FileName = @"C:\Users\student\AppData\Local\Programs\Python\Python38\python.exe";
                psi.Arguments = string.Format(script + " " + pictureName);
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
                // Upload the signature to google drive
                StaticClass.GoogleDrive("upload", @"C:\Users\student\Desktop\try\Signatural\GUI\GUI\bin\Debug\"+pictureName,pictureName);
                // Get result - real signature of forgery.
                string response = client.Receive();
                if (response.Split(',')[0] == "real")
                {   
                    if(response.Split(',')[1] == "Failed")
                    {
                        MessageBoxIcon icon = MessageBoxIcon.Error;
                        MessageBox.Show("Page out of boundries.", "Oops...", MessageBoxButtons.OK, icon);
                        Form1.Instance.PnlContainer.Controls["UserProfilePage"].BringToFront();
                        StaticClass.currentPage = "UserProfilePage";
                    }
                    else
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
        }

        private void btnSendFileBack_Click(object sender, EventArgs e)
        {
            if (!Form1.Instance.PnlContainer.Controls.ContainsKey("UserProfilePage"))
            {
                UserProfilePage userProfilePage = new UserProfilePage(client,username);
                Form1.Instance.PnlContainer.Controls.Add(userProfilePage);
            }
            Form1.Instance.PnlContainer.Controls["UserProfilePage"].BringToFront();
            StaticClass.currentPage = "UserProfilePage";
            Form1.Instance.PnlContainer.Controls.Remove(Controls["SignFilePage"]);
        }
    }
}
