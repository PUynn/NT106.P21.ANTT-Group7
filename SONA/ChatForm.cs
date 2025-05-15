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

namespace SONA
{
    public partial class ChatForm: UserControl
    {
        string emailUser;
        DataRow dr;
        public ChatForm(string srcEmail)
        {
            InitializeComponent();
            emailUser = srcEmail;
        }

        private DataRow ConvertToDataRow(UserInfo userInfo)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID_USER", typeof(int));
            dt.Columns.Add("NAME_USER", typeof(string));
            dt.Columns.Add("PICTURE_USER", typeof(string));
            dt.Columns.Add("EMAIL", typeof(string));
            dt.Columns.Add("PASSWORD_TK", typeof(string));
            dt.Columns.Add("CREATE_AT", typeof(string));
            dt.Columns.Add("SDT", typeof(string));

            DataRow row = dt.NewRow();
            row["ID_USER"] = userInfo.id_user;
            row["NAME_USER"] = userInfo.name_user;
            row["PICTURE_USER"] = userInfo.picture_user;
            row["EMAIL"] = userInfo.email;
            row["PASSWORD_TK"] = userInfo.password_tk;
            row["CREATE_AT"] = userInfo.create_at;
            row["SDT"] = userInfo.sdt;

            return row;
        }

        private void ChatForm_Load(object sender, EventArgs e)
        {
            try
            {
                using (TcpClient client = new TcpClient(IPAddressServer.serverIP, 5000))
                using (NetworkStream stream = client.GetStream())
                using (BinaryWriter writer = new BinaryWriter(stream))
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    writer.Write("userInfo");
                    writer.Write(emailUser);
                    
                    string response = reader.ReadString();            

                    if (response == "OK")
                    {
                        int idUser = reader.ReadInt32();
                        string nameUser = reader.ReadString();
                        string password = reader.ReadString();
                        string createAt = reader.ReadString();
                        string sdt = reader.ReadString();

                        UserInfo userInfo = new UserInfo
                        {
                            id_user = idUser,
                            name_user = nameUser,
                            picture_user = "",
                            email = emailUser,
                            password_tk = password,
                            create_at = createAt,
                            sdt = sdt
                        };

                        dr = ConvertToDataRow(userInfo);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối tới Server: " + ex.Message);
            }
            ChatRoom chatRoom = new ChatRoom(dr);
            pnChatRoom.Controls.Clear();
            pnChatRoom.Controls.Add(chatRoom);
        }
    }
}
