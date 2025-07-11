namespace SONA
{
    partial class ChatBox
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
            this.tbEnterChat = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnSendMessage = new Guna.UI2.WinForms.Guna2Button();
            this.lbChatBox = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.pnLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // tbEnterChat
            // 
            this.tbEnterChat.BackColor = System.Drawing.Color.Transparent;
            this.tbEnterChat.BorderColor = System.Drawing.Color.White;
            this.tbEnterChat.BorderRadius = 10;
            this.tbEnterChat.BorderThickness = 2;
            this.tbEnterChat.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbEnterChat.DefaultText = "";
            this.tbEnterChat.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbEnterChat.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbEnterChat.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbEnterChat.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbEnterChat.FillColor = System.Drawing.Color.Gray;
            this.tbEnterChat.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbEnterChat.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tbEnterChat.ForeColor = System.Drawing.Color.White;
            this.tbEnterChat.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbEnterChat.Location = new System.Drawing.Point(13, 817);
            this.tbEnterChat.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbEnterChat.Name = "tbEnterChat";
            this.tbEnterChat.PlaceholderForeColor = System.Drawing.Color.White;
            this.tbEnterChat.PlaceholderText = "Enter chat ...";
            this.tbEnterChat.SelectedText = "";
            this.tbEnterChat.Size = new System.Drawing.Size(443, 66);
            this.tbEnterChat.TabIndex = 17;
            this.tbEnterChat.TextOffset = new System.Drawing.Point(23, 0);
            // 
            // btnSendMessage
            // 
            this.btnSendMessage.BackColor = System.Drawing.Color.Gray;
            this.btnSendMessage.BackgroundImage = global::SONA.Properties.Resources.Send;
            this.btnSendMessage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSendMessage.BorderColor = System.Drawing.Color.White;
            this.btnSendMessage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSendMessage.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSendMessage.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSendMessage.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSendMessage.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSendMessage.Enabled = false;
            this.btnSendMessage.FillColor = System.Drawing.Color.Transparent;
            this.btnSendMessage.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSendMessage.ForeColor = System.Drawing.Color.White;
            this.btnSendMessage.Location = new System.Drawing.Point(390, 827);
            this.btnSendMessage.Name = "btnSendMessage";
            this.btnSendMessage.PressedColor = System.Drawing.Color.Transparent;
            this.btnSendMessage.Size = new System.Drawing.Size(56, 44);
            this.btnSendMessage.TabIndex = 55;
            // 
            // lbChatBox
            // 
            this.lbChatBox.AutoSize = false;
            this.lbChatBox.BackColor = System.Drawing.Color.Transparent;
            this.lbChatBox.Font = new System.Drawing.Font("Segoe UI", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbChatBox.ForeColor = System.Drawing.Color.White;
            this.lbChatBox.Location = new System.Drawing.Point(185, 3);
            this.lbChatBox.Name = "lbChatBox";
            this.lbChatBox.Size = new System.Drawing.Size(136, 63);
            this.lbChatBox.TabIndex = 8;
            this.lbChatBox.Text = "Chat ";
            // 
            // pnLayout
            // 
            this.pnLayout.AutoScroll = true;
            this.pnLayout.BackColor = System.Drawing.Color.Transparent;
            this.pnLayout.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pnLayout.Location = new System.Drawing.Point(0, 103);
            this.pnLayout.Margin = new System.Windows.Forms.Padding(2);
            this.pnLayout.Name = "pnLayout";
            this.pnLayout.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.pnLayout.Size = new System.Drawing.Size(467, 654);
            this.pnLayout.TabIndex = 56;
            this.pnLayout.WrapContents = false;
            // 
            // ChatBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.Controls.Add(this.pnLayout);
            this.Controls.Add(this.lbChatBox);
            this.Controls.Add(this.btnSendMessage);
            this.Controls.Add(this.tbEnterChat);
            this.Name = "ChatBox";
            this.Size = new System.Drawing.Size(469, 887);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2TextBox tbEnterChat;
        private Guna.UI2.WinForms.Guna2Button btnSendMessage;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbChatBox;
        private System.Windows.Forms.FlowLayoutPanel pnLayout;
    }
}
