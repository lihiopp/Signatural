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
    public partial class EmailVerificationPage : UserControl
    {
        private Client client;
        public EmailVerificationPage(Client theClient)
        {
            InitializeComponent();
            Form1.Instance.BackButton.Visible = false;
            client = theClient;
        }

        private void btnOkEmailVerification_Click(object sender, EventArgs e)
        {
            //check verification code
            MessageBoxIcon icon = MessageBoxIcon.Information;
            MessageBox.Show("You've successfully signed up!\r\nLog in with your new Account.", "Success!", MessageBoxButtons.OK, icon);
            Form1.Instance.PnlContainer.Controls["HomePage"].BringToFront();
        }
    }
}
