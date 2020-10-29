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
            this.cbBoxUsers = new System.Windows.Forms.ComboBox();
            this.radChatBox = new Telerik.WinControls.UI.RadChat();
            this.splitter = new System.Windows.Forms.Splitter();
            ((System.ComponentModel.ISupportInitialize)(this.radChatBox)).BeginInit();
            this.SuspendLayout();
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUser.Location = new System.Drawing.Point(208, 4);
            this.lblUser.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(58, 25);
            this.lblUser.TabIndex = 1;
            this.lblUser.Text = "Users";
            // 
            // cbBoxUsers
            // 
            this.cbBoxUsers.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.cbBoxUsers.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbBoxUsers.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.cbBoxUsers.FormattingEnabled = true;
            this.cbBoxUsers.Items.AddRange(new object[] {
            "3181701225285372"});
            this.cbBoxUsers.Location = new System.Drawing.Point(278, 4);
            this.cbBoxUsers.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.cbBoxUsers.Name = "cbBoxUsers";
            this.cbBoxUsers.Size = new System.Drawing.Size(219, 29);
            this.cbBoxUsers.TabIndex = 2;
            this.cbBoxUsers.SelectedIndexChanged += new System.EventHandler(this.cbBoxUsers_SelectedIndexChanged);
            // 
            // radChatBox
            // 
            this.radChatBox.AvatarSize = new System.Drawing.SizeF(30.8F, 25F);
            this.radChatBox.Location = new System.Drawing.Point(192, 40);
            this.radChatBox.Name = "radChatBox";
            this.radChatBox.Size = new System.Drawing.Size(628, 342);
            this.radChatBox.TabIndex = 3;
            this.radChatBox.Text = "radChat1";
            this.radChatBox.TimeSeparatorInterval = System.TimeSpan.Parse("1.00:00:00");
            // 
            // splitter
            // 
            this.splitter.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.splitter.Location = new System.Drawing.Point(0, 0);
            this.splitter.Name = "splitter";
            this.splitter.Size = new System.Drawing.Size(186, 384);
            this.splitter.TabIndex = 4;
            this.splitter.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 384);
            this.Controls.Add(this.splitter);
            this.Controls.Add(this.radChatBox);
            this.Controls.Add(this.cbBoxUsers);
            this.Controls.Add(this.lblUser);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "Form1";
            this.Text = "ManagerChatBox";
            ((System.ComponentModel.ISupportInitialize)(this.radChatBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.ComboBox cbBoxUsers;
        private Telerik.WinControls.UI.RadChat radChatBox;
        private System.Windows.Forms.Splitter splitter;
    }
}

