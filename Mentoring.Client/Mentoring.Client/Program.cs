using Mentoring.Client.Impls;
using System;
using System.Net.Http;

namespace Mentoring.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.InputEncoding = System.Text.Encoding.Unicode;
            var repo = new Repository(new HttpClient());
            var render = new Render(repo);
            render.Run().Wait();
        }
    }
}
