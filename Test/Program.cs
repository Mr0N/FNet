using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FXNet;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                while (true)
                {
                    try
                    {

                        httpClient.Timeouts = 150000;
                        var stream = httpClient.Get(Console.ReadLine());
                        Console.WriteLine(stream.ToString());
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            Console.ReadKey();
        }
    }
}
