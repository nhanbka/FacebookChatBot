using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ManagerChatBox.Database
{
    class Record
    {
        public String msgID;
        public String msgSenderID;
        public String msgReceiverID;
        public String msgTime;
        public String readTime;
        public String msgText;
    }
    class DatabaseManager
    {
        /// <summary>
        /// Configuration
        /// </summary>
        string server = "localhost";
        string database = "chatbotdb";
        string uid = "chatbot";
        string pwd = "1234";
        string port = "3307";


        MySqlConnection conn;
        string connectionString = null;

        public DatabaseManager()
        {
            string myConnectionString = "server=" + server + ";database=" + database + ";uid=" + uid + ";pwd=" + pwd + ";";
            connectionString = "server=" + server + ";Port=" + port + ";database=" + database + ";uid=" + uid + ";pwd=" + pwd + ";";
            conn = new MySqlConnection(connectionString);
            try
            {
                conn.Open();
                //MessageBox.Show("Connection Open ! ");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can not open connection !");
            }
        }

        ~DatabaseManager()
        {
            conn.Close();
        }

        /// <summary>
        /// Get message conversation between page's owner and client
        /// to handle
        /// result[0]: chat from client
        /// result[1]: chat from bot or page's owner
        /// </summary>
        /// <param name="clientID"></param>
        /// <returns></returns>
        public ArrayList getCustomerMessageById(String clientID)
        {
            String query = "SELECT * FROM chatContent WHERE msgSenderID = '" + clientID + "' OR msgReceiverID='" + clientID + "' ORDER BY msgTime DESC";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            ArrayList result = new ArrayList();
            MySqlDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                Record record = new Record();
                record.msgID = dataReader.GetString(0);
                record.msgSenderID = dataReader.GetString(1);
                record.msgReceiverID = dataReader.GetString(2);
                record.msgTime = dataReader.GetString(3);
                record.readTime = dataReader.GetString(4);
                record.msgText = dataReader.GetString(5);
                result.Add(record);
            }
            dataReader.Close();

            return result;
        }
    }
}
