using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace FXNet.Core
{
    class DNSCore : TLS
    {
        public Uri uri { set; get; }
        public IPAddress DnsGet(string host)
        {
            IPHostEntry iPHostEntry = Dns.GetHostEntry(host);
            IPAddress iPAddress = iPHostEntry.AddressList.ElementAtOrDefault(0);
            if (iPAddress == null) throw new Exception("iPAddress == null");//Створити нове виключення
            return iPAddress;
        }
        public Stream Connection(Uri uri)
        {
            this.uri = uri;
            IPAddress ip = DnsGet(uri.Host);
            return base.Connection(ip.ToString(), uri.Port, uri.Scheme == Uri.UriSchemeHttps);
        }
        public bool IsCheckConnection { set; get; }
    }
}
