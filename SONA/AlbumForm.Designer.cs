namespace SONA
{
    partial class AlbumForm
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
            this.lblNameAlbum = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btnPictureAlbum = new Guna.UI2.WinForms.Guna2Button();
            this.pnAlbumForm = new Guna.UI2.WinForms.Guna2Panel();
            this.pnAlbumForm.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblNameAlbum
            // 
            this.lblNameAlbum.BackColor = System.Drawing.Color.Transparent;
            this.lblNameAlbum.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNameAlbum.ForeColor = System.Drawing.Color.White;
            this.lblNameAlbum.Location = new System.Drawing.Point(13, 242);
            this.lblNameAlbum.Name = "lblNameAlbum";
            this.lblNameAlbum.Size = new System.Drawing.Size(15, 27);
            this.lblNameAlbum.TabIndex = 8;
            this.lblNameAlbum.Text = "A";
            // 
            // btnPictureAlbum
            // 
            this.btnPictureAlbum.BackColor = System.Drawing.Color.Transparent;
            this.btnPictureAlbum.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPictureAlbum.BorderRadius = 10;
            this.btnPictureAlbum.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPictureAlbum.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnPictureAlbum.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnPictureAlbum.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnPictureAlbum.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnPictureAlbum.FillColor = System.Drawing.Color.Transparent;
            this.btnPictureAlbum.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnPictureAlbum.ForeColor = System.Drawing.Color.Black;
            this.btnPictureAlbum.ImageSize = new System.Drawing.Size(50, 50);
            this.btnPictureAlbum.Location = new System.Drawing.Point(13, 12);
            this.btnPictureAlbum.Name = "btnPictureAlbum";
            this.btnPictureAlbum.Size = new System.Drawing.Size(224, 224);
            this.btnPictureAlbum.TabIndex = 7;
            this.btnPictureAlbum.Click += new System.EventHandler(this.btnPictureAlbum_Click);
            // 
            // pnAlbumForm
            // 
            this.pnAlbumForm.Controls.Add(this.lblNameAlbum);
            this.pnAlbumForm.Controls.Add(this.btnPictureAlbum);
            this.pnAlbumForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnAlbumForm.ForeColor = System.Drawing.Color.White;
            this.pnAlbumForm.Location = new System.Drawing.Point(0, 0);
            this.pnAlbumForm.Name = "pnAlbumForm";
            this.pnAlbumForm.Size = new System.Drawing.Size(273, 282);
            this.pnAlbumForm.TabIndex = 1;
            // 
            // AlbumForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.Controls.Add(this.pnAlbumForm);
            this.Name = "AlbumForm";
            this.Size = new System.Drawing.Size(273, 282);
            this.Load += new System.EventHandler(this.AlbumForm_Load);
            this.pnAlbumForm.ResumeLayout(false);
            this.pnAlbumForm.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2HtmlLabel lblNameAlbum;
        private Guna.UI2.WinForms.Guna2Button btnPictureAlbum;
        private Guna.UI2.WinForms.Guna2Panel pnAlbumForm;
    }
}
