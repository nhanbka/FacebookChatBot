using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
//using Quobject.SocketIoClientDotNet.Client;
using SocketIOClient;
using Telerik.WinControls.UI;

namespace ManagerChatBox.Connection
{
    [JsonObject(MemberSerialization.OptIn)]
    class PlainString
    {
        [JsonProperty]
        public string Data { get; set; }
        public PlainString() { }
        public string ToJsonString()
        {
            return JsonConvert.SerializeObject(this);
        }
        public static PlainString Deserialize(string jsonString)
        {
            return (PlainString)JsonConvert.DeserializeObject<PlainString>(jsonString);
        }
    }

    class UnhandleMessage
    {
        public string id { get; set; }
        public string message { get; set; }
    }

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
            socket.On("new_unhandled_id", data =>
            {
                dynamic results = JsonConvert.DeserializeObject<dynamic>(data.ToString());
                string id = (string)results[0]["id"];
                string message = (string)results[0]["message"];
                mainForm.Invoke((Action)delegate
                {
                    mainForm.addNewUserToPanel(id);
                    if (mainForm.curentUserId.Equals(id))
                    {
                        mainForm.updateChat(message);
                    }
                });
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

        public void FinishHandle(string id)
        {
            var jsonObject = new JObject();
            jsonObject.Add("fininshID", id);
            string toStringObject = jsonObject.ToString();
            socket.EmitAsync("finish_handle", jsonObject.ToString());
        }
    }
}
