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
            string text = string.Concat(ReadChunks());
            return text;
        }
        private IEnumerable<string> ReadChunks()
        {
            while (true)
            {
                int sizeChunk = GetSizeChunk();
                if (sizeChunk == 0)
                    break;
                string text = ReadFromChunk(sizeChunk);
                yield return text;
            }
        }
        private string ReadFromChunk(int size)
        {
            byte[] buffer = new byte[size];
            Data.Read(buffer, 0, buffer.Length);
            if (!(Data.ReadByte() == '\r'))
                throw new Exception();
            if (!(Data.ReadByte() == '\n'))
                throw new Exception();
            return _encoding.GetString(buffer);
        }
        private int GetSizeChunk()
        {
            var ls = new List<byte>(16);
            byte tempByte = default;
            while (true)
            {

                byte data = (byte)Data.ReadByte();
                ls.Add(data);
                if(ls.Count > 1000)
                {
                    throw new Exception("The server sends a chunk of incorrect size.");
                }
                if (data == '\n' && tempByte == '\r')
                {
                    //  var read = new StreamReader(temp);
                    var size = Encoding.ASCII.GetString(ls.ToArray()).TrimEnd('\r', '\n');
                    if(size.Contains(";"))//extension
                    {
                        size = size.Split(';')[0];
                    }
                    return int.TryParse(size, System.Globalization.NumberStyles.HexNumber, null, out var res) ? res : throw new Exception("Invalid hex format");

                }
                if (data == -1) break;


                tempByte = data;
            }
            throw new Exception();
        }
        public override Stream Data { get; internal set; }
        Encoding _encoding;
        internal ContentResponseChunk(Encoding encoding = null)
        {
            if (encoding == null)
            {
                encoding = Encoding.UTF8;
            }
            _encoding = encoding;
        }
    }
}
