using SimpleHttpClientNet.Headers.Response;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FXNet.Contents
{
    public class Content(Stream stream)
    {
        private ResponseHeaders Headers { set; get; }
        public string GetDataFromResponse()
        {
            Headers = ResponseHeaders.ParseHeaders(stream);
            Header contentLength = Headers.FirstOrDefault(a => a.Key == "Content-Length");
            long? length = long.TryParse(contentLength.Value, out var res) ? res : null;
            if(length == null)
            {
                throw new Exception();
            }
            byte[] buffer = new byte[length.Value];
            stream.Read(buffer, 0, buffer.Length);
            return Encoding.UTF8.GetString(buffer);
        }

    }
}
