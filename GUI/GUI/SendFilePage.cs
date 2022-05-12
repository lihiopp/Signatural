using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class SendFilePage : UserControl
    {
        private Client client;
        public SendFilePage(Client theClient)
        {
            InitializeComponent();
            browseFilesPanel.Visible = false;
            btnSendFile.Visible = false;
            //lblSignerUserStatus.Text = "";
            Form1.Instance.BackButton.Visible = true ;
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
            //send file to server
            if (!Form1.Instance.PnlContainer.Controls.ContainsKey("SaveSignedFilePage"))
            {
                SaveSignedFilePage saveSignedFilePage = new SaveSignedFilePage(client,filenamebox.Text);
                Form1.Instance.PnlContainer.Controls.Add(saveSignedFilePage);
            }
            Form1.Instance.PnlContainer.Controls["SaveSignedFilePage"].BringToFront();
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
                if (lblSignerUserStatus.Text == "User accepted your request")
                    browseFilesPanel.Visible = true;
            }
        }
    }
}
