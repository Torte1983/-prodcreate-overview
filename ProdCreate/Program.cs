using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace ProdCreate
{
    class Program
    {
        public static void Main(string[] args)
        {
            string path = @"C:\Users\Thorsten\source\repos\Torte1983\prodcreate-overview\prodcreate.log";
            string name = "BOXCARD";
            string line;
            int pos = 0;
            List<int> paras = new List<int>();

          
            
            // Zeilen lesen
           StreamReader file = new StreamReader(path);
           while((line = file.ReadLine()) != null)
           {
               if (line.Contains(name))
               {
               paras.Add(pos);
               Console.WriteLine(pos);
                  
               }
               pos++;
           }
            if (paras.Count == 1)
            {
                Console.WriteLine("Es wurde eine Produktionsdatei gefunden");
            }
            else
            {
                Console.WriteLine("Es wurden {0} Produktionsdateien gefunden", paras.Count);
            }
            
            // Declare an array depending found boxcards
            int[] array = new int[paras.Count];

            paras.CopyTo(array);
            Console.ReadLine();
        }
    }
}

