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
using System.Threading;

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
        int offset = 0;
        bool scrollWatcherThreadEnd = false, dataEOF = false;
        Thread scrollerWatcher;

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
            offset++;
        }

        private void radChatBox_SendMessage(object sender, SendMessageEventArgs e)
        {
            ChatTextMessage textMessage = e.Message as ChatTextMessage;
            radChatBox.AddMessage(textMessage);
            socketIOManager.SendMessage(textMessage.Message, curentUserId);
            //offset++;
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
            if(curentUserId != ((QuickDisplayMess)sender).userID)
            {
                radChatBox.ChatElement.MessagesViewElement.Items.Clear();
                offset = 0;
                dataEOF = false;
                curentUserId = ((QuickDisplayMess)sender).userID;
                guest = new Author(Image.FromFile(@".\temp\" + curentUserId + ".jpg"), curentUserId);
                lblUser.Text = ((QuickDisplayMess)sender).userName;
                pictureBox.Image = Image.FromFile(@".\temp\" + curentUserId + ".jpg");

                //ArrayList arrResult = databaseManager.getCustomerMessageById(curentUserId);
                ArrayList arrResult = databaseManager.getCustomerMessageById(curentUserId);
                int numOfResult = arrResult.Count;
                //for(int i = numOfResult - 1; i >=0; i--)
                foreach (Model.Message record in arrResult)
                {
                    //Model.Message record = (Model.Message)arrResult[i];
                    ChatTextMessage mess;
                    if (record.msgSenderID.Equals(Config.ownerID))
                        mess = new ChatTextMessage(record.msgText, radChatBox.Author, DateTime.Parse(record.msgTime));
                    else
                    {
                        mess = new ChatTextMessage(record.msgText, guest, DateTime.Parse(record.msgTime));
                    }
                    radChatBox.AddMessage(mess);
                }
                offset += numOfResult;
            }
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

        //private void ChangePosition(int numOfResult)
        //{
        //    ArrayList arrayList = new ArrayList();
        //    arrayList.AddRange(radChatBox.ChatElement.MessagesViewElement.Items);
        //    ArrayList newElement = new ArrayList(numOfResult);
        //    for(int i = arrayList.Count - numOfResult - 1, cur = 0; cur < numOfResult ; i++, cur--)
        //    {
        //        // copy last "numOfResult" element to array
        //        newElement[cur] = arrayList[i];
        //    }
        //    // create newDesiredArray
        //    for(int i = arrayList.Count - 1, cur = arrayList.Count - numOfResult - 1; cur >= 0; i--, cur--)
        //    {
        //        arrayList[i] = arrayList[cur];
        //    }
        //    for(int i = 0; i < numOfResult; i++)
        //    {
        //        arrayList[i] = newElement[i];
        //    }
        //    for(int i = 0; i < arrayList.Count; i++)
        //    {
        //        radChatBox.ChatElement.MessagesViewElement.Items[i] = (BaseChatDataItem)arrayList[i];
        //    }
        //}

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            scrollWatcherThreadEnd = true;
            scrollerWatcher.Abort();
        }
    }
}
