using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace GUI
{
    public partial class SendFilePage : UserControl
    {
        private Client client;
        private string rootpath = @"C:\Users\student\Desktop\sender\Signatural\GUI\filesReceived\";
        public SendFilePage(Client theClient)
        {
            InitializeComponent();
            boxUsernameOfSigner.Text = "";
            filenamebox.Text = "";
            browseFilesPanel.Visible = false;
            btnSendFile.Visible = false;
            lblSignerUserStatus.Text = "...";
            Form1.Instance.BackButton.Visible = true;
            client = theClient;
        }

        private void btnBrowseFiles_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"C:\", //root directory
                Title = "Browse PDF Files", //title of window
                CheckFileExists = true, //alert if user stated a nonexisting file
                CheckPathExists = true, //alert if user stated a nonexisting path
                DefaultExt = "pdf", //filter - show only pdf files
                Filter = "pdf files (*.pdf)|*.pdf",
                FilterIndex = 2,
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filenamebox.Text = openFileDialog1.FileName;
                btnSendFile.Visible = true;
            }
        }

        private void btnSendFile_Click(object sender, EventArgs e)
        {
            // Uploads file and sends the filename to the server
            string filepath = filenamebox.Text;
            var title = filepath.Split('\\');
            int num = title.Length - 1;
            string title2 = title[num];
            StaticClass.GoogleDrive("upload", filepath, title2);
            client.Send(title2);

            // Gets notified if there was a forgery attempt or not (signature is real / forged)
            string response = client.Receive();
            if (response.Split(',')[0] == "real")
            {
                if (response.Split(',')[1] == "Failed")
                {
                    MessageBoxIcon icon = MessageBoxIcon.Error;
                    MessageBox.Show("Something went wrong. Process Failed.", "Oops...", MessageBoxButtons.OK, icon);
                    Form1.Instance.PnlContainer.Controls["UserProfilePage"].BringToFront();
                    StaticClass.currentPage = "UserProfilePage";
                    Form1.Instance.PnlContainer.Controls.Remove(Controls["SendFilePage"]);
                }
                else
                {
                    string filename = response.Split(',')[2];
                    StaticClass.GoogleDrive("download", filename, this.rootpath);

                    Form1.Instance.BackButton.Visible = false;
                    if (!Form1.Instance.PnlContainer.Controls.ContainsKey("SaveSignedFilePage"))
                    {
                        SaveSignedFilePage saveSignedFilePage = new SaveSignedFilePage(client, this.rootpath + filename);
                        Form1.Instance.PnlContainer.Controls.Add(saveSignedFilePage);
                    }
                    Form1.Instance.PnlContainer.Controls["SaveSignedFilePage"].BringToFront();
                    StaticClass.currentPage = "SaveSignedFilePage";
                    Form1.Instance.PnlContainer.Controls.Remove(Controls["SendFilePage"]);
                }
            }
            else
            {
                MessageBoxIcon icon = MessageBoxIcon.Stop;
                MessageBox.Show("This user tries to forge a signature!", "The Deal's Off!", MessageBoxButtons.OK, icon);
                Form1.Instance.PnlContainer.Controls["UserProfilePage"].BringToFront();
                StaticClass.currentPage = "UserProfilePage";
                Form1.Instance.PnlContainer.Controls.Remove(Controls["SendFilePage"]);
            }
        }

        private void btnOkSignerUsername_Click(object sender, EventArgs e)
        {
            //check signer user status
            if (boxUsernameOfSigner.Text == "")
            {
                MessageBoxIcon icon = MessageBoxIcon.Error;
                MessageBox.Show("You must enter a username in this field.", "Oops...", MessageBoxButtons.OK, icon);
            }
            else
            {
                client.Send(boxUsernameOfSigner.Text);
                string response = client.Receive();
                lblSignerUserStatus.Text = response;
                if (response == "User available")
                {
                    browseFilesPanel.Visible = true;
                }
            }
        }
    }
}
