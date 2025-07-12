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
            this.btnBack = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Panel7 = new Guna.UI2.WinForms.Guna2Panel();
            this.lbNameSong = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblEnd = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.tbsTimeSong = new Guna.UI2.WinForms.Guna2TrackBar();
            this.guna2Panel3 = new Guna.UI2.WinForms.Guna2Panel();
            this.btnPlayMusic = new Guna.UI2.WinForms.Guna2Button();
            this.btnPrev = new Guna.UI2.WinForms.Guna2Button();
            this.btnShuffle = new Guna.UI2.WinForms.Guna2Button();
            this.btnNext = new Guna.UI2.WinForms.Guna2Button();
            this.btnReplay = new Guna.UI2.WinForms.Guna2Button();
            this.lblProcess = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.pbPictureSong = new Guna.UI2.WinForms.Guna2PictureBox();
            this.pnListenMusic.SuspendLayout();
            this.guna2Panel7.SuspendLayout();
            this.guna2Panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPictureSong)).BeginInit();
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
            this.pnChat.Size = new System.Drawing.Size(383, 913);
            this.pnChat.TabIndex = 4;
            // 
            // pnListenMusic
            // 
            this.pnListenMusic.Controls.Add(this.pbPictureSong);
            this.pnListenMusic.Controls.Add(this.guna2Panel7);
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
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.Transparent;
            this.btnBack.BorderColor = System.Drawing.Color.Transparent;
            this.btnBack.BorderRadius = 7;
            this.btnBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBack.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnBack.Location = new System.Drawing.Point(353, 3);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(100, 40);
            this.btnBack.TabIndex = 9;
            this.btnBack.Text = "← Back";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // guna2Panel7
            // 
            this.guna2Panel7.Controls.Add(this.lbNameSong);
            this.guna2Panel7.Controls.Add(this.lblEnd);
            this.guna2Panel7.Controls.Add(this.tbsTimeSong);
            this.guna2Panel7.Controls.Add(this.guna2Panel3);
            this.guna2Panel7.Controls.Add(this.lblProcess);
            this.guna2Panel7.Location = new System.Drawing.Point(22, 659);
            this.guna2Panel7.Name = "guna2Panel7";
            this.guna2Panel7.Size = new System.Drawing.Size(620, 162);
            this.guna2Panel7.TabIndex = 10;
            // 
            // lbNameSong
            // 
            this.lbNameSong.BackColor = System.Drawing.Color.Transparent;
            this.lbNameSong.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNameSong.ForeColor = System.Drawing.Color.Gainsboro;
            this.lbNameSong.Location = new System.Drawing.Point(217, 3);
            this.lbNameSong.Name = "lbNameSong";
            this.lbNameSong.Size = new System.Drawing.Size(151, 43);
            this.lbNameSong.TabIndex = 8;
            this.lbNameSong.Text = "name song";
            // 
            // lblEnd
            // 
            this.lblEnd.BackColor = System.Drawing.Color.Transparent;
            this.lblEnd.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEnd.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblEnd.Location = new System.Drawing.Point(513, 71);
            this.lblEnd.Name = "lblEnd";
            this.lblEnd.Size = new System.Drawing.Size(38, 22);
            this.lblEnd.TabIndex = 3;
            this.lblEnd.Text = "10:00";
            // 
            // tbsTimeSong
            // 
            this.tbsTimeSong.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tbsTimeSong.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.tbsTimeSong.Location = new System.Drawing.Point(18, 40);
            this.tbsTimeSong.Name = "tbsTimeSong";
            this.tbsTimeSong.Size = new System.Drawing.Size(583, 36);
            this.tbsTimeSong.TabIndex = 4;
            this.tbsTimeSong.ThumbColor = System.Drawing.Color.Silver;
            this.tbsTimeSong.Value = 0;
            // 
            // guna2Panel3
            // 
            this.guna2Panel3.Controls.Add(this.btnPlayMusic);
            this.guna2Panel3.Controls.Add(this.btnPrev);
            this.guna2Panel3.Controls.Add(this.btnShuffle);
            this.guna2Panel3.Controls.Add(this.btnNext);
            this.guna2Panel3.Controls.Add(this.btnReplay);
            this.guna2Panel3.Location = new System.Drawing.Point(149, 71);
            this.guna2Panel3.Name = "guna2Panel3";
            this.guna2Panel3.Size = new System.Drawing.Size(298, 80);
            this.guna2Panel3.TabIndex = 1;
            // 
            // btnPlayMusic
            // 
            this.btnPlayMusic.Animated = true;
            this.btnPlayMusic.CheckedState.Image = global::SONA.Properties.Resources.PlayAni;
            this.btnPlayMusic.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPlayMusic.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnPlayMusic.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnPlayMusic.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnPlayMusic.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnPlayMusic.FillColor = System.Drawing.Color.Transparent;
            this.btnPlayMusic.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnPlayMusic.ForeColor = System.Drawing.Color.White;
            this.btnPlayMusic.Image = global::SONA.Properties.Resources.PauseAni;
            this.btnPlayMusic.ImageSize = new System.Drawing.Size(50, 50);
            this.btnPlayMusic.Location = new System.Drawing.Point(111, 3);
            this.btnPlayMusic.Name = "btnPlayMusic";
            this.btnPlayMusic.Size = new System.Drawing.Size(71, 68);
            this.btnPlayMusic.TabIndex = 0;
            // 
            // btnPrev
            // 
            this.btnPrev.Animated = true;
            this.btnPrev.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrev.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnPrev.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnPrev.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnPrev.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnPrev.FillColor = System.Drawing.Color.Transparent;
            this.btnPrev.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnPrev.ForeColor = System.Drawing.Color.White;
            this.btnPrev.Image = global::SONA.Properties.Resources.Prev;
            this.btnPrev.ImageSize = new System.Drawing.Size(50, 50);
            this.btnPrev.Location = new System.Drawing.Point(56, 3);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(50, 68);
            this.btnPrev.TabIndex = 0;
            // 
            // btnShuffle
            // 
            this.btnShuffle.Animated = true;
            this.btnShuffle.CheckedState.Image = global::SONA.Properties.Resources.ShuffleOn;
            this.btnShuffle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnShuffle.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnShuffle.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnShuffle.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnShuffle.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnShuffle.FillColor = System.Drawing.Color.Transparent;
            this.btnShuffle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnShuffle.ForeColor = System.Drawing.Color.White;
            this.btnShuffle.Image = global::SONA.Properties.Resources.Shuffle;
            this.btnShuffle.ImageSize = new System.Drawing.Size(40, 40);
            this.btnShuffle.Location = new System.Drawing.Point(1, 3);
            this.btnShuffle.Name = "btnShuffle";
            this.btnShuffle.Size = new System.Drawing.Size(50, 68);
            this.btnShuffle.TabIndex = 0;
            // 
            // btnNext
            // 
            this.btnNext.Animated = true;
            this.btnNext.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNext.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnNext.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnNext.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnNext.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnNext.FillColor = System.Drawing.Color.Transparent;
            this.btnNext.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnNext.ForeColor = System.Drawing.Color.White;
            this.btnNext.Image = global::SONA.Properties.Resources.Next;
            this.btnNext.ImageSize = new System.Drawing.Size(50, 50);
            this.btnNext.Location = new System.Drawing.Point(188, 3);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(50, 68);
            this.btnNext.TabIndex = 0;
            // 
            // btnReplay
            // 
            this.btnReplay.Animated = true;
            this.btnReplay.CheckedState.Image = global::SONA.Properties.Resources.RecoreOn;
            this.btnReplay.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReplay.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnReplay.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnReplay.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnReplay.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnReplay.FillColor = System.Drawing.Color.Transparent;
            this.btnReplay.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnReplay.ForeColor = System.Drawing.Color.White;
            this.btnReplay.Image = global::SONA.Properties.Resources.Record;
            this.btnReplay.ImageSize = new System.Drawing.Size(45, 45);
            this.btnReplay.Location = new System.Drawing.Point(245, 3);
            this.btnReplay.Name = "btnReplay";
            this.btnReplay.Size = new System.Drawing.Size(50, 68);
            this.btnReplay.TabIndex = 0;
            // 
            // lblProcess
            // 
            this.lblProcess.BackColor = System.Drawing.Color.Transparent;
            this.lblProcess.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProcess.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblProcess.Location = new System.Drawing.Point(18, 71);
            this.lblProcess.Name = "lblProcess";
            this.lblProcess.Size = new System.Drawing.Size(38, 22);
            this.lblProcess.TabIndex = 3;
            this.lblProcess.Text = "00:00";
            // 
            // pbPictureSong
            // 
            this.pbPictureSong.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbPictureSong.FillColor = System.Drawing.Color.Transparent;
            this.pbPictureSong.ImageRotate = 0F;
            this.pbPictureSong.Location = new System.Drawing.Point(40, 54);
            this.pbPictureSong.Name = "pbPictureSong";
            this.pbPictureSong.Size = new System.Drawing.Size(574, 504);
            this.pbPictureSong.TabIndex = 11;
            this.pbPictureSong.TabStop = false;
            // 
            // RoomForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.lbHostName);
            this.Controls.Add(this.lbRoomID);
            this.Controls.Add(this.pnListenMusic);
            this.Controls.Add(this.pnPlaylist);
            this.Controls.Add(this.pnChat);
            this.Name = "RoomForm";
            this.Size = new System.Drawing.Size(1485, 919);
            this.pnListenMusic.ResumeLayout(false);
            this.guna2Panel7.ResumeLayout(false);
            this.guna2Panel7.PerformLayout();
            this.guna2Panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbPictureSong)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pnPlaylist;
        private Guna.UI2.WinForms.Guna2Panel pnChat;
        private Guna.UI2.WinForms.Guna2Panel pnListenMusic;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbRoomID;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbHostName;
        private Guna.UI2.WinForms.Guna2Button btnBack;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel7;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbNameSong;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblEnd;
        private Guna.UI2.WinForms.Guna2TrackBar tbsTimeSong;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel3;
        private Guna.UI2.WinForms.Guna2Button btnPlayMusic;
        private Guna.UI2.WinForms.Guna2Button btnPrev;
        private Guna.UI2.WinForms.Guna2Button btnShuffle;
        private Guna.UI2.WinForms.Guna2Button btnNext;
        private Guna.UI2.WinForms.Guna2Button btnReplay;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblProcess;
        private Guna.UI2.WinForms.Guna2PictureBox pbPictureSong;
    }
}
