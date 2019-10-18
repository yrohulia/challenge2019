using System;
using System.IO;
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

            string[] paths = Directory.GetFiles("./Image-files/");

            foreach (string path in paths) {
                Console.WriteLine("\nReading challenge file " + path + "...\n");
                var process = HandwritingAnalyzer.ReadHandwrittenText(path);
                process.Wait();
                JToken result = process.Result;

                if (result["status"].ToString() == "Succeeded")
                {
                    foreach (var page in result["recognitionResults"])
                    {
                        Console.WriteLine($"Page: {page["page"]}\n");

                        foreach (var line in page["lines"])
                        {
                            foreach (var word in line["words"])
                            {
                                if (word["confidence"] != null)
                                {
                                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                                }

                                Console.Write($"{word["text"]}");
                                Console.ResetColor();

                                if (word.Next != null)
                                {
                                    Console.Write(" ");
                                }
                            }

                            Console.WriteLine();
                        }
                    }
                }
                else
                {
                    Console.WriteLine($"Error recognizing the text - {result["status"]}");
                }
            }

            Console.ReadLine();
        }
    }
}
