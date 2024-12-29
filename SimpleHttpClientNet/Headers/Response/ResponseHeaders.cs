using FXNet.HeaderRequest.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleHttpClientNet.Headers.Response
{
    public record Header(string Key, string Value);
    public class ResponseHeaders : List<Header>
    {
        public Protocol protocol { get; private set; }
        public static ResponseHeaders ParseHeaders(Stream stream)
        {
            var reader = new StreamReader(stream);
            var responseHeaders = new ResponseHeaders();
            string firstLine = reader.ReadLine();//Parse the first line
            do
            {
                var line = reader.ReadLine();

                if (string.IsNullOrEmpty(line))
                {
                    break;
                }
                var arrayChars = line.Split(':');
                responseHeaders.Add(new Header(arrayChars[0], arrayChars[1]));
            } while (!reader.EndOfStream);
            return responseHeaders;
        }

    }
}
