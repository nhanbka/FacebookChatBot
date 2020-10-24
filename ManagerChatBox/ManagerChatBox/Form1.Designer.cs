namespace ManagerChatBox
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSend = new System.Windows.Forms.Button();
            this.lblUser = new System.Windows.Forms.Label();
            this.cbBoxUsers = new System.Windows.Forms.ComboBox();
            this.richTxtBoxConversationToSend = new System.Windows.Forms.RichTextBox();
            this.pictureBoxAvatar = new System.Windows.Forms.PictureBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAvatar)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSend
            // 
            this.btnSend.Font = new System.Drawing.Font("#9Slide07 Staccato ", 15.75F);
            this.btnSend.Location = new System.Drawing.Point(560, 319);
            this.btnSend.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(90, 56);
            this.btnSend.TabIndex = 0;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Font = new System.Drawing.Font("#9Slide07 Staccato ", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUser.Location = new System.Drawing.Point(18, 9);
            this.lblUser.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(51, 28);
            this.lblUser.TabIndex = 1;
            this.lblUser.Text = "Users";
            // 
            // cbBoxUsers
            // 
            this.cbBoxUsers.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.cbBoxUsers.Font = new System.Drawing.Font("#9Slide07 Staccato ", 15.75F);
            this.cbBoxUsers.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.cbBoxUsers.FormattingEnabled = true;
            this.cbBoxUsers.Items.AddRange(new object[] {
            "101714355046687",
            "3181701225285372"});
            this.cbBoxUsers.Location = new System.Drawing.Point(79, 6);
            this.cbBoxUsers.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.cbBoxUsers.Name = "cbBoxUsers";
            this.cbBoxUsers.Size = new System.Drawing.Size(199, 36);
            this.cbBoxUsers.TabIndex = 2;
            this.cbBoxUsers.SelectedIndexChanged += new System.EventHandler(this.cbBoxUsers_SelectedIndexChanged);
            // 
            // richTxtBoxConversationToSend
            // 
            this.richTxtBoxConversationToSend.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTxtBoxConversationToSend.Font = new System.Drawing.Font("#9Slide03 SVNFjalla One", 14.25F);
            this.richTxtBoxConversationToSend.Location = new System.Drawing.Point(13, 316);
            this.richTxtBoxConversationToSend.Name = "richTxtBoxConversationToSend";
            this.richTxtBoxConversationToSend.Size = new System.Drawing.Size(539, 59);
            this.richTxtBoxConversationToSend.TabIndex = 4;
            this.richTxtBoxConversationToSend.Text = "";
            // 
            // pictureBoxAvatar
            // 
            this.pictureBoxAvatar.Location = new System.Drawing.Point(288, 7);
            this.pictureBoxAvatar.Name = "pictureBoxAvatar";
            this.pictureBoxAvatar.Size = new System.Drawing.Size(46, 34);
            this.pictureBoxAvatar.TabIndex = 5;
            this.pictureBoxAvatar.TabStop = false;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Font = new System.Drawing.Font("#9Slide03 SVNFjalla One", 14.25F);
            this.richTextBox1.Location = new System.Drawing.Point(13, 51);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(539, 259);
            this.richTextBox1.TabIndex = 6;
            this.richTextBox1.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(653, 380);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.pictureBoxAvatar);
            this.Controls.Add(this.richTxtBoxConversationToSend);
            this.Controls.Add(this.cbBoxUsers);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.btnSend);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("#9Slide07 Staccato ", 15.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Name = "Form1";
            this.Text = "ManagerChatBox";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAvatar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.ComboBox cbBoxUsers;
        private System.Windows.Forms.RichTextBox richTxtBoxConversationToSend;
        private System.Windows.Forms.PictureBox pictureBoxAvatar;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}

