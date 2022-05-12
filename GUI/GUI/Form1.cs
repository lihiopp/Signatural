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
    public partial class Form1 : System.Windows.Forms.Form
    {
        static Form1 _obj;
        public string currentPage;
        private Client client;
        public static Form1 Instance
        {
            get
            {
                if (_obj == null)
                    _obj = new Form1();
                return _obj;
            }
        }

        public Panel PnlContainer
        {
            get { return panelContainer; }
            set { panelContainer = value; }
        }

        public Button LougoutButton
        {
            get { return btnLogout; }
            set { btnLogout = value; }
        }

        public Button BackButton
        {
            get { return btnBack; }
            set { btnBack = value; }
        }

        public Form1()
        {
            InitializeComponent();
            backgroundWorker1.RunWorkerAsync(2000);
            currentPage = "HomePage";

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnBack.Visible = false;
            _obj = this;

            HomePage homePage = new HomePage(client);
            homePage.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(homePage);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if(currentPage == "LoginPage" || currentPage == "SignupPage")
            {
                panelContainer.Controls["HomePage"].BringToFront();
                btnBack.Visible = false;
            }
            //if(currentPage== "ResetPasswordPage" || currentPage=="UserProfilePage")
                //btnBack.Visible = false;
            //if(currentPage=="EmailVerificationPage"||currentPage=="SignFilePage")
                //btnBack.Visible = false;
            //if(currentPage=="SaveSignedFilePage")
                //btnBack.Visible = false;
            switch (currentPage)
            {
                case "ForgotPasswordPage":
                    {
                        panelContainer.Controls["LoginPage"].BringToFront();
                        break;
                    }
                case ("SendFilePage"):
                    {
                        panelContainer.Controls["UserProfilePage"].BringToFront();
                        break;
                    }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            client.Close();
            this.Close();
        }

        private void btnTwitter_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://twitter.com");
        }

        private void btnInsta_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://instagram.com");
        }

        private void btnLinkedin_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://linkedin.com");
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            MessageBoxIcon icon = MessageBoxIcon.Warning;
            DialogResult result = MessageBox.Show("Are you sure you want to leave?", "Wait!", MessageBoxButtons.YesNo, icon);
            if (result == DialogResult.Yes)
            {
                //send server action==logout so that it swiched username fo client_id in the dictioanry
                panelContainer.Controls["HomePage"].BringToFront();
                panelContainer.Controls.Clear();
                panelContainer.Controls.Add(new HomePage(client));
                btnBack.Visible = false;
                btnLogout.Visible = false;
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker helperBW = sender as BackgroundWorker;
            int arg = (int)e.Argument;
            e.Result = BackgroundProcessLogicMethod(helperBW, arg);
            if (helperBW.CancellationPending)
            {
                e.Cancel = true;
            }
        }
        private int BackgroundProcessLogicMethod(BackgroundWorker bw, int a)
        {
            int result = 0;
            client = new Client(54876);
            return result;
        }
    }
}
