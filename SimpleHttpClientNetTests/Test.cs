using Microsoft.VisualStudio.TestTools.UnitTesting;
using FXNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleHttpClientNet.Logging.Abstraction;
using SimpleHttpClientNet.Logging;

namespace FXNet.Tests
{
    [TestClass()]
    public class Test
    {
        
     
        [TestMethod()]
        public void GetRequestTest()
        {
            Log.SetProviderLogging(new DebugLog());
            //Console.ReadKey();
            using var client = new HttpSimpleClient();
            var content = client.Get("https://spaces.im/");
            var response = content.ReadResponse();
            string text = response.Response.GetText();
            ;
            ;
        }
    }
}