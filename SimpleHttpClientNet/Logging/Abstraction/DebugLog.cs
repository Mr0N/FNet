using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleHttpClientNet.Logging.Abstraction
{
    public class DebugLog : BaseLog
    {
        public override void Write(string text)
        {
            Debug.WriteLine(text);
        }
    }
}
