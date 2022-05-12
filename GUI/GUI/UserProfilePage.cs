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
    public partial class UserProfilePage : UserControl
    {
        private Client client;
        public UserProfilePage(Client theClient)
        {
            InitializeComponent();
            Form1.Instance.BackButton.Visible = false;
            client = theClient;
        }

        private void btnSendFile_Click(object sender, EventArgs e)
        {
            if (!Form1.Instance.PnlContainer.Controls.ContainsKey("SendFilePage"))
            {
                SendFilePage sendFilePage = new SendFilePage(client);
                Form1.Instance.PnlContainer.Controls.Add(sendFilePage);
            }
            Form1.Instance.PnlContainer.Controls["SendFilePage"].BringToFront();
            Form1.Instance.PnlContainer.Visible = true;
            Position.currentPage = "SendFilePage";
        }
    }
}
