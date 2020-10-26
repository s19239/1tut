using System;
using System.Collections.Generic;
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
            HttpClient client = new HttpClient();
            HttpResponseMessage res = await  client.GetAsync(args[0]);
            if (res.IsSuccessStatusCode)
            {
                string content = await res.Content.ReadAsStringAsync();
                emails(content);
                   
            
            }
            //Console.WriteLine("Hello World!");

             void emails(string text)
            {
                Regex reg = new Regex(@"[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,6}", RegexOptions.IgnoreCase);

                MatchCollection matches = reg.Matches(text);
                // Report the number of matches found.
                int noOfMatches = matches.Count;
                // Report on each match.
                foreach (Match match in matches)
                {
                    Console.WriteLine(match.Value.ToString());
                }
            }
        }
    }
}
