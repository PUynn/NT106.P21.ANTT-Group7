using Supabase;
using Postgrest.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Postgrest.Attributes;
using System;

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
    }
}