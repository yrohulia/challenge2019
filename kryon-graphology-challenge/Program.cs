using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using kryongraphologychallenge.Helpers;
using Newtonsoft.Json.Linq;

namespace kryon_graphology_challenge
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //   /$$   /$$                                        
            //  | $$  /$$/                                        
            //  | $$ /$$/   /$$$$$$  /$$   /$$  /$$$$$$  /$$$$$$$ 
            //  | $$$$$/   /$$__  $$| $$  | $$ /$$__  $$| $$__  $$
            //  | $$  $$  | $$  \__/| $$  | $$| $$  \ $$| $$  \ $$
            //  | $$\  $$ | $$      | $$  | $$| $$  | $$| $$  | $$
            //  | $$ \  $$| $$      |  $$$$$$$|  $$$$$$/| $$  | $$
            //  |__/  \__/|__/       \____  $$ \______/ |__/  |__/
            //                       /$$  | $$                    
            //                      |  $$$$$$/                    
            //                       \______/                     

            // TODO: STAGE 1 //
            string[] paths = { "demo-1.jpeg", "demo-2.jpeg", "demo-3.jpeg", "demo-4.jpeg", "demo-5.jpeg" };

            foreach (string path in paths) {
                Console.WriteLine("\nReading challenge file " + path + "...\n");
                JToken responseObject = HandwritingAnalyzer.ReadHandwrittenText("./Image-files/" + path).Result;
                Console.WriteLine(responseObject.ToString());
                // TODO: STAGE 2 //
                // WANT TO ANALYZE HUGE AMOUNTS OF TEXT 
                // AND UTILIZE IT TO PARTICIPATE THE NEXT
                // INDUSTRIAL REVOLUTION?
                // result += responseObject....
            }

            // TODO: STAGE 3 //
            Console.WriteLine("\nCan you find the connection between the outputs above?");
            Console.WriteLine("\nSend us your solution with the github repo and your CV to challenge@kryon.com and wait for our call!\n");
            Console.ReadLine();
        }
    }
}
