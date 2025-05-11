using Supabase;
using Postgrest.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Postgrest.Attributes;
using System;
using System.Linq;

namespace SONA
{
    // View songswithsinger chứa các thuộc tính của table song và table singer bằng cách kết chúng lại bằng id_singer
    [Table("songswithsinger")] // Ánh xạ class Song thành view songswithsinger trong cơ sở dữ liệu
    public class Song : BaseModel
    {
        // Các thuộc tính của table song
        [PrimaryKey("id_song")]
        public int id_song { get; set; }

        [Column("picture_song")]
        public string picture_song { get; set; }

        [Column("name_song")]
        public string name_song { get; set; }

        [Column("am_thanh")]
        public string am_thanh { get; set; }

        [Column("id_singer")]
        public int id_singer { get; set; }

        [Column("the_loai")]
        public string the_loai { get; set; }

        [Column("duration")]
        public int duration { get; set; }

        [Column("luot_nghe")]
        public int luot_nghe { get; set; }

        [Column("danh_gia")]
        public int danh_gia { get; set; }

        [Column("volume")]
        public int volume { get; set; }

        // Các thuộc tính của table singer
        [Column("name_singer")]
        public string name_singer { get; set; }

        [Column("picture_singer")]
        public string picture_singer { get; set; }

        [Column("birthdate")]
        public string birthdate { get; set; }

        [Column("nationality")]
        public string nationality { get; set; }
    }

    // View userinfo chứa các thuộc tính của table user trong cơ sở dữ liệu
    [Table("userinfo")]
    public class UserInfo : BaseModel
    {
        [PrimaryKey("id_user")]
        public int id_user { get; set; }

        [Column("name_user")]
        public string name_user { get; set; }

        [Column("picture_user")]
        public string picture_user { get; set; }

        [Column("email")]
        public string email { get; set; }

        [Column("password_tk")]
        public string password_tk { get; set; }

        [Column("create_at")]
        public string create_at { get; set; }

        [Column("sdt")]
        public string sdt { get; set; }
    }

    public class SupabaseService
    {
        private readonly Supabase.Client _client; // Đối tượng client để kết nối với Supabase

        public SupabaseService() // Khởi tạo client Supabase với URL và AnonKey
        {
            var url = "https://lgnvhovprubrxohnhwph.supabase.co";
            var anonKey = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6ImxnbnZob3ZwcnVicnhvaG5od3BoIiwicm9sZSI6ImFub24iLCJpYXQiOjE3NDY3MTMzMDcsImV4cCI6MjA2MjI4OTMwN30.Z4EPI8SlTDuUwsXspxtfzTUTUR8Bo5JvzbdD64CuK68";
            _client = new Supabase.Client(url, anonKey);
        }

        public async Task InitializeAsync() // Phương thức khởi kết nối với Supabase bất đồng bộ
        {
            try
            {
                await _client.InitializeAsync(); // Gọi phương thức Supabase để thiết lập kết nối
            }
            catch (Exception ex) // Xử lý ngoại lệ nếu có lỗi xảy ra trong quá trình khởi tạo (ví dụ API key không hợp lệ)
            {
                throw new Exception("Failed to initialize Supabase client: " + ex.Message);
            }
        }

        // Phương thức lấy danh sách bài hát từ view songswithsinger trong cơ sở dữ liệu
        public async Task<List<Song>> GetSongsAsync() 
        {
            try
            {
                var result = await _client
                    .From<Song>()
                    .Get(); // Truy vấn tất cả bản ghi từ view songswithsinger
                var songs = result.Models; // Lấy danh sách các bài hát từ kết quả truy vấn
                
                if (songs == null || songs.Count == 0) // Kiểm tra xem có bài hát không, nếu không thì ném ngoại lệ với thông báo lỗi
                {
                    throw new Exception("No songs found in the database.");
                }
                return songs;
            }
            catch (Exception ex) // Xử lý ngoại lệ nếu có lỗi xảy ra trong quá trình truy vấn
            {
                throw new Exception("Error fetching songs: " + ex.Message);
            }
        }

        // Phương thức lấy thông tin người dùng từ bảng userinfo trong cơ sở dữ liệu
        public async Task<List<UserInfo>> GetUserInfosAsync()
        {
            try
            {
                var result = await _client
                    .From<UserInfo>() // Truy vấn bảng userinfor
                    .Get();
                var userInfos = result.Models;
                if (userInfos == null || userInfos.Count == 0)
                {
                    throw new Exception("No user information found in the database.");
                }
                return userInfos;
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching user information: " + ex.Message);
            }
        }

        // Phương thức insert thông tin người dùng vào bảng userinfo trong cơ sở dữ liệu
        public async Task InsertUserAsync(UserInfo user)
        {
            try
            {
                await _client
                    .From<UserInfo>()
                    .Insert(user); // Chèn thông tin người dùng vào bảng userinfo
            }
            catch (Exception ex)
            {
                throw new Exception("Error inserting user: " + ex.Message);
            }
        }
    }
}