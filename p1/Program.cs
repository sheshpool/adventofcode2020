using System;
using System.IO;
using System.Collections.Generic;

namespace p1
{
    class Program
    {
        static void Main(string[] args)
        {      
            const int TARGET_VALUE = 2020;

            Console.WriteLine("Starting..");
            var reader = new StreamReader(File.OpenRead(@"input.csv"));
            List<int> expenseList = new List<int>();
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                expenseList.Add(Int32.Parse(line));
            }
            expenseList.Sort();
            int i, j, k;
            bool isFound = false;
            int nbIt = 0;
            i=0; j=0;
            /* Partie 1*/
            while(i<expenseList.Count && expenseList[i]<= TARGET_VALUE && !isFound)
            {
                j = 0;
                while(j<expenseList.Count && expenseList[i] + expenseList[j] <= TARGET_VALUE && !isFound)
                {
                    if(expenseList[i] + expenseList[j] == TARGET_VALUE)
                    {
                        Console.WriteLine("{0} x {1} = {2}", expenseList[i], expenseList[j], expenseList[i]*expenseList[j]);
                        isFound = true;
                    }
                    j++;
                    nbIt++; //652/40000 combinaisons totales
                }
                i++;
            }
            Console.WriteLine(nbIt);
            /* Partie 2*/
            i=0; j=0;k=0;isFound=false;nbIt=0;
            while(i<expenseList.Count && expenseList[i]<= TARGET_VALUE && !isFound)
            {
                j = 0;
                while(j<expenseList.Count && expenseList[i] + expenseList[j] <= TARGET_VALUE && !isFound)
                {
                    k=0;
                    while(k<expenseList.Count && expenseList[i] + expenseList[j] + expenseList[k]<= TARGET_VALUE && !isFound)
                    {                   
                        if(expenseList[i] + expenseList[j] + expenseList[k] == TARGET_VALUE)
                        {
                            Console.WriteLine("{0} x {1} x {2} = {3}", expenseList[i], expenseList[j], expenseList[k], expenseList[i]*expenseList[j]*expenseList[k]);
                            isFound = true;
                        }
                        k++;
                        nbIt++;
                    }             
                    j++;
                    nbIt++; //447/8000000 combinaisons totales
                }
                i++;
            }
            Console.WriteLine("End.");
            Console.WriteLine(nbIt);
            Console.Read();
        }
    }
}