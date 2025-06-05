namespace SONA_Server
{
    partial class ServerForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServerForm));
            this.btnStart = new Guna.UI2.WinForms.Guna2Button();
            this.btnStop = new Guna.UI2.WinForms.Guna2Button();
            this.btnNone = new Guna.UI2.WinForms.Guna2Button();
            this.btnMinimize = new Guna.UI2.WinForms.Guna2Button();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.lvManageMess = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.BorderRadius = 25;
            this.btnStart.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            resources.ApplyResources(this.btnStart, "btnStart");
            this.btnStart.ForeColor = System.Drawing.Color.White;
            this.btnStart.Name = "btnStart";
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.BorderRadius = 25;
            this.btnStop.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            resources.ApplyResources(this.btnStop, "btnStop");
            this.btnStop.ForeColor = System.Drawing.Color.White;
            this.btnStop.Name = "btnStop";
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnNone
            // 
            this.btnNone.BorderRadius = 25;
            this.btnNone.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            resources.ApplyResources(this.btnNone, "btnNone");
            this.btnNone.ForeColor = System.Drawing.Color.White;
            this.btnNone.Name = "btnNone";
            this.btnNone.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnMinimize
            // 
            this.btnMinimize.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.btnMinimize, "btnMinimize");
            this.btnMinimize.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnMinimize.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnMinimize.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnMinimize.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnMinimize.FillColor = System.Drawing.Color.Transparent;
            this.btnMinimize.ForeColor = System.Drawing.Color.Transparent;
            this.btnMinimize.Image = global::SONA_Server.Properties.Resources.Minimize;
            this.btnMinimize.ImageOffset = new System.Drawing.Point(0, -2);
            this.btnMinimize.ImageSize = new System.Drawing.Size(25, 25);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.btnClose, "btnClose");
            this.btnClose.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnClose.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnClose.FillColor = System.Drawing.Color.Transparent;
            this.btnClose.ForeColor = System.Drawing.Color.Transparent;
            this.btnClose.Image = global::SONA_Server.Properties.Resources.Close;
            this.btnClose.ImageOffset = new System.Drawing.Point(0, -3);
            this.btnClose.ImageSize = new System.Drawing.Size(50, 50);
            this.btnClose.Name = "btnClose";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lvManageMess
            // 
            this.lvManageMess.HideSelection = false;
            resources.ApplyResources(this.lvManageMess, "lvManageMess");
            this.lvManageMess.Name = "lvManageMess";
            this.lvManageMess.UseCompatibleStateImageBehavior = false;
            this.lvManageMess.View = System.Windows.Forms.View.Details;
            // 
            // ServerForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lvManageMess);
            this.Controls.Add(this.btnMinimize);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnNone);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ServerForm";
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Button btnStart;
        private Guna.UI2.WinForms.Guna2Button btnStop;
        private Guna.UI2.WinForms.Guna2Button btnNone;
        private Guna.UI2.WinForms.Guna2Button btnClose;
        private Guna.UI2.WinForms.Guna2Button btnMinimize;
        private System.Windows.Forms.ListView lvManageMess;
    }
}

