using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_3
{
    class Program
    {
        static void Main(string[] args)
        {

            string lines = System.IO.File.ReadAllText(@"C:\Users\Alexandre BERTRAND\documents\visual studio 2012\Projects\AdventOfCode\Day 3\TextFile1.txt");

            int[,] tab = new int[9999, 9999];
            int x = 5000;
            int y = 5000;

            int xrobo = 5000;
            int yrobo = 5000;
            bool prec = true;

            tab[x, y] += 1;
            tab[xrobo, yrobo] += 1;

            foreach (char c in lines)
            {
                if (prec)
                {
                    if (c.Equals('<'))
                        x += -1;
                    else if (c.Equals('>'))
                        x += 1;
                    else if (c.Equals('^'))
                        y += -1;
                    else if (c.Equals('v'))
                        y += 1;

                    tab[x, y] += 1;
                    prec = false;
                }
                else
                {
                    if (c.Equals('<'))
                        xrobo += -1;
                    else if (c.Equals('>'))
                        xrobo += 1;
                    else if (c.Equals('^'))
                        yrobo += -1;
                    else if (c.Equals('v'))
                        yrobo += 1;

                    tab[xrobo, yrobo] += 1;
                    prec = true;
                }


            }

            int nbgens = 0;
            foreach (int nbkdo in tab)
            {

                if (nbkdo >= 1)
                    nbgens++;
            }

            Console.WriteLine(nbgens);
            Console.ReadLine();


        }
    }
}
