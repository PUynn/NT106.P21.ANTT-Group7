using Guna.UI2.WinForms;
using NAudio.Dsp;
using NAudio.Wave;
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

namespace SONA
{
    public partial class Home : UserControl
    {
        SONA S;
        private ListenMusic currentListenMusic;

        string emailUser;
        public Home(SONA s, string srcEmail)
        {
            InitializeComponent();
            S = s;
            emailUser = srcEmail;
        }
        
        private void MyClick()
        {
            pnMyLibrary.FillColor = Color.FromArgb(17, 17, 17);
            btnDiscover.Checked = false;
            btnHome.Checked = false;
            btnSearch.Checked = false;
            txtSearch.Visible = false;
            btnSearch.Visible = true;
        }

        // Hàm gọi form homeContent chứa các nội dung trong home
        private void Home_Load(object sender, EventArgs e)
        {
            if (pnMain.Controls.Count == 0 || pnMain.Controls[0].GetType() != typeof(HomeContent))
            {
                HomeContent homeContent = new HomeContent(this);
                homeContent.Dock = DockStyle.Fill;
                pnMain.Controls.Clear();
                pnMain.Controls.Add(homeContent);
            }

        }
        
        private void btnLibrary_Click(object sender, EventArgs e)
        {
            pnMyLibrary.FillColor = Color.FromArgb(17, 17, 17);
        }

        private void btnPlaylists_Click(object sender, EventArgs e)
        {
            MyClick();
        }

        private void btnFavorited_Click(object sender, EventArgs e)
        {
            MyClick();
        }

        private void btnAlbums_Click(object sender, EventArgs e)
        {
            MyClick();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            MenuClick();
            txtSearch.Visible = true;
            btnSearch.Visible = false;
            txtSearch.Focus();
        }

        private void MenuClick()
        {
            pnMyLibrary.FillColor = Color.FromArgb(39, 39, 39);
            btnAlbums.Checked = false;
            btnPlaylists.Checked = false;
            btnLibrary.Checked = false;
            btnFavorited.Checked = false;
            btnChat.Checked = false;
        }

        // Hàm quay trở lại màn hình chính khi nhấn nút home và gọi hàm StopMusicAndDispose để dừng bài hát đang phát
        private void btnHome_Click(object sender, EventArgs e)
        {
            MenuClick();
            txtSearch.Visible = false;
            btnSearch.Visible = true;

            if (currentListenMusic != null)
            {
                currentListenMusic.StopMusicAndDispose();
                currentListenMusic = null;
            }

            HomeContent home = new HomeContent(this);
            pnMain.Controls.Clear();
            pnMain.Controls.Add(home);
        }

        private void btnDiscover_Click(object sender, EventArgs e)
        {
            MenuClick();
            txtSearch.Visible = false;
            btnSearch.Visible = true;
        }

        private void btnChat_Click(object sender, EventArgs e)
        {
            MyClick();
            ChatForm chatForm = new ChatForm(emailUser);
            pnMain.Controls.Clear();
            pnMain.Controls.Add(chatForm);
        }

        private void btnArtists_Click(object sender, EventArgs e)
        {
            MyClick();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void btnMinimize_Click(object sender, EventArgs e)
        {
            S.WindowState = FormWindowState.Minimized;
        }

        // Hàm tìm kiếm bài hát khi nhấn enter vào ô tìm kiếm
        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (currentListenMusic != null)
                {
                    currentListenMusic.StopMusicAndDispose();
                    currentListenMusic = null;
                }

                string keyword = txtSearch.Text.Trim();
                if (!string.IsNullOrEmpty(keyword))
                {
                    SearchForm searchForm = new SearchForm(this, keyword);
                    pnMain.Controls.Clear();
                    pnMain.Controls.Add(searchForm);
                }
            }
        }

        private void txtSearch_Click(object sender, EventArgs e)
        {
            txtSearch.Focus();
        }

        // Hàm dừng bài hát khi nó đang phát trong form listenMusic
        public void SetCurrentListenMusic(ListenMusic listenMusic)
        {
            if (currentListenMusic != null && currentListenMusic != listenMusic)
            {
                currentListenMusic.StopMusicAndDispose();
            }
            currentListenMusic = listenMusic;
        }

    }
}