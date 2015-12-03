using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(@"c:\users\alexandre bertrand\documents\visual studio 2012\Projects\AdventOfCode\Day2\TextFile1.txt");
            int qte = 0;
            int ruban = 0;

            foreach (string parser in lines) {

                string[] number = parser.Split('x');              
                
                int l = int.Parse(number[0]);
                int w = int.Parse(number[1]);
                int h = int.Parse(number[2]);

                List<int> all = new List<int>();
                all.Add(l);
                all.Add(w);
                all.Add(h);

                int numeprec = 0;
                foreach (int nume in all) {
                    if (numeprec < nume)
                        numeprec = nume;
                }

                all.Remove(numeprec);


                qte = qte + 2 * l * w + 2 * w * h + 2 * h * l + all[0] * all[1];

                ruban = ruban + all[0] * 2 + all[1] * 2 + l * w * h;
                

            }

            Console.WriteLine(qte);
            Console.WriteLine(ruban);
            Console.ReadLine();
        }
    }
}
