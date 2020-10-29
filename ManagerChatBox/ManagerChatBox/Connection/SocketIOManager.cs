using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
//using Quobject.SocketIoClientDotNet.Client;
using SocketIOClient;
using Telerik.WinControls.UI;

namespace ManagerChatBox.Connection
{
    class SocketIOManager
    {
        SocketIO socket;
        RadChat chatBox;
        Form1 mainForm;
        public SocketIOManager(ref RadChat chatBox, Form1 mainForm)
        {
            this.chatBox = chatBox;
            this.mainForm = mainForm;
            socket = new SocketIO("http://localhost:3000/");
            socket.ConnectAsync();
            socket.On("hi", response =>
            {
                string text = response.GetValue<string>();
            });
            socket.OnConnected += async (sender, e) =>
            {
                await socket.EmitAsync("hi", ".net core");
            };
            socket.On("new_unhandled_id", response =>
            {
                string id = response.GetValue<string>();
                mainForm.addCbBoxOption(id);
            });
        }

        public void SendMessage(string message, string senderID)
        {
            var jsonObject = new JObject();
            jsonObject.Add("responseMess", message);
            jsonObject.Add("senderID", senderID);
            string toStringObject = jsonObject.ToString();
            socket.EmitAsync("owner_answer", jsonObject.ToString());
        }
    }
}
