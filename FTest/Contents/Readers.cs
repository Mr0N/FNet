using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FXNet.Contents
{
    public class Readers
    {
        StreamReader streamReader;
        Encoding encoding;
        //public int ReadTimeout
        //{
        //    set => stream.ReadTimeout = value;
        //    get => stream.ReadTimeout;
        //}
        public string ReadToString()
        {

            return streamReader.ReadToEnd();
            //StringBuilder stringBuilder = new StringBuilder();
            //byte[] Buffer = new byte[1024];
            //int pos = -1;
            //while (pos != 0)
            //{
            //    pos = (Buffer, 0, Buffer.Length);
            //    stringBuilder.Append(encoding.GetString(Buffer));
            //}
            //return stringBuilder.ToString();
        }


        public Readers(Stream stream, Encoding encoding,int ReadTimeouts)
        {
            var streams = stream;
            streams.ReadTimeout = 20000;
            this.streamReader = new StreamReader(streams);
            //this.stream.ReadTimeout = (int)TimeSpan.FromSeconds(30).TotalMilliseconds;
            this.encoding = encoding;
        }
    }
}
