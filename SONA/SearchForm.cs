using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SONA
{
    public partial class SearchForm : UserControl
    {
        Home H;
        private SupabaseService supabaseService;
        public SearchForm(Home h)
        {
            InitializeComponent();
            H = h;
            supabaseService = new SupabaseService();
        }

        // Hàm chuyển đổi List<Song> thành DataTable để tương thích với SongSearch
        private DataTable ConvertSongsToDataTable(List<Song> songs)
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

            foreach (var song in songs)
            {
                DataRow row = dt.NewRow();
                row["ID_SONG"] = song.id_song;
                row["PICTURE_SONG"] = song.picture_song ?? string.Empty;
                row["NAME_SONG"] = song.name_song ?? string.Empty;
                row["AM_THANH"] = song.am_thanh ?? string.Empty;
                row["ID_SINGER"] = song.id_singer;
                row["NAME_SINGER"] = song.name_singer ?? string.Empty;
                row["PICTURE_SINGER"] = song.picture_singer ?? string.Empty;
                row["THE_LOAI"] = song.the_loai ?? string.Empty;
                row["DURATION"] = song.duration;
                row["LUOT_NGHE"] = song.luot_nghe;
                row["DANH_GIA"] = song.danh_gia;
                row["VOLUME"] = song.volume;
                row["BIRTHDATE"] = song.birthdate ?? string.Empty;
                row["NATIONALITY"] = song.nationality ?? string.Empty;

                dt.Rows.Add(row);
            }

            return dt;
        }

        // Hàm in ra các bài hát tìm thấy bằng cách gọi form SongSearch và truyền vào các thông tin cần thiết
        private async void SearchForm_Load(object sender, EventArgs e)
        {
            try
            {
                // Khởi tạo SupabaseService và lấy dữ liệu từ View songs_with_singer
                await supabaseService.InitializeAsync();
                var songs = await supabaseService.GetSongsAsync();

                // Chuyển đổi List<Song> thành DataTable
                DataTable dtb = ConvertSongsToDataTable(songs);

                flpResult.Controls.Clear();
                foreach (DataRow dr in dtb.Rows)
                {
                    SongSearch songSearch = new SongSearch(H, dr);
                    flpResult.Controls.Add(songSearch);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading song data: " + ex.Message);
            }
        }
    }
}