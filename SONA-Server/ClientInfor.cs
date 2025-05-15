using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SONA_Server
{
    class ClientInfor
    {
        public string Username { get; set; }
        public string IPAddress { get; set; }
        public TcpClient TcpClient { get; set; }

        public ClientInfor(string username, string ipAddress, TcpClient tcpClient)
        {
            Username = username;
            IPAddress = ipAddress;
            TcpClient = tcpClient;
        }

        // Ghi đè ToString để dễ hiển thị trong ListBox
        public override string ToString()
        {
            return $"{Username} ({IPAddress})";
        }
    }
}
