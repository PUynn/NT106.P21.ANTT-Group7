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
            this.flpSongFavourites = new System.Windows.Forms.FlowLayoutPanel();
            this.pnHeader = new Guna.UI2.WinForms.Guna2Panel();
            this.btnSearch = new Guna.UI2.WinForms.Guna2Button();
            this.btnList = new Guna.UI2.WinForms.Guna2Button();
            this.btnFilter = new Guna.UI2.WinForms.Guna2Button();
            this.btnLarge = new Guna.UI2.WinForms.Guna2Button();
            this.btnRecent = new Guna.UI2.WinForms.Guna2Button();
            this.txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.pnFavourite.SuspendLayout();
            this.pnHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnFavourite
            // 
            this.pnFavourite.Controls.Add(this.pnHeader);
            this.pnFavourite.Controls.Add(this.flpSongFavourites);
            this.pnFavourite.ForeColor = System.Drawing.SystemColors.ControlText;
            this.pnFavourite.Location = new System.Drawing.Point(0, 0);
            this.pnFavourite.Name = "pnFavourite";
            this.pnFavourite.Size = new System.Drawing.Size(1482, 919);
            this.pnFavourite.TabIndex = 0;
            // 
            // flpSongFavourites
            // 
            this.flpSongFavourites.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.flpSongFavourites.Location = new System.Drawing.Point(3, 73);
            this.flpSongFavourites.Name = "flpSongFavourites";
            this.flpSongFavourites.Size = new System.Drawing.Size(1476, 843);
            this.flpSongFavourites.TabIndex = 2;
            // 
            // pnHeader
            // 
            this.pnHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.pnHeader.Controls.Add(this.txtSearch);
            this.pnHeader.Controls.Add(this.btnSearch);
            this.pnHeader.Controls.Add(this.btnList);
            this.pnHeader.Controls.Add(this.btnFilter);
            this.pnHeader.Controls.Add(this.btnLarge);
            this.pnHeader.Controls.Add(this.btnRecent);
            this.pnHeader.Location = new System.Drawing.Point(3, 0);
            this.pnHeader.Name = "pnHeader";
            this.pnHeader.Size = new System.Drawing.Size(1479, 51);
            this.pnHeader.TabIndex = 1;
            // 
            // btnSearch
            // 
            this.btnSearch.Animated = true;
            this.btnSearch.BorderRadius = 5;
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSearch.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSearch.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSearch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSearch.FillColor = System.Drawing.Color.Transparent;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSearch.Image = global::SONA.Properties.Resources.SearchOFF;
            this.btnSearch.ImageSize = new System.Drawing.Size(30, 30);
            this.btnSearch.Location = new System.Drawing.Point(1412, 3);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(40, 40);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnList
            // 
            this.btnList.Animated = true;
            this.btnList.BorderRadius = 5;
            this.btnList.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnList.Checked = true;
            this.btnList.CheckedState.Image = global::SONA.Properties.Resources.ListOn;
            this.btnList.Cursor = System.Windows.Forms.Cursors.Hand;
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
            this.btnList.Location = new System.Drawing.Point(3, 3);
            this.btnList.Name = "btnList";
            this.btnList.Size = new System.Drawing.Size(40, 40);
            this.btnList.TabIndex = 1;
            // 
            // btnFilter
            // 
            this.btnFilter.Animated = true;
            this.btnFilter.BorderRadius = 5;
            this.btnFilter.Cursor = System.Windows.Forms.Cursors.Hand;
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
            this.btnFilter.Location = new System.Drawing.Point(246, 3);
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
            this.btnLarge.CheckedState.Image = global::SONA.Properties.Resources.GridOn;
            this.btnLarge.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLarge.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLarge.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnLarge.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLarge.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnLarge.FillColor = System.Drawing.Color.Transparent;
            this.btnLarge.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnLarge.ForeColor = System.Drawing.Color.White;
            this.btnLarge.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnLarge.Image = global::SONA.Properties.Resources.GridOff;
            this.btnLarge.ImageSize = new System.Drawing.Size(40, 40);
            this.btnLarge.Location = new System.Drawing.Point(49, 3);
            this.btnLarge.Name = "btnLarge";
            this.btnLarge.Size = new System.Drawing.Size(40, 40);
            this.btnLarge.TabIndex = 2;
            // 
            // btnRecent
            // 
            this.btnRecent.Animated = true;
            this.btnRecent.BorderRadius = 5;
            this.btnRecent.Cursor = System.Windows.Forms.Cursors.Hand;
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
            this.btnRecent.Location = new System.Drawing.Point(95, 3);
            this.btnRecent.Name = "btnRecent";
            this.btnRecent.Size = new System.Drawing.Size(145, 40);
            this.btnRecent.TabIndex = 3;
            this.btnRecent.Text = "Recent";
            // 
            // txtSearch
            // 
            this.txtSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtSearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtSearch.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.txtSearch.BorderRadius = 16;
            this.txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearch.DefaultText = "";
            this.txtSearch.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtSearch.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtSearch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearch.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearch.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.txtSearch.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSearch.ForeColor = System.Drawing.Color.White;
            this.txtSearch.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSearch.IconLeft = ((System.Drawing.Image)(resources.GetObject("txtSearch.IconLeft")));
            this.txtSearch.IconLeftOffset = new System.Drawing.Point(10, 0);
            this.txtSearch.IconLeftSize = new System.Drawing.Size(26, 26);
            this.txtSearch.Location = new System.Drawing.Point(940, 5);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(137)))), ((int)(((byte)(137)))));
            this.txtSearch.PlaceholderText = "Search";
            this.txtSearch.SelectedText = "";
            this.txtSearch.Size = new System.Drawing.Size(512, 38);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.Visible = false;
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // Favourite
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.Controls.Add(this.pnFavourite);
            this.Name = "Favourite";
            this.Size = new System.Drawing.Size(1482, 919);
            this.pnFavourite.ResumeLayout(false);
            this.pnHeader.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pnFavourite;
        private System.Windows.Forms.FlowLayoutPanel flpSongFavourites;
        private Guna.UI2.WinForms.Guna2Panel pnHeader;
        private Guna.UI2.WinForms.Guna2Button btnSearch;
        private Guna.UI2.WinForms.Guna2Button btnList;
        private Guna.UI2.WinForms.Guna2Button btnFilter;
        private Guna.UI2.WinForms.Guna2Button btnLarge;
        private Guna.UI2.WinForms.Guna2Button btnRecent;
        private Guna.UI2.WinForms.Guna2TextBox txtSearch;
    }
}
