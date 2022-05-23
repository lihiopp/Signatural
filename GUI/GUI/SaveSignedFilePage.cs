using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class SaveSignedFilePage : UserControl
    {
        private Client client;
        private string path = "C:\\Users\\idd\\Desktop\\Michals\\cyber\\Signatural\\filesReceived\\";
        public SaveSignedFilePage(Client theClient,string filename)
        {
            InitializeComponent();
            this.path = this.path + filename;
            webBrowser1.Navigate(this.path);
            webBrowser1.Invalidate();
            Form1.Instance.BackButton.Visible = false;
            client = theClient;
        }

        private void btnSaveFile_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog
            {
                InitialDirectory = @"C:\", //root directory
                Title = "Save PDF File", //title of window
                CheckFileExists = false, //alert if user stated a nonexisting file
                CheckPathExists = true, //alert if user stated a nonexisting path
                DefaultExt = "pdf", //filter - show only pdf files
                Filter = "pdf files (*.pdf)|*.pdf",
                FilterIndex = 2,
            };
            saveDialog.FileName = filenamebox.Text;
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                string filepath = saveDialog.FileName; // In case the user changed it inside the dialog
                
                // Copy file to the user's wanted location
                FileInfo fi1 = new FileInfo(this.path);
                FileInfo fi2 = new FileInfo(filepath);
                fi1.CopyTo(filepath);

                Form1.Instance.PnlContainer.Controls["UserProfilePage"].BringToFront();
                StaticClass.currentPage = "UserProfilePage";

                // So the page will have to be created with a new filename 
                // in each and every deal, and the page won't just be brought to front with
                // the incorrect filename.
                Form1.Instance.PnlContainer.Controls.Remove(Controls["SaveSignedFilePage"]);
            }
        }
    }
}
