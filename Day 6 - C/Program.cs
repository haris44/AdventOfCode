using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_6___C
{
    class Program
    {
        static void Main(string[] args)
        {


            string[] lines = System.IO.File.ReadAllLines(@"c:\users\alexandre bertrand\documents\visual studio 2012\Projects\Day 6 - C\Day 6 - C\day6.txt");
           
            int[,] tab = new int[1000, 1000];

            foreach (string line in lines)
            {
                string[] ligne = line.Split(' ');
                string action;

                int xdeb;
                int xfin;
                int ydeb;
                int yfin;

                if (ligne.Length == 5)
                {

                    action = ligne[0] + ' ' + ligne[1];

                    string[] deb = ligne[2].Split(',');
                    xdeb = int.Parse(deb[0]);
                    ydeb = int.Parse(deb[1]);

                    string[] fin = ligne[4].Split(',');
                    xfin = int.Parse(fin[0]);
                    yfin = int.Parse(fin[1]);


                }
                else {
                    action = ligne[0];

                    string[] deb = ligne[1].Split(',');
                    xdeb = int.Parse(deb[0]);
                    ydeb = int.Parse(deb[1]);

                    string[] fin = ligne[3].Split(',');
                    xfin = int.Parse(fin[0]);
                    yfin = int.Parse(fin[1]);
                }
                //List<string> coord = new List<string>();

                for (int i = ydeb; i < yfin + 1; i++)
                {
                    for (int j = xdeb; j < xfin + 1; j++)
                    {
                        
                        if (action == "turn on") {
                            tab[j, i] += 1;
                        }
                        else if (action == "turn off" && tab[j, i] != 0)
                        {
                            tab[j, i] -= 1;
                        }
                        else if (action == "toggle")
                        {
                            tab[j, i] += 2;
                        }

                        //coord.Add(j + " " + i + " " + tab[j, i]);

                    }
                }


               
            }

            

            int total = 0;
            foreach (int result in tab) {                
                    total += result;
                
            }

            Console.WriteLine(total);
            Console.ReadLine();



        }
    }
}
