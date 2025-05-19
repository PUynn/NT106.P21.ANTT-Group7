using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace SONA
{
    public partial class HomeContent : UserControl
    {
        Home H;
        private List<Song> songs = new List<Song>(); // Danh sách bài hát được lấy từ Supabase

        public HomeContent(Home h)
        {
            InitializeComponent();
            H = h;
        }

        // Chuyển đổi Song thành DataRow để dễ dàng đẩy dữ liệu qua các form khác
        private DataRow ConvertSongToDataRow(Song song)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID_SONG", typeof(int));
            dt.Columns.Add("PICTURE_SONG", typeof(string));
            dt.Columns.Add("NAME_SONG", typeof(string));
            dt.Columns.Add("AM_THANH", typeof(string));
            dt.Columns.Add("ID_SINGER", typeof(int));
            dt.Columns.Add("NAME_SINGER", typeof(string));
            dt.Columns.Add("PICTURE_SINGER", typeof(string));
            dt.Columns.Add("THE_LOAI", typeof(string));
            dt.Columns.Add("DURATION", typeof(int));
            dt.Columns.Add("LUOT_NGHE", typeof(int));
            dt.Columns.Add("DANH_GIA", typeof(int));
            dt.Columns.Add("VOLUME", typeof(int));
            dt.Columns.Add("BIRTHDATE", typeof(string));
            dt.Columns.Add("NATIONALITY", typeof(string));

            DataRow row = dt.NewRow();
            row["ID_SONG"] = song.id_song;
            row["PICTURE_SONG"] = song.picture_song;
            row["NAME_SONG"] = song.name_song;
            row["AM_THANH"] = song.am_thanh;
            row["ID_SINGER"] = song.id_singer;
            row["NAME_SINGER"] = song.name_singer;
            row["PICTURE_SINGER"] = song.picture_singer;
            row["THE_LOAI"] = song.the_loai;
            row["DURATION"] = song.duration;
            row["LUOT_NGHE"] = song.luot_nghe;
            row["DANH_GIA"] = song.danh_gia;
            row["VOLUME"] = song.volume;
            row["BIRTHDATE"] = song.birthdate;
            row["NATIONALITY"] = song.nationality;

            return row;
        }

        // Phương thức lấy danh sách bài hát từ Server
        private void GetSongsFromServer()
        {
            try
            {
                using (TcpClient client = new TcpClient(IPAddressServer.serverIP, 5000))
                using (NetworkStream stream = client.GetStream())
                using (BinaryWriter writer = new BinaryWriter(stream))
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    writer.Write("getSongs"); // Gửi yêu cầu lấy bài hát

                    string response = reader.ReadString(); // Nhận phản hồi từ server
                    if (response == "NoSongs")
                    {
                        songs = new List<Song>(); // Không có bài hát
                        MessageBox.Show("No songs available from server.");
                    }
                    else if (response == "SongsFound")
                    {
                        songs.Clear(); // Xóa danh sách hiện tại
                        int songCount = reader.ReadInt32(); // Đọc số lượng bài hát

                        for (int i = 0; i < songCount; i++)
                        {
                            // Đọc từng bài hát từ server
                            Song song = new Song
                            {
                                id_song = int.Parse(reader.ReadString()),
                                picture_song = reader.ReadString(),
                                name_song = reader.ReadString(),
                                am_thanh = reader.ReadString(),
                                id_singer = int.Parse(reader.ReadString()),
                                name_singer = reader.ReadString(),
                                picture_singer = reader.ReadString(),
                                the_loai = reader.ReadString(),
                                duration = int.Parse(reader.ReadString()),
                                luot_nghe = int.Parse(reader.ReadString()),
                                danh_gia = int.Parse(reader.ReadString()),
                                volume = int.Parse(reader.ReadString()),
                                birthdate = reader.ReadString(),
                                nationality = reader.ReadString()
                            };
                            songs.Add(song);
                        }
                    }
                    else
                    {
                        MessageBox.Show(response); // Hiển thị lỗi từ server
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error connecting to server: " + ex.Message);
                songs = new List<Song>(); // Đảm bảo danh sách rỗng nếu có lỗi
            }
        }

        // Hàm liệt kê các danh sách bài hát và nghệ sĩ ngẫu nhiên vào trong panel tương ứng
        private async void HomeContent_Load(object sender, EventArgs e)
        {
            await connectSupabase(); // Gọi hàm lấy dữ liệu từ Supabase
            btnRefreshSong_Click(sender, e);
            btnRefreshArtist_Click(sender, e);
        }

        private async Task connectSupabase()
        {
            try
            {
                var supabase = new SupabaseService();
                await supabase.InitializeAsync();
                songs = await supabase.GetSongsAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error connecting to Supabase: " + ex.Message);
            }
        }

        // Hàm liệt kê các bài hát từ danh sách đã nhận từ server
        private void btnRefreshSong_Click(object sender, EventArgs e)
        {
            int countSong = 0;
            HashSet<string> songDifferent = new HashSet<string>();

            try
            {
                GetSongsFromServer();
                flpSongs.Controls.Clear();

                if (songs == null || songs.Count == 0) // Kiểm tra xem có bài hát nào không
                {
                    MessageBox.Show("No songs available from server.");
                    return;
                }

                var randomSongs = songs.OrderBy(x => Guid.NewGuid()).ToList(); // Chọn ngẫu nhiên bài hát từ danh sách

                foreach (var song in randomSongs)
                {
                    if (countSong >= 8) break; // Giới hạn số lượng bài hát hiển thị là 8
                    if (songDifferent.Contains(song.id_song.ToString())) continue; // Tránh trùng lặp

                    songDifferent.Add(song.id_song.ToString());
                    countSong++;

                    // Chuyển đổi bài hát thành DataRow và hiển thị trên SongForm
                    DataRow dr = ConvertSongToDataRow(song);
                    SongForm songForm = new SongForm(H, dr);
                    flpSongs.Controls.Add(songForm);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error refreshing songs: " + ex.Message);
            }
        }

        // Hàm liệt kê các nghệ sĩ từ danh sách đã lấy từ Supabase
        private void btnRefreshArtist_Click(object sender, EventArgs e)
        {
            int countArtist = 0;
            HashSet<string> artistDifferent = new HashSet<string>();

            try
            {
                GetSongsFromServer();
                flpArtists.Controls.Clear();

                if (songs == null || songs.Count == 0)
                {
                    MessageBox.Show("No artists available from server.");
                    return;
                }

                var randomSongs = songs.OrderBy(x => Guid.NewGuid()).ToList();

                foreach (var song in randomSongs)
                {
                    if (countArtist >= 8) break;
                    if (artistDifferent.Contains(song.id_singer.ToString())) continue;

                    artistDifferent.Add(song.id_singer.ToString());
                    countArtist++;

                    DataRow dr = ConvertSongToDataRow(song);
                    ArtistForm artistForm = new ArtistForm(H, dr);
                    flpArtists.Controls.Add(artistForm);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error refreshing artists: " + ex.Message);
            }
        }
    }
}