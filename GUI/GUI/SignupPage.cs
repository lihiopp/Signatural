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
    public partial class SignupPage : UserControl
    {
        private Client client;
        public SignupPage(Client theClient)
        {
            InitializeComponent();
            Form1.Instance.BackButton.Visible = true;
            client = theClient;
        }

        private void btnDoneSignup_Click(object sender, EventArgs e)
        {
            string username = boxUsernameSignup.Text;
            string password = boxPasswordSignup.Text;
            string email = boxEmailSignup.Text;
            if(password.Length<6)
            {
                MessageBoxIcon error = MessageBoxIcon.Error;
                MessageBox.Show("Password must be at least 6 characters.", "Oops...", MessageBoxButtons.OK, error);
                return;
            }
            //checks details...
            client.Send($"[{username},{password},{email}]");
            string response = client.Receive();
            if (response == "Valid")
            {
                //email verification here!!!!
                //get signature here!!!!
                if (!Form1.Instance.PnlContainer.Controls.ContainsKey("EmailVerificationPage"))
                {
                    EmailVerificationPage emailVerificationPage = new EmailVerificationPage(client);
                    Form1.Instance.PnlContainer.Controls.Add(emailVerificationPage);
                }
                Form1.Instance.PnlContainer.Controls["emailVerificationPage"].BringToFront();
            }
            else
            {
                MessageBoxIcon error = MessageBoxIcon.Error;
                MessageBox.Show(response, "Oops...", MessageBoxButtons.OK, error);
            }

        }
    }
}
