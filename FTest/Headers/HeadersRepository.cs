using FXNet.HeaderRequest.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FXNet.HeaderRequest
{
   public class HeadersRepository : Dictionary<string, HashSet<string>>
    {
        public Protocol HeadersProtocol { set; get; }
        public void Add(string key,IEnumerable<string> value)
        {
            if (base.ContainsKey(key))
            {
                foreach (var item in value) base[key].Add(item);
            }
            base.Add(key,new HashSet<string>(value));
        }
       public void Add(string key,string value)
       {
            if (base.ContainsKey(key))
            {
                base[key].Add(value);
            }
            base.Add(key, new HashSet<string>() { value });
       }
        protected HeadersRepository()
        {
        }

    }
}
