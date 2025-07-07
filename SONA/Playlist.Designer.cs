namespace SONA
{
    partial class Playlist
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
            this.lblNamePlaylist = new System.Windows.Forms.Label();
            this.pnHeader = new Guna.UI2.WinForms.Guna2Panel();
            this.pnTask = new Guna.UI2.WinForms.Guna2Panel();
            this.btnPlay = new Guna.UI2.WinForms.Guna2Button();
            this.btnShuffle = new Guna.UI2.WinForms.Guna2Button();
            this.btnUpload = new Guna.UI2.WinForms.Guna2Button();
            this.btnAdd = new Guna.UI2.WinForms.Guna2Button();
            this.btnDownload = new Guna.UI2.WinForms.Guna2Button();
            this.lblNameUser = new System.Windows.Forms.Label();
            this.pnDescription = new Guna.UI2.WinForms.Guna2Panel();
            this.pbPicturePlaylist = new Guna.UI2.WinForms.Guna2PictureBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.pnPlaylist = new Guna.UI2.WinForms.Guna2Panel();
            this.pnAddSong = new Guna.UI2.WinForms.Guna2Panel();
            this.txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnCancel = new Guna.UI2.WinForms.Guna2Button();
            this.flpListSong = new System.Windows.Forms.FlowLayoutPanel();
            this.btnOk = new Guna.UI2.WinForms.Guna2Button();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.flpSongs = new System.Windows.Forms.FlowLayoutPanel();
            this.pnHeader.SuspendLayout();
            this.pnTask.SuspendLayout();
            this.pnDescription.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPicturePlaylist)).BeginInit();
            this.pnPlaylist.SuspendLayout();
            this.pnAddSong.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblNamePlaylist
            // 
            this.lblNamePlaylist.AutoSize = true;
            this.lblNamePlaylist.Font = new System.Drawing.Font("Segoe UI", 19.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNamePlaylist.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblNamePlaylist.Location = new System.Drawing.Point(3, 9);
            this.lblNamePlaylist.Name = "lblNamePlaylist";
            this.lblNamePlaylist.Size = new System.Drawing.Size(127, 45);
            this.lblNamePlaylist.TabIndex = 0;
            this.lblNamePlaylist.Text = "Playlist";
            // 
            // pnHeader
            // 
            this.pnHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.pnHeader.Controls.Add(this.pnTask);
            this.pnHeader.Controls.Add(this.lblNameUser);
            this.pnHeader.Controls.Add(this.lblNamePlaylist);
            this.pnHeader.Location = new System.Drawing.Point(25, 22);
            this.pnHeader.Name = "pnHeader";
            this.pnHeader.Size = new System.Drawing.Size(995, 162);
            this.pnHeader.TabIndex = 1;
            // 
            // pnTask
            // 
            this.pnTask.Controls.Add(this.btnPlay);
            this.pnTask.Controls.Add(this.btnShuffle);
            this.pnTask.Controls.Add(this.btnUpload);
            this.pnTask.Controls.Add(this.btnAdd);
            this.pnTask.Controls.Add(this.btnDownload);
            this.pnTask.Location = new System.Drawing.Point(3, 94);
            this.pnTask.Name = "pnTask";
            this.pnTask.Size = new System.Drawing.Size(989, 65);
            this.pnTask.TabIndex = 3;
            // 
            // btnPlay
            // 
            this.btnPlay.Animated = true;
            this.btnPlay.BorderRadius = 5;
            this.btnPlay.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPlay.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnPlay.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnPlay.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnPlay.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnPlay.FillColor = System.Drawing.Color.Transparent;
            this.btnPlay.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnPlay.ForeColor = System.Drawing.Color.White;
            this.btnPlay.Image = global::SONA.Properties.Resources.PlayAni;
            this.btnPlay.ImageSize = new System.Drawing.Size(40, 40);
            this.btnPlay.Location = new System.Drawing.Point(8, 12);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(55, 50);
            this.btnPlay.TabIndex = 1;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // btnShuffle
            // 
            this.btnShuffle.Animated = true;
            this.btnShuffle.BorderRadius = 5;
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
            this.btnShuffle.Location = new System.Drawing.Point(69, 15);
            this.btnShuffle.Name = "btnShuffle";
            this.btnShuffle.Size = new System.Drawing.Size(45, 40);
            this.btnShuffle.TabIndex = 1;
            // 
            // btnUpload
            // 
            this.btnUpload.Animated = true;
            this.btnUpload.BorderRadius = 5;
            this.btnUpload.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpload.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnUpload.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnUpload.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnUpload.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnUpload.FillColor = System.Drawing.Color.Transparent;
            this.btnUpload.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnUpload.ForeColor = System.Drawing.Color.White;
            this.btnUpload.Image = global::SONA.Properties.Resources.upload;
            this.btnUpload.ImageSize = new System.Drawing.Size(40, 40);
            this.btnUpload.Location = new System.Drawing.Point(222, 15);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(45, 40);
            this.btnUpload.TabIndex = 5;
            // 
            // btnAdd
            // 
            this.btnAdd.Animated = true;
            this.btnAdd.BorderRadius = 5;
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAdd.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAdd.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAdd.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAdd.FillColor = System.Drawing.Color.Transparent;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Image = global::SONA.Properties.Resources.add_circle;
            this.btnAdd.ImageSize = new System.Drawing.Size(40, 40);
            this.btnAdd.Location = new System.Drawing.Point(120, 15);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(45, 40);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDownload
            // 
            this.btnDownload.Animated = true;
            this.btnDownload.BorderRadius = 5;
            this.btnDownload.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDownload.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDownload.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnDownload.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDownload.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnDownload.FillColor = System.Drawing.Color.Transparent;
            this.btnDownload.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnDownload.ForeColor = System.Drawing.Color.White;
            this.btnDownload.Image = global::SONA.Properties.Resources.Download;
            this.btnDownload.ImageSize = new System.Drawing.Size(40, 40);
            this.btnDownload.Location = new System.Drawing.Point(171, 15);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(45, 40);
            this.btnDownload.TabIndex = 4;
            // 
            // lblNameUser
            // 
            this.lblNameUser.AutoSize = true;
            this.lblNameUser.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNameUser.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblNameUser.Location = new System.Drawing.Point(7, 54);
            this.lblNameUser.Name = "lblNameUser";
            this.lblNameUser.Size = new System.Drawing.Size(226, 23);
            this.lblNameUser.TabIndex = 2;
            this.lblNameUser.Text = "By: Trần Nguyễn Việt Hoàng";
            // 
            // pnDescription
            // 
            this.pnDescription.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.pnDescription.Controls.Add(this.pbPicturePlaylist);
            this.pnDescription.Controls.Add(this.lblDescription);
            this.pnDescription.Location = new System.Drawing.Point(1041, 22);
            this.pnDescription.Name = "pnDescription";
            this.pnDescription.Size = new System.Drawing.Size(400, 894);
            this.pnDescription.TabIndex = 2;
            // 
            // pbPicturePlaylist
            // 
            this.pbPicturePlaylist.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbPicturePlaylist.FillColor = System.Drawing.Color.Transparent;
            this.pbPicturePlaylist.ImageRotate = 0F;
            this.pbPicturePlaylist.Location = new System.Drawing.Point(0, 0);
            this.pbPicturePlaylist.Name = "pbPicturePlaylist";
            this.pbPicturePlaylist.Size = new System.Drawing.Size(400, 400);
            this.pbPicturePlaylist.TabIndex = 0;
            this.pbPicturePlaylist.TabStop = false;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblDescription.Location = new System.Drawing.Point(3, 417);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(100, 23);
            this.lblDescription.TabIndex = 2;
            this.lblDescription.Text = "Description:";
            // 
            // pnPlaylist
            // 
            this.pnPlaylist.Controls.Add(this.pnDescription);
            this.pnPlaylist.Controls.Add(this.pnHeader);
            this.pnPlaylist.Controls.Add(this.pnAddSong);
            this.pnPlaylist.Controls.Add(this.flpSongs);
            this.pnPlaylist.Location = new System.Drawing.Point(0, 0);
            this.pnPlaylist.Name = "pnPlaylist";
            this.pnPlaylist.Size = new System.Drawing.Size(1482, 919);
            this.pnPlaylist.TabIndex = 4;
            // 
            // pnAddSong
            // 
            this.pnAddSong.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(9)))), ((int)(((byte)(9)))));
            this.pnAddSong.BorderRadius = 10;
            this.pnAddSong.Controls.Add(this.txtSearch);
            this.pnAddSong.Controls.Add(this.btnCancel);
            this.pnAddSong.Controls.Add(this.flpListSong);
            this.pnAddSong.Controls.Add(this.btnOk);
            this.pnAddSong.Controls.Add(this.btnClose);
            this.pnAddSong.Location = new System.Drawing.Point(364, 230);
            this.pnAddSong.Name = "pnAddSong";
            this.pnAddSong.Size = new System.Drawing.Size(628, 582);
            this.pnAddSong.TabIndex = 6;
            this.pnAddSong.Visible = false;
            // 
            // txtSearch
            // 
            this.txtSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtSearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtSearch.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.txtSearch.BorderRadius = 25;
            this.txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearch.DefaultText = "";
            this.txtSearch.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtSearch.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtSearch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearch.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearch.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.txtSearch.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSearch.ForeColor = System.Drawing.Color.White;
            this.txtSearch.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSearch.IconLeft = global::SONA.Properties.Resources.Search;
            this.txtSearch.IconLeftOffset = new System.Drawing.Point(10, 0);
            this.txtSearch.IconLeftSize = new System.Drawing.Size(26, 26);
            this.txtSearch.Location = new System.Drawing.Point(37, 59);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(137)))), ((int)(((byte)(137)))));
            this.txtSearch.PlaceholderText = "Search";
            this.txtSearch.SelectedText = "";
            this.txtSearch.Size = new System.Drawing.Size(552, 54);
            this.txtSearch.TabIndex = 70;
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
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
            this.btnCancel.Location = new System.Drawing.Point(444, 510);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(145, 51);
            this.btnCancel.TabIndex = 69;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // flpListSong
            // 
            this.flpListSong.AutoScroll = true;
            this.flpListSong.Location = new System.Drawing.Point(37, 130);
            this.flpListSong.Name = "flpListSong";
            this.flpListSong.Size = new System.Drawing.Size(552, 357);
            this.flpListSong.TabIndex = 66;
            // 
            // btnOk
            // 
            this.btnOk.Animated = true;
            this.btnOk.BackColor = System.Drawing.Color.Transparent;
            this.btnOk.BorderRadius = 8;
            this.btnOk.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOk.FillColor = System.Drawing.Color.White;
            this.btnOk.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnOk.ForeColor = System.Drawing.Color.Black;
            this.btnOk.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnOk.ImageSize = new System.Drawing.Size(28, 28);
            this.btnOk.Location = new System.Drawing.Point(282, 510);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(145, 51);
            this.btnOk.TabIndex = 68;
            this.btnOk.Text = "Ok";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
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
            this.btnClose.Location = new System.Drawing.Point(582, 12);
            this.btnClose.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(30, 30);
            this.btnClose.TabIndex = 65;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // flpSongs
            // 
            this.flpSongs.AutoScroll = true;
            this.flpSongs.Location = new System.Drawing.Point(25, 209);
            this.flpSongs.Name = "flpSongs";
            this.flpSongs.Size = new System.Drawing.Size(995, 707);
            this.flpSongs.TabIndex = 7;
            // 
            // Playlist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.Controls.Add(this.pnPlaylist);
            this.Name = "Playlist";
            this.Size = new System.Drawing.Size(1482, 919);
            this.Load += new System.EventHandler(this.Playlist_Load);
            this.pnHeader.ResumeLayout(false);
            this.pnHeader.PerformLayout();
            this.pnTask.ResumeLayout(false);
            this.pnDescription.ResumeLayout(false);
            this.pnDescription.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPicturePlaylist)).EndInit();
            this.pnPlaylist.ResumeLayout(false);
            this.pnAddSong.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblNamePlaylist;
        private Guna.UI2.WinForms.Guna2Panel pnHeader;
        private Guna.UI2.WinForms.Guna2Panel pnTask;
        private Guna.UI2.WinForms.Guna2Button btnShuffle;
        private Guna.UI2.WinForms.Guna2Button btnAdd;
        private Guna.UI2.WinForms.Guna2Button btnDownload;
        private Guna.UI2.WinForms.Guna2Button btnUpload;
        private System.Windows.Forms.Label lblNameUser;
        private Guna.UI2.WinForms.Guna2Panel pnDescription;
        private Guna.UI2.WinForms.Guna2PictureBox pbPicturePlaylist;
        private Guna.UI2.WinForms.Guna2Panel pnPlaylist;
        private Guna.UI2.WinForms.Guna2Button btnPlay;
        private System.Windows.Forms.Label lblDescription;
        public Guna.UI2.WinForms.Guna2Panel pnAddSong;
        private Guna.UI2.WinForms.Guna2Button btnClose;
        private System.Windows.Forms.FlowLayoutPanel flpListSong;
        private Guna.UI2.WinForms.Guna2TextBox txtSearch;
        private System.Windows.Forms.FlowLayoutPanel flpSongs;
        private Guna.UI2.WinForms.Guna2Button btnCancel;
        private Guna.UI2.WinForms.Guna2Button btnOk;
    }
}
