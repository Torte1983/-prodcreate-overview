using System;
using System.IO;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\Thorsten\source\repos\Torte1983\prodcreate-overview\prodcreate.log";
            int lineNumber = 0;
            string[] searchValue;
            int lastLineMatch = 0;
            searchValue = new string[] { "PARAMETERS", "PARAMETER_OPTIONS", "PROP",
                                         "GENERAL", "SIZE", "AFTER_SIZE", "OPTIONS",
                                         "ACTIONS"};

            string[] file = File.ReadAllLines(path);
            int[] linePara = new int[searchValue.Length];
            int[] paraSize = new int[searchValue.Length];
            for (int i = 0; i < searchValue.Length; i++)
            {
                lineNumber = 0;
                foreach (string line in file)
                {
                    lineNumber++;
                    if (line.Contains(searchValue[i]))
                    {
                        linePara[i] = lineNumber;
                        continue;
                    }
                }

                Console.WriteLine("Der Suchtext {0} befindet sich in Zeile {1}", searchValue[i], linePara[i]);
            }

            for (int i = 0; i < searchValue.Length; i++)
            {
                if (i < searchValue.Length - 1)
                {
                    paraSize[i] = linePara[i + 1] - linePara[i];
                }
                else
                {
                    paraSize[i] = file.Length - linePara[i];
                }
            }
            
            string[][] boxparas;
            boxparas = new string[searchValue.Length][];
            int n = 0;
            for (int i = 0; i < searchValue.Length; i++)
            {
                boxparas[i] = new string[paraSize[i]];
                // Aktion einfügen
                for (int j = 0; j <= paraSize[i]-1; j++)
                {
                    boxparas[i][j] = file[j + linePara[i] -1];
                    Console.WriteLine(boxparas[i][j]);
                }
                Console.WriteLine("\n");
            }
            Console.ReadLine();
        }
    }
}
 