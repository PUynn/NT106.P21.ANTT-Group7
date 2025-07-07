namespace SONA
{
    partial class ArtistForm
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
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.cpbArtist = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.lbNameAlbum = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cpbArtist)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Controls.Add(this.cpbArtist);
            this.guna2Panel1.Controls.Add(this.lbNameAlbum);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(260, 260);
            this.guna2Panel1.TabIndex = 0;
            // 
            // cpbArtist
            // 
            this.cpbArtist.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cpbArtist.FillColor = System.Drawing.Color.Transparent;
            this.cpbArtist.ImageRotate = 0F;
            this.cpbArtist.Location = new System.Drawing.Point(13, 0);
            this.cpbArtist.Name = "cpbArtist";
            this.cpbArtist.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.cpbArtist.Size = new System.Drawing.Size(224, 224);
            this.cpbArtist.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.cpbArtist.TabIndex = 12;
            this.cpbArtist.TabStop = false;
            this.cpbArtist.Click += new System.EventHandler(this.cpbArtist_Click);
            // 
            // lbNameAlbum
            // 
            this.lbNameAlbum.AutoSize = false;
            this.lbNameAlbum.BackColor = System.Drawing.Color.Transparent;
            this.lbNameAlbum.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNameAlbum.ForeColor = System.Drawing.Color.White;
            this.lbNameAlbum.Location = new System.Drawing.Point(13, 230);
            this.lbNameAlbum.Name = "lbNameAlbum";
            this.lbNameAlbum.Size = new System.Drawing.Size(224, 24);
            this.lbNameAlbum.TabIndex = 10;
            this.lbNameAlbum.Text = "A";
            this.lbNameAlbum.TextAlignment = System.Drawing.ContentAlignment.TopCenter;
            // 
            // ArtistForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.Controls.Add(this.guna2Panel1);
            this.Name = "ArtistForm";
            this.Size = new System.Drawing.Size(260, 260);
            this.Load += new System.EventHandler(this.ArtistForm_Load);
            this.guna2Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cpbArtist)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbNameAlbum;
        private Guna.UI2.WinForms.Guna2CirclePictureBox cpbArtist;
    }
}
