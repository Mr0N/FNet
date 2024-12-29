using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace FXNet.Core
{
    class CoreTCP : IDisposable
    {
        TcpClient _tcpClient;
        public void Dispose()
        {
            this.Close();
            _tcpClient.Dispose();
        }
        public int Port { private set; get; }
        public void Close()
        {
            if (_tcpClient != null) _tcpClient.Close();
        }
        private void CreateTCP(string host, int port)
        {
            Close();
            this.Port = port;
            this._tcpClient = new TcpClient(host, port);

        }
        public NetworkStream Connection(string host, int port)
        {
            Console.WriteLine(host + ":" + port);


            CreateTCP(host, port);
            return _tcpClient.GetStream();
        }
    }
}
