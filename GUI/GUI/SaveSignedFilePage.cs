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
    public partial class SaveSignedFilePage : UserControl
    {
        private Client client;
        public SaveSignedFilePage(Client theClient,string path)
        {
            InitializeComponent();
            webBrowser1.Navigate(path);
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
                string filepath = saveDialog.FileName; //in case the user changed it inside the dialog
                //save file (or copy) to the wanted location - filepath

            }
            Form1.Instance.PnlContainer.Controls["UserProfilePage"].BringToFront();
            Position.currentPage = "UserProfilePage";
        }
    }
}
