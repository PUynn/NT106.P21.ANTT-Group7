using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SONA
{
    public partial class Chat_User : UserControl
    {
        private string idUser;
        private string targetId;

        public event Action<string> OnChatClick;

        public Chat_User(string idUser)
        {
            InitializeComponent();
            this.idUser = idUser;

            SetupClickEvents();
        }

        private void SetupClickEvents()
        {
            this.Click += TriggerChatClick;
            guna2Button1.Click += TriggerChatClick;
            foreach (Control ctl in this.Controls)
            {
                if (ctl != guna2Button1)
                {
                    ctl.Click += TriggerChatClick;
                }
            }
            guna2Button1.Click += ShowDialog;
        }

        private void TriggerChatClick(object sender, EventArgs e)
        {
            Console.WriteLine($"[DEBUG] TriggerChatClick: targetId={targetId} tại {DateTime.Now}");
            if (!string.IsNullOrEmpty(targetId))
            {
                OnChatClick?.Invoke(targetId);
            }
            else
            {
                Console.WriteLine("[DEBUG] TriggerChatClick: targetId is null or empty.");
            }
        }

        private void ShowDialog(object sender, EventArgs e)
        {
            Console.WriteLine($"[DEBUG] ShowDialog: targetId={targetId} tại {DateTime.Now}");
            if (!string.IsNullOrEmpty(targetId))
            {
                MessageBox.Show($"Đã chọn người dùng: {name_user.Text}\nTarget ID: {targetId}", "Thông tin người dùng", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Target ID chưa được thiết lập.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void SetUser(string name, string targetId, string lastMessage = "")
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(targetId))
            {
                Console.WriteLine("[DEBUG] SetUser: Invalid name or targetId provided.");
                return;
            }

            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() =>
                {
                    UpdateUserControls(name, targetId, lastMessage);
                }));
            }
            else
            {
                UpdateUserControls(name, targetId, lastMessage);
            }
        }

        private void UpdateUserControls(string name, string targetId, string lastMessage)
        {
            try
            {
                name_user.Text = name ?? "Unknown";
                tb_lastMessage.Text = lastMessage ?? "";
                this.targetId = targetId;
                Console.WriteLine($"[DEBUG] SetUser: Updated - Name={name}, TargetId={targetId}, LastMessage={lastMessage}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[DEBUG] Error in UpdateUserControls: {ex.Message}");
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (!DesignMode)
            {
                SetupClickEvents();
            }
        }
    }
}