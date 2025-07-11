namespace SONA
{
    partial class Favourite
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Favourite));
            this.pnFavourite = new Guna.UI2.WinForms.Guna2Panel();
            this.flpSongs = new System.Windows.Forms.FlowLayoutPanel();
            this.pnTitle = new Guna.UI2.WinForms.Guna2Panel();
            this.lblNumber = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.pnHeader = new Guna.UI2.WinForms.Guna2Panel();
            this.btnList = new Guna.UI2.WinForms.Guna2Button();
            this.btnFilter = new Guna.UI2.WinForms.Guna2Button();
            this.btnAdd = new Guna.UI2.WinForms.Guna2Button();
            this.btnSearch = new Guna.UI2.WinForms.Guna2Button();
            this.btnLarge = new Guna.UI2.WinForms.Guna2Button();
            this.btnRecent = new Guna.UI2.WinForms.Guna2Button();
            this.txtKeyword = new Guna.UI2.WinForms.Guna2TextBox();
            this.pnFavourite.SuspendLayout();
            this.pnTitle.SuspendLayout();
            this.pnHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnFavourite
            // 
            this.pnFavourite.Controls.Add(this.flpSongs);
            this.pnFavourite.Controls.Add(this.pnTitle);
            this.pnFavourite.Controls.Add(this.pnHeader);
            this.pnFavourite.ForeColor = System.Drawing.SystemColors.ControlText;
            this.pnFavourite.Location = new System.Drawing.Point(0, 0);
            this.pnFavourite.Name = "pnFavourite";
            this.pnFavourite.Size = new System.Drawing.Size(1482, 919);
            this.pnFavourite.TabIndex = 0;
            // 
            // flpSongs
            // 
            this.flpSongs.Location = new System.Drawing.Point(3, 103);
            this.flpSongs.Name = "flpSongs";
            this.flpSongs.Size = new System.Drawing.Size(1476, 813);
            this.flpSongs.TabIndex = 2;
            // 
            // pnTitle
            // 
            this.pnTitle.Controls.Add(this.lblNumber);
            this.pnTitle.Location = new System.Drawing.Point(3, 65);
            this.pnTitle.Name = "pnTitle";
            this.pnTitle.Size = new System.Drawing.Size(1479, 35);
            this.pnTitle.TabIndex = 1;
            // 
            // lblNumber
            // 
            this.lblNumber.BackColor = System.Drawing.Color.Transparent;
            this.lblNumber.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblNumber.ForeColor = System.Drawing.Color.LightGray;
            this.lblNumber.Location = new System.Drawing.Point(52, 3);
            this.lblNumber.Name = "lblNumber";
            this.lblNumber.Size = new System.Drawing.Size(98, 27);
            this.lblNumber.TabIndex = 0;
            this.lblNumber.Text = "Name song";
            // 
            // pnHeader
            // 
            this.pnHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.pnHeader.Controls.Add(this.txtKeyword);
            this.pnHeader.Controls.Add(this.btnList);
            this.pnHeader.Controls.Add(this.btnFilter);
            this.pnHeader.Controls.Add(this.btnAdd);
            this.pnHeader.Controls.Add(this.btnSearch);
            this.pnHeader.Controls.Add(this.btnLarge);
            this.pnHeader.Controls.Add(this.btnRecent);
            this.pnHeader.Location = new System.Drawing.Point(3, 0);
            this.pnHeader.Name = "pnHeader";
            this.pnHeader.Size = new System.Drawing.Size(1476, 59);
            this.pnHeader.TabIndex = 0;
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
            this.btnList.Location = new System.Drawing.Point(1027, 6);
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
            this.btnFilter.Location = new System.Drawing.Point(1270, 6);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(145, 40);
            this.btnFilter.TabIndex = 4;
            this.btnFilter.Text = "Filter: All";
            // 
            // btnAdd
            // 
            this.btnAdd.Animated = true;
            this.btnAdd.BorderRadius = 5;
            this.btnAdd.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
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
            this.btnAdd.Location = new System.Drawing.Point(52, 6);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(40, 40);
            this.btnAdd.TabIndex = 1;
            // 
            // btnSearch
            // 
            this.btnSearch.Animated = true;
            this.btnSearch.BorderRadius = 5;
            this.btnSearch.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnSearch.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSearch.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSearch.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSearch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSearch.FillColor = System.Drawing.Color.Transparent;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSearch.Image = global::SONA.Properties.Resources.SearchOFF;
            this.btnSearch.ImageSize = new System.Drawing.Size(25, 25);
            this.btnSearch.Location = new System.Drawing.Point(1421, 6);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(40, 40);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
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
            this.btnLarge.Location = new System.Drawing.Point(1073, 6);
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
            this.btnRecent.Location = new System.Drawing.Point(1119, 6);
            this.btnRecent.Name = "btnRecent";
            this.btnRecent.Size = new System.Drawing.Size(145, 40);
            this.btnRecent.TabIndex = 3;
            this.btnRecent.Text = "Recent";
            // 
            // txtKeyword
            // 
            this.txtKeyword.BorderColor = System.Drawing.Color.Black;
            this.txtKeyword.BorderRadius = 20;
            this.txtKeyword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtKeyword.DefaultText = "";
            this.txtKeyword.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtKeyword.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtKeyword.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtKeyword.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtKeyword.FillColor = System.Drawing.Color.DarkGray;
            this.txtKeyword.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtKeyword.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtKeyword.ForeColor = System.Drawing.Color.Black;
            this.txtKeyword.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtKeyword.Location = new System.Drawing.Point(1027, 6);
            this.txtKeyword.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtKeyword.Name = "txtKeyword";
            this.txtKeyword.PlaceholderText = "";
            this.txtKeyword.SelectedText = "";
            this.txtKeyword.Size = new System.Drawing.Size(388, 42);
            this.txtKeyword.TabIndex = 6;
            this.txtKeyword.Visible = false;
            // 
            // Favourite
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.Controls.Add(this.pnFavourite);
            this.Name = "Favourite";
            this.Size = new System.Drawing.Size(1482, 919);
            this.Load += new System.EventHandler(this.Favourite_Load);
            this.pnFavourite.ResumeLayout(false);
            this.pnTitle.ResumeLayout(false);
            this.pnTitle.PerformLayout();
            this.pnHeader.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pnFavourite;
        private Guna.UI2.WinForms.Guna2Panel pnHeader;
        private Guna.UI2.WinForms.Guna2Button btnAdd;
        private Guna.UI2.WinForms.Guna2Button btnSearch;
        private Guna.UI2.WinForms.Guna2Button btnFilter;
        private Guna.UI2.WinForms.Guna2Button btnRecent;
        private Guna.UI2.WinForms.Guna2Button btnLarge;
        private Guna.UI2.WinForms.Guna2Button btnList;
        private Guna.UI2.WinForms.Guna2Panel pnTitle;
        private System.Windows.Forms.FlowLayoutPanel flpSongs;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblNumber;
        private Guna.UI2.WinForms.Guna2TextBox txtKeyword;
    }
}
