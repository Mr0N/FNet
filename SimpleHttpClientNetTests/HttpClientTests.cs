using Microsoft.VisualStudio.TestTools.UnitTesting;
using FXNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FXNet.Tests
{
    [TestClass()]
    public class HttpClientTests
    {
        static TestServer _server;

        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            _server = new TestServer();
            Task.Run(() => _server.Run("http://localhost:80"));
            Thread.Sleep(15000);
        }

        [ClassCleanup]
        public static void Cleanup()
        {
            _server.Dispose();
        }

        [TestMethod()]
        public void GetRequestTest()
        {
            using var client = new HttpSimpleClient();
            var content = client.Get("http://localhost:80/test");
            string html = content.ReadToString();
        }
    }
}