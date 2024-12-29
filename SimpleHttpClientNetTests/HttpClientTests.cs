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
            Task.Run(() =>
            {
                try
                {
                    _server.Run("http://127.0.0.1:11");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);

                }
            });

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
            Thread.Sleep(10_000);
            //Console.ReadKey();
            using var client = new HttpSimpleClient();
            var content = client.Get("http://localhost:11/Test");
            var response = content.ReadRequest();
            string text = response.Response.GetText();
            ;
            ;
        }
    }
}