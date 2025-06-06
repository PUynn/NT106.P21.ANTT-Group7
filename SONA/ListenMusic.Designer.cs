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
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.pbPictureSong = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Panel6 = new Guna.UI2.WinForms.Guna2Panel();
            this.lblSince = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblNameSinger = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btnPictureSinger = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Panel5 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Button6 = new Guna.UI2.WinForms.Guna2Button();
            this.tbsVolume = new Guna.UI2.WinForms.Guna2TrackBar();
            this.tbsTimeSong = new Guna.UI2.WinForms.Guna2TrackBar();
            this.lblEnd = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblProcess = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2Panel4 = new Guna.UI2.WinForms.Guna2Panel();
            this.btnLyrics = new Guna.UI2.WinForms.Guna2Button();
            this.btnFavourite = new Guna.UI2.WinForms.Guna2Button();
            this.btnAlbums = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Panel3 = new Guna.UI2.WinForms.Guna2Panel();
            this.btnPlayMusic = new Guna.UI2.WinForms.Guna2Button();
            this.btnPrev = new Guna.UI2.WinForms.Guna2Button();
            this.btShuffle = new Guna.UI2.WinForms.Guna2Button();
            this.btnNext = new Guna.UI2.WinForms.Guna2Button();
            this.btReplay = new Guna.UI2.WinForms.Guna2Button();
            this.btnMore = new Guna.UI2.WinForms.Guna2Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPictureSong)).BeginInit();
            this.guna2Panel2.SuspendLayout();
            this.guna2Panel6.SuspendLayout();
            this.guna2Panel5.SuspendLayout();
            this.guna2Panel4.SuspendLayout();
            this.guna2Panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Controls.Add(this.pbPictureSong);
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(1490, 735);
            this.guna2Panel1.TabIndex = 0;
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
            // guna2Panel2
            // 
            this.guna2Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.guna2Panel2.Controls.Add(this.guna2Panel6);
            this.guna2Panel2.Controls.Add(this.guna2Panel5);
            this.guna2Panel2.Controls.Add(this.tbsTimeSong);
            this.guna2Panel2.Controls.Add(this.lblEnd);
            this.guna2Panel2.Controls.Add(this.lblProcess);
            this.guna2Panel2.Controls.Add(this.guna2Panel4);
            this.guna2Panel2.Controls.Add(this.guna2Panel3);
            this.guna2Panel2.Controls.Add(this.btnMore);
            this.guna2Panel2.Location = new System.Drawing.Point(0, 754);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.Size = new System.Drawing.Size(1482, 919);
            this.guna2Panel2.TabIndex = 0;
            // 
            // guna2Panel6
            // 
            this.guna2Panel6.Controls.Add(this.lblSince);
            this.guna2Panel6.Controls.Add(this.lblNameSinger);
            this.guna2Panel6.Controls.Add(this.btnPictureSinger);
            this.guna2Panel6.Location = new System.Drawing.Point(59, 56);
            this.guna2Panel6.Name = "guna2Panel6";
            this.guna2Panel6.Size = new System.Drawing.Size(274, 80);
            this.guna2Panel6.TabIndex = 6;
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
            this.lblNameSinger.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblNameSinger.Location = new System.Drawing.Point(98, 17);
            this.lblNameSinger.Name = "lblNameSinger";
            this.lblNameSinger.Size = new System.Drawing.Size(108, 30);
            this.lblNameSinger.TabIndex = 1;
            this.lblNameSinger.Text = "Charlie Puth";
            // 
            // btnPictureSinger
            // 
            this.btnPictureSinger.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPictureSinger.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPictureSinger.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnPictureSinger.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnPictureSinger.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnPictureSinger.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnPictureSinger.FillColor = System.Drawing.Color.Transparent;
            this.btnPictureSinger.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnPictureSinger.ForeColor = System.Drawing.Color.White;
            this.btnPictureSinger.Location = new System.Drawing.Point(0, 0);
            this.btnPictureSinger.Name = "btnPictureSinger";
            this.btnPictureSinger.Size = new System.Drawing.Size(80, 80);
            this.btnPictureSinger.TabIndex = 0;
            this.btnPictureSinger.Click += new System.EventHandler(this.btnSinger_Click);
            // 
            // guna2Panel5
            // 
            this.guna2Panel5.Controls.Add(this.guna2Button6);
            this.guna2Panel5.Controls.Add(this.tbsVolume);
            this.guna2Panel5.Location = new System.Drawing.Point(1050, 56);
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
            this.tbsTimeSong.Scroll += new System.Windows.Forms.ScrollEventHandler(this.tbsTimeSong_Scroll);
            // 
            // lblEnd
            // 
            this.lblEnd.BackColor = System.Drawing.Color.Transparent;
            this.lblEnd.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEnd.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblEnd.Location = new System.Drawing.Point(943, 73);
            this.lblEnd.Name = "lblEnd";
            this.lblEnd.Size = new System.Drawing.Size(30, 22);
            this.lblEnd.TabIndex = 3;
            this.lblEnd.Text = "4:45";
            // 
            // lblProcess
            // 
            this.lblProcess.BackColor = System.Drawing.Color.Transparent;
            this.lblProcess.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProcess.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblProcess.Location = new System.Drawing.Point(431, 73);
            this.lblProcess.Name = "lblProcess";
            this.lblProcess.Size = new System.Drawing.Size(30, 22);
            this.lblProcess.TabIndex = 3;
            this.lblProcess.Text = "2:23";
            // 
            // guna2Panel4
            // 
            this.guna2Panel4.Controls.Add(this.btnLyrics);
            this.guna2Panel4.Controls.Add(this.btnFavourite);
            this.guna2Panel4.Controls.Add(this.btnAlbums);
            this.guna2Panel4.Location = new System.Drawing.Point(1216, 56);
            this.guna2Panel4.Name = "guna2Panel4";
            this.guna2Panel4.Size = new System.Drawing.Size(185, 80);
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
            this.btnLyrics.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnLyrics.Image = global::SONA.Properties.Resources.Lyrics;
            this.btnLyrics.ImageSize = new System.Drawing.Size(45, 45);
            this.btnLyrics.Location = new System.Drawing.Point(115, 2);
            this.btnLyrics.Name = "btnLyrics";
            this.btnLyrics.Size = new System.Drawing.Size(50, 68);
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
            this.btnFavourite.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnFavourite.Image = global::SONA.Properties.Resources.Favourites;
            this.btnFavourite.ImageSize = new System.Drawing.Size(45, 45);
            this.btnFavourite.Location = new System.Drawing.Point(3, 3);
            this.btnFavourite.Name = "btnFavourite";
            this.btnFavourite.Size = new System.Drawing.Size(50, 68);
            this.btnFavourite.TabIndex = 0;
            this.btnFavourite.Click += new System.EventHandler(this.btnFavourite_Click);
            // 
            // btnAlbums
            // 
            this.btnAlbums.Animated = true;
            this.btnAlbums.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAlbums.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAlbums.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAlbums.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAlbums.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAlbums.FillColor = System.Drawing.Color.Transparent;
            this.btnAlbums.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAlbums.ForeColor = System.Drawing.Color.White;
            this.btnAlbums.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnAlbums.Image = global::SONA.Properties.Resources.Add;
            this.btnAlbums.ImageSize = new System.Drawing.Size(45, 45);
            this.btnAlbums.Location = new System.Drawing.Point(59, 3);
            this.btnAlbums.Name = "btnAlbums";
            this.btnAlbums.Size = new System.Drawing.Size(50, 68);
            this.btnAlbums.TabIndex = 0;
            // 
            // guna2Panel3
            // 
            this.guna2Panel3.Controls.Add(this.btnPlayMusic);
            this.guna2Panel3.Controls.Add(this.btnPrev);
            this.guna2Panel3.Controls.Add(this.btShuffle);
            this.guna2Panel3.Controls.Add(this.btnNext);
            this.guna2Panel3.Controls.Add(this.btReplay);
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
            this.btnPlayMusic.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
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
            this.btnPrev.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnPrev.Image = global::SONA.Properties.Resources.Prev;
            this.btnPrev.ImageSize = new System.Drawing.Size(50, 50);
            this.btnPrev.Location = new System.Drawing.Point(56, 3);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(50, 68);
            this.btnPrev.TabIndex = 0;
            // 
            // btShuffle
            // 
            this.btShuffle.Animated = true;
            this.btShuffle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btShuffle.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btShuffle.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btShuffle.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btShuffle.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btShuffle.FillColor = System.Drawing.Color.Transparent;
            this.btShuffle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btShuffle.ForeColor = System.Drawing.Color.White;
            this.btShuffle.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btShuffle.Image = global::SONA.Properties.Resources.Shuffle;
            this.btShuffle.ImageSize = new System.Drawing.Size(40, 40);
            this.btShuffle.Location = new System.Drawing.Point(1, 3);
            this.btShuffle.Name = "btShuffle";
            this.btShuffle.Size = new System.Drawing.Size(50, 68);
            this.btShuffle.TabIndex = 0;
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
            this.btnNext.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnNext.Image = global::SONA.Properties.Resources.Next;
            this.btnNext.ImageSize = new System.Drawing.Size(50, 50);
            this.btnNext.Location = new System.Drawing.Point(188, 3);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(50, 68);
            this.btnNext.TabIndex = 0;
            // 
            // btReplay
            // 
            this.btReplay.Animated = true;
            this.btReplay.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btReplay.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btReplay.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btReplay.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btReplay.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btReplay.FillColor = System.Drawing.Color.Transparent;
            this.btReplay.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btReplay.ForeColor = System.Drawing.Color.White;
            this.btReplay.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btReplay.Image = global::SONA.Properties.Resources.Record;
            this.btReplay.ImageSize = new System.Drawing.Size(45, 45);
            this.btReplay.Location = new System.Drawing.Point(245, 3);
            this.btReplay.Name = "btReplay";
            this.btReplay.Size = new System.Drawing.Size(50, 68);
            this.btReplay.TabIndex = 0;
            this.btReplay.Click += new System.EventHandler(this.btReplay_Click);
            // 
            // btnMore
            // 
            this.btnMore.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
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
            this.btnMore.Location = new System.Drawing.Point(1416, 59);
            this.btnMore.Name = "btnMore";
            this.btnMore.Size = new System.Drawing.Size(50, 68);
            this.btnMore.TabIndex = 0;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // ListenMusic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(9)))), ((int)(((byte)(8)))));
            this.Controls.Add(this.guna2Panel2);
            this.Controls.Add(this.guna2Panel1);
            this.Name = "ListenMusic";
            this.Size = new System.Drawing.Size(1482, 919);
            this.Load += new System.EventHandler(this.ListenMusic_Load);
            this.guna2Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbPictureSong)).EndInit();
            this.guna2Panel2.ResumeLayout(false);
            this.guna2Panel2.PerformLayout();
            this.guna2Panel6.ResumeLayout(false);
            this.guna2Panel6.PerformLayout();
            this.guna2Panel5.ResumeLayout(false);
            this.guna2Panel4.ResumeLayout(false);
            this.guna2Panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Button btnPlayMusic;
        private Guna.UI2.WinForms.Guna2Button btnPrev;
        private Guna.UI2.WinForms.Guna2Button btnNext;
        private Guna.UI2.WinForms.Guna2Button btReplay;
        private Guna.UI2.WinForms.Guna2Button btShuffle;
        private Guna.UI2.WinForms.Guna2Button guna2Button6;
        private Guna.UI2.WinForms.Guna2Button btnLyrics;
        private Guna.UI2.WinForms.Guna2Button btnAlbums;
        private Guna.UI2.WinForms.Guna2Button btnFavourite;
        private Guna.UI2.WinForms.Guna2Button btnMore;
        private Guna.UI2.WinForms.Guna2Button btnPictureSinger;
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

        public FormBorderStyle FormBorderStyle { get; private set; }
    }
}