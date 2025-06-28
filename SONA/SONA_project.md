# SƠ ĐỒ TỔNG QUAN PROJECT SONA

## 📋 TỔNG QUAN DỰ ÁN

**Tên dự án:** SONA - Ứng dụng âm nhạc trực tuyến  
**Môn học:** Lập trình mạng căn bản - NT106.P21.ANTT  
**Giảng viên:** Trần Hồng Nghi  
**Nhóm:** Group 7

### Thành viên nhóm:
- Lê Phương Uyên (MSSV: 23521761)
- Trần Nguyễn Việt Hoàng (MSSV: 23520541)  
- Nguyễn Đình Tri (MSSV: 23521642)

---

## 🏗️ KIẾN TRÚC TỔNG THỂ

```
┌─────────────────────────────────────────────────────────────────┐
│                        SONA PROJECT                             │
├─────────────────────────────────────────────────────────────────┤
│                                                                 │
│  ┌─────────────────┐              ┌─────────────────┐          │
│  │   SONA CLIENT   │              │  SONA SERVER    │          │
│  │   (WinForms)    │◄────────────►│   (WinForms)    │          │
│  │                 │   TCP/IP     │                 │          │
│  │                 │   Port 5000  │                 │          │
│  └─────────────────┘              └─────────────────┘          │
│           │                                │                   │
│           │                                │                   │
│           ▼                                ▼                   │
│  ┌─────────────────┐              ┌─────────────────┐          │
│  │   SUPABASE      │              │   SUPABASE      │          │
│  │   DATABASE      │              │   DATABASE      │          │
│  │   (PostgreSQL)  │              │   (PostgreSQL)  │          │
│  └─────────────────┘              └─────────────────┘          │
│                                                                 │
└─────────────────────────────────────────────────────────────────┘
```

---

## 📁 CẤU TRÚC THƯ MỤC

```
SONA/
├── SONA/                          # Client Application
│   ├── Program.cs                 # Entry point
│   ├── Sona.cs                    # Main form
│   ├── Home.cs                    # Main home interface
│   ├── HomeContent.cs             # Home content display
│   ├── Login.cs                   # Login form
│   ├── SignUp.cs                  # Registration form
│   ├── ForgetPassword.cs          # Password recovery
│   ├── ListenMusic.cs             # Music player
│   ├── MusicBar.cs                # Music control bar
│   ├── Playlist.cs                # Playlist management
│   ├── ListAlbum.cs               # Album listing
│   ├── Favourite.cs               # Favorites management
│   ├── ChatForm.cs                # Chat interface
│   ├── ChatRoom.cs                # Chat room
│   ├── SongSearch.cs              # Song search
│   ├── ArtistForm.cs              # Artist information
│   ├── AlbumForm.cs               # Album display
│   ├── SongForm.cs                # Song display
│   ├── HistoryForm.cs             # Listening history
│   ├── SearchForm.cs              # Search interface
│   ├── SignUpInfor.cs             # User registration info
│   ├── ArtistInfor.cs             # Artist details
│   ├── Album.cs                   # Album details
│   ├── PlaylistForm.cs            # Playlist item
│   └── Resources/                 # Images, icons, etc.
│
├── SONA-Server/                   # Server Application
│   ├── Program.cs                 # Server entry point
│   ├── ServerForm.cs              # Server main interface
│   ├── SupabaseService.cs         # Database service
│   ├── ClientInfor.cs             # Client information model
│   └── Resources/                 # Server resources
│
├── packages/                      # NuGet packages
├── SONA.sln                       # Solution file
├── README.md                      # Project documentation
└── Logo Sona.png                  # Project logo
```

---

## 🔧 CÔNG NGHỆ SỬ DỤNG

### Frontend (Client)
- **Framework:** .NET Framework 4.7.2
- **UI Library:** Guna.UI2.WinForms
- **Audio Library:** NAudio
- **Database:** Npgsql (PostgreSQL connector)

### Backend (Server)
- **Framework:** .NET Framework 4.7.2
- **Network:** TCP/IP Socket Programming
- **Database:** Supabase (PostgreSQL)
- **Authentication:** Google OAuth, Facebook OAuth
- **Email:** SMTP for OTP verification

