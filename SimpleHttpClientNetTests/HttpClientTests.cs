using Microsoft.VisualStudio.TestTools.UnitTesting;
using FXNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleHttpClientNet.Logging;
using SimpleHttpClientNet.Logging.Abstraction;

namespace FXNet.Tests
{
    [TestClass()]
    public class HttpClientTests
    {
        static TestServer _server;

        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            Log.SetProviderLogging(new DebugLog());
            _server = new TestServer();
            Task.Run(() =>
            {
                try
                {
                    _server.Run("http://localhost:5063");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);

                }
            });
            ;
            Thread.Sleep(20_000);
            ;
        }

        [ClassCleanup]
        public static void Cleanup()
        {
            _server.Dispose();
        }

        [TestMethod()]
        public void GetRequestTest()
        {
            
            //Console.ReadKey();
            using var client = new HttpSimpleClient();
            var content = client.Get("http://localhost:5063/home/test");
            var response = content.ReadResponse();
            string text = response.Response.GetText();
            ;
            ;
        }
    }
}