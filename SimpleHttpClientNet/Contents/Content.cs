using SimpleHttpClientNet.Contents;
using SimpleHttpClientNet.Contents.Abstrr;
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
        public ResponseHeaders Headers { private set; get; }
        public ResponseContentFromServer Response { private set; get; }

        public Content ReadRequest()
        {
            Headers = ResponseHeaders.ParseHeaders(stream);
            if(Headers.FirstOrDefault(a => a.Key == "Transfer-Encoding")?.Value == "chunked")
            {
                Response = new ContentResponseChunk() { Data = stream };
                return this;
            }
            Header contentLength = Headers.FirstOrDefault(a => a.Key == "Content-Length");
            

            long? length = long.TryParse(contentLength.Value, out var res) ? res : null;
            byte[] buffer = new byte[length.Value];
            stream.Read(buffer, 0, buffer.Length);
            var memory = new MemoryStream(buffer);
            Response = new ContentResponse() { Data = memory };
            return this;
        }

    }
}
