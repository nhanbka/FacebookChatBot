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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.lblUser = new System.Windows.Forms.Label();
            this.radChatBox = new Telerik.WinControls.UI.RadChat();
            this.flowLayoutUserManager = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.mainPanelBottom = new System.Windows.Forms.Panel();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.btnFinishChat = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.radChatBox)).BeginInit();
            this.flowLayoutUserManager.SuspendLayout();
            this.panel1.SuspendLayout();
            this.mainPanel.SuspendLayout();
            this.mainPanelBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Enabled = false;
            this.lblUser.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUser.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblUser.Location = new System.Drawing.Point(49, 7);
            this.lblUser.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(58, 25);
            this.lblUser.TabIndex = 1;
            this.lblUser.Text = "Users";
            // 
            // radChatBox
            // 
            this.radChatBox.AvatarSize = new System.Drawing.SizeF(19.6F, 15F);
            this.radChatBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radChatBox.Location = new System.Drawing.Point(0, 0);
            this.radChatBox.Margin = new System.Windows.Forms.Padding(2);
            this.radChatBox.Name = "radChatBox";
            this.radChatBox.Size = new System.Drawing.Size(750, 466);
            this.radChatBox.TabIndex = 3;
            this.radChatBox.Text = "radChat1";
            this.radChatBox.TimeSeparatorInterval = System.TimeSpan.Parse("1.00:00:00");
            this.radChatBox.Scroll += new System.Windows.Forms.ScrollEventHandler(this.radChatBox_Scroll);
            // 
            // flowLayoutUserManager
            // 
            this.flowLayoutUserManager.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(132)))), ((int)(((byte)(139)))));
            this.flowLayoutUserManager.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutUserManager.Controls.Add(this.panel1);
            this.flowLayoutUserManager.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowLayoutUserManager.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutUserManager.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutUserManager.Name = "flowLayoutUserManager";
            this.flowLayoutUserManager.Size = new System.Drawing.Size(220, 466);
            this.flowLayoutUserManager.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(220, 40);
            this.panel1.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.BackColor = System.Drawing.SystemColors.Control;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Enabled = false;
            this.textBox1.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.textBox1.Location = new System.Drawing.Point(73, 7);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(78, 25);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "Message";
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.mainPanelBottom);
            this.mainPanel.Controls.Add(this.radChatBox);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(220, 0);
            this.mainPanel.Margin = new System.Windows.Forms.Padding(2);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(750, 466);
            this.mainPanel.TabIndex = 5;
            // 
            // mainPanelBottom
            // 
            this.mainPanelBottom.BackColor = System.Drawing.SystemColors.Control;
            this.mainPanelBottom.Controls.Add(this.btnFinishChat);
            this.mainPanelBottom.Controls.Add(this.pictureBox);
            this.mainPanelBottom.Controls.Add(this.lblUser);
            this.mainPanelBottom.Dock = System.Windows.Forms.DockStyle.Top;
            this.mainPanelBottom.Location = new System.Drawing.Point(0, 0);
            this.mainPanelBottom.Margin = new System.Windows.Forms.Padding(2);
            this.mainPanelBottom.Name = "mainPanelBottom";
            this.mainPanelBottom.Size = new System.Drawing.Size(750, 41);
            this.mainPanelBottom.TabIndex = 4;
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(0, 0);
            this.pictureBox.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(47, 41);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox.TabIndex = 3;
            this.pictureBox.TabStop = false;
            // 
            // btnFinishChat
            // 
            this.btnFinishChat.BackColor = System.Drawing.SystemColors.MenuBar;
            this.btnFinishChat.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnFinishChat.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnFinishChat.Location = new System.Drawing.Point(648, 0);
            this.btnFinishChat.Name = "btnFinishChat";
            this.btnFinishChat.Size = new System.Drawing.Size(102, 41);
            this.btnFinishChat.TabIndex = 4;
            this.btnFinishChat.Text = "Finish Chat";
            this.btnFinishChat.UseVisualStyleBackColor = false;
            this.btnFinishChat.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(970, 466);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.flowLayoutUserManager);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "Form1";
            this.Text = "ManagerChatBox";
            ((System.ComponentModel.ISupportInitialize)(this.radChatBox)).EndInit();
            this.flowLayoutUserManager.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.mainPanel.ResumeLayout(false);
            this.mainPanelBottom.ResumeLayout(false);
            this.mainPanelBottom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblUser;
        private Telerik.WinControls.UI.RadChat radChatBox;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutUserManager;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Panel mainPanelBottom;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnFinishChat;
    }
}

