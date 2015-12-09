using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_8___C
{
    class Program
    {
        static void Main(string[] args)
        {
           var fichier = System.IO.File.ReadAllText(@"c:\users\alexandre\documents\visual studio 2015\Projects\Day 8 - C\Day 8 - C\Day8.txt");
            int nocara = 0;
            int cara = 0;
            bool echap = false;
            int nb = 0;
            foreach (char caracts in fichier)
            {
                string caract = caracts.ToString();

                if (caract == "\"")
                {
                    nocara++;
                }
                else if (caract ==  @"\"){
                    nocara++;
                    echap = true;
                }
                else if (caract == @"\")
                {
                    nocara++;
                    echap = true;
                }

                else
                {
                    if (echap && caract == "x")
                    {
                        nocara++;
                        nb++;
                    }
                    else if (echap && nb == 1)
                    {
                        nocara++;
                        nb++;
                    }
                    else if (echap && nb == 2)
                    {
                        nocara++;
                        nb = 0;
                    }
                    else { 
                        cara++;
                        nb = 0;
                    }
                }

            }
            Console.WriteLine(cara - nocara);
            Console.ReadLine();

        }
    }
}
