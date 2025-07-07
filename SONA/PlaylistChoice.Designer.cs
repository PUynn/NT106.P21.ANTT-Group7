namespace SONA
{
    partial class PlaylistChoice
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
            this.btnPicturePlaylist = new Guna.UI2.WinForms.Guna2Button();
            this.lblNamePlaylist = new System.Windows.Forms.Label();
            this.btnCheck = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // btnPicturePlaylist
            // 
            this.btnPicturePlaylist.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPicturePlaylist.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnPicturePlaylist.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnPicturePlaylist.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnPicturePlaylist.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnPicturePlaylist.FillColor = System.Drawing.Color.Transparent;
            this.btnPicturePlaylist.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnPicturePlaylist.ForeColor = System.Drawing.Color.White;
            this.btnPicturePlaylist.Location = new System.Drawing.Point(3, 5);
            this.btnPicturePlaylist.Name = "btnPicturePlaylist";
            this.btnPicturePlaylist.Size = new System.Drawing.Size(50, 50);
            this.btnPicturePlaylist.TabIndex = 0;
            // 
            // lblNamePlaylist
            // 
            this.lblNamePlaylist.AutoSize = true;
            this.lblNamePlaylist.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.lblNamePlaylist.ForeColor = System.Drawing.Color.White;
            this.lblNamePlaylist.Location = new System.Drawing.Point(71, 16);
            this.lblNamePlaylist.Name = "lblNamePlaylist";
            this.lblNamePlaylist.Size = new System.Drawing.Size(76, 23);
            this.lblNamePlaylist.TabIndex = 1;
            this.lblNamePlaylist.Text = "Playlist 1";
            // 
            // btnCheck
            // 
            this.btnCheck.Animated = true;
            this.btnCheck.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCheck.CheckedState.Image = global::SONA.Properties.Resources.CheckOn;
            this.btnCheck.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCheck.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCheck.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCheck.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCheck.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCheck.FillColor = System.Drawing.Color.Transparent;
            this.btnCheck.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCheck.ForeColor = System.Drawing.Color.White;
            this.btnCheck.Image = global::SONA.Properties.Resources.CheckOff;
            this.btnCheck.ImageSize = new System.Drawing.Size(50, 50);
            this.btnCheck.Location = new System.Drawing.Point(214, 12);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(34, 34);
            this.btnCheck.TabIndex = 4;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // PlaylistChoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(9)))), ((int)(((byte)(9)))));
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.lblNamePlaylist);
            this.Controls.Add(this.btnPicturePlaylist);
            this.Name = "PlaylistChoice";
            this.Size = new System.Drawing.Size(260, 59);
            this.Load += new System.EventHandler(this.PlaylistChoice_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btnPicturePlaylist;
        private System.Windows.Forms.Label lblNamePlaylist;
        private Guna.UI2.WinForms.Guna2Button btnCheck;
    }
}
