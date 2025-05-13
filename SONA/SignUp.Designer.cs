namespace SONA
{
    partial class SignUp
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
            this.components = new System.ComponentModel.Container();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2CircleButton1 = new Guna.UI2.WinForms.Guna2CircleButton();
            this.lbDangnhap = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.guna2Elipse2 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.guna2Elipse3 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.guna2Separator2 = new Guna.UI2.WinForms.Guna2Separator();
            this.lblEmail = new System.Windows.Forms.Label();
            this.tbOTP = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.btnSignUp = new Guna.UI2.WinForms.Guna2Button();
            this.btnNext = new Guna.UI2.WinForms.Guna2Button();
            this.btnRefreshOTP = new Guna.UI2.WinForms.Guna2Button();
            this.btnSignUpGoogle = new Guna.UI2.WinForms.Guna2Button();
            this.btnSignUpFb = new Guna.UI2.WinForms.Guna2Button();
            this.tbEmail = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblCheck = new System.Windows.Forms.Label();
            this.lblOTP = new System.Windows.Forms.Label();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Panel2.SuspendLayout();
            this.guna2Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel2.Controls.Add(this.guna2CircleButton1);
            this.guna2Panel2.Controls.Add(this.lbDangnhap);
            this.guna2Panel2.Controls.Add(this.label2);
            this.guna2Panel2.Controls.Add(this.label1);
            this.guna2Panel2.Location = new System.Drawing.Point(92, 27);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.Size = new System.Drawing.Size(341, 169);
            this.guna2Panel2.TabIndex = 0;
            // 
            // guna2CircleButton1
            // 
            this.guna2CircleButton1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2CircleButton1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2CircleButton1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2CircleButton1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2CircleButton1.FillColor = System.Drawing.Color.Black;
            this.guna2CircleButton1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2CircleButton1.ForeColor = System.Drawing.Color.White;
            this.guna2CircleButton1.Image = global::SONA.Properties.Resources.SONA2Logo;
            this.guna2CircleButton1.ImageSize = new System.Drawing.Size(40, 40);
            this.guna2CircleButton1.Location = new System.Drawing.Point(142, 3);
            this.guna2CircleButton1.Name = "guna2CircleButton1";
            this.guna2CircleButton1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CircleButton1.Size = new System.Drawing.Size(60, 60);
            this.guna2CircleButton1.TabIndex = 20;
            // 
            // lbDangnhap
            // 
            this.lbDangnhap.AutoSize = true;
            this.lbDangnhap.BackColor = System.Drawing.Color.Transparent;
            this.lbDangnhap.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbDangnhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDangnhap.Location = new System.Drawing.Point(220, 114);
            this.lbDangnhap.Name = "lbDangnhap";
            this.lbDangnhap.Size = new System.Drawing.Size(108, 25);
            this.lbDangnhap.TabIndex = 3;
            this.lbDangnhap.Text = "Đăng nhập";
            this.lbDangnhap.Click += new System.EventHandler(this.lbDangnhap_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(26, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(301, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Bạn đã có tài khoản ? Đăng nhập";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.label1.Location = new System.Drawing.Point(89, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 48);
            this.label1.TabIndex = 1;
            this.label1.Text = "Đăng kí";
            // 
            // guna2Elipse2
            // 
            this.guna2Elipse2.BorderRadius = 100;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label4.ForeColor = System.Drawing.Color.Gray;
            this.label4.Location = new System.Drawing.Point(229, 525);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 29);
            this.label4.TabIndex = 4;
            this.label4.Text = "Hoặc";
            // 
            // guna2Separator2
            // 
            this.guna2Separator2.FillThickness = 2;
            this.guna2Separator2.Location = new System.Drawing.Point(323, 534);
            this.guna2Separator2.Name = "guna2Separator2";
            this.guna2Separator2.Size = new System.Drawing.Size(213, 10);
            this.guna2Separator2.TabIndex = 3;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.lblEmail.Location = new System.Drawing.Point(3, 207);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(96, 20);
            this.lblEmail.TabIndex = 0;
            this.lblEmail.Text = "Địa chỉ email";
            // 
            // tbOTP
            // 
            this.tbOTP.BorderRadius = 12;
            this.tbOTP.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbOTP.DefaultText = "";
            this.tbOTP.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbOTP.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbOTP.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbOTP.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbOTP.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbOTP.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tbOTP.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbOTP.Location = new System.Drawing.Point(0, 328);
            this.tbOTP.Margin = new System.Windows.Forms.Padding(4);
            this.tbOTP.Name = "tbOTP";
            this.tbOTP.PlaceholderText = "";
            this.tbOTP.SelectedText = "";
            this.tbOTP.Size = new System.Drawing.Size(528, 58);
            this.tbOTP.TabIndex = 1;
            this.tbOTP.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbOTP_KeyDown);
            // 
            // guna2Separator1
            // 
            this.guna2Separator1.FillThickness = 2;
            this.guna2Separator1.Location = new System.Drawing.Point(-2, 534);
            this.guna2Separator1.Name = "guna2Separator1";
            this.guna2Separator1.Size = new System.Drawing.Size(213, 10);
            this.guna2Separator1.TabIndex = 2;
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel1.Controls.Add(this.btnSignUp);
            this.guna2Panel1.Controls.Add(this.btnNext);
            this.guna2Panel1.Controls.Add(this.btnRefreshOTP);
            this.guna2Panel1.Controls.Add(this.guna2Panel2);
            this.guna2Panel1.Controls.Add(this.btnSignUpGoogle);
            this.guna2Panel1.Controls.Add(this.btnSignUpFb);
            this.guna2Panel1.Controls.Add(this.label4);
            this.guna2Panel1.Controls.Add(this.guna2Separator2);
            this.guna2Panel1.Controls.Add(this.guna2Separator1);
            this.guna2Panel1.Controls.Add(this.tbEmail);
            this.guna2Panel1.Controls.Add(this.tbOTP);
            this.guna2Panel1.Controls.Add(this.lblCheck);
            this.guna2Panel1.Controls.Add(this.lblOTP);
            this.guna2Panel1.Controls.Add(this.lblEmail);
            this.guna2Panel1.ForeColor = System.Drawing.Color.DarkGray;
            this.guna2Panel1.Location = new System.Drawing.Point(88, 33);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(528, 779);
            this.guna2Panel1.TabIndex = 0;
            // 
            // btnSignUp
            // 
            this.btnSignUp.Animated = true;
            this.btnSignUp.BackColor = System.Drawing.Color.Transparent;
            this.btnSignUp.BorderRadius = 33;
            this.btnSignUp.FillColor = System.Drawing.Color.DarkGray;
            this.btnSignUp.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSignUp.ForeColor = System.Drawing.Color.White;
            this.btnSignUp.HoverState.FillColor = System.Drawing.Color.LightBlue;
            this.btnSignUp.ImageSize = new System.Drawing.Size(28, 28);
            this.btnSignUp.Location = new System.Drawing.Point(0, 432);
            this.btnSignUp.Name = "btnSignUp";
            this.btnSignUp.Size = new System.Drawing.Size(528, 64);
            this.btnSignUp.TabIndex = 22;
            this.btnSignUp.Text = "Đăng kí";
            this.btnSignUp.Click += new System.EventHandler(this.btnSignUp_Click);
            // 
            // btnNext
            // 
            this.btnNext.BorderRadius = 17;
            this.btnNext.CheckedState.Image = global::SONA.Properties.Resources.Refresh;
            this.btnNext.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNext.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnNext.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnNext.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnNext.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnNext.FillColor = System.Drawing.Color.Transparent;
            this.btnNext.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnNext.ForeColor = System.Drawing.Color.Transparent;
            this.btnNext.Image = global::SONA.Properties.Resources.Right;
            this.btnNext.ImageSize = new System.Drawing.Size(50, 50);
            this.btnNext.Location = new System.Drawing.Point(490, 245);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(35, 35);
            this.btnNext.TabIndex = 8;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnRefreshOTP
            // 
            this.btnRefreshOTP.BorderRadius = 17;
            this.btnRefreshOTP.CheckedState.Image = global::SONA.Properties.Resources.Refresh;
            this.btnRefreshOTP.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefreshOTP.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnRefreshOTP.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnRefreshOTP.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnRefreshOTP.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnRefreshOTP.FillColor = System.Drawing.Color.Transparent;
            this.btnRefreshOTP.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnRefreshOTP.ForeColor = System.Drawing.Color.Transparent;
            this.btnRefreshOTP.Image = global::SONA.Properties.Resources.Refresh;
            this.btnRefreshOTP.ImageSize = new System.Drawing.Size(25, 25);
            this.btnRefreshOTP.Location = new System.Drawing.Point(490, 339);
            this.btnRefreshOTP.Name = "btnRefreshOTP";
            this.btnRefreshOTP.Size = new System.Drawing.Size(35, 35);
            this.btnRefreshOTP.TabIndex = 8;
            this.btnRefreshOTP.Click += new System.EventHandler(this.btnRefreshOTP_Click);
            // 
            // btnSignUpGoogle
            // 
            this.btnSignUpGoogle.Animated = true;
            this.btnSignUpGoogle.BorderRadius = 35;
            this.btnSignUpGoogle.BorderThickness = 1;
            this.btnSignUpGoogle.FillColor = System.Drawing.Color.Transparent;
            this.btnSignUpGoogle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSignUpGoogle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnSignUpGoogle.Image = global::SONA.Properties.Resources.Google;
            this.btnSignUpGoogle.ImageOffset = new System.Drawing.Point(0, -1);
            this.btnSignUpGoogle.ImageSize = new System.Drawing.Size(30, 30);
            this.btnSignUpGoogle.Location = new System.Drawing.Point(0, 582);
            this.btnSignUpGoogle.Name = "btnSignUpGoogle";
            this.btnSignUpGoogle.Size = new System.Drawing.Size(528, 72);
            this.btnSignUpGoogle.TabIndex = 7;
            this.btnSignUpGoogle.Text = "Đăng kí bằng Google";
            this.btnSignUpGoogle.Click += new System.EventHandler(this.btnSignUpGoogle_Click);
            // 
            // btnSignUpFb
            // 
            this.btnSignUpFb.Animated = true;
            this.btnSignUpFb.BorderRadius = 35;
            this.btnSignUpFb.BorderThickness = 1;
            this.btnSignUpFb.CheckedState.BorderColor = System.Drawing.Color.Transparent;
            this.btnSignUpFb.CheckedState.CustomBorderColor = System.Drawing.Color.Transparent;
            this.btnSignUpFb.FillColor = System.Drawing.Color.Transparent;
            this.btnSignUpFb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSignUpFb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnSignUpFb.Image = global::SONA.Properties.Resources.icons8_facebook_50;
            this.btnSignUpFb.ImageOffset = new System.Drawing.Point(0, -1);
            this.btnSignUpFb.ImageSize = new System.Drawing.Size(30, 30);
            this.btnSignUpFb.Location = new System.Drawing.Point(0, 672);
            this.btnSignUpFb.Name = "btnSignUpFb";
            this.btnSignUpFb.Size = new System.Drawing.Size(528, 72);
            this.btnSignUpFb.TabIndex = 6;
            this.btnSignUpFb.Text = "Đăng kí bằng Facebook";
            // 
            // tbEmail
            // 
            this.tbEmail.BorderRadius = 12;
            this.tbEmail.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbEmail.DefaultText = "";
            this.tbEmail.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbEmail.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbEmail.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbEmail.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbEmail.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbEmail.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tbEmail.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbEmail.Location = new System.Drawing.Point(0, 231);
            this.tbEmail.Margin = new System.Windows.Forms.Padding(4);
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.PlaceholderText = "";
            this.tbEmail.SelectedText = "";
            this.tbEmail.Size = new System.Drawing.Size(528, 58);
            this.tbEmail.TabIndex = 1;
            this.tbEmail.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbEmail_KeyDown);
            // 
            // lblCheck
            // 
            this.lblCheck.AutoSize = true;
            this.lblCheck.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCheck.ForeColor = System.Drawing.Color.Red;
            this.lblCheck.Location = new System.Drawing.Point(3, 390);
            this.lblCheck.Name = "lblCheck";
            this.lblCheck.Size = new System.Drawing.Size(250, 20);
            this.lblCheck.TabIndex = 0;
            this.lblCheck.Text = "Vui lòng nhập địa chỉ Email của bạn!\r\n";
            // 
            // lblOTP
            // 
            this.lblOTP.AutoSize = true;
            this.lblOTP.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOTP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.lblOTP.Location = new System.Drawing.Point(3, 304);
            this.lblOTP.Name = "lblOTP";
            this.lblOTP.Size = new System.Drawing.Size(60, 20);
            this.lblOTP.TabIndex = 0;
            this.lblOTP.Text = "Mã OTP";
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 24;
            this.guna2Elipse1.TargetControl = this;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.BackgroundImage = global::SONA.Properties.Resources.x;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClose.FillColor = System.Drawing.Color.Transparent;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.Black;
            this.btnClose.Location = new System.Drawing.Point(641, 33);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(20, 20);
            this.btnClose.TabIndex = 8;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // SignUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.guna2Panel1);
            this.Name = "SignUp";
            this.Size = new System.Drawing.Size(704, 853);
            this.Load += new System.EventHandler(this.SignUp_Load);
            this.guna2Panel2.ResumeLayout(false);
            this.guna2Panel2.PerformLayout();
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse3;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Button btnSignUpGoogle;
        private Guna.UI2.WinForms.Guna2Button btnSignUpFb;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator2;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator1;
        private Guna.UI2.WinForms.Guna2TextBox tbOTP;
        private System.Windows.Forms.Label lblEmail;
        private Guna.UI2.WinForms.Guna2Button btnClose;
        private System.Windows.Forms.Label lbDangnhap;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2CircleButton guna2CircleButton1;
        private Guna.UI2.WinForms.Guna2Button btnRefreshOTP;
        private System.Windows.Forms.Label lblCheck;
        private Guna.UI2.WinForms.Guna2TextBox tbEmail;
        private System.Windows.Forms.Label lblOTP;
        private Guna.UI2.WinForms.Guna2Button btnNext;
        private Guna.UI2.WinForms.Guna2Button btnSignUp;
    }
}
