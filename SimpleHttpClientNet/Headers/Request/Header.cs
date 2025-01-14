using FXNet.HeaderRequest.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleHttpClientNet.Headers.Request
{
    public class Header : HeadersRepository, IHeader
    {
        public string GetHeaders()
        {
            string result = HeadersProtocol.GetHeaders() + "\r\n";
            foreach (var item in this)
            {
                foreach (var ele in item.Value)
                {
                    result += string.Format("{0}: {1}\r\n", item.Key, ele);
                }
                result += "\r\n\r\n";


            }
            Logging.Log.Write($"headers\n\r:{result}");
            return result;
        }
        public Header()
        {
        }
    }
}
