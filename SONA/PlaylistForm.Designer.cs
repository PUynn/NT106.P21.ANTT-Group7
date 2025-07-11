namespace SONA
{
    partial class PlaylistForm
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
            this.lblNamePlaylist = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btnPicturePlaylist = new Guna.UI2.WinForms.Guna2Button();
            this.pnPlaylistForm = new Guna.UI2.WinForms.Guna2Panel();
            this.btnRemove = new Guna.UI2.WinForms.Guna2Button();
            this.pnPlaylistForm.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblNamePlaylist
            // 
            this.lblNamePlaylist.BackColor = System.Drawing.Color.Transparent;
            this.lblNamePlaylist.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNamePlaylist.ForeColor = System.Drawing.Color.White;
            this.lblNamePlaylist.Location = new System.Drawing.Point(17, 280);
            this.lblNamePlaylist.Name = "lblNamePlaylist";
            this.lblNamePlaylist.Size = new System.Drawing.Size(15, 27);
            this.lblNamePlaylist.TabIndex = 8;
            this.lblNamePlaylist.Text = "A";
            // 
            // btnPicturePlaylist
            // 
            this.btnPicturePlaylist.BackColor = System.Drawing.Color.Transparent;
            this.btnPicturePlaylist.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPicturePlaylist.BorderRadius = 10;
            this.btnPicturePlaylist.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPicturePlaylist.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnPicturePlaylist.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnPicturePlaylist.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnPicturePlaylist.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnPicturePlaylist.FillColor = System.Drawing.Color.Transparent;
            this.btnPicturePlaylist.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnPicturePlaylist.ForeColor = System.Drawing.Color.White;
            this.btnPicturePlaylist.ImageSize = new System.Drawing.Size(50, 50);
            this.btnPicturePlaylist.Location = new System.Drawing.Point(17, 50);
            this.btnPicturePlaylist.Name = "btnPicturePlaylist";
            this.btnPicturePlaylist.Size = new System.Drawing.Size(224, 224);
            this.btnPicturePlaylist.TabIndex = 7;
            this.btnPicturePlaylist.Click += new System.EventHandler(this.btnPicturePlaylist_Click);
            // 
            // pnPlaylistForm
            // 
            this.pnPlaylistForm.Controls.Add(this.btnRemove);
            this.pnPlaylistForm.Controls.Add(this.lblNamePlaylist);
            this.pnPlaylistForm.Controls.Add(this.btnPicturePlaylist);
            this.pnPlaylistForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnPlaylistForm.ForeColor = System.Drawing.Color.White;
            this.pnPlaylistForm.Location = new System.Drawing.Point(0, 0);
            this.pnPlaylistForm.Name = "pnPlaylistForm";
            this.pnPlaylistForm.Size = new System.Drawing.Size(273, 323);
            this.pnPlaylistForm.TabIndex = 1;
            // 
            // btnRemove
            // 
            this.btnRemove.Animated = true;
            this.btnRemove.BackColor = System.Drawing.Color.Transparent;
            this.btnRemove.BorderColor = System.Drawing.Color.Transparent;
            this.btnRemove.BorderRadius = 7;
            this.btnRemove.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.btnRemove.CheckedState.Image = global::SONA.Properties.Resources.FavouriteOn;
            this.btnRemove.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRemove.FillColor = System.Drawing.Color.Transparent;
            this.btnRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemove.ForeColor = System.Drawing.Color.Transparent;
            this.btnRemove.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.btnRemove.Image = global::SONA.Properties.Resources.Close;
            this.btnRemove.ImageOffset = new System.Drawing.Point(0, -2);
            this.btnRemove.ImageSize = new System.Drawing.Size(60, 60);
            this.btnRemove.Location = new System.Drawing.Point(218, 3);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.btnRemove.Size = new System.Drawing.Size(55, 41);
            this.btnRemove.TabIndex = 9;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // PlaylistForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.Controls.Add(this.pnPlaylistForm);
            this.Name = "PlaylistForm";
            this.Size = new System.Drawing.Size(273, 323);
            this.Load += new System.EventHandler(this.PlaylistForm_Load);
            this.pnPlaylistForm.ResumeLayout(false);
            this.pnPlaylistForm.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2HtmlLabel lblNamePlaylist;
        private Guna.UI2.WinForms.Guna2Button btnPicturePlaylist;
        private Guna.UI2.WinForms.Guna2Panel pnPlaylistForm;
        private Guna.UI2.WinForms.Guna2Button btnRemove;
    }
}
