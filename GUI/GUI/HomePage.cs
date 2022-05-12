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
    public partial class HomePage : UserControl
    {
        private Client client;
        public HomePage(Client theClient)
        {
            InitializeComponent();
            Form1.Instance.BackButton.Visible = false;
            client = theClient;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            client.Send("[Login]");
            if(!Form1.Instance.PnlContainer.Controls.ContainsKey("LoginPage"))
            {
                LoginPage loginPage = new LoginPage(client);
                Form1.Instance.PnlContainer.Controls.Add(loginPage);
            }
            Form1.Instance.PnlContainer.Controls["LoginPage"].BringToFront();
            Form1.Instance.BackButton.Visible = true;
            Position.currentPage = "LoginPage";
        }

        private void btnSignup_Click(object sender, EventArgs e)
        {
            client.Send("[Signup]");
            if (!Form1.Instance.PnlContainer.Controls.ContainsKey("SignupPage"))
            {
                SignupPage signupPage = new SignupPage(client);
                Form1.Instance.PnlContainer.Controls.Add(signupPage);
            }
            Form1.Instance.PnlContainer.Controls["SignupPage"].BringToFront();
            Form1.Instance.BackButton.Visible = true;
            Position.currentPage = "SignupPage";
        }
    }
}
