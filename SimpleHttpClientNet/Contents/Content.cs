using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FXNet.Contents
{
   public class Content:Readers
    {
        public override string ToString()
        {
             return  base.ReadToString();
        }
        public Content(Stream stream,Encoding encoding,int ReadersTimeout):base(stream,encoding, ReadersTimeout)
        {
          
        }
    }
}
