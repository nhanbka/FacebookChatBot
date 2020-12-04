using System;
using System.Collections;
using System.Windows.Forms;
using ManagerChatBox.Database;
using Telerik.WinControls.UI;
using ManagerChatBox.Connection;
using System.Net;
using System.IO;
using ManagerChatBox.Model;
using ManagerChatBox.Component;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Drawing;
using System.Drawing.Imaging;

namespace ManagerChatBox
{
    public partial class Form1 : Form
    {
        Author guest;
        //Socket socket;
        List<string> userManager;
        SocketIOManager socketIOManager;
        public string curentUserId = "";
        DatabaseManager databaseManager;

        public Form1()
        {
            InitializeComponent();
            userManager = new List<string>();
            databaseManager = new DatabaseManager();                        // Init connection with database
            socketIOManager = new SocketIOManager(ref radChatBox, this);    // Init connection with socketIO server
            try
            {
                radChatBox.Author = new Author(Image.FromFile(@".\temp\manager_ava.png"), "Lê Trọng Nhân");
            } catch (FileNotFoundException fileNotFound)
            {
                Console.WriteLine("Cannot find file manager_ava.png in temp folder");
                radChatBox.Author = new Author(null, "Lê Trọng Nhân");
            }
            
            radChatBox.AutoAddUserMessages = false;
            radChatBox.SendMessage += radChatBox_SendMessage;
            //addNewUserToPanel("3181701225285372");
        }

        public void updateChat(string newMsg)
        {
            ChatTextMessage mess = new ChatTextMessage(newMsg, guest, DateTime.UtcNow);
            radChatBox.AddMessage(mess);
        }

        private void radChatBox_SendMessage(object sender, SendMessageEventArgs e)
        {
            ChatTextMessage textMessage = e.Message as ChatTextMessage;
            radChatBox.AddMessage(textMessage);
            socketIOManager.SendMessage(textMessage.Message, curentUserId);
        }

        public void addNewUserToPanel(string userId)
        {
            foreach (string id in userManager)
            {
                if (userId.Equals(id))
                    return;
            }
            userManager.Add(userId);
            QuickDisplayMess quickDisplayMess = new QuickDisplayMess(userId);
            quickDisplayMess.lastMessTime = "Last mess:" + databaseManager.getLastMessageTime(userId);
            quickDisplayMess.Name = "quickDisplayMess" + userId;
            flowLayoutUserManager.Controls.Add(quickDisplayMess);
            quickDisplayMess.MouseClick += new MouseEventHandler(QuickDisplayMess_MouseClick);
        }

        void QuickDisplayMess_MouseClick(object sender, MouseEventArgs e)
        {
            curentUserId = ((QuickDisplayMess)sender).userID;
            guest = new Author(Image.FromFile(@".\temp\" + curentUserId + ".jpg"), curentUserId);
            lblUser.Text = ((QuickDisplayMess)sender).userName;
            pictureBox.Image = Image.FromFile(@".\temp\" + curentUserId + ".jpg");

            ArrayList arrResult = databaseManager.getCustomerMessageById(curentUserId);
            foreach (Model.Message record in arrResult)
            {
                ChatTextMessage mess;
                if (record.msgSenderID.Equals(Config.ownerID))
                    mess = new ChatTextMessage(record.msgText, radChatBox.Author, DateTime.Parse(record.msgTime));
                else
                {
                    mess = new ChatTextMessage(record.msgText, guest, DateTime.Parse(record.msgTime));
                }
                radChatBox.AddMessage(mess);
            }
        }

        private void radChatBox_Scroll(object sender, ScrollEventArgs e)
        {
            MessageBox.Show(radChatBox.ChatElement.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(curentUserId != "")
            {
                socketIOManager.FinishHandle(curentUserId);
                radChatBox.ChatElement.MessagesViewElement.Items.Clear();
                pictureBox.Image.Dispose();
                Control control = Controls.Find("quickDisplayMess" + curentUserId, true)[0];
                flowLayoutUserManager.Controls.Remove(control);
                control.Dispose();
                lblUser.Text = "";
                userManager.Remove(curentUserId);
                curentUserId = "";
            }
        }
    }
}
