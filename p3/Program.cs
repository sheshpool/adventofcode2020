using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace p3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting..");
            List<string> lineList = new List<string>();

            var reader = new StreamReader(File.OpenRead(@"input.csv"));
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                lineList.Add(line);
            }

            Console.WriteLine("Partie 1 : {0}", TreeCount(lineList, 3, 1));
            
            List<TupleSteps> tupleStepsList = new List<TupleSteps>();
            tupleStepsList.Add(new TupleSteps(){rightSteps = 1, downSteps = 1});
            tupleStepsList.Add(new TupleSteps(){rightSteps = 3, downSteps = 1});
            tupleStepsList.Add(new TupleSteps(){rightSteps = 5, downSteps = 1});
            tupleStepsList.Add(new TupleSteps(){rightSteps = 7, downSteps = 1});
            tupleStepsList.Add(new TupleSteps(){rightSteps = 1, downSteps = 2});
            
            double p=1;
            foreach (var tupleSteps in tupleStepsList)
            {
                p = p * TreeCount(lineList, tupleSteps.rightSteps , tupleSteps.downSteps);
            }
            Console.WriteLine("Partie 2 : {0}", p);
            Console.WriteLine("End.");
        }
        public static int TreeCount(List<string> lineList, int rightSteps, int downSteps)
        {
            int nb=0;
            int positionX = rightSteps;
            for(int positionY = downSteps; positionY < lineList.Count; positionY = positionY + downSteps)
            {

                if(lineList[positionY][positionX % lineList[positionY].Length] == '#' )
                {
                    nb++;
                }
                positionX = positionX + rightSteps;
            }
            return nb;
        }
        //4385176320
        
    }

    public class TupleSteps
    {
        public int rightSteps { get; set; }
        public int downSteps { get; set; }

        
    }
}
