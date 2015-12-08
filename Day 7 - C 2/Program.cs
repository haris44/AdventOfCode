using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_7___C_2
{
    class Program
    {

        public static Dictionary<string, int> openWith;
        static void Main(string[] args)
        {

            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Alexandre\Documents\AdventOfCode\Day 7 - C 2\day7.txt");
            openWith = new Dictionary<string, int>();

            foreach (var line in lines)
            {
                string[] part = line.Split(' ');
                string key = part[part.Length - 1];
                string arg;

                if(part.Length == 3)
                {
                    arg = "ADD"
                }
                else if(part.Length == 4)
                {
                    arg = "NOT";
                }
                else if(part.Length == )


            }
        }
    }
}
