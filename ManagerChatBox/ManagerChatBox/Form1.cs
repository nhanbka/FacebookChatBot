using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ManagerChatBox.Database;

namespace ManagerChatBox
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void cbBoxUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            DatabaseManager databaseManager = new DatabaseManager();
            ArrayList arrResult = databaseManager.getCustomerMessageById(cbBoxUsers.SelectedText);
            String append = "";
            foreach (Record record in arrResult)
            {
                append += record.msgSenderID + " (" + record.msgTime + ") :\n";
                append += record.msgText + "\n";
            }
            richTextBox1.Text = append;
        }
    }
}
