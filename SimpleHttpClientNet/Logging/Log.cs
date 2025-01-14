using SimpleHttpClientNet.Logging.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleHttpClientNet.Logging
{
    public static class Log
    {
        public static void Write(string text) { 
                _log.Write(text);
        }
        private static BaseLog _log = new ConsoleLog();
        public static bool WriteLog { set; get; }
        public static void SetProviderLogging(BaseLog log)
        {
            _log = log;
        }
    }
}
