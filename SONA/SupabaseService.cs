using Supabase;
using Postgrest.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Postgrest.Attributes;
using System;
using System.Linq;

namespace SONA
{
    [Table("songswithsinger")] // Thay đổi ánh xạ sang View
    public class Song : BaseModel
    {
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

        // Thuộc tính từ singer
        [Column("name_singer")]
        public string name_singer { get; set; }

        [Column("picture_singer")]
        public string picture_singer { get; set; }

        [Column("birthdate")]
        public string birthdate { get; set; }

        [Column("nationality")]
        public string nationality { get; set; }
    }

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
        private readonly Supabase.Client _client;

        public SupabaseService()
        {
            var url = "https://lgnvhovprubrxohnhwph.supabase.co";
            var anonKey = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6ImxnbnZob3ZwcnVicnhvaG5od3BoIiwicm9sZSI6ImFub24iLCJpYXQiOjE3NDY3MTMzMDcsImV4cCI6MjA2MjI4OTMwN30.Z4EPI8SlTDuUwsXspxtfzTUTUR8Bo5JvzbdD64CuK68";
            _client = new Supabase.Client(url, anonKey);
        }

        public async Task InitializeAsync()
        {
            try
            {
                await _client.InitializeAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to initialize Supabase client: " + ex.Message);
            }
        }

        public async Task<List<Song>> GetSongsAsync()
        {
            try
            {
                var result = await _client
                    .From<Song>() // Truy vấn View songs_with_singer
                    .Get();
                var songs = result.Models;
                if (songs == null || songs.Count == 0)
                {
                    throw new Exception("No songs found in the database.");
                }

                return songs;
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching songs: " + ex.Message);
            }
        }

        public async Task<List<UserInfo>> GetUserInfosAsync()
        {
            try
            {
                var result = await _client
                    .From<UserInfo>() // Truy vấn bảng userinfo
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

        public async Task InsertUserAsync(UserInfo user)
        {
            try
            {
                await _client
                    .From<UserInfo>()
                    .Insert(user);
            }
            catch (Exception ex)
            {
                throw new Exception("Error inserting user: " + ex.Message);
            }
        }
    }
}