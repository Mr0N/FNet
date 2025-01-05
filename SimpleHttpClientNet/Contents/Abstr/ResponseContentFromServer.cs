using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleHttpClientNet.Contents.Abstrr
{
    public abstract class ResponseContentFromServer
    {
        public abstract string GetText();
        public abstract Stream Data { get; internal set; }
    }
}
