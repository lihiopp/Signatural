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
        private string verification_code;
        public EmailVerificationPage(Client theClient, string verification_code)
        {
            InitializeComponent();
            Form1.Instance.BackButton.Visible = false;
            client = theClient;
            this.verification_code = verification_code;
        }

        private void btnOkEmailVerification_Click(object sender, EventArgs e)
        {
            //check verification code
            string input_code = boxActivateAccCode.Text;
            if (verification_code == input_code)
            {
                MessageBoxIcon icon = MessageBoxIcon.Information;
                MessageBox.Show("You've successfully signed up!\r\nLog in with your new Account.", "Success!", MessageBoxButtons.OK, icon);
                Form1.Instance.PnlContainer.Controls["HomePage"].BringToFront();
                Position.currentPage = "HomePage";
            }
            else
            {
                MessageBoxIcon icon = MessageBoxIcon.Error;
                MessageBox.Show("Wrong code.", "Oops...!", MessageBoxButtons.OK, icon);
            }
        }
    }
}
