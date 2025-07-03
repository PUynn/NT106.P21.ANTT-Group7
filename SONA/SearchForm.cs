using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net.Sockets;

namespace SONA
{
    public partial class SearchForm : UserControl
    {
        Home H;
        private string id_song, idUser;
        private string keyword;

        public SearchForm(Home h, string idUser, string keyword)
        {
            InitializeComponent();
            H = h;
            this.idUser = idUser;
            this.keyword = keyword;
        }

        // Hàm in ra các bài hát tìm thấy bằng cách gọi form SongSearch và truyền vào các thông tin cần thiết
        private void SearchForm_Load(object sender, EventArgs e)
        {
            try
            {
                flpResult.Controls.Clear();

                using (TcpClient client = new TcpClient(IPAddressServer.serverIP, 5000))
                using (NetworkStream stream = client.GetStream())
                using (BinaryWriter writer = new BinaryWriter(stream))
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    writer.Write("songSearch"); // server cần xử lý lệnh này
                    writer.Write(keyword); // gửi từ khóa tìm kiếm

                    string response = reader.ReadString(); // OK hoặc lỗi

                    if (response == "OK")
                    {
                        int songCount = reader.ReadInt32();
                        for (int i = 0; i < songCount; i++)
                        {
                            string id_song = reader.ReadString();
                            SongSearch songSearch = new SongSearch(H, id_song, idUser);
                            flpResult.Controls.Add(songSearch);
                        }
                    }
                    else
                    {
                        MessageBox.Show(response);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error connecting to server: " + ex.Message);
            }
        }
    }
}