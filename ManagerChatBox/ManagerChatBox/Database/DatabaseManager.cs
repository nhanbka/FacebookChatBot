using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using ManagerChatBox.Model;

namespace ManagerChatBox.Database
{
    class DatabaseManager
    {
        /// <summary>
        /// Configuration
        /// </summary>
        string server = "localhost";
        string database = "chatbotdb";
        string uid = "chatbot";
        string pwd = "1234";
        string port = "3306";

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
            String query = "SELECT * FROM chatContent WHERE msgSenderID = '" + clientID + "' OR msgReceiverID='" + clientID + "' ORDER BY msgTime ASC";
            ArrayList result = new ArrayList();
            if (conn.State == ConnectionState.Closed)
            {
                return result;
            }
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                Model.Message mess = new Model.Message();
                mess.msgID = dataReader.GetString(0);
                mess.msgSenderID = dataReader.GetString(1);
                mess.msgReceiverID = dataReader.GetString(2);
                mess.msgTime = dataReader.GetString(3);
                mess.readTime = dataReader.GetString(4);
                mess.msgText = dataReader.GetString(5);
                result.Add(mess);
            }
            dataReader.Close();

            return result;
        }
    }
}
