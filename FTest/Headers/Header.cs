using FXNet.HeaderRequest.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FXNet.HeaderRequest
{
    public class Header : HeadersRepository, IHeader
    {
        public string GetHeaders()
        {
            string result = this.HeadersProtocol.GetHeaders() + "\r\n";
            foreach (var item in this)
            {
                foreach (var ele in item.Value)
                {
                    result += string.Format("{0}: {1}\r\n", item.Key , ele);
                }
                result += "\r\n\r\n";


            }
            return result;
        }
        public Header()
        {
        }
    }
}
