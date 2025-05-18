namespace SONA
{
    partial class ChatForm
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
            this.pnChatForm = new Guna.UI2.WinForms.Guna2Panel();
            this.pnListChat = new Guna.UI2.WinForms.Guna2Panel();
            this.pnChatRoom = new Guna.UI2.WinForms.Guna2Panel();
            this.pnChatForm.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnChatForm
            // 
            this.pnChatForm.Controls.Add(this.pnChatRoom);
            this.pnChatForm.Controls.Add(this.pnListChat);
            this.pnChatForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnChatForm.Location = new System.Drawing.Point(0, 0);
            this.pnChatForm.Name = "pnChatForm";
            this.pnChatForm.Size = new System.Drawing.Size(1485, 919);
            this.pnChatForm.TabIndex = 0;
            // 
            // pnListChat
            // 
            this.pnListChat.AutoScroll = true;
            this.pnListChat.Location = new System.Drawing.Point(3, 3);
            this.pnListChat.Name = "pnListChat";
            this.pnListChat.Size = new System.Drawing.Size(405, 913);
            this.pnListChat.TabIndex = 0;
            // 
            // pnChatRoom
            // 
            this.pnChatRoom.Location = new System.Drawing.Point(436, 3);
            this.pnChatRoom.Name = "pnChatRoom";
            this.pnChatRoom.Size = new System.Drawing.Size(1046, 913);
            this.pnChatRoom.TabIndex = 0;
            // 
            // ChatForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.Controls.Add(this.pnChatForm);
            this.Name = "ChatForm";
            this.Size = new System.Drawing.Size(1485, 919);
            this.Load += new System.EventHandler(this.ChatForm_Load);
            this.pnChatForm.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pnChatForm;
        private Guna.UI2.WinForms.Guna2Panel pnListChat;
        private Guna.UI2.WinForms.Guna2Panel pnChatRoom;
    }
}
