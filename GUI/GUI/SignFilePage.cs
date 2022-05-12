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
    public partial class SignFilePage : UserControl
    {
        private Client client;
        public SignFilePage(Client theClient,string path)
        {
            InitializeComponent();
            btnSendFileBack.Visible = false;
            webBrowser1.Navigate(path);
            webBrowser1.Invalidate();
            Form1.Instance.BackButton.Visible = false;
            client = theClient;
        }

        private void btnSignFile_Click(object sender, EventArgs e)
        {
            //this Panel only shows up one you hit YES on the pop up! (background worker)
            //open signature drawing window...
            //check if forged or not, if it is - show a pop up and return to the user's profile.
            //show the signed file...
            btnSendFileBack.Visible = true; //everytime the sign page is opened it should be set to false.
        }

        private void btnSendFileBack_Click(object sender, EventArgs e)
        {
            //send signed file to server...
        }
    }
}
