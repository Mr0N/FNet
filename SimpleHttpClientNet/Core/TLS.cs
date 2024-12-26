using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace FXNet.Core
{
    class TLS : CoreTCP
    {
        public Stream stream { set; get; }
        public Stream Connection(string host, int port, bool isCheckTLS)
        {
            NetworkStream network =  base.Connection(host, port);
            if (!isCheckTLS)
            {
                this.stream = network;
                return this.stream;
            }
            this.stream = Start(network, host);
            return this.stream;
        }
        public SslStream Start(NetworkStream stream, string host)
        {
            SslStream sslStream = new SslStream(stream, false, ValidateServerCertificate, null);
            sslStream.AuthenticateAsClient(host);
            byte[] messsage = Encoding.UTF8.GetBytes("Hello from the client.<EOF>");
            sslStream.Write(messsage);
            sslStream.Flush();
            return sslStream;
        }
        public static bool ValidateServerCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }
    }
}
