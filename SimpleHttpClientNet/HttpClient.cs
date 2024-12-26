using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using FXNet.Core;
using FXNet.HeaderRequest;
using FXNet.HeaderRequest.Protocols;
using FXNet.Contents;

namespace FXNet
{
   public class HttpClient:IDisposable
    {
        DNSCore _core;
        Stream _stream;
        public int Timeouts { set; get; } = 20000;
        private Stream CreateConnection(Uri uri)
        {
            if (_core.uri != null)
            {
                if ((_core.uri.Port != uri.Port) && (_core.uri.Host != uri.Host))
                {
                    return _core.Connection(uri);
                }
            }
            else
            {
                return _core.Connection(uri);
            }
            if (!_core.IsCheckConnection)
            {
                return _core.Connection(uri);
            }
            return _core.stream;

        }
        private void Write(byte[] Buffer)
        {
            _stream.Write(Buffer, 0, Buffer.Length);
        }
        private List<byte> Read()
        {
            List<byte> listBytes = new List<byte>();
            byte[] buffer = new byte[1024];
            while (_stream.Read(buffer, 0, buffer.Length) == 0)
            {
                listBytes.AddRange(buffer);
            }
            return listBytes;
        }
        public Content Get(string uri, string Version = "HTTP/1.1")
        {
           return this.Send(HttpTypeRequest.GET, uri, null, null, Version);
        }
        public Content Send(HttpTypeRequest typeRequest,string uri, Encoding encoding = null, byte[] data = null, string Version = "HTTP/1.1")
        {
            return this.Send(typeRequest.ToString(),new Uri(uri),encoding, data, Version);
        }
        public Content Send(string typeRequest,Uri uri, Encoding encoding = null, byte[] data=null,string Version= "HTTP/1.1")
        {
            if (encoding == null) encoding = Encoding.ASCII;
            List<byte> buffer = new List<byte>();
            _stream = CreateConnection(uri);
            Protocol protocol = new Protocol(typeRequest, uri.LocalPath, Version);
            HeadersRepository header = new Header();
            header.HeadersProtocol = protocol;
            header.Add("Host", uri.Host);
            var headers = (header as IHeader).GetHeaders();
            buffer.AddRange(encoding.GetBytes(headers));
            
            if (data != null) buffer.AddRange(data);
            Console.WriteLine(Encoding.ASCII.GetString(buffer.ToArray()));
            Write(buffer.ToArray());
            return new Content(_stream,encoding, Timeouts);
        }
        Content _content; 
        public void Dispose()
        {
            this._stream.Close();
            this._core.Close();
            this._core.Dispose();
            this._stream.Close();
        }

        public HttpClient()
        {
            _core = new DNSCore();
        }
    }
}
