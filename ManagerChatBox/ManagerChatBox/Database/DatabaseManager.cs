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
        string myConnectionString = "server=localhost;database=chatbotdb;uid=chatbot;pwd=1234;";
        MySqlConnection conn;
        string connectionString = null;

        public DatabaseManager()
        {
            connectionString = "server=localhost;Port=3307;database=chatbotdb;uid=chatbot;pwd=1234;";
            conn = new MySqlConnection(connectionString);
            try
            {
                conn.Open();
                MessageBox.Show("Connection Open ! ");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can not open connection ! ");
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
        public ArrayList[] getCustomerMessageById(String clientID)
        {
            String query1 = "SELECT * FROM chatContent WHERE msgSenderID = '" + clientID + "' ORDER BY msgTime ASC";
            //create command and assign the query and connection from the constructor
            MySqlCommand cmd1 = new MySqlCommand(query1, conn);
            ArrayList[] result = new ArrayList[2];
            MySqlDataReader rdr1 = cmd1.ExecuteReader();
            result[0] = new ArrayList();
            while (rdr1.Read())
            {
                Record record = new Record();
                record.msgID = rdr1.GetString(0);
                record.msgSenderID = rdr1.GetString(1);
                record.msgReceiverID = rdr1.GetString(2);
                record.msgTime = rdr1.GetString(3);
                record.readTime = rdr1.GetString(4);
                record.msgText = rdr1.GetString(5);
                result[0].Add(record);
            }

            String query2 = "SELECT * FROM chatContent WHERE msgReceiverID = '" + clientID + "' ORDER BY msgTime ASC";
            //create command and assign the query and connection from the constructor
            MySqlCommand cmd2 = new MySqlCommand(query1, conn);
            MySqlDataReader rdr2 = cmd2.ExecuteReader();
            result[1] = new ArrayList();
            while (rdr2.Read())
            {
                Record record = new Record();
                record.msgID = rdr2.GetString(0);
                record.msgSenderID = rdr2.GetString(1);
                record.msgReceiverID = rdr2.GetString(2);
                record.msgTime = rdr2.GetString(3);
                record.readTime = rdr2.GetString(4);
                record.msgText = rdr2.GetString(5);
                result[1].Add(record);
            }

            return result;
        }
    }
}
