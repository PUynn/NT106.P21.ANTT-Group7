namespace SONA
{
    partial class SearchForm
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
            this.flpResult = new System.Windows.Forms.FlowLayoutPanel();
            this.pnHeader = new Guna.UI2.WinForms.Guna2Panel();
            this.btnArtists = new Guna.UI2.WinForms.Guna2Button();
            this.btnAll = new Guna.UI2.WinForms.Guna2Button();
            this.btnSongs = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Panel1.SuspendLayout();
            this.pnHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Controls.Add(this.flpResult);
            this.guna2Panel1.Controls.Add(this.pnHeader);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(1485, 919);
            this.guna2Panel1.TabIndex = 0;
            // 
            // flpResult
            // 
            this.flpResult.AutoScroll = true;
            this.flpResult.Location = new System.Drawing.Point(4, 68);
            this.flpResult.Name = "flpResult";
            this.flpResult.Size = new System.Drawing.Size(1475, 848);
            this.flpResult.TabIndex = 12;
            // 
            // pnHeader
            // 
            this.pnHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.pnHeader.Controls.Add(this.btnArtists);
            this.pnHeader.Controls.Add(this.btnAll);
            this.pnHeader.Controls.Add(this.btnSongs);
            this.pnHeader.Location = new System.Drawing.Point(0, 3);
            this.pnHeader.Name = "pnHeader";
            this.pnHeader.Size = new System.Drawing.Size(1479, 59);
            this.pnHeader.TabIndex = 8;
            // 
            // btnArtists
            // 
            this.btnArtists.Animated = true;
            this.btnArtists.BackColor = System.Drawing.Color.Transparent;
            this.btnArtists.BorderRadius = 8;
            this.btnArtists.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnArtists.CheckedState.FillColor = System.Drawing.Color.White;
            this.btnArtists.CheckedState.ForeColor = System.Drawing.Color.Black;
            this.btnArtists.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnArtists.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnArtists.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnArtists.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnArtists.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.btnArtists.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnArtists.ForeColor = System.Drawing.Color.White;
            this.btnArtists.Location = new System.Drawing.Point(173, 13);
            this.btnArtists.Name = "btnArtists";
            this.btnArtists.Size = new System.Drawing.Size(106, 33);
            this.btnArtists.TabIndex = 9;
            this.btnArtists.Text = "Artists";
            this.btnArtists.Click += new System.EventHandler(this.btnArtists_Click);
            // 
            // btnAll
            // 
            this.btnAll.Animated = true;
            this.btnAll.BackColor = System.Drawing.Color.Transparent;
            this.btnAll.BorderRadius = 8;
            this.btnAll.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnAll.Checked = true;
            this.btnAll.CheckedState.FillColor = System.Drawing.Color.White;
            this.btnAll.CheckedState.ForeColor = System.Drawing.Color.Black;
            this.btnAll.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAll.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAll.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAll.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAll.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.btnAll.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAll.ForeColor = System.Drawing.Color.White;
            this.btnAll.Location = new System.Drawing.Point(16, 13);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(55, 33);
            this.btnAll.TabIndex = 11;
            this.btnAll.Text = "All";
            // 
            // btnSongs
            // 
            this.btnSongs.Animated = true;
            this.btnSongs.BackColor = System.Drawing.Color.Transparent;
            this.btnSongs.BorderRadius = 8;
            this.btnSongs.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnSongs.CheckedState.FillColor = System.Drawing.Color.White;
            this.btnSongs.CheckedState.ForeColor = System.Drawing.Color.Black;
            this.btnSongs.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSongs.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSongs.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSongs.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSongs.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.btnSongs.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSongs.ForeColor = System.Drawing.Color.White;
            this.btnSongs.Location = new System.Drawing.Point(77, 13);
            this.btnSongs.Name = "btnSongs";
            this.btnSongs.Size = new System.Drawing.Size(90, 33);
            this.btnSongs.TabIndex = 10;
            this.btnSongs.Text = "Songs";
            this.btnSongs.Click += new System.EventHandler(this.btnSongs_Click);
            // 
            // SearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.Controls.Add(this.guna2Panel1);
            this.Name = "SearchForm";
            this.Size = new System.Drawing.Size(1485, 919);
            this.Load += new System.EventHandler(this.SearchForm_Load);
            this.guna2Panel1.ResumeLayout(false);
            this.pnHeader.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Panel pnHeader;
        private Guna.UI2.WinForms.Guna2Button btnArtists;
        private Guna.UI2.WinForms.Guna2Button btnAll;
        private Guna.UI2.WinForms.Guna2Button btnSongs;
        private System.Windows.Forms.FlowLayoutPanel flpResult;
    }
}
