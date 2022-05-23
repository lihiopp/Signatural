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
        private string username;
        private string rootpath = @"C:\Users\idd\Desktop\Michals\cyber\Signatural\";
        public UserProfilePage(Client theClient,string username,string filename)
        {
            InitializeComponent();
            Form1.Instance.BackButton.Visible = false;
            client = theClient;
            this.username = username;
            lblHelloUser.Text += username;
            pictureBox1.Image = Image.FromFile(System.Environment.GetFolderPath
                (System.Environment.SpecialFolder.Personal) + "_graph.png");
            this.Controls.Add(pictureBox1);
        }

        private void btnSendFile_Click(object sender, EventArgs e)
        {
            client.Send("Send file");
            if (!Form1.Instance.PnlContainer.Controls.ContainsKey("SendFilePage"))
            {
                SendFilePage sendFilePage = new SendFilePage(client);
                Form1.Instance.PnlContainer.Controls.Add(sendFilePage);
            }
            Form1.Instance.PnlContainer.Controls["SendFilePage"].BringToFront();
            Form1.Instance.PnlContainer.Controls.Remove(Controls["userProfilePage"]);
            Form1.Instance.PnlContainer.Visible = true;
            StaticClass.currentPage = "SendFilePage";
        }

        private void btnSignFile_Click(object sender, EventArgs e)
        {
            // Gets request from other user thorugh the server
            btnSignFile.BackColor = Color.AliceBlue;
            string msg = client.Receive();
            MessageBoxIcon icon = MessageBoxIcon.Information;
            DialogResult result = MessageBox.Show(msg, "Hey there!", MessageBoxButtons.YesNo, icon);
            if(result == DialogResult.Yes)
            {
                client.Send("Yes");
                // Gets needed file
                string filename = client.Receive();
                client.GetFile(filename);
                
                if (!Form1.Instance.PnlContainer.Controls.ContainsKey("SignFilePage"))
                {
                    SignFilePage signFilePage = new SignFilePage(client,rootpath+filename,this.username);
                    Form1.Instance.PnlContainer.Controls.Add(signFilePage);
                }
                Form1.Instance.PnlContainer.Controls["SignFilePage"].BringToFront();
                Form1.Instance.PnlContainer.Controls.Remove(Controls["userProfilePage"]);
            }
            else
            {
                btnSignFile.BackColor = Color.DodgerBlue;
            }
        }
    }
}
