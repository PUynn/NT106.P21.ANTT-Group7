namespace SONA
{
    partial class SongForm
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
            this.lbNameSong = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btnPictureSong = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(9)))), ((int)(((byte)(8)))));
            this.guna2Panel1.Controls.Add(this.lbNameSong);
            this.guna2Panel1.Controls.Add(this.btnPictureSong);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2Panel1.ForeColor = System.Drawing.Color.White;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(250, 254);
            this.guna2Panel1.TabIndex = 0;
            // 
            // lbNameSong
            // 
            this.lbNameSong.BackColor = System.Drawing.Color.Transparent;
            this.lbNameSong.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNameSong.ForeColor = System.Drawing.Color.White;
            this.lbNameSong.Location = new System.Drawing.Point(13, 214);
            this.lbNameSong.Name = "lbNameSong";
            this.lbNameSong.Size = new System.Drawing.Size(15, 24);
            this.lbNameSong.TabIndex = 8;
            this.lbNameSong.Text = "A";
            // 
            // btnPictureSong
            // 
            this.btnPictureSong.BorderRadius = 10;
            this.btnPictureSong.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPictureSong.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnPictureSong.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnPictureSong.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnPictureSong.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnPictureSong.FillColor = System.Drawing.Color.Transparent;
            this.btnPictureSong.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnPictureSong.ForeColor = System.Drawing.Color.White;
            this.btnPictureSong.ImageSize = new System.Drawing.Size(50, 50);
            this.btnPictureSong.Location = new System.Drawing.Point(13, 0);
            this.btnPictureSong.Name = "btnPictureSong";
            this.btnPictureSong.Size = new System.Drawing.Size(224, 208);
            this.btnPictureSong.TabIndex = 7;
            this.btnPictureSong.Click += new System.EventHandler(this.btnPictureSong_Click);
            // 
            // SongForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.guna2Panel1);
            this.Name = "SongForm";
            this.Size = new System.Drawing.Size(250, 254);
            this.Load += new System.EventHandler(this.SongForm_Load);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Button btnPictureSong;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbNameSong;
    }
}
