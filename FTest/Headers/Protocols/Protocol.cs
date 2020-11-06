using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FXNet.HeaderRequest.Protocols
{
    public class Protocol
    {
        public string GetHeaders()
        {
            return string.Format("{0} {1} {2}", this.RequestType, this.RequestValue, this.Version);
        }
        public string Version { protected set; get; }
        public string RequestType {protected set; get; }
        public string RequestValue { protected set; get; }
        public Protocol(string RequestType, string RequestValue="/", string Version= "HTTP/1.1")
        {
            this.Version = Version;
            this.RequestValue = RequestValue;
            this.RequestType = RequestType;
        }
    }
}
