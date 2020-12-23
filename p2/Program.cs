using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace p2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting..");
            List<string> pwdList = new List<string>();

            var reader = new StreamReader(File.OpenRead(@"input.csv"));
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                pwdList.Add(line);
            }

            /* Partie 1*/

            string pattern = @"-|: | ";
            int nb =0;
            foreach(string pwd in pwdList)
            {
                string[] substrings = Regex.Split(pwd, pattern);
                int count = substrings[3].Count(c => c == substrings[2][0]);               
                //Console.WriteLine("{0} {1} {2} {3} => {4}", substrings[0], substrings[1], substrings[2][0], substrings[3], count);
                if(count >= Int32.Parse(substrings[0]) && count <= Int32.Parse(substrings[1]))
                {
                    nb++;
                }
            }
            Console.WriteLine("Nb = {0}", nb);
            /* Partie 2*/
            nb =0;
            foreach(string pwd in pwdList)
            {
                int i=0;
                string[] substrings = Regex.Split(pwd, pattern);

                //Console.WriteLine("{0} {1} {2} {3} => {4}", substrings[0], substrings[1], substrings[2][0], substrings[3], count);
                i = substrings[3][Int32.Parse(substrings[0]) - 1] == substrings[2][0] ? i+1 : i;
                i = substrings[3][Int32.Parse(substrings[1]) - 1] == substrings[2][0] ? i+1 : i;
                nb = i == 1 ? nb + 1: nb;              
            }
            Console.WriteLine("Nb = {0}", nb);          
            Console.WriteLine("End.");
        }      
    }
}