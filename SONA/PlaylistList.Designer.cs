namespace SONA
{
    partial class PlaylistList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlaylistList));
            this.flpPlaylist = new System.Windows.Forms.FlowLayoutPanel();
            this.pnPlaylistList = new Guna.UI2.WinForms.Guna2Panel();
            this.pnAddPlaylist = new Guna.UI2.WinForms.Guna2Panel();
            this.cpbPicturePlaylist = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.lblChoosePicture = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbNamePlaylist = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnCancel = new Guna.UI2.WinForms.Guna2Button();
            this.btnCreate = new Guna.UI2.WinForms.Guna2Button();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.pnHeader = new Guna.UI2.WinForms.Guna2Panel();
            this.btnAdd = new Guna.UI2.WinForms.Guna2Button();
            this.btnList = new Guna.UI2.WinForms.Guna2Button();
            this.btnFilter = new Guna.UI2.WinForms.Guna2Button();
            this.btnLarge = new Guna.UI2.WinForms.Guna2Button();
            this.btnRecent = new Guna.UI2.WinForms.Guna2Button();
            this.pnPlaylistList.SuspendLayout();
            this.pnAddPlaylist.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cpbPicturePlaylist)).BeginInit();
            this.pnHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // flpPlaylist
            // 
            this.flpPlaylist.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.flpPlaylist.Location = new System.Drawing.Point(0, 52);
            this.flpPlaylist.Name = "flpPlaylist";
            this.flpPlaylist.Size = new System.Drawing.Size(1482, 864);
            this.flpPlaylist.TabIndex = 2;
            // 
            // pnPlaylistList
            // 
            this.pnPlaylistList.Controls.Add(this.pnAddPlaylist);
            this.pnPlaylistList.Controls.Add(this.flpPlaylist);
            this.pnPlaylistList.Controls.Add(this.pnHeader);
            this.pnPlaylistList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnPlaylistList.ForeColor = System.Drawing.SystemColors.ControlText;
            this.pnPlaylistList.Location = new System.Drawing.Point(0, 0);
            this.pnPlaylistList.Name = "pnPlaylistList";
            this.pnPlaylistList.Size = new System.Drawing.Size(1482, 919);
            this.pnPlaylistList.TabIndex = 1;
            // 
            // pnAddPlaylist
            // 
            this.pnAddPlaylist.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(9)))), ((int)(((byte)(8)))));
            this.pnAddPlaylist.Controls.Add(this.cpbPicturePlaylist);
            this.pnAddPlaylist.Controls.Add(this.lblChoosePicture);
            this.pnAddPlaylist.Controls.Add(this.label2);
            this.pnAddPlaylist.Controls.Add(this.tbNamePlaylist);
            this.pnAddPlaylist.Controls.Add(this.btnCancel);
            this.pnAddPlaylist.Controls.Add(this.btnCreate);
            this.pnAddPlaylist.Controls.Add(this.btnClose);
            this.pnAddPlaylist.Location = new System.Drawing.Point(427, 140);
            this.pnAddPlaylist.Name = "pnAddPlaylist";
            this.pnAddPlaylist.Size = new System.Drawing.Size(617, 617);
            this.pnAddPlaylist.TabIndex = 7;
            this.pnAddPlaylist.Visible = false;
            // 
            // cpbPicturePlaylist
            // 
            this.cpbPicturePlaylist.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cpbPicturePlaylist.Image = global::SONA.Properties.Resources.BasePlaylist1;
            this.cpbPicturePlaylist.ImageRotate = 0F;
            this.cpbPicturePlaylist.Location = new System.Drawing.Point(162, 29);
            this.cpbPicturePlaylist.Name = "cpbPicturePlaylist";
            this.cpbPicturePlaylist.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.cpbPicturePlaylist.Size = new System.Drawing.Size(300, 300);
            this.cpbPicturePlaylist.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.cpbPicturePlaylist.TabIndex = 74;
            this.cpbPicturePlaylist.TabStop = false;
            this.cpbPicturePlaylist.Click += new System.EventHandler(this.cpbPicturePlaylist_Click);
            // 
            // lblChoosePicture
            // 
            this.lblChoosePicture.AutoSize = true;
            this.lblChoosePicture.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblChoosePicture.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Underline);
            this.lblChoosePicture.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(137)))), ((int)(((byte)(137)))));
            this.lblChoosePicture.Location = new System.Drawing.Point(158, 346);
            this.lblChoosePicture.Name = "lblChoosePicture";
            this.lblChoosePicture.Size = new System.Drawing.Size(306, 20);
            this.lblChoosePicture.TabIndex = 72;
            this.lblChoosePicture.Text = "Choose a background image for your playlist";
            this.lblChoosePicture.Click += new System.EventHandler(this.cpbPicturePlaylist_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(54, 415);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 23);
            this.label2.TabIndex = 72;
            this.label2.Text = "Name playlist:";
            // 
            // tbNamePlaylist
            // 
            this.tbNamePlaylist.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.tbNamePlaylist.BorderRadius = 12;
            this.tbNamePlaylist.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbNamePlaylist.DefaultText = "";
            this.tbNamePlaylist.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbNamePlaylist.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbNamePlaylist.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbNamePlaylist.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbNamePlaylist.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.tbNamePlaylist.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbNamePlaylist.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tbNamePlaylist.ForeColor = System.Drawing.Color.White;
            this.tbNamePlaylist.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbNamePlaylist.Location = new System.Drawing.Point(58, 447);
            this.tbNamePlaylist.Margin = new System.Windows.Forms.Padding(4);
            this.tbNamePlaylist.Name = "tbNamePlaylist";
            this.tbNamePlaylist.PlaceholderText = "";
            this.tbNamePlaylist.SelectedText = "";
            this.tbNamePlaylist.Size = new System.Drawing.Size(504, 54);
            this.tbNamePlaylist.TabIndex = 71;
            // 
            // btnCancel
            // 
            this.btnCancel.Animated = true;
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.BorderRadius = 10;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnCancel.ImageSize = new System.Drawing.Size(28, 28);
            this.btnCancel.Location = new System.Drawing.Point(417, 534);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(145, 51);
            this.btnCancel.TabIndex = 69;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnCreate
            // 
            this.btnCreate.Animated = true;
            this.btnCreate.BackColor = System.Drawing.Color.Transparent;
            this.btnCreate.BorderRadius = 8;
            this.btnCreate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCreate.FillColor = System.Drawing.Color.White;
            this.btnCreate.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnCreate.ForeColor = System.Drawing.Color.Black;
            this.btnCreate.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnCreate.ImageSize = new System.Drawing.Size(28, 28);
            this.btnCreate.Location = new System.Drawing.Point(248, 534);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(145, 51);
            this.btnCreate.TabIndex = 68;
            this.btnCreate.Text = "Create";
            this.btnCreate.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClose.BorderRadius = 15;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FillColor = System.Drawing.Color.Transparent;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.Black;
            this.btnClose.Image = global::SONA.Properties.Resources.x;
            this.btnClose.Location = new System.Drawing.Point(571, 13);
            this.btnClose.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(30, 30);
            this.btnClose.TabIndex = 65;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pnHeader
            // 
            this.pnHeader.Controls.Add(this.btnAdd);
            this.pnHeader.Controls.Add(this.btnList);
            this.pnHeader.Controls.Add(this.btnFilter);
            this.pnHeader.Controls.Add(this.btnLarge);
            this.pnHeader.Controls.Add(this.btnRecent);
            this.pnHeader.Location = new System.Drawing.Point(3, 3);
            this.pnHeader.Name = "pnHeader";
            this.pnHeader.Size = new System.Drawing.Size(1482, 46);
            this.pnHeader.TabIndex = 0;
            // 
            // btnAdd
            // 
            this.btnAdd.Animated = true;
            this.btnAdd.BorderRadius = 5;
            this.btnAdd.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAdd.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAdd.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAdd.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAdd.FillColor = System.Drawing.Color.Transparent;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnAdd.Image = global::SONA.Properties.Resources.AddSong;
            this.btnAdd.ImageSize = new System.Drawing.Size(30, 30);
            this.btnAdd.Location = new System.Drawing.Point(1412, 3);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(40, 40);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnList
            // 
            this.btnList.Animated = true;
            this.btnList.BorderRadius = 5;
            this.btnList.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnList.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnList.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnList.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnList.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnList.FillColor = System.Drawing.Color.Transparent;
            this.btnList.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnList.ForeColor = System.Drawing.Color.White;
            this.btnList.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnList.Image = global::SONA.Properties.Resources.ListOff;
            this.btnList.ImageSize = new System.Drawing.Size(40, 40);
            this.btnList.Location = new System.Drawing.Point(31, 3);
            this.btnList.Name = "btnList";
            this.btnList.Size = new System.Drawing.Size(40, 40);
            this.btnList.TabIndex = 1;
            // 
            // btnFilter
            // 
            this.btnFilter.Animated = true;
            this.btnFilter.BorderRadius = 5;
            this.btnFilter.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnFilter.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnFilter.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnFilter.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnFilter.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnFilter.FillColor = System.Drawing.Color.Transparent;
            this.btnFilter.Font = new System.Drawing.Font("Segoe UI", 10.8F);
            this.btnFilter.ForeColor = System.Drawing.Color.LightGray;
            this.btnFilter.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnFilter.Image = global::SONA.Properties.Resources.filter_all;
            this.btnFilter.ImageSize = new System.Drawing.Size(40, 40);
            this.btnFilter.Location = new System.Drawing.Point(274, 3);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(145, 40);
            this.btnFilter.TabIndex = 4;
            this.btnFilter.Text = "Filter: All";
            // 
            // btnLarge
            // 
            this.btnLarge.Animated = true;
            this.btnLarge.BorderRadius = 5;
            this.btnLarge.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnLarge.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLarge.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnLarge.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLarge.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnLarge.FillColor = System.Drawing.Color.Transparent;
            this.btnLarge.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnLarge.ForeColor = System.Drawing.Color.White;
            this.btnLarge.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnLarge.Image = ((System.Drawing.Image)(resources.GetObject("btnLarge.Image")));
            this.btnLarge.ImageSize = new System.Drawing.Size(40, 40);
            this.btnLarge.Location = new System.Drawing.Point(77, 3);
            this.btnLarge.Name = "btnLarge";
            this.btnLarge.Size = new System.Drawing.Size(40, 40);
            this.btnLarge.TabIndex = 2;
            // 
            // btnRecent
            // 
            this.btnRecent.Animated = true;
            this.btnRecent.BorderRadius = 5;
            this.btnRecent.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnRecent.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnRecent.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnRecent.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnRecent.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnRecent.FillColor = System.Drawing.Color.Transparent;
            this.btnRecent.Font = new System.Drawing.Font("Segoe UI", 10.8F);
            this.btnRecent.ForeColor = System.Drawing.Color.LightGray;
            this.btnRecent.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnRecent.Image = global::SONA.Properties.Resources.recent;
            this.btnRecent.ImageSize = new System.Drawing.Size(40, 40);
            this.btnRecent.Location = new System.Drawing.Point(123, 3);
            this.btnRecent.Name = "btnRecent";
            this.btnRecent.Size = new System.Drawing.Size(145, 40);
            this.btnRecent.TabIndex = 3;
            this.btnRecent.Text = "Recent";
            // 
            // PlaylistList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.Controls.Add(this.pnPlaylistList);
            this.Name = "PlaylistList";
            this.Size = new System.Drawing.Size(1482, 919);
            this.pnPlaylistList.ResumeLayout(false);
            this.pnAddPlaylist.ResumeLayout(false);
            this.pnAddPlaylist.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cpbPicturePlaylist)).EndInit();
            this.pnHeader.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpPlaylist;
        private Guna.UI2.WinForms.Guna2Panel pnPlaylistList;
        private Guna.UI2.WinForms.Guna2Panel pnHeader;
        private Guna.UI2.WinForms.Guna2Button btnList;
        private Guna.UI2.WinForms.Guna2Button btnFilter;
        private Guna.UI2.WinForms.Guna2Button btnAdd;
        private Guna.UI2.WinForms.Guna2Button btnLarge;
        private Guna.UI2.WinForms.Guna2Button btnRecent;
        public Guna.UI2.WinForms.Guna2Panel pnAddPlaylist;
        private Guna.UI2.WinForms.Guna2Button btnCancel;
        private Guna.UI2.WinForms.Guna2Button btnCreate;
        private Guna.UI2.WinForms.Guna2Button btnClose;
        private Guna.UI2.WinForms.Guna2TextBox tbNamePlaylist;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblChoosePicture;
        private Guna.UI2.WinForms.Guna2CirclePictureBox cpbPicturePlaylist;
    }
}
