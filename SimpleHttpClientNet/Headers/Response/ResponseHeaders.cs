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
            var hedersEnumerable = ReadLineFromASCII(stream);
            using var en = hedersEnumerable.GetEnumerator();
            //using var reader = new StreamReader(stream);
            var responseHeaders = new ResponseHeaders();
            en.MoveNext();//Parse the first line
            string temp = "";
            while(en.MoveNext())
            {
                var line = en.Current;


                if (string.IsNullOrEmpty(line))
                {
                    //temp = reader.ReadLine();
                    break;

                }

                var arrayChars = line.Split(':');
                responseHeaders.Add(new Header(arrayChars[0].Trim(' '), arrayChars[1].Trim(' ')));


            }
            return responseHeaders;
        }
        static IEnumerable<string> ReadLineFromASCII(Stream memory)
        {
            List<byte> buffer = new List<byte>(100);
            byte lastChar = default;
            //foreach (var b in bytes)
            while (true)
            {
                byte b = (byte)memory.ReadByte();
                if (b == -1)
                {
                    break;
                }

                buffer.Add(b);
                if (lastChar == '\r' && b == '\n')
                {

                    yield return Encoding.ASCII.GetString(buffer.ToArray()).TrimEnd('\r','\n');
                    buffer = new List<byte>(100);
                }
                lastChar = b;
            }
        }
    }
}