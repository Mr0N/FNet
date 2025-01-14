using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleHttpClientNet.Logging.Abstraction
{
    public class ConsoleLog : BaseLog
    {
        public override void Write(string text)
        {
            Console.WriteLine(text);
        }
    }
}
