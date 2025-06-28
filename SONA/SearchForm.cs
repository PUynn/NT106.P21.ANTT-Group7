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
using System.Threading;

namespace SONA
{
    public partial class SearchForm : UserControl
    {
        private Home h;
        private string idUser;
        private List<string> songIds = new List<string>();
        private List<string> artistIds = new List<string>();
        private string currentSearchTerm = "";
        private System.Windows.Forms.Timer searchTimer;
        private ListBox suggestionListBox;

        public SearchForm(Home h, string idUser)
        {
            InitializeComponent();
            this.h = h;
            this.idUser = idUser;
            
            // Khởi tạo timer cho tìm kiếm real-time
            searchTimer = new System.Windows.Forms.Timer();
            searchTimer.Interval = 500; // 500ms delay
            searchTimer.Tick += SearchTimer_Tick;
            
            // Khởi tạo listbox gợi ý
            InitializeSuggestionListBox();
        }

        private void InitializeSuggestionListBox()
        {
            suggestionListBox = new ListBox();
            suggestionListBox.Visible = false;
            suggestionListBox.Font = new Font("Segoe UI", 10);
            suggestionListBox.BackColor = Color.FromArgb(39, 39, 39);
            suggestionListBox.ForeColor = Color.White;
            suggestionListBox.BorderStyle = BorderStyle.None;
            suggestionListBox.SelectedIndexChanged += SuggestionListBox_SelectedIndexChanged;
            
            // Thêm vào panel header
            pnHeader.Controls.Add(suggestionListBox);
            suggestionListBox.BringToFront();
        }

        private void SuggestionListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (suggestionListBox.SelectedItem != null)
            {
                string selectedItem = suggestionListBox.SelectedItem.ToString();
                // Lấy tên từ gợi ý (loại bỏ phần type)
                string name = selectedItem.Split('(')[0].Trim();
                
                // Thực hiện tìm kiếm với tên đã chọn
                PerformSearch(name);
                suggestionListBox.Visible = false;
            }
        }

        private void SearchTimer_Tick(object sender, EventArgs e)
        {
            searchTimer.Stop();
            if (!string.IsNullOrWhiteSpace(currentSearchTerm))
            {
                GetSearchSuggestions(currentSearchTerm);
            }
        }

