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
            Position.currentPage = "HomePage";
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if(Position.currentPage == "LoginPage" || Position.currentPage == "SignupPage")
            {
                panelContainer.Controls["HomePage"].BringToFront();
                Position.currentPage = "HomePage";
                btnBack.Visible = false;
            }
            switch (Position.currentPage)
            {
                case "ForgotPasswordPage":
                    {
                        panelContainer.Controls["LoginPage"].BringToFront();
                        Position.currentPage = "LoginPage";
                        break;
                    }
                case ("SendFilePage"):
                    {
                        panelContainer.Controls["UserProfilePage"].BringToFront();
                        Position.currentPage = "UserProfilePage";
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
            client = new Client(55876);
            return result;
        }
    }
}
