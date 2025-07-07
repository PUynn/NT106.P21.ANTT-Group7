using System.Windows.Forms;

namespace SONA
{
    partial class ListenMusic
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
            this.components = new System.ComponentModel.Container();
            this.pnBackground = new Guna.UI2.WinForms.Guna2Panel();
            this.pbPictureSong = new Guna.UI2.WinForms.Guna2PictureBox();
            this.pnAddPlaylist = new Guna.UI2.WinForms.Guna2Panel();
            this.lblNewPlaylist = new System.Windows.Forms.Label();
            this.btnAdd = new Guna.UI2.WinForms.Guna2Button();
            this.btnCloseflpPlaylist = new Guna.UI2.WinForms.Guna2Button();
            this.flpPlaylist = new System.Windows.Forms.FlowLayoutPanel();
            this.pnMusicBar = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Panel6 = new Guna.UI2.WinForms.Guna2Panel();
            this.cpbPictureSinger = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.lblSince = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblNameSinger = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2Panel5 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Button6 = new Guna.UI2.WinForms.Guna2Button();
            this.tbsVolume = new Guna.UI2.WinForms.Guna2TrackBar();
            this.tbsTimeSong = new Guna.UI2.WinForms.Guna2TrackBar();
            this.lblEnd = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblProcess = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2Panel4 = new Guna.UI2.WinForms.Guna2Panel();
            this.btnLyrics = new Guna.UI2.WinForms.Guna2Button();
            this.btnFavourite = new Guna.UI2.WinForms.Guna2Button();
            this.btnPlaylist = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Panel3 = new Guna.UI2.WinForms.Guna2Panel();
            this.btnPlayMusic = new Guna.UI2.WinForms.Guna2Button();
            this.btnPrev = new Guna.UI2.WinForms.Guna2Button();
            this.btnShuffle = new Guna.UI2.WinForms.Guna2Button();
            this.btnNext = new Guna.UI2.WinForms.Guna2Button();
            this.btnReplay = new Guna.UI2.WinForms.Guna2Button();
            this.btnMore = new Guna.UI2.WinForms.Guna2Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pnCreatePlaylist = new Guna.UI2.WinForms.Guna2Panel();
            this.cpbPicturePlaylist = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.lblChoosePicture = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbNamePlaylist = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnCancel = new Guna.UI2.WinForms.Guna2Button();
            this.btnCreate = new Guna.UI2.WinForms.Guna2Button();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.pnBackground.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPictureSong)).BeginInit();
            this.pnAddPlaylist.SuspendLayout();
            this.pnMusicBar.SuspendLayout();
            this.guna2Panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cpbPictureSinger)).BeginInit();
            this.guna2Panel5.SuspendLayout();
            this.guna2Panel4.SuspendLayout();
            this.guna2Panel3.SuspendLayout();
            this.pnCreatePlaylist.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cpbPicturePlaylist)).BeginInit();
            this.SuspendLayout();
            // 
            // pnBackground
            // 
            this.pnBackground.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.pnBackground.Controls.Add(this.pbPictureSong);
            this.pnBackground.Location = new System.Drawing.Point(0, 0);
            this.pnBackground.Name = "pnBackground";
            this.pnBackground.Size = new System.Drawing.Size(1482, 735);
            this.pnBackground.TabIndex = 0;
            // 
            // pbPictureSong
            // 
            this.pbPictureSong.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbPictureSong.FillColor = System.Drawing.Color.Transparent;
            this.pbPictureSong.ImageRotate = 0F;
            this.pbPictureSong.Location = new System.Drawing.Point(400, 30);
            this.pbPictureSong.Name = "pbPictureSong";
            this.pbPictureSong.Size = new System.Drawing.Size(680, 680);
            this.pbPictureSong.TabIndex = 0;
            this.pbPictureSong.TabStop = false;
            // 
            // pnAddPlaylist
            // 
            this.pnAddPlaylist.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(9)))), ((int)(((byte)(9)))));
            this.pnAddPlaylist.Controls.Add(this.lblNewPlaylist);
            this.pnAddPlaylist.Controls.Add(this.btnAdd);
            this.pnAddPlaylist.Controls.Add(this.btnCloseflpPlaylist);
            this.pnAddPlaylist.Controls.Add(this.flpPlaylist);
            this.pnAddPlaylist.Location = new System.Drawing.Point(1155, 514);
            this.pnAddPlaylist.Name = "pnAddPlaylist";
            this.pnAddPlaylist.Size = new System.Drawing.Size(315, 293);
            this.pnAddPlaylist.TabIndex = 2;
            this.pnAddPlaylist.Visible = false;
            // 
            // lblNewPlaylist
            // 
            this.lblNewPlaylist.AutoSize = true;
            this.lblNewPlaylist.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblNewPlaylist.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblNewPlaylist.ForeColor = System.Drawing.Color.White;
            this.lblNewPlaylist.Location = new System.Drawing.Point(43, 10);
            this.lblNewPlaylist.Name = "lblNewPlaylist";
            this.lblNewPlaylist.Size = new System.Drawing.Size(90, 20);
            this.lblNewPlaylist.TabIndex = 2;
            this.lblNewPlaylist.Text = "New playlist";
            this.lblNewPlaylist.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Animated = true;
            this.btnAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAdd.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAdd.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAdd.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAdd.FillColor = System.Drawing.Color.Transparent;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Image = global::SONA.Properties.Resources.add_circle;
            this.btnAdd.ImageSize = new System.Drawing.Size(50, 50);
            this.btnAdd.Location = new System.Drawing.Point(9, 3);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(34, 34);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnCloseflpPlaylist
            // 
            this.btnCloseflpPlaylist.BackColor = System.Drawing.Color.Transparent;
            this.btnCloseflpPlaylist.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCloseflpPlaylist.BorderRadius = 15;
            this.btnCloseflpPlaylist.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCloseflpPlaylist.FillColor = System.Drawing.Color.Transparent;
            this.btnCloseflpPlaylist.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCloseflpPlaylist.ForeColor = System.Drawing.Color.Black;
            this.btnCloseflpPlaylist.Image = global::SONA.Properties.Resources.x;
            this.btnCloseflpPlaylist.Location = new System.Drawing.Point(276, 3);
            this.btnCloseflpPlaylist.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.btnCloseflpPlaylist.Name = "btnCloseflpPlaylist";
            this.btnCloseflpPlaylist.Size = new System.Drawing.Size(34, 34);
            this.btnCloseflpPlaylist.TabIndex = 65;
            this.btnCloseflpPlaylist.Click += new System.EventHandler(this.btnCloseflpPlaylist_Click);
            // 
            // flpPlaylist
            // 
            this.flpPlaylist.AutoScroll = true;
            this.flpPlaylist.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(9)))), ((int)(((byte)(9)))));
            this.flpPlaylist.Location = new System.Drawing.Point(3, 43);
            this.flpPlaylist.Name = "flpPlaylist";
            this.flpPlaylist.Size = new System.Drawing.Size(309, 247);
            this.flpPlaylist.TabIndex = 2;
            // 
            // pnMusicBar
            // 
            this.pnMusicBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.pnMusicBar.Controls.Add(this.guna2Panel6);
            this.pnMusicBar.Controls.Add(this.guna2Panel5);
            this.pnMusicBar.Controls.Add(this.tbsTimeSong);
            this.pnMusicBar.Controls.Add(this.lblEnd);
            this.pnMusicBar.Controls.Add(this.lblProcess);
            this.pnMusicBar.Controls.Add(this.guna2Panel4);
            this.pnMusicBar.Controls.Add(this.guna2Panel3);
            this.pnMusicBar.Controls.Add(this.btnMore);
            this.pnMusicBar.Location = new System.Drawing.Point(0, 754);
            this.pnMusicBar.Name = "pnMusicBar";
            this.pnMusicBar.Size = new System.Drawing.Size(1482, 919);
            this.pnMusicBar.TabIndex = 0;
            // 
            // guna2Panel6
            // 
            this.guna2Panel6.Controls.Add(this.cpbPictureSinger);
            this.guna2Panel6.Controls.Add(this.lblSince);
            this.guna2Panel6.Controls.Add(this.lblNameSinger);
            this.guna2Panel6.Location = new System.Drawing.Point(59, 56);
            this.guna2Panel6.Name = "guna2Panel6";
            this.guna2Panel6.Size = new System.Drawing.Size(274, 80);
            this.guna2Panel6.TabIndex = 6;
            // 
            // cpbPictureSinger
            // 
            this.cpbPictureSinger.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cpbPictureSinger.FillColor = System.Drawing.Color.Transparent;
            this.cpbPictureSinger.ImageRotate = 0F;
            this.cpbPictureSinger.Location = new System.Drawing.Point(3, 0);
            this.cpbPictureSinger.Name = "cpbPictureSinger";
            this.cpbPictureSinger.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.cpbPictureSinger.Size = new System.Drawing.Size(80, 80);
            this.cpbPictureSinger.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.cpbPictureSinger.TabIndex = 7;
            this.cpbPictureSinger.TabStop = false;
            this.cpbPictureSinger.Click += new System.EventHandler(this.cpbPictureSinger_Click);
            // 
            // lblSince
            // 
            this.lblSince.BackColor = System.Drawing.Color.Transparent;
            this.lblSince.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSince.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(137)))), ((int)(((byte)(137)))));
            this.lblSince.Location = new System.Drawing.Point(98, 44);
            this.lblSince.Name = "lblSince";
            this.lblSince.Size = new System.Drawing.Size(170, 22);
            this.lblSince.TabIndex = 1;
            this.lblSince.Text = "Since 1991, December 02";
            // 
            // lblNameSinger
            // 
            this.lblNameSinger.BackColor = System.Drawing.Color.Transparent;
            this.lblNameSinger.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNameSinger.ForeColor = System.Drawing.Color.White;
            this.lblNameSinger.Location = new System.Drawing.Point(98, 17);
            this.lblNameSinger.Name = "lblNameSinger";
            this.lblNameSinger.Size = new System.Drawing.Size(108, 30);
            this.lblNameSinger.TabIndex = 1;
            this.lblNameSinger.Text = "Charlie Puth";
            // 
            // guna2Panel5
            // 
            this.guna2Panel5.Controls.Add(this.guna2Button6);
            this.guna2Panel5.Controls.Add(this.tbsVolume);
            this.guna2Panel5.Location = new System.Drawing.Point(1046, 56);
            this.guna2Panel5.Name = "guna2Panel5";
            this.guna2Panel5.Size = new System.Drawing.Size(163, 80);
            this.guna2Panel5.TabIndex = 5;
            // 
            // guna2Button6
            // 
            this.guna2Button6.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button6.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button6.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button6.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button6.FillColor = System.Drawing.Color.Transparent;
            this.guna2Button6.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button6.ForeColor = System.Drawing.Color.White;
            this.guna2Button6.Image = global::SONA.Properties.Resources.Volume;
            this.guna2Button6.ImageSize = new System.Drawing.Size(45, 45);
            this.guna2Button6.Location = new System.Drawing.Point(3, 3);
            this.guna2Button6.Name = "guna2Button6";
            this.guna2Button6.Size = new System.Drawing.Size(50, 68);
            this.guna2Button6.TabIndex = 0;
            // 
            // tbsVolume
            // 
            this.tbsVolume.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tbsVolume.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.tbsVolume.Location = new System.Drawing.Point(59, 19);
            this.tbsVolume.Name = "tbsVolume";
            this.tbsVolume.Size = new System.Drawing.Size(93, 40);
            this.tbsVolume.TabIndex = 4;
            this.tbsVolume.ThumbColor = System.Drawing.Color.Silver;
            this.tbsVolume.Scroll += new System.Windows.Forms.ScrollEventHandler(this.tbsVolume_Scroll);
            // 
            // tbsTimeSong
            // 
            this.tbsTimeSong.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tbsTimeSong.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.tbsTimeSong.Location = new System.Drawing.Point(431, 43);
            this.tbsTimeSong.Name = "tbsTimeSong";
            this.tbsTimeSong.Size = new System.Drawing.Size(542, 31);
            this.tbsTimeSong.TabIndex = 4;
            this.tbsTimeSong.ThumbColor = System.Drawing.Color.Silver;
            this.tbsTimeSong.Value = 0;
            this.tbsTimeSong.Scroll += new System.Windows.Forms.ScrollEventHandler(this.tbsTimeSong_Scroll);
            // 
            // lblEnd
            // 
            this.lblEnd.BackColor = System.Drawing.Color.Transparent;
            this.lblEnd.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEnd.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblEnd.Location = new System.Drawing.Point(943, 73);
            this.lblEnd.Name = "lblEnd";
            this.lblEnd.Size = new System.Drawing.Size(38, 22);
            this.lblEnd.TabIndex = 3;
            this.lblEnd.Text = "10:00";
            // 
            // lblProcess
            // 
            this.lblProcess.BackColor = System.Drawing.Color.Transparent;
            this.lblProcess.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProcess.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblProcess.Location = new System.Drawing.Point(431, 73);
            this.lblProcess.Name = "lblProcess";
            this.lblProcess.Size = new System.Drawing.Size(38, 22);
            this.lblProcess.TabIndex = 3;
            this.lblProcess.Text = "00:00";
            // 
            // guna2Panel4
            // 
            this.guna2Panel4.Controls.Add(this.btnLyrics);
            this.guna2Panel4.Controls.Add(this.btnFavourite);
            this.guna2Panel4.Controls.Add(this.btnPlaylist);
            this.guna2Panel4.Location = new System.Drawing.Point(1212, 56);
            this.guna2Panel4.Name = "guna2Panel4";
            this.guna2Panel4.Size = new System.Drawing.Size(203, 80);
            this.guna2Panel4.TabIndex = 0;
            // 
            // btnLyrics
            // 
            this.btnLyrics.Animated = true;
            this.btnLyrics.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLyrics.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLyrics.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnLyrics.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLyrics.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnLyrics.FillColor = System.Drawing.Color.Transparent;
            this.btnLyrics.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnLyrics.ForeColor = System.Drawing.Color.White;
            this.btnLyrics.Image = global::SONA.Properties.Resources.Lyrics;
            this.btnLyrics.ImageSize = new System.Drawing.Size(45, 45);
            this.btnLyrics.Location = new System.Drawing.Point(133, 7);
            this.btnLyrics.Name = "btnLyrics";
            this.btnLyrics.Size = new System.Drawing.Size(59, 59);
            this.btnLyrics.TabIndex = 0;
            // 
            // btnFavourite
            // 
            this.btnFavourite.Animated = true;
            this.btnFavourite.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.btnFavourite.CheckedState.Image = global::SONA.Properties.Resources.FavouriteOn;
            this.btnFavourite.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFavourite.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnFavourite.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnFavourite.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnFavourite.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnFavourite.FillColor = System.Drawing.Color.Transparent;
            this.btnFavourite.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnFavourite.ForeColor = System.Drawing.Color.White;
            this.btnFavourite.Image = global::SONA.Properties.Resources.Favourites;
            this.btnFavourite.ImageSize = new System.Drawing.Size(45, 45);
            this.btnFavourite.Location = new System.Drawing.Point(3, 7);
            this.btnFavourite.Name = "btnFavourite";
            this.btnFavourite.Size = new System.Drawing.Size(59, 59);
            this.btnFavourite.TabIndex = 0;
            this.btnFavourite.Click += new System.EventHandler(this.btnFavourite_Click);
            // 
            // btnPlaylist
            // 
            this.btnPlaylist.Animated = true;
            this.btnPlaylist.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPlaylist.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnPlaylist.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnPlaylist.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnPlaylist.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnPlaylist.FillColor = System.Drawing.Color.Transparent;
            this.btnPlaylist.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnPlaylist.ForeColor = System.Drawing.Color.White;
            this.btnPlaylist.Image = global::SONA.Properties.Resources.Add;
            this.btnPlaylist.ImageSize = new System.Drawing.Size(45, 45);
            this.btnPlaylist.Location = new System.Drawing.Point(68, 7);
            this.btnPlaylist.Name = "btnPlaylist";
            this.btnPlaylist.Size = new System.Drawing.Size(59, 59);
            this.btnPlaylist.TabIndex = 0;
            this.btnPlaylist.Click += new System.EventHandler(this.btnPlaylist_Click);
            // 
            // guna2Panel3
            // 
            this.guna2Panel3.Controls.Add(this.btnPlayMusic);
            this.guna2Panel3.Controls.Add(this.btnPrev);
            this.guna2Panel3.Controls.Add(this.btnShuffle);
            this.guna2Panel3.Controls.Add(this.btnNext);
            this.guna2Panel3.Controls.Add(this.btnReplay);
            this.guna2Panel3.Location = new System.Drawing.Point(556, 80);
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
            this.btnPlayMusic.Click += new System.EventHandler(this.btnPlayMusic_Click);
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
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
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
            this.btnShuffle.Click += new System.EventHandler(this.btnShuffle_Click);
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
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
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
            this.btnReplay.Click += new System.EventHandler(this.btnReplay_Click);
            // 
            // btnMore
            // 
            this.btnMore.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMore.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnMore.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnMore.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnMore.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnMore.FillColor = System.Drawing.Color.Transparent;
            this.btnMore.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnMore.ForeColor = System.Drawing.Color.White;
            this.btnMore.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnMore.Image = global::SONA.Properties.Resources.More;
            this.btnMore.ImageSize = new System.Drawing.Size(45, 45);
            this.btnMore.Location = new System.Drawing.Point(1420, 59);
            this.btnMore.Name = "btnMore";
            this.btnMore.Size = new System.Drawing.Size(50, 68);
            this.btnMore.TabIndex = 0;
            this.btnMore.Click += new System.EventHandler(this.btnMore_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pnCreatePlaylist
            // 
            this.pnCreatePlaylist.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(9)))), ((int)(((byte)(8)))));
            this.pnCreatePlaylist.Controls.Add(this.cpbPicturePlaylist);
            this.pnCreatePlaylist.Controls.Add(this.lblChoosePicture);
            this.pnCreatePlaylist.Controls.Add(this.label2);
            this.pnCreatePlaylist.Controls.Add(this.tbNamePlaylist);
            this.pnCreatePlaylist.Controls.Add(this.btnCancel);
            this.pnCreatePlaylist.Controls.Add(this.btnCreate);
            this.pnCreatePlaylist.Controls.Add(this.btnClose);
            this.pnCreatePlaylist.Location = new System.Drawing.Point(431, 69);
            this.pnCreatePlaylist.Name = "pnCreatePlaylist";
            this.pnCreatePlaylist.Size = new System.Drawing.Size(617, 617);
            this.pnCreatePlaylist.TabIndex = 8;
            this.pnCreatePlaylist.Visible = false;
            // 
            // cpbPicturePlaylist
            // 
            this.cpbPicturePlaylist.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cpbPicturePlaylist.Image = global::SONA.Properties.Resources.BasePlaylist1;
            this.cpbPicturePlaylist.ImageRotate = 0F;
            this.cpbPicturePlaylist.Location = new System.Drawing.Point(162, 29);
            this.cpbPicturePlaylist.Name = "cpbPicturePlaylist";
            this.cpbPicturePlaylist.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.cpbPicturePlaylist.Size = new System.Drawing.Size(300, 300);
            this.cpbPicturePlaylist.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.cpbPicturePlaylist.TabIndex = 74;
            this.cpbPicturePlaylist.TabStop = false;
            this.cpbPicturePlaylist.Click += new System.EventHandler(this.lblChoosePicture_Click);
            // 
            // lblChoosePicture
            // 
            this.lblChoosePicture.AutoSize = true;
            this.lblChoosePicture.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblChoosePicture.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Underline);
            this.lblChoosePicture.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(137)))), ((int)(((byte)(137)))));
            this.lblChoosePicture.Location = new System.Drawing.Point(158, 346);
            this.lblChoosePicture.Name = "lblChoosePicture";
            this.lblChoosePicture.Size = new System.Drawing.Size(306, 20);
            this.lblChoosePicture.TabIndex = 72;
            this.lblChoosePicture.Text = "Choose a background image for your playlist";
            this.lblChoosePicture.Click += new System.EventHandler(this.lblChoosePicture_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(54, 415);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 23);
            this.label2.TabIndex = 72;
            this.label2.Text = "Name playlist:";
            // 
            // tbNamePlaylist
            // 
            this.tbNamePlaylist.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.tbNamePlaylist.BorderRadius = 12;
            this.tbNamePlaylist.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbNamePlaylist.DefaultText = "";
            this.tbNamePlaylist.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbNamePlaylist.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbNamePlaylist.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbNamePlaylist.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbNamePlaylist.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.tbNamePlaylist.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbNamePlaylist.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tbNamePlaylist.ForeColor = System.Drawing.Color.White;
            this.tbNamePlaylist.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbNamePlaylist.Location = new System.Drawing.Point(58, 447);
            this.tbNamePlaylist.Margin = new System.Windows.Forms.Padding(4);
            this.tbNamePlaylist.Name = "tbNamePlaylist";
            this.tbNamePlaylist.PlaceholderText = "";
            this.tbNamePlaylist.SelectedText = "";
            this.tbNamePlaylist.Size = new System.Drawing.Size(504, 54);
            this.tbNamePlaylist.TabIndex = 71;
            // 
            // btnCancel
            // 
            this.btnCancel.Animated = true;
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.BorderRadius = 10;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnCancel.ImageSize = new System.Drawing.Size(28, 28);
            this.btnCancel.Location = new System.Drawing.Point(417, 534);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(145, 51);
            this.btnCancel.TabIndex = 69;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnCreate
            // 
            this.btnCreate.Animated = true;
            this.btnCreate.BackColor = System.Drawing.Color.Transparent;
            this.btnCreate.BorderRadius = 8;
            this.btnCreate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCreate.FillColor = System.Drawing.Color.White;
            this.btnCreate.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnCreate.ForeColor = System.Drawing.Color.Black;
            this.btnCreate.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnCreate.ImageSize = new System.Drawing.Size(28, 28);
            this.btnCreate.Location = new System.Drawing.Point(248, 534);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(145, 51);
            this.btnCreate.TabIndex = 68;
            this.btnCreate.Text = "Create";
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClose.BorderRadius = 15;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FillColor = System.Drawing.Color.Transparent;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.Black;
            this.btnClose.Image = global::SONA.Properties.Resources.x;
            this.btnClose.Location = new System.Drawing.Point(571, 13);
            this.btnClose.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(30, 30);
            this.btnClose.TabIndex = 65;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ListenMusic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.Controls.Add(this.pnCreatePlaylist);
            this.Controls.Add(this.pnAddPlaylist);
            this.Controls.Add(this.pnMusicBar);
            this.Controls.Add(this.pnBackground);
            this.Name = "ListenMusic";
            this.Size = new System.Drawing.Size(1482, 919);
            this.Load += new System.EventHandler(this.ListenMusic_Load);
            this.pnBackground.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbPictureSong)).EndInit();
            this.pnAddPlaylist.ResumeLayout(false);
            this.pnAddPlaylist.PerformLayout();
            this.pnMusicBar.ResumeLayout(false);
            this.pnMusicBar.PerformLayout();
            this.guna2Panel6.ResumeLayout(false);
            this.guna2Panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cpbPictureSinger)).EndInit();
            this.guna2Panel5.ResumeLayout(false);
            this.guna2Panel4.ResumeLayout(false);
            this.guna2Panel3.ResumeLayout(false);
            this.pnCreatePlaylist.ResumeLayout(false);
            this.pnCreatePlaylist.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cpbPicturePlaylist)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Panel pnMusicBar;
        private Guna.UI2.WinForms.Guna2Panel pnBackground;
        private Guna.UI2.WinForms.Guna2Button btnPlayMusic;
        private Guna.UI2.WinForms.Guna2Button btnPrev;
        private Guna.UI2.WinForms.Guna2Button btnNext;
        private Guna.UI2.WinForms.Guna2Button btnReplay;
        private Guna.UI2.WinForms.Guna2Button btnShuffle;
        private Guna.UI2.WinForms.Guna2Button guna2Button6;
        private Guna.UI2.WinForms.Guna2Button btnLyrics;
        private Guna.UI2.WinForms.Guna2Button btnPlaylist;
        private Guna.UI2.WinForms.Guna2Button btnFavourite;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel4;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel3;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblEnd;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblProcess;
        private Guna.UI2.WinForms.Guna2TrackBar tbsTimeSong;
        private Guna.UI2.WinForms.Guna2PictureBox pbPictureSong;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel5;
        private Guna.UI2.WinForms.Guna2TrackBar tbsVolume;
        private Timer timer1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel6;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblNameSinger;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblSince;
        private Guna.UI2.WinForms.Guna2CirclePictureBox cpbPictureSinger;
        private FlowLayoutPanel flpPlaylist;
        private Guna.UI2.WinForms.Guna2Panel pnAddPlaylist;
        private Guna.UI2.WinForms.Guna2Button btnAdd;
        private Label lblNewPlaylist;
        private Guna.UI2.WinForms.Guna2Button btnCloseflpPlaylist;
        public Guna.UI2.WinForms.Guna2Panel pnCreatePlaylist;
        private Guna.UI2.WinForms.Guna2CirclePictureBox cpbPicturePlaylist;
        private Label lblChoosePicture;
        private Label label2;
        private Guna.UI2.WinForms.Guna2TextBox tbNamePlaylist;
        private Guna.UI2.WinForms.Guna2Button btnCancel;
        private Guna.UI2.WinForms.Guna2Button btnCreate;
        private Guna.UI2.WinForms.Guna2Button btnClose;
        private Guna.UI2.WinForms.Guna2Button btnMore;

        public FormBorderStyle FormBorderStyle { get; private set; }
    }
}