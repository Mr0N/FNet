using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using FXNet.Core;
using FXNet.HeaderRequest.Protocols;
using FXNet.Contents;
using SimpleHttpClientNet.Headers.Request;
using SimpleHttpClientNet.Logging;

namespace FXNet
{
    public class HttpSimpleClient : IDisposable
    {
        DNSCore _core;
        Stream _stream;
        public int Timeouts { set; get; } = 20000;
        private Stream CreateConnection(Uri uri)
        {
            Log.Write($"Create connection to:{uri}");
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
        private void Write(MemoryStream memory)
        {
            _stream.Write(memory.ToArray());
        }
        //private List<byte> Read()
        //{
        //    List<byte> listBytes = new List<byte>();
        //    byte[] buffer = new byte[1024];
        //    while (_stream.Read(buffer, 0, buffer.Length) == 0)
        //    {
        //        listBytes.AddRange(buffer);
        //    }
        //    return listBytes;
        //}
        public Content Get(string uri, string Version = "HTTP/1.1")
        {
            return this.Send(HttpTypeRequest.GET, uri, null, null, Version);
        }
        public Content Send(HttpTypeRequest typeRequest, string uri, Encoding encoding = null, byte[] data = null, string Version = "HTTP/1.1")
        {
            return this.Send(typeRequest.ToString(), new Uri(uri), encoding, data, Version);
        }
        public Content Send(string typeRequest, Uri uri, Encoding encoding = null, byte[] data = null, string Version = "HTTP/1.1")
        {
            Log.Write($"Type Request:{typeRequest}" +
                $"Uri:{uri}" +
                $"Version http:{Version}");
            if (encoding == null) encoding = Encoding.ASCII;
            //  List<byte> buffer = new List<byte>();
            using var buffer = new MemoryStream();
            _stream = CreateConnection(uri);
            Protocol protocol = new Protocol(typeRequest, uri.LocalPath, Version);
            HeadersRepository header = new Header();
            header.HeadersProtocol = protocol;
            header.Add("Host", uri.Host);
            var headers = (header as IHeader).GetHeaders();
            buffer.Write(encoding.GetBytes(headers));

            if (data != null) buffer.Write(data);
            Write(buffer);
            return new Content(_stream);
        }
        Content _content;
        public void Dispose()
        {
            this._stream.Close();
            this._core.Close();
            this._core.Dispose();
            this._stream.Close();
        }

        public HttpSimpleClient()
        {
            _core = new DNSCore();
        }
    }
}
