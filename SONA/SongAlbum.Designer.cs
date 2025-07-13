namespace SONA
{
    partial class SongAlbum
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
            this.pnSongAlbum = new Guna.UI2.WinForms.Guna2Panel();
            this.lblNameSinger = new System.Windows.Forms.Label();
            this.btnFavourite = new Guna.UI2.WinForms.Guna2Button();
            this.lblNameSong = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btnPictureSong = new Guna.UI2.WinForms.Guna2Button();
            this.pnSongAlbum.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnSongAlbum
            // 
            this.pnSongAlbum.Controls.Add(this.lblNameSinger);
            this.pnSongAlbum.Controls.Add(this.btnFavourite);
            this.pnSongAlbum.Controls.Add(this.lblNameSong);
            this.pnSongAlbum.Controls.Add(this.btnPictureSong);
            this.pnSongAlbum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnSongAlbum.Location = new System.Drawing.Point(0, 0);
            this.pnSongAlbum.Name = "pnSongAlbum";
            this.pnSongAlbum.Size = new System.Drawing.Size(960, 100);
            this.pnSongAlbum.TabIndex = 1;
            // 
            // lblNameSinger
            // 
            this.lblNameSinger.AutoSize = true;
            this.lblNameSinger.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblNameSinger.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblNameSinger.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(137)))), ((int)(((byte)(137)))));
            this.lblNameSinger.Location = new System.Drawing.Point(109, 43);
            this.lblNameSinger.Name = "lblNameSinger";
            this.lblNameSinger.Size = new System.Drawing.Size(88, 20);
            this.lblNameSinger.TabIndex = 3;
            this.lblNameSinger.Text = "Charlie Puth";
            this.lblNameSinger.Click += new System.EventHandler(this.lblNameSinger_Click);
            // 
            // btnFavourite
            // 
            this.btnFavourite.Animated = true;
            this.btnFavourite.BackColor = System.Drawing.Color.Transparent;
            this.btnFavourite.BorderColor = System.Drawing.Color.Transparent;
            this.btnFavourite.BorderRadius = 7;
            this.btnFavourite.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.btnFavourite.CheckedState.Image = global::SONA.Properties.Resources.FavouriteOn;
            this.btnFavourite.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFavourite.FillColor = System.Drawing.Color.Transparent;
            this.btnFavourite.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFavourite.ForeColor = System.Drawing.Color.Transparent;
            this.btnFavourite.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.btnFavourite.Image = global::SONA.Properties.Resources.Favourites;
            this.btnFavourite.ImageOffset = new System.Drawing.Point(0, -2);
            this.btnFavourite.ImageSize = new System.Drawing.Size(40, 40);
            this.btnFavourite.Location = new System.Drawing.Point(884, 22);
            this.btnFavourite.Name = "btnFavourite";
            this.btnFavourite.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.btnFavourite.Size = new System.Drawing.Size(55, 41);
            this.btnFavourite.TabIndex = 2;
            this.btnFavourite.Click += new System.EventHandler(this.btnFavorited_Click);
            // 
            // lblNameSong
            // 
            this.lblNameSong.BackColor = System.Drawing.Color.Transparent;
            this.lblNameSong.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.lblNameSong.ForeColor = System.Drawing.Color.White;
            this.lblNameSong.Location = new System.Drawing.Point(113, 13);
            this.lblNameSong.Name = "lblNameSong";
            this.lblNameSong.Size = new System.Drawing.Size(99, 33);
            this.lblNameSong.TabIndex = 1;
            this.lblNameSong.Text = "Attention";
            // 
            // btnPictureSong
            // 
            this.btnPictureSong.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPictureSong.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPictureSong.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnPictureSong.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnPictureSong.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnPictureSong.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnPictureSong.FillColor = System.Drawing.Color.Transparent;
            this.btnPictureSong.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnPictureSong.ForeColor = System.Drawing.Color.White;
            this.btnPictureSong.Location = new System.Drawing.Point(16, 3);
            this.btnPictureSong.Name = "btnPictureSong";
            this.btnPictureSong.Size = new System.Drawing.Size(80, 80);
            this.btnPictureSong.TabIndex = 0;
            this.btnPictureSong.Click += new System.EventHandler(this.btnPictureSong_Click);
            // 
            // SongAlbum
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.Controls.Add(this.pnSongAlbum);
            this.Name = "SongAlbum";
            this.Size = new System.Drawing.Size(960, 100);
            this.Load += new System.EventHandler(this.SongSearch_Load);
            this.pnSongAlbum.ResumeLayout(false);
            this.pnSongAlbum.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pnSongAlbum;
        private System.Windows.Forms.Label lblNameSinger;
        private Guna.UI2.WinForms.Guna2Button btnFavourite;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblNameSong;
        private Guna.UI2.WinForms.Guna2Button btnPictureSong;
    }
}