### Database
- **Platform:** Supabase (PostgreSQL)
- **Connection:** SSL/TLS encrypted
- **Location:** AWS Asia Pacific (Singapore)

---

## 🔄 LUỒNG HOẠT ĐỘNG CHÍNH

### 1. Khởi động ứng dụng
```
Client Start → Get Server IP from Database → Connect to Server
```

### 2. Đăng nhập/Đăng ký
```
Login Form → Server Authentication → Database Verification → Home Interface
```

### 3. Phát nhạc
```
Select Song → Request from Server → Download/Stream → NAudio Player
```

### 4. Chat real-time
```
Chat Form → TCP Connection → Server Relay → Other Clients
```

---

## 🎵 TÍNH NĂNG CHÍNH

### Client Features
- ✅ **Authentication:** Login/Register with email, Google, Facebook
- ✅ **Music Player:** Play, pause, skip, volume control
- ✅ **Playlist Management:** Create, edit, delete playlists
- ✅ **Album Management:** Browse and manage albums
- ✅ **Favorites:** Add/remove favorite songs
- ✅ **Search:** Search songs, artists, albums
- ✅ **Real-time Chat:** Chat with other users
- ✅ **History:** Track listening history
- ✅ **User Profile:** Manage user information

### Server Features
- ✅ **TCP Server:** Handle multiple client connections
- ✅ **Database Management:** CRUD operations with Supabase
- ✅ **Authentication Service:** User verification and OTP
- ✅ **File Management:** Music file storage and retrieval
- ✅ **Real-time Communication:** Message relay between clients
- ✅ **Notification System:** Push notifications for users

---

## 🗄️ CƠ SỞ DỮ LIỆU

### Supabase Tables (PostgreSQL)
- **Users:** Thông tin người dùng
- **Songs:** Thông tin bài hát
- **Albums:** Thông tin album
- **Artists:** Thông tin nghệ sĩ
- **Playlists:** Danh sách phát
- **Favorites:** Bài hát yêu thích
- **History:** Lịch sử nghe nhạc
- **Chat:** Tin nhắn chat
- **IP:** Địa chỉ IP server

---

## 🌐 KẾT NỐI MẠNG

### TCP/IP Communication
- **Port:** 5000
- **Protocol:** TCP
- **Data Format:** Binary (BinaryReader/BinaryWriter)
- **Commands:** Custom protocol for different operations

### Database Connection
- **Host:** aws-0-ap-southeast-1.pooler.supabase.com
- **Port:** 5432
- **SSL:** Required
- **Authentication:** Username/Password

---

## 📱 GIAO DIỆN NGƯỜI DÙNG

### Design Theme
- **Color Scheme:** Dark theme (Spotify-inspired)
- **UI Framework:** Guna.UI2.WinForms
- **Layout:** Modern, responsive design
- **Icons:** Custom icons and resources

### Main Sections
1. **Login/Register:** Authentication interface
2. **Home:** Main dashboard with recommendations
3. **Library:** Personal music collection
4. **Search:** Find music and artists
5. **Chat:** Real-time messaging
6. **Player:** Music playback controls

---

## 🔒 BẢO MẬT

### Authentication
- Email/Password authentication
- Google OAuth integration
- Facebook OAuth integration
- OTP verification for password reset

### Data Protection
- SSL/TLS encryption for database
- Secure password hashing
- Session management
- Input validation

---

## 🚀 DEPLOYMENT

### Requirements
- Windows OS
- .NET Framework 4.7.2
- Internet connection
- Supabase account

### Installation
1. Clone repository
2. Restore NuGet packages
3. Configure database connection
4. Build and run

---

## 📊 METRICS

### Performance
- **Concurrent Users:** Multiple TCP connections
- **Audio Quality:** High-quality audio playback
- **Response Time:** Real-time communication
- **Scalability:** Cloud-based database

### Features Coverage
- **Core Music Features:** 100%
- **Social Features:** 80%
- **User Management:** 90%
- **Real-time Communication:** 85%

---

*Sơ đồ này mô tả tổng quan về kiến trúc và chức năng của project SONA - một ứng dụng âm nhạc hoàn chỉnh với khả năng phát nhạc, quản lý playlist, chat real-time và tích hợp với cơ sở dữ liệu cloud.*