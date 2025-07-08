namespace SONA
{
    partial class RoomForm
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
            this.pnPlaylist = new Guna.UI2.WinForms.Guna2Panel();
            this.pnChat = new Guna.UI2.WinForms.Guna2Panel();
            this.pnListenMusic = new Guna.UI2.WinForms.Guna2Panel();
            this.lbRoomID = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lbHostName = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.SuspendLayout();
            // 
            // pnPlaylist
            // 
            this.pnPlaylist.AutoScroll = true;
            this.pnPlaylist.Location = new System.Drawing.Point(3, 0);
            this.pnPlaylist.Name = "pnPlaylist";
            this.pnPlaylist.Size = new System.Drawing.Size(351, 919);
            this.pnPlaylist.TabIndex = 1;
            // 
            // pnChat
            // 
            this.pnChat.Location = new System.Drawing.Point(1016, 3);
            this.pnChat.Name = "pnChat";
            this.pnChat.Size = new System.Drawing.Size(469, 887);
            this.pnChat.TabIndex = 4;
            // 
            // pnListenMusic
            // 
            this.pnListenMusic.Location = new System.Drawing.Point(353, 92);
            this.pnListenMusic.Name = "pnListenMusic";
            this.pnListenMusic.Size = new System.Drawing.Size(663, 824);
            this.pnListenMusic.TabIndex = 5;
            // 
            // lbRoomID
            // 
            this.lbRoomID.AutoSize = false;
            this.lbRoomID.BackColor = System.Drawing.Color.Transparent;
            this.lbRoomID.Font = new System.Drawing.Font("Segoe UI", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRoomID.ForeColor = System.Drawing.Color.White;
            this.lbRoomID.Location = new System.Drawing.Point(514, 3);
            this.lbRoomID.Name = "lbRoomID";
            this.lbRoomID.Size = new System.Drawing.Size(254, 72);
            this.lbRoomID.TabIndex = 7;
            this.lbRoomID.Text = " Room ID ";
            // 
            // lbHostName
            // 
            this.lbHostName.AutoSize = false;
            this.lbHostName.BackColor = System.Drawing.Color.Transparent;
            this.lbHostName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHostName.ForeColor = System.Drawing.Color.White;
            this.lbHostName.Location = new System.Drawing.Point(514, 57);
            this.lbHostName.Name = "lbHostName";
            this.lbHostName.Size = new System.Drawing.Size(203, 29);
            this.lbHostName.TabIndex = 8;
            this.lbHostName.Text = "Host ";
            // 
            // RoomForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.Controls.Add(this.lbHostName);
            this.Controls.Add(this.lbRoomID);
            this.Controls.Add(this.pnListenMusic);
            this.Controls.Add(this.pnPlaylist);
            this.Controls.Add(this.pnChat);
            this.Name = "RoomForm";
            this.Size = new System.Drawing.Size(1485, 919);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pnPlaylist;
        private Guna.UI2.WinForms.Guna2Panel pnChat;
        private Guna.UI2.WinForms.Guna2Panel pnListenMusic;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbRoomID;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbHostName;
    }
}
