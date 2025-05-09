namespace SONA
{
    partial class ArtistInfor
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
            this.flpSongs = new System.Windows.Forms.FlowLayoutPanel();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.lblCountry = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblDate = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblNameSinger = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btnAvatar = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnAvatar)).BeginInit();
            this.SuspendLayout();
            // 
            // flpSongs
            // 
            this.flpSongs.AutoScroll = true;
            this.flpSongs.Location = new System.Drawing.Point(3, 388);
            this.flpSongs.Name = "flpSongs";
            this.flpSongs.Size = new System.Drawing.Size(1479, 466);
            this.flpSongs.TabIndex = 11;
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Controls.Add(this.lblCountry);
            this.guna2Panel1.Controls.Add(this.lblDate);
            this.guna2Panel1.Controls.Add(this.lblNameSinger);
            this.guna2Panel1.Controls.Add(this.btnAvatar);
            this.guna2Panel1.Location = new System.Drawing.Point(3, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(1479, 336);
            this.guna2Panel1.TabIndex = 12;
            // 
            // lblCountry
            // 
            this.lblCountry.BackColor = System.Drawing.Color.Transparent;
            this.lblCountry.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCountry.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(137)))), ((int)(((byte)(137)))));
            this.lblCountry.Location = new System.Drawing.Point(343, 180);
            this.lblCountry.Name = "lblCountry";
            this.lblCountry.Size = new System.Drawing.Size(40, 24);
            this.lblCountry.TabIndex = 1;
            this.lblCountry.Text = "USA";
            // 
            // lblDate
            // 
            this.lblDate.BackColor = System.Drawing.Color.Transparent;
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(137)))), ((int)(((byte)(137)))));
            this.lblDate.Location = new System.Drawing.Point(343, 155);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(210, 24);
            this.lblDate.TabIndex = 1;
            this.lblDate.Text = "Since 1991, December 02";
            // 
            // lblNameSinger
            // 
            this.lblNameSinger.BackColor = System.Drawing.Color.Transparent;
            this.lblNameSinger.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNameSinger.ForeColor = System.Drawing.Color.White;
            this.lblNameSinger.Location = new System.Drawing.Point(341, 105);
            this.lblNameSinger.Name = "lblNameSinger";
            this.lblNameSinger.Size = new System.Drawing.Size(222, 48);
            this.lblNameSinger.TabIndex = 1;
            this.lblNameSinger.Text = "Charlie Puth";
            // 
            // btnAvatar
            // 
            this.btnAvatar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAvatar.FillColor = System.Drawing.Color.Transparent;
            this.btnAvatar.ImageRotate = 0F;
            this.btnAvatar.Location = new System.Drawing.Point(16, 16);
            this.btnAvatar.Name = "btnAvatar";
            this.btnAvatar.Size = new System.Drawing.Size(300, 300);
            this.btnAvatar.TabIndex = 0;
            this.btnAvatar.TabStop = false;
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 17.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel1.ForeColor = System.Drawing.Color.White;
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(16, 342);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(132, 38);
            this.guna2HtmlLabel1.TabIndex = 13;
            this.guna2HtmlLabel1.Text = "List song:";
            // 
            // ArtistInfor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.Controls.Add(this.guna2HtmlLabel1);
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.flpSongs);
            this.Name = "ArtistInfor";
            this.Size = new System.Drawing.Size(1485, 919);
            this.Load += new System.EventHandler(this.ArtistInfor_Load);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnAvatar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpSongs;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2PictureBox btnAvatar;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblNameSinger;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblDate;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblCountry;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
    }
}
