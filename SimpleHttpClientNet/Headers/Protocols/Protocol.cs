using SimpleHttpClientNet.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FXNet.HeaderRequest.Protocols
{
    public class Protocol
    {

        public string GetHeaders()
        {
            string protocol = string.Format("{0} {1} {2}", this.RequestType, this.RequestValue, this.Version);
            Log.Write($"protol:{protocol}");
            return protocol;
        }
        public string Version { protected set; get; }
        public string RequestType { protected set; get; }
        public string RequestValue { protected set; get; }
        public Protocol(string RequestType, string RequestValue = "/", string Version = "HTTP/1.1")
        {
            this.Version = Version;
            this.RequestValue = RequestValue;
            this.RequestType = RequestType;
        }
    }
}
