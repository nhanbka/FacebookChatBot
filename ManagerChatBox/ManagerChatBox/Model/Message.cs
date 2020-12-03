using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerChatBox.Model
{
    public class Message
    {
        public String msgID { get; set; }
        public String msgSenderID { get; set; }
        public String msgReceiverID { get; set; }
        public String msgTime { get; set; }
        public String readTime { get; set; }
        public String msgText { get; set; }
    }
}
