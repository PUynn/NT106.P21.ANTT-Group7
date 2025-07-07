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
            this.flpHistory = new System.Windows.Forms.FlowLayoutPanel();
            this.flpSongs = new System.Windows.Forms.FlowLayoutPanel();
            this.lblHistory = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2Panel6 = new Guna.UI2.WinForms.Guna2Panel();
            this.pbBackground = new Guna.UI2.WinForms.Guna2PictureBox();
            this.btnRefresh3 = new Guna.UI2.WinForms.Guna2Button();
            this.lblForYou = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblArtists = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btnRefreshArtist = new Guna.UI2.WinForms.Guna2Button();
            this.btnRefreshSong = new Guna.UI2.WinForms.Guna2Button();
            this.pnHeader = new Guna.UI2.WinForms.Guna2Panel();
            this.btnAlbums = new Guna.UI2.WinForms.Guna2Button();
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
            this.pnHomeContent.Paint += new System.Windows.Forms.PaintEventHandler(this.pnHomeContent_Paint);
            // 
            // pnAll
            // 
            this.pnAll.AutoScroll = true;
            this.pnAll.Controls.Add(this.flpArtists);
            this.pnAll.Controls.Add(this.flpHistory);
            this.pnAll.Controls.Add(this.flpSongs);
            this.pnAll.Controls.Add(this.lblHistory);
            this.pnAll.Controls.Add(this.guna2Panel6);
            this.pnAll.Controls.Add(this.btnRefresh3);
            this.pnAll.Controls.Add(this.lblForYou);
            this.pnAll.Controls.Add(this.lblArtists);
            this.pnAll.Controls.Add(this.btnRefreshArtist);
            this.pnAll.Controls.Add(this.btnRefreshSong);
            this.pnAll.Location = new System.Drawing.Point(3, 68);
            this.pnAll.Name = "pnAll";
            this.pnAll.Size = new System.Drawing.Size(1479, 848);
            this.pnAll.TabIndex = 1;
            this.pnAll.Paint += new System.Windows.Forms.PaintEventHandler(this.pnAll_Paint);
            // 
            // flpArtists
            // 
            this.flpArtists.AutoScroll = true;
            this.flpArtists.Location = new System.Drawing.Point(6, 1023);
            this.flpArtists.Name = "flpArtists";
            this.flpArtists.Size = new System.Drawing.Size(1449, 290);
            this.flpArtists.TabIndex = 7;
            this.flpArtists.WrapContents = false;
            this.flpArtists.Paint += new System.Windows.Forms.PaintEventHandler(this.flpArtists_Paint);
            // 
            // flpHistory
            // 
            this.flpHistory.AutoScroll = true;
            this.flpHistory.Location = new System.Drawing.Point(6, 1455);
            this.flpHistory.Name = "flpHistory";
            this.flpHistory.Size = new System.Drawing.Size(1449, 290);
            this.flpHistory.TabIndex = 7;
            this.flpHistory.WrapContents = false;
            this.flpHistory.Paint += new System.Windows.Forms.PaintEventHandler(this.flpHistory_Paint);
            // 
            // flpSongs
            // 
            this.flpSongs.AutoScroll = true;
            this.flpSongs.Location = new System.Drawing.Point(6, 587);
            this.flpSongs.Name = "flpSongs";
            this.flpSongs.Size = new System.Drawing.Size(1449, 290);
            this.flpSongs.TabIndex = 6;
            this.flpSongs.WrapContents = false;
            this.flpSongs.Paint += new System.Windows.Forms.PaintEventHandler(this.flpSongs_Paint);
            // 
            // lblHistory
            // 
            this.lblHistory.BackColor = System.Drawing.Color.Transparent;
            this.lblHistory.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHistory.ForeColor = System.Drawing.Color.White;
            this.lblHistory.Location = new System.Drawing.Point(17, 1407);
            this.lblHistory.Name = "lblHistory";
            this.lblHistory.Size = new System.Drawing.Size(81, 32);
            this.lblHistory.TabIndex = 5;
            this.lblHistory.Text = "Albums";
            this.lblHistory.Click += new System.EventHandler(this.lblHistory_Click);
            // 
            // guna2Panel6
            // 
            this.guna2Panel6.Controls.Add(this.pbBackground);
            this.guna2Panel6.Location = new System.Drawing.Point(3, 3);
            this.guna2Panel6.Name = "guna2Panel6";
            this.guna2Panel6.Size = new System.Drawing.Size(1452, 482);
            this.guna2Panel6.TabIndex = 3;
            this.guna2Panel6.Paint += new System.Windows.Forms.PaintEventHandler(this.guna2Panel6_Paint);
            // 
            // pbBackground
            // 
            this.pbBackground.BackgroundImage = global::SONA.Properties.Resources.background;
            this.pbBackground.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbBackground.FillColor = System.Drawing.Color.Transparent;
            this.pbBackground.ImageRotate = 0F;
            this.pbBackground.Location = new System.Drawing.Point(11, 3);
            this.pbBackground.Name = "pbBackground";
            this.pbBackground.Size = new System.Drawing.Size(1429, 476);
            this.pbBackground.TabIndex = 0;
            this.pbBackground.TabStop = false;
            this.pbBackground.Click += new System.EventHandler(this.pbBackground_Click);
            // 
            // btnRefresh3
            // 
            this.btnRefresh3.Animated = true;
            this.btnRefresh3.BorderRadius = 8;
            this.btnRefresh3.CheckedState.ForeColor = System.Drawing.Color.White;
            this.btnRefresh3.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnRefresh3.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnRefresh3.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnRefresh3.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnRefresh3.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.btnRefresh3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnRefresh3.ForeColor = System.Drawing.Color.White;
            this.btnRefresh3.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnRefresh3.Image = global::SONA.Properties.Resources.Refresh;
            this.btnRefresh3.ImageOffset = new System.Drawing.Point(-3, 0);
            this.btnRefresh3.Location = new System.Drawing.Point(1347, 1400);
            this.btnRefresh3.Name = "btnRefresh3";
            this.btnRefresh3.Size = new System.Drawing.Size(108, 39);
            this.btnRefresh3.TabIndex = 5;
            this.btnRefresh3.Text = "Refresh";
            this.btnRefresh3.Click += new System.EventHandler(this.btnRefresh3_Click);
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
            this.lblForYou.Click += new System.EventHandler(this.lblForYou_Click);
            // 
            // lblArtists
            // 
            this.lblArtists.BackColor = System.Drawing.Color.Transparent;
            this.lblArtists.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblArtists.ForeColor = System.Drawing.Color.White;
            this.lblArtists.Location = new System.Drawing.Point(17, 971);
            this.lblArtists.Name = "lblArtists";
            this.lblArtists.Size = new System.Drawing.Size(209, 32);
            this.lblArtists.TabIndex = 5;
            this.lblArtists.Text = "Your favorite artists";
            this.lblArtists.Click += new System.EventHandler(this.lblArtists_Click);
            // 
            // btnRefreshArtist
            // 
            this.btnRefreshArtist.Animated = true;
            this.btnRefreshArtist.BorderRadius = 8;
            this.btnRefreshArtist.CheckedState.ForeColor = System.Drawing.Color.White;
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
            this.btnRefreshSong.BorderRadius = 8;
            this.btnRefreshSong.CheckedState.ForeColor = System.Drawing.Color.White;
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
            this.pnHeader.Controls.Add(this.btnAlbums);
            this.pnHeader.Controls.Add(this.btnArtists);
            this.pnHeader.Controls.Add(this.btnMusic);
            this.pnHeader.Controls.Add(this.btnAll);
            this.pnHeader.Location = new System.Drawing.Point(3, 3);
            this.pnHeader.Name = "pnHeader";
            this.pnHeader.Size = new System.Drawing.Size(1479, 59);
            this.pnHeader.TabIndex = 1;
            this.pnHeader.Paint += new System.Windows.Forms.PaintEventHandler(this.pnHeader_Paint);
            // 
            // btnAlbums
            // 
            this.btnAlbums.Animated = true;
            this.btnAlbums.BackColor = System.Drawing.Color.Transparent;
            this.btnAlbums.BorderRadius = 8;
            this.btnAlbums.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnAlbums.CheckedState.FillColor = System.Drawing.Color.White;
            this.btnAlbums.CheckedState.ForeColor = System.Drawing.Color.Black;
            this.btnAlbums.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAlbums.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAlbums.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAlbums.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAlbums.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.btnAlbums.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAlbums.ForeColor = System.Drawing.Color.White;
            this.btnAlbums.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnAlbums.Location = new System.Drawing.Point(284, 12);
            this.btnAlbums.Name = "btnAlbums";
            this.btnAlbums.Size = new System.Drawing.Size(107, 33);
            this.btnAlbums.TabIndex = 3;
            this.btnAlbums.Text = "Albums";
            this.btnAlbums.Click += new System.EventHandler(this.btnAlbums_Click_1);
            // 
            // btnArtists
            // 
            this.btnArtists.Animated = true;
            this.btnArtists.BackColor = System.Drawing.Color.Transparent;
            this.btnArtists.BorderRadius = 8;
            this.btnArtists.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnArtists.CheckedState.FillColor = System.Drawing.Color.White;
            this.btnArtists.CheckedState.ForeColor = System.Drawing.Color.Black;
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
            this.btnMusic.Text = "Music";
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
            this.flpMusic.Paint += new System.Windows.Forms.PaintEventHandler(this.flpMusic_Paint);
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
        private Guna.UI2.WinForms.Guna2Button btnAlbums;
        private Guna.UI2.WinForms.Guna2Button btnArtists;
        private Guna.UI2.WinForms.Guna2Button btnMusic;
        private Guna.UI2.WinForms.Guna2Button btnAll;
        private Guna.UI2.WinForms.Guna2Button btnRefresh3;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblForYou;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblArtists;
        private Guna.UI2.WinForms.Guna2Button btnRefreshArtist;
        private Guna.UI2.WinForms.Guna2Button btnRefreshSong;
        private System.Windows.Forms.FlowLayoutPanel flpHistory;
        private System.Windows.Forms.FlowLayoutPanel flpArtists;
        private Guna.UI2.WinForms.Guna2Panel pnAll;
        private System.Windows.Forms.FlowLayoutPanel flpMusic;
    }
}