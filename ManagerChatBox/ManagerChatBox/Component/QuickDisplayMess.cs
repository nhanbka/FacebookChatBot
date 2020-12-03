using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;
using ManagerChatBox.Connection;
using ManagerChatBox.Model;
using Newtonsoft.Json;

namespace ManagerChatBox.Component
{
    public partial class QuickDisplayMess : UserControl
    {

        // Declare parameter
        public string userID;
        public string userName;

        // Declare function
        public QuickDisplayMess()
        {
            InitializeComponent();
        }

        public QuickDisplayMess(string userID)
        {
            this.userID = userID;
            InitializeComponent();
            string response = HTTPRequestManager.Get(@"https://graph.facebook.com/" + userID + "?fields=first_name,last_name,profile_pic&access_token=" + Config.PAGE_ACCESS_TOKEN);
            Console.WriteLine(response);
            User newUser = JsonConvert.DeserializeObject<User>(response);
            string filePath = @".\temp\" + userID + ".jpg";
            if (!File.Exists(filePath))
            {
                using (WebClient client = new WebClient())
                {
                    client.DownloadFile(new Uri(newUser.profile_pic), filePath);
                    client.Dispose();
                }
            }
            this.avatarImage.Image = Image.FromFile(filePath);
            userName = newUser.last_name + " " + newUser.first_name;
            this.lblUsername.Text = userName;
        }

        private void QuickDisplayMess_MouseClick(object sender, MouseEventArgs e)
        {

        }
    }
}
