using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_5___C
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(@"c:\users\alexandre bertrand\documents\visual studio 2012\Projects\Day 5 - C\Day 5 - C\TextFile1.txt");
            


            int goodchains = 0;

            foreach (string parser in lines)
            {
                bool tilt = false;
                bool doube = false;
                List<string> chains = new List<string>();
                char prec = ' ';
                char precprec = ' ';

                foreach (char letter in parser) {

                    
                    if (chains.Contains(prec.ToString() + letter.ToString())) {

                        if (chains[chains.Count - 1] != prec.ToString() + letter.ToString() || chains[chains.Count - 2] == prec.ToString() + letter.ToString())
                            tilt = true;
                        else
                        {
                            int l;
                        }
                    }

                    if (letter == precprec)
                        doube = true;
 
                    chains.Add(prec.ToString() + letter.ToString());

                    //if(prec == letter)
                    //    doube = true;

                    //if(voyelles.Contains(letter)){
                    //    nbvoy++;
                  
                    //}

                    precprec = prec;
                    prec = letter;
                    

                }

                if (tilt && doube)
                    goodchains++;

            }

            Console.WriteLine(goodchains.ToString());
            Console.ReadLine();
        }
    }
}
