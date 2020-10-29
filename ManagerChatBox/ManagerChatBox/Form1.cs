using System;
using System.Collections;
using System.Windows.Forms;
using ManagerChatBox.Database;
using Telerik.WinControls.UI;
using ManagerChatBox.Connection;
//using Quobject.SocketIoClientDotNet.Client;

namespace ManagerChatBox
{
    public partial class Form1 : Form
    {
        String ownerID = "101714355046687";
        Author guest;
        //Socket socket;
        SocketIOManager socketIOManager;
        public Form1()
        {
            InitializeComponent();
            socketIOManager = new SocketIOManager(ref radChatBox, this);
            radChatBox.Author = new Author(null, "Lê Trọng Nhân");
            radChatBox.AutoAddUserMessages = false;
            radChatBox.SendMessage += radChatBox_SendMessage;
        }

        private void cbBoxUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            radChatBox.ChatElement.MessagesViewElement.Items.Clear();
            DatabaseManager databaseManager = new DatabaseManager();
            string userID = (string)cbBoxUsers.SelectedItem;
            guest = new Author(null, userID);
            ArrayList arrResult = databaseManager.getCustomerMessageById(userID);
            foreach (Record record in arrResult)
            {
                ChatTextMessage mess;
                if (record.msgSenderID.Equals(ownerID))
                    mess = new ChatTextMessage(record.msgText, radChatBox.Author, DateTime.Parse(record.msgTime));
                else
                {
                    mess = new ChatTextMessage(record.msgText, guest, DateTime.Parse(record.msgTime));
                }
                radChatBox.AddMessage(mess);
            }
        }

        private void radChatBox_SendMessage(object sender, SendMessageEventArgs e)
        {
            ChatTextMessage textMessage = e.Message as ChatTextMessage;
            radChatBox.AddMessage(textMessage);
            socketIOManager.SendMessage(textMessage.Message, (String)cbBoxUsers.SelectedItem);
        }

        public void addCbBoxOption(string id)
        {
            bool isAdd = true;
            foreach (string option in cbBoxUsers.Items)
            {
                if (option.Equals(id))
                {
                    isAdd = false;
                    break;
                }
            }
            if(isAdd) cbBoxUsers.Items.Add(id);
        }
    }
}
