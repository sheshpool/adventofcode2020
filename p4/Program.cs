using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace p4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting..");

            //var reader = new StreamReader(File.OpenRead(@"input.txt"));
            string inputString = File.ReadAllText(@"input.txt");

            List<Passeport> passportList = new List<Passeport>();
            List<Passeport> passportList2 = new List<Passeport>();
            string splitPattern = @"\n\n";
            string [] passportStrings = Regex.Split(inputString, splitPattern);

            /* Partie 1*/
            var byrRegex = new Regex(@"(?<=byr:)([^( |\n|)]*)");
            var iyrRegex = new Regex(@"(?<=iyr:)([^( |\n|)]*)");
            var eyrRegex = new Regex(@"(?<=eyr:)([^( |\n|)]*)");
            var hgtRegex = new Regex(@"(?<=hgt:)([^( |\n|)]*)");
            var hclRegex = new Regex(@"(?<=hcl:)([^( |\n|)]*)");
            var eclRegex = new Regex(@"(?<=ecl:)([^( |\n|)]*)");
            var pidRegex = new Regex(@"(?<=pid:)([^( |\n|)]*)"); 
            var cidRegex = new Regex(@"(?<=cid:)([^( |\n|)]*)");
            foreach (var passportString in passportStrings)
            {
                Passeport passeport = new Passeport();
                passeport.Byr = byrRegex.Match(passportString).Groups[0].Value.ToString();
                passeport.Iyr = iyrRegex.Match(passportString).Groups[0].Value.ToString();
                passeport.Eyr = eyrRegex.Match(passportString).Groups[0].Value.ToString();
                passeport.Hgt = hgtRegex.Match(passportString).Groups[0].Value.ToString();
                passeport.Hcl = hclRegex.Match(passportString).Groups[0].Value.ToString();
                passeport.Ecl = eclRegex.Match(passportString).Groups[0].Value.ToString();             
                passeport.Pid = pidRegex.Match(passportString).Groups[0].Value.ToString();       
                passeport.Cid = cidRegex.Match(passportString).Groups[0].Value.ToString();
                passportList.Add(passeport);
            }
            int nb = 0;
            int i = 0;
            foreach (var passeport in passportList)
            {
                i++;

                if(
                       passeport.Iyr != ""
                    && passeport.Ecl != "" 
                    && passeport.Hgt != ""
                    && passeport.Pid != ""
                    && passeport.Byr != ""
                    && passeport.Hcl != ""
                    && passeport.Eyr != ""	
                )
                {
                    Console.Write("{1} : ");
                    nb++;                
                }
                else
                {
                    Console.Write("{0} : ");
                }
                
                Console.WriteLine("{8} => byr:{0}, iyr:{1}, eyr:{2}, hgt:{3}, hcl:{4}, ecl:{5}, pid:{6}, cid:{7}"           
                ,passeport.Byr
                ,passeport.Iyr
                ,passeport.Eyr
                ,passeport.Hgt
                ,passeport.Hcl
                ,passeport.Ecl
                ,passeport.Pid
                ,passeport.Cid
                ,i
                );
                
            }

            Console.WriteLine("Partie 1 : {0}", nb);

            /* Partie 2*/
            byrRegex = new Regex(@"(?<=byr:)([0-9]{4})(?= |\n|)");
            iyrRegex = new Regex(@"(?<=iyr:)([0-9]{4})(?= |\n|)");
            eyrRegex = new Regex(@"(?<=eyr:)([0-9]{4})(?= |\n|)");
            hgtRegex = new Regex(@"(?<=hgt:)([0-9]+cm|[0-9]+in)(?= |\n|)");
            hclRegex = new Regex(@"(?<=hcl:)(#[0-9a-f]{6})(?= |\n|)");
            eclRegex = new Regex(@"(?<=ecl:)(amb|blu|brn|gry|grn|hzl|oth)(?= |\n|)");
            pidRegex = new Regex(@"(?<=pid:)([0-9]{9})(?= |\n|)"); 
            cidRegex = new Regex(@"(?<=cid:)([^( |\n)]*)(?= |\n|)");
            foreach (var passportString in passportStrings)
            {
                Passeport passeport = new Passeport();
                passeport.Byr = byrRegex.Match(passportString).Groups[0].Value.ToString();
                passeport.Iyr = iyrRegex.Match(passportString).Groups[0].Value.ToString();
                passeport.Eyr = eyrRegex.Match(passportString).Groups[0].Value.ToString();
                passeport.Hgt = hgtRegex.Match(passportString).Groups[0].Value.ToString();
                passeport.Hcl = hclRegex.Match(passportString).Groups[0].Value.ToString();
                passeport.Ecl = eclRegex.Match(passportString).Groups[0].Value.ToString();             
                passeport.Pid = pidRegex.Match(passportString).Groups[0].Value.ToString();       
                passeport.Cid = cidRegex.Match(passportString).Groups[0].Value.ToString();
                passportList2.Add(passeport);
            }

            nb = 0;
            i = 0;
            foreach (var passeport in passportList2)
            {
                i++;

                if(
                       passeport.Iyr == ""
                    || passeport.Ecl == "" 
                    || passeport.Hgt == ""
                    || passeport.Pid == ""
                    || passeport.Byr == ""
                    || passeport.Hcl == ""
                    || passeport.Eyr == ""	
                )
                {
                    Console.Write("{0} : ");              
                }
                else
                {
                    int hgtValue = Int32.Parse(passeport.Hgt.Substring(0, passeport.Hgt.Length-2));
                    string hgtType = passeport.Hgt.Substring(passeport.Hgt.Length-2, 2);

                    if(
                           Int32.Parse(passeport.Byr) >= 1920 && Int32.Parse(passeport.Byr) <= 2002
                        && Int32.Parse(passeport.Iyr) >= 2010 && Int32.Parse(passeport.Iyr) <= 2020
                        && Int32.Parse(passeport.Eyr) >= 2020 && Int32.Parse(passeport.Eyr) <= 2030
                        && (
                                   hgtType == "cm" && hgtValue>=150 && hgtValue<=193
                                || hgtType == "in" && hgtValue>=59 && hgtValue<=76
                                )
                    )
                    {
                        Console.Write("{1} : ");
                        nb++;
                    }
                    else
                    {
                        Console.Write("{0} : ");
                    }
                }
                
                Console.WriteLine("{8} => byr:{0}, iyr:{1}, eyr:{2}, hgt:{3}, hcl:{4}, ecl:{5}, pid:{6}, cid:{7}"           
                ,passeport.Byr
                ,passeport.Iyr
                ,passeport.Eyr
                ,passeport.Hgt
                ,passeport.Hcl
                ,passeport.Ecl
                ,passeport.Pid
                ,passeport.Cid
                ,i
                );
                
            }

            Console.WriteLine("Partie 2 : {0}", nb);

            Console.WriteLine("End.");
        }
    }

    public class Passeport
    {
        public string Byr { get; set; }
        public string Iyr { get; set; }
        public string Eyr { get; set; }
        public string Hgt { get; set; }
        public string Hcl { get; set; }
        public string Ecl { get; set; }
        public string Pid { get; set; }
        public string Cid { get; set; }
    }
}