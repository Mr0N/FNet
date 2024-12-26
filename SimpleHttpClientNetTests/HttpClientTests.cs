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
        
        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            new TestServer().Run("http://localhost:5000");
        }

        [ClassCleanup]
        public static void Cleanup()
        {
         
        }

        [TestMethod()]
        public void GetRequestTest()
        {
            ;
        }
    }
}