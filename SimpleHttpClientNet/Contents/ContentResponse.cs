using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleHttpClientNet.Contents
{
    public class ContentResponse
    {
        public string GetText()
        {
            var reader = new StreamReader(streamContent);
            return reader.ReadToEnd();
        }
        public Stream streamContent { get; internal set; }
        internal ContentResponse()
        {
                    
        }
    }
}
