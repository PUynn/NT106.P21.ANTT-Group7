namespace SONA
{
    partial class MusicRoom
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
            this.txtJoinRoom = new Guna.UI2.WinForms.Guna2TextBox();
            this.buttonJoin = new Guna.UI2.WinForms.Guna2Button();
            this.buttonCreate = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.lbMusicRoom = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtJoinRoom
            // 
            this.txtJoinRoom.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.txtJoinRoom.BorderRadius = 25;
            this.txtJoinRoom.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtJoinRoom.DefaultText = "";
            this.txtJoinRoom.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtJoinRoom.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtJoinRoom.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtJoinRoom.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtJoinRoom.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.txtJoinRoom.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtJoinRoom.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.txtJoinRoom.ForeColor = System.Drawing.Color.White;
            this.txtJoinRoom.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtJoinRoom.IconLeftOffset = new System.Drawing.Point(10, 0);
            this.txtJoinRoom.IconLeftSize = new System.Drawing.Size(26, 26);
            this.txtJoinRoom.Location = new System.Drawing.Point(101, 157);
            this.txtJoinRoom.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.txtJoinRoom.Name = "txtJoinRoom";
            this.txtJoinRoom.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(137)))), ((int)(((byte)(137)))));
            this.txtJoinRoom.PlaceholderText = "Nhập Room ID để tham gia ";
            this.txtJoinRoom.SelectedText = "";
            this.txtJoinRoom.Size = new System.Drawing.Size(667, 75);
            this.txtJoinRoom.TabIndex = 1;
            this.txtJoinRoom.TextChanged += new System.EventHandler(this.txtJoinRoom_TextChanged);
            // 
            // buttonJoin
            // 
            this.buttonJoin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.buttonJoin.BorderRadius = 15;
            this.buttonJoin.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.buttonJoin.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.buttonJoin.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.buttonJoin.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.buttonJoin.FillColor = System.Drawing.Color.DarkGray;
            this.buttonJoin.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.buttonJoin.ForeColor = System.Drawing.Color.White;
            this.buttonJoin.Location = new System.Drawing.Point(572, 167);
            this.buttonJoin.Name = "buttonJoin";
            this.buttonJoin.Size = new System.Drawing.Size(178, 49);
            this.buttonJoin.TabIndex = 2;
            this.buttonJoin.Text = "Tham gia";
            // 
            // buttonCreate
            // 
            this.buttonCreate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.buttonCreate.BorderRadius = 15;
            this.buttonCreate.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.buttonCreate.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.buttonCreate.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.buttonCreate.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.buttonCreate.FillColor = System.Drawing.Color.DarkGray;
            this.buttonCreate.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.buttonCreate.ForeColor = System.Drawing.Color.White;
            this.buttonCreate.Location = new System.Drawing.Point(307, 291);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(254, 57);
            this.buttonCreate.TabIndex = 3;
            this.buttonCreate.Text = "Tạo phòng mới";
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Controls.Add(this.lbMusicRoom);
            this.guna2Panel1.Controls.Add(this.buttonCreate);
            this.guna2Panel1.Controls.Add(this.buttonJoin);
            this.guna2Panel1.Controls.Add(this.txtJoinRoom);
            this.guna2Panel1.Location = new System.Drawing.Point(212, 140);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(871, 369);
            this.guna2Panel1.TabIndex = 4;
            // 
            // lbMusicRoom
            // 
            this.lbMusicRoom.AutoSize = false;
            this.lbMusicRoom.BackColor = System.Drawing.Color.Transparent;
            this.lbMusicRoom.Font = new System.Drawing.Font("Segoe UI", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMusicRoom.ForeColor = System.Drawing.Color.White;
            this.lbMusicRoom.Location = new System.Drawing.Point(317, 3);
            this.lbMusicRoom.Name = "lbMusicRoom";
            this.lbMusicRoom.Size = new System.Drawing.Size(291, 91);
            this.lbMusicRoom.TabIndex = 6;
            this.lbMusicRoom.Text = "Music Room";
            this.lbMusicRoom.Click += new System.EventHandler(this.lbMusicRoom_Click);
            // 
            // MusicRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.Controls.Add(this.guna2Panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "MusicRoom";
            this.Size = new System.Drawing.Size(1304, 781);
            this.Load += new System.EventHandler(this.MusicRoom_Load);
            this.guna2Panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2TextBox txtJoinRoom;
        private Guna.UI2.WinForms.Guna2Button buttonJoin;
        private Guna.UI2.WinForms.Guna2Button buttonCreate;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbMusicRoom;
    }
}
