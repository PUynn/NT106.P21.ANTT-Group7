using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SONA
{
    public partial class Chat_List : UserControl
    {
        private string idUser;
        public event Action<string> OnUserSelected;

        public Chat_List(string idUser)
        {
            InitializeComponent();
            this.idUser = idUser ?? throw new ArgumentNullException(nameof(idUser));
            _ = LoadRecentChatsAsync();
        }

        private async Task LoadRecentChatsAsync()
        {
            await UpdateUI(() => fl_ListUser.Controls.Clear());
            Console.WriteLine($"[Client] Bắt đầu tải danh sách trò chuyện cho idUser={idUser} tại {DateTime.Now}");

            try
            {
                var result = await FetchDataFromServerAsync("getRecentChats", idUser);
                if (result.Success && result.Data != null)
                {
                    await ProcessUserDataAsync(result.Data);
                }
                else if (!string.IsNullOrEmpty(result.ErrorMessage))
                {
                    await ShowErrorMessage(result.ErrorMessage);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Client] Lỗi khi tải danh sách trò chuyện: {ex.Message} tại {DateTime.Now}");
                await ShowErrorMessage($"⚠ Lỗi khi tải danh sách trò chuyện: {ex.Message}");
            }
        }

        private async void tb_search_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                string keyword = tb_search.Text?.Trim() ?? string.Empty;

                await UpdateUI(() => fl_ListUser.Controls.Clear());
                if (!string.IsNullOrEmpty(keyword))
                    await LoadSearchResultsAsync(keyword);
                else
                    await LoadRecentChatsAsync();
            }
        }

        private async Task LoadSearchResultsAsync(string keyword)
        {
            await UpdateUI(() => fl_ListUser.Controls.Clear());
            Console.WriteLine($"[Client] Bắt đầu tìm kiếm với keyword={keyword} cho idUser={idUser} tại {DateTime.Now}");

            try
            {
                var result = await FetchDataFromServerAsync("searchUsers", idUser, keyword);
                if (result.Success && result.Data != null)
                {
                    await ProcessUserDataAsync(result.Data);
                }
                else if (!string.IsNullOrEmpty(result.ErrorMessage))
                {
                    await ShowErrorMessage(result.ErrorMessage);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Client] Lỗi khi tìm kiếm người dùng: {ex.Message} tại {DateTime.Now}");
                await ShowErrorMessage($"⚠ Lỗi khi tìm kiếm người dùng: {ex.Message}");
            }
        }

        private async Task<(bool Success, List<(string TargetId, string Name)> Data, string ErrorMessage)> FetchDataFromServerAsync(string requestType, string idUser, string keyword = null)
        {
            using (var cts = new CancellationTokenSource(10000))
            using (var client = new TcpClient())
            {
                Console.WriteLine($"[Client] Bắt đầu gửi yêu cầu {requestType} với idUser={idUser}, keyword={keyword} tại {DateTime.Now}");
                Console.WriteLine($"[Client] Thử kết nối đến {IPAddressServer.serverIP}:5000 tại {DateTime.Now}");

                try
                {
                    client.ReceiveTimeout = 10000;
                    client.SendTimeout = 10000;

                    var connectTask = client.ConnectAsync(IPAddressServer.serverIP, 5000);
                    if (await Task.WhenAny(connectTask, Task.Delay(10000, cts.Token)) != connectTask)
                    {
                        cts.Cancel();
                        Console.WriteLine($"[Client] Timeout: Không thể kết nối đến {IPAddressServer.serverIP}:5000 sau 10 giây tại {DateTime.Now}");
                        return (false, null, "Kết nối với server timeout sau 10 giây.");
                    }

                    Console.WriteLine($"[Client] Kết nối thành công đến {IPAddressServer.serverIP}:5000 tại {DateTime.Now}");
                    await connectTask;

                    using (var stream = client.GetStream())
                    {
                        Console.WriteLine($"[Client] Mở stream thành công tại {DateTime.Now}");
                        using (var writer = new BinaryWriter(stream))
                        using (var reader = new BinaryReader(stream))
                        {
                            Console.WriteLine($"[Client] Gửi requestType={requestType} tại {DateTime.Now}");
                            writer.Write(requestType);
                            if (requestType == "searchUsers" && !string.IsNullOrEmpty(keyword))
                            {
                                Console.WriteLine($"[Client] Gửi keyword={keyword} tại {DateTime.Now}");
                                writer.Write(keyword);
                            }
                            Console.WriteLine($"[Client] Gửi idUser={idUser} tại {DateTime.Now}");
                            writer.Write(idUser);

                            Console.WriteLine($"[Client] Đang chờ phản hồi từ server tại {DateTime.Now}");
                            string response = reader.ReadString();
                            Console.WriteLine($"[Client] Nhận phản hồi từ server: {response} tại {DateTime.Now}");
                            if (response == "OK")
                            {
                                int count = reader.ReadInt32();
                                Console.WriteLine($"[Client] Nhận count={count} từ server tại {DateTime.Now}");
                                var users = new List<(string, string)>();
                                for (int i = 0; i < count; i++)
                                {
                                    string data = reader.ReadString() ?? string.Empty;
                                    Console.WriteLine($"[Client] Nhận dữ liệu dòng {i}: {data} tại {DateTime.Now}");
                                    string[] parts = data.Split('|');
                                    if (parts.Length >= 2)
                                    {
                                        users.Add((parts[0], parts[1]));
                                    }
                                }
                                return (true, users, null);
                            }
                            return (false, null, $"Server không phản hồi đúng: {response}");
                        }
                    }
                }
                catch (SocketException ex)
                {
                    Console.WriteLine($"[Client] Lỗi Socket: {ex.Message} - StackTrace: {ex.StackTrace} tại {DateTime.Now}");
                    return (false, null, $"Lỗi kết nối: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[Client] Lỗi không xác định: {ex.Message} - StackTrace: {ex.StackTrace} tại {DateTime.Now}");
                    return (false, null, ex.Message);
                }
            }
        }

        private async Task ProcessUserDataAsync(List<(string TargetId, string Name)> users)
        {
            if (users == null || !users.Any())
            {
                await ShowErrorMessage("🔍 Không tìm thấy cuộc trò chuyện nào gần đây.");
                return;
            }

            var userControls = users.Select(u =>
            {
                var userControl = new Chat_User(idUser)
                {
                    Dock = DockStyle.Top
                };
                userControl.SetUser(u.Name, u.TargetId);
                userControl.OnChatClick += async (selectedId) =>
                {
                    Console.WriteLine($"[Client] OnChatClick triggered with targetId={selectedId} tại {DateTime.Now}");
                    OnUserSelected?.Invoke(selectedId);
                };
                return userControl;
            }).ToList();

            await UpdateUI(() =>
            {
                fl_ListUser.Controls.Clear();
                foreach (var userControl in userControls)
                {
                    fl_ListUser.Controls.Add(userControl);
                }
            });
        }

        private async Task UpdateUI(Action action)
        {
            if (this.IsDisposed) return;

            if (this.InvokeRequired)
            {
                await Task.Run(() => this.Invoke((MethodInvoker)(() => action())));
            }
            else
            {
                action();
            }
        }

        private async Task ShowErrorMessage(string message)
        {
            if (this.IsDisposed) return;

            if (this.InvokeRequired)
            {
                await Task.Run(() => this.Invoke((MethodInvoker)(() => MessageBox.Show(message))));
            }
            else
            {
                MessageBox.Show(message);
            }
        }
    }
}