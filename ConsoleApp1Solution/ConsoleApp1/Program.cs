using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            if (args.Length == 0)
            {
                throw new ArgumentNullException("parameter 1 has not been passed");
            }
            else if (args == null)
            {
                throw new ArgumentException("parameter is null");
            }
                HttpClient client = new HttpClient();
            HttpResponseMessage res = await  client.GetAsync(args[0]);
            if (res.IsSuccessStatusCode)
            {
                string content = await res.Content.ReadAsStringAsync();
                emails(content);
                   
            }
            else
            {
                throw new ArgumentException("Error while downloading the page");
            }
            client.Dispose();

             void emails(string text)
            {
                Regex reg = new Regex(@"[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,6}", RegexOptions.IgnoreCase);

              
                var matches = reg.Matches(text);
                var uniqueMatches = matches
                    .OfType<Match>()
                    .Select(m => m.Value)
                    .Distinct();


                if (matches.Count == 0)
                    Console.WriteLine("No email addresses found");
                else
                {
                    uniqueMatches.ToList().ForEach(Console.WriteLine);
                }
            }
        }
    }
}
