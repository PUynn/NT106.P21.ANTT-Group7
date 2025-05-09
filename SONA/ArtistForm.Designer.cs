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
            this.btnPictureSinger = new Guna.UI2.WinForms.Guna2Button();
            this.lblNameSinger = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Controls.Add(this.btnPictureSinger);
            this.guna2Panel1.Controls.Add(this.lblNameSinger);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(250, 254);
            this.guna2Panel1.TabIndex = 0;
            // 
            // btnPictureSinger
            // 
            this.btnPictureSinger.BorderRadius = 10;
            this.btnPictureSinger.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPictureSinger.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnPictureSinger.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnPictureSinger.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnPictureSinger.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnPictureSinger.FillColor = System.Drawing.Color.Transparent;
            this.btnPictureSinger.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnPictureSinger.ForeColor = System.Drawing.Color.White;
            this.btnPictureSinger.ImageSize = new System.Drawing.Size(50, 50);
            this.btnPictureSinger.Location = new System.Drawing.Point(13, 0);
            this.btnPictureSinger.Name = "btnPictureSinger";
            this.btnPictureSinger.Size = new System.Drawing.Size(224, 208);
            this.btnPictureSinger.TabIndex = 11;
            this.btnPictureSinger.Click += new System.EventHandler(this.btnPictureSong_Click);
            // 
            // lblNameSinger
            // 
            this.lblNameSinger.BackColor = System.Drawing.Color.Transparent;
            this.lblNameSinger.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNameSinger.ForeColor = System.Drawing.Color.White;
            this.lblNameSinger.Location = new System.Drawing.Point(13, 214);
            this.lblNameSinger.Name = "lblNameSinger";
            this.lblNameSinger.Size = new System.Drawing.Size(15, 24);
            this.lblNameSinger.TabIndex = 10;
            this.lblNameSinger.Text = "A";
            // 
            // ArtistForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(9)))), ((int)(((byte)(8)))));
            this.Controls.Add(this.guna2Panel1);
            this.Name = "ArtistForm";
            this.Size = new System.Drawing.Size(250, 254);
            this.Load += new System.EventHandler(this.ArtistForm_Load);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblNameSinger;
        private Guna.UI2.WinForms.Guna2Button btnPictureSinger;
    }
}
