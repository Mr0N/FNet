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
        private bool CreateTCP(string host,int port)
        {
            Close();
            try
            {
                this.Port = port;
                this._tcpClient = new TcpClient(host, port);
            }
            catch{ return false; }
            return true;
        }
        public NetworkStream Connection(string host,int port)
        {
            Console.WriteLine(host +":"+port);


            if (CreateTCP(host, port))
            {
                return _tcpClient.GetStream();
            }
            throw new Exception("Не вдалося створити зєднання");//Створити потом ошибку
        }
    }
}