        private void GetSearchSuggestions(string searchTerm)
        {
            try
            {
                using (TcpClient client = new TcpClient(IPAddressServer.serverIP, 5000))
                using (NetworkStream stream = client.GetStream())
                using (BinaryWriter writer = new BinaryWriter(stream))
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    writer.Write("getSearchSuggestions");
                    writer.Write(searchTerm);
                    string response = reader.ReadString();

                    if (response == "OK")
                    {
                        int suggestionCount = reader.ReadInt32();
                        suggestionListBox.Items.Clear();
                        
                        for (int i = 0; i < suggestionCount; i++)
                        {
                            string suggestion = reader.ReadString();
                            suggestionListBox.Items.Add(suggestion);
                        }

                        if (suggestionCount > 0)
                        {
                            suggestionListBox.Visible = true;
                            suggestionListBox.Size = new Size(300, Math.Min(suggestionCount * 25 + 10, 200));
                            suggestionListBox.Location = new Point(16, 50);
                        }
                        else
                        {
                            suggestionListBox.Visible = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Không hiển thị lỗi cho gợi ý tìm kiếm
                suggestionListBox.Visible = false;
            }
        }

        private void PerformSearch(string searchTerm)
        {
            currentSearchTerm = searchTerm;
            songIds.Clear();
            artistIds.Clear();
            
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                // Hiển thị tất cả nếu không có từ khóa
                getIDSong();
                getIDSinger();
            }
            else
            {
                // Tìm kiếm theo từ khóa
                SearchSongs(searchTerm);
                SearchArtists(searchTerm);
            }
        }

        private void SearchSongs(string searchTerm)
        {
            try
            {
                flpResult.Controls.Clear();
                Title title = new Title("Songs:");
                flpResult.Controls.Add(title);

                using (TcpClient client = new TcpClient(IPAddressServer.serverIP, 5000))
                using (NetworkStream stream = client.GetStream())
                using (BinaryWriter writer = new BinaryWriter(stream))
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    writer.Write("searchSongs");
                    writer.Write(searchTerm);
                    string response = reader.ReadString();

                    if (response == "OK")
                    {
                        int songCount = reader.ReadInt32();
                        for (int i = 0; i < songCount; i++)
                        {
                            string id_song = reader.ReadString();
                            songIds.Add(id_song);
                        }
                        foreach (var songId in songIds)
                        {
                            SongSearch songSearch = new SongSearch(h, songId, idUser, songIds);
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

        private void SearchArtists(string searchTerm)
        {
            try
            {
                Title title = new Title("Singers:");
                flpResult.Controls.Add(title);

                using (TcpClient client = new TcpClient(IPAddressServer.serverIP, 5000))
                using (NetworkStream stream = client.GetStream())
                using (BinaryWriter writer = new BinaryWriter(stream))
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    writer.Write("searchArtists");
                    writer.Write(searchTerm);
                    string response = reader.ReadString();
                    if (response == "OK")
                    {
                        int singerCount = reader.ReadInt32();
                        for (int i = 0; i < singerCount; i++)
                        {
                            string id_singer = reader.ReadString();
                            artistIds.Add(id_singer);
                            ArtistForm artistForm = new ArtistForm(h, id_singer, idUser);
                            flpResult.Controls.Add(artistForm);
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

        // Thêm method để nhận từ khóa tìm kiếm từ Home form
        public void SetSearchTerm(string searchTerm)
        {
            PerformSearch(searchTerm);
        }


        private void txtSearchBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                searchTimer.Stop();
                suggestionListBox.Visible = false;
       
            }
            else if (e.KeyCode == Keys.Escape)
            {
                suggestionListBox.Visible = false;
            }
        }

        private void getIDSong()
        {
            try
            {
                flpResult.Controls.Clear();
                Title title = new Title("Songs:");
                flpResult.Controls.Add(title);

                using (TcpClient client = new TcpClient(IPAddressServer.serverIP, 5000))
                using (NetworkStream stream = client.GetStream())
                using (BinaryWriter writer = new BinaryWriter(stream))
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    writer.Write("getIDSong");
                    string response = reader.ReadString();

                    if (response == "OK")
                    {
                        int songCount = reader.ReadInt32();
                        for (int i = 0; i < songCount; i++)
                        {
                            string id_song = reader.ReadString();
                            songIds.Add(id_song);
                        }
                        foreach (var songId in songIds)
                        {
                            SongSearch songSearch = new SongSearch(h, songId, idUser, songIds);
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

        private void getIDSinger()
        {
            try
            {
                Title title = new Title("Singers:");
                flpResult.Controls.Add(title);

                using (TcpClient client = new TcpClient(IPAddressServer.serverIP, 5000))
                using (NetworkStream stream = client.GetStream())
                using (BinaryWriter writer = new BinaryWriter(stream))
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    writer.Write("getIDSinger");
                    string response = reader.ReadString();
                    if (response == "OK")
                    {
                        int singerCount = reader.ReadInt32();
                        for (int i = 0; i < singerCount; i++)
                        {
                            string id_singer = reader.ReadString();
                            artistIds.Add(id_singer);
                            ArtistForm artistForm = new ArtistForm(h, id_singer, idUser);
                            flpResult.Controls.Add(artistForm);
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

        private void SearchForm_Load(object sender, EventArgs e)
        {
            getIDSong();
            getIDSinger();
        }

        private void btnSongs_Click(object sender, EventArgs e)
        {
            Title title = new Title("Songs:");

            flpResult.Controls.Clear();
            flpResult.Controls.Add(title);
            
            foreach (var songId in songIds)
            {
                SongSearch songSearch = new SongSearch(h, songId, idUser, songIds);
                flpResult.Controls.Add(songSearch);
            }
        }

        private void btnArtists_Click(object sender, EventArgs e)
        {
            Title title = new Title("Singers:");

            flpResult.Controls.Clear();
            flpResult.Controls.Add(title);

            foreach (var artistId in artistIds)
            {
                ArtistForm artistForm = new ArtistForm(h, artistId, idUser);
                flpResult.Controls.Add(artistForm);
            }
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            Title title = new Title("Songs:");

            flpResult.Controls.Clear();
            flpResult.Controls.Add(title);

            foreach (var songId in songIds)
            {
                SongSearch songSearch = new SongSearch(h, songId, idUser, songIds);
                flpResult.Controls.Add(songSearch);
            }

            title = new Title("Singers:");
            flpResult.Controls.Add(title);

            foreach (var artistId in artistIds)
            {
                ArtistForm artistForm = new ArtistForm(h, artistId, idUser);
                flpResult.Controls.Add(artistForm);

            }
        }

        
    }
}