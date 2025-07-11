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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListenMusic));
            this.pnBackground = new Guna.UI2.WinForms.Guna2Panel();
            this.pbPictureSong = new Guna.UI2.WinForms.Guna2PictureBox();
            this.btnPlaylist = new Guna.UI2.WinForms.Guna2Button();
            this.pnAddPlaylist = new Guna.UI2.WinForms.Guna2Panel();
            this.lblNewPlaylist = new System.Windows.Forms.Label();
            this.btnAdd = new Guna.UI2.WinForms.Guna2Button();
            this.btnCloseflpPlaylist = new Guna.UI2.WinForms.Guna2Button();
            this.flpPlaylist = new System.Windows.Forms.FlowLayoutPanel();
            this.pnArtists = new Guna.UI2.WinForms.Guna2Panel();
            this.cpbPictureSinger = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.lblSince = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblNameSinger = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.pnCreatePlaylist = new Guna.UI2.WinForms.Guna2Panel();
            this.cpbPicturePlaylist = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.lblChoosePicture = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbNamePlaylist = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnCancel = new Guna.UI2.WinForms.Guna2Button();
            this.btnCreate = new Guna.UI2.WinForms.Guna2Button();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.btnFavourite = new Guna.UI2.WinForms.Guna2Button();
            this.btnLyrics = new Guna.UI2.WinForms.Guna2Button();
            this.pnTools = new Guna.UI2.WinForms.Guna2Panel();
            this.pnBackground.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPictureSong)).BeginInit();
            this.pnAddPlaylist.SuspendLayout();
            this.pnArtists.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cpbPictureSinger)).BeginInit();
            this.pnCreatePlaylist.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cpbPicturePlaylist)).BeginInit();
            this.pnTools.SuspendLayout();
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
            this.btnPlaylist.Image = ((System.Drawing.Image)(resources.GetObject("btnPlaylist.Image")));
            this.btnPlaylist.ImageSize = new System.Drawing.Size(45, 45);
            this.btnPlaylist.Location = new System.Drawing.Point(3, 7);
            this.btnPlaylist.Name = "btnPlaylist";
            this.btnPlaylist.Size = new System.Drawing.Size(59, 59);
            this.btnPlaylist.TabIndex = 0;
            this.btnPlaylist.Click += new System.EventHandler(this.btnPlaylist_Click);
            // 
            // pnAddPlaylist
            // 
            this.pnAddPlaylist.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(9)))), ((int)(((byte)(9)))));
            this.pnAddPlaylist.Controls.Add(this.lblNewPlaylist);
            this.pnAddPlaylist.Controls.Add(this.btnAdd);
            this.pnAddPlaylist.Controls.Add(this.btnCloseflpPlaylist);
            this.pnAddPlaylist.Controls.Add(this.flpPlaylist);
            this.pnAddPlaylist.Location = new System.Drawing.Point(1119, 331);
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
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
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
            this.btnCloseflpPlaylist.Image = ((System.Drawing.Image)(resources.GetObject("btnCloseflpPlaylist.Image")));
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
            // pnArtists
            // 
            this.pnArtists.Controls.Add(this.cpbPictureSinger);
            this.pnArtists.Controls.Add(this.lblSince);
            this.pnArtists.Controls.Add(this.lblNameSinger);
            this.pnArtists.Location = new System.Drawing.Point(45, 630);
            this.pnArtists.Name = "pnArtists";
            this.pnArtists.Size = new System.Drawing.Size(274, 80);
            this.pnArtists.TabIndex = 6;
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
            this.cpbPicturePlaylist.Image = ((System.Drawing.Image)(resources.GetObject("cpbPicturePlaylist.Image")));
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
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(571, 13);
            this.btnClose.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(30, 30);
            this.btnClose.TabIndex = 65;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnFavourite
            // 
            this.btnFavourite.Animated = true;
            this.btnFavourite.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.btnFavourite.CheckedState.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
            this.btnFavourite.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFavourite.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnFavourite.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnFavourite.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnFavourite.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnFavourite.FillColor = System.Drawing.Color.Transparent;
            this.btnFavourite.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnFavourite.ForeColor = System.Drawing.Color.White;
            this.btnFavourite.Image = ((System.Drawing.Image)(resources.GetObject("btnFavourite.Image")));
            this.btnFavourite.ImageSize = new System.Drawing.Size(45, 45);
            this.btnFavourite.Location = new System.Drawing.Point(68, 7);
            this.btnFavourite.Name = "btnFavourite";
            this.btnFavourite.Size = new System.Drawing.Size(59, 59);
            this.btnFavourite.TabIndex = 1;
            this.btnFavourite.Click += new System.EventHandler(this.btnFavourite_Click);
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
            this.btnLyrics.Image = ((System.Drawing.Image)(resources.GetObject("btnLyrics.Image")));
            this.btnLyrics.ImageSize = new System.Drawing.Size(45, 45);
            this.btnLyrics.Location = new System.Drawing.Point(133, 7);
            this.btnLyrics.Name = "btnLyrics";
            this.btnLyrics.Size = new System.Drawing.Size(59, 59);
            this.btnLyrics.TabIndex = 75;
            // 
            // pnTools
            // 
            this.pnTools.Controls.Add(this.btnFavourite);
            this.pnTools.Controls.Add(this.btnPlaylist);
            this.pnTools.Controls.Add(this.btnLyrics);
            this.pnTools.Location = new System.Drawing.Point(1239, 630);
            this.pnTools.Name = "pnTools";
            this.pnTools.Size = new System.Drawing.Size(195, 80);
            this.pnTools.TabIndex = 9;
            // 
            // ListenMusic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.Controls.Add(this.pnTools);
            this.Controls.Add(this.pnAddPlaylist);
            this.Controls.Add(this.pnCreatePlaylist);
            this.Controls.Add(this.pnArtists);
            this.Controls.Add(this.pnBackground);
            this.Name = "ListenMusic";
            this.Size = new System.Drawing.Size(1482, 919);
            this.Load += new System.EventHandler(this.ListenMusic_Load);
            this.pnBackground.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbPictureSong)).EndInit();
            this.pnAddPlaylist.ResumeLayout(false);
            this.pnAddPlaylist.PerformLayout();
            this.pnArtists.ResumeLayout(false);
            this.pnArtists.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cpbPictureSinger)).EndInit();
            this.pnCreatePlaylist.ResumeLayout(false);
            this.pnCreatePlaylist.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cpbPicturePlaylist)).EndInit();
            this.pnTools.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Panel pnBackground;
        private Guna.UI2.WinForms.Guna2Button btnPlaylist;
        private Guna.UI2.WinForms.Guna2PictureBox pbPictureSong;
        private Guna.UI2.WinForms.Guna2Panel pnArtists;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblNameSinger;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblSince;
        private Guna.UI2.WinForms.Guna2CirclePictureBox cpbPictureSinger;
        private FlowLayoutPanel flpPlaylist;
        private Guna.UI2.WinForms.Guna2Panel pnAddPlaylist;
        private Guna.UI2.WinForms.Guna2Button btnAdd;
        private Label lblNewPlaylist;
        private Guna.UI2.WinForms.Guna2Button btnCloseflpPlaylist;
        public Guna.UI2.WinForms.Guna2Panel pnCreatePlaylist;
        private Label lblChoosePicture;
        private Label label2;
        private Guna.UI2.WinForms.Guna2TextBox tbNamePlaylist;
        private Guna.UI2.WinForms.Guna2Button btnCancel;
        private Guna.UI2.WinForms.Guna2Button btnCreate;
        private Guna.UI2.WinForms.Guna2Button btnClose;
        private Guna.UI2.WinForms.Guna2Button btnFavourite;
        private Guna.UI2.WinForms.Guna2CirclePictureBox cpbPicturePlaylist;
        private Guna.UI2.WinForms.Guna2Button btnLyrics;
        private Guna.UI2.WinForms.Guna2Panel pnTools;

        public FormBorderStyle FormBorderStyle { get; private set; }
    }
}