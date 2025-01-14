using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleHttpClientNet.Logging.Abstraction
{
    public abstract class BaseLog
    {
        public abstract void Write(string text);

    }
}
