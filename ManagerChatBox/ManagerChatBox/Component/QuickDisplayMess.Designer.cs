using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ManagerChatBox.Component
{
    partial class QuickDisplayMess
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.avatarImage = new System.Windows.Forms.PictureBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblTimeStamp = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.avatarImage)).BeginInit();
            this.SuspendLayout();
            // 
            // avatarImage
            // 
            this.avatarImage.Location = new System.Drawing.Point(2, 3);
            this.avatarImage.Name = "avatarImage";
            this.avatarImage.Size = new System.Drawing.Size(45, 38);
            this.avatarImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.avatarImage.TabIndex = 0;
            this.avatarImage.TabStop = false;
            // 
            // lblUsername
            // 
            this.lblUsername.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.Location = new System.Drawing.Point(52, 2);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(53, 15);
            this.lblUsername.TabIndex = 1;
            this.lblUsername.Text = "Name";
            // 
            // lblTimeStamp
            // 
            this.lblTimeStamp.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblTimeStamp.AutoSize = true;
            this.lblTimeStamp.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimeStamp.Location = new System.Drawing.Point(53, 26);
            this.lblTimeStamp.Name = "lblTimeStamp";
            this.lblTimeStamp.Size = new System.Drawing.Size(137, 12);
            this.lblTimeStamp.TabIndex = 3;
            this.lblTimeStamp.Text = "Last mess: 23:59:59 20/10/1965";
            // 
            // QuickDisplayMess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(201)))), ((int)(((byte)(158)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lblTimeStamp);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.avatarImage);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "QuickDisplayMess";
            this.Size = new System.Drawing.Size(220, 44);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.QuickDisplayMess_MouseClick);
            ((System.ComponentModel.ISupportInitialize)(this.avatarImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox avatarImage;
        private Label lblUsername;
        private Label lblTimeStamp;
    }
}
