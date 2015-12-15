using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_12___C
{
    class Program
    {
        static void Main(string[] args)
        {
            string lines = System.IO.File.ReadAllText(@"c:\users\macpro\documents\visual studio 2015\Projects\Day 12 - C\Day 12 - C\day12.txt");
            double total = 0;

            bool moins = false;
            string numencours = "";

            bool inob = false;
            objet encours = null;

            foreach (char c in lines)
            {
              
                if (c == '{' && inob == false)                  
                {
                    encours = new objet();
                    inob = true;
                }
                else if (c == '}' && inob == true && encours.inobjet == null)
                {
                    encours = null;
                    inob = false;
                }
                else if (inob == true)
                {
                   encours.checkcarac(c);
                }
                else if (Char.IsNumber(c))
                {
                    numencours += c;
                }
                else if (c == '-')
                {
                    moins = true;
                }
                else
                {
                    if (numencours != "")
                    {
                        if (moins)
                            total -= (double.Parse(numencours));
                        else
                        {
                            total += (double.Parse(numencours));
                        }
                        numencours = "";
                        moins = false;
                    }
                    else
                    {
                        numencours = "";
                        moins = false;
                    }

                }

            }
            Console.WriteLine(total);
            Console.ReadLine();
        }


    }
}
