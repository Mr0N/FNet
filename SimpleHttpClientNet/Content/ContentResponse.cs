﻿using SimpleHttpClientNet.Contents.Abstrr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleHttpClientNet.Contents
{
    public class ContentResponse: ResponseContentFromServer
    {
        public override string GetText()
        {
            var reader = new StreamReader(Data);
            return reader.ReadToEnd();
        }
        public override Stream Data { get; internal set; }
        internal ContentResponse()
        {
                    
        }
    }
}
