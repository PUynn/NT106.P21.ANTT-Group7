using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace SONA
{
    public partial class HomeContent : UserControl
    {
        Home H;
        private List<Song> songs = new List<Song>();

        public HomeContent(Home h)
        {
            InitializeComponent();
            H = h;
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

        // Chuyển đổi Song thành DataRow để tương thích với SongForm và ArtistForm
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

        // Hàm liệt kê các bài hát từ danh sách đã lấy từ Supabase
        private void btnRefreshSong_Click(object sender, EventArgs e)
        {
            int countSong = 0;
            HashSet<string> songDifferent = new HashSet<string>();
            try
            {
                flpSongs.Controls.Clear();

                if (songs == null || songs.Count == 0)
                {
                    MessageBox.Show("No songs available from Supabase.");
                    return;
                }

                // Chọn ngẫu nhiên bài hát
                var randomSongs = songs.OrderBy(x => Guid.NewGuid()).ToList();

                foreach (var song in randomSongs)
                {
                    if (countSong >= 8) break;
                    if (songDifferent.Contains(song.id_song.ToString())) continue;

                    songDifferent.Add(song.id_song.ToString());
                    countSong++;

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
                flpArtists.Controls.Clear();

                if (songs == null || songs.Count == 0)
                {
                    MessageBox.Show("No artists available from Supabase.");
                    return;
                }

                // Chọn ngẫu nhiên nghệ sĩ
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