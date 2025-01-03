using SimpleHttpClientNet.Contents.Abstrr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleHttpClientNet.Contents
{
    public class ContentResponseChunk : ResponseContentFromServer
    {
        public override string GetText()
        {
            var builder = new StringBuilder();
          
            while (true)
            {
                byte[] buffer = new byte[1];
                int qq = streamContent.ReadByte();
               // string hex = Encoding.UTF8.GetString(buffer);
            }
            return builder.ToString();
        }
        public override Stream streamContent { get; internal set; }
        internal ContentResponseChunk()
        {

        }
    }
}
