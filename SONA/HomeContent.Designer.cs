namespace SONA
{
    partial class HomeContent
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
            this.pnHomeContent = new Guna.UI2.WinForms.Guna2Panel();
            this.pnAll = new Guna.UI2.WinForms.Guna2Panel();
            this.flpArtists = new System.Windows.Forms.FlowLayoutPanel();
            this.flpAlbums = new System.Windows.Forms.FlowLayoutPanel();
            this.flpSongs = new System.Windows.Forms.FlowLayoutPanel();
            this.lblHistory = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2Panel6 = new Guna.UI2.WinForms.Guna2Panel();
            this.pbBackground = new Guna.UI2.WinForms.Guna2PictureBox();
            this.btnRefreshAlbum = new Guna.UI2.WinForms.Guna2Button();
            this.lblForYou = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblArtists = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btnRefreshArtist = new Guna.UI2.WinForms.Guna2Button();
            this.btnRefreshSong = new Guna.UI2.WinForms.Guna2Button();
            this.pnHeader = new Guna.UI2.WinForms.Guna2Panel();
            this.btnArtists = new Guna.UI2.WinForms.Guna2Button();
            this.btnMusic = new Guna.UI2.WinForms.Guna2Button();
            this.btnAll = new Guna.UI2.WinForms.Guna2Button();
            this.flpMusic = new System.Windows.Forms.FlowLayoutPanel();
            this.pnHomeContent.SuspendLayout();
            this.pnAll.SuspendLayout();
            this.guna2Panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbBackground)).BeginInit();
            this.pnHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnHomeContent
            // 
            this.pnHomeContent.AutoScroll = true;
            this.pnHomeContent.Controls.Add(this.pnAll);
            this.pnHomeContent.Controls.Add(this.pnHeader);
            this.pnHomeContent.Controls.Add(this.flpMusic);
            this.pnHomeContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnHomeContent.Location = new System.Drawing.Point(0, 0);
            this.pnHomeContent.Name = "pnHomeContent";
            this.pnHomeContent.Size = new System.Drawing.Size(1485, 919);
            this.pnHomeContent.TabIndex = 2;
            // 
            // pnAll
            // 
            this.pnAll.AutoScroll = true;
            this.pnAll.Controls.Add(this.flpArtists);
            this.pnAll.Controls.Add(this.flpAlbums);
            this.pnAll.Controls.Add(this.flpSongs);
            this.pnAll.Controls.Add(this.lblHistory);
            this.pnAll.Controls.Add(this.guna2Panel6);
            this.pnAll.Controls.Add(this.btnRefreshAlbum);
            this.pnAll.Controls.Add(this.lblForYou);
            this.pnAll.Controls.Add(this.lblArtists);
            this.pnAll.Controls.Add(this.btnRefreshArtist);
            this.pnAll.Controls.Add(this.btnRefreshSong);
            this.pnAll.Location = new System.Drawing.Point(3, 68);
            this.pnAll.Name = "pnAll";
            this.pnAll.Size = new System.Drawing.Size(1479, 848);
            this.pnAll.TabIndex = 1;
            // 
            // flpArtists
            // 
            this.flpArtists.AutoScroll = true;
            this.flpArtists.Location = new System.Drawing.Point(6, 1023);
            this.flpArtists.Name = "flpArtists";
            this.flpArtists.Size = new System.Drawing.Size(1449, 290);
            this.flpArtists.TabIndex = 7;
            this.flpArtists.WrapContents = false;
            // 
            // flpAlbums
            // 
            this.flpAlbums.AutoScroll = true;
            this.flpAlbums.Location = new System.Drawing.Point(6, 1455);
            this.flpAlbums.Name = "flpAlbums";
            this.flpAlbums.Size = new System.Drawing.Size(1449, 290);
            this.flpAlbums.TabIndex = 7;
            this.flpAlbums.WrapContents = false;
            // 
            // flpSongs
            // 
            this.flpSongs.AutoScroll = true;
            this.flpSongs.Location = new System.Drawing.Point(6, 587);
            this.flpSongs.Name = "flpSongs";
            this.flpSongs.Size = new System.Drawing.Size(1449, 290);
            this.flpSongs.TabIndex = 6;
            this.flpSongs.WrapContents = false;
            // 
            // lblHistory
            // 
            this.lblHistory.BackColor = System.Drawing.Color.Transparent;
            this.lblHistory.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHistory.ForeColor = System.Drawing.Color.White;
            this.lblHistory.Location = new System.Drawing.Point(17, 1407);
            this.lblHistory.Name = "lblHistory";
            this.lblHistory.Size = new System.Drawing.Size(224, 32);
            this.lblHistory.TabIndex = 5;
            this.lblHistory.Text = "Most popular albums\r\n";
            // 
            // guna2Panel6
            // 
            this.guna2Panel6.Controls.Add(this.pbBackground);
            this.guna2Panel6.Location = new System.Drawing.Point(3, 3);
            this.guna2Panel6.Name = "guna2Panel6";
            this.guna2Panel6.Size = new System.Drawing.Size(1452, 482);
            this.guna2Panel6.TabIndex = 3;
            // 
            // pbBackground
            // 
            this.pbBackground.BackgroundImage = global::SONA.Properties.Resources.BackgroundMusic;
            this.pbBackground.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbBackground.FillColor = System.Drawing.Color.Transparent;
            this.pbBackground.ImageRotate = 0F;
            this.pbBackground.Location = new System.Drawing.Point(-3, 3);
            this.pbBackground.Name = "pbBackground";
            this.pbBackground.Size = new System.Drawing.Size(1452, 476);
            this.pbBackground.TabIndex = 0;
            this.pbBackground.TabStop = false;
            // 
            // btnRefreshAlbum
            // 
            this.btnRefreshAlbum.Animated = true;
            this.btnRefreshAlbum.BorderRadius = 20;
            this.btnRefreshAlbum.CheckedState.ForeColor = System.Drawing.Color.White;
            this.btnRefreshAlbum.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefreshAlbum.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnRefreshAlbum.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnRefreshAlbum.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnRefreshAlbum.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnRefreshAlbum.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.btnRefreshAlbum.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnRefreshAlbum.ForeColor = System.Drawing.Color.White;
            this.btnRefreshAlbum.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnRefreshAlbum.Image = global::SONA.Properties.Resources.Refresh;
            this.btnRefreshAlbum.ImageOffset = new System.Drawing.Point(-3, 0);
            this.btnRefreshAlbum.Location = new System.Drawing.Point(1347, 1400);
            this.btnRefreshAlbum.Name = "btnRefreshAlbum";
            this.btnRefreshAlbum.Size = new System.Drawing.Size(108, 39);
            this.btnRefreshAlbum.TabIndex = 5;
            this.btnRefreshAlbum.Text = "Refresh";
            this.btnRefreshAlbum.Click += new System.EventHandler(this.btnRefreshAlbum_Click);
            // 
            // lblForYou
            // 
            this.lblForYou.BackColor = System.Drawing.Color.Transparent;
            this.lblForYou.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblForYou.ForeColor = System.Drawing.Color.White;
            this.lblForYou.Location = new System.Drawing.Point(17, 538);
            this.lblForYou.Name = "lblForYou";
            this.lblForYou.Size = new System.Drawing.Size(146, 32);
            this.lblForYou.TabIndex = 5;
            this.lblForYou.Text = "Made For You";
            // 
            // lblArtists
            // 
            this.lblArtists.BackColor = System.Drawing.Color.Transparent;
            this.lblArtists.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblArtists.ForeColor = System.Drawing.Color.White;
            this.lblArtists.Location = new System.Drawing.Point(17, 971);
            this.lblArtists.Name = "lblArtists";
            this.lblArtists.Size = new System.Drawing.Size(222, 32);
            this.lblArtists.TabIndex = 5;
            this.lblArtists.Text = "Your favourite artists";
            // 
            // btnRefreshArtist
            // 
            this.btnRefreshArtist.Animated = true;
            this.btnRefreshArtist.BorderRadius = 20;
            this.btnRefreshArtist.CheckedState.ForeColor = System.Drawing.Color.White;
            this.btnRefreshArtist.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefreshArtist.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnRefreshArtist.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnRefreshArtist.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnRefreshArtist.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnRefreshArtist.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.btnRefreshArtist.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnRefreshArtist.ForeColor = System.Drawing.Color.White;
            this.btnRefreshArtist.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnRefreshArtist.Image = global::SONA.Properties.Resources.Refresh;
            this.btnRefreshArtist.ImageOffset = new System.Drawing.Point(-3, 0);
            this.btnRefreshArtist.Location = new System.Drawing.Point(1347, 964);
            this.btnRefreshArtist.Name = "btnRefreshArtist";
            this.btnRefreshArtist.Size = new System.Drawing.Size(108, 39);
            this.btnRefreshArtist.TabIndex = 5;
            this.btnRefreshArtist.Text = "Refresh";
            this.btnRefreshArtist.Click += new System.EventHandler(this.btnRefreshArtist_Click);
            // 
            // btnRefreshSong
            // 
            this.btnRefreshSong.Animated = true;
            this.btnRefreshSong.BorderRadius = 20;
            this.btnRefreshSong.CheckedState.ForeColor = System.Drawing.Color.White;
            this.btnRefreshSong.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefreshSong.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnRefreshSong.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnRefreshSong.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnRefreshSong.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnRefreshSong.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.btnRefreshSong.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnRefreshSong.ForeColor = System.Drawing.Color.White;
            this.btnRefreshSong.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnRefreshSong.Image = global::SONA.Properties.Resources.Refresh;
            this.btnRefreshSong.ImageOffset = new System.Drawing.Point(-3, 0);
            this.btnRefreshSong.Location = new System.Drawing.Point(1347, 531);
            this.btnRefreshSong.Name = "btnRefreshSong";
            this.btnRefreshSong.Size = new System.Drawing.Size(108, 39);
            this.btnRefreshSong.TabIndex = 5;
            this.btnRefreshSong.Text = "Refresh";
            this.btnRefreshSong.Click += new System.EventHandler(this.btnRefreshSong_Click);
            // 
            // pnHeader
            // 
            this.pnHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.pnHeader.Controls.Add(this.btnArtists);
            this.pnHeader.Controls.Add(this.btnMusic);
            this.pnHeader.Controls.Add(this.btnAll);
            this.pnHeader.Location = new System.Drawing.Point(3, 3);
            this.pnHeader.Name = "pnHeader";
            this.pnHeader.Size = new System.Drawing.Size(1479, 59);
            this.pnHeader.TabIndex = 1;
            // 
            // btnArtists
            // 
            this.btnArtists.Animated = true;
            this.btnArtists.BackColor = System.Drawing.Color.Transparent;
            this.btnArtists.BorderRadius = 8;
            this.btnArtists.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnArtists.CheckedState.FillColor = System.Drawing.Color.White;
            this.btnArtists.CheckedState.ForeColor = System.Drawing.Color.Black;
            this.btnArtists.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnArtists.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnArtists.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnArtists.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnArtists.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnArtists.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.btnArtists.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnArtists.ForeColor = System.Drawing.Color.White;
            this.btnArtists.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnArtists.Location = new System.Drawing.Point(171, 12);
            this.btnArtists.Name = "btnArtists";
            this.btnArtists.Size = new System.Drawing.Size(107, 33);
            this.btnArtists.TabIndex = 3;
            this.btnArtists.Text = "Artists";
            this.btnArtists.Click += new System.EventHandler(this.btnArtists_Click);
            // 
            // btnMusic
            // 
            this.btnMusic.Animated = true;
            this.btnMusic.BackColor = System.Drawing.Color.Transparent;
            this.btnMusic.BorderRadius = 8;
            this.btnMusic.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnMusic.CheckedState.FillColor = System.Drawing.Color.White;
            this.btnMusic.CheckedState.ForeColor = System.Drawing.Color.Black;
            this.btnMusic.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMusic.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnMusic.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnMusic.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnMusic.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnMusic.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.btnMusic.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMusic.ForeColor = System.Drawing.Color.White;
            this.btnMusic.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnMusic.Location = new System.Drawing.Point(75, 12);
            this.btnMusic.Name = "btnMusic";
            this.btnMusic.Size = new System.Drawing.Size(90, 33);
            this.btnMusic.TabIndex = 3;
            this.btnMusic.Text = "Songs";
            this.btnMusic.Click += new System.EventHandler(this.btnMusic_Click);
            // 
            // btnAll
            // 
            this.btnAll.Animated = true;
            this.btnAll.BackColor = System.Drawing.Color.Transparent;
            this.btnAll.BorderRadius = 8;
            this.btnAll.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnAll.Checked = true;
            this.btnAll.CheckedState.FillColor = System.Drawing.Color.White;
            this.btnAll.CheckedState.ForeColor = System.Drawing.Color.Black;
            this.btnAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAll.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAll.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAll.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAll.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAll.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.btnAll.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAll.ForeColor = System.Drawing.Color.White;
            this.btnAll.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnAll.Location = new System.Drawing.Point(14, 12);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(55, 33);
            this.btnAll.TabIndex = 3;
            this.btnAll.Text = "All";
            this.btnAll.Click += new System.EventHandler(this.btnAll_Click);
            // 
            // flpMusic
            // 
            this.flpMusic.AutoScroll = true;
            this.flpMusic.Location = new System.Drawing.Point(3, 68);
            this.flpMusic.Name = "flpMusic";
            this.flpMusic.Size = new System.Drawing.Size(1479, 848);
            this.flpMusic.TabIndex = 0;
            this.flpMusic.Visible = false;
            // 
            // HomeContent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.Controls.Add(this.pnHomeContent);
            this.Name = "HomeContent";
            this.Size = new System.Drawing.Size(1485, 919);
            this.Load += new System.EventHandler(this.HomeContent_Load);
            this.pnHomeContent.ResumeLayout(false);
            this.pnAll.ResumeLayout(false);
            this.pnAll.PerformLayout();
            this.guna2Panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbBackground)).EndInit();
            this.pnHeader.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pnHomeContent;
        private System.Windows.Forms.FlowLayoutPanel flpSongs;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblHistory;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel6;
        private Guna.UI2.WinForms.Guna2PictureBox pbBackground;
        private Guna.UI2.WinForms.Guna2Panel pnHeader;
        private Guna.UI2.WinForms.Guna2Button btnArtists;
        private Guna.UI2.WinForms.Guna2Button btnMusic;
        private Guna.UI2.WinForms.Guna2Button btnAll;
        private Guna.UI2.WinForms.Guna2Button btnRefreshAlbum;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblForYou;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblArtists;
        private Guna.UI2.WinForms.Guna2Button btnRefreshArtist;
        private Guna.UI2.WinForms.Guna2Button btnRefreshSong;
        private System.Windows.Forms.FlowLayoutPanel flpAlbums;
        private System.Windows.Forms.FlowLayoutPanel flpArtists;
        private Guna.UI2.WinForms.Guna2Panel pnAll;
        private System.Windows.Forms.FlowLayoutPanel flpMusic;
    }
}