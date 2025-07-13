namespace SONA
{
    partial class Chat_User
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
            this.tb_lastMessage = new Guna.UI2.WinForms.Guna2TextBox();
            this.name_user = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.SystemColors.Info;
            this.guna2Panel1.BorderRadius = 15;
            this.guna2Panel1.Controls.Add(this.tb_lastMessage);
            this.guna2Panel1.Controls.Add(this.name_user);
            this.guna2Panel1.Controls.Add(this.guna2Button1);
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(393, 45);
            this.guna2Panel1.TabIndex = 0;
            // 
            // tb_lastMessage
            // 
            this.tb_lastMessage.BorderRadius = 20;
            this.tb_lastMessage.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tb_lastMessage.DefaultText = "";
            this.tb_lastMessage.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tb_lastMessage.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tb_lastMessage.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tb_lastMessage.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tb_lastMessage.FillColor = System.Drawing.Color.DarkGray;
            this.tb_lastMessage.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tb_lastMessage.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tb_lastMessage.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tb_lastMessage.Location = new System.Drawing.Point(220, -2);
            this.tb_lastMessage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tb_lastMessage.Name = "tb_lastMessage";
            this.tb_lastMessage.PlaceholderText = "";
            this.tb_lastMessage.ReadOnly = true;
            this.tb_lastMessage.SelectedText = "";
            this.tb_lastMessage.Size = new System.Drawing.Size(170, 48);
            this.tb_lastMessage.TabIndex = 1;
            // 
            // name_user
            // 
            this.name_user.BackColor = System.Drawing.Color.Transparent;
            this.name_user.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.name_user.Location = new System.Drawing.Point(10, 12);
            this.name_user.Name = "name_user";
            this.name_user.Size = new System.Drawing.Size(16, 22);
            this.name_user.TabIndex = 0;
            this.name_user.Text = "A";
            // 
            // guna2Button1
            // 
            this.guna2Button1.BorderRadius = 15;
            this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button1.FillColor = System.Drawing.Color.Transparent;
            this.guna2Button1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button1.ForeColor = System.Drawing.Color.White;
            this.guna2Button1.Location = new System.Drawing.Point(0, 0);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(393, 45);
            this.guna2Button1.TabIndex = 2;
            // 
            // Chat_User
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.guna2Panel1);
            this.Name = "Chat_User";
            this.Size = new System.Drawing.Size(393, 45);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel name_user;
        private Guna.UI2.WinForms.Guna2TextBox tb_lastMessage;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
    }
}
