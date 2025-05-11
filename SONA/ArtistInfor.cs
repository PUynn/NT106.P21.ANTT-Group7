using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.IO;

namespace SONA
{
    public partial class ArtistInfor : UserControl
    {
        Home H;
        DataRow src;
        private SupabaseService supabaseService;

        public ArtistInfor(Home h, DataRow dr)
        {
            InitializeComponent();
            src = dr;
            H = h;
            supabaseService = new SupabaseService();
        }

        private string ConvertDate(string date)
        {
            try
            {
                DateTime parsedDate = DateTime.Parse(date);
                string month = parsedDate.ToString("MMMM");
                int day = parsedDate.Day;
                int year = parsedDate.Year;
                return $"Since {month} {day}, {year}";
            }
            catch (FormatException)
            {
                return "Invalid date format";
            }
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

        private async void ArtistInfor_Load(object sender, EventArgs e)
        {
            try
            {
                // Khởi tạo SupabaseService và lấy dữ liệu từ View songswithsinger
                await supabaseService.InitializeAsync();
                var allSongs = await supabaseService.GetSongsAsync();

                // Lọc bài hát theo ID_SINGER từ src
                int singerId = Convert.ToInt32(src["ID_SINGER"]);
                var artistSongs = allSongs
                    .Where(s => s.id_singer == singerId)
                    .ToList();

                // Chuyển đổi List<Song> thành DataTable và hiển thị
                DataTable dtb = ConvertSongsToDataTable(artistSongs);
                flpSongs.Controls.Clear();
                foreach (DataRow dr in dtb.Rows)
                {
                    SongSearch songSearch = new SongSearch(H, dr);
                    flpSongs.Controls.Add(songSearch);
                }

                // Tải hình ảnh từ URL
                string pictureUrl = src["PICTURE_SINGER"]?.ToString();
                if (!string.IsNullOrEmpty(pictureUrl))
                {
                    using (var client = new HttpClient())
                    {
                        var imageData = await client.GetByteArrayAsync(pictureUrl);
                        if (imageData != null && imageData.Length > 0)
                        {
                            using (var ms = new MemoryStream(imageData))
                            {
                                btnAvatar.BackgroundImage = Image.FromStream(ms);
                            }
                        }
                        else
                        {
                            btnAvatar.BackgroundImage = null;
                        }
                    }
                }
                else
                {
                    btnAvatar.BackgroundImage = null;
                }

                btnAvatar.BackgroundImageLayout = ImageLayout.Stretch;
                lblNameSinger.Text = src["NAME_SINGER"]?.ToString() ?? "Unknown Artist";
                lblDate.Text = ConvertDate(src["BIRTHDATE"]?.ToString() ?? string.Empty);
                lblCountry.Text = src["NATIONALITY"]?.ToString() ?? "Unknown Nationality";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading artist information: " + ex.Message);
                btnAvatar.BackgroundImage = null;
            }
        }
    }
}