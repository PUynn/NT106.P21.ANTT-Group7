namespace SONA
{
    partial class Album
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
            this.lblNameAlbum = new System.Windows.Forms.Label();
            this.pnHeader = new Guna.UI2.WinForms.Guna2Panel();
            this.pnTools = new Guna.UI2.WinForms.Guna2Panel();
            this.pnDescription = new Guna.UI2.WinForms.Guna2Panel();
            this.pnAlbum = new Guna.UI2.WinForms.Guna2Panel();
            this.flpSongs = new System.Windows.Forms.FlowLayoutPanel();
            this.lblDescription = new System.Windows.Forms.Label();
            this.pbPictureAlbum = new Guna.UI2.WinForms.Guna2PictureBox();
            this.btnPlay = new Guna.UI2.WinForms.Guna2Button();
            this.btnShuffle = new Guna.UI2.WinForms.Guna2Button();
            this.btnUpload = new Guna.UI2.WinForms.Guna2Button();
            this.btnDownload = new Guna.UI2.WinForms.Guna2Button();
            this.pnHeader.SuspendLayout();
            this.pnTools.SuspendLayout();
            this.pnDescription.SuspendLayout();
            this.pnAlbum.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPictureAlbum)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNameAlbum
            // 
            this.lblNameAlbum.AutoSize = true;
            this.lblNameAlbum.Font = new System.Drawing.Font("Segoe UI", 19.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNameAlbum.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblNameAlbum.Location = new System.Drawing.Point(3, 9);
            this.lblNameAlbum.Name = "lblNameAlbum";
            this.lblNameAlbum.Size = new System.Drawing.Size(120, 45);
            this.lblNameAlbum.TabIndex = 0;
            this.lblNameAlbum.Text = "Album";
            // 
            // pnHeader
            // 
            this.pnHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.pnHeader.Controls.Add(this.pnTools);
            this.pnHeader.Controls.Add(this.lblDescription);
            this.pnHeader.Controls.Add(this.lblNameAlbum);
            this.pnHeader.Location = new System.Drawing.Point(25, 22);
            this.pnHeader.Name = "pnHeader";
            this.pnHeader.Size = new System.Drawing.Size(995, 162);
            this.pnHeader.TabIndex = 1;
            // 
            // pnTools
            // 
            this.pnTools.Controls.Add(this.btnPlay);
            this.pnTools.Controls.Add(this.btnShuffle);
            this.pnTools.Controls.Add(this.btnUpload);
            this.pnTools.Controls.Add(this.btnDownload);
            this.pnTools.Location = new System.Drawing.Point(3, 94);
            this.pnTools.Name = "pnTools";
            this.pnTools.Size = new System.Drawing.Size(989, 65);
            this.pnTools.TabIndex = 3;
            // 
            // pnDescription
            // 
            this.pnDescription.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.pnDescription.Controls.Add(this.pbPictureAlbum);
            this.pnDescription.Location = new System.Drawing.Point(1041, 22);
            this.pnDescription.Name = "pnDescription";
            this.pnDescription.Size = new System.Drawing.Size(400, 894);
            this.pnDescription.TabIndex = 2;
            // 
            // pnAlbum
            // 
            this.pnAlbum.Controls.Add(this.flpSongs);
            this.pnAlbum.Controls.Add(this.pnDescription);
            this.pnAlbum.Controls.Add(this.pnHeader);
            this.pnAlbum.Location = new System.Drawing.Point(0, 0);
            this.pnAlbum.Name = "pnAlbum";
            this.pnAlbum.Size = new System.Drawing.Size(1482, 919);
            this.pnAlbum.TabIndex = 4;
            // 
            // flpSongs
            // 
            this.flpSongs.AutoScroll = true;
            this.flpSongs.Location = new System.Drawing.Point(25, 209);
            this.flpSongs.Name = "flpSongs";
            this.flpSongs.Size = new System.Drawing.Size(995, 707);
            this.flpSongs.TabIndex = 3;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblDescription.Location = new System.Drawing.Point(7, 54);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(287, 23);
            this.lblDescription.TabIndex = 2;
            this.lblDescription.Text = "A collection of popular US/UK songs";
            // 
            // pbPictureAlbum
            // 
            this.pbPictureAlbum.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbPictureAlbum.FillColor = System.Drawing.Color.Transparent;
            this.pbPictureAlbum.ImageRotate = 0F;
            this.pbPictureAlbum.Location = new System.Drawing.Point(0, 0);
            this.pbPictureAlbum.Name = "pbPictureAlbum";
            this.pbPictureAlbum.Size = new System.Drawing.Size(400, 400);
            this.pbPictureAlbum.TabIndex = 0;
            this.pbPictureAlbum.TabStop = false;
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
            this.btnShuffle.Click += new System.EventHandler(this.btnShuffle_Click);
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
            this.btnUpload.Location = new System.Drawing.Point(171, 15);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(45, 40);
            this.btnUpload.TabIndex = 5;
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
            this.btnDownload.Location = new System.Drawing.Point(120, 15);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(45, 40);
            this.btnDownload.TabIndex = 4;
            // 
            // Album
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.Controls.Add(this.pnAlbum);
            this.Name = "Album";
            this.Size = new System.Drawing.Size(1482, 919);
            this.Load += new System.EventHandler(this.Album_Load);
            this.pnHeader.ResumeLayout(false);
            this.pnHeader.PerformLayout();
            this.pnTools.ResumeLayout(false);
            this.pnDescription.ResumeLayout(false);
            this.pnAlbum.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbPictureAlbum)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblNameAlbum;
        private Guna.UI2.WinForms.Guna2Panel pnHeader;
        private Guna.UI2.WinForms.Guna2Panel pnTools;
        private Guna.UI2.WinForms.Guna2Button btnShuffle;
        private Guna.UI2.WinForms.Guna2Button btnDownload;
        private Guna.UI2.WinForms.Guna2Button btnUpload;
        private Guna.UI2.WinForms.Guna2Panel pnDescription;
        private Guna.UI2.WinForms.Guna2PictureBox pbPictureAlbum;
        private Guna.UI2.WinForms.Guna2Panel pnAlbum;
        private Guna.UI2.WinForms.Guna2Button btnPlay;
        private System.Windows.Forms.FlowLayoutPanel flpSongs;
        private System.Windows.Forms.Label lblDescription;
    }
}
