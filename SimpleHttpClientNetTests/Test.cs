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
    public class Test
    {
        
     
        [TestMethod()]
        public void GetRequestTest()
        {
            
            //Console.ReadKey();
            using var client = new HttpSimpleClient();
            var content = client.Get("https://spaces.im/");
            var response = content.ReadRequest();
            string text = response.Response.GetText();
            ;
            ;
        }
    }
}